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

    String outputMessage;
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
        {
            methodStatus = false;
            phoneNumberTextBox.CssClass = "form-control is-invalid";
            phoneNumberTextBoxLabel.Text = "invalid phone number";
            phoneNumberTextBoxLabel.CssClass = "form-control-label text-danger";

        }

        if (InputValidation.ValidateName(firstNameTextBox.Text) == false)
        {
            methodStatus = false;
            firstNameTextBox.CssClass = "form-control is-invalid";
            firstNameTextBoxLabel.Text = "invalid first name";
            firstNameTextBoxLabel.CssClass = "form-control-label text-danger";
        }

        if (InputValidation.ValidateName(middleNameTextBox.Text) == false)
        {
            methodStatus = false;
            middleNameTextBox.CssClass = "form-control is-invalid";
            middleNameTextBoxLabel.Text = "invalid middle name";
            middleNameTextBoxLabel.CssClass = "form-control-label text-danger";
        }

        if (InputValidation.ValidateName(lastNameTextBox.Text) == false)
        {
            methodStatus = false;
            lastNameTextBox.CssClass = "form-control is-invalid";
            lastNameTextBoxLabel.Text = "invalid last name";
            lastNameTextBoxLabel.CssClass = "form-control-label text-danger";
        }

        if (InputValidation.ValidateUserInput(usernameTextBox.Text) == false)
        {
            methodStatus = false;
            usernameTextBox.CssClass = "form-control is-invalid";
            usernameTextBoxLabel.Text = "invalid username";
            usernameTextBoxLabel.CssClass = "form-control-label text-danger";
        }

        if (InputValidation.ValidateUserInput(passwordTextBox.Text) == false)
        {
            methodStatus = false;
            passwordTextBox.CssClass = "form-control is-invalid";
            passwordTextBoxLabel.Text = "invalid password";
            passwordTextBoxLabel.CssClass = "form-control-label text-danger";
        }

        if (InputValidation.ValidateEmail(emailTextBox.Text) == false)
        {
            methodStatus = false;
            emailTextBox.CssClass = "form-control is-invalid";
            emailTextBoxLabel.Text = "invalid email address";
            emailTextBoxLabel.CssClass = "form-control-label text-danger";
        }

        if (methodStatus == true)
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();

            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();

            queryString = "";
            if (customCheck1.Checked)
            {
                queryString = "INSERT INTO webapppersonalfit.userregistration (firstname, middlename, lastname, email, phonenumber, username, userpassword, slowHashSalt, isPT)"
                        + "VALUES(?firstname, ?middlename, ?lastname, ?email, ?phonenumber, ?uname, ?userpassword, ?slowHashSalt, TRUE)";
            }
            else
                queryString = "INSERT INTO webapppersonalfit.userregistration (firstname, middlename, lastname, email, phonenumber, username, userpassword, slowHashSalt)"
                        + "VALUES(?firstname, ?middlename, ?lastname, ?email, ?phonenumber, ?uname, ?userpassword, ?slowHashSalt, FALSE)";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryString, conn);
            cmd.Parameters.AddWithValue("?firstname", firstNameTextBox.Text);
            cmd.Parameters.AddWithValue("?middlename", middleNameTextBox.Text);
            cmd.Parameters.AddWithValue("?lastname", lastNameTextBox.Text);
            cmd.Parameters.AddWithValue("?email", emailTextBox.Text);
            cmd.Parameters.AddWithValue("?phonenumber", phoneNumberTextBox.Text);
            cmd.Parameters.AddWithValue("?uname", usernameTextBox.Text);
            cmd.Parameters.AddWithValue("?userpassword", passwordTextBox.Text);
            //cmd.Parameters.AddWithValue("?slowHashSalt", passwordTextBox.Text);

            String saltHashReturned = PasswordStorage.CreateHash(passwordTextBox.Text);
            int commaIndex = saltHashReturned.IndexOf(":");
            String extractedString = saltHashReturned.Substring(commaIndex + 1);
            commaIndex = extractedString.IndexOf(":");
            extractedString = saltHashReturned.Substring(commaIndex + 1);
            commaIndex = extractedString.IndexOf(":");

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

            //Registration is successfully completed
            String subject = "PersonalFit Verification Email";
            String body = "Please click the link below to verify your email.";
            Email.sendEmail(Util.defaultEmail, emailTextBox.Text, subject, body);
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