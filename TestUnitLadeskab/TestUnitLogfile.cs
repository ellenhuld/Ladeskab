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
        private IReader ireader;
        private IFileWriter ifilewriter;
        private ITimeProvider itimeProvider;


        [SetUp]
        public void SetUp()
        {
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
    }
}
