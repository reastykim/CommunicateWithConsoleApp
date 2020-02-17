using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
            _consoleAppProcess = new Process();
            _consoleAppProcess.EnableRaisingEvents = true;
            _consoleAppProcess.StartInfo.FileName = ConsoleAppPath;
            _consoleAppProcess.StartInfo.CreateNoWindow = true;
            _consoleAppProcess.StartInfo.UseShellExecute = false;
            _consoleAppProcess.StartInfo.RedirectStandardOutput = true;
            _consoleAppProcess.StartInfo.RedirectStandardError = true;
            _consoleAppProcess.StartInfo.RedirectStandardInput = true;
            _consoleAppProcess.OutputDataReceived += _consoleAppProcess_OutputDataReceived;

            _consoleAppProcess.Exited += (ss, ee) =>
            {
                Console.WriteLine();
                Console.WriteLine($"ConsoleApp exited with ExitCode={_consoleAppProcess.ExitCode}");
            };

            var result = _consoleAppProcess.Start();
            _consoleAppProcess.BeginOutputReadLine();
            _consoleAppProcess.BeginErrorReadLine();

            InitializeComponent();
        }

        private void _consoleAppProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            var output = e.Data;
            Console.WriteLine($"<= {output}");

            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                switch (output)
                {
                    case "나이를 입력하세요 : ":
                        gridAgeInput.IsEnabled = true;
                        gridNameInput.IsEnabled = false;
                        break;
                    case "이름을 입력하세요 : ":
                        gridAgeInput.IsEnabled = false;
                        gridNameInput.IsEnabled = true;
                        break;
                    default:
                        txtBlockOutput.Text = output;
                        break;
                }
            }));
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtBlockOutput.Text = "";
            gridAgeInput.IsEnabled = false;
            gridNameInput.IsEnabled = false;

            _consoleAppProcess.StandardInput.Write(txtBoxAge.Text + Environment.NewLine);
            _consoleAppProcess.StandardInput.Flush();
            txtBoxAge.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtBlockOutput.Text = "";
            gridAgeInput.IsEnabled = false;
            gridNameInput.IsEnabled = false;

            _consoleAppProcess.StandardInput.Write(txtBoxName.Text + Environment.NewLine);
            _consoleAppProcess.StandardInput.Flush();
            txtBoxName.Text = "";
        }
    }
}
