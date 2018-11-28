using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader reader;
    String connectionString;
    String name;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submitButtonEventMethod(object sender, EventArgs e)
    {
        if(checkAgainstWhiteList(usernameTextBox.Value) == true &&
            checkAgainstWhiteList(passwordTextBox.Value) == true)
        {
            //DoSQLQuery();
            LoginWithPasswordHashFunction();
        }
        else
        {
            ValidationTextBoxLabel.Text = "Invalid Username or Password.";
        }
    }

    private void LoginWithPasswordHashFunction()
    {
        String saltHash = null;
        String userID="";
        try
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();

            conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            conn.Open();
            String query = "SELECT slowHashSalt, firstname, middlename, lastname FROM webAppPersonalFit.userregistration WHERE username=?uname";
            
            cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("?uname", usernameTextBox.Value);

            reader = cmd.ExecuteReader();

            if(reader.HasRows && reader.Read())
            {
                String saltHashes = reader.GetString(reader.GetOrdinal("slowHashSalt"));
                //Console.WriteLine(saltHashes);
                saltHash = saltHashes;

                userID = reader.GetString(reader.GetOrdinal("firstname")) + " " + reader.GetString(reader.GetOrdinal("lastname"));
            }
            else
            {
                ValidationTextBoxLabel.Text = "Invalid Username or Password.";
            }
            if(saltHash != null)
            {
                bool validUser = PasswordStorage.VerifyPassword(passwordTextBox.Value, saltHash);

                if (validUser == true)
                {
                    Session[userID] = userID;
                    Response.BufferOutput = true;
                    Response.Redirect("TrainerCatalog.aspx", false);
                }
                else
                {
                    ValidationTextBoxLabel.Text = "Invalid Username or Password.";
                }
            }
            ValidationTextBoxLabel.Text = "Invalid Username or Password.";
            reader.Close();
            conn.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private bool checkAgainstWhiteList(String userInput)
    {
        var regExpression = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9]*$");
        if(regExpression.IsMatch(userInput))
            return true;
        else
            return false;
    }

    private void DoSQLQuery()
    {
        try
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            conn.Open();

            //String query = "SELECT * FROM webapppersonalfit.userregistration WHERE username='" + usernameTextBox.Text +
            //    "' AND userpassword='" + passwordTextBox.Text + "'";

            String query = "SELECT * FROM webapppersonalfit.userregistration WHERE username=?uname AND userpassword=?pword";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);

            //usernameTextBox.Text => return string => string comparison to against the SQL injection
            cmd.Parameters.AddWithValue("?uname", usernameTextBox.Value);
            cmd.Parameters.AddWithValue("?pword", passwordTextBox.Value);

            reader = cmd.ExecuteReader();
            name = "";
            while (reader.HasRows && reader.Read())
            {
                name = reader.GetString(reader.GetOrdinal("firstname")) + " " + reader.GetString(reader.GetOrdinal("lastname"));
            }
            if (reader.HasRows)
            {
                Session["UserName"] = name;
                Response.BufferOutput = true;
                Response.Redirect("LoggedIn.aspx", false);
            }
            else
            {
                passwordTextBox.Value = "Invalid User";
            }
            reader.Close();
            conn.Close();
        }
        catch(Exception e)
        {
            passwordTextBox.Value = e.ToString();
        }
    }
}