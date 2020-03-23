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

        [SetUp]
        public void Setup()
        {
            _uut = new Display();
            _iDisplay = Substitute.For<IDisplay>();
        }

        [Test]
        public void Display_Message_Recived()
        {
            _iDisplay.DisplayMessage("Døren er låst op");
            _iDisplay.Received().DisplayMessage("Døren er låst op");
        }

        
    }
}
