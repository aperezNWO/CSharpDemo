using System;
using System.Web.Mvc;

namespace Exam70483Web.Controllers
{
    public class MCSDController : Controller
    {
        //
        public ActionResult _MCSD()
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
        //
        public ActionResult _Exam70483()
        {
            try
            {
                // SKILL 4.3 LINQ
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            //
            return View();
        }
    }
}