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

namespace _01_UIThreadBehaviorDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnDoWork_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Thread Id in BtnClick = " + Thread.CurrentThread.ManagedThreadId);
            TBStatus.Text = "Work Starting";
            //ThreadPool.QueueUserWorkItem((o) => DoWork());

            /*var thread = new Thread(DoWork);
            thread.Start();*/

            //DoWork();

            var task = new Task<DateTime>(DoWork);
            task.ContinueWith(t => UpdateCompletion(t), TaskScheduler.FromCurrentSynchronizationContext());
            task.Start();
        }

        private DateTime DoWork()
        {
            Debug.WriteLine("Thread Id in DoWork = " + Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 5000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    for (int k = 0; k < 100; k++)
                    {
                        
                    }
                }
            }
            return DateTime.Now;
            //Dispatcher.BeginInvoke(new Action(() => TBStatus.Text = "Work Completed"));

        }

        public void UpdateCompletion(Task<DateTime> t)
        {

            TBStatus.Text = "Work Completed at " + t.Result.ToLongTimeString();
        }
    }
}
