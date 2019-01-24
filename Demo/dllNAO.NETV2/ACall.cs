using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Baku.LibqiDotNet;
namespace dllNAO.NETV2
{
    /// <summary>
    /// Methods related to sync Call:
    /// </summary>
    public class ACall
    {

        public BackgroundWorker bw;

       public struct structRobotMotor
        {
            bool Enabled;
            string Name;
            double[] Angle;
            double[] time;

        }
        
       public struct structNAOqiParameters
        {
            public string robotIP;
            public int port;
            public structRobotMotor[] motors;
            public string method;
            public string SingleParamValue;
            public object[] QiParams;
            #region Motion Values 
            public string[] names;
            public double[][] AngleList;
            public double[][] timeLists;
            public bool isAbsolute;
            #endregion

            public dllNAO.NETV2.clsGlobals.NAOqiServices Service;
            //used for debug only
            public string debugString;
        }
       public struct structAcallResult
        {
            public enum Result { failure = 0, Sucess = 1 }
            public Result ResultStatus;
            public string Message;
            public DateTime dateTime;

            public int NAOqiResult;
            /// <summary>
            /// Optional 
            /// </summary>
            public object NAOqiObject;
        }
        public ACall()
        {
           bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.DoWork += Bw_DoWork;
           
        }
        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            structNAOqiParameters parameters;
            structAcallResult result = new structAcallResult();
            parameters = (structNAOqiParameters)e.Argument;
            bw.ReportProgress(10);                    
                try
                {
                    bw.ReportProgress(30);
                dllNAO.NETV2.clsGlobals global = new clsGlobals();
                if (!string.IsNullOrEmpty( parameters.debugString))
                {
                    result = global.callNaoqiFIXED(parameters);
                }
                else
                {
                    result = global.callNaoqi(parameters);
                }
                    bw.ReportProgress(80);
                    e.Result = result;
                    bw.ReportProgress(100);
                }
                catch (Exception ex )
                {
                    bw.ReportProgress(100);
                  
                    result.Message = ex.Message;
                    result.dateTime = DateTime.Now;
                    e.Result = result;

                }



            
           
            // and to transport a result back to the main thread              
            e.Result = result;
        }


    }
}





