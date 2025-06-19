using System;
using Xunit;
using Classes;

namespace UnitTest
{
    public class UnitTest_BankAccount
    {
        [Fact]
        public void Constructor_WithValidAccountNumber_CreatesAccountSuccessfully()
        {
            // Arrange
            string accountNumber = "123456789";
            decimal initialBalance = 100m;

            // Act
            var account = new BankAccount(accountNumber, initialBalance);

            // Assert
            Assert.Equal(accountNumber, account.AccountNumber);
            Assert.Equal(initialBalance, account.Balance);
            Assert.True(account.IsActive);
            Assert.Single(account.Transactions); // Initial deposit transaction
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Constructor_WithInvalidAccountNumber_ThrowsArgumentException(string accountNumber)
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new BankAccount(accountNumber));
        }

        [Fact]
        public void Constructor_WithNegativeInitialBalance_ThrowsArgumentException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new BankAccount("123456789", -100m));
        }

        [Fact]
        public void Deposit_WithValidAmount_IncreasesBalance()
        {
            // Arrange
            var account = new BankAccount("123456789", 100m);
            decimal depositAmount = 50m;
            decimal expectedBalance = 150m;

            // Act
            account.Deposit(depositAmount, "Test deposit");

            // Assert
            Assert.Equal(expectedBalance, account.Balance);
            Assert.Equal(2, account.Transactions.Count); // Initial + deposit
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void Deposit_WithInvalidAmount_ThrowsArgumentException(decimal amount)
        {
            // Arrange
            var account = new BankAccount("123456789", 100m);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.Deposit(amount));
        }

        [Fact]
        public void Withdraw_WithValidAmount_DecreasesBalance()
        {
            // Arrange
            var account = new BankAccount("123456789", 100m);
            decimal withdrawAmount = 30m;
            decimal expectedBalance = 70m;

            // Act
            account.Withdraw(withdrawAmount, "Test withdrawal");

            // Assert
            Assert.Equal(expectedBalance, account.Balance);
            Assert.Equal(2, account.Transactions.Count);
        }

        [Fact]
        public void Withdraw_WithInsufficientFunds_ThrowsInvalidOperationException()
        {
            // Arrange
            var account = new BankAccount("123456789", 50m);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(100m));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void Withdraw_WithInvalidAmount_ThrowsArgumentException(decimal amount)
        {
            // Arrange
            var account = new BankAccount("123456789", 100m);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.Withdraw(amount));
        }

        [Fact]
        public void Transfer_WithValidAmountAndActiveDestination_CompletesSuccessfully()
        {
            // Arrange
            var sourceAccount = new BankAccount("123456789", 100m);
            var destinationAccount = new BankAccount("987654321", 50m);
            decimal transferAmount = 30m;

            // Act
            sourceAccount.Transfer(destinationAccount, transferAmount, "Test transfer");

            // Assert
            Assert.Equal(70m, sourceAccount.Balance);
            Assert.Equal(80m, destinationAccount.Balance);
        }

        [Fact]
        public void Transfer_WithNullDestination_ThrowsArgumentNullException()
        {
            // Arrange
            var account = new BankAccount("123456789", 100m);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => account.Transfer(null, 50m));
        }

        [Fact]
        public void Transfer_ToInactiveAccount_ThrowsInvalidOperationException()
        {
            // Arrange
            var sourceAccount = new BankAccount("123456789", 100m);
            var destinationAccount = new BankAccount("987654321", 0m);
            destinationAccount.CloseAccount();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => sourceAccount.Transfer(destinationAccount, 50m));
        }

        [Fact]
        public void CloseAccount_WithZeroBalance_ClosesSuccessfully()
        {
            // Arrange
            var account = new BankAccount("123456789", 0m);

            // Act
            account.CloseAccount();

            // Assert
            Assert.False(account.IsActive);
        }

        [Fact]
        public void CloseAccount_WithNonZeroBalance_ThrowsInvalidOperationException()
        {
            // Arrange
            var account = new BankAccount("123456789", 100m);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => account.CloseAccount());
        }

        [Fact]
        public void Deposit_OnInactiveAccount_ThrowsInvalidOperationException()
        {
            // Arrange
            var account = new BankAccount("123456789", 0m);
            account.CloseAccount();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => account.Deposit(50m));
        }

        [Theory]
        [InlineData(1000, 0.05, 30, 4.11)] // $1000 at 5% for 30 days
        [InlineData(500, 0.03, 365, 15)] // $500 at 3% for 1 year
        [InlineData(0, 0.05, 30, 0)] // No balance
        public void CalculateInterest_WithValidInputs_ReturnsCorrectAmount(decimal balance, decimal rate, int days, decimal expected)
        {
            // Arrange
            var account = new BankAccount("123456789", balance);

            // Act
            decimal interest = account.CalculateInterest(rate, days);

            // Assert
            Assert.Equal(expected, interest, 2); // 2 decimal places precision
        }

        [Fact]
        public void CalculateInterest_WithNegativeRate_ThrowsArgumentException()
        {
            // Arrange
            var account = new BankAccount("123456789", 100m);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.CalculateInterest(-0.01m, 30));
        }

        [Fact]
        public void CalculateInterest_WithNegativeDays_ThrowsArgumentException()
        {
            // Arrange
            var account = new BankAccount("123456789", 100m);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.CalculateInterest(0.05m, -1));
        }
    }
}
