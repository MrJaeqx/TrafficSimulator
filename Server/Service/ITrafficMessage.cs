using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace MessageService
{
    [ServiceContract(Namespace = "MessageService")]
    public interface ITrafficMessage
    {
        [OperationContract]
        string GetServerName();

        [OperationContract]
        void SendRedLight(int carID, int trafficLightID, DateTime time);

        [OperationContract]
        void SendAccident(int junctionID, DateTime time);

        [OperationContract]
        void SendSpeeding(int carID, int carSpeed, DateTime time);

        [OperationContract]
        string RetrieveMessage();
    }
}
