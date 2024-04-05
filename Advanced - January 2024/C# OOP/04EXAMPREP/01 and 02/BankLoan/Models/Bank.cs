using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private int capacity;
        private List<ILoan> loans;
        private List<IClient> clients;

        public Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            loans = new List<ILoan>();
            clients = new List<IClient>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }

                name = value;
            }
        }

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }
        public IReadOnlyCollection<ILoan> Loans
        {
            get { return loans.AsReadOnly(); }
        }
        public IReadOnlyCollection<IClient> Clients
        {
            get { return clients.AsReadOnly(); }
        }
        public double SumRates()
        {
            double sumRates = 0;
            foreach (ILoan loan in Loans)
            {
                sumRates += loan.InterestRate;
            }

            return sumRates;
        }

        public void AddClient(IClient Client)
        {
            if (Clients.Count >= Capacity)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }
            clients.Add(Client);
        }

        public void RemoveClient(IClient Client)
        {
            clients.Remove(Client);
        }

        public void AddLoan(ILoan loan)
        {
            loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}, Type: {this.GetType().Name}");
            if (Clients.Count > 0)
            {
                sb.AppendLine($"Clients: {string.Join(", ", Clients)}");
            } else if (Clients.Count <= 0)
            {
                sb.AppendLine($"Clients: none");
            }
            sb.AppendLine($"Loans: {Loans.Count}, Sum of Rates: {SumRates()}");

            return sb.ToString().Trim();
        }
    }
}
