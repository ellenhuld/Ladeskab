using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interface;

namespace Ladeskab
{
    public class RFIDReader : IReader
    {
        private int _oldid;
        public event EventHandler<ReadtagChangedEventArgs> TagDataEvent;
        
        public void Readtag(int id)
        {
            ReadtagChanged(new ReadtagChangedEventArgs { tag = id });
            _oldid = id;
        }
        protected virtual void ReadtagChanged(ReadtagChangedEventArgs e)
        {
            TagDataEvent?.Invoke(this, e);
        }
    }
}
