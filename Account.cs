using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace ATMAssignment
{
    public class Account
    {
        private int balance, pin, number;
        private string name;
        private Object lockObject = new Object();
        public Thread t;
        public fundsWithdrawn fundWithdrawnVariable;
        public delegate void fundsWithdrawn(int decrease, int currentBalance);

        public Account(int balance, int pin, int number, string name)
        {
            this.balance = balance;
            this.pin = pin;
            this.number = number;
            this.name = name;
        }

        public int getBalance()
        {
            return this.balance;
        }

        public string getName()
        {
            return this.name;
        }

        public int getNumber()
        {
            return this.number;
        }

        public int getPin()
        {
            return this.pin;
        }

        public bool checkPin(int pin)
        {
            return (pin == this.pin);
        }

        public void createThread(int decrease, int currentBalance, fundsWithdrawn fundsWithdrawnCallback)
        {
            // Create new thread for withdrawal
            this.t = new Thread(() =>
            {
                this.decrementBalance(decrease, currentBalance);
            });
            t.Start();
            fundWithdrawnVariable = fundsWithdrawnCallback;
        }

        public bool decrementBalance(int decrease, int currentBalance)
        {
            if (Form1.paused)
            {
                this.t.Suspend();
            }
            lock (lockObject)
            {
                if (this.balance >= decrease)
                {
                    this.balance -= decrease;
                    Thread.Sleep(100);
                    fundWithdrawnVariable(decrease, currentBalance);
                    return true;
                }
                return false;
            }
        }

        public void resume()
        {
            if(this.t != null && this.t.ThreadState == System.Threading.ThreadState.Suspended) this.t.Resume();
            Debug.WriteLine("output No." + this.number);
        }
    }
}
