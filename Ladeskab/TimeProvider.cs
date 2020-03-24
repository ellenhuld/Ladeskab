using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interface;

namespace Ladeskab
{
    public class TimeProvider : ITimeProvider
    {

        public string TimeStamp => System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    }
}
