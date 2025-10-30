using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoOOP.Banking
{
    internal abstract class AccountBase
    {
        protected double _balance;
        //public double Balance { get; protected set; }
        public abstract double Balance { get; protected set; }

        public AccountBase(double initialBalance) 
        {
            Balance = initialBalance;
        }

        public abstract void Deposit(double amount);

        public abstract void Withdraw(double amount);
    }
}
