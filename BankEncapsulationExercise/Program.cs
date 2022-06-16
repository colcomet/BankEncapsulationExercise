using System;

namespace BankEncapsulationExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();
            bool done = false;
            do
            {
                done = HandleInput(account);
            } while (!done);
        }

        private static bool HandleInput(BankAccount account)
        {
            Console.WriteLine();
            Console.Write("[D]eposit, View [B]alance, or [E]xit: ");

            var entry = Console.ReadKey();
            if (entry.KeyChar == 'E' || entry.KeyChar == 'e' || entry.KeyChar == 'X' || entry.KeyChar == 'x')
            {
                return true;
            }
            else if (entry.KeyChar == 'B' || entry.KeyChar == 'b')
            {
                Console.WriteLine();
                Console.WriteLine($"Account balance is {account.GetBalance():$0.00}");
            }
            else if (entry.KeyChar == 'D' || entry.KeyChar == 'd')
            {
                Console.WriteLine();
                double deposit = GetParsedDepositAmount();
                account.Deposit(deposit);
                Console.WriteLine($"{deposit:$0.00} has been deposited.");
            }
            return false;
        }

        private static double GetParsedDepositAmount()
        {
            bool gotResult;
            double result;
            do
            {
                Console.WriteLine("Enter amount to deposit");
                gotResult = double.TryParse(Console.ReadLine(), out result);
            } while (!gotResult);
            return result;
        }
    }
}
