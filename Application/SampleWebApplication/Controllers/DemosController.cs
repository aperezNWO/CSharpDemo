using Exam70483Library;
using Exam70483Library.DataAccess;
using Exam70483Library.Managers;
using Exam70483Web.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Exam70483Web.Controllers
{
    public class DemosController : GenericController
    {
        #region "Campos"
        //
        string connString               = System.Configuration.ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        string _documentsLocalDirectory = System.Configuration.ConfigurationManager.AppSettings["DocumentsLocalDirectory"];
        //
        int ARRAY_SIZE = 25;
        #endregion

        #region "Metodos"

        #region "Raiz"
        //
        public ActionResult _DemosIndex(int id = 0)
        {
            //
            try
            {
                //---------------------------------------------------
                // LOG
                //---------------------------------------------------
                LogModel.Log("PAGE_DEMO_INDEX", this.GetIpValue());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return View();
        }
        //
        #endregion

        #region "PDF DEMO"
        public ActionResult _PDFDemo()
        {
            //
            ViewBag.Message = @"[OBTENER PDF A PARTIR DE HTML Y CSS]";
            //
            try
            {
                //---------------------------------------------------
                // LOG
                //---------------------------------------------------
                LogModel.Log("PAGE_PDF_DEMO", this.GetIpValue());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return View();
        }
        //
        public string _GetPdf(string subjectName)
        {
            //
            string _extensionDocumento = @"pdf";
            string _directorioDocumento = string.Format("{0}/{1}", _documentsLocalDirectory, _extensionDocumento);
            string status = @"[ok]";

            //
            string fileName = string.Format("{0}{1}.{2}"
             , System.Guid.NewGuid().ToString()
             , DateTime.Now.ToString(Globals.DateFormatShortTimestamp)
             , _extensionDocumento);

            string resultRelativeFilePath = string.Format(@"~/{0}/{1}", _directorioDocumento, fileName);
            //
            string cssPath         = Server.MapPath(@"~/Content/pdf.css");
            string resultFilePath  = Server.MapPath(resultRelativeFilePath);
            string imagePath       = Server.MapPath(@"~/Content/mcsd-cert.jpg");
            string mcsdImagePath   = Server.MapPath(@"~/Content/mcsd.png");
            //
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            //
            try
            {
                //---------------------------------------------------
                // IMAGEN DE ENCABEZADO
                //---------------------------------------------------
                string htmlContent = string.Empty;
                htmlContent += @"<table width=""100%"" cellpadding=""0px"" cellspacing=""0px"" style=""border: solid 0px #000;"">";
                htmlContent += string.Format(@"<tr><td align=""center"" style=""width:100%;border:0px;""><img src=""{0}""></img></td></tr>", imagePath);
                htmlContent += @"</table>";
                // NO ES POSIBLE CARGAR LA IMAGEN DESDE CSS
                //htmlContent      += string.Format(@"<div style=""background-image: url(""{0}""); background-repeat: no-repeat; height: 250px;"">&nbsp;</div>",mcsdImagePath);   
                //
                //---------------------------------------------------
                // AÑADIR FORMATO EXTERNO
                //---------------------------------------------------
                string wrapperhtml = string.Empty;
                using (var streamReader = new System.IO.StreamReader(Server.MapPath(@"~/Content/Resultados.html"), System.Text.Encoding.UTF8))
                {
                    wrapperhtml = streamReader.ReadToEnd();
                    streamReader.Close();
                }
                //
                string currentDate = DateTime.Now.ToString("dddd, dd MMMM yyyy", new CultureInfo("es-CO"));
                //
                wrapperhtml = wrapperhtml.Replace("[CONTENT]", subjectName);
                wrapperhtml = wrapperhtml.Replace("[CURRENT_DATE]", currentDate);
                wrapperhtml = wrapperhtml.Replace("[IMAGE]", htmlContent);
                wrapperhtml = wrapperhtml.Replace("[IMAGE_PATH]", mcsdImagePath);
                //    
                status += string.Format("|{0}|{1}|{2}", fileName, resultFilePath, imagePath);
                //
                Exam70483.Libraries.Managers.PDFManager.GetPDFFile(
                        wrapperhtml
                      , cssPath
                      , resultFilePath
                );
            }
            catch (Exception e)
            {
                //
                string errorMsg = string.Format("PDF_ERROR : {0}", e.InnerException.Message + " " + e.StackTrace);
                //
                LogModel.Log(errorMsg, string.Empty, LogModel.LogType.Error);
                //
                status = errorMsg;
            }
            //
            return status;
        }
        #endregion

        #region "CSV ASYNC DEMO"
        //
        public ActionResult _XlsAsyncDemo()
        {
            //
            try
            {
                //---------------------------------------------------
                // LOG
                //---------------------------------------------------
                LogModel.Log("PAGE_CSV_ASYNC_DEMO", this.GetIpValue(), LogModel.LogType.Info);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return View();
        }
        //
        public Task<String> SetCSVTaskAsync()
        {
            return Task<String>.Factory.StartNew(() =>
            {
                //
                string status = "ok";
                //
                try
                {
                    //------------------------------------------------------------------------------------------------------
                    // OBTENER DATOS
                    //------------------------------------------------------------------------------------------------------
                    DataTable maestroListado = PersonasModel.ListadoPersonasDataTable();

                    //------------------------------------------------------------------------------------------------------
                    // DECLARACION DE VARIABLES
                    //------------------------------------------------------------------------------------------------------
                    Exam70483Library.Globals.AsyncTaskType asyncType = Exam70483Library.Globals.AsyncTaskType.CSVExnacato;
                    string rootPath = Server.MapPath("~/");
                    //------------------------------------------------------------------------------------------------------
                    // INSTANCIACION DE CLASE 
                    //------------------------------------------------------------------------------------------------------
                    //
                    CSVManager csvManager = new CSVManager
                        (
                              asyncType
                            , maestroListado
                            , rootPath
                        );
                    status = csvManager.GetCSV();

                    //------------------------------------------------------------------------------------------------------
                    // LOG
                    //------------------------------------------------------------------------------------------------------
#if DEBUG
                    LogModel.Log("CSV_ASYNC");

                    LogModel.Log(string.Format("ROOT_PATH : {0}", rootPath));

                    LogModel.Log(string.Format("ROOT_FILE : {0}", status));

                    LogModel.Log(string.Format("RECORD_AMT : {0}", maestroListado.Rows.Count));
#endif

                }
                catch (Exception e)
                {
                    //
                    string errorMsg = string.Format("CSV_ERROR : {0}", e.InnerException.Message + " " + e.StackTrace);
                    //
                    LogModel.Log(errorMsg, string.Empty, LogModel.LogType.Error);
                    //
                    status = errorMsg;
                }

                return status;

            });
        }
        #endregion

        #region "ZIP ASYNC DEMO"
        //
        public ActionResult _ZipDemo()
        {
            //
            try
            {
                //---------------------------------------------------
                // LOG
                //---------------------------------------------------
                LogModel.Log("PAGE_ZIP_DEMO", this.GetIpValue(), LogModel.LogType.Info);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return View();

        }
        //
        [HttpPost]
        public ActionResult _ZipDemo(HttpPostedFileBase UploadFileCtrl)
        {
            //
            if (UploadFileCtrl != null && UploadFileCtrl.ContentLength > 0)
                //
                try
                {
                    //
                    string path = Path.Combine(Server.MapPath("~/Output/UploadedFiles"),
                                               Path.GetFileName(UploadFileCtrl.FileName));
                    //
                    TempData["UploadedFileName"] = UploadFileCtrl.FileName;
                    //
                    UploadFileCtrl.SaveAs(path);
                    //
                    ViewBag.Message = "[SE CARGO EL ARCHIVO CORRECTAMENTE]";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = string.Format("[ERROR EN CARGA DE ARCHIVO : {0}", ex.Message.ToString());
                }
            else
            {
                ViewBag.Message = "[DEBE ESPECIFICAR UN ARCHIVO]";
            }
            return View();
        }
        //
        public Task<String> SetZipAsync()
        {
            return Task<String>.Factory.StartNew(() =>
            {
                //
                string status = "ok";
                //
                try
                {
                    //------------------------------------------------------------------------------------------------------
                    // OBTENER ARCHIVO
                    //------------------------------------------------------------------------------------------------------

                    //------------------------------------------------------------------------------------------------------
                    // DECLARACION DE VARIABLES
                    //------------------------------------------------------------------------------------------------------
                    string fileName = TempData["UploadedFileName"].ToString();
                    string uploadedFilePath = Path.Combine(Server.MapPath("~/Output/UploadedFiles"),
                                                   Path.GetFileName(fileName));
                    string extensionDocumento = "zip";
                    string destionationDirectory = Server.MapPath(string.Format("~/Output/{0}", extensionDocumento));


                    //------------------------------------------------------------------------------------------------------
                    // INSTANCIACION DE CLASE 
                    //------------------------------------------------------------------------------------------------------
                    //
                    FileManager fileManager = new FileManager
                        (
                              uploadedFilePath
                            , destionationDirectory
                            , extensionDocumento
                        );

                    status = fileManager.SetZipFile();

                    //------------------------------------------------------------------------------------------------------
                    // LOG
                    //------------------------------------------------------------------------------------------------------
#if DEBUG
                    LogModel.Log("ZIP_ASYNC");

                    LogModel.Log(string.Format("FILE_TO_ZIP : {0}", uploadedFilePath));

                    LogModel.Log(string.Format("ZIPPED_FILE : {0}", status));
#endif
                }
                catch (Exception e)
                {
                    //
                    string errorMsg = string.Format("ZIP_ERROR : {0}", e.Message + " " + e.StackTrace);
                    //
                    LogModel.Log(errorMsg, string.Empty, LogModel.LogType.Error);
                    //
                    status = errorMsg;
                }

                return status;

            });
        }

        #endregion

        #region "Regex DEMO"
        public ActionResult _RegExDemo()
        {
            //-------------------------------------------------
            // LLAMADO A LA PÁGINA "_RegexDemo"
            //-------------------------------------------------

            try
            {
                //
                string filePath = Server.MapPath(@"~/xml/cdCatalog.xml");
                string xmlContent = System.IO.File.ReadAllText(filePath);
                string xmlContentRaw = xmlContent;
                //    
                //---------------------------------------------------------------------------------------
                // CORREGIR LINE FEEDS    
                //---------------------------------------------------------------------------------------
                string _lineBreakPattern = @"(\r\n)";
                //
                Regex rx = new Regex(_lineBreakPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                //
                MatchCollection matchCollectionLineBreak = rx.Matches(xmlContent);
                //
                foreach (Match matchEntryLineBreak in matchCollectionLineBreak)
                {
                    xmlContent = xmlContent.Replace(matchEntryLineBreak.Value, string.Format(@"|", matchEntryLineBreak.Value));
                }
                //---------------------------------------------------------------------------------------
                // CORREGIR TABS
                //---------------------------------------------------------------------------------------
                string _tabBreakPattern = @"[ \t]";
                //
                rx = new Regex(_tabBreakPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                //
                MatchCollection matchCollectiontabs = rx.Matches(xmlContent);
                //
                foreach (Match matchEntryTab in matchCollectiontabs)
                {
                    xmlContent = xmlContent.Replace(matchEntryTab.Value, string.Format(@"■", matchEntryTab.Value));
                }
                //-------------------------------------------------------------------------------------------
                // CONVERTGIR A CARACTERES LEGIBLES DE HTML
                //-------------------------------------------------------------------------------------------
                string xmlEncoded = HttpUtility.HtmlEncode(xmlContent);
                //    
                xmlEncoded = xmlEncoded.Replace(@"|", @"<br/>");
                xmlEncoded = xmlEncoded.Replace(@"■", @"&nbsp;");
                //
                //-------------------------------------------------------------------------------------------
                //
                //-------------------------------------------------------------------------------------------
                ViewBag.Message = xmlEncoded;
                //
                Session["XmlContent"] = xmlEncoded;
                //
                Session["xmlContentRaw"] = xmlContentRaw;
                //
                ViewBag.RegEx = string.Empty;

                //
                LogModel.Log("PAGE_REGEX_DEMO", this.GetIpValue(), LogModel.LogType.Info);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }
        //
        public string _RegExEval
            (
                  string p_tagSearch
                , string p_textSearch
            )
        {
            //
            string p_textContent = Session["XmlContent"].ToString();
            //                
            string p_textContentRaw = Session["XmlContentRaw"].ToString();
            //
            string status = "0";
            //
            try
            {
                //--------------------------------------------------
                // LOG
                //--------------------------------------------------
#if DEBUG
                //
                LogModel.Log(
                                    string.Format("REGEX_XML. p_tagSearch='{0}', p_textSearch='{1}'"
                                                             , p_tagSearch
                                                             , p_textSearch)
                             );
#endif
                //--------------------------------------------------
                // SEARCH REGEX TEXT
                //--------------------------------------------------
                RegExManager regexManager = new RegExManager
                    (
                          p_tagSearch
                        , p_textSearch
                        , p_textContentRaw
                    );
                //
                status = regexManager.GetMaches();

                //
#if DEBUG
                LogModel.Log(
                            string.Format("REGEX_XML. Status ='{0}'"
                                         , status)
                            );
#endif
                //
            }
            catch (Exception ex)
            {
                //
                LogModel.Log(string.Format("REGEX_ÈRROR. ='{0}'-'{1}'"
                                                         , ex.Message
                                                         , ex.StackTrace)
                            , string.Empty
                            , LogModel.LogType.Error);
            }
            //
            return status;
        }
        //
        public string _NewSearch()
        {
            //-------------------------------------------------
            // LLAMADO A LA PÁGINA 
            //-------------------------------------------------
            string xmlContent = string.Empty;
            //
            try
            {
                //
                xmlContent = Session["XmlContent"].ToString();
                //
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //
            return xmlContent;
        }
        #endregion

        #region "Sort Benchmark Demo"
        //
        public ActionResult _SortBenchMarkDemo()
        {
            //-------------------------------------------------
            // LLAMADO A LA PÁGINA "_SortBenchMarkDemo"
            //-------------------------------------------------

            try
            {
                //
                string unsortedListRaw = AlgorithmManager.GetUnsortedList
                    (
                          ARRAY_SIZE
                    );
                //
                string unsortedListEncoded = HttpUtility.HtmlEncode(unsortedListRaw).Replace("|", "<br/>");
                //
                ViewBag.Message = unsortedListEncoded;
                //
                Session["unsortedList"] = unsortedListRaw;

                //
                LogModel.Log("PAGE_SORT_BENCHAMRK_DEMO", this.GetIpValue(), LogModel.LogType.Info);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }
        //
        public string _GetSort(ushort p_sortAlgoritm)
        {
            //
            string status = "OK";
            //
            try
            {
                //--------------------------------------------------
                // DECLARACION DE VARIABLES 
                //--------------------------------------------------
                //
                string unsortedList = Session["unsortedList"].ToString();
                //                
                AlgorithmManager am = new AlgorithmManager
                    (
                          unsortedList
                        , ARRAY_SIZE
                    );
                //
                switch (p_sortAlgoritm)
                {
                    case 1: // BUBBLE SORT
                        am.BubbleSort();
                        break;
                    case 2: // QUICK SORT
                        am.QuickSort();
                        break;
                    case 3: // TREE SORT
                        am.TreeSort();
                        break;
                }
                //
                string sortedList = string.Empty;
                //
                foreach (string sortStep in am.SortSteps)
                {
                    sortedList += string.Format("■|{0}|", sortStep);
                }
                //
                string sortedListEncoded = HttpUtility.HtmlEncode(sortedList).Replace("|", "<br/>");
                //
                status = sortedListEncoded;
                //
            }
            catch (Exception ex)
            {
                LogModel.Log(string.Format("SORT_BENCHMARK_ERROR. ='{0}'-'{1}'"
                                                             , ex.Message
                                                             , ex.StackTrace)
                            , string.Empty
                            , LogModel.LogType.Error);
            }
            //--------------------------------------------------
            // LOG
            //--------------------------------------------------
#if DEBUG
            LogModel.Log(string.Format("SORT_BENCHMARK . GET SORT : {0}", status));
#endif
            //
            return status;
        }
        //
        public string _NewSort()
        {
            //
            string status = "OK";
            try
            {
                //
                string unsortedListRaw = AlgorithmManager.GetUnsortedList
                        (
                             ARRAY_SIZE
                        );
                //
                string unsortedListEncoded = HttpUtility.HtmlEncode(unsortedListRaw).Replace("|", "<br/>");
                //
                Session["unsortedList"] = unsortedListRaw;
                //
                status = unsortedListEncoded;
                //
            }
            catch (Exception ex)
            {
                LogModel.Log(string.Format("REGEX_ÈRROR. ='{0}'-'{1}'"
                                                      , ex.Message
                                                      , ex.StackTrace)
                            , string.Empty
                            , LogModel.LogType.Error
                            );
            }
            //--------------------------------------------------
            // LOG
            //--------------------------------------------------
#if DEBUG
            LogModel.Log(string.Format("SORT_BENCHMARK . NEW SORT : {0}", status));
#endif
            //
            return status;
        }
        //
        #endregion

        #region "Disjkstra DEMO"
        public ActionResult _DijkstraDemo()
        {
            //-------------------------------------------------
            // LLAMADO A LA PÁGINA "_DijkstraDemo"
            //-------------------------------------------------
            try
            {
                //
                ViewBag.Message = "";

                //
                LogModel.Log("PAGE_DIJKSTRA_DEMO.", this.GetIpValue(), LogModel.LogType.Info);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }
        //
        public string _GetGraph()
        {
            //--------------------------------------------------
            // DECLARACION DE VARIABLES
            //--------------------------------------------------
            string status = "ok";

            try
            {
                //--------------------------------------------------
                // LOG
                //--------------------------------------------------
#if DEBUG
                LogModel.Log("DIJKSTRA DEMO. GET_GRAPH");
#endif
                //--------------------------------------------------
                // CREAR GRAFO
                //--------------------------------------------------
                string vertexList = AlgorithmManager.Dijkstra();

                //--------------------------------------------------
                // CONVERTIR LISTADO A CADENA VISIBLE EN HTML
                //--------------------------------------------------
                string sortedListEncoded = string.Empty;
                sortedListEncoded = HttpUtility.HtmlEncode(vertexList);
                sortedListEncoded = sortedListEncoded.Replace(@",", @"<br/>");
                sortedListEncoded = sortedListEncoded.Replace(@"\t", @"&nbsp;");
                //
                status = sortedListEncoded;
                //
            }
            catch (Exception ex)
            {
                LogModel.Log(string.Format("REGEX_ÈRROR. ='{0}'-'{1}'"
                                                      , ex.Message
                                                      , ex.StackTrace)
                             , string.Empty
                             , LogModel.LogType.Error
                             );
            }
            //
            return status;
        }
        //
        public string _NewGraph()
        {
            //--------------------------------------------------
            // DECLARACION DE VARIABLES
            //--------------------------------------------------
            string status = "ok";

            try
            {
                //--------------------------------------------------
                // LOG
                //--------------------------------------------------
#if DEBUG
                LogModel.Log("DIJKSTRA DEMO. NEW_GRAPH");
#endif
            }
            catch (Exception ex)
            {
                LogModel.Log(
                             string.Format("REGEX_ÈRROR. ='{0}'-'{1}'"
                                                      , ex.Message
                                                      , ex.StackTrace
                             ));
            }
            //
            return status;
        }

        public string GenerateRandomVertex(ushort p_vertexSize, ushort p_sourcePoint)
        {
            //
            ushort p_sampleSize = 23;
            string status = string.Empty;

            //
            status = AlgorithmManager.GenerateRandomPoints(p_vertexSize, p_sampleSize, p_sourcePoint);

            //
            return status;
        }

        #endregion

        #region "Log DEMO"
        public ActionResult _LogDemo()
        {
            //
            List<AccessLogEntity> ListadoAccessLog = new List<AccessLogEntity>();
            //
            try
            {
                //
                LogModel.Log("PAGE_ACCESS_LOG_DEMO", this.GetIpValue());
                //
                ListadoAccessLog = LogModel.GetAccessLog
                    (
                         connString
                    );
                //
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            //
            return View(ListadoAccessLog);
        }

        public string GenerarInformeXLS()
        {
            //
            string status = "OK";

            try
            {
                //
                string _extensionDocumento  = @"xlsx";
                string _directorioDocumento = string.Format("{0}/{1}", _documentsLocalDirectory, _extensionDocumento);
                string _nombreDocumento     = string.Format("{0}{1}.{2}"
                 , System.Guid.NewGuid().ToString()
                 , DateTime.Now.ToString(Globals.DateFormatShortTimestamp)
                 , _extensionDocumento);

                //
                string resultRelativeFilePath = string.Format(@"~/{0}/{1}", _directorioDocumento, _nombreDocumento);
                string resultFilePath         = Server.MapPath(resultRelativeFilePath);

                //
                List<AccessLogEntity> ListadoAccessLog = new List<AccessLogEntity>();
                //
                ListadoAccessLog                       = LogModel.GetAccessLog(connString);
                //
                XlsManager xlsManager = new XlsManager(resultFilePath, ListadoAccessLog);
                status                = (xlsManager.GetXLS()) == true ? _nombreDocumento : @"[ERROR]";
                //
            }
            catch (Exception ex)
            {
                //
                status = String.Format("PAGE_LOG_DEMO | ERROR | {0}-{1}", ex.Message, ex.StackTrace);
                //
                LogModel.Log(status, GetIpValue(), LogModel.LogType.Error);
                //
                throw ex;
            }
            return status;
        }
        #endregion

        #region "NEURAL NETWORK DEMO"
        public ActionResult _NeuralNetworkDemo()
        {
            //-------------------------------------------------
            // LLAMADO A LA PÁGINA "_DijkstraDemo"
            //-------------------------------------------------
            try
            {
                //
                ViewBag.Message = "";

                //
                LogModel.Log("NEURAL_NETWORK_DEMO.", this.GetIpValue(), LogModel.LogType.Info);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }

        #endregion

        #endregion
    }
}