using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;


public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void sendEventMethod(object sender, EventArgs e)
    {
        try
        { 
            MailMessage message = new MailMessage(from.Text, to.Text, subject.Text, body.Text);
            message.IsBodyHtml = true;

            //Handler the mail sending for you
            String Host = "smtp.gmail.com";
            int Port = 587;
            SmtpClient client = new SmtpClient(Host, Port);

            client.EnableSsl = true;

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            client.Credentials = new System.Net.NetworkCredential("cong.pham234@gmail.com", "Bin04071989!@");
            client.Send(message);
            status.Text = "Mail was sent successfully";
        }
        catch(Exception ex)
        {
            status.Text = ex.StackTrace;
        }
    }
}