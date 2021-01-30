using System;
using System.Collections.Generic;
using System.Net;

namespace PortScanner.Scanning
{
    class Host
    {
        internal IPAddress IP;
        internal List<Port> Ports;
        internal bool OnlineLastCheck = false;

        public Host(IPAddress iP)
        {
            IP = iP ?? throw new ArgumentNullException(nameof(iP));
            Ports = new List<Port>();
            OnlineLastCheck = false;
        }

        public Host(IPAddress iP, List<Port> ports) : this(iP)
        {
            Ports = ports ?? throw new ArgumentNullException(nameof(ports));
        }

        public override string ToString()
        {
            return IP.ToString();
        }
    }
}
