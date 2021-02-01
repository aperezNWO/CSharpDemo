using Exam70483Library.Managers;
using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Exam70483Web.Controllers
{
    public class UnitTestingController : Controller
    {
        //
        public ActionResult _UnitTesting01()
        {
            //
            string htmlNewLine = @"<br/>";
            //
            StringBuilder stringArray = new StringBuilder();
            //
            int ARRAY_SIZE = 25;
            //
            Random rand = new Random();
            //
            int[] arr = new int[ARRAY_SIZE];
            //
            int[] randomArray = AlgorithmManager.FisherYates(ARRAY_SIZE, rand);
            //
            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                stringArray.Append(string.Format("{0}{1}", ((i == 0) ? "" : @"|"), randomArray[i].ToString()));
            }
            //
            string unsortedList = stringArray.ToString();
            //                
            AlgorithmManager am = new AlgorithmManager
                (
                      unsortedList
                    , ARRAY_SIZE
                );
            //
            string sortedList = am.BubbleSort();
            //
            ViewBag.Message = string.Format("{0}{1}----{1}{2}"
                        , HttpUtility.HtmlEncode(unsortedList).Replace(@"|", htmlNewLine)
                        , htmlNewLine
                        , HttpUtility.HtmlEncode(sortedList).Replace(@"|", htmlNewLine)
            );
            //
            return View();
        }

        public ActionResult _UnitTesting02()
        {
            //
            string htmlNewLine = @"<br/>";
            //
            StringBuilder stringArray = new StringBuilder();
            //
            int ARRAY_SIZE = 25;
            Random rand = new Random();
            //
            int[] arr = new int[ARRAY_SIZE];
            //
            int[] randomArray = AlgorithmManager.FisherYates(ARRAY_SIZE, rand);
            //
            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                stringArray.Append(string.Format("{0}{1}", ((i == 0) ? "" : @"|"), randomArray[i].ToString()));
            }
            //
            string unsortedList = stringArray.ToString();
            //                
            AlgorithmManager am = new AlgorithmManager
                (
                      unsortedList
                    , ARRAY_SIZE
                );
            //
            string sortedList = am.BubbleSort();
            //
            ViewBag.Message = HttpUtility.HtmlEncode(unsortedList).Replace(@"|", htmlNewLine);
            //
            return View();
        }

        public ActionResult _UnitTesting03()
        {
            //
            return View();
        }
        //
        public ActionResult _UnitTesting04()
        {
            //
            return View();
        }
        //
        public string GenerateRandomVertex()
        {
            //
            string status = string.Empty;
            //
            const ushort sampleSize = 23;
            const ushort vertexSize = 6;
            const ushort sourcePoint = 5;

            status = AlgorithmManager.GenerateRandomPoints(vertexSize, sampleSize, sourcePoint);

            return status;
        }
        //
        public ActionResult _UnitTesting05()
        {
            return View();
        }

        //
        public ActionResult _UnitTesting06()
        {
            return View();
        }

        //
        public ActionResult _UnitTesting07()
        {
            return View();
        }

    }
}