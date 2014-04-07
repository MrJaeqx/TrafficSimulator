using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficSimulator
{
    public static class TrafficMessageSender
    {
        // Lijst met al gemelde te snelle roadusers
        private static List<double> speedingsID = new List<double>();

        // Lijst met al gemelde door rood gereden roadusers
        private static List<double> redlightID = new List<double>();

        /// <summary>
        /// Stuur ongeluk.
        /// </summary>
        /// <param name="junctionID">Kruispunt ID van de locatie van het ongeluk.</param>
        public static void SendAccident(int junctionID)
        {
            //new TrafficMessageService.TrafficMessageClient().SendAccident(junctionID, DateTime.Now);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stuur een rood licht overtreding.
        /// </summary>
        /// <param name="carID">ID van de auto.</param>
        /// <param name="trafficLightID">ID van het verkeerslicht.</param>
        public static void SendRedLight(double carID, int trafficLightID)
        {
            // Controleer of de auto al geregistreerd is
            if (!redlightID.Exists(x => x == carID))
            {
                redlightID.Add(carID);
                new TrafficMessageService.TrafficMessageClient().SendRedLight((int)carID, trafficLightID, DateTime.Now);
            }
        }

        /// <summary>
        /// Stuur een snelheidsovertreding
        /// </summary>
        /// <param name="carID">ID van de auto.</param>
        /// <param name="carSpeed">Snelheid van de auto.</param>
        public static void SendSpeeding(double carID, double carSpeed)
        {
            // Controleer of de auto al geregistreerd is
            if (!speedingsID.Exists(x => x == carID))
            {
                speedingsID.Add(carID);
                new TrafficMessageService.TrafficMessageClient().SendSpeeding((int)carID, (int)carSpeed, DateTime.Now);
            }
        }
    }
}
