using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Path;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace dllNAO.NETV2
{
    public class clsGlobals
    {
        public double[][] tmpList;
        static public bool PathAdded = false;
        public clsGlobals()
        {
            if (PathAdded==false)
            {
PathModifier.AddEnvironmentPath("dlls", PathModifyMode.RelativeToWorkingDirectory);
                PathAdded = true;
            }

            

        }
        public enum NAOqiServices { ALMemory, ALTextToSpeech, ALMotion }

        public ACall.structAcallResult callNaoqi(string CallParametervalue, string ip = "127.0.0.1", int port = 9559, string Service = "ALTextToSpeech", string methodName = "say")
        {

            ACall.structAcallResult result = new ACall.structAcallResult();
            try
            {
                QiString value = new QiString(CallParametervalue);

                // PathModifier.AddEnvironmentPath("dlls", PathModifyMode.RelativeToEntryAssembly);
                string address = "tcp://" + ip + ":+" + port.ToString();
                var session = QiSession.Create(address);
                Console.WriteLine($"Connected? {session.IsConnected}");
                if (!session.IsConnected)
                {
                    result.ResultStatus = ACall.structAcallResult.Result.failure;
                    result.Message = "end program because there is no connection";
                    result.dateTime = DateTime.Now;
                    result.NAOqiResult = -1;
                    return result;
                }
                var tts = session.GetService(Service);
                result.NAOqiObject = tts[methodName].Call(value);

                session.Close();
                session.Destroy();

                result.ResultStatus = ACall.structAcallResult.Result.Sucess;
                result.Message = "Successfull called and excecuted the program on Robot";
                result.dateTime = DateTime.Now;
                result.NAOqiResult = 1;
                return result;
            }
            catch (Exception ex)
            {
                result.ResultStatus = ACall.structAcallResult.Result.failure;
                result.Message = "Exception on call function CallNaoqi , " + ex.Message;
                result.dateTime = DateTime.Now;
                result.NAOqiResult = -1;
                return result;
            }
        }

        /// <summary>
        ///  Move Single Motor by angle
        /// </summary>
        /// <param name="NAOqiParameters">parameter name : singleMotor name should be valid</param>
        /// <param name="angle">Motor Angle </param>
        /// <returns></returns>
        public ACall.structAcallResult callNaoqi(ACall.structNAOqiParameters NAOqiParameters, double angle)
        {
            ACall.structAcallResult result = new ACall.structAcallResult();
            string address = "tcp://" + NAOqiParameters.robotIP + ":+" + NAOqiParameters.port.ToString();
            var session = QiSession.Create(address);
            var motion = session.GetService(NAOqiParameters.Service.ToString("F"));
            double toRad = Math.PI / 180.0;
            QiList<QiString> namesB
                                   = QiList.Create(new string[] { NAOqiParameters.SingleParamValue });

            QiList<QiList<QiDouble>> angleListsB
                = QiList.Create<QiList<QiDouble>>(new QiList<QiDouble>[]
            {
        QiList.Create(new double[] { angle * toRad })
            });
            QiList<QiList<QiDouble>> timeListsB
                = QiList.Create<QiList<QiDouble>>(new QiList<QiDouble>[]
            {
        QiList.Create(new double[] { 1.0})
            });

            QiBool isAbsoluteB = new QiBool(true);

            result.NAOqiObject = motion["angleInterpolation"].Call(namesB, angleListsB, timeListsB, isAbsoluteB);

            result.ResultStatus = ACall.structAcallResult.Result.Sucess;
            return result;
        }


        /// <summary>
        ///  for Debug /// will be Deleted when finished .
        ///  
        /// </summary>       
        /// <returns></returns>
        public ACall.structAcallResult callNaoqiFIXED(ACall.structNAOqiParameters NAOqiParameters)
        {
            ACall.structAcallResult result = new ACall.structAcallResult();
            string address = "tcp://" + NAOqiParameters.robotIP + ":+" + NAOqiParameters.port.ToString();
            var session = QiSession.Create(address);
            var motion = session.GetService(NAOqiParameters.Service.ToString("F"));
            double toRad = Math.PI / 180.0;

                    QiList<QiString> names
                        = QiList.Create(new string[] { "HeadYaw", "HeadPitch" });

                    QiList<QiList<QiDouble>> angleLists
                        = QiList.Create<QiList<QiDouble>>(new QiList<QiDouble>[]
                    {
        QiList.Create(new double[] { 30.0 * toRad }),
        QiList.Create(new double[] { -30.0 * toRad})
                    });

                    QiList<QiList<QiDouble>> timeLists
                        = QiList.Create<QiList<QiDouble>>(new QiList<QiDouble>[]
                    {
        QiList.Create(new double[] { 1.0}),
        QiList.Create(new double[] { 1.0})
                    });

                    QiBool isAbsolute = new QiBool(true);

                    result.NAOqiObject = motion["angleInterpolation"].Call(names, angleLists, timeLists, isAbsolute);
                    result.ResultStatus = ACall.structAcallResult.Result.Sucess;

            return result;
        }



        /// <summary>
        /// //////////////  FINAL Will be soon ///////////////////
        /// </summary>
        /// <param name="NAOqiParameters"></param>
        /// <returns>NAOqi Call result object</returns>
        public ACall.structAcallResult callNaoqi(ACall.structNAOqiParameters NAOqiParameters)
        {
            ACall.structAcallResult result = new ACall.structAcallResult();
            string address;
            address = "tcp://" + NAOqiParameters.robotIP + ":+" + NAOqiParameters.port.ToString();
            var session = QiSession.Create(address);
            try
            {
                if (!session.IsConnected)
                {
                    result.ResultStatus = ACall.structAcallResult.Result.failure;
                    result.dateTime = DateTime.Now;
                    result.Message = "Not Connected";
                    return result;
                }
                var nAOQiService = session.GetService(NAOqiParameters.Service.ToString("F"));
                switch (NAOqiParameters.Service)
                {
                    case NAOqiServices.ALMemory:
                        break;
                    case NAOqiServices.ALTextToSpeech:

                        result.NAOqiObject = nAOQiService[NAOqiParameters.method].Call(NAOqiParameters.SingleParamValue);
                        result.Message = "called ALTextToSpeech Successfully";

                        break;
                    #region Motion Service
                    case NAOqiServices.ALMotion:
                        
                        QiList<QiString> names
                                    = QiList.Create(NAOqiParameters.names);
                        QiList<QiList<QiDouble>> angleLists = QiList.Create<QiList<QiDouble>>(new QiList<QiDouble>[] { QiList.Create(NAOqiParameters.AngleList[0]) });
                        for (int i = 1; i < NAOqiParameters.AngleList.Count(); i++)
                        {
                            angleLists.QiValue.AddElement(QiList.Create(NAOqiParameters.AngleList[i]).QiValue);
                        }
                        QiList<QiList<QiDouble>> timeLists = QiList.Create<QiList<QiDouble>>(new QiList<QiDouble>[] { QiList.Create(NAOqiParameters.timeLists[0]) });
                        for (int i = 1; i < NAOqiParameters.timeLists.Count(); i++)
                        {
                            timeLists.QiValue.AddElement(QiList.Create(NAOqiParameters.timeLists[i]).QiValue);
                        }
                       QiBool isAbsolute;
                        if (NAOqiParameters.isAbsolute)
                        {
  isAbsolute = new QiBool(true);
                        }
                        else
                        {
  isAbsolute = new QiBool(false);
                        }
                        result.NAOqiObject = nAOQiService["angleInterpolation"].Call(names, angleLists, timeLists, isAbsolute);
                        result.Message = "successfully called ALMotioin Service";

                        break;
                    #endregion Motion Service
                    default:
                        break;
                }

                result.dateTime = DateTime.Now;
             
                result.ResultStatus = ACall.structAcallResult.Result.Sucess;
                session.Close();
                session.Destroy();
                return result;
            }
            catch (Exception ex)
            {
                result.Message = "Error in call NAOqi, ex:" + ex.Message;
                result.dateTime = DateTime.Now;
                result.ResultStatus = ACall.structAcallResult.Result.failure;
                return result;
            }
        }

        ///////




        // public ACall.structAcallResult callNaoqi(ACall.structNAOqiParameters NAOqiParameters)
        //// parameters,string CallParametervalue, string ip = "127.0.0.1", int port = 9559, string Service = "ALTextToSpeech", string methodName = "say")
        // {
        //     ACall.structAcallResult result = new ACall.structAcallResult();
        //     try
        //     {
        //         QiString value = new QiString(NAOqiParameters.SingleMotorName);


        //         string address = "tcp://" + NAOqiParameters.robotIP + ":+" + NAOqiParameters.port.ToString();
        //         var session = QiSession.Create(address);
        //         Console.WriteLine($"Connected? {session.IsConnected}");
        //         if (!session.IsConnected)
        //         {
        //             result.ResultStatus = ACall.structAcallResult.Result.failure;
        //             result.Message = "end program because there is no connection";
        //             result.dateTime = DateTime.Now;
        //             result.NAOqiResult = -1;
        //             return result;
        //         }
        //         var tts = session.GetService(NAOqiParameters.Service);
        //         result.NAOqiObject = tts[NAOqiParameters.method].Call(value);

        //         session.Close();
        //         session.Destroy();

        //         result.ResultStatus = ACall.structAcallResult.Result.Sucess;
        //         result.Message = "Successfull called and excecuted the program on Robot";
        //         result.dateTime = DateTime.Now;
        //         result.NAOqiResult = 1;
        //         return result;
        //     }
        //     catch (Exception ex)
        //     {
        //         result.ResultStatus = ACall.structAcallResult.Result.failure;
        //         result.Message = "Exception on call function CallNaoqi , " + ex.Message;
        //         result.dateTime = DateTime.Now;
        //         result.NAOqiResult = -1;
        //         return result;
        //     }
        // }
    }
}
