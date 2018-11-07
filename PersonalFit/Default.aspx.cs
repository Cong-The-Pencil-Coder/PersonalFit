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
            passwordTextBox.Value = "Does not pass white List Test";
        }
    }

    private void LoginWithPasswordHashFunction()
    {
        List<String> salthashList = null;
        List<String> namesList = null;
        try
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();

            conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            conn.Open();
            String query = "SELECT slowHashSalt, firstname, middlename, lastname FROM webAppPersonalFit.userregistration WHERE username=?uname";
            
            cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("?uname", usernameTextBox.Value);

            reader = cmd.ExecuteReader();

            while (reader.HasRows && reader.Read())
            {
                if (salthashList == null)
                {
                    salthashList = new List<String>();
                    namesList = new List<String>();
                }

                String saltHashes = reader.GetString(reader.GetOrdinal("slowHashSalt"));
                //Console.WriteLine(saltHashes);
                salthashList.Add(saltHashes);

                String fullname = reader.GetString(reader.GetOrdinal("firstname")) + " " + reader.GetString(reader.GetOrdinal("lastname"));
                namesList.Add(fullname);
            }

            if(salthashList != null)
            {
                for(int i = 0; i < salthashList.Count; i++)
                {
                    bool validUser = PasswordStorage.VerifyPassword(passwordTextBox.Value, salthashList[i]);

                    if (validUser == true)
                    {
                        Session["UserName"] = namesList[i];
                        Response.BufferOutput = true;
                        Response.Redirect("LoggedIn.aspx", false);
                    }
                    else
                    {
                        passwordTextBox.Value = "User not authenticated";
                    }

                }
            }
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