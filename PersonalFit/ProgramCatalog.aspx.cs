using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProgramCatalog : System.Web.UI.Page
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
        Session["prog_name"] = btn.ID;
        Response.BufferOutput = true;
        Response.Redirect("ProgramInfoPage.aspx", false);
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
            String trainerID = (String)Session["trainerID"];
            String query = "SELECT * FROM webapppersonalfit.program WHERE trainer_ID=" + trainerID + ";";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();

            while (reader.HasRows && reader.Read())
            {
                String progName = reader.GetString(reader.GetOrdinal("prog_name"));
                String cardTitle = reader.GetString(reader.GetOrdinal("duration"));
                String cardContent = reader.GetString(reader.GetOrdinal("focus"));
                //String picUrl = reader.GetString(reader.GetOrdinal("url_pic"));
                String picUrl = "";
                addCardOntoPlaceHolder(progName, cardTitle, cardContent, picUrl);
            }
            reader.Close();
            conn.Close();
        }
        catch (Exception e)
        {
            //passwordTextBox.Value = e.ToString();
        }
    }

    private void addCardOntoPlaceHolder(String progName, String cardTitle, String cardContent, String picUrl)
    {
        String divTag = "<div class=\"\" style=\"max-width: 20rem; display: inline;\"> " +
                            "<div class=\"card-header\">" + progName + "</div>" +
                                "<div class=\"card-body\">" +
                                    "<h4 class=\"card-title\">" + cardTitle + "</h4>" +
                                    "<p class=\"card-text\">" + cardContent + "</p>";

        Button submitButton = new Button();
        submitButton.Click += new EventHandler(this.SubmitEventHandler);
        submitButton.CssClass = "btn btn-warning";
        submitButton.Text = "info";
        submitButton.ID = progName;
        MyPlaceholder.Controls.Add(new Literal() { Text = divTag });
        MyPlaceholder.Controls.Add(submitButton);
        MyPlaceholder.Controls.Add(new Literal() { Text = "</div>" + "</div>" });
    }
}