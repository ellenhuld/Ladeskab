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
        private string _fileWriter;

        public FileWriter(string fileWriter)
        {
            _fileWriter = fileWriter;
        }

        public void WriteLine(string line)
        {
            using (var writer = File.AppendText(_fileWriter))
            {
                writer.WriteLine(line);
            }
        }
    }
}
