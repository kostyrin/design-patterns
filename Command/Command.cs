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
        void Undo();
    }

    public class BankAccountCommand : ICommand
    {
        private readonly BankAccount bankAccount;
        private Action action;
        private int amount;
        private bool succeeded;

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
                    succeeded = true;
                    break;
                case Action.Withdraw:
                    succeeded = bankAccount.Withdraw(amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action));
            }
                
        }

        public void Undo()
        {
            switch (action)
            {
                case Action.Deposit:
                    bankAccount.Withdraw(amount);
                    break;
                case Action.Withdraw:
                    bankAccount.Deposit(amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action));
            }
        }
    }
}
