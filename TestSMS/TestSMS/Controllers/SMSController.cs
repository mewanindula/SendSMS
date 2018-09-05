using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSMS.Models;

namespace TestSMS.Controllers
{
    public class SMSController : Controller
    {
        SerialPort sp = new SerialPort();

        public ActionResult SMSIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendSMS(SMSViewModel model)
        {
            try
            {
                sendSMS(model.TelNo, model.Message);

                System.Threading.Thread.Sleep(3000);

                sendSMS(model.TelNo, model.Message);

                return RedirectToAction("SMSIndex");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void sendSMS(string mobNo, string msg)
        {
            string telNo = Char.ConvertFromUtf32(34) + mobNo + Char.ConvertFromUtf32(34);

            sp.PortName = "COM4";

            sp.Open();
            sp.Write("AT+CMGF=1" + Char.ConvertFromUtf32(13));
            sp.Write("AT+CMGS=" + telNo + Char.ConvertFromUtf32(13));
            sp.Write(msg + Char.ConvertFromUtf32(26) + Char.ConvertFromUtf32(13));
            sp.Close();
        }
    }
}