using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TrainerProfile : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader reader;
    String connectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            conn.Open();
            String userID = (String)Session["userID"];
            userID = "1";
            String query = "SELECT * FROM webapppersonalfit.trainer AS T WHERE T.userID=1;";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();

            if(reader.HasRows && reader.Read())
            {
                Username.Text = reader.GetString(reader.GetOrdinal("name"));
                short_intro.Text = reader.GetString(reader.GetOrdinal("short_intro"));
                long_intro.Text = reader.GetString(reader.GetOrdinal("long_intro"));
            }
        }
        catch (Exception ex)
        {
            //
        }
    }
}