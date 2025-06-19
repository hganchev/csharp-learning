using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.EventDriven
{
    /// <summary>
    /// Demonstrates Event-Driven Programming principles:
    /// - Events and Event Handlers: Objects communicate through events
    /// - Publisher-Subscriber Pattern: Loose coupling between event sources and handlers
    /// - Asynchronous Processing: Events can be handled asynchronously
    /// - Event Aggregation: Multiple events can be combined and managed centrally
    /// - State Changes: Events often represent state changes in the system
    /// </summary>
    
    // Custom EventArgs for different types of events
    public class OrderEventArgs : EventArgs
    {
        public string OrderId { get; }
        public string CustomerName { get; }
        public decimal Amount { get; }
        public DateTime Timestamp { get; }
        
        public OrderEventArgs(string orderId, string customerName, decimal amount)
        {
            OrderId = orderId;
            CustomerName = customerName;
            Amount = amount;
            Timestamp = DateTime.Now;
        }
    }
    
    public class InventoryEventArgs : EventArgs
    {
        public string ProductId { get; }
        public int Quantity { get; }
        public string Action { get; } // "Added", "Removed", "LowStock"
        public DateTime Timestamp { get; }
        
        public InventoryEventArgs(string productId, int quantity, string action)
        {
            ProductId = productId;
            Quantity = quantity;
            Action = action;
            Timestamp = DateTime.Now;
        }
    }
    
    public class UserEventArgs : EventArgs
    {
        public string UserId { get; }
        public string Action { get; } // "Login", "Logout", "ProfileUpdate"
        public string Details { get; }
        public DateTime Timestamp { get; }
        
        public UserEventArgs(string userId, string action, string details = "")
        {
            UserId = userId;
            Action = action;
            Details = details;
            Timestamp = DateTime.Now;
        }
    }
    
    // Publisher: E-commerce System that raises various events
    public class ECommerceSystem
    {
        // Event declarations
        public event EventHandler<OrderEventArgs>? OrderPlaced;
        public event EventHandler<OrderEventArgs>? OrderShipped;
        public event EventHandler<OrderEventArgs>? OrderCancelled;
        public event EventHandler<InventoryEventArgs>? InventoryChanged;
        public event EventHandler<UserEventArgs>? UserActivity;
        
        // Business methods that trigger events
        public void PlaceOrder(string orderId, string customerName, decimal amount)
        {
            Console.WriteLine($"Processing order {orderId} for {customerName}...");
            
            // Business logic here...
            
            // Raise event to notify all interested parties
            OrderPlaced?.Invoke(this, new OrderEventArgs(orderId, customerName, amount));
        }
        
        public void ShipOrder(string orderId, string customerName, decimal amount)
        {
            Console.WriteLine($"Shipping order {orderId}...");
            
            // Shipping logic here...
            
            OrderShipped?.Invoke(this, new OrderEventArgs(orderId, customerName, amount));
        }
        
        public void CancelOrder(string orderId, string customerName, decimal amount)
        {
            Console.WriteLine($"Cancelling order {orderId}...");
            
            // Cancellation logic here...
            
            OrderCancelled?.Invoke(this, new OrderEventArgs(orderId, customerName, amount));
        }
        
        public void UpdateInventory(string productId, int quantity, string action)
        {
            Console.WriteLine($"Inventory update: {action} {quantity} units of {productId}");
            
            // Inventory update logic here...
            
            InventoryChanged?.Invoke(this, new InventoryEventArgs(productId, quantity, action));
        }
        
        public void RecordUserActivity(string userId, string action, string details = "")
        {
            // User activity tracking...
            
            UserActivity?.Invoke(this, new UserEventArgs(userId, action, details));
        }
    }
    
    // Subscriber: Email Notification Service
    public class EmailNotificationService
    {
        private readonly string _serviceName = "Email Service";
        
        public void Subscribe(ECommerceSystem system)
        {
            // Subscribe to relevant events
            system.OrderPlaced += OnOrderPlaced;
            system.OrderShipped += OnOrderShipped;
            system.OrderCancelled += OnOrderCancelled;
            
            Console.WriteLine($"{_serviceName} subscribed to order events.");
        }
        
        public void Unsubscribe(ECommerceSystem system)
        {
            // Unsubscribe from events
            system.OrderPlaced -= OnOrderPlaced;
            system.OrderShipped -= OnOrderShipped;
            system.OrderCancelled -= OnOrderCancelled;
            
            Console.WriteLine($"{_serviceName} unsubscribed from order events.");
        }
        
        private void OnOrderPlaced(object? sender, OrderEventArgs e)
        {
            Console.WriteLine($"📧 {_serviceName}: Sending order confirmation email to {e.CustomerName}");
            Console.WriteLine($"   Order ID: {e.OrderId}, Amount: ${e.Amount:F2}");
        }
        
        private void OnOrderShipped(object? sender, OrderEventArgs e)
        {
            Console.WriteLine($"📧 {_serviceName}: Sending shipping notification to {e.CustomerName}");
            Console.WriteLine($"   Order {e.OrderId} is on its way!");
        }
        
        private void OnOrderCancelled(object? sender, OrderEventArgs e)
        {
            Console.WriteLine($"📧 {_serviceName}: Sending cancellation notification to {e.CustomerName}");
            Console.WriteLine($"   Order {e.OrderId} has been cancelled.");
        }
    }
    
    // Subscriber: Inventory Management Service
    public class InventoryManagementService
    {
        private readonly Dictionary<string, int> _stockLevels = new();
        private readonly string _serviceName = "Inventory Service";
        
        public void Subscribe(ECommerceSystem system)
        {
            system.OrderPlaced += OnOrderPlaced;
            system.InventoryChanged += OnInventoryChanged;
            
            Console.WriteLine($"{_serviceName} subscribed to inventory events.");
        }
        
        private void OnOrderPlaced(object? sender, OrderEventArgs e)
        {
            // Simulate inventory reduction when order is placed
            Console.WriteLine($"📦 {_serviceName}: Reducing inventory for order {e.OrderId}");
            
            // Check if stock is low after order
            if (IsStockLow("PRODUCT_001"))
            {
                var eCommerceSystem = sender as ECommerceSystem;
                eCommerceSystem?.UpdateInventory("PRODUCT_001", GetStockLevel("PRODUCT_001"), "LowStock");
            }
        }
        
        private void OnInventoryChanged(object? sender, InventoryEventArgs e)
        {
            Console.WriteLine($"📦 {_serviceName}: Inventory change detected for {e.ProductId}");
            
            switch (e.Action)
            {
                case "Added":
                    AddStock(e.ProductId, e.Quantity);
                    break;
                case "Removed":
                    RemoveStock(e.ProductId, e.Quantity);
                    break;
                case "LowStock":
                    HandleLowStock(e.ProductId, e.Quantity);
                    break;
            }
        }
        
        private void AddStock(string productId, int quantity)
        {
            _stockLevels[productId] = _stockLevels.GetValueOrDefault(productId, 0) + quantity;
            Console.WriteLine($"   Added {quantity} units. New stock: {_stockLevels[productId]}");
        }
        
        private void RemoveStock(string productId, int quantity)
        {
            int currentStock = _stockLevels.GetValueOrDefault(productId, 0);
            _stockLevels[productId] = Math.Max(0, currentStock - quantity);
            Console.WriteLine($"   Removed {quantity} units. New stock: {_stockLevels[productId]}");
        }
        
        private void HandleLowStock(string productId, int currentQuantity)
        {
            Console.WriteLine($"   ⚠️ LOW STOCK ALERT for {productId}: Only {currentQuantity} units remaining!");
            Console.WriteLine($"   Initiating automatic reorder process...");
        }
        
        private bool IsStockLow(string productId) => GetStockLevel(productId) < 10;
        private int GetStockLevel(string productId) => _stockLevels.GetValueOrDefault(productId, 50);
    }
    
    // Subscriber: Analytics Service
    public class AnalyticsService
    {
        private readonly List<OrderEventArgs> _orderHistory = new();
        private readonly List<UserEventArgs> _userActivityLog = new();
        private readonly string _serviceName = "Analytics Service";
        
        public void Subscribe(ECommerceSystem system)
        {
            system.OrderPlaced += OnOrderPlaced;
            system.OrderShipped += OnOrderShipped;
            system.OrderCancelled += OnOrderCancelled;
            system.UserActivity += OnUserActivity;
            
            Console.WriteLine($"{_serviceName} subscribed to all events.");
        }
        
        private void OnOrderPlaced(object? sender, OrderEventArgs e)
        {
            _orderHistory.Add(e);
            Console.WriteLine($"📊 {_serviceName}: Recording order placement metrics");
            GenerateRealTimeStats();
        }
        
        private void OnOrderShipped(object? sender, OrderEventArgs e)
        {
            Console.WriteLine($"📊 {_serviceName}: Recording shipping metrics for order {e.OrderId}");
        }
        
        private void OnOrderCancelled(object? sender, OrderEventArgs e)
        {
            Console.WriteLine($"📊 {_serviceName}: Recording cancellation metrics for order {e.OrderId}");
        }
        
        private void OnUserActivity(object? sender, UserEventArgs e)
        {
            _userActivityLog.Add(e);
            Console.WriteLine($"📊 {_serviceName}: Tracking user {e.UserId} activity: {e.Action}");
        }
        
        private void GenerateRealTimeStats()
        {
            decimal totalRevenue = _orderHistory.Sum(o => o.Amount);
            int orderCount = _orderHistory.Count;
            decimal averageOrderValue = orderCount > 0 ? totalRevenue / orderCount : 0;
            
            Console.WriteLine($"   Current stats: {orderCount} orders, ${totalRevenue:F2} revenue, ${averageOrderValue:F2} avg order");
        }
        
        public void GenerateReport()
        {
            Console.WriteLine($"\n=== {_serviceName} Report ===");
            Console.WriteLine($"Total Orders: {_orderHistory.Count}");
            Console.WriteLine($"Total Revenue: ${_orderHistory.Sum(o => o.Amount):F2}");
            Console.WriteLine($"User Activities Tracked: {_userActivityLog.Count}");
        }
    }
    
    // Event Aggregator for managing multiple event sources
    public class EventAggregator
    {
        private readonly List<ECommerceSystem> _eventSources = new();
        private readonly List<object> _subscribers = new();
        
        public void RegisterEventSource(ECommerceSystem source)
        {
            _eventSources.Add(source);
            
            // Subscribe all existing subscribers to the new source
            foreach (var subscriber in _subscribers)
            {
                SubscribeToSource(subscriber, source);
            }
        }
        
        public void RegisterSubscriber(object subscriber)
        {
            _subscribers.Add(subscriber);
            
            // Subscribe to all existing sources
            foreach (var source in _eventSources)
            {
                SubscribeToSource(subscriber, source);
            }
        }
        
        private void SubscribeToSource(object subscriber, ECommerceSystem source)
        {
            switch (subscriber)
            {
                case EmailNotificationService emailService:
                    emailService.Subscribe(source);
                    break;
                case InventoryManagementService inventoryService:
                    inventoryService.Subscribe(source);
                    break;
                case AnalyticsService analyticsService:
                    analyticsService.Subscribe(source);
                    break;
            }
        }
    }
    
    // Demonstration class
    public static class EventDrivenDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("=== Event-Driven Programming Demo ===\n");
            
            // Create the main system (publisher)
            var ecommerceSystem = new ECommerceSystem();
            
            // Create services (subscribers)
            var emailService = new EmailNotificationService();
            var inventoryService = new InventoryManagementService();
            var analyticsService = new AnalyticsService();
            
            // Subscribe services to system events
            emailService.Subscribe(ecommerceSystem);
            inventoryService.Subscribe(ecommerceSystem);
            analyticsService.Subscribe(ecommerceSystem);
            
            Console.WriteLine("\n--- Simulating Business Operations ---\n");
            
            // Simulate user activity
            ecommerceSystem.RecordUserActivity("USER_001", "Login", "Web browser");
            
            // Simulate order placement (this will trigger multiple event handlers)
            ecommerceSystem.PlaceOrder("ORD_001", "Alice Johnson", 299.99m);
            
            Console.WriteLine();
            
            // Simulate inventory update
            ecommerceSystem.UpdateInventory("PRODUCT_001", 5, "Added");
            
            Console.WriteLine();
            
            // Simulate order shipping
            ecommerceSystem.ShipOrder("ORD_001", "Alice Johnson", 299.99m);
            
            Console.WriteLine();
            
            // Place another order
            ecommerceSystem.PlaceOrder("ORD_002", "Bob Smith", 149.50m);
            
            Console.WriteLine();
            
            // Simulate order cancellation
            ecommerceSystem.CancelOrder("ORD_002", "Bob Smith", 149.50m);
            
            Console.WriteLine();
            
            // Generate final analytics report
            analyticsService.GenerateReport();
            
            Console.WriteLine("\n--- Event-Driven Demo Complete ---");
        }
    }
}