// Solid Principles in C# with code examples

/* 
Single responsibility Principle

A class should have only one reason to change, meaning it should only have one responsibility.

A class responsible for representing data should only have the responsibility of holding the data. 
It should not be responsible for saving the data to a database or performing any other unrelated tasks.

By having a single responsibility, a class becomes more cohesive and easier to maintain. It also makes the application more flexible, as changes to one responsibility do not impact other responsibilities.

The Single Responsibility Principle states that a module should have only one reason to change.
*/


public class Invoice {
    int InvoiceNo {get; set;}
    string? CustomerName {get; set;}
    int Amount {get; set;}
    string Description {get; set;}

    public Invoice GenerateInvoice(){
        // generates an invoice 
    }
    // This breaks the single responsibility principle as the class has more than one responsibility
    // Generating and saving the invoice to DB; In this case we should have another class be responsible for save
    public bool SaveInvoiceToDataBase(Invoice invoice){
        // Save invoice to DB
    }

}


/* 
Open-Close Principle 

The Open-closed principle states that software entities (classes, methods, functions, etc.) 
should be open for extension but closed for modification.

You should design a class or a method in such a way that you can extend its behavior without directly modifying the existing source code.

Open for extension but closed for modification

Leverage the open-closed principle to design software that is more modular, flexible, and maintainable.
*/ 

public class Invoice {
    int InvoiceNo {get; set;}
    string? CustomerName {get; set;}
    int Amount {get; set;}
    string Description {get; set;}
}

// Class responsible to save this 

class InvoiceRepository
{
    public void SaveFile(Invoice invoice)
    {
        Console.WriteLine($"Saved the invoice #{invoice.InvoiceNo} into a file.");
    }
    public void SaveDB(Invoice invoice)
    {
        Console.WriteLine($"Saved the invoice #{invoice.InvoiceNo} into a database.");
    }
}

// Now if we need to add a method to save this into a Json format; 
// adding directly into this class voilates the open-close principle
// we need to create and abstraction 

interface IInvoiceRepository
{
    void Save(Invoice invoice);
}

class FileInvoiceRepository : IInvoiceRepository
{
    public void Save(Invoice invoice)
    {
        Console.WriteLine($"Saved the invoice #{invoice.InvoiceNo} into a file.");
    }
}

class DBInvoiceRepository : IInvoiceRepository
{
    public void Save(Invoice invoice)
    {
        Console.WriteLine($"Saved the invoice #{invoice.InvoiceNo} into the database.");
    }
}

class JSONInvoiceRepository: IInvoiceRepository
{
    public void Save(Invoice invoice)
    {
        Console.WriteLine($"Saved the invoice #{invoice.InvoiceNo} into the database.");
    }
}

/* 
Liskov Substitution Principle 

The Liskov substitution principle states that if a method uses a base class, 
then it should be able to use any of its derived classes without the need of having the information about the derived class.

In other words, the derived classes should be substitutable for their base class without causing errors or side effects. 
This means that the behavior of the derived class should not contradict the behavior of the base class.


*/ 

public abstract class Vehicle 
{
    public abstract void Drive();
}

public class Car : Vehicle
{
    public override void Drive()
    {
        Console.WriteLine("Drive a Car");
    }
}

public class Truck : Vehicle
{
    public override void Drive()
    {
        Console.WriteLine("Drive a truck");
    }
}

public class Program
{
    public static void TestDrive(Vehicle vehicle)
    {
        vehicle.Drive();
    }

    TestDrive(Car car);
    TestDrive(Truck truck); 
}

/* 
Interface Segregation Principle

The interface segregation principle suggests that you should not force a client to 
implement an interface that contains methods that it doesn’t need.

The interface segregation principle promotes the idea of creating small and cohesive interfaces that are specific to the client’s needs.


*/

public interface IVehicle
{
    public void Run();
    public void Fly();
}

public class Aircraft1 : IVehicle
{
    public override void Run()
    {
        Console.WriteLine("Aircraft is running");
    }

    public override void Fly()
    {
        console.WriteLine("Aircraft is Flying");
    }
}

public class Car1 : IVehicle
{
    public override void Run()
    {
        Console.WriteLine("Car is running");
    }

    public override void Fly()
    {
        throw new NotImplementedException();
    }
}

// This is the voilation of Interface Segregation Principle

public interface IFlyable
{
    void Fly();
}
public interface IRunnable
{
    void Run();
}

public class Aircraft : IRunnable, IFlyable
{
    public void Run() => Console.Write("Running");
    public void Fly() => Console.Write("Flying");
}

public class Car: IRunnable
{
    public void Run() => Console.Write("Running");
}

/* 
Dependency Inversion Principle

The Dependency Inversion Principle states that high-level modules should not directly depend on low-level modules, 
but both should depend on abstractions of each other.

high-level modules are modules that contain the main logic of the application, 
while low-level modules are modules that provide supporting functionality.


*/

public class DataBaseService
{
    public void Save(string message)
    {
        Console.WriteLine("Save the message into the database");
    }
}

//Logger method uses Save method from the database service class to save logs to the Database

public class Logger
{
    private readonly DatabaseService _databaseService;

    public Logger(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }
    public void Log(string message)
    {
        _databaseService.Save(message);
    }
}

// This creates a Tight Coupling between Database service class and Logger Class, as logger is directly using the object of
// Database service class to save logs in DB

public interface IDataService
{
    public void Save(string message);
}

public class DatabaseService: IDataService
{
    public void Save(string message)
    {
        Console.WriteLine("Save the message into the database");
    }
}

public class Logger
{
    private readonly IDataService _dataService;

    public Logger(IDataService dataService)
    {
        _dataService = dataService;
    }

    public void Log(string message)
    {
        _dataService.Save(message);
    }
}

// Use

public class Program
{
    public static void Main(string[] args)
    {
        var logger = new Logger(new DatabaseService());
        logger.Log("Hello");
    }
}