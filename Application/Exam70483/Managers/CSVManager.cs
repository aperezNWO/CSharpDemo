using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;


namespace Exam70483Library.Managers
{
    public class CSVManager
    {
        #region "Campos Dinamicos"
        private string nombreDocumento;
        private string documentHeader;
        private DataTable maestroListado;
        private Globals.AsyncTaskType asyncTaskName;
        private string rootPath;
        #endregion

        #region "Campos Estaticos"
        private static string csvSeparator = ";";
        private static string csvSeparatorReplacement = "|";
        #endregion

        #region "constructor"
        //
        public CSVManager
        (
                  Globals.AsyncTaskType anAsyncTaskName
                , DataTable aMaestroListado
                , string aRootPath
        )
        {
            //
            this.asyncTaskName = anAsyncTaskName;
            this.maestroListado = aMaestroListado;
            this.rootPath = aRootPath;

            //
            SetPreconditions();
        }

        public CSVManager(Globals.AsyncTaskType anAsyncTaskName, DataTable aMaestroListado)
        {
            this.asyncTaskName = anAsyncTaskName;
            this.maestroListado = aMaestroListado;

            this.SetPreconditions();
        }
        #endregion

        #region "Propiedades"
        public static string CSVSeparator
        {
            get
            {
                return csvSeparator;
            }
        }

        public static string CSVSeparatorReplacement
        {
            get
            {
                return csvSeparatorReplacement;
            }
        }

        public string DocumentHeader
        {
            get
            {
                return documentHeader;
            }
            set
            {
                documentHeader = value;
            }
        }

        public static string DirectorioLocalDocumentos
        {
            get
            {
                return ConfigurationManager.AppSettings["DocumentsLocalDirectory"].ToString();
            }
        }

        public static string ExtensionDocumento
        {
            get
            {
                return "csv";
            }
        }

        public static string DirectorioLocalCSV
        {
            get
            {
                string directorioLocalCSV = string.Format(@"{0}\{1}"
                , DirectorioLocalDocumentos
                , CSVManager.ExtensionDocumento);

                return directorioLocalCSV;
            }
        }

        public string NombreDocumento
        {
            // 1.1 COMPOSICION DE NOMBRE DE DOCUMENTO :
            // a. Sesion
            // b. fecha
            // c. hora.
            // d. minuto/segundo
            get
            {
                return this.nombreDocumento;
            }
        }

        public string RutaDocumentoCSV
        {
            get
            {
                string rutaDocumentoCSV = string.Format(@"{0}\{1}\{2}"
                                , this.rootPath
                                , CSVManager.DirectorioLocalCSV
                                , this.NombreDocumento);

                return rutaDocumentoCSV;
            }
        }

        public static string UrlRootDocumentos
        {
            get
            {
                return ConfigurationManager.AppSettings["DocumentsUrl"].ToString();
            }
        }

        public string ResultsURL
        {
            get
            {
                //
                string resultsURL = string.Format(@"../{0}/{1}"
                                , CSVManager.DirectorioLocalCSV
                                , this.NombreDocumento);
                //
                resultsURL = resultsURL.Replace(@"\", @"/");
                //
                return resultsURL;
            }
        }
        #endregion

        #region "Metodos"

        #region "Auxiliares"
        private void SetPreconditions()
        {
            //
            this.nombreDocumento = string.Format("{0}{1}.{2}"
             , System.Guid.NewGuid().ToString()
             , DateTime.Now.ToString(Globals.DateFormatShortTimestamp)
             , ExtensionDocumento);
            //
            string directoryPath = string.Format("{0}{1}", this.rootPath, CSVManager.DirectorioLocalCSV);
            //
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
        #endregion

        #region "Principales"
        private string GetCSVExnacato()
        {
            //-----------------------------------------
            // PRECONDICIONES
            //-----------------------------------------
            if (this.maestroListado == null)
                return string.Empty;

            //-----------------------------------------
            // LOG
            //-----------------------------------------
#if DEBUG
            LogModel.Log(string.Format("FILE_PATH : {0}", this.RutaDocumentoCSV));
#endif

            //-----------------------------------------
            // ESCRIBIR DATOS
            //-----------------------------------------
            this.DocumentHeader = string.Format("sep={0}{1}", CSVManager.CSVSeparator, System.Environment.NewLine);
            this.DocumentHeader += string.Format("NombreCompleto{0}ProfesionOficio{0}", CSVManager.CSVSeparator);
            //
            using (StreamWriter sw = new StreamWriter(this.RutaDocumentoCSV, true, Encoding.Unicode))
            {
                //
                sw.WriteLine(this.DocumentHeader);
                //
                int rowCount = maestroListado.Rows.Count;
                //
                for (int i = 0; i < rowCount; i++)
                {
                    //
                    StringBuilder content = new StringBuilder();
                    //
                    string nombreCompleto = maestroListado.Rows[i][1].ToString();
                    //
                    content.Append
                        (
                            string.Format("=\"{0}\"", nombreCompleto)
                        );
                    //
                    string profesionOficio = maestroListado.Rows[i][2].ToString();
                    //
                    content.Append
                        (
                           string.Format("{0}{1}"
                                 , CSVManager.CSVSeparator
                                 , profesionOficio
                        ));
                    //
                    sw.WriteLine(content.ToString());
                }

                sw.Close();
            }
            return this.ResultsURL;
        }

        public string GetCSV()
        {
            //
            string status = string.Empty;
            //
            try
            {
                switch (this.asyncTaskName)
                {
                    case Globals.AsyncTaskType.CSVExnacato:
                        status = this.GetCSVExnacato();
                        break;
                }
                //
                return status;
            }
            catch (Exception ex)
            {

                //-----------------------------------------
                // LOG
                //-----------------------------------------
                LogModel.Log(string.Format(@"CSV_ERROR : {0} : {1} ", ex.Message, ex.StackTrace)
                            , string.Empty
                            , LogModel.LogType.Error);

                //
                return "ERROR_CSV";
            }
        }

        #endregion 

        #endregion
    }
}
