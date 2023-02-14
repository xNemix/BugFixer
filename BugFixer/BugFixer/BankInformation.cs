using BugFixer.Exceptions;

namespace BugFixer
{
    public class BankInformation
    {
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string Currency { get; set; }
        public int Balance { get; set; }


        public BankInformation()
        {
            AccountNumber = "Test AccountNumber";
            BankName = "Test BankName";
            Currency = "Test Currency";
            Balance = 0;
        }

        public BankInformation(string accountNumber, string bankName, string currency, int balance) : this()
        {
            AccountNumber = accountNumber;
            BankName = bankName;
            Currency = currency;
            Balance = balance;
        }

        public void AddBalance()
        {
            Console.WriteLine($"Your current balance is {Balance}");
            Console.WriteLine("How much would you like to add?");
            Console.WriteLine("1: 100");
            Console.WriteLine("2: 500");
            Console.WriteLine("3: 1000");
            var selection = Console.ReadLine()!;
            if (selection == "1")
            {
                Balance = +100;
                Console.WriteLine("100 added to your balance");
            }
            else if (selection == "2")
            {
                Balance = +500;
                Console.WriteLine("500 added to your balance");
            }
            else if (selection == "3")
            {
                Balance = +1000;
                Console.WriteLine("1000 added to your balance");
            }
            else
            {
                throw new InvalidInputException();
            }
        }
    }
}
