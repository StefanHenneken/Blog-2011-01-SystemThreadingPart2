using System;
using System.ComponentModel;
using System.Threading;

namespace Threading
{
    class BackgroundWorkerSample
    {
        private double workerResult;       
        static void Main(string[] args)
        {
            new BackgroundWorkerSample();
        }
        public BackgroundWorkerSample()
        {
            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.DoWork += new DoWorkEventHandler(this.DoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.WorkCompleted);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(this.ProgressChanged);
            bgWorker.RunWorkerAsync("Beginne Berechnung von PI!");
            bgWorker.WorkerReportsProgress = true;
            while (bgWorker.IsBusy)
                Thread.Sleep(50);
            Console.WriteLine("Ergebnis = " + workerResult);
            Console.ReadLine();
        }
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine(e.Argument);
            e.Result = CalculatePi((BackgroundWorker)sender);
        }
        private void WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Beendet!");
            workerResult = (double)e.Result;
        }
        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine(string.Format("Fertig {0}% ", e.ProgressPercentage));
        }
        private double CalculatePi(BackgroundWorker worker)
        {
            double radius = 100;
            double kreistreffer = 0;
            long perc = (long)(((radius * 2) * Math.Pow(radius, 2)) + Math.Pow(radius, 2) / 100) / 100;
            long iter = 0;
            int percCompleted = 0;
            for (double y = radius * (-1); y <= radius; y++)
            {
                double end = Math.Pow(radius, 2);
                for (double x = radius * (-1); x <= end; x ++)
                {
                    iter ++;
                    if ((Math.Pow(x, 2) + Math.Pow(y, 2)) <= Math.Pow(radius, 2))
                        kreistreffer++;
                    if (iter == perc)
                    {
                        worker.ReportProgress(percCompleted++);
                        iter = 0;
                    }
                }
            }
            return kreistreffer / Math.Pow(radius, 2);
        }
    }
}
