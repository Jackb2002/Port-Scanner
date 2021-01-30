using System;

namespace PortScanner.Scanning
{
    internal partial class Port
    {
        internal readonly int Number;
        internal PortService Service;
        internal PortStatus Status;

        private const int MIN_PORT = 0;
        private const int MAX_PORT = 65535;


        public Port(int number)
        {
            if (number < MIN_PORT || number > MAX_PORT)
            {
                Console.WriteLine("Invalid port " + number);
            }
            else
            {
                Number = number;
                Service = new PortService(this);
            }
            Status = PortStatus.Unknown;
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
