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
    public class TestUnitConsoleWrite
    {
        private ConsoleWrite _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new ConsoleWrite();
        }

        [Test]

        public void WriteLine_ConsoleWrite_Input()
        {
            string message = "Console Write Test"; //bruges til test input
            _uut.WriteLine(message); //input (det er det her som er console write)
            Assert.That(message, Is.EqualTo(message));
        }
    }
}
