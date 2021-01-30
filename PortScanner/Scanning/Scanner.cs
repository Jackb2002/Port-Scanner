using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace PortScanner.Scanning
{
    internal class Scanner
    {
        public static event ScanCompleteEventHandler OnScanComplete;
        public delegate void ScanCompleteEventHandler(object sender, ScanCompleteEventArgs e);
        public static event ScanFailEventHandler OnScanFailed;
        public delegate void ScanFailEventHandler(object sender, ScanFailEventArgs e);

        internal static void Scan(IPAddress IP, List<Port> ports, bool pingCheck = true)
        {
            Task.Factory.StartNew(() => scanThread(IP, ports, pingCheck));
        }

        private static void scanThread(IPAddress IP, List<Port> ports, bool pingCheck)
        {
            DateTime start = DateTime.Now;

            Host host = new Host(IP);
            Ping ping = new Ping();

            var onlineStatus = ping.Send(IP);
            Console.WriteLine("Host ping " + IP + " returned " + onlineStatus.Status);

            if (onlineStatus.Status == IPStatus.Success || !pingCheck)
            {
                if (onlineStatus.Status == IPStatus.Success)
                {
                    host.OnlineLastCheck = true;
                }
                else if (!pingCheck)
                {
                    Console.WriteLine("Scanning host " + IP + " skipping ping check");
                }

                Console.WriteLine("Setting up threads for scan " + IP);
                List<Task> scanTasks = new List<Task>();
                for (int i = 0; i < ports.Count; i++)
                {
                    Port port = ports[i];
                    Console.WriteLine($"Index {i} Port {port.Number}");
                    scanTasks.Add(Task.Factory.StartNew(() => ScanPort(host, port)));
                }

                Console.WriteLine("All Tasks Started, Waiting Finish");
                Task.WaitAll(scanTasks.ToArray());
                Console.WriteLine("All Tasks Complete, Organising Port Array");

                DateTime end = DateTime.Now;
                OnScanComplete?.Invoke(null, new ScanCompleteEventArgs(host, ports, ports.Where(x => x.Status == PortStatus.Open).ToList(), start, end));

                foreach (var port in host.Ports)
                {
                    Console.WriteLine($"{port.Number}:{port.Status} - Service:{port.Service}");
                }
            }
            else
            {
                OnScanFailed?.Invoke(null, new ScanFailEventArgs(host, ports, start, DateTime.Now));
            }
        }

        private static Port ScanPort(Host host, Port port)
        {
            Console.WriteLine("Scan job for port " + port.Number);
            using (var client = new TcpClient())
            {
                var result = client.BeginConnect(host.IP, port.Number, null, null);
                var success = result.AsyncWaitHandle.WaitOne(150);
                try
                {
                    client.EndConnect(result);
                    if (success)
                    {
                        port.Status = PortStatus.Open;
                        host.Ports.Add(port);
                        return port;
                    }
                    else
                    {
                        port.Status = PortStatus.Closed;
                        host.Ports.Add(port);
                        return port;
                    }
                }
                catch (SocketException)
                {
                    port.Status = PortStatus.Closed;
                    host.Ports.Add(port);
                    return port;
                }
                finally
                {
                    Console.WriteLine("Port " + port.Number + " Scanned");
                }
            }
        }
    }
}
