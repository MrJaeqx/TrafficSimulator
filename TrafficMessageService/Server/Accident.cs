using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    class Accident
    {
        public int junctionID { get; private set; }
        public DateTime time { get; private set; }

        // constructor, defineert alle variabelen
        public Accident(int junctionID, DateTime time)
        {
            this.junctionID = junctionID;
            this.time = time;
        }

        // maakt een leesbare string van de tijd
        public string timeToString()
        {
            return time.ToLongTimeString();
        }
        // maakt een leesbare string van alle data
        override
        public String ToString() {
            return Convert.ToString(junctionID) + " - " + time.ToLongTimeString();
        }
    }
}
