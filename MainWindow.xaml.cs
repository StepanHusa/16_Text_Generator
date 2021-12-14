using System;
using System.Collections.Generic;
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
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace _16_Text_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static System.Timers.Timer timer = new System.Timers.Timer();

        public MainWindow()
        {
            InitializeComponent();

            date.Text = DateTime.Now.ToShortDateString();


            Clipboard.SetText(DateTime.Now.ToShortDateString());


            timer.Interval = 20000; //5 sec
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            this.WindowState = WindowState.Minimized;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(DateTime.Now.ToShortDateString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

    }
}

//TODO add new text features

