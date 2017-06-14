using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace TraceabilityConnector
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
          
            string mutexId = $"Global\\{{{AppGuid()}}}";
            bool createdNew;         
            var allowEveryoneRule =
                new MutexAccessRule(
                    new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                    MutexRights.FullControl, AccessControlType.Allow);
            var securitySettings = new MutexSecurity();
            securitySettings.AddAccessRule(allowEveryoneRule);

         
            using (var mutex = new Mutex(false, mutexId, out createdNew, securitySettings))
            {
                        var hasHandle = mutex.WaitOne(1000, false);
                if (!hasHandle)
                {
                    MessageBox.Show(@"Aplikasi sudah berjalan. Check di tray icon!");
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new TraceabilityConnector(false));
                }



                if (hasHandle)
                        mutex.ReleaseMutex();
                
            }
        }

        private static string AppGuid()
        {
            string path = @"unique.dot";
            var guid = "";
            if (!File.Exists(path))
            {
               // File.Create(path);
                TextWriter tw = new StreamWriter(path,false);
                guid = Guid.NewGuid().ToString();
                tw.WriteLine(guid);
                tw.Close();
            }
            else
            {
                using (var tw = new StreamReader(path, true))
                {
                    guid = tw.ReadLine();
                    tw.Close();
                }
            }
            return guid?.ToUpper();
        }
    }
}
