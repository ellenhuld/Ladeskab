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
    public class TestUnitRFIDReader
    {
        private RFIDReader _uut;
        private ReadtagChangedEventArgs _receivedEventArgs;

        [SetUp]
        public void Setup()
        {
            _receivedEventArgs = null;

            _uut = new RFIDReader();

            _uut.TagDataEvent += (o, args) =>
            {
                _receivedEventArgs = args;
            };
        }

        [Test]
        public void Readtag_ReadtagToNewValue_EventHappens()
        {
            _uut.Readtag(23);
            Assert.That(_receivedEventArgs, Is.Not.Null);
        }
    }
}
