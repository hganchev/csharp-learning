using System;
using System.Collections.Generic;

namespace SOLID
{
    /// <summary>
    /// DIP - Dependency Inversion Principle
    /// Definition: 
    /// 1. High-level modules should not depend on low-level modules. Both should depend on abstractions.
    /// 2. Abstractions should not depend on details. Details should depend on abstractions.
    /// </summary>
    class DIP
    {
        public DIP()
        {
            Console.WriteLine("=== Dependency Inversion Principle (DIP) ===");
            Console.WriteLine("High-level modules should not depend on low-level modules. Both should depend on abstractions.\n");

            // Problem Example - Violating DIP
            Console.WriteLine("PROBLEM - Violating DIP:");
            var problemService = new OrderServiceProblem();
            problemService.ProcessOrder("Order #123");
            Console.WriteLine("The OrderService is tightly coupled to specific implementations!\n");

            // Solution Example - Following DIP
            Console.WriteLine("SOLUTION - Following DIP:");
            
            // We can easily switch implementations without changing the high-level code
            var emailNotifier = new EmailNotifier();
            var sqlRepository = new SqlOrderRepository();
            var orderService1 = new OrderService(sqlRepository, emailNotifier);
            orderService1.ProcessOrder("Order #456");
            
            Console.WriteLine();
            
            // Same service with different implementations
            var smsNotifier = new SmsNotifier();
            var mongoRepository = new MongoOrderRepository();
            var orderService2 = new OrderService(mongoRepository, smsNotifier);
            orderService2.ProcessOrder("Order #789");
        }
    }

    #region Problem - Violating DIP
    /// <summary>
    /// PROBLEM: High-level OrderServiceProblem directly depends on low-level concrete classes.
    /// This creates tight coupling and makes testing/maintenance difficult.
    /// </summary>
    
    // Low-level modules (concrete implementations)
    class EmailServiceProblem
    {
        public void SendEmail(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    class DatabaseServiceProblem
    {
        public void SaveToDatabase(string data)
        {
            Console.WriteLine($"Saved to SQL database: {data}");
        }
    }

    // High-level module that violates DIP
    class OrderServiceProblem
    {
        // Directly depends on concrete low-level classes (VIOLATION!)
        private readonly EmailServiceProblem _emailService;
        private readonly DatabaseServiceProblem _databaseService;

        public OrderServiceProblem()
        {
            // Tight coupling - cannot be changed without modifying this class
            _emailService = new EmailServiceProblem();
            _databaseService = new DatabaseServiceProblem();
        }

        public void ProcessOrder(string orderId)
        {
            Console.WriteLine($"Processing order: {orderId}");
            
            // Business logic
            _databaseService.SaveToDatabase(orderId);
            _emailService.SendEmail($"Order {orderId} processed successfully");
            
            Console.WriteLine("Order processing completed");
        }
    }
    #endregion

    #region Solution - Following DIP
    /// <summary>
    /// SOLUTION: Use abstractions (interfaces) to invert the dependencies
    /// </summary>
    
    // Abstractions (interfaces) - high-level concepts
    interface IOrderRepository
    {
        void SaveOrder(string orderId);
        string GetOrder(string orderId);
    }

    interface INotificationService
    {
        void SendNotification(string message);
    }

    // Low-level modules now depend on abstractions
    class SqlOrderRepository : IOrderRepository
    {
        public void SaveOrder(string orderId)
        {
            Console.WriteLine($"Saving order {orderId} to SQL database");
        }

        public string GetOrder(string orderId)
        {
            Console.WriteLine($"Retrieving order {orderId} from SQL database");
            return $"Order data for {orderId}";
        }
    }

    class MongoOrderRepository : IOrderRepository
    {
        public void SaveOrder(string orderId)
        {
            Console.WriteLine($"Saving order {orderId} to MongoDB");
        }

        public string GetOrder(string orderId)
        {
            Console.WriteLine($"Retrieving order {orderId} from MongoDB");
            return $"Order data for {orderId}";
        }
    }

    class EmailNotifier : INotificationService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Email notification: {message}");
        }
    }

    class SmsNotifier : INotificationService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"SMS notification: {message}");
        }
    }

    class PushNotifier : INotificationService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Push notification: {message}");
        }
    }

    // High-level module that follows DIP
    class OrderService
    {
        // Depends on abstractions, not concrete implementations
        private readonly IOrderRepository _orderRepository;
        private readonly INotificationService _notificationService;

        // Dependencies are injected (Dependency Injection)
        public OrderService(IOrderRepository orderRepository, INotificationService notificationService)
        {
            _orderRepository = orderRepository;
            _notificationService = notificationService;
        }

        public void ProcessOrder(string orderId)
        {
            Console.WriteLine($"Processing order: {orderId}");
            
            // Business logic remains the same
            _orderRepository.SaveOrder(orderId);
            _notificationService.SendNotification($"Order {orderId} processed successfully");
            
            Console.WriteLine("Order processing completed");
        }

        public void CancelOrder(string orderId)
        {
            Console.WriteLine($"Cancelling order: {orderId}");
            // Could involve different repository operations
            _notificationService.SendNotification($"Order {orderId} has been cancelled");
        }
    }

    // Example of a factory or service locator that could manage dependencies
    class OrderServiceFactory
    {
        public static OrderService CreateOrderService(string repositoryType, string notifierType)
        {
            IOrderRepository repository = repositoryType.ToLower() switch
            {
                "sql" => new SqlOrderRepository(),
                "mongo" => new MongoOrderRepository(),
                _ => throw new ArgumentException("Unknown repository type")
            };

            INotificationService notifier = notifierType.ToLower() switch
            {
                "email" => new EmailNotifier(),
                "sms" => new SmsNotifier(),
                "push" => new PushNotifier(),
                _ => throw new ArgumentException("Unknown notifier type")
            };

            return new OrderService(repository, notifier);
        }
    }
    #endregion
}