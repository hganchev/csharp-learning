using System;
using System.Collections.Generic;

namespace app.OOP
{
    /// <summary>
    /// Demonstrates Object-Oriented Programming principles:
    /// - Encapsulation: Data hiding and controlled access through properties
    /// - Inheritance: Creating specialized classes from base classes
    /// - Polymorphism: Different behaviors for the same method signature
    /// - Abstraction: Hiding implementation details behind interfaces
    /// </summary>    
    // Base class demonstrating encapsulation and basic OOP concepts
    public abstract class Vehicle
    {
        // Private fields - data hiding (encapsulation)
        private string _brand = string.Empty;
        private int _year;
        private double _fuel;
        
        // Public properties with validation (encapsulation)
        public string Brand 
        { 
            get => _brand; 
            set => _brand = !string.IsNullOrEmpty(value) ? value : throw new ArgumentException("Brand cannot be empty");
        }
        
        public int Year 
        { 
            get => _year; 
            set => _year = value > 1900 ? value : throw new ArgumentException("Year must be after 1900");
        }
        
        public double Fuel 
        { 
            get => _fuel; 
            private set => _fuel = Math.Max(0, value); // Can only be set internally
        }
        
        // Auto-implemented property
        public string Color { get; set; } = "White";
        
        // Constructor with parameters
        protected Vehicle(string brand, int year, string color = "White")
        {
            Brand = brand;
            Year = year;
            Color = color;
            Fuel = 100.0; // Start with full tank
        }
        
        // Virtual method - can be overridden in derived classes (polymorphism)
        public virtual void Start()
        {
            if (Fuel > 0)
                Console.WriteLine($"{Brand} vehicle is starting...");
            else
                Console.WriteLine($"{Brand} vehicle cannot start - no fuel!");
        }
        
        // Abstract method - must be implemented in derived classes
        public abstract void Accelerate();
        
        // Regular method with business logic
        public void Refuel(double amount)
        {
            if (amount <= 0) throw new ArgumentException("Fuel amount must be positive");
            Fuel = Math.Min(100, Fuel + amount);
            Console.WriteLine($"Refueled {Brand}. Current fuel: {Fuel:F1}%");
        }
        
        protected void ConsumeFuel(double amount)
        {
            Fuel = Math.Max(0, Fuel - amount);
        }    }
    
    // Inheritance example - Car inherits from Vehicle
    public class Car : Vehicle
    {
        public int Doors { get; set; }
        public string TransmissionType { get; set; } = string.Empty;
        
        public Car(string brand, int year, int doors, string transmissionType, string color = "White") 
            : base(brand, year, color)
        {
            Doors = doors;
            TransmissionType = transmissionType;
        }
        
        // Polymorphism - overriding the virtual method with specific implementation
        public override void Start()
        {
            Console.WriteLine($"Starting {Brand} car with {Doors} doors...");
            base.Start(); // Call parent implementation
        }
        
        // Implementing abstract method
        public override void Accelerate()
        {
            if (Fuel > 10)
            {
                ConsumeFuel(5);
                Console.WriteLine($"{Brand} car is accelerating smoothly with {TransmissionType} transmission!");
            }
            else
            {
                Console.WriteLine($"{Brand} car needs fuel to accelerate!");
            }
        }
        
        public void ToggleAirConditioning()
        {
            ConsumeFuel(2);
            Console.WriteLine("Air conditioning toggled");
        }
    }
    
    // Another inheritance example - Motorcycle inherits from Vehicle
    public class Motorcycle : Vehicle
    {
        public bool HasSidecar { get; set; }
        
        public Motorcycle(string brand, int year, bool hasSidecar, string color = "Black") 
            : base(brand, year, color)
        {
            HasSidecar = hasSidecar;
        }
        
        // Polymorphism - different implementation of the same method
        public override void Start()
        {
            Console.WriteLine($"Kick-starting {Brand} motorcycle...");
            if (Fuel > 0)
                Console.WriteLine("Motorcycle engine roars to life!");
        }
        
