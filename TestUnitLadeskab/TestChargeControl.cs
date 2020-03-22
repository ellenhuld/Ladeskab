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

namespace TestUnitLadeskab
{
    [TestFixture]
    class TestChargeControl
    {
        private ChargeControl _uut;
        private ICharge _charge;
        private int threshold;

        [SetUp]
        public void SetUp()
        {
            _charge = Substitute.For<ICharge>();
            _uut = new ChargeControl(threshold, _charge);
        }

        [TestCase(500)]
        [TestCase(300)]
        [TestCase(100)]
        public void CurrentChanged_DifferentArguments_CurrentIsCorrect(double newCurrent)
        {
            _charge.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = newCurrent });
            Assert.That(_uut.CurrentCharge, Is.EqualTo(newCurrent));
        }



    }
}
