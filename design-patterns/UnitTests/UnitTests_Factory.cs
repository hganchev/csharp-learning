using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatterns.Factory;

[TestClass]
public class UnitTests_Factory
{
    [TestMethod]
    public void TestCarCreation()
    {
        // Act
        IVehicle vehicle = VehicleFactory.CreateVehicle("car");

        // Assert
        Assert.IsInstanceOfType(vehicle, typeof(Car));
        Assert.AreEqual("Car", vehicle.Type);
    }

    [TestMethod]
    public void TestMotorcycleCreation()
    {
        // Act
        IVehicle vehicle = VehicleFactory.CreateVehicle("motorcycle");

        // Assert
        Assert.IsInstanceOfType(vehicle, typeof(Motorcycle));
        Assert.AreEqual("Motorcycle", vehicle.Type);
    }

    [TestMethod]
    public void TestTruckCreation()
    {
        // Act
        IVehicle vehicle = VehicleFactory.CreateVehicle("truck");

        // Assert
        Assert.IsInstanceOfType(vehicle, typeof(Truck));
        Assert.AreEqual("Truck", vehicle.Type);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestInvalidVehicleType()
    {
        // Act & Assert
        VehicleFactory.CreateVehicle("plane");
    }

    [TestMethod]
    public void TestVehicleOperations()
    {
        // Arrange
        var car = VehicleFactory.CreateVehicle("car");
        
        // Act & Assert (no exceptions should be thrown)
        car.Start();
        car.GetInfo();
        car.Stop();
        
        Assert.AreEqual("Car", car.Type);
    }
}
