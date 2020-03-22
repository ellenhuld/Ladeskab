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
    public class TestLadeskab
    {
        private  USBCharger _uut;
        private CurrentEventArgs _receivedEventArgs;
        //private  ICharge _charge;

        [SetUp]
        public void Setup()
        {
            _receivedEventArgs = null;

            //_charge = Substitute.For<ICharge>();
            _uut = new USBCharger();
            


            _uut.CurrentValueEvent += (o, args) =>
            {
                _receivedEventArgs = args;
            };
        }

        [Test]
        public void CurrentIsConnected()
        {
            Assert.That(() => _uut.Connected);

        }

        [Test]
        public void SetCurrent_CurrentIsDisconnect_EventFired()
        {
            _uut.StartCharge();
            Assert.That(_receivedEventArgs, Is.Not.Null);

        }

        [Test]
        public void SetCurrent_CurrentIsConnected_EventReceived()
        {
            _uut.StartCharge();
            Assert.That(_receivedEventArgs.Current, Is.EqualTo(500));

        }

    }
}
