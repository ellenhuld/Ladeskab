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
        }
    
}
