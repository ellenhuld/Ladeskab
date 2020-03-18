using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interface;
using Ladeskab;
using NSubstitute;
using NUnit.Framework;

namespace TestUnitLadeskab
{
    [TestFixture]
    public class TestLedeskab
    {
        private  USBCharger _uut;
        private ICharge _charge;

        [SetUp]
        public void Setup()
        {
            _uut = new USBCharger();
            _charge = Substitute.For<ICharge>();
        }

        [Test]
        public void CurrentIsConnected()
        {
            Assert.That(() => _uut.Connected);

        }
        
    }
}
