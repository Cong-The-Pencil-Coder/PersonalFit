using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    String queryString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void registerEventMethod(object sender, EventArgs e)
    {
        registerUserWithSlowHash();
    }

    private void registerUserWithSlowHash()
    {
        bool methodStatus = true;

        if(InputValidation.ValidatePhoneNumber(phoneNumberTextBox.Text) == false)
            methodStatus = false;

        if (InputValidation.ValidateName(firstNameTextBox.Text) == false)
            methodStatus = false;

        if (InputValidation.ValidateName(middleNameTextBox.Text) == false)
            methodStatus = false;

        if (InputValidation.ValidateName(lastNameTextBox.Text) == false)
            methodStatus = false;

        if (InputValidation.ValidateUserInput(usernameTextBox.Text) == false)
            methodStatus = false;

        if (InputValidation.ValidateUserInput(passwordTextBox.Text) == false)
            methodStatus = false;

        if (InputValidation.ValidateEmail(emailTextBox.Text) == false)
            methodStatus = false;

        if(methodStatus == true)
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();

            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();

            queryString = "";

            queryString = "INSERT INTO webapppersonalfit.userregistration (firstname, middlename, lastname, email, phonenumber, username, slowHashSalt)"
                        + "VALUES(?firstname, ?middlename, ?lastname, ?email, ?phonenumber, ?uname, ?userpassword, ?slowHashSalt)";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryString, conn);
            cmd.Parameters.AddWithValue("?firstname", firstNameTextBox.Text);
            cmd.Parameters.AddWithValue("?middlename", middleNameTextBox.Text);
            cmd.Parameters.AddWithValue("?lastname", lastNameTextBox.Text);
            cmd.Parameters.AddWithValue("?email", emailTextBox.Text);
            cmd.Parameters.AddWithValue("?phonenumber", phoneNumberTextBox.Text);
            cmd.Parameters.AddWithValue("?uname", usernameTextBox.Text);
            cmd.Parameters.AddWithValue("?userpasswird", passwordTextBox.Text);
            //cmd.Parameters.AddWithValue("?slowHashSalt", passwordTextBox.Text);

            String saltHashReturned = PasswordStorage.CreateHash(passwordTextBox.Text);
            int commaIndex = saltHashReturned.IndexOf(":");
            String extractedString = saltHashReturned.Substring(0, commaIndex);
            commaIndex = saltHashReturned.IndexOf(":");
            extractedString = saltHashReturned.Substring(commaIndex + 1);
            commaIndex = extractedString.IndexOf(":");
            String salt = extractedString.Substring(0, commaIndex);

            commaIndex = extractedString.IndexOf(":");
            extractedString = extractedString.Substring(commaIndex + 1);
            String hash = extractedString;
            //from the first : to the second : is the salt
            //from the second : to the end is the hash
            cmd.Parameters.AddWithValue("?slowHashSalt", saltHashReturned);

            cmd.ExecuteReader();
            conn.Close();
        }
    }


    private void registerUser()
    {
        String queryString = "";

        String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
        conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
        conn.Open();

        queryString = "INSERT INTO webapppersonalfit.userregistration (firstname, middlename, lastname, email, phonenumber, username, userpassword)"
                       + "VALUES('"
                       + firstNameTextBox.Text + "','"
                       + middleNameTextBox.Text + "','"
                       + lastNameTextBox.Text + "','"
                       + emailTextBox.Text + "','"
                       + phoneNumberTextBox.Text + "','"
                       + usernameTextBox.Text + "','"
                       + passwordTextBox.Text
                       + "')";

        cmd = new MySql.Data.MySqlClient.MySqlCommand(queryString, conn);
        cmd.ExecuteReader();

        conn.Close();
    }
}