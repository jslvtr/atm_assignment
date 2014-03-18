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
    public partial class Form3 : Form
    {
        private Account account;
        private Form2 parent;
        private System.Timers.Timer exitTimer;
        private Thread withdrawThread;

        public Form3(ref Account account, Form2 parent)
        {
            InitializeComponent();
            this.account = account;
            this.parent = parent;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            nameLabel.Text = account.getName() + ", No." + account.getNumber();
            balanceLabel.Text = "Balance: £" + account.getBalance();
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (cashLabel.Text == "£0")
            {
                if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                {
                    cashLabel.Text = "£1";
                } else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
                {
                    cashLabel.Text = "£2";
                }
                else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
                {
                    cashLabel.Text = "£3";
                }
                else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
                {
                    cashLabel.Text = "£4";
                }
                else if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
                {
                    cashLabel.Text = "£5";
                }
                else if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
                {
                    cashLabel.Text = "£6";
                }
                else if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
                {
                    cashLabel.Text = "£7";
                }
                else if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
                {
                    cashLabel.Text = "£8";
                }
                else if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
                {
                    cashLabel.Text = "£9";
                }
            }
            else if(cashLabel.Text.Length <= 5)
            {
                if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                {
                    cashLabel.Text = cashLabel.Text+ "1";
                }
                else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
                {
                    cashLabel.Text = cashLabel.Text + "2";
                }
                else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
                {
                    cashLabel.Text = cashLabel.Text + "3";
                }
                else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
                {
                    cashLabel.Text = cashLabel.Text + "4";
                }
                else if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
                {
                    cashLabel.Text = cashLabel.Text + "5";
                }
                else if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
                {
                    cashLabel.Text = cashLabel.Text + "6";
                }
                else if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
                {
                    cashLabel.Text = cashLabel.Text + "7";
                }
                else if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
                {
                    cashLabel.Text = cashLabel.Text + "8";
                }
                else if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
                {
                    cashLabel.Text = cashLabel.Text + "9";
                }
                else if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
                {
                    cashLabel.Text = cashLabel.Text + "0";
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cashLabel.Text == "£0")
            {
                cashLabel.Text = "£1";
            }
            else if (cashLabel.Text.Length <= 5)
            {
                cashLabel.Text = cashLabel.Text + "1";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cashLabel.Text == "£0")
            {
                cashLabel.Text = "£2";
            }
            else if (cashLabel.Text.Length <= 5)
            {
                cashLabel.Text = cashLabel.Text + "2";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cashLabel.Text == "£0")
            {
                cashLabel.Text = "£3";
            }
            else if (cashLabel.Text.Length <= 5)
            {
                cashLabel.Text = cashLabel.Text + "3";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cashLabel.Text == "£0")
            {
                cashLabel.Text = "£4";
            }
            else if (cashLabel.Text.Length <= 5)
            {
                cashLabel.Text = cashLabel.Text + "4";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (cashLabel.Text == "£0")
            {
                cashLabel.Text = "£5";
            }
            else if (cashLabel.Text.Length <= 5)
            {
                cashLabel.Text = cashLabel.Text + "5";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (cashLabel.Text == "£0")
            {
                cashLabel.Text = "£6";
            }
            else if (cashLabel.Text.Length <= 5)
            {
                cashLabel.Text = cashLabel.Text + "6";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (cashLabel.Text == "£0")
            {
                cashLabel.Text = "£9";
            }
            else if (cashLabel.Text.Length <= 5)
            {
                cashLabel.Text = cashLabel.Text + "9";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (cashLabel.Text == "£0")
            {
                cashLabel.Text = "£8";
            }
            else if (cashLabel.Text.Length <= 5)
            {
                cashLabel.Text = cashLabel.Text + "8";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (cashLabel.Text == "£0")
            {
                cashLabel.Text = "£7";
            }
            else if (cashLabel.Text.Length <= 5)
            {
                cashLabel.Text = cashLabel.Text + "7";
            }
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if(cashLabel.Text != "£0")
            {
                cashLabel.Text = cashLabel.Text + "0";
            }
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            int decrease = Convert.ToInt32(cashLabel.Text.Substring(1));
            int currentBalance = this.account.getBalance();

            this.account.createThread(decrease, currentBalance, (delegate{ this.fundsWithdrawn(decrease, currentBalance); }));

            if (!Form1.paused) Thread.Sleep(100);
            else if(Form1.paused)
            {
                errorLabel.Text = "Thread suspended!";
                errorLabel.ForeColor = System.Drawing.Color.Red;
                errorLabel.Visible = true;
            }
        }

        void fundsWithdrawn(int decrease, int currentBalance)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => this.fundsWithdrawnFullMethod(decrease, currentBalance)));
            }
            else
            {
                this.fundsWithdrawnFullMethod(decrease, currentBalance);
            }
        }

        public void fundsWithdrawnFullMethod(int decrease, int currentBalance)
        {
            if (this.account.getBalance() < currentBalance)
            {
                balanceLabel.Text = "Balance: £" + account.getBalance();
                errorLabel.Text = "Funds withdrawn: £" + decrease;
                errorLabel.ForeColor = System.Drawing.Color.Green;
                errorLabel.Visible = true;
                exitTimer = new System.Timers.Timer(3000);
                exitTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
                exitTimer.Start();
                GC.KeepAlive(exitTimer);
            }
            else
            {
                errorLabel.Text = "Insufficient funds for withdrawal of £" + decrease + ".";
                errorLabel.ForeColor = System.Drawing.Color.Red;
                errorLabel.Visible = true;
                exitTimer = new System.Timers.Timer(2000);
                exitTimer.Elapsed += new System.Timers.ElapsedEventHandler(LabelDisappear);
                exitTimer.Start();
                GC.KeepAlive(exitTimer);
                this.cashLabel.Text = "£0";
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (cashLabel.Text != "£0")
            {
                cashLabel.Text = "£0";
            }
            else
            {
                this.Close();
                parent.Show();
                parent.resetChild();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            cashLabel.Text = "£10";
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.resetChild();
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if (cashLabel.Text != "£0")
            {
                if (cashLabel.Text.Length > 2)
                {
                    cashLabel.Text = cashLabel.Text.Substring(0, cashLabel.Text.Length - 1);
                }
                else
                {
                    cashLabel.Text = "£0";
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            cashLabel.Text = "£20";
        }

        private void button50_Click(object sender, EventArgs e)
        {
            cashLabel.Text = "£50";
        }

        private void button100_Click(object sender, EventArgs e)
        {
            cashLabel.Text = "£100";
        }

        private void button300_Click(object sender, EventArgs e)
        {
            cashLabel.Text = "£300";
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

        void LabelDisappear(object source, System.Timers.ElapsedEventArgs e)
        {
            exitTimer.Stop();
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => LabelDisappear(source, e)));
            }
            else
            {
                GC.Collect();
                this.errorLabel.Hide();
            }
        }

        private void Cancel()
        {
            this.Close();
            parent.resetChild();
        }
    }
}