        public override void Accelerate()
        {
            if (Fuel > 5)
            {
                ConsumeFuel(3);
                string sidecarInfo = HasSidecar ? " (with sidecar)" : "";
                Console.WriteLine($"{Brand} motorcycle{sidecarInfo} accelerates quickly!");
            }
            else
            {
                Console.WriteLine($"{Brand} motorcycle needs fuel!");
            }
        }
        
        public void Wheelie()
        {
            if (!HasSidecar && Fuel > 15)
            {
                ConsumeFuel(8);
                Console.WriteLine($"{Brand} motorcycle performs an awesome wheelie!");
            }
            else if (HasSidecar)
            {
                Console.WriteLine("Cannot perform wheelie with sidecar!");
            }
            else
            {
                Console.WriteLine("Not enough fuel for wheelie!");
            }
        }    }
    
    // Interface example - defining a contract for maintenance operations
    public interface IMaintainable
    {
        void PerformMaintenance();
        DateTime LastMaintenanceDate { get; set; }
        bool NeedsMaintenance { get; }
    }
    
    // Interface for rentable vehicles
    public interface IRentable
    {
        decimal DailyRate { get; }
        bool IsAvailable { get; }
        void Rent(string customerName);
        void Return();
    }
    
    // Class implementing multiple interfaces
    public class RentalCar : Car, IMaintainable, IRentable
    {
        private string? _currentRenter;
        
        public DateTime LastMaintenanceDate { get; set; }
        public decimal DailyRate { get; }
        public bool IsAvailable => _currentRenter == null;
        
        public bool NeedsMaintenance 
        { 
            get => DateTime.Now - LastMaintenanceDate > TimeSpan.FromDays(90); 
        }
        
        public RentalCar(string brand, int year, decimal dailyRate, string color = "White") 
            : base(brand, year, 4, "Automatic", color)
        {
            DailyRate = dailyRate;
            LastMaintenanceDate = DateTime.Now.AddDays(-30); // Last maintained 30 days ago
        }
        
        public void PerformMaintenance()
        {
            LastMaintenanceDate = DateTime.Now;
            Refuel(100); // Full tank after maintenance
            Console.WriteLine($"{Brand} rental car maintenance completed. Next due: {LastMaintenanceDate.AddDays(90):yyyy-MM-dd}");
        }
        
        public void Rent(string customerName)
        {
            if (!IsAvailable)
                throw new InvalidOperationException("Car is already rented");
            if (NeedsMaintenance)
                throw new InvalidOperationException("Car needs maintenance before rental");
                
            _currentRenter = customerName;
            Console.WriteLine($"{Brand} rented to {customerName} at ${DailyRate}/day");
        }
        
        public void Return()
        {
            if (IsAvailable)
                throw new InvalidOperationException("Car is not currently rented");
                
            Console.WriteLine($"{Brand} returned by {_currentRenter}");
            _currentRenter = null;
        }
    }
    
    // Enum for vehicle status
    public enum VehicleStatus
    {
        Available,
        InUse,
        Maintenance,
        OutOfService
    }
    
    // Static class for utility methods
    public static class VehicleUtilities
    {
        public static void DisplayVehicleInfo(Vehicle vehicle)
        {
            Console.WriteLine($"\n=== Vehicle Information ===");
            Console.WriteLine($"Brand: {vehicle.Brand}");
            Console.WriteLine($"Year: {vehicle.Year}");
            Console.WriteLine($"Color: {vehicle.Color}");
            Console.WriteLine($"Fuel Level: {vehicle.Fuel:F1}%");
        }
        
        public static void TestPolymorphism(List<Vehicle> vehicles)
        {
            Console.WriteLine("\n=== Testing Polymorphism ===");
            foreach (var vehicle in vehicles)
            {
                vehicle.Start(); // Same method call, different behavior
                vehicle.Accelerate(); // Same method call, different behavior
                Console.WriteLine();
            }
        }
    }
}

     