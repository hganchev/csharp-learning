using System;
using System.Collections.Generic;
using System.IO;

namespace SOLID
{
    /// <summary>
    /// SRP - Single Responsibility Principle
    /// Definition: A class should have only ONE reason to change, meaning it should have only ONE job or responsibility.
    /// </summary>
    class SRP
    {
        public SRP()
        {
            Console.WriteLine("=== Single Responsibility Principle (SRP) ===");
            Console.WriteLine("A class should have only ONE reason to change.\n");

            // Problem Example - Violating SRP
            Console.WriteLine("PROBLEM - Violating SRP:");
            var problemUser = new UserProblem("John Doe", "john@example.com");
            problemUser.Save(); // This class handles both user data AND persistence
            problemUser.SendEmail("Welcome!"); // AND email sending
            Console.WriteLine();

            // Solution Example - Following SRP
            Console.WriteLine("SOLUTION - Following SRP:");
            var user = new User("Jane Doe", "jane@example.com");
            var userRepository = new UserRepository();
            var emailService = new EmailService();
            
            userRepository.Save(user); // Separate class handles persistence
            emailService.SendEmail(user.Email, "Welcome!"); // Separate class handles email
        }
    }

    #region Problem - Violating SRP
    /// <summary>
    /// PROBLEM: This class violates SRP because it has multiple responsibilities:
    /// 1. Managing user data
    /// 2. Saving user to database
    /// 3. Sending emails
    /// If we need to change how we save users or send emails, we'd need to modify this class.
    /// </summary>
    class UserProblem
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public UserProblem(string name, string email)
        {
            Name = name;
            Email = email;
        }

        // Responsibility 1: User data management (OK)
        public void UpdateName(string newName)
        {
            Name = newName;
        }

        // Responsibility 2: Database operations (VIOLATION!)
        public void Save()
        {
            Console.WriteLine($"Saving user {Name} to database...");
            // Database logic here
        }

        // Responsibility 3: Email operations (VIOLATION!)
        public void SendEmail(string message)
        {
            Console.WriteLine($"Sending email to {Email}: {message}");
            // Email logic here
        }
    }
    #endregion

    #region Solution - Following SRP
    /// <summary>
    /// SOLUTION: Each class now has a single responsibility
    /// </summary>
    
    // Responsibility 1: Only manages user data
    class User
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public void UpdateName(string newName)
        {
            Name = newName;
        }
    }

    // Responsibility 2: Only handles user persistence
    class UserRepository
    {
        public void Save(User user)
        {
            Console.WriteLine($"Saving user {user.Name} to database...");
            // Database logic here
        }

        public User GetById(int id)
        {
            Console.WriteLine($"Getting user with ID {id} from database...");
            // Database retrieval logic here
            return new User("Retrieved User", "retrieved@example.com");
        }
    }

    // Responsibility 3: Only handles email operations
    class EmailService
    {
        public void SendEmail(string email, string message)
        {
            Console.WriteLine($"Sending email to {email}: {message}");
            // Email sending logic here
        }

        public void SendWelcomeEmail(string email)
        {
            SendEmail(email, "Welcome to our service!");
        }
    }
    #endregion
}