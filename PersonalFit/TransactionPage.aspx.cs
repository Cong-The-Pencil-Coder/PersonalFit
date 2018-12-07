using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TransactionPage : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    String queryString;
    String progname;
    String userid;
    String amount = "";
    String trainerid = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        progname = (String)Session["prog_name"];
        userid = (String)Session["UserID"];
        GetProgramInfo();
        AddControlClassToFrontEnd(progname, amount);
    }

    protected void submitButtonEventHandler(object sender, EventArgs e)
    {
        try
        {
            String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            conn.Open();
            queryString = "INSERT INTO webapppersonalfit.transaction (progname, userid, amount, timestamp) "
               + "VALUES(?progname, ?userid, ?amount, ?timestamp)";
            String date = DateTime.UtcNow.ToString();

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryString, conn);
            cmd.Parameters.AddWithValue("?progname", progname);
            cmd.Parameters.AddWithValue("?userid", userid);
            cmd.Parameters.AddWithValue("?amount", amount);
            cmd.Parameters.AddWithValue("?timestamp", date);
            cmd.ExecuteReader();
            conn.Close();
  
            SetTrainerClientDatabase(progname, trainerid, userid);
            Response.Redirect("TransactionConfirmationPage.aspx");
        }
        catch (Exception ex)
        {

        }
    }

    protected void SetTrainerClientDatabase(String progname, String trainerId, String clientId)
    {
        MySql.Data.MySqlClient.MySqlConnection conn3;
        MySql.Data.MySqlClient.MySqlCommand cmd3;

        try
        {
            String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn3 = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            conn3.Open();
            queryString = "INSERT INTO webapppersonalfit.trainerclient (progname, trainerid, clientid) "
               + "VALUES(?progname, ?trainerid, ?clientid)";

            cmd3 = new MySql.Data.MySqlClient.MySqlCommand(queryString, conn3);
            cmd3.Parameters.AddWithValue("?progname", progname);
            cmd3.Parameters.AddWithValue("?trainerid", trainerId);
            cmd3.Parameters.AddWithValue("?clientid", clientId);
            cmd3.ExecuteReader();
            conn3.Close();
        }
        catch (Exception ex)
        {

        }
    }

    protected void AddControlClassToFrontEnd(String progname, String amount)
    {
        String placeholder = "<p style=\"color: black\">" + progname + "<span class=\"price\">$" + amount + "</span></p>"
            + "<hr>"
            + "<p style=\"color: black\">Total <span class=\"price\" style=\"color: black\"><b>$" + amount + "</b></span></p>";
        ProductName.Controls.Add(new Literal() { Text = placeholder });
    }

    protected void GetProgramInfo()
    {
        MySql.Data.MySqlClient.MySqlConnection conn2;
        MySql.Data.MySqlClient.MySqlCommand cmd2;
        MySql.Data.MySqlClient.MySqlDataReader reader;

        String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
        conn2 = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
        conn2.Open();

        String query = "SELECT * FROM webapppersonalfit.program WHERE prog_name='" + (String)Session["prog_name"] + "';";
        cmd2 = new MySql.Data.MySqlClient.MySqlCommand(query, conn2);
        reader = cmd2.ExecuteReader();

        if (reader.HasRows && reader.Read())
        {
            amount = reader.GetString(reader.GetOrdinal("price"));
            trainerid = reader.GetString(reader.GetOrdinal("trainer_id"));
        }
        reader.Close();
        conn2.Close();
    }
}