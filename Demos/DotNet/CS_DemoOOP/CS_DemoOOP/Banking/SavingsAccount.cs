using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_DemoOOP.Insurance;

namespace CS_DemoOOP.Banking
{
    internal class SavingsAccount: AccountBase, IInsurance
    {
        public delegate void LowBalanceHandler(double currentBalance);

        public event LowBalanceHandler? LowBalance;

        public override double Balance 
        { 
            get => _balance; 
            protected set
            {
                _balance = value;
            }
        }

        public SavingsAccount(double initialBalance): base (initialBalance)
        {
            
        }

        public override void Deposit(double amount)
        {
            this.Balance += amount;
        }

        public override void Withdraw(double amount)
        {
            if (this.Balance > 0 && this.Balance - amount > 0)
            {
                this.Balance -= amount;
            }
            else
            {
                //throw new InvalidOperationException("Insufficient funds in account.");
                LowBalance?.Invoke(this.Balance);
            }
        }

        public double CalculatePremium()
        {
            var premium = this.Balance * 0.01;
            Console.WriteLine($"Insurance premium for savings account: {premium}");
            return premium;
        }
    }
}
