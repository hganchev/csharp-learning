# C# Test Driven Development (TDD) Examples

This repository demonstrates comprehensive Test Driven Development (TDD) practices in C# using xUnit testing framework. The project showcases real-world examples of TDD principles with proper test organization, mocking, and business logic validation.

## 🎯 Project Overview

This project contains multiple examples of TDD implementation:

1. **Calculator** - Basic mathematical operations with proper error handling
2. **BankAccount** - Business domain example with state management and transactions
3. **ShoppingCart** - Complex business logic with discounts and product management
4. **SQLQueries** - Data access layer testing with mocking

## 🧪 TDD Principles Demonstrated

### Red-Green-Refactor Cycle
- **Red**: Write failing tests first
- **Green**: Write minimal code to make tests pass
- **Refactor**: Improve code while keeping tests green

### Testing Best Practices
- **AAA Pattern**: Arrange, Act, Assert
- **Theory Tests**: Data-driven testing with multiple inputs
- **Exception Testing**: Validating error conditions
- **Mocking**: Isolating units under test from dependencies
- **Test Organization**: Logical grouping and clear naming

## 📁 Project Structure

```
├── Classes/
│   ├── Calculator.cs          # Mathematical operations with validation
│   ├── BankAccount.cs         # Banking domain with business rules
│   ├── ShoppingCart.cs        # E-commerce cart with discount system
│   └── SQLQueries.cs          # Data access with dependency injection
├── UnitTests/
│   ├── UnitTest_Calc.cs       # Calculator tests with comprehensive coverage
│   ├── UnitTest_BankAccount.cs # Bank account business logic tests
│   ├── UnitTest_ShoppingCart.cs # Shopping cart functionality tests
│   ├── UnitTest_SQL.cs        # SQL operations with mocking
│   └── Usings.cs              # Global using directives
└── README.md
```

## 🏗️ Classes Overview

### Calculator Class
**Purpose**: Demonstrates basic TDD with mathematical operations

**Features**:
- Basic arithmetic operations (Add, Subtract, Multiply, Divide)
- Advanced operations (Power, SquareRoot)
- Number type checking (IsOdd, IsEven)
- Input validation and error handling
- Overflow and infinity checks

**TDD Concepts**:
- Theory-based testing with multiple data sets
- Exception testing for edge cases
- Precision handling for floating-point operations

### BankAccount Class
**Purpose**: Real-world business domain example with state management

**Features**:
- Account creation with validation
- Deposit and withdrawal operations
- Transfer between accounts
- Transaction history tracking
- Interest calculation
- Account lifecycle management

**TDD Concepts**:
- State-based testing
- Business rule validation
- Transaction integrity
- Error condition handling

### ShoppingCart Class
**Purpose**: Complex business logic with multiple interacting components

**Features**:
- Product management (add, remove, clear)
- Multiple discount types:
  - Percentage discounts
  - Fixed amount discounts
  - Buy X Get Y Free promotions
- Subtotal and total calculations
- Inventory tracking

**TDD Concepts**:
- Object collaboration testing
- Strategy pattern implementation
- Complex business rule validation
- Interface-based design

### SQLQueries Class
**Purpose**: Data access layer testing with dependency injection

**Features**:
- Database connection abstraction
- Parameterized queries
- Result processing
- Configurable connection settings

**TDD Concepts**:
- Dependency injection for testability
- Mocking external dependencies
- Data access pattern testing
- Integration testing principles

## 🧪 Test Examples

### Unit Tests (Fact)
```csharp
[Fact]
public void Add_WithPositiveNumbers_ReturnsCorrectSum()
{
    // Arrange
    double x = 5;
    double y = 5;
    double expected = 10;

    // Act
    double result = _calculator.Add(x, y);

    // Assert
    Assert.Equal(expected, result);
}
```

### Theory Tests (Data-Driven)
```csharp
[Theory]
[InlineData(8, 4, 2)]
[InlineData(5, 2, 2.5)]
[InlineData(10, 2, 5)]
public void Divide_WithValidInputs_ReturnsCorrectQuotient(double dividend, double divisor, double expected)
{
    // Act
    double result = _calculator.Divide(dividend, divisor);

    // Assert
    Assert.Equal(expected, result, 10);
}
```

### Exception Testing
```csharp
[Fact]
public void Divide_ByZero_ThrowsDivideByZeroException()
{
    // Arrange & Act & Assert
    Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
}
```

### Mocking Example
```csharp
[Fact]
public void TestCheckNameExist()
{
    // Arrange
    sqlReaderMock.SetupSequence(_ => _.Read())
        .Returns(true)
        .Returns(false);
    commandMock.Setup(m => m.ExecuteReader()).Returns(sqlReaderMock.Object);
    
    // Act
    bool result = Classes.SQLQueries.CheckNameExist("John");
    
    // Assert
    Assert.True(result);
    commandMock.Verify();
}
```

## 🚀 Getting Started

### Prerequisites
- .NET 6.0 or later
- Visual Studio 2022 or Visual Studio Code
- xUnit test runner

### Running the Tests
1. Clone the repository
2. Open the solution in Visual Studio or VS Code
3. Build the solution
4. Run tests using Test Explorer or command line:
   ```bash
   dotnet test
   ```

### Building the Project
```bash
dotnet build
```

## 📚 Key TDD Concepts Covered

1. **Test First Development**: Writing tests before implementation
2. **Red-Green-Refactor**: The core TDD cycle
3. **Test Organization**: Grouping related tests and clear naming
4. **Data-Driven Testing**: Using Theory attributes for multiple test cases
5. **Exception Testing**: Validating error conditions and edge cases
6. **Mocking and Stubbing**: Isolating units under test
7. **State vs. Behavior Testing**: Different approaches to validation
8. **Test Maintainability**: Writing tests that are easy to understand and modify

## 🎓 Learning Outcomes

By studying this project, you will learn:
- How to apply TDD principles in real-world scenarios
- Best practices for unit test organization and naming
- Proper use of xUnit features (Facts, Theories, Assertions)
- Mocking strategies for external dependencies
- Business logic validation through comprehensive testing
- Error handling and edge case testing
- Code design that supports testability

## 🤝 Contributing

Feel free to contribute by:
- Adding more TDD examples
- Improving existing test coverage
- Adding documentation and comments
- Suggesting better testing practices

## 📖 Additional Resources

- [xUnit Documentation](https://xunit.net/)
- [TDD Best Practices](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices)
- [Moq Framework](https://github.com/moq/moq4)
- [Test Driven Development by Kent Beck](https://www.amazon.com/Test-Driven-Development-Kent-Beck/dp/0321146530)
