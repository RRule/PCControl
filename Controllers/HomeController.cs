using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.NetworkInformation;
using System.Net;

namespace PCControl.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            string shutdownURL = "1337";
            DateTime currentDate = DateTime.Now;
            bool isOn = LocalPing();
            if (isOn)
            {
                ViewBag.Message = string.Format("Lastupdate {1} \r\nStatus:  {0}",  LocalPing()==true ? "on" : "off", currentDate);
                ViewBag.URL = shutdownURL;
            }
            else
            {
                ViewBag.Message = "Is off";
            }


            Response.AddHeader("Refresh", "35");
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
    }
}