//============================================================================
// Nombre      : 
// Autor       : 
// Version     :
// Copyright   : 
// Descripcion : 
//============================================================================
using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.end;

namespace Exam70483.Libraries.Managers
{
    #region "Clases"
    public class PDFManager  /* : EventRaiser*/
    {
        /// <summary>
        /// CREATE A PDF FILE FROM BOTH VALID HTML AND CSS SOURCES
        /// </summary>
        /// <param name="htmlContent">A Well Formed html Document. IMAGE PATH MUST BE LOADED AT RUNTIME.  </param>
        /// <param name="cssPath">Path to a valid css file</param>
        /// <param name="resultsFilePath">Output path to the resulting pdf</param>
        public static void GetPDFFile(string htmlContent, string cssPath, string resultsFilePath)
        {
            //-----------------------------------------------
            // INICIAR VARIABLES
            //-----------------------------------------------
            List<string> cssFiles = new List<string>();
            cssFiles.Add(cssPath);

            var output          = new MemoryStream();
            var input           = new MemoryStream(Encoding.UTF8.GetBytes(htmlContent));
            var document        = new Document();
            var writer          = PdfWriter.GetInstance(document, output);
            writer.CloseStream  = false;
            document.Open();

            //-----------------------------------------------
            // AÑADIR Y ANALIZAR CSS + HTML
            //-----------------------------------------------
            var htmlContext = new HtmlPipelineContext(null);
            htmlContext.SetTagFactory(iTextSharp.tool.xml.html.Tags.GetHtmlTagProcessorFactory());

            ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
            cssFiles.ForEach(i => cssResolver.AddCssFile(i, true));

            var pipeline  = new CssResolverPipeline(cssResolver, new HtmlPipeline(htmlContext, new PdfWriterPipeline(document, writer)));
            var worker    = new XMLWorker(pipeline, true);
            var p          = new XMLParser(worker);

            p.Parse(input);
            document.Close();
            output.Position = 0;

            //-----------------------------------------------
            // GUARDAR ARCHIVO
            //-----------------------------------------------
            using (FileStream file = new FileStream(resultsFilePath, FileMode.Create, FileAccess.Write))
            {
                output.WriteTo(file);
            }

        }
    }
    #endregion
}
