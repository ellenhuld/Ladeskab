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
    public class TestUnitDoor
    {
        private Door _uut;
        private DoorOpenChangedEventArgs _openEventArgs;
        private DoorCloseChangedEventArgs _closeEventArgs;
        private IDoor _door;

        [SetUp]
        public void Setup()
        {
            _openEventArgs = null;
            _closeEventArgs = null;
            _door = Substitute.For<IDoor>();
            _uut = new Door();

            _uut.DoorCloseEvent += (o, args) =>
            {
                _closeEventArgs = args;
            };

            _uut.DoorOpenEvent += (o, args) =>
            {
                _openEventArgs = args;
            };
        }

        [Test]
        public void DoorOpen_IsDoorOpen_EventHappens()
        {
            _uut.DoorOpen();
            Assert.That(_openEventArgs._openstate, Is.EqualTo(true));
        }
        [Test]
        public void DoorClose_IsDoorOpen_EventHappens()
        {
            _uut.DoorClose();
            Assert.That(_closeEventArgs._closestate, Is.EqualTo(true));
        }

        //[TestCase(true)]
        //public void LockDoor_IsLocked(bool state)
        //{
            
        //    _door.Received(state);
        //    _uut.LockDoor();


        //}
        //[Test]
        //public void UnlockDoor_IsUnlocked()
        //{
        //    _uut.UnlockDoor();
        //    Assert.That(_uut.UnlockDoor(), Is.EqualTo());
        //}
    }
}
