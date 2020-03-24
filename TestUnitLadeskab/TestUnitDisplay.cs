using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interface;
using Ladeskab;
using NSubstitute;
using NUnit.Framework;
using TestUnitLadeskab.FakeClasses;

namespace TestUnitLadeskab
{
    [TestFixture]
    public class TestUnitDisplay
    {
        private Display _uut;
        private IDisplay _iDisplay;
        private IConsoleWrite _iWrite;

        [SetUp]
        public void Setup()
        {
            _iWrite = Substitute.For<IConsoleWrite>();
            _uut = new Display(_iWrite);
            //_iDisplay = Substitute.For<IDisplay>();
            
        }
         
        [Test]
        public void Display_Message_Recived()
        {

            _uut.DisplayMessage("Døren er låst op");
            _iWrite.Received(1).WriteLine(Arg.Is<string>(s=> s.Contains($"Døren er låst op")));
            //_iWrite.Received().WriteLine(Arg.Any<string>());
        }

        
    }
}
