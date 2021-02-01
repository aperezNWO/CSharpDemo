using System;
using System.Web.Mvc;

namespace Exam70483Web.Controllers
{
    public class GenericController : Controller
    {
        //
        public string GetIpValue()
        {
            //
            string ipAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            //
            if (string.IsNullOrEmpty(ipAdd))
            {
                ipAdd = Request.ServerVariables["REMOTE_ADDR"];
            }
            //
            return ipAdd;
        }
    }
}