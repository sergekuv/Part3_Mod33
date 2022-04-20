using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;

namespace Part3_Mod33
{
    public class Logger : ILogger
    {
        string logDir, eventFile, errorFile;

        public Logger()
        {
            //  НАверное, стоит эти операции заветнуть в try/catch? Но куда выводить сообщение об ошибке, если возникне исключение?
            logDir = ConfigurationManager.AppSettings.Get("logDir");
            //if (string.IsNullOrEmpty(logDir))
            //{
            //    logDir = Directory.GetCurrentDirectory() + @"\Logs";
            //    Console.WriteLine("-empty-currentDir: " + logDir);
            //}

            Directory.CreateDirectory(logDir);
            DateTime dt = DateTime.Now;
            logDir += "\\" + DateTime.Now.ToString("yyyyMMddHHmmss");
            Directory.CreateDirectory(logDir);

            eventFile = logDir + "\\" + ConfigurationManager.AppSettings.Get("eventFile");
            errorFile = logDir + "\\" + ConfigurationManager.AppSettings.Get("errorFile");
        }
        public void WriteEvent(string eventMessage)
        {
            string message = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "\t" + eventMessage;
            File.AppendAllTextAsync(eventFile, message + Environment.NewLine);
            //Console.WriteLine(eventMessage);
        }

        public void WriteError(string errorMessage)
        {
            string message = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "\t" + errorMessage;
            File.AppendAllTextAsync(errorFile, message + Environment.NewLine);
            //Console.WriteLine(errorMessage);
        }
    }
}
