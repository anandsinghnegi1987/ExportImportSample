using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AboutUs()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Product()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Account()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult SendMail(FormCollection frmcollection)
        {
            string username = "anandsinghnegi1987@gmail.com";
            string password = "Singhnegi@1987";

            MailMessage mail = new MailMessage();
            mail.To.Add(username);
            mail.From = new MailAddress(username);
            mail.Subject = "Sample";
            string Body = frmcollection["message"];
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(username, password); // Enter seders User name and password  
            smtp.EnableSsl = true;
            smtp.Send(mail);

            return View();
        }

        [HttpPost]
        public ActionResult Login()
        {
            Session["Customer"] = "User";
            return RedirectToAction("Dashboard", "Customer");
        }

        [HttpGet]
        //[ActionName("~/Home/Account")]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Account", "Home");
        }

    }
}