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
        String progname = "Header";
        String cardtitle = "cardTitle";
        String cardcontent = "content is here";
        String divTag = "<div class=\"card bg-light mb-3 \" style=\"max-width: 20rem; \"> " +
                            "<div class=\"card-header\">" + progname + "</div>" +
                                "<div class=\"card-body\">" +
                                    "<h4 class=\"card-title\">" + cardtitle + "</h4>" +
                                    "<p class=\"card-text\">" + cardcontent + "</p>" +
                                "</div>" +
                        "</div>";
        MyPlaceholder.Controls.Add(new Literal() { Text = divTag });
        //loadDataToExerciseTable();
    }

    protected void loadDataToExerciseTable()
    {
        // Generate rows and cells.           
        int numrows = 10;
        int numcells = 3;
        thColorStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#d9534f");
        trColorSytle.BackColor = System.Drawing.ColorTranslator.FromHtml("#343a40");
        try
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            conn.Open();

            String query = "SELECT * FROM webapppersonalfit.exercises";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            String content = "";
            bool breakcond = false;
            for (int i = 0; i < numrows; i++)
            {
                TableRow r = new TableRow();
                for (int j = 0; j < numcells; j++)
                {
                    TableCell c = new TableCell();
                    if (i == 0 && j == 0)
                    {
                        c.Controls.Add(new Button());
                        c.ApplyStyle(thColorStyle);
                    }
                    else if (i == 0 && j == 1)
                    {
                        c.Controls.Add(new LiteralControl("#Sets"));
                        c.ApplyStyle(thColorStyle);
                    }
                    else if (i == 0 && j == 2)
                    {
                        c.Controls.Add(new LiteralControl("#Reps"));
                        c.ApplyStyle(thColorStyle);
                    }
                    else if (reader.HasRows && reader.Read())
                    {
                        content = reader.GetString(reader.GetOrdinal("name"));
                        c.Controls.Add(new LiteralControl(content));
                        r.Cells.Add(c);

                        c = new TableCell();
                        content = reader.GetString(reader.GetOrdinal("#sets"));
                        c.Controls.Add(new LiteralControl(content));
                        r.Cells.Add(c);

                        c = new TableCell();
                        content = reader.GetString(reader.GetOrdinal("#reps"));
                        c.Controls.Add(new LiteralControl(content));
                        r.Cells.Add(c);
                        break;
                    }
                    else
                    {
                        breakcond = true;
                        break;
                    }
                    r.Cells.Add(c);
                }
                ProgCatalogTable.Rows.Add(r);
                if (breakcond)
                    break;
            }
            reader.Close();
            conn.Close();
        }
        catch (Exception e)
        {
            //passwordTextBox.Value = e.ToString();
        }
    }
}