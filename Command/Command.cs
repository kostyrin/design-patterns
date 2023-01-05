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
        bool Succeeded { get; set; }
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

        public bool Succeeded { get; set; }

        public void Call()
        {
            switch (action)
            {
                case Action.Deposit:
                    bankAccount.Deposit(amount);
                    Succeeded = true;
                    break;
                case Action.Withdraw:
                    Succeeded = bankAccount.Withdraw(amount);
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

    public class CompositeBankAccountCommand : List<BankAccountCommand>, ICommand
    {
        public virtual void Call()
        {
            ForEach(cmd => cmd.Call());
        }

        public virtual void Undo()
        {
            foreach (ICommand command in ((IEnumerable<BankAccountCommand>)this).Reverse())
            {
                if (command.Succeeded) command.Call();
            }
        }

        public virtual bool Succeeded
        {
            get { return this.All(cmd => cmd.Succeeded); }
            set 
            {
                foreach (var cmd in this)
                    cmd.Succeeded = value;
            }
        }
    }

    public class MoneyTransferCommand : CompositeBankAccountCommand
    {
        public MoneyTransferCommand(BankAccount from, BankAccount to, int amount)
        {
            AddRange(new[]
            {
                new BankAccountCommand(from, Action.Withdraw, amount),
                new BankAccountCommand(to, Action.Deposit, amount)
            });
        }

        public override void Call()
        {
            BankAccountCommand last = null;
            foreach (var cmd in this)
            {
                if (last == null || last.Succeeded)
                {
                    cmd.Call();
                    last = cmd;
                }
                else
                {
                    cmd.Undo();
                    break;
                }
            }
        }
    }
}
