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

            //itimeProvider = Substitute.For<ITimeProvider>();
            _uut = new TimeProvider();

        }

        [Test]
        public void TestDateTime()
        {
            //Test input hvor jeg får timestamp fra system og sammenligner med _uut timestamp
            Assert.That(_uut.TimeStamp, Is.EqualTo(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

            //_uut.TimeStamp
            //itimeProvider.TimeStamp.Returns(new DateTime("2010, 3, 11, 22,30,50"));
            
        }
    }

}
