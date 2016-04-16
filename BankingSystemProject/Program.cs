using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankingSystemProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Client Richie = new Client("Rachel",7876927843);
            Accounts Carol = new Accounts("saving", 100000m);
            Carol.Account_Num = Richie.AccountNumber;
            StreamWriter writer = new StreamWriter("AccountSummary.txt");
            writer.WriteLine("*******************");
            writer.WriteLine("Poonam Bank System");
            writer.WriteLine("*******************");
            writer.WriteLine("Name of client: " + Richie.Name);
            writer.WriteLine("Mobile Number  :" + Richie.MobileNumber);
            writer.WriteLine("Account number: " + Richie.AccountNumber);                
            writer.WriteLine("Account Type :" + Carol.AccountType);
            writer.WriteLine();
            writer.WriteLine();
            string answer = "";
            do
            {
                Console.WriteLine("*******************");
                Console.WriteLine("Poonam Bank System");
                Console.WriteLine("*******************");
                Console.WriteLine("1-View Client Information");
                Console.WriteLine("2-Deposit Funds");
                Console.WriteLine("3-Withdraw Funds");
                Console.WriteLine("4-View Account Information");
                Console.WriteLine("5-Exit");
                Console.WriteLine("Pick from the menu by giving the number");
                answer = Console.ReadLine();

                if (answer == "1")
                {
                    Console.WriteLine("Account Holder :" + Richie.Name);
                    Console.WriteLine("Account Number :" + Richie.AccountNumber);
                    Console.WriteLine("Mobile Number  :" + Richie.MobileNumber);
                }
                else if (answer == "2")
                {
                    Console.WriteLine("enter deposit amount");
                    decimal amount = decimal.Parse(Console.ReadLine());
                    Carol.deposit(amount);
                    Console.WriteLine("Date: " + DateTime.Now + "  Transaction Amount:  +" + amount + "  Current Balance : " + Carol.Balance);
                    writer.WriteLine("Date: " + DateTime.Now + "  Transaction Amount:  +" + amount + "  Current Balance : " + Carol.Balance);
                }
                else if (answer == "3")
                {
                    Console.WriteLine("withdraw amount?");
                    decimal deductAmt = decimal.Parse(Console.ReadLine());
                    Carol.withdraw(deductAmt);
                    Console.WriteLine("Date: " + DateTime.Now + "  Transaction Amount:  -" + deductAmt + "  Current Balance : " + Carol.Balance);
                    writer.WriteLine("Date: " + DateTime.Now + "  Transaction Amount:  -" + deductAmt + "  Current Balance : " + Carol.Balance);
                }
                else if (answer == "4")
                {
                    Console.WriteLine("Account Number :" + Carol.Account_Num);
                    Console.WriteLine("Account Type :" + Carol.AccountType);
                    Console.WriteLine("Account Balance :" + Carol.Balance);
                }
                else
                {
                    writer.Close();
                    StreamReader reader = new StreamReader("AccountSummary.txt");
                    string summary = "";
                    using (reader)
                    {
                        summary = reader.ReadToEnd();
                    }
                    Console.WriteLine("Account Summary :");
                    Console.WriteLine(summary);
                    Console.WriteLine("GoodBye");
                   answer = "5";
                }
            } while (answer != "5");
        }
    }

    class Client
    {
        private string name = "Lina Mirchandani";
        private int accountNumber = 384462827;
        private long mobileNumber = 7876927843;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public int AccountNumber
        {
            get
            {
                return this.accountNumber;
            }
            set
            {
                this.accountNumber = value;

            }
        }
        public long MobileNumber
        {
            get
            {
                return this.mobileNumber;
            }
            set
            {
                this.mobileNumber = value;

            }
        }



        public Client()
        {

        }
        public Client(string name,long cellnumber)
        {
            this.Name = name;
            this.MobileNumber = cellnumber;
            GetRandomAccountNumber();
        }

        public void GetRandomAccountNumber()
        {
            Random accountnum = new Random();
            this.AccountNumber = accountnum.Next(100000000, 992540345);
        }



    }
    
    class Accounts
    {
        private string accountType = "saving";
        private decimal balance = 100000m;
        private int account_Num = 384462827;

        public int Account_Num
        {
            get
            {
                return this.account_Num;
            }
            set
            {
                this.account_Num = value;
            }
        }
        public string AccountType
        {
            get
            {
                return this.accountType;
            }
            set
            {
                this.accountType = value;
            }
        }
        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }
        public Accounts()
        {

        }

        public Accounts(string type, decimal bal)
        {
            this.AccountType = type;
            this.Balance = bal;
        }


        public void deposit(decimal dAmount)
        {
            this.Balance += dAmount;
        }

        public void withdraw(decimal wAmount)
        {
            this.Balance -= wAmount;
        }
    }
}
