using Exam70483Library.DataAccess;
using Exam70483Library.Managers;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Services;

namespace Exam70483Web.ASPNET
{

    /// <summary>
    /// Helper web service for CascadingDropDown sample
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class _XlsAsyncDemoClassicWS : WebService
    {
        #region "Campos"
        private static string constring = System.Configuration.ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        #endregion

        #region "Métodos"
        [WebMethod]
        public string SetCSVTaskWeb()
        { 
            //
            string status = string.Empty;
            //------------------------------------------------------------------------------------------------------
            // LOG
            //------------------------------------------------------------------------------------------------------
            #if DEBUG
                LogModel.Log("SETCSVTASK_WEBSERVICE");
            #endif            

            //
            status = SetCSVTask();
            
            //
            return status;
        }
        //
        protected static string SetCSVTask()
        {
            string status = string.Empty;

            //------------------------------------------------------------------------------------------------------
            // OBTENER DATOS
            //------------------------------------------------------------------------------------------------------
            DataTable maestroListado = PersonasModel.ListadoPersonasDataTable(); 

            //------------------------------------------------------------------------------------------------------
            // DECLARACION DE VARIABLES
            //------------------------------------------------------------------------------------------------------
            Exam70483Library.Globals.AsyncTaskType asyncType  = Exam70483Library.Globals.AsyncTaskType.CSVExnacato;
            string rootPath                                   = HttpContext.Current.Server.MapPath("~/");

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
            LogModel.Log(string.Format("ROOT_PATH : {0}", rootPath));

            LogModel.Log(string.Format("ROOT_FILE : {0}", status));

            LogModel.Log(string.Format("RECORD_AMT : {0}", maestroListado.Rows.Count));
#endif

            //
            return status;
        }
        //
        #endregion
    }
}