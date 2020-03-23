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

        [SetUp]
        public void SetUp()
        {
            _charge = Substitute.For<ICharge>();
            _uut = new ChargeControl(_charge);
        }

        [TestCase(500)]
        [TestCase(300)]
        [TestCase(100)]
        public void CurrentChanged_DifferentArguments_CurrentIsCorrect(double newCurrent)
        {
            _charge.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = newCurrent });
            Assert.That(_uut.CurrentCharge, Is.EqualTo(newCurrent));
        }

        [TestCase(500)]
        [TestCase(6)]
        [TestCase(255)]
        public void Regulate_StartChargeCalled(double currentCharge)
        {
            _uut.CurrentCharge = currentCharge;
            _uut.Regulate();
            _charge.Received().StartCharge();
        }

        [TestCase(501)]
        [TestCase(5)]
        [TestCase(-5)]
        public void Regulate_StopChargeCalled(double currentCharge)
        {
            _uut.CurrentCharge = currentCharge;
            _uut.Regulate();
            _charge.Received().StopCharge();
        }

        [Test]
        public void IsConnected_USBCharger_IsConnectedTrue()
        {
            _charge.Connected.Returns(true);
            Assert.That(_uut.IsConnected(), Is.EqualTo(true));
        }

        [Test]
        public void IsConnected_USBCharger_IsConnectedFalse()
        {
            _charge.Connected.Returns(false);
            Assert.That(_uut.IsConnected(), Is.EqualTo(false));
        }
    }
}
