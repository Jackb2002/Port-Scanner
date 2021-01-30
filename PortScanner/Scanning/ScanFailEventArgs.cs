using System;
using System.Collections.Generic;

namespace PortScanner.Scanning
{
    internal class ScanFailEventArgs : EventArgs
    {
        internal Host host;
        internal List<Port> Ports;
        internal DateTime StartTime;
        internal DateTime EndTime;
        internal TimeSpan ElapsedTime;

        public ScanFailEventArgs(Host host, List<Port> ports, DateTime startTime, DateTime endTime)
        {
            this.host = host ?? throw new ArgumentNullException(nameof(host));
            Ports = ports ?? throw new ArgumentNullException(nameof(ports));
            StartTime = startTime;
            EndTime = endTime;
            ElapsedTime = endTime - startTime;
        }
    }
}