using FindLecturerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace FindLecturerApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult AdminIndex()
        {
            return RedirectToAction("UnapprovedUsers", "Account");
        }

        public ActionResult UserIndex()
        {
            return RedirectToAction("ViewProfile", "Lecturers");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Contact(MailViewModel mailModel)
        {
            if (ModelState.IsValid)
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                MailMessage mail = new MailMessage();
                //set the addresses
                mail.From = new MailAddress("ivana.0607@gmail.com", "Нова порака од контакт форма");
                mail.To.Add("ivana.stojkovska2@gmail.com");
              

                mail.Subject = "Порака";
                mail.IsBodyHtml = true;
                mail.Body = string.Format("<b>Од корисникот: </b>" + " " + mailModel.Name + "<br/><br/>" + "<b>Email на корисникот: </b>" + " " + mailModel.Email + "<br/><br/>" + "<b>Наслов на пораката: </b>" + " " + mailModel.Title + "<br/><br/>" + "<b>Содржина на пораката: </b>" + "<br/>" + mailModel.Message);

                smtp.Send(mail);
                ViewBag.Message = "Ви благодариме. Вашата порака е успешно испратена!";

                return View();
            }
            return View();
        }
    }
}