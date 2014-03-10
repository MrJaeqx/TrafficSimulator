using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TrafficMessageReceiver
{
    class Data
    {
        // proxy om de TrafficMessageService te gebruiken
        private TrafficMessageService.TrafficMessageClient myTrafficMessageProxy;

        // lists met de data per type
        private List<Accident> accidentList;
        private List<RedLight> redLightList;
        private List<Speeding> speedingList;

        public string ServerName { get; private set; }

        Data(string serverIP, string serverPort)
        {
            myTrafficMessageProxy = new TrafficMessageReceiver.TrafficMessageService.TrafficMessageClient();
            myTrafficMessageProxy.Endpoint.Address = new System.ServiceModel.EndpointAddress("http://" + serverIP + ":" + serverPort + "/MEX");

            accidentList = new List<Accident>();
            redLightList = new List<RedLight>();
            speedingList = new List<Speeding>();

            ServerName = myTrafficMessageProxy.GetServerName();
        }

        public List<Accident> GetAccidents()
        {
            UpdateDataLists();
            return accidentList;
        }

        public List<RedLight> GetRedLights()
        {
            UpdateDataLists();
            return redLightList;
        }

        public List<Speeding> GetSpeedings()
        {
            UpdateDataLists();
            return speedingList;
        }

        public void SaveXML()
        {

        }

        private void UpdateDataLists()
        {
            string xml = myTrafficMessageProxy.RetrieveMessage();

        }


    }
}
