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

        public string ServerName { get; private set; }

        Data(string serverIP, string serverPort)
        {
            myTrafficMessageProxy = new TrafficMessageReceiver.TrafficMessageService.TrafficMessageClient();
            myTrafficMessageProxy.Endpoint.Address = new System.ServiceModel.EndpointAddress("http://" + serverIP + ":" + serverPort + "/MEX");

            ServerName = myTrafficMessageProxy.GetServerName();
        }


    }
}
