using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBulgarianBot.Business
{
    public class EventData<T>
    {
        public EventData(object client, T eventArgs)
        {
            this.Client = client;
            this.EventArgs = eventArgs;
        }

        public object Client { get; }

        public T EventArgs { get; }
    }
}
