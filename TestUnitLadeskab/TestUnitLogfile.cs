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
    public class TestUnitLogfile
    {
        private LogFile _uut;
        //private ILogfile iLogfile;
        //private IChargeControl ichargeControl;
        private IReader ireader;
        private IFileWriter ifilewriter;
        private ITimeProvider itimeProvider;


        [SetUp]
        public void SetUp()
        {
            //iLogfile = Substitute.For<ILogfile>();
            //ichargeControl = Substitute.For<IChargeControl>();
            //ireader = Substitute.For<IReader>();
            ifilewriter = Substitute.For<IFileWriter>();
            itimeProvider = Substitute.For<ITimeProvider>();

            _uut = new LogFile(ifilewriter, itimeProvider);

        }

        [Test]
        public void LogMessage_FileWriter()
        {
            _uut.LogMessage("Log to file");
            ifilewriter.Received().WriteLine(Arg.Any<string>());
        }

        [Test]
        public void LogMessage_TimeProvider()
        {
            _uut.LogMessage("Log to file");
            _ = itimeProvider.Received().TimeStamp;
        }




        //    [TestCase(1594)]
        //    [TestCase(0)]
        //    [TestCase(7)]
        //    public void Available_LogFile_LogDoorLockedCalled(int id)
        //    {
        //        ichargeControl.IsConnected().Returns(true);
        //        ireader.TagDataEvent += Raise.EventWith(new ReadtagChangedEventArgs { Tag = id });
        //        iLogfile.Received().LogDoorLocked(id);

        //    }

        //    [TestCase(-10)]
        //    [TestCase(0)]
        //    [TestCase(23)]
        //    public void Locked_LogFile_LogDoorUnlockCalled(int id)
        //    {
        //        ichargeControl.IsConnected().Returns(true);
        //        ireader.TagDataEvent += Raise.EventWith(new ReadtagChangedEventArgs { Tag = id });
        //        ireader.TagDataEvent += Raise.EventWith(new ReadtagChangedEventArgs { Tag = id });

        //        iLogfile.Received().LogDoorUnlocked(id);
        //    }
        //}
    }
}
