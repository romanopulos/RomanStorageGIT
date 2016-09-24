using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AirPortRomanOOP
{
    class Loging
    {
        string logfile = "log.txt";
        public string LogFile
        {
            get
            {
                return logfile;
            }
        }
        string logmessagestart;
        string logmessageend;

        public void StartProgram()
        {
            logmessagestart = "The program starts at :";
            using (StreamWriter writer = new StreamWriter(LogFile, true, Encoding.UTF8))
            {
                writer.Write(logmessagestart+DateTime.Now);
            }
        }

        public void EndProgram()
        {
            logmessageend = " The program ends at :";
            using (StreamWriter writer = new StreamWriter(LogFile, true, Encoding.UTF8))
            {
                writer.WriteLine(logmessageend+DateTime.Now);
                writer.WriteLine();
            }
        }       
    }
}
