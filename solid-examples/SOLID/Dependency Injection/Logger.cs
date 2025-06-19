using System;

namespace SOLID.DependencyInjection
{
    /// <summary>
    /// Dependency Injection (DI) Examples
    /// 
    /// Dependency Injection is a design pattern that implements Inversion of Control (IoC).
    /// It allows objects to receive their dependencies from external sources rather than creating them internally.
    /// 
    /// Benefits:
    /// - Loose coupling between classes
    /// - Better testability (can inject mock dependencies)
    /// - Better maintainability and flexibility
    /// - Follows the Dependency Inversion Principle
    /// </summary>
    public class DependencyInjectionExamples
    {
        #region Problem: Tight Coupling (Without Dependency Injection)

        /// <summary>
        /// PROBLEM: UserService with tight coupling
        /// - Hard to test (can't mock database)
        /// - Hard to change database implementation
        /// - Violates Dependency Inversion Principle
        /// </summary>
        public class UserServiceProblem
        {
            // Directly creating dependencies - TIGHT COUPLING
            private readonly SqlDatabase _database = new SqlDatabase();
            private readonly SmtpEmailService _emailService = new SmtpEmailService();
            private readonly ConsoleLogger _logger = new ConsoleLogger();

            public void RegisterUser(string username, string email)
            {
                try
                {
                    _logger.Log($"Starting user registration for: {username}");

                    // Validate user
                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
                    {
                        throw new ArgumentException("Username and email are required");
                    }

                    // Save to database - CANNOT change database type without modifying this class
                    _database.Save($"User: {username}, Email: {email}");

                    // Send welcome email - CANNOT change email provider without modifying this class
                    _emailService.SendEmail(email, "Welcome!", $"Welcome {username}!");

                    _logger.Log($"User registration completed for: {username}");
                }
                catch (Exception ex)
                {
                    _logger.Log($"Error during registration: {ex.Message}");
                    throw;
                }
            }
        }

        /// <summary>
        /// PROBLEM: Order processor with tight coupling
        /// </summary>
        public class OrderProcessorProblem
        {
            // Hard-coded dependencies
            private readonly SqlDatabase _database = new SqlDatabase();
            private readonly SmtpEmailService _emailService = new SmtpEmailService();

            public void ProcessOrder(int orderId, string customerEmail)
            {
                // Cannot easily switch to different database or email service
                var orderData = _database.Get(orderId);
                _emailService.SendEmail(customerEmail, "Order Confirmation", $"Order processed: {orderData}");
            }
        }

        #endregion

        #region Solution: Proper Dependency Injection

        /// <summary>
        /// SOLUTION: UserService with dependency injection
        /// - Loose coupling through interfaces
        /// - Easy to test with mock dependencies
        /// - Easy to change implementations
        /// - Follows Dependency Inversion Principle
        /// </summary>
        public class UserServiceSolution
        {
            // Dependencies injected through constructor - LOOSE COUPLING
            private readonly IDatabase _database;
            private readonly IEmailService _emailService;
            private readonly ILogger _logger;

            // Constructor Injection - dependencies provided from outside
            public UserServiceSolution(IDatabase database, IEmailService emailService, ILogger logger)
            {
                _database = database ?? throw new ArgumentNullException(nameof(database));
                _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            }

            public void RegisterUser(string username, string email)
            {
                try
                {
                    _logger.Log($"Starting user registration for: {username}");

                    // Validate user
                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
                    {
                        throw new ArgumentException("Username and email are required");
                    }

                    // Save to database - can use ANY implementation of IDatabase
                    _database.Save($"User: {username}, Email: {email}");

                    // Send welcome email - can use ANY implementation of IEmailService
                    _emailService.SendEmail(email, "Welcome!", $"Welcome {username}!");

                    _logger.Log($"User registration completed for: {username}");
                }
                catch (Exception ex)
                {
                    _logger.Log($"Error during registration: {ex.Message}");
                    throw;
                }
            }
        }

