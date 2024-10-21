using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    public class Event

    {
        private string eventName;
        private string location;

        public Event(string eventName, string location)
        {
            this.eventName = eventName;
            this.location = location;
        }

        public string EventName
        {
            get { return eventName; }
            set { eventName = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

    }
}
