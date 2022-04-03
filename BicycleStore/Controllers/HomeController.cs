using BicycleStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;

namespace BicycleStore.Controllers
{
    public class HomeController : Controller
    {
        BicycleContext context;

        public HomeController(BicycleContext context)
        {
            this.context = context;
        }

        public IActionResult Index(string message, string prop)
        {
            ViewBag.IndexMessage = message;
            ViewBag.Props = Type.GetType("BicycleStore.Models.Bicycle").GetProperties().Where(x => x.Name != "BicycleId" && x.Name != "BicycleAdditionalInfo").Select(x => x.Name).ToList();

            if (prop == null)
                return View(context.Bicycles.ToList());
            else
                return View(context.Bicycles.ToList().OrderBy((x => x.GetType().GetProperty(prop).GetValue(x))).ToList());
        }
        
        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.BicycleId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Buy(Order order)
        {
            if (ModelState.IsValid)
            {
                context.Orders.Add(order);
                context.SaveChanges();

                MailAddress from = new MailAddress("spamtemp0azaza@gmail.com", "my logg");
                MailAddress to = new MailAddress(order.CustomerEmail);

                MailMessage m = new MailMessage(from, to);
                m.Subject = "Receipt";
                m.Body = $"Thank you, {order.CustomerName}, for buying 2 packs of our premium weed</h2>";
                m.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("spamtemp0azaza@gmail.com", "hryfprkojvshqkpi");
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(m);

                return RedirectToAction("Index", new { message = $"Thank you for your order dear {order.CustomerName}" });
            }

            return View();
        }
    }
}
