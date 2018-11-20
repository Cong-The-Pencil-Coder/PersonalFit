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

    protected void Page_Load(object sender, EventArgs e)
    {
        loadDataToExerciseTable();
    }

    protected void loadDataToExerciseTable()
    {
        // Generate rows and cells.           
        int numrows = 50;
        int numcells = 3;

        try
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            conn.Open();

            String query = "SELECT * FROM webapppersonalfit.exercises";

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
                        c.Controls.Add(new LiteralControl("Exercises"));
                    else if (i == 0 && j == 1)
                        c.Controls.Add(new LiteralControl("#Sets"));
                    else if (i == 0 && j == 2)
                        c.Controls.Add(new LiteralControl("#Reps"));
                    else if (reader.HasRows && reader.Read())
                    {
                        if (j == 0)
                            content = reader.GetString(reader.GetOrdinal("name"));
                        else if (j == 1)
                            content = reader.GetString(reader.GetOrdinal("#sets"));
                        else if (j == 2)
                            content = reader.GetString(reader.GetOrdinal("#reps"));
                        Console.WriteLine(content);
                        c.Controls.Add(new LiteralControl(content));
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

            //while (reader.HasRows && reader.Read())
            //{
            //    name = reader.GetString(reader.GetOrdinal("firstname")) + " " + reader.GetString(reader.GetOrdinal("lastname"));
            //}
            //if (reader.HasRows)
            //{
            //    Session["UserName"] = name;
            //    Response.BufferOutput = true;
            //    Response.Redirect("LoggedIn.aspx", false);
            //}
            //else
            //{
            //    passwordTextBox.Value = "Invalid User";
            //}
            reader.Close();
            conn.Close();
        }
        catch (Exception e)
        {
            //passwordTextBox.Value = e.ToString();
        }
    }
}