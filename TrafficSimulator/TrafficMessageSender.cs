using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficSimulator
{
    public static class TrafficMessageSender
    {

        private static List<double> speedingsID = new List<double>();
        private static List<double> redlightID = new List<double>();

        public static void SendAccident(int junctionID)
        {
            new TrafficMessageService.TrafficMessageClient().SendAccident(junctionID, DateTime.Now);
        }

        public static void SendRedLight(double carID, int trafficLightID)
        {
            if (!redlightID.Exists(x => x == carID))
            {
                redlightID.Add(carID);
                new TrafficMessageService.TrafficMessageClient().SendRedLight((int)carID, trafficLightID, DateTime.Now);
            }
        }

        public static void SendSpeeding(double carID, double carSpeed)
        {
            if (!speedingsID.Exists(x => x == carID))
            {
                speedingsID.Add(carID);
                new TrafficMessageService.TrafficMessageClient().SendSpeeding((int)carID, (int)carSpeed, DateTime.Now);
            }
        }
    }
}
