using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interface;

namespace Ladeskab
{

        public class LogFile : ILogfile
        {
            private string logFile = "logfile.txt"; // Navnet på systemets log-fil

            private IFileWriter _fileWriter;
            private ITimeProvider _provider;

            //constuctor injection
            public LogFile(IFileWriter fileWriter, ITimeProvider provider )
            {
                _fileWriter = fileWriter;
                _provider = provider;

            }

            public void LogMessage(string message)
            {
                _fileWriter.WriteLine($"{_provider.TimeStamp}:{message}");
            }

            //public void LogDoorLocked(int id)
            //{
            //    using (var writer = File.AppendText(logFile))
            //    {
            //        writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", id);
            //    }
            //}

            //public void LogDoorUnlocked(int id)
            //{
            //    using (var writer = File.AppendText(logFile))
            //    {
            //        writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", id);
            //    }

            //}

        }
    
}
