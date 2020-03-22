using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Interface
{
    public class ReadtagChangedEventArgs : EventArgs
    {
        public int Tag { get; set; }
    }
    public interface IReader
    {
        event EventHandler<ReadtagChangedEventArgs> TagDataEvent;
    }
}
