using System;
using System.Collections.Generic;
public class Car
{
    public int Year;
    public string Model;
    public string Color;
    public bool Clean;
    public Car(int year, string model, string color, bool clean)
    {
        Year = year;
        Model = model;
        Color = color;
        Clean = clean;
    }
    public override string ToString()
    {
        if (Clean) return $"{Model} ({Year}), цвет: {Color}, чистая";
        else return $"{Model} ({Year}), цвет: {Color}, грязная";
    }
}
public class Garage
{
    public List<Car> Cars;
    public Garage()
    {
        Cars = new List<Car>();
    }
    public void Add(Car car)
    {
        Cars.Add(car);
    }
}
public class CarWash
{
    public void Wash(Car car)
    {
        if (!car.Clean)
        {
            Console.WriteLine($"отправляется в мойку: {car.Model}");
            car.Clean = true;
            Console.WriteLine($"{car.Model} помыта");
        }
        else
        {
            Console.WriteLine($"{car.Model} уже чистая");
        }
    }
}
public delegate void CarToWashDelegate(Car car);
class Program
{
    static void Main()
    {
        Garage garage = new Garage();
        garage.Add(new Car(2002, "Mazda RX-7", "красная", false));
        garage.Add(new Car(2018, "Honda Civic", "черная", true));
        garage.Add(new Car(2019, "Supra", "белая", false));

        Console.WriteLine("машины до мойки:");
        foreach (var car in garage.Cars)
        {
            Console.WriteLine(car);
        }
        Console.WriteLine();

        CarWash carWash = new CarWash();
        CarToWashDelegate washDelegate = carWash.Wash;
        foreach (var car in garage.Cars)
        {
            washDelegate(car);
        }

        Console.WriteLine("\nмашины после мойки:");
        foreach (var car in garage.Cars)
        {
            Console.WriteLine(car);
        }
    }
}
