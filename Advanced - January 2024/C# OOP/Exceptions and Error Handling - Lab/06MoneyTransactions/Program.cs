namespace _06MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(",");
            Dictionary<int, double> bankAccounts = new Dictionary<int, double>();
            foreach (string bankAccount in input)
            {
                string[] splitted = bankAccount.Split("-");
                int account = int.Parse(splitted[0]);
                double balance = double.Parse(splitted[1]);
                bankAccounts[account] = balance; 
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" ");
                int account = int.Parse(tokens[1]);
                double sum = double.Parse(tokens[2]);
                bool validAccount = false;

                try
                {
                    foreach (KeyValuePair<int, double> kvp in bankAccounts)
                    {
                        if (account == kvp.Key) { validAccount = true; break; }
                    }

                    if (!validAccount)
                    {
                        throw new ArgumentException("Invalid account!");
                    }

                    if (tokens[0] == "Deposit")
                    {
                        bankAccounts[account] += sum;
                        Console.WriteLine($"Account {account} has new balance: {bankAccounts[account]:F2}");
                    }
                    else if (tokens[0] == "Withdraw")
                    {
                        if (bankAccounts[account] < sum)
                        {
                            throw new ArgumentException("Insufficient balance!");
                        } else
                        {
                            bankAccounts[account] -= sum;
                            Console.WriteLine($"Account {account} has new balance: {bankAccounts[account]:F2}");
                        }
                    } else
                    {
                        throw new ArgumentException("Invalid command!");
                    }

                } catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                } finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}