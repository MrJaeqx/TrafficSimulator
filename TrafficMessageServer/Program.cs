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
using System.Diagnostics;
using System.ComponentModel;
using System.Security.Principal;
using System.IO;
using System.Reflection;
using NetFwTypeLib;


namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!RunningAsAdmin())
            {
                RunAsAdmin(Environment.CurrentDirectory + "\\Server.exe");
            }
            else{

                try
                {
                    // zet poort 8000 open in de firewall
                    OpenPortFirewall(8000);

                    // zoek uit alle ips de default en gebruik deze voor de server
                    IPHostEntry IPhost;
                    string localIP = "";
                    IPhost = Dns.GetHostEntry(Dns.GetHostName());
                    localIP = IPhost.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();

                    // creeer een host proces voor de TrafficMessageService
                    ServiceHost host = new ServiceHost(typeof(CTrafficMessage));

                    // creeer een zgn. end-point voor de service
                    Type contract = typeof(ITrafficMessage);
                    //WSHttpBinding binding = new WSHttpBinding();
                    BasicHttpBinding binding = new BasicHttpBinding();
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

        private static void OpenPortFirewall(int port)
        {
            INetFwMgr icfMgr = null;
            try
            {
                Type TicfMgr = Type.GetTypeFromProgID("HNetCfg.FwMgr");
                icfMgr = (INetFwMgr)Activator.CreateInstance(TicfMgr);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Service failed to launch...");
                Console.WriteLine("We can't add a firewall rule");
                Console.WriteLine("\nPress <enter> to end the program...");
                Console.ReadLine();
            }

            try
            {
                INetFwProfile profile;
                INetFwOpenPort portClass;
                Type TportClass = Type.GetTypeFromProgID("HNetCfg.FWOpenPort");
                portClass = (INetFwOpenPort)Activator.CreateInstance(TportClass);

                // Get the current profile
                profile = icfMgr.LocalPolicy.CurrentProfile;

                // Set the port properties
                portClass.Scope = NetFwTypeLib.NET_FW_SCOPE_.NET_FW_SCOPE_ALL;
                portClass.Enabled = true;
                portClass.Protocol = NetFwTypeLib.NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                portClass.Name = "TrafficSimulatorServer";
                portClass.Port = port;

                // Add the port to the ICF Permissions List
                profile.GloballyOpenPorts.Add(portClass);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Service failed to launch...");
                Console.WriteLine("We can't add a firewall rule");
                Console.WriteLine("\nPress <enter> to end the program...");
                Console.ReadLine();
            }
        }

        private static void RunAsAdmin(string fileName)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.Verb = "runas";
            processInfo.FileName = fileName;
            try
            {
                Process.Start(processInfo);
            }
            catch (Win32Exception)
            {
                //Do nothing. Probably the user canceled the UAC window
            }
        }

        private static bool RunningAsAdmin()
        {
            WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);

            return hasAdministrativeRight;
        }

    }
}
