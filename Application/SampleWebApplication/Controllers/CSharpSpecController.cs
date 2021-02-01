using System;
using System.Web.Mvc;

namespace Exam70483Web.Controllers
{
    public class CSharpSpecController : Controller
    {
        //
        public ActionResult _CSharpSpec()
        {
            try
            {
                //string constring = System.Configuration.ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return View();
        }
    }
}