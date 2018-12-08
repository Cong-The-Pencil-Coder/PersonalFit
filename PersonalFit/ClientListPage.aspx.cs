using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClientListPage : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader reader;
    String connectionString;
    List<Button> btnList = new List<Button>();

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadTable();
    }

    protected void LoadTable()
    {
        try
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            conn.Open();

            String trainerid = (String)Session["UserID"];
            String query = "SELECT * FROM webapppersonalfit.userregistration AS UR webapppersonalfit.program AS P, webapppersonalfit.trainerclient AS TC " +
                            "WHERE TC.trainerid=" + "'" + trainerid + "'" +
                            "AND P.prog_name=TC.progname " +
                            "AND UR.userID=TC.clientid;";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            String content = "";

            while(true)
            {
                TableRow r = new TableRow();
                r.CssClass = "row100 body";
                TableCell c = new TableCell();
                c.CssClass = "cell100 column1";
                if (reader.HasRows && reader.Read())
                {
                    content = reader.GetString(reader.GetOrdinal("progname"));
                    c.Controls.Add(new LiteralControl(content));
                    r.Cells.Add(c);

                    c = new TableCell();
                    c.CssClass = "cell100 column2";
                    content = reader.GetString(reader.GetOrdinal("focus"));
                    c.Controls.Add(new LiteralControl(content));
                    r.Cells.Add(c);

                    c = new TableCell();
                    c.CssClass = "cell100 column3";
                    content = reader.GetString(reader.GetOrdinal("duration"));
                    c.Controls.Add(new LiteralControl(content));
                    r.Cells.Add(c);

                    c = new TableCell();
                    c.CssClass = "cell100 column4";
                    content = reader.GetString(reader.GetOrdinal("firstname")) + " " + reader.GetString(reader.GetOrdinal("lastname"));
                    c.Controls.Add(new LiteralControl(content));
                    r.Cells.Add(c);

                    //c = new TableCell();
                    //c.CssClass = "cell100 column5";
                    //content = reader.GetString(reader.GetOrdinal("userID"));
                    //Button btn = new Button();
                    //btn.ID = content;
                    //btnList.Add(btn);
                    //c.Controls.Add(btn);
                    //r.Cells.Add(c);
                }
                else
                    break;
                Table1.Rows.Add(r);
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