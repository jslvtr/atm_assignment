using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ATMAssignment
{
    public partial class Form2 : Form
    {
        private Account account;
        private Object thisLock = new Object();
        private Form3 child;
        private System.Timers.Timer exitTimer;

        public Form2(ref Account account)
        {
            InitializeComponent();
            this.account = account;
            this.Visible = true;
            child = new Form3(ref account, this);
        }

        public void Start()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => this.Show()));
            }
            else
            {
                this.Show();
            }
        }

        public void resetChild()
        {
            child = new Form3(ref account, this);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            welcomeLabel.Text = "Welcome, " + account.getName();
        }

        private void balanceButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "Your balance is £" + account.getBalance();
            messageLabel.Visible = true;
            messageLabel.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "Please take your card";
            messageLabel.Visible = true;
            messageLabel.Focus();
            exitTimer = new System.Timers.Timer(3000);
            exitTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            exitTimer.Start();
            GC.KeepAlive(exitTimer);
        }

        private void messageLabel_Leave(object sender, EventArgs e)
        {
            messageLabel.Visible = false;
        }

        void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            exitTimer.Stop();
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => this.Cancel()));
            }
            else
            {
                GC.Collect();
                this.Cancel();
            }
        }

        private void Cancel()
        {
            this.Close();
            child.Close();
        }

        private void cashButton_Click(object sender, EventArgs e)
        {
            if (child.Visible)
            {
                MessageBox.Show("Someone else is trying to use this account to take money out right now!");
            }
            lock (child)
            {
                //new Form3(ref account, this).Show();
                child.Show();
            }
            
        }
    }
}
