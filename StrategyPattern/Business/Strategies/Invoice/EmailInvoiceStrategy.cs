using StrategyPattern.Business.Models;
using System.Net;
using System.Net.Mail;

namespace StrategyPattern.Business.Strategies.Invoice
{
    public class EmailInvoiceStrategy: InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            using (SmtpClient client = new SmtpClient("smtp.sendgrid.net", 587))
            {
                NetworkCredential credentials = new NetworkCredential("USERNAME", "PASSWORD");
                client.Credentials = credentials;

                MailMessage mail = new MailMessage("invoices@qoz.me", "invoices@qoz.me")
                {
                    Subject = "We've created an invoice for your order",
                    Body = GenerateTextInvoice(order)
                };

                client.Send(mail);
            }
        }
    }
}
