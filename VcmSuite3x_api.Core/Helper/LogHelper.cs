using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Configuration;
using log4net;
using log4net.Config;
using Newtonsoft.Json;

namespace VcmSuite3x_api.Core.Helper
{

    public class LogHelper
    {

        public static string _EmailAdm = ConfigurationManager.AppSettings["Email.Adm"];


        public LogHelper()
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("log4net.config"));
            var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            XmlConfigurator.Configure(repo, log4netConfig["log4net"]);

            this.Log = LogManager.GetLogger(typeof(LogHelper));
            //this.Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public ILog Log { get; set; }

        public void WriteLog(eFeedbackType type
            , string message    /**/
            , bool IsToWriteOnConsole = true
            , Guid? guid = null /**/
            , eApiCallerMethod? method = null /**/
            , Object obj = null
            , Exception ex = null
            , bool IsToSendEmail = false)
        {

            string guidString = guid.HasValue ? guid.ToString() : Guid.NewGuid().ToString();

            string startMessage = string.Format("[{0}] [{1}] [{2}]", type.ToString(), DateTime.Now.ToString("yyyyMMdd hh:mm:ss"), guidString);

            {
                string messageLog = string.Format("{0} {1}", startMessage, message);
                Log.Info(messageLog);
                if (IsToWriteOnConsole) { Console.WriteLine(messageLog); }
            }
            if (method.HasValue)
            {
                string messageLog = string.Format("{0} Method: {1}", startMessage, method.ToString());
                Log.Info(messageLog);
                if (IsToWriteOnConsole) { Console.WriteLine(messageLog); }
            }
            if (obj != null)
            {
                string messageLog = string.Format("{0} Object: {1}", startMessage, JsonConvert.SerializeObject(obj));
                Log.Info(messageLog);
                if (IsToWriteOnConsole) { Console.WriteLine(messageLog); }
            }
            if (ex != null && !string.IsNullOrEmpty(ex.Message))
            {
                string messageLog = string.Format("{0} exMessage: {1}", startMessage, ex.Message.ToString());
                Log.Info(messageLog);
                if (IsToWriteOnConsole) { Console.WriteLine(messageLog); }
            }
            if (ex != null && ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
            {
                string messageLog = string.Format("{0} exInnerException: {1}", startMessage, ex.InnerException.Message.ToString());
                Log.Info(messageLog);
                if (IsToWriteOnConsole) { Console.WriteLine(messageLog); }
            }
            if (IsToSendEmail)
            {
                string messageLog = string.Format("{0} Email Error Sent to: {1}", startMessage, _EmailAdm);
                Log.Info(messageLog);
                if (IsToWriteOnConsole) { Console.WriteLine(messageLog); }
            }
            {
                string messageLog = string.Format("->");
                Log.Info(messageLog);
                if (IsToWriteOnConsole) { Console.WriteLine(messageLog); }
            }
        }


        //if (IsToSendEmail)
        //{
        //    string body = string.Format("Mensagem: {0}{1}", message
        //                                                  , hasException ? string.Format(" || {0}", ex.Message) : string.Empty);

        //    SendMail sendEmail = new SendMail(_EmailAdm, "[CiiRUS Automation - Error]", body);

        //    sendEmail.SendEmailAsync(Convert.ToInt32(EEmailType.Admin));
        //}
    }

}
