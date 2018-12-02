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

    public String userID { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            conn.Open();
            userID = (String)Session["trainerID"];
            String query = "SELECT * FROM webapppersonalfit.trainer AS T WHERE T.userID="+ userID +";";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();

            if(reader.HasRows && reader.Read())
            {
                Username.Text = reader.GetString(reader.GetOrdinal("name"));
                short_intro.Text = reader.GetString(reader.GetOrdinal("short_intro"));
                long_intro.Text = reader.GetString(reader.GetOrdinal("long_intro"));
            }
            addSpanOntoPlaceHolder();
            conn.Close();
            reader.Close();
        }
        catch (Exception ex)
        {
            //
        }
    }

    public void MessageButtonEventHandler(object sender, EventArgs e)
    {
        Response.BufferOutput = true;
        Server.Transfer("index.aspx", true);
    }

    private void addSpanOntoPlaceHolder()
    {
        connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
        conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
        conn.Open();

        String userID = (String)Session["trainerID"];
        String query = "SELECT * FROM webapppersonalfit.trainerspecialty AS TS WHERE TS.trainerID=" + userID + ";";
        cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
        reader = cmd.ExecuteReader();

        String primary = "badge-primary";
        String secondary = "badge-secondary";
        String success = "badge-success";
        String danger = "badge-danger";
        String warning = "badge-warning";
        String info = "badge-info";
        String light = "badge-light";
        String dark = "badge-dark";

        uint i = 1;
        while(reader.HasRows && reader.Read())
        {
            Label span = new Label();
            span.CssClass = "badge badge-pill trainer-span ";
            span.Text = reader.GetString(reader.GetOrdinal("specialty"));
            if (i % 8 == 0) span.CssClass += dark;
            else if (i % 7 == 0) span.CssClass += light;
            else if (i % 6 == 0) span.CssClass += info;
            else if (i % 5 == 0) span.CssClass += warning;
            else if (i % 4 == 0) span.CssClass += danger;
            else if (i % 3 == 0) span.CssClass += success;
            else if (i % 2 == 0) span.CssClass += secondary;
            else span.CssClass += primary;
            i++;
            SpecialtySpanHolder.Controls.Add(span);
        }
    }
}