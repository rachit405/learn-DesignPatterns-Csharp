/*
Abstract Factory 

Bundled up factories of object creation.

A factory of factories; a factory that groups the individual
but related/dependent factories together without specifying their concrete classes.

The abstract factory pattern provides a way to encapsulate a group of individual factories 
that have a common theme without specifying their concrete classes

Uses : 

When there are interrelated dependencies with not-that-simple creation logic involved

*/

public interface IVehicle
{
    public void GetDiscription();
}

class Car : IVehicle 
{
    public void GetDiscription()
    {
        Console.WriteLine("Its a Car");
    }
}

class Truck : IVehicle
{
    public void GetDiscription()
    {
        Console.WriteLine("Its a Truck");
    }
}

public interface IFittingExpert
{
    void GetDiscription();
}

public class CarFittingExpert : IFittingExpert
{
    public void GetDiscription()
    {
        Console.WriteLine("I am a car fitting Expert");
    }
}

public class TruckFittingExpert : IFittingExpert
{
    public void GetDiscription()
    {
        Console.WriteLine("I am a Truck Fitting Expert");
    }
}

// Abstract Factory ;; Now we have our abstract factory that would let us make family of related objects

public interface IVehicleFactory
{
    IVehicle MakeVehicle();
    IFittingExpert MakeFittingExpert();
}

// Factory classes

public class CarFactory : IVehicleFactory
{
    public IVehicle MakeVehicle()
    {
        return new Car();
    }
    public IFittingExpert MakeFittingExpert()
    {
        return new CarFittingExpert();
    }
}

public class TruckFactory : IVehicleFactory
{
    public IVehicle MakeVehicle()
    {
        return new Truck();
    }
    public IFittingExpert MakeFittingExpert()
    {
        return new TruckFittingExpert();
    }
}

// Use

var carFactory = new CarFactory();
var car = carFactory.MakeVehicle();
var carFittingExpert = carFactory.MakeFittingExpert();

Console.WriteLine(car.GetDiscription()); // output I am a car
Console.WriteLine(carFittingExpert.GetDiscription()); // output I am a car fitting expert