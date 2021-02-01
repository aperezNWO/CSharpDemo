using System;
using System.Data.SqlClient;
using System.Web.UI;
using Exam70483Library;
using Exam70483Library.DataAccess;

namespace Exam70483.Libraries.Managers
{
    public abstract class AsyncTask
    {
        #region "0. Delegados/Eventos"
        public delegate void StatusChangedEventHandler(string args);
        public delegate void AsyncTaskDelegate();
        public event StatusChangedEventHandler StatusChanged;
        #endregion

        #region "1. Campos"
        protected String                _taskprogress;
        protected String                _endTaskProgress;
        protected AsyncTaskDelegate     _dlgt;
        private   System.Web.UI.Page    _mainPage;
        protected Globals.AsyncTaskType _asyncTaskType;
        private   string                constring = System.Configuration.ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        #endregion

        #region "2. CONSTRUCTOR"
        public AsyncTask(System.Web.UI.Page page, Globals.AsyncTaskType asyncTaskName)
        {
            this._mainPage = page;
            this._asyncTaskType = asyncTaskName;
        }
        #endregion

        #region "3. METODOS"
        #region "METODOS ABSCRACTOS"
        public abstract void ExecuteAsyncTask();
        #endregion

        #region "METODOS CONCRETOS"
        // Invoke the Changed event; called whenever list changes
        public void OnStatusChanged(string statusDescription)
        {
            if (StatusChanged != null)
                StatusChanged(statusDescription);
        }

        // Define the method that will get called to
        // start the asynchronous task.
        public IAsyncResult OnBegin(object sender, EventArgs e,
            AsyncCallback cb, object extraData)
        {
            OnStatusChanged(_taskprogress);

            _dlgt               = new AsyncTaskDelegate(ExecuteAsyncTask);
            IAsyncResult result = _dlgt.BeginInvoke(cb, extraData);

            return result;
        }

        // Define the method that will get called when
        // the asynchronous task is ended.
        public void OnEnd(IAsyncResult ar)
        {
            OnStatusChanged(_endTaskProgress);
            _dlgt.EndInvoke(ar);
        }

        // Define the method that will get called if the task
        // is not completed within the asynchronous timeout interval.
        public void OnTimeout(IAsyncResult ar)
        {
            _taskprogress = "Ha ocurrido un problema. For favor intente nuevamente.";
            OnStatusChanged(_taskprogress);
        }

        public void BeginExecuteAsyncTask()
        {
            try
            {
                // Define the asynchronuous task.
                PageAsyncTask pageAsyncTask = new PageAsyncTask(this.OnBegin, this.OnEnd, this.OnTimeout, true);

                // Register the asynchronous task.
                this._mainPage.RegisterAsyncTask(pageAsyncTask);

                // Execute the register asynchronous task.
                this._mainPage.ExecuteRegisteredAsyncTasks();

            }
            catch (Exception ex)
            {
                //------------------------------------------------------------------------------------------------------
                // LOG
                //------------------------------------------------------------------------------------------------------
                //
                string errorMsg = string.Format("{0}-{1}",ex.Message,ex.StackTrace);
                //
                LogModel.Log(string.Format("ASYNCTASK_BeginExecuteAsyncTask_ERROR : {0} ", errorMsg)
                             ,string.Empty
                             ,LogModel.LogType.Error);
            }
        }
        #endregion
        #endregion
    }

}

