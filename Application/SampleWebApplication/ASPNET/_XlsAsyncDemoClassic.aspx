﻿<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="_XlsAsyncDemoClassic.aspx.cs" 
    Inherits="Exam70483Web.Views.Demos._XlsAsyncDemoClassic" 
    Async="true"
    AsyncTimeout="1000"
%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
        <link href="../Content/Site.css"              rel="stylesheet"/>
        <link href="../Content/bootstrap.css"         rel="stylesheet"/>
        <link href="../Content/bootstrap.min.css"     rel="stylesheet"/>
        <script type="text/javascript"                src ="../scripts/jquery-1.10.2.min.js"></script>
 </head>
    <style>
    /*------------------------------------------------*/
    /* ESTILOS STATUS DE OPERACION                    */
    /*------------------------------------------------*/
    .modalStatus {
        display: none; /* Hidden by default */
        position: fixed; /* Stay in place */
        z-index: 99; /* Sit on top */
        left: 0;
        top: 0;
        width: 100%; /* Full width */
        height: 100%; /* Full height */
        overflow: auto; /* Enable scroll if needed */
        background-color: rgb(0,0,0); /* Fallback color */
        background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
    }

    .modalStatus-content {
        text-align:center;
        background-color: #fefefe;
        margin: 15% auto; /* 15% from the top and centered */
        padding: 1em;
        border: 1px solid #888;
        width: 100%; /* Could be more or less, depending on screen size */
        color: black;
    }
</style>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scm" runat="server" EnablePageMethods="true" />
        <div class="main-container">
            <div class="content">
                <div class="content-body">
                    <p>[ARCHIVOS CSV / LLAMADO A WEBMETHODS / ASP.NET CLASICO]</p>
                    <p>[WEBMETHODS            - <a href="javascript: void window.open('https://docs.microsoft.com/es-es/dotnet/api/system.web.services.webmethodattribute?view=netframework-4.8')">[Attributo "WebMethod"]</a>]</p>
                    <p>[EJECUCION ASINCRONICA - <a href="javascript: void window.open('https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.pageasynctask?view=netframework-4.8')">[CLASE "PageAsyncTask"]</a>]</p>
                </div>
                <hr />
                <div>
                        [OBTENER CSV]
                        <ul>
                            <li>
                                Ver Código Fuente : [<a href="javascript:void window.open('../Source/_XlsAsyncDemoClassic_HTML.txt');" class="DownloadSourceCode">HTML</a>] [<a href="javascript:void window.open('../Source/_XlsAsyncDemoClassicWS_CS.txt');" class="DownloadSourceCode">CS</a>]                                
                                <input id="GetCsvWS"           type="button" title="[GET CSV]" value="[GET CSV]"></input> [WebService/Jquery/Ajax]
                            </li>
                        </ul>
                        <ul>
                            <li>
                                Ver Código Fuente : [<a href="javascript:void window.open('../Source/_XlsAsyncDemoClassic_HTML.txt');" class="DownloadSourceCode">HTML</a>] [<a href="javascript:void window.open('../Source/_XlsAsyncDemoClassic_CS.txt');" class="DownloadSourceCode">CS</a>]
                                <input id="GetCsvPageMethod"   type="button" title="[GET CSV]" value="[GET CSV]"></input> [PageMethod/Jquery/Ajax]
                            </li>
                        </ul>
                        <asp:Panel ID="pnlGetCSV" runat="server">
                             <asp:UpdatePanel ID="GetCSVUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>
                                    <ul>
                                        <li>
                                            Ver Código Fuente : [<a href="javascript:void window.open('../Source/_XlsAsyncDemoClassic_HTML.txt');" class="DownloadSourceCode">HTML</a>] [<a href="javascript:void window.open('../Source/_XlsAsyncDemoClassic_CS.txt');" class="DownloadSourceCode">CS</a>]
                                            <input id="GetCsvServerMethod" type="button" title="[GET CSV]" value="[GET CSV]" runat="server" onserverclick="GetCSV_ServerClick"></input> [ServerMethod (ASYNC)/Jquery/Ajax] 
                                        </li>
                                    </ul>
                                    <hr />
                                        <a href="#" id="DownloadFile" runat="server">Descargar CSV</a>
                                    <hr />
                            </ContentTemplate>
                      </asp:UpdatePanel>
                   </asp:Panel>
                </div>
            </div>
        </div>
        <!-- FOOTER -->
       <div class="container body-content">
       <hr />
            <footer>
               <div>
                <!-- VERSION DEL APLICATIVO-->
                Aplicativo MCSD-DEMO - Version : <%=Exam70483Web.Controllers.HomeController.ApplicationVersion %> | Compatible con Google Chrome / Mozilla Firefox
               </div>
               <br />
                <!-- INICIO VENTANA MODAL TRANSCURSO OPERACION -->
                <div id="statusWindow" class="modalStatus" style="display:none">
                    <div class="modalStatus-content">
                        ... Procesando ...
                    </div>
                </div>
                <!-- FIN VENTANA MODAL TRANSCURSO DE OPERACION -->
            </footer>
        </div>
    </form>
</body>
</html>

<script type="text/javascript">
    //
    $(document).ready(function ()
    {
        console.log("LOADING PAGE 5");
    });
    //
    $(document).ajaxStart(function () {
        _ShowProgressBar();
    });
    /**************************************************************************************************/
    $(document).ajaxStop(function () {
        _HideProgressBar();
    });
    /**************************************************************************************************/
    $(document).ajaxComplete(function () {
        _HideProgressBar();
    });
    /**************************************************************************************************///
    $(document).ajaxSuccess(function () {
        _HideProgressBar();
    });
    //
    function _ShowProgressBar() {
        //
        var modal = document.getElementById("statusWindow");
        modal.style.display = "block";

        console.log('status window show');
        //
    }
    // 
    function _HideProgressBar() {
        //
        var modal = document.getElementById("statusWindow");
        modal.style.display = "none";
        modal.style.display = "hidden";

        console.log('status window hide');
        //
    }
    //
    $("#GetCsvPageMethod").click(function ()
    {
        SearchPageMethod();
    });
    //
    function SearchPageMethod()
    {
        //
        _ShowProgressBar();
        //
        PageMethods.SetCSVTaskWeb(function (response) {
            //
            var filePath = response;
            //
            console.log("SETCSVTASK_PAGEMETHOD. CSV PATH : " + filePath);
            //
            $("#DownloadFile").attr("href", "javascript:void window.open('" + filePath + "');");
            //
            _HideProgressBar();
            //
            alert('SE GENERÓ CORRECTAMENTE EL ARCHIVO');
        });
    }
    //
    $("#GetCsvWS").click(function ()
    {
        SearchWS();
    });
    //
    function SearchWS()
    {
        $.ajax
            ({
                url         : "_XlsAsyncDemoClassicWS.asmx/SetCSVTaskWeb",
                async       : true,
                global      : true,
                type        : "post",
                contentType : "application/xml",
                datatype    : "xml",  
                success     : function (data)
                {
                    //
                    var filePath = data.childNodes[0].innerHTML;
                    //
                    console.log("CSV PATH : " + filePath);
                    //
                    $("#DownloadFile").attr("href", "javascript:void window.open('" + filePath + "');");
                    //
                    alert('SE GENERÓ CORRECTAMENTE EL ARCHIVO');
                    //
                    return true;
                },
                error: function (xhr, textStatus, errorThrown)
                {
                    //
                    console.error("ERROR : " + xhr.responseText);
                    //
                    alert("ERROR : " + errorThrown);
                    //
                    return false;
                }
        });
    }
</script>
