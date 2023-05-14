using System;
namespace SOLID
{
    // OCP Open Closed Principle - Software entities ... should be open for extension, but closed for modification
    class OCP
    {
        public OCP()
        {
            Console.WriteLine("OCP - Software entities ... should be open for extension, but closed for modification");
            var myCar1 = new Car1();
            myCar1.travelDistance = 200;
            myCar1.travelTime = 100;
            var myCar2 = new Car2();
            myCar1.travelDistance = 300;
            myCar1.travelTime = 220;
            var calcSpeed = new CalculateSpeed();
            Console.WriteLine(calcSpeed.calculateCar1Speed(myCar1));
            Console.WriteLine(calcSpeed.calculateCar2Speed(myCar2));

            var myCar3 = new Car3();
            myCar3.travelDistance = 500;
            myCar3.travelTime = 300;
            Console.WriteLine(myCar3.calculateSpeed());
        }
    }

    class Car1
    {
        public double travelDistance {get; set;}/*meters*/
        public double travelTime {get; set;} /*seconds*/
    }

    class Car2
    {
        public double travelDistance {get; set;}/*meters*/
        public double travelTime {get; set;} /*seconds*/
    }
    // The problem with this is that we keep modifying the code every time we need to calculate the Spped of another car.
    class CalculateSpeed
    {
        public double calculateCar1Speed(Car1 car)
        {
            return car.travelDistance/car.travelTime; /*m/s*/
        }

        public double calculateCar2Speed(Car2 car)
        {
            return car.travelDistance/car.travelTime; /*m/s*/
        }
    }

    public interface ICar
    {
        
        public double calculateSpeed();
    }

    // Now we no longer have to modify existing code when we create a new entity - 
    // we just extend the functionality we need and apply it to the new entity.
    class Car3:ICar
    {
        public double travelDistance {get; set;}/*meters*/
        public double travelTime {get; set;} /*seconds*/
        public double calculateSpeed()
        {
            return travelDistance/travelTime; /*m/s*/
        }
    }
}