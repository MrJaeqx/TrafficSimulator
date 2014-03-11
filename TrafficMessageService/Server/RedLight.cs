using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    class RedLight
    {

        public int carID { get; private set; }
        public int trafficLightID { get; private set; }
        public DateTime time { get; private set; }

        // constructor, defineert alle variabelen
        public RedLight(int carID, int trafficLightID, DateTime time)
        {
            this.carID = carID;
            this.trafficLightID = trafficLightID;
            this.time = time;
        }

        // maakt een leesbare string van de tijd
        public string timeToString()
        {
            return time.ToString("dd-mm-yyyy HH:mm:ss");
        }

        // maakt een leesbare string van alle data
        override
        public String ToString() {
            return Convert.ToString(carID) + " - " + Convert.ToString(trafficLightID) + " - " + time.ToLongTimeString();
        }
    }
}
