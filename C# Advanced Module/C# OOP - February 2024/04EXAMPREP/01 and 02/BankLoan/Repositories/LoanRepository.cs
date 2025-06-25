using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        private List<ILoan> loans = new List<ILoan>();
        public IReadOnlyCollection<ILoan> Models
        {
            get { return loans.AsReadOnly(); }
        }
        public void AddModel(ILoan model)
        {
            loans.Add(model);
        }

        public bool RemoveModel(ILoan model)
        {
            if (loans.Contains(model))
            {
                loans.Remove(model);
                return true;
            }

            return false;
        }

        public ILoan FirstModel(string name)
        {
            return loans.FirstOrDefault(l => l.GetType().Name == name);
        }
    }
}
