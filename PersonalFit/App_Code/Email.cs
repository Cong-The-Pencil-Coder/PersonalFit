using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Mail;
/// <summary>
/// Summary description for Class1
/// </summary>
public class Email
{
    public Email()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void sendEmail(String from, String to, String subject, String body)
    {
        try
        {
            MailMessage message = new MailMessage(from, to, subject, body);
            message.IsBodyHtml = true;

            //Handler the mail sending for you
            String Host = "smtp.gmail.com";
            int Port = 587;
            SmtpClient client = new SmtpClient(Host, Port);

            client.EnableSsl = true;

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            client.Credentials = new System.Net.NetworkCredential(Util.defaultEmail, Util.password);
            client.Send(message);
        }
        catch (Exception ex)
        {

        }
    }
}