using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using Exam70483Library.DataAccess;
using Exam70483Library.Managers;
using Exam70483Web.Models.Entity;

namespace Exam70483Web.Controllers
{
    public class PersonasController : GenericController
    {
        #region "Campos"
        //
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        //
        #endregion

        #region "Metodos"
        public ActionResult Listado()
        {
            //
            List<PersonaEntity> listPersona = new List<PersonaEntity>();
            //
            try
            {
                //
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
                //
                using (var connection = new SqlConnection(constring))
                {
                    //
                    connection.Open();
                    //
                    LogModel.Log("PAGE_EXNACATO_LISTADO", this.GetIpValue());
                    //
                    listPersona = PersonasModel.Submit_6_Tsql_SelectPersona(connection);
                }
                //
                return View(listPersona);
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        //
        public string SetCSVTaskPersonas()
        {
            //
            string status = "ok";
            //
            try
            {
                //---------------------------------------------------
                // LOG
                //---------------------------------------------------
#if DEBUG
                LogModel.Log("CSV_ASYNC");
#endif

                //------------------------------------------------------------------------------------------------------
                // OBTENER DATOS
                //------------------------------------------------------------------------------------------------------
                DataTable maestroListado = PersonasModel.ListadoPersonasDataTable();

                //------------------------------------------------------------------------------------------------------
                // DECLARACION DE VARIABLES
                //------------------------------------------------------------------------------------------------------
                Exam70483Library.Globals.AsyncTaskType asyncType = Exam70483Library.Globals.AsyncTaskType.CSVExnacato;
                string rootPath                                  = Server.MapPath("~/");

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
            }
            catch (Exception e)
            {
                //
                string errorMsg = string.Format("CSV_ERROR : {0}",e.InnerException.Message + " " + e.StackTrace);
                //
                LogModel.Log(errorMsg,string.Empty,LogModel.LogType.Error);
                //
                status = errorMsg;
            }

            return status;
        }
        #endregion
    }
}