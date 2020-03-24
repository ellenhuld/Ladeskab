using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interface;

namespace Ladeskab
{
    public class FileWriter : IFileWriter
    {
        //private string _fileWriter;
        //private IFileWriter _fileWriter;

        
        //public FileWriter(IFileWriter fileWriter)
        public FileWriter()
        {
            //_fileWriter = fileWriter;
        }

        public void WriteLine(string line)
        {
            using (var writer = File.AppendText("Logfile.txt"))
            {
                writer.WriteLine(line);
            }
        }
    }
}
