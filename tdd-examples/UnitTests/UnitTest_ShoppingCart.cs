using System;
using System.Linq;
using Xunit;
using Classes;

namespace UnitTest
{
    public class UnitTest_ShoppingCart
    {
        private readonly Product _testProduct1;
        private readonly Product _testProduct2;

        public UnitTest_ShoppingCart()
        {
            _testProduct1 = new Product("Laptop", 999.99m, "Electronics");
            _testProduct2 = new Product("Mouse", 29.99m, "Electronics");
        }

        [Fact]
        public void Constructor_CreatesEmptyCart()
        {
            // Act
            var cart = new ShoppingCart();

            // Assert
            Assert.True(cart.IsEmpty);
            Assert.Equal(0, cart.TotalItemCount);
            Assert.Equal(0m, cart.GetSubtotal());
        }

        [Fact]
        public void AddItem_WithValidProduct_AddsToCart()
        {
            // Arrange
            var cart = new ShoppingCart();

            // Act
            cart.AddItem(_testProduct1, 2);

            // Assert
            Assert.False(cart.IsEmpty);
            Assert.Equal(2, cart.TotalItemCount);
            Assert.True(cart.HasProduct(_testProduct1));
            Assert.Equal(2, cart.GetQuantity(_testProduct1));
        }

        [Fact]
        public void AddItem_WithNullProduct_ThrowsArgumentNullException()
        {
            // Arrange
            var cart = new ShoppingCart();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => cart.AddItem(null));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void AddItem_WithInvalidQuantity_ThrowsArgumentException(int quantity)
        {
            // Arrange
            var cart = new ShoppingCart();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => cart.AddItem(_testProduct1, quantity));
        }

        [Fact]
        public void AddItem_SameProductTwice_IncreasesQuantity()
        {
            // Arrange
            var cart = new ShoppingCart();
            cart.AddItem(_testProduct1, 2);

            // Act
            cart.AddItem(_testProduct1, 3);

            // Assert
            Assert.Equal(5, cart.GetQuantity(_testProduct1));
            Assert.Equal(5, cart.TotalItemCount);
        }

        [Fact]
        public void RemoveItem_WithValidQuantity_DecreasesQuantity()
        {
            // Arrange
            var cart = new ShoppingCart();
            cart.AddItem(_testProduct1, 5);

            // Act
            cart.RemoveItem(_testProduct1, 2);

            // Assert
            Assert.Equal(3, cart.GetQuantity(_testProduct1));
            Assert.Equal(3, cart.TotalItemCount);
        }

        [Fact]
        public void RemoveItem_WithExactQuantity_RemovesProductFromCart()
        {
            // Arrange
            var cart = new ShoppingCart();
            cart.AddItem(_testProduct1, 3);

            // Act
            cart.RemoveItem(_testProduct1, 3);

            // Assert
            Assert.False(cart.HasProduct(_testProduct1));
            Assert.Equal(0, cart.GetQuantity(_testProduct1));
            Assert.True(cart.IsEmpty);
        }

