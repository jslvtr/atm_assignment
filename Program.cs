using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ATMAssignment
{
    static class Program
    {

        public static Account[] accounts;

        /*
         * Here we save the accounts to the text file.
         * If the file doesn't exist, we create it first.
         * Then we simply go through all our accounts and write them to file in .CSV format.
         */
        public static void saveAccounts()
        {
            // Create the file if it doesn't exist...
            try {
                if (!System.IO.File.Exists(@".\accountsave.txt"))
                {
                    System.IO.File.Create(@".\accountsave.txt");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to write file. Do you have enough permissions?");
            }

            // We use using so that the file closes itself at the end of the block.
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@".\accountsave.txt"))
            {
                foreach (Account a in accounts)
                {
                    file.WriteLine(a.getBalance() + "," + a.getPin() + "," + a.getNumber()+ "," + a.getName());
                }
            }
        }

        /*
         * This method is used to load the accounts from a text file.
         */
        private static void loadAccounts()
        {
            string line;
            List<Account> accountList = new List<Account>();
            // We check that the file exists...
            if (System.IO.File.Exists(@".\accountsave.txt"))
            {
                // We use `using` so that the StreamReader is destroyed at the end of the block
                using (System.IO.StreamReader file = new System.IO.StreamReader(@".\accountsave.txt"))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        try
                        {
                            string[] lineSplit = line.Split(',');
                            accountList.Add(new Account(Convert.ToInt32(lineSplit[0]), Convert.ToInt32(lineSplit[1]), Convert.ToInt32(lineSplit[2]), lineSplit[3]));
                        }
                        catch (Exception e)
                        {

                        }

                    }
                }
                accounts = accountList.ToArray<Account>();
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            loadAccounts();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
