using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab;
using Ladeskab.Interface;
using NSubstitute;
using NUnit.Framework;

namespace TestUnitLadeskab
{
    [TestFixture]
    public class TestUnitTimeProvider
    {
        private TimeProvider _uut;
        private ITimeProvider itimeProvider;


        [SetUp]
        public void SetUp()
        {
            _uut = new TimeProvider();
        }

        [Test]
        public void TestDateTime()
        {
            //Test input hvor jeg får timestamp fra system og sammenligner med _uut timestamp
            Assert.That(_uut.TimeStamp, Is.EqualTo(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
        }
    }

}
