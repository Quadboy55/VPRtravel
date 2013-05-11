using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for Mail
/// </summary>
public static class Mail
{
	public static void sendMail(String message, String mailKlant, String naamKlant)
	{
        MailAddress fromAddress = new MailAddress("1004224752@student.katho.be", "VPRtravel");//"name@yourdomain.com";
        MailAddress toAddress = new MailAddress(mailKlant, naamKlant); //"name@anydomain.com"; 

        //Create the MailMessage instance 
        MailMessage myMailMessage = new MailMessage(fromAddress, toAddress);

        //Assign the MailMessage's properties 
        myMailMessage.Subject = "Confirmation";
        myMailMessage.Body = message;
        myMailMessage.IsBodyHtml = true;
        

        SmtpClient client = new SmtpClient();
        client.Port = 587;
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true;
        client.Timeout = 10000;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("1004224752@student.katho.be", "69JNhL");


        //Send the MailMessage (will use the Web.config settings) 
        client.Send(myMailMessage);
	}
}