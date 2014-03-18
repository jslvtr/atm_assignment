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
        public List<Thread> t;
        public List<fundsWithdrawn> fundWithdrawnVariable;
        public delegate void fundsWithdrawn(int decrease, int currentBalance);

        public Account(int balance, int pin, int number, string name)
        {
            this.balance = balance;
            this.pin = pin;
            this.number = number;
            this.name = name;
            this.t = new List<Thread>();
            this.fundWithdrawnVariable = new List<fundsWithdrawn>();
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
            Thread tmp = new Thread(() =>
            {
                this.decrementBalance(decrease, currentBalance);
            });
            t.Add(tmp);
            tmp.Start();
            fundWithdrawnVariable.Add(fundsWithdrawnCallback);
        }

        public bool decrementBalance(int decrease, int currentBalance)
        {
            if (Form1.paused)
            {
                for (int i = 0; i < t.Count; i++ )
                {
                    if (t.ElementAt(i).ThreadState != System.Threading.ThreadState.Suspended) t.ElementAt(i).Suspend();
                }
            }
            lock (lockObject)
            {
                if (this.balance >= decrease)
                {
                    this.balance -= decrease;
                    Thread.Sleep(100);
                    fundWithdrawnVariable.ElementAt(0)(decrease, currentBalance);
                    fundWithdrawnVariable.RemoveAt(0);
                    return true;
                }
                return false;
            }
        }

        public void resume()
        {
            for (int i = 0; i < t.Count; i++ )
            {
                if (t.ElementAt(i) != null && t.ElementAt(i).ThreadState == System.Threading.ThreadState.Suspended)
                {
                    t.ElementAt(i).Resume();
                    Debug.WriteLine("output No." + this.number);
                }
            }
            
        }
    }
}
