using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TrainerProfileCreationPage : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    String queryString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SubmitEventHandler(object sender, EventArgs e)
    {
        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();

        conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
        conn.Open();

        queryString = "";

        queryString = "INSERT INTO webapppersonalfit.trainer (userID, name, short_intro, long_intro, url_pic)"
                    + "VALUES(?userID, ?name, ?short_intro, ?long_intro, ?url_pic)";


        cmd = new MySql.Data.MySqlClient.MySqlCommand(queryString, conn);
        cmd.Parameters.AddWithValue("?userID", (String)Session["UserID"]);
        cmd.Parameters.AddWithValue("?name", fullnametextbox.Value);
        cmd.Parameters.AddWithValue("?short_intro", shortintro.Value);
        cmd.Parameters.AddWithValue("?long_intro", longintro.Value);
        cmd.Parameters.AddWithValue("?url_pic", urlpic.Value);

        cmd.ExecuteReader();
        conn.Close();
        Response.Redirect("TrainerCatalog.aspx");
    }
}