        /// <summary>
        /// SOLUTION: Order processor with dependency injection
        /// </summary>
        public class OrderProcessorSolution
        {
            private readonly IDatabase _database;
            private readonly IEmailService _emailService;
            private readonly ILogger _logger;

            public OrderProcessorSolution(IDatabase database, IEmailService emailService, ILogger logger)
            {
                _database = database ?? throw new ArgumentNullException(nameof(database));
                _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            }

            public void ProcessOrder(int orderId, string customerEmail)
            {
                _logger.Log($"Processing order {orderId}");

                // Can easily switch to different database or email service
                var orderData = _database.Get(orderId);
                _emailService.SendEmail(customerEmail, "Order Confirmation", $"Order processed: {orderData}");

                _logger.Log($"Order {orderId} processed successfully");
            }
        }

        #endregion

        #region Different Types of Dependency Injection        
        /// <summary>
        /// Property Injection - dependencies set through properties
        /// Less preferred than constructor injection
        /// </summary>
        public class ServiceWithPropertyInjection
        {
            public IDatabase? Database { get; set; }
            public ILogger? Logger { get; set; }

            public void DoWork()
            {
                if (Database == null || Logger == null)
                    throw new InvalidOperationException("Dependencies not set");

                Logger.Log("Doing work...");
                Database.Save("Some data");
            }
        }

        /// <summary>
        /// Method Injection - dependencies passed to specific methods
        /// </summary>
        public class ServiceWithMethodInjection
        {
            public void ProcessData(string data, IDatabase database, ILogger logger)
            {
                logger.Log($"Processing data: {data}");
                database.Save(data);
            }
        }

        #endregion

        #region Demonstration Methods

        public static void RunDependencyInjectionExamples()
        {
            Console.WriteLine("=== DEPENDENCY INJECTION EXAMPLES ===\n");

            // Problem: Tight coupling
            Console.WriteLine("--- PROBLEM: Tight Coupling ---");
            var problemService = new UserServiceProblem();
            problemService.RegisterUser("john_doe", "john@example.com");
            Console.WriteLine("Issue: Cannot easily change database or email service\n");

            // Solution: Dependency injection with different implementations
            Console.WriteLine("--- SOLUTION: Dependency Injection ---");

            // Configuration 1: SQL + SMTP + Console
            Console.WriteLine("Configuration 1: SQL Database + SMTP Email + Console Logger");
            var sqlDb = new SqlDatabase();
            var smtpEmail = new SmtpEmailService();
            var consoleLogger = new ConsoleLogger();
            var service1 = new UserServiceSolution(sqlDb, smtpEmail, consoleLogger);
            service1.RegisterUser("alice", "alice@example.com");

            Console.WriteLine("\nConfiguration 2: MongoDB + SendGrid + File Logger");
            var mongoDb = new MongoDatabase();
            var sendGridEmail = new SendGridEmailService();
            var fileLogger = new FileLogger();
            var service2 = new UserServiceSolution(mongoDb, sendGridEmail, fileLogger);
            service2.RegisterUser("bob", "bob@example.com");

            Console.WriteLine("\n--- ORDER PROCESSING EXAMPLE ---");
            var orderProcessor = new OrderProcessorSolution(mongoDb, sendGridEmail, fileLogger);
            orderProcessor.ProcessOrder(12345, "customer@example.com");

            Console.WriteLine("\n--- PROPERTY INJECTION EXAMPLE ---");
            var propService = new ServiceWithPropertyInjection
            {
                Database = sqlDb,
                Logger = consoleLogger
            };
            propService.DoWork();

            Console.WriteLine("\n--- METHOD INJECTION EXAMPLE ---");
            var methodService = new ServiceWithMethodInjection();
            methodService.ProcessData("Important data", mongoDb, fileLogger);
        }

        #endregion
    }
}