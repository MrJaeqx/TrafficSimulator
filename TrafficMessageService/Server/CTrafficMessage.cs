using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessageService;
using System.ServiceModel;
using System.Xml;
using System.IO;

namespace Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CTrafficMessage : ITrafficMessage
    {
        // de lists met de classes waarin de data gestored wordt
        private List<RedLight> redLightMessages;
        private List<Accident> accidentMessages;
        private List<Speeding> speedingMessages;

        // constructor
        CTrafficMessage()
        {
            redLightMessages = new List<RedLight>();
            accidentMessages = new List<Accident>();
            speedingMessages = new List<Speeding>();

            // Dummy data
            redLightMessages.Add(new RedLight(1, 404, new DateTime(2014, 5, 21)));
            redLightMessages.Add(new RedLight(2, 200, new DateTime(2013, 5, 21)));
            redLightMessages.Add(new RedLight(3, 503, new DateTime(2012, 5, 21)));
            accidentMessages.Add(new Accident(1, new DateTime(2012, 5, 21)));
            accidentMessages.Add(new Accident(2, new DateTime(2012, 5, 21)));
            accidentMessages.Add(new Accident(3, new DateTime(2012, 5, 21)));
            speedingMessages.Add(new Speeding(1, 500, new DateTime(2012, 5, 21)));
            speedingMessages.Add(new Speeding(2, 800, new DateTime(2012, 5, 21)));
            speedingMessages.Add(new Speeding(3, 200, new DateTime(2012, 5, 21)));
        }

        // returnt de naam van de server
        public string GetServerName()
        {
            return "TrafficMessageServer";
        }

        // slaat een bericht over rood licht op
        public void SendRedLight(int carID, int trafficLightID, DateTime time)
        {
            redLightMessages.Add(new RedLight(carID, trafficLightID, time));
        }

        // slaat een bericht over een ongeluk op
        public void SendAccident(int junctionID, DateTime time)
        {
            accidentMessages.Add(new Accident(junctionID, time));
        }

        // slaat een bericht over te hard rijden op
        public void SendSpeeding(int carID, int carSpeed, DateTime time)
        {
            speedingMessages.Add(new Speeding(carID, carSpeed, time));
        }

        // stuur alle data in xml formaat naar de politie
        public string RetrieveMessage()
        {
            var stringWriter = new StringWriter();
            var xmlTextWriter = XmlWriter.Create(stringWriter);

            CreateXML().WriteTo(xmlTextWriter);
            xmlTextWriter.Flush();

            string str = stringWriter.GetStringBuilder().ToString();

            return str;

        }

        // Maak de Xml aan voor de politie
        private XmlDocument CreateXML()
        {
            XmlDocument XmlData = new XmlDocument();

            // Main element
            XmlElement TrafficData = XmlData.CreateElement("", "trafficdata", "");
            XmlData.AppendChild(TrafficData);

            // RedLight elements
            XmlElement RedLightParent = XmlData.CreateElement("", "redlights", "");
            TrafficData.AppendChild(RedLightParent);

            foreach(RedLight item in redLightMessages) {
                XmlElement RedLightData = XmlData.CreateElement("", "redlight", "");
                RedLightParent.AppendChild(RedLightData);

                XmlElement  RedLightDataCar         = XmlData.CreateElement("", "car_id", "");
                XmlText     RedLightDataCarText     = XmlData.CreateTextNode(Convert.ToString(item.carID));
                XmlElement  RedLightDataLight       = XmlData.CreateElement("", "trafficlight_id", "");
                XmlText     RedLightDataLightText   = XmlData.CreateTextNode(Convert.ToString(item.trafficLightID));
                XmlElement  RedLightDataTime        = XmlData.CreateElement("", "time", "");
                XmlText     RedLightDataTimeText    = XmlData.CreateTextNode(item.timeToString());

                RedLightDataCar.AppendChild(RedLightDataCarText);
                RedLightDataLight.AppendChild(RedLightDataLightText);
                RedLightDataTime.AppendChild(RedLightDataTimeText);

                RedLightData.AppendChild(RedLightDataCar);
                RedLightData.AppendChild(RedLightDataLight);
                RedLightData.AppendChild(RedLightDataTime);
            }

            // Accident elements
            XmlElement AccidentParent = XmlData.CreateElement("", "accidents", "");
            TrafficData.AppendChild(AccidentParent);

            foreach (Accident item in accidentMessages)
            {
                XmlElement AccidentData = XmlData.CreateElement("", "accident", "");
                AccidentParent.AppendChild(AccidentData);

                XmlElement  AccidentDataJunction        = XmlData.CreateElement("", "junction_id", "");
                XmlText     AccidentDataJunctionText    = XmlData.CreateTextNode(Convert.ToString(item.junctionID));
                XmlElement  AccidentDataTime            = XmlData.CreateElement("", "time", "");
                XmlText     AccidentDataTimeText        = XmlData.CreateTextNode(item.timeToString());

                AccidentDataJunction.AppendChild(AccidentDataJunctionText);
                AccidentDataTime.AppendChild(AccidentDataTimeText);

                AccidentData.AppendChild(AccidentDataJunction);
                AccidentData.AppendChild(AccidentDataTime);
            }

            // Speeding elements
            XmlElement SpeedingParent = XmlData.CreateElement("", "speedings", "");
            TrafficData.AppendChild(SpeedingParent);

            foreach (Speeding item in speedingMessages)
            {
                XmlElement SpeedingData = XmlData.CreateElement("", "speeding", "");
                SpeedingParent.AppendChild(SpeedingData);

                XmlElement  SpeedingDataCar         = XmlData.CreateElement("", "car_id", "");
                XmlText     SpeedingDataCarText     = XmlData.CreateTextNode(Convert.ToString(item.carID));
                XmlElement  SpeedingDataSpeed       = XmlData.CreateElement("", "trafficlight_id", "");
                XmlText     SpeedingDataSpeedText   = XmlData.CreateTextNode(Convert.ToString(item.carSpeed));
                XmlElement  SpeedingDataTime        = XmlData.CreateElement("", "time", "");
                XmlText     SpeedingDataTimeText    = XmlData.CreateTextNode(item.timeToString());

                SpeedingDataCar.AppendChild(SpeedingDataCarText);
                SpeedingDataSpeed.AppendChild(SpeedingDataSpeedText);
                SpeedingDataTime.AppendChild(SpeedingDataTimeText);

                SpeedingData.AppendChild(SpeedingDataCar);
                SpeedingData.AppendChild(SpeedingDataSpeed);
                SpeedingData.AppendChild(SpeedingDataTime);
            }

            return XmlData;
        }
    }
}
