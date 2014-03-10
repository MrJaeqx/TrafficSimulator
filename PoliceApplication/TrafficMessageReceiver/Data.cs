using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TrafficMessageReceiver
{
    /// <summary>
    /// Deze class haalt alle data van de server.
    /// </summary>
    class Data
    {
        /// <summary>Proxy om de TrafficMessageService te gebruiken.</summary>
        private TrafficMessageService.TrafficMessageClient myTrafficMessageProxy;

        /// <summary>Lists met de ongelukken</summary>
        private List<Accident> accidentList;
        /// <summary>Lists met de rood licht overtredingen</summary>
        private List<RedLight> redLightList;
        /// <summary>Lists met de snelheidsovertredingen</summary>
        private List<Speeding> speedingList;

        /// <summary>Servernaam</summary>
        public string ServerName { get; private set; }

        /// <summary>Constructor</summary>
        /// <param name="serverIP">Een string die het ip van de server bevat</param>
        /// <param name="serverPort">Een string die de poort van de server bevat</param>
        public Data(string serverIP, string serverPort)
        {
            // maak de connectie met de server
            myTrafficMessageProxy = new TrafficMessageReceiver.TrafficMessageService.TrafficMessageClient();
            myTrafficMessageProxy.Endpoint.Address = new System.ServiceModel.EndpointAddress("http://" + serverIP + ":" + serverPort + "/MEX");

            // initaliseer de lists
            accidentList = new List<Accident>();
            redLightList = new List<RedLight>();
            speedingList = new List<Speeding>();

            // set de servername property
            ServerName = myTrafficMessageProxy.GetServerName();
        }

        /// <summary>Update de list en return de ongelukken</summary>
        /// <returns>Returnt een List met Accident objecten</returns>
        public List<Accident> GetAccidents()
        {
            UpdateDataLists();
            return accidentList;
        }

        /// <summary>Update de list en return de rood licht overtredingen</summary>
        /// <returns>Returnt een List met RedLight objecten</returns>
        public List<RedLight> GetRedLights()
        {
            UpdateDataLists();
            return redLightList;
        }

        /// <summary>Update de list en return de snelheidsovertredingen</summary>
        /// <returns>Returnt een List met Speeding objecten</returns>
        public List<Speeding> GetSpeedings()
        {
            UpdateDataLists();
            return speedingList;
        }

        /// <summary>Sla de XML op in een bestand</summary>
        /// <param name="filePath">Een string die het bestandspad bevat</param>
        public void SaveXML(string filePath)
        {
            // haal de xml van de server
            string XmlString = myTrafficMessageProxy.RetrieveMessage();
            XmlDocument XmlData = new XmlDocument();

            // sla de xml op 
            XmlData.Save(filePath);
        }

        /// <summary>Haal de data van de server en update de lists</summary>
        private void UpdateDataLists()
        {
            // haal de xml van de server
            string XmlString = myTrafficMessageProxy.RetrieveMessage();
            XmlDocument XmlData = new XmlDocument();
            XmlData.LoadXml(XmlString);

            // Haal alle rood lichten uit de xml
            XmlNodeList RedLights = XmlData.GetElementsByTagName("redlights");

            foreach (XmlNodeList RedLight in RedLights)
            {
                int carID = Convert.ToInt32(RedLight[0].InnerText);
                int trafficlightID = Convert.ToInt32(RedLight[1].InnerText);

                string[] timeComponents = RedLight[2].InnerText.Split();
                DateTime time = new DateTime(Convert.ToInt32(timeComponents[0]), Convert.ToInt32(timeComponents[1]), Convert.ToInt32(timeComponents[2]));

                redLightList.Add(new RedLight(carID, trafficlightID, time));
            }

            // Haal alle ongelukken uit de xml
            XmlNodeList Accidents = XmlData.GetElementsByTagName("accidents");

            foreach (XmlNodeList Accident in Accidents)
            {
                int carID = Convert.ToInt32(Accident[0].InnerText);
                int trafficlightID = Convert.ToInt32(Accident[1].InnerText);

                string[] timeComponents = Accident[2].InnerText.Split();
                DateTime time = new DateTime(Convert.ToInt32(timeComponents[0]), Convert.ToInt32(timeComponents[1]), Convert.ToInt32(timeComponents[2]));

                redLightList.Add(new RedLight(carID, trafficlightID, time));
            }

            // Haal alle snelheidsovertredingen uit de xml
            XmlNodeList Speedings = XmlData.GetElementsByTagName("speedings");

            foreach (XmlNodeList Speeding in Speedings)
            {
                int carID = Convert.ToInt32(Speeding[0].InnerText);
                int trafficlightID = Convert.ToInt32(Speeding[1].InnerText);

                string[] timeComponents = Speeding[2].InnerText.Split();
                DateTime time = new DateTime(Convert.ToInt32(timeComponents[0]), Convert.ToInt32(timeComponents[1]), Convert.ToInt32(timeComponents[2]));

                redLightList.Add(new RedLight(carID, trafficlightID, time));
            }
        }
    }
}
