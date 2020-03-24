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


        public void WriteLine(string line)
        {
            using (var writer = File.AppendText("Logfile.txt"))
            {
                writer.WriteLine(line);
            }
        }
    }
}
