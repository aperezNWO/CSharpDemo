using Exam70483.Libraries.Managers;
using Exam70483Library;
using Exam70483Library.DataAccess;
using Exam70483Library.Managers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace Exam70483Web.Views.Demos
{
    #region "Clases"

    public class CSVAsyncTask : AsyncTask
    {
        #region "Campos"
        private string    constring        = System.Configuration.ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        private string    rootPath         = HttpContext.Current.Server.MapPath("~/");
        private DataTable _maestroListado  = new DataTable();
        public  string    _Status          = String.Empty;
        #endregion

        #region "2. Constructor"
        public CSVAsyncTask(System.Web.UI.Page page, Globals.AsyncTaskType asyncTaskName, DataTable maestroListado)
            : base(page, asyncTaskName)
        {
            this._maestroListado = maestroListado;
        }
        #endregion

        #region "3. Metodos"
        //
        public override void ExecuteAsyncTask()
        {
            switch (this._asyncTaskType)
            {
                case Globals.AsyncTaskType.CSVExnacato:
                    {
                        CSVManager csvManager = new CSVManager
                        (
                              this._asyncTaskType
                            , this._maestroListado
                            , rootPath
                        );

                        this._taskprogress = csvManager.GetCSV();

                        //------------------------------------------------------------------------------------------------------
                        // LOG
                        //------------------------------------------------------------------------------------------------------

#if DEBUG
                        LogModel.Log(string.Format("ROOT_PATH : {0}", rootPath));

                        LogModel.Log(string.Format("ROOT_FILE : {0}", _taskprogress));

                        LogModel.Log(string.Format("RECORD_AMT : {0}", this._maestroListado.Rows.Count));
#endif
                        //
                        this._endTaskProgress   = string.Format("RECORD_AMT : {0}" , this._maestroListado.Rows.Count);
                        this._Status            = this._taskprogress;
                    }

                    break;
            }
            OnStatusChanged(_taskprogress);
        }
#endregion
    }
    //
    public partial class _XlsAsyncDemoClassic : System.Web.UI.Page
    {
        #region "Campos"
                private static string constring = System.Configuration.ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
                private static string rootPath  = HttpContext.Current.Server.MapPath("~/");
        #endregion

        #region "Métodos"
                [WebMethod]
                public static string SetCSVTaskWeb()
                {
                    //
                    string status = string.Empty;
                    //
                    status = SetCSVTask();
                    //------------------------------------------------------------------------------------------------------
                    // LOG
                    //------------------------------------------------------------------------------------------------------
        #if DEBUG 
                    LogModel.Log(string.Format("SETCSVTASK_PAGEMETHOD : {0}",status));
        #endif
                    //
                    return status;
                }
                //
                private static string SetCSVTask()
                {
                    string status = string.Empty;

                    //------------------------------------------------------------------------------------------------------
                    // OBTENER DATOS
                    //------------------------------------------------------------------------------------------------------
                    DataTable maestroListado = PersonasModel.ListadoPersonasDataTable();

                    //------------------------------------------------------------------------------------------------------
                    // DECLARACION DE VARIABLES
                    //------------------------------------------------------------------------------------------------------
                    Exam70483Library.Globals.AsyncTaskType asyncType = Exam70483Library.Globals.AsyncTaskType.CSVExnacato;

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

                private static string SetCSVTask(System.Web.UI.Page page)
                {
                    string status = string.Empty;

                    //------------------------------------------------------------------------------------------------------
                    // DECLARACION DE VARIABLES
                    //------------------------------------------------------------------------------------------------------
                    Exam70483Library.Globals.AsyncTaskType asyncType = Exam70483Library.Globals.AsyncTaskType.CSVExnacato;

                    //------------------------------------------------------------------------------------------------------
                    // OBTENER DATOS
                    //------------------------------------------------------------------------------------------------------
                    DataTable maestroListado = PersonasModel.ListadoPersonasDataTable();

                    //------------------------------------------------------------------------------------------------------
                    // INSTANCIACION DE CLASE 
                    //------------------------------------------------------------------------------------------------------
                    CSVAsyncTask asyncTaskCSV = new CSVAsyncTask(page, asyncType, maestroListado);
                    asyncTaskCSV.BeginExecuteAsyncTask();
                    status                    = asyncTaskCSV._Status;
                    //------------------------------------------------------------------------------------------------------


                    //------------------------------------------------------------------------------------------------------
                    // EJEMPLO MSDN
                    //------------------------------------------------------------------------------------------------------
                    //_CSVAsyncTask asyncTaskCSV = new _CSVAsyncTask();
                    //PageAsyncTask asyncTask1 = new PageAsyncTask(asyncTaskCSV.OnBegin, asyncTaskCSV.OnEnd, asyncTaskCSV.OnTimeout, "Async1", true);
                    //------------------------------------------------------------------------------------------------------


                    return status;

                }
                //
                public void GetCSV()
                {
                    try
                    {
                        //
                        ScriptManager.RegisterStartupScript(this, this.Page.GetType(), @"[ALERTA_1]",
                                                            "javascript:_ShowProgressBar()", true);                
                        //
                        string filePath                        = SetCSVTask(this.Page);
                        //
                        string fileUrl                         = string.Format(@"javascript: void window.open('{0}')", filePath);
                        this.DownloadFile.Attributes["href"]   = fileUrl;
                        //
                        //------------------------------------------------------------------------------------------------------
                        // LOG
                        //------------------------------------------------------------------------------------------------------

                        #if DEBUG
                        LogModel.Log(string.Format("SETCSVTASK_SERVERCLICK : {0}", filePath));

                        LogModel.Log(string.Format("SETCSVTASK_SERVERCLICK : {0}", fileUrl));
                        #endif
                        //
                        this.GetCSVUpdatePanel.Update();
                        //
                        this.ShowStatusWindow("SE GENERÓ CORRECTAMENTE EL ARCHIVO");
                        //
                    }
                    catch (Exception ex)
                    {
                        //------------------------------------------------------------------------------------------------------
                        // LOG
                        //------------------------------------------------------------------------------------------------------
                        //
                        string errorMsg = ex.InnerException.Message + " | " + ex.InnerException.StackTrace;
                        //
                        LogModel.Log(string.Format("SETCSVTASK_SERVERCLICK_ERROR : {0} ", errorMsg));
                        //
                        this.ShowStatusWindow(errorMsg);
                        //
                    }
                }
                //
                public void ShowStatusWindow(string msg)
                {
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), @"[ALERTA_3]",
                                            "javascript:_HideProgressBar()", true);

                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), @"[ALERTA_2]",
                                                        string.Format("javascript:alert('{0}')", msg), true);

                    //------------------------------------------------------------------------------------------------------
                    // LOG
                    //------------------------------------------------------------------------------------------------------
        #if DEBUG
                    LogModel.Log(string.Format("SETCSVTASK_SERVERCLICK_MSG : {0} ", string.Format("javascript:alert('{0}')", msg)));
        #endif
                }
        #endregion

        #region "Event Handlers"
                protected void Page_Load(object sender, EventArgs e)
                {
                    //
                    this.scm.RegisterAsyncPostBackControl(GetCsvServerMethod);
                    //
                }

                protected void GetCSV_ServerClick(object sender, EventArgs e)
                {
                    GetCSV();
                }
        #endregion
    }
    
    #endregion
}