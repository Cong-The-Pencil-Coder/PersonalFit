using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProgramCreationPage : System.Web.UI.Page
{

    static List<TableRow> ExerciseTableRow = new List<TableRow>();
    static List<TableRow> MealTableRow = new List<TableRow>();
    private Style thColorStyle = new Style();
    private Style trColorSytle = new Style();

    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    String queryString;
    static string programname = "";

    public class info
    {
        String ExerciseName { get; set; }
        String Day { get; set; }
        String Sets { get; set; }
        String Reps { get; set; }
        String UrlPic { get; set; }
        
        public info(String a, String b , String c, String d, String e)
        {
            ExerciseName = a;
            Day = b;
            Sets = c;
            Reps = d;
            UrlPic = e;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        thColorStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#d9534f");
        trColorSytle.BackColor = System.Drawing.ColorTranslator.FromHtml("#343a40");

        TableRow r = new TableRow();
        TableCell c1 = new TableCell();

        c1.Controls.Add(new LiteralControl("Exercise Name    "));
        c1.ApplyStyle(thColorStyle);
        r.Cells.Add(c1);

        TableCell c2 = new TableCell();
        c2.Controls.Add(new LiteralControl("Day  "));
        c2.ApplyStyle(thColorStyle);
        r.Cells.Add(c2);

        TableCell c3 = new TableCell();
        c3.Controls.Add(new LiteralControl("Sets "));
        c3.ApplyStyle(thColorStyle);
        r.Cells.Add(c3);

        TableCell c4 = new TableCell();
        c4.Controls.Add(new LiteralControl("Reps "));
        c4.ApplyStyle(thColorStyle);
        r.Cells.Add(c4);

        TableCell c5 = new TableCell();
        c5.Controls.Add(new LiteralControl("UrlPic   "));
        c5.ApplyStyle(thColorStyle);
        r.Cells.Add(c5);

        ExerciseTable.Rows.Add(r);

        thColorStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#5cb85c");
        trColorSytle.BackColor = System.Drawing.ColorTranslator.FromHtml("#343a40");

        r = new TableRow();

        TableCell c6 = new TableCell();
        c6.Controls.Add(new LiteralControl("Meal     "));
        c6.ApplyStyle(thColorStyle);
        r.Cells.Add(c6);

        TableCell c7 = new TableCell();
        c7.Controls.Add(new LiteralControl("Time     "));
        c7.ApplyStyle(thColorStyle);
        r.Cells.Add(c7);

        TableCell c8 = new TableCell();
        c8.Controls.Add(new LiteralControl("Description      "));
        c8.ApplyStyle(thColorStyle);
        r.Cells.Add(c8);

        MealTable.Rows.Add(r);
    }

    protected void AddingExerciseEventHandler(object sender, EventArgs e)
    {
        thColorStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#d9534f");
        trColorSytle.BackColor = System.Drawing.ColorTranslator.FromHtml("#343a40");

        TableRow r = new TableRow();
        TableCell c = new TableCell();
        
        c.Controls.Add(new LiteralControl(ExNameTextBox.Text));
        //c.ApplyStyle(thColorStyle);
        r.Cells.Add(c);

        TableCell c1 = new TableCell();
        c1.Controls.Add(new LiteralControl(DayTextBox.Text));
        //c.ApplyStyle(thColorStyle);
        r.Cells.Add(c1);

        TableCell c2 = new TableCell();
        c2.Controls.Add(new LiteralControl(SetTextBox.Text));
        //c.ApplyStyle(thColorStyle);
        r.Cells.Add(c2);

        TableCell c3 = new TableCell();
        c3.Controls.Add(new LiteralControl(RepTextBox.Text));
        //c.ApplyStyle(thColorStyle);
        r.Cells.Add(c3);

        TableCell c4 = new TableCell();
        c4.Controls.Add(new LiteralControl(UrlPicTextBox.Text));
        //c.ApplyStyle(thColorStyle);
        r.Cells.Add(c4);
        ExerciseTableRow.Add(r);
        foreach(TableRow row in ExerciseTableRow)
            ExerciseTable.Rows.Add(row);
        foreach (TableRow row in MealTableRow)
            MealTable.Rows.Add(row);
        AddNewExerciseToDatabase();
    }

    protected void AddNewExerciseToDatabase()
    {
        try
        {
            String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            conn.Open();
            queryString = "INSERT INTO webapppersonalfit.exercises (name, sets, reps, progname, day) "
               + "VALUES(?name, ?sets, ?reps, ?progname, ?day)";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryString, conn);
            cmd.Parameters.AddWithValue("?name", ExNameTextBox.Text);
            cmd.Parameters.AddWithValue("?sets", SetTextBox.Text);
            cmd.Parameters.AddWithValue("?reps", RepTextBox.Text);
            cmd.Parameters.AddWithValue("?progname", programname);
            cmd.Parameters.AddWithValue("?day", DayTextBox.Text);
            cmd.ExecuteReader();
            conn.Close();
        }
        catch(Exception e)
        {

        }
    }

    protected void AddNewProgramToDatabaseButtonEventHandler(object sender, EventArgs e)
    {
        Label lbl = new Label();
        try
        {
            String queryString = "";

            String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            conn.Open();

            String trainer_id = (String)Session["UserID"];
            String prog_name = progname.Text;
            String prog_duration = progduration.Text;
            String prog_price = progprice.Text;
            String prog_focus = progfocus.Text;
            String prog_body = progbody.Text;

            programname = prog_name;

            queryString = "INSERT INTO webapppersonalfit.program (trainer_id, prog_name, price, duration, focus) "
                           + "VALUES(?trainerid, ?progname, ?price, ?duration, ?focus)";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryString, conn);
            cmd.Parameters.AddWithValue("?trainerid", trainer_id);
            cmd.Parameters.AddWithValue("?progname", prog_name);
            cmd.Parameters.AddWithValue("?price", prog_price);
            cmd.Parameters.AddWithValue("?duration", prog_duration);
            cmd.Parameters.AddWithValue("?focus", prog_focus);

            cmd.ExecuteReader();

            conn.Close();
            lbl.Text = lbl.Text = "Program is submitted";
            PlaceHolder2.Controls.Add(lbl);

        }
       catch(Exception ex)
        {
            lbl.Text = lbl.Text = "Program is not submitted";
            PlaceHolder2.Controls.Add(lbl);
        }

    }

    protected void AddingMealEventHandler(object sender, EventArgs e)
    {
        thColorStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#5cb85c");
        trColorSytle.BackColor = System.Drawing.ColorTranslator.FromHtml("#343a40");

        TableRow ro = new TableRow();
        TableCell col = new TableCell();
        col.Controls.Add(new LiteralControl(TextBox5.Text));
        //c.ApplyStyle(thColorStyle);
        ro.Cells.Add(col);

        TableCell c2 = new TableCell();
        c2.Controls.Add(new LiteralControl(TextBox6.Text));
        //c.ApplyStyle(thColorStyle);
        ro.Cells.Add(c2);

        TableCell c3 = new TableCell();
        c3.Controls.Add(new LiteralControl(TextBox7.Text));
        //c.ApplyStyle(thColorStyle);
        ro.Cells.Add(c3);


        MealTableRow.Add(ro);
        foreach (TableRow row in MealTableRow)
            MealTable.Rows.Add(row);
        foreach (TableRow row in ExerciseTableRow)
            ExerciseTable.Rows.Add(row);

        AddNewMealToDatabase();
    }

    protected void AddNewMealToDatabase()
    {
        try
        {
            String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            conn.Open();
            queryString = "INSERT INTO webapppersonalfit.meals (name, time, meals, progname) "
               + "VALUES(?name, ?time, ?meals, ?progname)";
            String mealname = TextBox5.Text;
            String mealtime = TextBox6.Text;
            String description = TextBox7.Text;

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryString, conn);
            cmd.Parameters.AddWithValue("?name", mealname);
            cmd.Parameters.AddWithValue("?time", mealtime);
            cmd.Parameters.AddWithValue("?meals", description);
            cmd.Parameters.AddWithValue("?progname", programname);
            cmd.ExecuteReader();
            conn.Close();
        }
        catch (Exception e)
        {

        }
    }
}