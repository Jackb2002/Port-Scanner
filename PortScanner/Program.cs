using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PortScanner
{
    class Program
    {
        public const string NAME = "Port Scanner";
        public const decimal VERSION = 0.1M;

        internal static MainWindow main;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Title = $"{NAME} - {VERSION}";
            Console.Clear();
            Console.WriteLine("Creating Form Window");
            Thread FormThread = new Thread(StartForm);
            FormThread.Start();
            Thread.Sleep(-1);
        }

        [STAThread]
        private static void StartForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            main = new MainWindow();
            Application.Run(main);
        }

        internal static void HideConsole()
        {
            var consoleHandle = GetConsoleWindow();
            ShowWindow(consoleHandle, 0);  // hides console window
        }

        internal static void ShowConsole()
        {
            var consoleHandle = GetConsoleWindow();
            ShowWindow(consoleHandle, 3);  // shows console window
        }
    }
}
