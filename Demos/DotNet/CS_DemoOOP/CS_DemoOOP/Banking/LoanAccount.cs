using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoOOP.Banking
{
    internal class LoanAccount: AccountBase
    {
        public override double Balance
        {
            get => _balance;
            protected set
            {
                _balance = value;
            }
        }

        public LoanAccount(double initialLoanAmount): base(initialLoanAmount)
        {
            
        }

        public override void Deposit(double amount)
        {
            if(this.Balance> 0 && this.Balance-amount >= 0)
            {
                this.Balance -= amount;
            }
            else
            {
                throw new InvalidOperationException("Depositing amount more than the outstanding balance.");
            }
        }

        public override void Withdraw(double amount)
        {
            this.Balance += amount;
        }
    }
}
