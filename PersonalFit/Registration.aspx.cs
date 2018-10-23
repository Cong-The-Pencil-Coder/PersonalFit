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

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void registerEventMethod(object sender, EventArgs e)
    {
        registerUser();
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
    }
}