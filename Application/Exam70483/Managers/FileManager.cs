using System;
using System.IO;
using System.IO.Compression;


namespace Exam70483Library.Managers
{
    public class FileManager
    {
        #region "Campos"
        private string _uploadedFilePath;
        private string _destionationDirectory;
        private string _extensionDocumento;
        #endregion

        #region "Constructor"
        public FileManager
        (
            string uploadedFilePath,
            string destinationDirectory,
            string extensionDocumento
        )
        {
            this._uploadedFilePath = uploadedFilePath;
            this._destionationDirectory = destinationDirectory;
            this._extensionDocumento = extensionDocumento;
        }
        #endregion

        #region "Métodos"
        //
        private string GetFileName()
        {
            //
            string fileName = string.Format("{0}{1}.{2}"
             , System.Guid.NewGuid().ToString()
             , DateTime.Now.ToString(Globals.DateFormatShortTimestamp)
             , _extensionDocumento);
            //
            return fileName;

        }
        //
        public string SetZipFile()
        {
            //------------------------------------------------------------------------------------------
            // DECLARACION DE VARIABLES
            //------------------------------------------------------------------------------------------

            string _uploadedFileName          = Path.GetFileName(_uploadedFilePath);
            string _sourceDirectoryName       = _uploadedFileName.Replace(".","_");
            string _destionationTempDir       = string.Format(@"{0}\{1}"    , _destionationDirectory, _sourceDirectoryName);
            string _destionationTempPath      = string.Format(@"{0}\{1}\{2}", _destionationDirectory, _sourceDirectoryName, _uploadedFileName);
            string _destionationFileName      = GetFileName();
            string _destinationFullPath       = string.Format(@"{0}\{1}"
                , _destionationDirectory
                , _destionationFileName
                );
            string _destionationUrl           = string.Format("../Output/zip/{0}"
                , _destionationFileName
            );

            //------------------------------------------------------------------------------------------
            // CREACION DE DIRECTORIOS / ARCHIVOS TEMPORALES
            //------------------------------------------------------------------------------------------
            //
            Directory.CreateDirectory(_destionationTempDir);
            //
            bool overWriteFile = true;
            File.Copy(_uploadedFilePath, _destionationTempPath,overWriteFile);
            //
            ZipFile.CreateFromDirectory(_destionationTempDir, _destinationFullPath);


            //
            return _destionationUrl;
            //
        }
        #endregion
    }
}
