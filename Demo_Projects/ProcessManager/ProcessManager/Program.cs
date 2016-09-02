using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;

namespace ProcessManager
{
    class Program
    {
        private static readonly log4net.ILog log =
         log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static int expirationTime = Convert.ToInt32(ConfigurationSettings.AppSettings["ExpirationTimeLimitMinutes"]);
        static bool debugMode = Convert.ToBoolean(ConfigurationSettings.AppSettings["DebugMode"]);
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Starting Run at " + DateTime.Now);
            string[] nameOfProcesses = ConfigurationSettings.AppSettings["ProcessName"].ToLower().Split(';');

            Process[] processList = Process.GetProcesses();

            foreach (Process theprocess in processList)
            {
                if (nameOfProcesses.Any(theprocess.ProcessName.ToLower().Contains))
                {
                    if (!debugMode)
                    {
                        log.Info("Process: " + theprocess.ProcessName + " ID: " + theprocess.Id + " Start Time: " + theprocess.StartTime);
                    }
                    else
                    {
                        log.Debug("(DEBUG) Process: " + theprocess.ProcessName + " ID: " + theprocess.Id + " Start Time: " + theprocess.StartTime);
                    }

                    int minutes = (DateTime.Now - theprocess.StartTime).Minutes;

                    if (minutes >= expirationTime)
                    {
                        if (!debugMode)
                        {
                            log.Info("Killing Process: " + theprocess.ProcessName + " Running For: " + minutes + " Minutes");
                            theprocess.Kill();
                        }
                        else
                        {
                            log.Debug("(DEBUG) Process: " + theprocess.ProcessName + " Running For: " + minutes + " Minutes");
                        }
                    }


                }
            }
            log.Info("Ending Run at " + DateTime.Now);
            Console.ReadKey();

        }
    }
}
