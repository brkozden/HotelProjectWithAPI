using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddress = new MailboxAddress("Hotel", "Gönderenin mail adresi");
            mimeMessage.From.Add(mailboxAddress);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User",model.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var BodyBuilder = new BodyBuilder();
            BodyBuilder.TextBody = model.Body;
            mimeMessage.Body = BodyBuilder.ToMessageBody();

            mimeMessage.Subject = model.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com",587,false);
            client.Authenticate("Gönderenin mail adresi", "Password Key");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
