using System;
using System.Threading;

namespace Threading
{
    class AsynchroneMethodenaufrufe
    {
        private delegate string AsyncMyMethodCaller(int number, string message);
        private bool myMethodFinished = false;
        static void Main(string[] args)
        {
            new AsynchroneMethodenaufrufe();
        }
        public AsynchroneMethodenaufrufe()
        {
            AsyncMyMethodCaller caller = new AsyncMyMethodCaller(this.MyMethod);

            // Methode 1 - Warten auf Beendigung durch Aufruf von EndInvoke()
            IAsyncResult result = caller.BeginInvoke(5, "Methode 1", null, null);
            Console.WriteLine(caller.EndInvoke(result));

            // Methode 2 - Für das Beenden auf das Handle warten
            result = caller.BeginInvoke(3, "Methode 2", null, null);
            result.AsyncWaitHandle.WaitOne();
            Console.WriteLine(caller.EndInvoke(result));

            // Methode 3 - zyklisches Abfragen
            result = caller.BeginInvoke(4, "Methode 3", null, null);
            while (!result.IsCompleted)
                Thread.Sleep(50);
            Console.WriteLine(caller.EndInvoke(result));

            // Methode 4 - callback benutzen
            result = caller.BeginInvoke(2, "Methode 4", new AsyncCallback(this.MyMethodFinishedHandler), caller);
            while (!myMethodFinished)
                Thread.Sleep(50);
            Console.WriteLine(caller.EndInvoke(result));
            Console.ReadLine();
        }
        private void MyMethodFinishedHandler(IAsyncResult result)
        {
            myMethodFinished = true;
            Console.WriteLine ("asynchronen Aufruf beendet");
        }
        private string MyMethod(int number, string message)
        {
            Console.WriteLine("AsyncDemo.MyMethod() aufgerufen");
            for (int i = 0; i < number; i ++)
            {
                Console.WriteLine(string.Format(" {0}:{1} ", i, message));
                Thread.Sleep(250);
            }
            return "Rückgabewert!";
        }
    }
}
