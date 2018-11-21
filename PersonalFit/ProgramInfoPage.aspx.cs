using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProgramInfoPage : System.Web.UI.Page
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
        loadDataToMealTable();
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
                        c.Controls.Add(new LiteralControl("Exercises"));
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
                ExerciseTable.Rows.Add(r);
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

    protected void loadDataToMealTable()
    {
        // Generate rows and cells.           
        int numrows = 10;
        int numcells = 3;
        thColorStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#5cb85c");
        trColorSytle.BackColor = System.Drawing.ColorTranslator.FromHtml("#343a40");
        try
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            conn.Open();

            String query = "SELECT * FROM webapppersonalfit.meals";
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
                        c.Controls.Add(new LiteralControl("Name"));
                        c.ApplyStyle(thColorStyle);
                    }
                    else if (i == 0 && j == 1)
                    {
                        c.Controls.Add(new LiteralControl("Time"));
                        c.ApplyStyle(thColorStyle);
                    }
                    else if (i == 0 && j == 2)
                    {
                        c.Controls.Add(new LiteralControl("Meal"));
                        c.ApplyStyle(thColorStyle);
                    }
                    else if (reader.HasRows && reader.Read())
                    {
                        content = reader.GetString(reader.GetOrdinal("name"));
                        c.Controls.Add(new LiteralControl(content));
                        r.Cells.Add(c);

                        c = new TableCell();
                        content = reader.GetString(reader.GetOrdinal("time"));
                        c.Controls.Add(new LiteralControl(content));
                        r.Cells.Add(c);

                        c = new TableCell();
                        content = reader.GetString(reader.GetOrdinal("meals"));
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
                MealTable.Rows.Add(r);
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