        [Fact]
        public void RemoveItem_MoreThanAvailable_ThrowsInvalidOperationException()
        {
            // Arrange
            var cart = new ShoppingCart();
            cart.AddItem(_testProduct1, 2);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => cart.RemoveItem(_testProduct1, 5));
        }

        [Fact]
        public void RemoveItem_ProductNotInCart_ThrowsInvalidOperationException()
        {
            // Arrange
            var cart = new ShoppingCart();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => cart.RemoveItem(_testProduct1));
        }

        [Fact]
        public void GetSubtotal_WithMultipleProducts_ReturnsCorrectTotal()
        {
            // Arrange
            var cart = new ShoppingCart();
            cart.AddItem(_testProduct1, 2); // 2 * 999.99 = 1999.98
            cart.AddItem(_testProduct2, 3); // 3 * 29.99 = 89.97
            decimal expected = 2089.95m;

            // Act
            decimal subtotal = cart.GetSubtotal();

            // Assert
            Assert.Equal(expected, subtotal);
        }

        [Fact]
        public void GetTotal_WithoutDiscounts_EqualsSubtotal()
        {
            // Arrange
            var cart = new ShoppingCart();
            cart.AddItem(_testProduct1, 1);

            // Act
            decimal total = cart.GetTotal();
            decimal subtotal = cart.GetSubtotal();

            // Assert
            Assert.Equal(subtotal, total);
        }

        [Fact]
        public void ApplyDiscount_WithPercentageDiscount_ReducesTotal()
        {
            // Arrange
            var cart = new ShoppingCart();
            cart.AddItem(_testProduct1, 1); // 999.99
            var discount = new PercentageDiscount("10% Off", 10m);
            decimal expectedTotal = 899.99m; // 999.99 - (999.99 * 0.10)

            // Act
            cart.ApplyDiscount(discount);
            decimal total = cart.GetTotal();

            // Assert
            Assert.Equal(expectedTotal, total, 2);
        }

        [Fact]
        public void ApplyDiscount_WithFixedAmountDiscount_ReducesTotal()
        {
            // Arrange
            var cart = new ShoppingCart();
            cart.AddItem(_testProduct1, 1); // 999.99
            var discount = new FixedAmountDiscount("$50 Off", 50m);
            decimal expectedTotal = 949.99m;

            // Act
            cart.ApplyDiscount(discount);
            decimal total = cart.GetTotal();

            // Assert
            Assert.Equal(expectedTotal, total);
        }

        [Fact]
        public void ApplyDiscount_WithBuyXGetYFreeDiscount_ReducesTotal()
        {
            // Arrange
            var cart = new ShoppingCart();
            cart.AddItem(_testProduct2, 3); // Buy 2 get 1 free scenario
            var discount = new BuyXGetYFreeDiscount("Buy 2 Get 1 Free", _testProduct2, 2, 1);
            decimal expectedTotal = 59.98m; // 2 * 29.99 (1 free)

            // Act
            cart.ApplyDiscount(discount);
            decimal total = cart.GetTotal();

            // Assert
            Assert.Equal(expectedTotal, total);
        }

        [Fact]
        public void ClearCart_RemovesAllItems()
        {
            // Arrange
            var cart = new ShoppingCart();
            cart.AddItem(_testProduct1, 2);
            cart.AddItem(_testProduct2, 3);

            // Act
            cart.ClearCart();

            // Assert
            Assert.True(cart.IsEmpty);
            Assert.Equal(0, cart.TotalItemCount);
            Assert.Equal(0m, cart.GetSubtotal());
        }

        [Fact]
        public void GetQuantity_ForProductNotInCart_ReturnsZero()
        {
            // Arrange
            var cart = new ShoppingCart();

            // Act
            int quantity = cart.GetQuantity(_testProduct1);

            // Assert
            Assert.Equal(0, quantity);
        }

        [Fact]
        public void Product_Constructor_WithValidData_CreatesProductSuccessfully()
        {
            // Arrange
            string name = "Test Product";
            decimal price = 19.99m;
            string category = "Test Category";

            // Act
            var product = new Product(name, price, category);

            // Assert
            Assert.Equal(name, product.Name);
            Assert.Equal(price, product.Price);
            Assert.Equal(category, product.Category);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Product_Constructor_WithInvalidName_ThrowsArgumentException(string name)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Product(name, 10m));
        }

        [Fact]
        public void Product_Constructor_WithNegativePrice_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Product("Test", -1m));
        }

        [Fact]
        public void PercentageDiscount_Constructor_WithValidData_CreatesDiscountSuccessfully()
        {
            // Arrange & Act
            var discount = new PercentageDiscount("10% Off", 10m);

            // Assert
            Assert.Equal("10% Off", discount.Name);
            Assert.Equal(10m, discount.Percentage);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(101)]
        public void PercentageDiscount_Constructor_WithInvalidPercentage_ThrowsArgumentException(decimal percentage)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new PercentageDiscount("Test", percentage));
        }

        [Fact]
        public void FixedAmountDiscount_Constructor_WithNegativeAmount_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FixedAmountDiscount("Test", -10m));
        }

        [Fact]
        public void BuyXGetYFreeDiscount_CalculateDiscount_WithEligibleItems_ReturnsCorrectDiscount()
        {
            // Arrange
            var cart = new ShoppingCart();
            cart.AddItem(_testProduct2, 5); // 5 items at 29.99 each
            var discount = new BuyXGetYFreeDiscount("Buy 2 Get 1 Free", _testProduct2, 2, 1);
            decimal expectedDiscount = 29.99m; // 1 free item

            // Act
            decimal discountAmount = discount.CalculateDiscount(cart, cart.GetSubtotal());

            // Assert
            Assert.Equal(expectedDiscount, discountAmount);
        }
    }
}
