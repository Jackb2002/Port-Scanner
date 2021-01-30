using System;
using System.Collections.Generic;

namespace PortScanner.Scanning
{
    internal class ScanCompleteEventArgs : EventArgs
    {
        internal Host host;
        internal List<Port> Ports;
        internal List<Port> OpenPorts;
        internal DateTime StartTime;
        internal DateTime EndTime;
        internal TimeSpan ElapsedTime;

        public ScanCompleteEventArgs(Host host, List<Port> ports, List<Port> openPorts, DateTime startTime, DateTime endTime)
        {
            this.host = host ?? throw new ArgumentNullException(nameof(host));
            Ports = ports ?? throw new ArgumentNullException(nameof(ports));
            OpenPorts = openPorts ?? throw new ArgumentNullException(nameof(openPorts));
            StartTime = startTime;
            EndTime = endTime;
            ElapsedTime = endTime - startTime;
        }
    }
}