using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public enum Action
    {
        Deposit, Withdraw
    }
    public interface ICommand
    {
        void Call();
    }

    public class BankAccountCommand : ICommand
    {
        private readonly BankAccount bankAccount;
        private Action action;
        private int amount;

        public BankAccountCommand(BankAccount bankAccount, Action action, int amount)
        {
            this.bankAccount = bankAccount;
            this.action = action;
            this.amount = amount;
        }

        public void Call()
        {
            switch (action)
            {
                case Action.Deposit:
                    bankAccount.Deposit(amount);
                    break;
                case Action.Withdraw:
                    bankAccount.Withdraw(amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action));
            }
                
        }
    }
}
