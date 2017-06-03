using System;
using System.Threading;
using System.Windows.Forms;

namespace Threading
{
    public partial class WinForm : Form
    {
        private bool threadRunning = true;
        private delegate void SetLabelTextDelegate(string text);        
        public WinForm()
        {
            InitializeComponent();
            Thread t = new Thread(new ThreadStart(delegate()
            {
                int count = 0;
                while (threadRunning)
                {
                    SetLabelText(string.Format("Wert: {0}", count++));
                    Thread.Sleep(250);
                }
            } ));
            t.Start();
        }
        private void SetLabelText(string text)
        {
            if (InvokeRequired)
                Invoke(new SetLabelTextDelegate(SetLabelText), new object [] { text } );
            else
                label.Text = text;
        }
        private void WinForm_OnFormClosed(object sender, FormClosedEventArgs e)
        {
            threadRunning = false;
        }
    }
}
