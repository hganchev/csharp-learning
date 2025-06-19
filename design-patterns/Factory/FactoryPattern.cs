// Factory Pattern Example
// The Factory pattern provides an interface for creating objects without specifying their exact class.
// It encapsulates object creation logic in a single place, making it easier to manage and extend.

namespace DesignPatterns.Factory
{
    // Product interface
    public interface IVehicle
    {
        string Type { get; }
        void Start();
        void Stop();
        void GetInfo();
    }

    // Concrete Products
    public class Car : IVehicle
    {
        public string Type => "Car";

        public void Start()
        {
            Console.WriteLine("Car engine started with ignition key");
        }

        public void Stop()
        {
            Console.WriteLine("Car engine stopped");
        }

        public void GetInfo()
        {
            Console.WriteLine("This is a 4-wheeled motor vehicle");
        }
    }

    public class Motorcycle : IVehicle
    {
        public string Type => "Motorcycle";

        public void Start()
        {
            Console.WriteLine("Motorcycle engine started with kick/button");
        }

        public void Stop()
        {
            Console.WriteLine("Motorcycle engine stopped");
        }

        public void GetInfo()
        {
            Console.WriteLine("This is a 2-wheeled motor vehicle");
        }
    }

    public class Truck : IVehicle
    {
        public string Type => "Truck";

        public void Start()
        {
            Console.WriteLine("Truck diesel engine started");
        }

        public void Stop()
        {
            Console.WriteLine("Truck engine stopped");
        }

        public void GetInfo()
        {
            Console.WriteLine("This is a heavy-duty transport vehicle");
        }
    }

    // Factory class
    public static class VehicleFactory
    {
        public static IVehicle CreateVehicle(string vehicleType)
        {
            return vehicleType.ToLower() switch
            {
                "car" => new Car(),
                "motorcycle" => new Motorcycle(),
                "truck" => new Truck(),
                _ => throw new ArgumentException($"Unknown vehicle type: {vehicleType}")
            };
        }
    }

    // Client code demonstrating the Factory pattern
    public class FactoryPatternDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("=== Factory Pattern Demo ===");
            
            string[] vehicleTypes = { "car", "motorcycle", "truck" };

            foreach (string type in vehicleTypes)
            {
                try
                {
                    IVehicle vehicle = VehicleFactory.CreateVehicle(type);
                    Console.WriteLine($"\nCreated: {vehicle.Type}");
                    vehicle.GetInfo();
                    vehicle.Start();
                    vehicle.Stop();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
