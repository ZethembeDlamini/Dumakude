using Rotativa;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using guestHouse.Models;



namespace guestHouse.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Index(string name , string email, string checkIn, string checkOut, int price,int meals)
        {
            Logic.invoice invoice = new Logic.invoice(name, email, checkIn, checkOut,price,meals);
     
            return View(invoice);
        }

 
public ActionResult GeneratePdf(string name, string email,string checkIn,string checkOut, int price,int meals)
    {
            // your model to populate the view
            Logic.invoice invoice = new Logic.invoice(name, email, checkIn, checkOut,price,meals);
            // Generate the PDF from the view

            var pdfBytes = new Rotativa.ViewAsPdf("Index",invoice).BuildPdf(ControllerContext);

            // Email the PDF
           EmailPdf(pdfBytes,email);

            // Optionally, you can also return the PDF as a download response
             return File(pdfBytes, "application/pdf", "invoice.pdf");
    }

       

private void EmailPdf(byte[] pdfBytes,string email)
    {
        // Create a new email message
        var message = new MailMessage();
        message.Subject = "Invoice";
        message.Body = "Please find attached the invoice.";

        // Add the PDF as an attachment
        var attachment = new Attachment(new MemoryStream(pdfBytes), "invoice.pdf", "application/pdf");
        message.Attachments.Add(attachment);

        // Set the sender, recipient, and SMTP server details
        message.From = new MailAddress("mpumelelodlamuni@gmail.com");
        message.To.Add(email);
        var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("mpumelelodlamuni@gmail.com", "acpwnggnpcxfuayt");
           

        // Send the email
        smtpClient.Send(message);
    }




}
}