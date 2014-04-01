using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficSimulator
{
    public static class TrafficMessageSender
    {

        public static void SendAccident(int junctionID)
        {
            new TrafficMessageService.TrafficMessageClient().SendAccident(junctionID, DateTime.Now);
        }

        public static void SendRedLight(int carID, int trafficLightID)
        {
            new TrafficMessageService.TrafficMessageClient().SendRedLight(carID, trafficLightID, DateTime.Now);
        }

        public static void SendSpeeding(int carID, int carSpeed)
        {
            new TrafficMessageService.TrafficMessageClient().SendSpeeding(carID, carSpeed, DateTime.Now);
        }
    }
}
