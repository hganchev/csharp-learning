using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes
{
    /// <summary>
    /// Shopping cart demonstrating TDD with business rules, discounts, and validation
    /// </summary>
    public class ShoppingCart
    {
        private readonly Dictionary<Product, int> _items;
        private readonly List<IDiscount> _discounts;

        public ShoppingCart()
        {
            _items = new Dictionary<Product, int>();
            _discounts = new List<IDiscount>();
        }

        public IReadOnlyDictionary<Product, int> Items => _items;
        public int TotalItemCount => _items.Sum(item => item.Value);

        public void AddItem(Product product, int quantity = 1)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive");

            if (_items.ContainsKey(product))
            {
                _items[product] += quantity;
            }
            else
            {
                _items[product] = quantity;
            }
        }

        public void RemoveItem(Product product, int quantity = 1)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive");

            if (!_items.ContainsKey(product))
                throw new InvalidOperationException("Product not found in cart");

            if (_items[product] < quantity)
                throw new InvalidOperationException("Cannot remove more items than available");

            _items[product] -= quantity;
            
            if (_items[product] == 0)
            {
                _items.Remove(product);
            }
        }

        public void ClearCart()
        {
            _items.Clear();
        }

        public decimal GetSubtotal()
        {
            return _items.Sum(item => item.Key.Price * item.Value);
        }

        public decimal GetTotal()
        {
            var subtotal = GetSubtotal();
            var discountAmount = _discounts.Sum(discount => discount.CalculateDiscount(this, subtotal));
            return Math.Max(0, subtotal - discountAmount);
        }

        public void ApplyDiscount(IDiscount discount)
        {
            if (discount == null)
                throw new ArgumentNullException(nameof(discount));

            _discounts.Add(discount);
        }

        public void RemoveDiscount(IDiscount discount)
        {
            _discounts.Remove(discount);
        }

        public bool IsEmpty => _items.Count == 0;

        public bool HasProduct(Product product)
        {
            return _items.ContainsKey(product);
        }

        public int GetQuantity(Product product)
        {
            return _items.TryGetValue(product, out int quantity) ? quantity : 0;
        }
    }

    public class Product
    {
        public Product(string name, decimal price, string category = "General")
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be null or empty");
            
            if (price < 0)
                throw new ArgumentException("Product price cannot be negative");

            Name = name;
            Price = price;
            Category = category ?? "General";
        }

        public string Name { get; }
        public decimal Price { get; }
        public string Category { get; }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Name == product.Name &&
                   Price == product.Price &&
                   Category == product.Category;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price, Category);
        }

        public override string ToString()
        {
            return $"{Name} - {Price:C} ({Category})";
        }
    }

    public interface IDiscount
    {
        string Name { get; }
        decimal CalculateDiscount(ShoppingCart cart, decimal subtotal);
    }

    public class PercentageDiscount : IDiscount
    {
        public PercentageDiscount(string name, decimal percentage)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Discount name cannot be null or empty");
            
            if (percentage < 0 || percentage > 100)
                throw new ArgumentException("Percentage must be between 0 and 100");

            Name = name;
            Percentage = percentage;
        }

        public string Name { get; }
        public decimal Percentage { get; }

        public decimal CalculateDiscount(ShoppingCart cart, decimal subtotal)
        {
            return subtotal * (Percentage / 100);
        }
    }

    public class FixedAmountDiscount : IDiscount
    {
        public FixedAmountDiscount(string name, decimal amount)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Discount name cannot be null or empty");
            
            if (amount < 0)
                throw new ArgumentException("Discount amount cannot be negative");

            Name = name;
            Amount = amount;
        }

        public string Name { get; }
        public decimal Amount { get; }

        public decimal CalculateDiscount(ShoppingCart cart, decimal subtotal)
        {
            return Math.Min(Amount, subtotal);
        }
    }

    public class BuyXGetYFreeDiscount : IDiscount
    {
        public BuyXGetYFreeDiscount(string name, Product product, int buyQuantity, int freeQuantity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Discount name cannot be null or empty");
            
            Name = name;
            Product = product ?? throw new ArgumentNullException(nameof(product));
            BuyQuantity = buyQuantity > 0 ? buyQuantity : throw new ArgumentException("Buy quantity must be positive");
            FreeQuantity = freeQuantity > 0 ? freeQuantity : throw new ArgumentException("Free quantity must be positive");
        }

        public string Name { get; }
        public Product Product { get; }
        public int BuyQuantity { get; }
        public int FreeQuantity { get; }

        public decimal CalculateDiscount(ShoppingCart cart, decimal subtotal)
        {
            if (!cart.HasProduct(Product))
                return 0;

            var quantity = cart.GetQuantity(Product);
            var eligibleSets = quantity / (BuyQuantity + FreeQuantity);
            var freeItems = eligibleSets * FreeQuantity;
            
            return freeItems * Product.Price;
        }
    }
}
