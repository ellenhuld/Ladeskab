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
        private Door _door;

        [SetUp]
        public void Setup()
        {
            _uut = new Display();
            _door = new Door();
        }

        //[TestCase("Døren er låst")]
        //public void Display_Message_Recived_LockDoor(string input)
        //{  
        //    string s1 = _door.LockDoor();
        //    Assert.That(input, Is.EqualTo(s1));
        //}
        
        //[TestCase("Døren er låst op")]
        //public void Display_Message_Recived_UnlockDoor(string input)
        //{
        //    string s1 = _door.UnlockDoor();
        //    Assert.That(input, Is.EqualTo(s1));
        //}
    }
}
