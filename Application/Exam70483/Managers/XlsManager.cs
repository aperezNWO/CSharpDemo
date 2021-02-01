using System;
using System.Collections.Generic;
using System.IO;
using Exam70483Web.Models.Entity;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Exam70483Library.Managers
{
    public class XlsManager
    {
        #region "Campos"
        string                _resultFilePath;
        List<AccessLogEntity> _listadoAccessLog;
        #endregion

        #region "Constructor"
        //
        public XlsManager(
                            string                 p_resultFilePath
                            ,List<AccessLogEntity> p_listadoAccessLog
                         )
        {
            //
            this._listadoAccessLog = p_listadoAccessLog;
            this._resultFilePath   = p_resultFilePath;
        }
        #endregion

        #region "Métodos"
        //
        public bool GetXLS()
        {
            //
            bool result = true;
            //
            try
            {
                //
                CrearExcel();

                //
                result = true;
            }
            catch (Exception ex)
            {
                //
                string errorMsg = string.Format("PAGE_LOG_DEMO_ERROR : {0}",(ex.Message + "-" + ex.StackTrace));
                //
                LogModel.Log(errorMsg, string.Empty,LogModel.LogType.Error);
                //
                result = false;
            }

            return result;
        }
        //
        public static String GetCellPositionFromIndex(int column)
        {
            column--;
            String col = Convert.ToString((char)('A' + (column % 26)));
            while (column >= 26)
            {
                column = (column / 26) - 1;
                col = Convert.ToString((char)('A' + (column % 26))) + col;
            }
            return col;
        }
        //
        public void CrearExcel()
        {
            //
            string nombreHoja  = "LOG";


            //
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel          = new ExcelPackage();

            //
            using (excel       = new ExcelPackage(new FileInfo(_resultFilePath)))
            {
                //
                excel.Workbook.Worksheets.Add(nombreHoja);
                excel.Save();

                //
                var hojaActual = excel.Workbook.Worksheets[nombreHoja];


                //-----------------------------------------------------------
                // ENCABEZADO
                //-----------------------------------------------------------

                //
                List<string> headerNames = new List<string>();
                //
                headerNames.Add("PAGE_NAME");
                headerNames.Add("ACCESS_DATE");
                headerNames.Add("IP_VALUE");

                //
                for (int index = 0; index < headerNames.Count; index++)
                {
                    //
                    string cellPosition = string.Format(@"{0}1",GetCellPositionFromIndex((index+1)));
                    string cellValue    = headerNames[index];

                    //
                    hojaActual.Cells[cellPosition].Value                  = cellValue;
                    hojaActual.Cells[cellPosition].Style.Font.Color.SetColor(System.Drawing.Color.White);
                    hojaActual.Cells[cellPosition].Style.Font.Bold        = true;
                    hojaActual.Cells[cellPosition].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    hojaActual.Cells[cellPosition].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.SaddleBrown);
                    hojaActual.Cells[cellPosition].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thick);
                }

                //------------------------------------------------------------------
                // CONTENIDO
                //------------------------------------------------------------------                
                for (int index = 0; index < this._listadoAccessLog.Count; index++)
                {
                    //
                    AccessLogEntity accessLogEntity = this._listadoAccessLog[index];
                    string cellPosition             = string.Empty;
                    string cellValue                = string.Empty;

                    // PAGE_NAME
                    cellPosition                         = string.Format(@"A{0}", (index + 2));
                    cellValue                            = accessLogEntity.PageName;  
                    hojaActual.Cells[cellPosition].Value = cellValue;
                    hojaActual.Cells[cellPosition].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    // ACCESS_DATE
                    cellPosition                         = string.Format(@"B{0}", (index + 2));
                    cellValue                            = accessLogEntity.AccessDate.ToString(); 
                    hojaActual.Cells[cellPosition].Value = cellValue;
                    hojaActual.Cells[cellPosition].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    // IP_VALUE
                    cellPosition                         = string.Format(@"C{0}", (index + 2));
                    cellValue                            = accessLogEntity.IPValue;
                    hojaActual.Cells[cellPosition].Value = cellValue;
                    hojaActual.Cells[cellPosition].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                }

                //--------------------------------------------------------------------
                // FORMATEAR DOCUMENTO
                //--------------------------------------------------------------------
                hojaActual.Cells.AutoFitColumns();
                hojaActual.View.ShowGridLines = false;
                hojaActual.View.FreezePanes(2, 1);
                excel.Save();
            }
        }

        #endregion
    }
}
