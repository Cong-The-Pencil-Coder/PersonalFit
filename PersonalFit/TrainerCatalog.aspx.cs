using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TrainerCatalog : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader reader;
    String connectionString;
    private Style thColorStyle = new Style();
    private Style trColorSytle = new Style();
    protected void Page_Load(object sender, EventArgs e)
    {

        loadDataToExerciseTable();
    }

    protected void SubmitEventHandler(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        Session["trainerID"] = btn.ID;
        Response.BufferOutput = true;
        Response.Redirect("TrainerProfile.aspx", false);
    }

    protected void loadDataToExerciseTable()
    {
        thColorStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#d9534f");
        trColorSytle.BackColor = System.Drawing.ColorTranslator.FromHtml("#343a40");
        try
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            conn.Open();

            String query = "SELECT * FROM webapppersonalfit.trainer";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();

            while (reader.HasRows && reader.Read())
            {
                String trainerID = reader.GetString(reader.GetOrdinal("userID"));
                String trainerName = reader.GetString(reader.GetOrdinal("name"));
                String cardTitle = reader.GetString(reader.GetOrdinal("name"));
                String cardContent = reader.GetString(reader.GetOrdinal("short_intro"));
                String picUrl = reader.GetString(reader.GetOrdinal("url_pic"));
                addCardOntoPlaceHolder(trainerID, trainerName, cardTitle, cardContent, picUrl);
            }
            reader.Close();
            conn.Close();
        }
        catch (Exception e)
        {
            //passwordTextBox.Value = e.ToString();
        }
    }

    private void addCardOntoPlaceHolder(String trainerID, String trainerName, String cardTitle, String cardContent, String picUrl)
    {
        String divTag = "<div class=\"card bg-light mb-3 holder\" style=\"max-width: 20%; float: left; margin: 2.25em;\"><br /> " +
                            "<img class=\"avatar\" src=\"" + picUrl + "\" />" + 
                                    "<div class=\"card-body\">" +
                                    "<h4 class=\"card-title\" style=\"text-align: center;\">" + cardTitle + "</h4>" +
                                    "<p class=\"card-text\">" + cardContent + "</p>";

        Button submitButton = new Button();
        submitButton.Click += new EventHandler(this.SubmitEventHandler);
        submitButton.CssClass = "btn btn-warning";
        submitButton.Text = "info";
        submitButton.ID = trainerID;
        MyPlaceholder.Controls.Add(new Literal() { Text = divTag });
        this.addSpecialty(trainerID);
        MyPlaceholder.Controls.Add(new Literal() { Text = "<br /><br />" });
        MyPlaceholder.Controls.Add(submitButton);
        MyPlaceholder.Controls.Add(new Literal() { Text = "</div>" + "</div>" });
    }

    private void addSpecialty(String trainerID)
    {
        String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
        MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
        conn.Open();

        String query = "SELECT * FROM webapppersonalfit.trainerspecialty as TS WHERE TS.trainerID=" + trainerID + ";";
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
        MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();
        String primary = "badge-primary";
        String secondary = "badge-secondary";
        String success = "badge-success";
        String danger = "badge-danger";
        String warning = "badge-warning";
        String info = "badge-info";
        String light = "badge-light";
        String dark = "badge-dark";

        uint i = 1;
        while (reader.HasRows && reader.Read())
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
            MyPlaceholder.Controls.Add(span);
        }
    }
}
