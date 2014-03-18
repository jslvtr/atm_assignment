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
    public partial class Form1 : Form
    {
        private static List<Thread> threads;
        private System.Timers.Timer exitTimer;
        private bool fieldsVisible = false;
        public static bool paused = false;

        public Form1()
        {
            InitializeComponent();
            threads = new List<Thread>();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (textBox2.Text.Equals("") && !textBox2.Focused)
            {
                textBox2.Text = "Account PIN [1111]";
            }
            if (textBox1.Text.Equals("") && !textBox1.Focused)
            {
                textBox1.Text = "Account Number [111111]";
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        /**
         * Method to check that the Account number and pin number both are correct
         * and they both match.
         */
        private void ATMContinue()
        {
            bool found = false;
            for (int i = 0; i < Program.accounts.Length; i++)
            {
                try
                {
                    if (Program.accounts[i].checkPin(Convert.ToInt32(textBox2.Text)))
                    {
                        // Create new Thread for ATM operations panel for this account
                        Form2 child = new Form2(ref Program.accounts[i]);
                        child.Start();
                        found = true;
                    }
                }
                catch (Exception e)
                {

                }
            }
            if (!found)
            {
                errorLabel.Text = "Incorrect PIN or Account Number";
                errorLabel.Visible = true;
                exitTimer = new System.Timers.Timer();
                exitTimer.Interval = 2000;
                exitTimer.Elapsed += new System.Timers.ElapsedEventHandler(LabelDisappear);
                exitTimer.Start();
                GC.KeepAlive(exitTimer);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ATMContinue();
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.saveAccounts();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fieldsVisible)
            {
                try {
                Account[] tmpAccounts = Program.accounts;
                Account[] newAccounts = new Account[tmpAccounts.Length + 1];
                for(int i = 0; i < tmpAccounts.Length; i++)
                {
                    newAccounts[i] = tmpAccounts[i];
                }
                newAccounts[newAccounts.Length - 1] = new Account(
                                                                    Convert.ToInt32(balanceTextBox.Text),
                                                                    Convert.ToInt32(textBox2.Text),
                                                                    Convert.ToInt32(textBox1.Text),
                                                                    nameTextBox.Text
                                                                 );
                Program.accounts = newAccounts;
                Program.saveAccounts();
                } 
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding new account...");
                }
                fieldsVisible = false;
                nameTextBox.Visible = false;
                balanceTextBox.Visible = false;
            }
            else
            {
                nameTextBox.Visible = true;
                balanceTextBox.Visible = true;
                fieldsVisible = true;
            }
        }

        private void pauseBox_CheckedChanged(object sender, EventArgs e)
        {
            paused = !paused;
            for (int i = 0; i < Program.accounts.Length; i++)
            {
                Program.accounts[i].resume();
            }
        }
    }
}
