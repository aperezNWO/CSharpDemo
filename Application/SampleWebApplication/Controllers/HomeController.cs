using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Exam70483Web.Models;
using Exam70483Web.Models.Entity;

namespace Exam70483Web.Controllers
{
    public class HomeController : GenericController
    {
        #region "Propiedades"
        public static string ApplicationVersion
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        #endregion
        //
        #region "Metodos"
        public ActionResult Index()
        {
            try
            {
                //
                LogModel.Log("PAGE_INDEX",this.GetIpValue());
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return View();
        }
        //
        public ActionResult About()
        {
            //
            ViewBag.Message = "[PABLO ALEJANDRO PEREZ ACOSTA]";
            //
            try
            {
                //
                LogModel.Log("PAGE_ABOUT",this.GetIpValue());
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return View();
        }
        //
        public ActionResult Contact()
        {
            ViewBag.Message = "[CONTACT_INFO]";

            try
            {
                //
                LogModel.Log("PAGE_CONTACT",this.GetIpValue());
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }


            return View();
        }
        //
        #endregion
    }
}