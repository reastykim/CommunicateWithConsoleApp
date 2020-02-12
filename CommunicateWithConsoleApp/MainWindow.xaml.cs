using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommunicateWithConsoleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ConsoleAppPath = "ConsoleApp1.exe";
        private Process _consoleAppProcess;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _consoleAppProcess = new Process();
            _consoleAppProcess.EnableRaisingEvents = true;
            _consoleAppProcess.StartInfo.FileName = ConsoleAppPath;
            _consoleAppProcess.StartInfo.CreateNoWindow = true;
            _consoleAppProcess.StartInfo.UseShellExecute = false;

            _consoleAppProcess.Exited += (ss, ee) =>
            {
                Console.WriteLine();
                Console.WriteLine($"ConsoleApp exited with ExitCode={_consoleAppProcess.ExitCode}");
            };

            var result = _consoleAppProcess.Start();
        }
    }
}
