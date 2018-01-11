using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.NetworkInformation;
using System.Net;
using System.Web.Configuration;
using System.Diagnostics;

namespace PCControl.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Ping()
        {
            bool result = false;
            result = LocalPing();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Shutdown()
        {
            ShutDownChild();
            return Json("Shutting down", JsonRequestBehavior.AllowGet);
        }
        public ActionResult BruteShutdown()
        {
            ShutDownChild();
            return Json("Shutting down", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {

            string shutdownURL = "1337";
            DateTime currentDate = DateTime.Now;
            bool isOn = LocalPing();
            if (isOn)
            {
                ViewBag.Message = string.Format("Lastupdate {1} \r\nStatus:  {0}", LocalPing() == true ? "on" : "off", currentDate);
                ViewBag.URL = shutdownURL;
            }
            else
            {
                ViewBag.Message = "Is off";
            }

            ViewBag.AppName = Environment.MachineName;

            Response.AddHeader("Refresh", "80");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public static bool LocalPing()
        {
            // Ping's the local machine.
            Ping pingSender = new Ping();
            IPAddress address = IPAddress.Loopback;
            PingReply reply = pingSender.Send(address);
            if (reply.Status == IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void ShutDownChild()
        {
            Process.Start("shutdown", "/s /t 2");
        }
        private void BruteShutDownChild()
        {
            Process.Start("shutdown", "/f /s /t 2");
        }
    }
}