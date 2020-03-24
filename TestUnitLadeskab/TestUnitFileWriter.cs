using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab;
using Ladeskab.Interface;
using NSubstitute;
using NUnit.Framework;

namespace TestUnitLadeskab
{
    [TestFixture]
    public class TestUnitFileWriter
    {
        private FileWriter _uut;
        private IFileWriter ifileWriter;
        private string _fileWriter;

        [SetUp]
        public void SetUp()
        {
            //ifileWriter = Substitute.For<IFileWriter>();
            //_uut = new FileWriter(_fileWriter);

            _uut = new FileWriter();

        }

        [Test]
        public void Test_WriteLine_InFile()
        {
            _uut.WriteLine("Writing in file"); //Arrance (input)
            Console.WriteLine($"System.IO.Directory.GetCurrentDirectory()"); //Act
            Assert.That("LogFile.txt", Does.Exist); //Assert
        }

    }
}
