using PortScanner.Scanning;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace PortScanner
{
    public partial class MainWindow : Form
    {
        bool consoleHidden = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Scanner.OnScanComplete += scanComplete;
            Scanner.OnScanFailed += scanFailed;
            CheckForIllegalCrossThreadCalls = false;
            Console.WriteLine("Loaded UI");
            outputBox.AppendText("Loaded!");
        }

        private void scanFailed(object sender, ScanFailEventArgs e)
        {
            outputBox.AppendText(Environment.NewLine + $"Scanning of host {e.host} failed for {e.Ports.Count} ports \nElapsed Time {e.ElapsedTime.TotalSeconds} Seconds");
        }

        private void scanComplete(object sender, ScanCompleteEventArgs e)
        {
            outputBox.AppendText(Environment.NewLine + $"Scanning of host {e.host} finished for {e.Ports.Count} ports \nElapsed Time {e.ElapsedTime.TotalSeconds} Seconds");
            foreach (var port in e.OpenPorts)
            {
                outputBox.AppendText(Environment.NewLine + $"Port:{port} - {port.Status}");
            }
            outputBox.AppendText(Environment.NewLine + "All other ports are closed");
        }

        private void debugTglBtn_Click(object sender, EventArgs e)
        {
            if (consoleHidden)
            {
                Program.ShowConsole();
            }
            else
            {
                Program.HideConsole();
            }
            consoleHidden = !consoleHidden;
            Console.WriteLine("Toggled console visibility to " + !consoleHidden);
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Closing...");
            Program.ShowConsole();

            //anything to save before end of program
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void sndBtn_Click(object sender, EventArgs e)
        {
            outputBox.Clear();
            outputBox.AppendText("Scanning...");
            if (IPAddress.TryParse(ipaddTxt.Text, out IPAddress IP))
            {
                if (int.TryParse(minPortTxt.Text.Trim(), out int minInt))
                {
                    if (int.TryParse(maxPortTxt.Text.Trim(), out int maxInt))
                    {
                        List<Port> ports = new List<Port>();
                        for (int i = minInt; i < maxInt + 1; i++)
                        {
                            var tmp = new Port(i);
                            if (tmp != null) ports.Add(tmp);
                        }
                        Scanner.Scan(IP, ports);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Maximum Port");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Minimum Port");
                }
            }
            else
            {
                Console.WriteLine("Invalid IP");
            }
        }
    }
}
