using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using MessageService;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel.Configuration;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // zoek uit alle ips de default en gebruik deze voor de server
                IPHostEntry IPhost;
                string localIP = "";
                IPhost = Dns.GetHostEntry(Dns.GetHostName());
                localIP = IPhost.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();

                // creeer een host proces voor de TrafficMessageService
                ServiceHost host = new ServiceHost(typeof(CTrafficMessage));

                // creeer een zgn. end-point voor de service
                Type contract = typeof(ITrafficMessage);
                WSHttpBinding binding = new WSHttpBinding();
                //BasicHttpBinding binding = new BasicHttpBinding();
                string baseAddress = "http://" + localIP + ":8000";
                Uri address = new Uri(baseAddress + "/MessageService");
                host.AddServiceEndpoint(contract, binding, address);

                // creeer een zgn. mex endpoint om de wsdl van de service te hosten
                host.Description.Behaviors.Add(new ServiceMetadataBehavior());
                EndpointAddress endPointAddress = new EndpointAddress(baseAddress + "/MEX");
                ServiceEndpoint mexEndpoint = new ServiceMetadataEndpoint(endPointAddress);
                host.AddServiceEndpoint(mexEndpoint);

                // start de service
                host.Open();

                // hou het proces in de lucht tot de gebruiker op enter drukt
                Console.WriteLine("Service TrafficMessage successfully hosted at address: ");
                Console.WriteLine("http://" + localIP + ":8000/MEX");
                Console.WriteLine("\nPress <enter> to end the service...");
                Console.ReadLine();
            }
            catch (System.ServiceModel.AddressAccessDeniedException ex)
            {
                Console.WriteLine("Service failed to launch...");
                Console.WriteLine("Try running with admin permissions");
                Console.WriteLine("\nPress <enter> to end the program...");
                Console.ReadLine();
            }

            
        }

    }
}
