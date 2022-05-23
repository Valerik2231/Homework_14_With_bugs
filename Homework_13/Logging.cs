using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_13
{
    internal static class Logging
    {
        public static string NameUser;
        //static event Action<string> Log;
        static Logging()
        {
            BankAccount.Notification += Log;
        }

        public static void Log(string Mesage)
        {
            string writeLog = DateTime.Now.ToString();
            writeLog += "    " + NameUser + "     " + Mesage;
            if (!File.Exists("Log.txt"))
            {
                File.Create("Log.txt");
            }
            using(StreamWriter sw = File.AppendText("Log.txt"))
            {
                sw.WriteLine(writeLog);
            }
        }


    }
}
