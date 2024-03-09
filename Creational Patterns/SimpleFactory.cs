// Car factory

/* 
When to Use?

When creating an object is not just a few assignments and involves some logic, 
it makes sense to put it in a dedicated factory instead of repeating the same code everywhere.

*/

public interface ICar {
    getMilage();
    getHeight();
}

public class Car : ICar {
    private int milage{get; set;}
    private int height{get;set;}

    public Car(int milage, int height){
        this.height = height;
        this.milage = milage;
    } 

    public int getMilage(){
        return this.milage;
    }
    public int getHeight(){
        return this.height;
    }
}

// Factory Class

public static class CarFactory
{
    public static ICar MakeCar(int milage, int height)
    {
        return new Car(milage,height);
    }
}

var newCar = CarFactory.MakeCar(20,30);
Console.WriteLine($"Height of the car is {newCar.getHeight()}");
Console.WriteLine($"Milage of the car is {newCar.getMilage()}");