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
using System.    IO;

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
            time.Text = DateTime.Now.ToShortTimeString();


            Clipboard.SetText(DateTime.Now.ToShortDateString()+"_"+DateTime.Now.ToShortTimeString());


            timer.Interval = 20000; //5 sec
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            this.WindowState = WindowState.Minimized;
            FocusToPreviousWindow();
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
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(DateTime.Now.ToShortTimeString());

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var rand = new Random();
            string str= ((int)Math.Round(Math.Pow(10, 8) * rand.NextDouble())).ToString();
            Clipboard.SetText(str);
            filename.Text = str;
        }
        #region focus property

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern IntPtr GetLastActivePopup(IntPtr hWnd);

        [DllImport("user32.dll", ExactSpelling = true)]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        const uint GA_PARENT = 1;
        const uint GA_ROOT = 2;
        const uint GA_ROOTOWNER = 3;

        public IntPtr GetPreviousWindow()
        {
            IntPtr activeAppWindow = GetForegroundWindow();
            if (activeAppWindow == IntPtr.Zero)
                return IntPtr.Zero;

            IntPtr prevAppWindow = GetLastActivePopup(activeAppWindow);
            return IsWindowVisible(prevAppWindow) ? prevAppWindow : IntPtr.Zero;
        }

        public void FocusToPreviousWindow()
        {
            IntPtr prevWindow = GetPreviousWindow();
            if (prevWindow != IntPtr.Zero)
                SetForegroundWindow(prevWindow);
        }
        #endregion
    }
}

//TODO add new text features

