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
    public class TestUnitStationControl
    {
        private StationControl _uut;
        private IChargeControl _iChargeControl;
        private IDoor _iDoor;
        private IReader _iReader;
        private IDisplay _iDisplay;

        [SetUp]
        public void SetUp()
        {
            _iChargeControl = Substitute.For<IChargeControl>();
            _iDoor = Substitute.For<IDoor> ();
            _iReader = Substitute.For<IReader>();
            _iDisplay = Substitute.For<IDisplay>();
            _uut = new StationControl(_iReader, _iDoor, _iDisplay, _iChargeControl);

        }

        [Test]
        public void DoorOpenEventTest()
        {
            _iDoor.DoorOpenEvent += Raise.EventWith(new DoorOpenChangedEventArgs());
            _iDisplay.Received().DisplayMessage("Tilslut telefon");
        }        
        
        [Test]
        public void DoorOpenMultipleEventTest()
        {
            _iDoor.DoorOpenEvent += Raise.EventWith(new DoorOpenChangedEventArgs());
            _iDoor.DoorOpenEvent += Raise.EventWith(new DoorOpenChangedEventArgs());
            _iDisplay.Received(1).DisplayMessage("Tilslut telefon");
        }

        [Test]
        public void DoorCloseEventWithStateOpenTest()
        {
            _iDoor.DoorOpenEvent += Raise.EventWith(new DoorOpenChangedEventArgs());
            _iDoor.DoorCloseEvent += Raise.EventWith(new DoorCloseChangedEventArgs());
            _iDisplay.Received().DisplayMessage("Indlæs RFID");
        }

        [Test]
        public void DoorCloseEventWithStateAvaliableTest()
        {
            _iDoor.DoorCloseEvent += Raise.EventWith(new DoorCloseChangedEventArgs());
            _iDisplay.DidNotReceive().DisplayMessage("Indlæs RFID");
        }

        [Test]
        public void InitialRfidTest_IsConnectedTrue()
        {
            var id = 12;
            _iChargeControl.IsConnected().Returns(true);
            _iReader.TagDataEvent += Raise.EventWith(new ReadtagChangedEventArgs() { Tag = id });
            _iDoor.Received().LockDoor();
            _iDisplay.Received().DisplayMessage("Døren er låst");
            _iChargeControl.Received().Regulate();
            _iDisplay.Received().DisplayMessage("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
        }

        [Test]
        public void InitialRfid_IsConnectedFalse()
        {
            var id = 12;
            _iChargeControl.IsConnected().Returns(false);
            _iReader.TagDataEvent += Raise.EventWith(new ReadtagChangedEventArgs() { Tag = id });
            _iDisplay.Received().DisplayMessage("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
        }
        
        [Test]
        public void InitialRfid_DoorOpened()
        {
            _iDoor.DoorOpenEvent += Raise.EventWith(new DoorOpenChangedEventArgs());
            var id = 12;
            _iReader.TagDataEvent += Raise.EventWith(new ReadtagChangedEventArgs() { Tag = id });
            _iDoor.DidNotReceive().LockDoor();
            _iDisplay.DidNotReceive().DisplayMessage("Døren er låst");
            _iChargeControl.DidNotReceive().Regulate();
        }

        [Test]
        public void InitialRfid_DoorLOcked_CorrectID()
        {
            var id = 12;
            _iChargeControl.IsConnected().Returns(true);
            _iReader.TagDataEvent += Raise.EventWith(new ReadtagChangedEventArgs() { Tag = id });
            _iReader.TagDataEvent += Raise.EventWith(new ReadtagChangedEventArgs() { Tag = id });
            _iChargeControl.Received().Regulate();
            _iDoor.Received().UnlockDoor();
            _iDisplay.Received().DisplayMessage("Døren er låst op");

            _iDisplay.Received().DisplayMessage("Tag din telefon ud af skabet og luk døren");
        }

        [Test]
        public void InitialRfid_DoorLOcked_WrongID()
        {
            var id = 12;
            _iChargeControl.IsConnected().Returns(true);
            _iReader.TagDataEvent += Raise.EventWith(new ReadtagChangedEventArgs() { Tag = id });
            _iReader.TagDataEvent += Raise.EventWith(new ReadtagChangedEventArgs() { Tag = 13 });
            _iDisplay.Received().DisplayMessage("Forkert RFID tag");
        }

        //[Test]
        //public void Test()
        //{


        //    _uut.DoorOpenEvent += (o, args) =>
        //    {
        //        _openEventArgs = args;
        //    };

        //    _uut.DoorCloseEvent += (o, args) =>
        //    {
        //        _closeEventArgs = args;
        //    };
        //    _iReader.TagDataEvent += (o, args) =>
        //    {
        //        //_iReaderEventArgs = args;
        //    };

        //    _iReader.TagDataEvent += (o, args) =>
        //    {
        //        var b = 2 + 2;
        //    };

        //}
    }
}
