using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab;
using Ladeskab.Interface;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TestUnitLadeskab.FakeClasses;

namespace TestUnitLadeskab
{
    [TestFixture]
    class TestUnitChargeControl
    {
        private ChargeControl _uut;
        private ICharge _charge;
        private USBCharger _usbcharger;

        [SetUp]
        public void SetUp()
        {
            _charge = Substitute.For<ICharge>();
            _uut = new ChargeControl(_charge);
            _usbcharger = new USBCharger();
        }

        [TestCase(500)]
        [TestCase(300)]
        [TestCase(100)]
        public void CurrentChanged_DifferentArguments_CurrentIsCorrect(double newCurrent)
        {
            _charge.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = newCurrent });
            Assert.That(_uut.CurrentCharge, Is.EqualTo(newCurrent));
        }

        //[TestCase(500)]
        //[TestCase(2)]
        //[TestCase(0.0)]
        //public void Regulate_StartCharge_IsTrue()
        //{
        //    double current = _charge.StartCharge();
        //    Assert.That(_charge.StartCharge, Is.EqualTo(current));

        //}


        //[Test]
        //public void Regulate_StopCharge_IsFalse(int current, int threshold)
        //{
            
        //    Assert.That(_uut.Regulate(), Is.EqualTo(_charge.StopCharge()));
        //}

        //[Test]
        //public void Regulate_StopCharge_IsFalse()
        //{
        //    _charge.StopCharge();
        //    Assert.That(Stop, Is.Not.Null);
        //}


        [Test]
        public void IsConnected_USBCharger_IsConnectedTrue()
        {
            _usbcharger.SimulateConnected(true);
            Assert.That(_uut.IsConnected(), Is.EqualTo(true));
        }

        [Test]
        public void IsConnected_USBCharger_IsConnectedFalse()
        {
            _usbcharger.SimulateConnected(false);
            Assert.That(_uut.IsConnected(), Is.EqualTo(false));
        }
    }
}
