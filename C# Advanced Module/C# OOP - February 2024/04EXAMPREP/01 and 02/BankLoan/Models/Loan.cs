using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Models.Contracts;

namespace BankLoan.Models
{
    public abstract class Loan : ILoan
    {
        private int interestRate;
        private double amount;
        public Loan(int interestRate, double amount)
        {
            
        }

        public int InterestRate
        {
            get { return interestRate; }
        }

        public double Amount
        {
            get { return amount; }
        }
    }
}
