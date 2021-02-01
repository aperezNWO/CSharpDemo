using System;
using System.Web.Mvc;
using static _4_DataAccess.Skill_4_2_Consume_Data;

namespace Exam70483Web.Controllers
{
    #region "Classes"
    public class Exam70483_4_DataAccessController : Controller
    {
        #region "Principales"
        //
        public ActionResult Skill_4_2_Consume_Data()
        {
            //
            try
            {
                // EL METODO ABAJO EXPUESTO TRABAJABA CON EL MODELO DE DATOS ANTERIOR
                // NO SE EXPONE A ESTA VISTA
                // 4_DATA_ACCESS.Skill_4_2(new string[0]);

                //
                // [Listing 4 - 25] - [Consume JSON Data] 
                //
                ImageOfDay imageOfDay = _4_DataAccess.Skill_4_2_Consume_Data.JsonTest();
                //
                ViewBag.Url     = imageOfDay.url;
                ViewBag.Message = @"[Listing 4-25] - [Consume JSON Data]";
                //
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            //
            return View();
        }
        //
        public ActionResult Skill_4_3_Linq()
        {
            try
            {
                //string constring = System.Configuration.ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            //
            return View();
        }
        #endregion
    }
    #endregion
}