using System;
using System.Collections.Generic;

namespace Classes
{
    /// <summary>
    /// Bank account class demonstrating TDD with business rules and state management
    /// </summary>
    public class BankAccount
    {
        private decimal _balance;
        private readonly List<Transaction> _transactions;
        private readonly string _accountNumber;
        private bool _isActive;

        public BankAccount(string accountNumber, decimal initialBalance = 0)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentException("Account number cannot be null or empty");
            
            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative");

            _accountNumber = accountNumber;
            _balance = initialBalance;
            _transactions = new List<Transaction>();
            _isActive = true;

            if (initialBalance > 0)
            {
                _transactions.Add(new Transaction(TransactionType.Deposit, initialBalance, "Initial deposit"));
            }
        }

        public string AccountNumber => _accountNumber;
        public decimal Balance => _balance;
        public bool IsActive => _isActive;
        public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();

        public void Deposit(decimal amount, string description = "")
        {
            if (!_isActive)
                throw new InvalidOperationException("Cannot perform transactions on inactive account");
            
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive");

            _balance += amount;
            _transactions.Add(new Transaction(TransactionType.Deposit, amount, description));
        }

        public void Withdraw(decimal amount, string description = "")
        {
            if (!_isActive)
                throw new InvalidOperationException("Cannot perform transactions on inactive account");
            
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive");

            if (amount > _balance)
                throw new InvalidOperationException("Insufficient funds");

            _balance -= amount;
            _transactions.Add(new Transaction(TransactionType.Withdrawal, amount, description));
        }

        public void Transfer(BankAccount destinationAccount, decimal amount, string description = "")
        {
            if (destinationAccount == null)
                throw new ArgumentNullException(nameof(destinationAccount));

            if (!destinationAccount.IsActive)
                throw new InvalidOperationException("Cannot transfer to inactive account");

            // Withdraw from this account
            Withdraw(amount, $"Transfer to {destinationAccount.AccountNumber}: {description}");
            
            // Deposit to destination account
            destinationAccount.Deposit(amount, $"Transfer from {_accountNumber}: {description}");
        }

        public void CloseAccount()
        {
            if (_balance != 0)
                throw new InvalidOperationException("Cannot close account with non-zero balance");

            _isActive = false;
        }

        public decimal CalculateInterest(decimal interestRate, int days)
        {
            if (interestRate < 0)
                throw new ArgumentException("Interest rate cannot be negative");
            
            if (days < 0)
                throw new ArgumentException("Days cannot be negative");

            // Simple interest calculation: (Principal * Rate * Time) / 365
            return (_balance * interestRate * days) / 365;
        }
    }

    public class Transaction
    {
        public Transaction(TransactionType type, decimal amount, string description)
        {
            Type = type;
            Amount = amount;
            Description = description ?? string.Empty;
            Timestamp = DateTime.UtcNow;
        }

        public TransactionType Type { get; }
        public decimal Amount { get; }
        public string Description { get; }
        public DateTime Timestamp { get; }

        public override string ToString()
        {
            return $"{Timestamp:yyyy-MM-dd HH:mm:ss} - {Type}: {Amount:C} - {Description}";
        }
    }

    public enum TransactionType
    {
        Deposit,
        Withdrawal
    }
}
