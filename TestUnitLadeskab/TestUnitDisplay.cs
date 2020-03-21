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
        private IDisplay _display;

        [SetUp]
        public void Setup()
        {
            _uut = new Display();
            _display = Substitute.For<IDisplay>();
        }

        [Test]

    }
}
