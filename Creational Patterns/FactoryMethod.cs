/* 
Factroy Methods creates an object without having to specify the exact class 
for which we need the object


In plain words

It provides a way to delegate the instantiation logic to child classes.


In class-based programming, the factory method pattern is a creational pattern that uses 
factory methods to deal with the problem of creating objects without having to specify the exact 
class of the object that will be created. 
This is done by creating objects by calling a factory method—either specified in an interface 
and implemented by child classes, or implemented in a base class and optionally 
overridden by derived classes—rather than by calling a constructor.



Useful when there is some generic processing in a class but the required sub-class is dynamically decided at runtime. 
Or putting it in other words, when the client doesn't know what exact sub-class it might need.
*/

interface IInterviewer
{
    void AskQuestions();
}

class Developer : IInterviewer
{
    public void AskQuestions()
    {
        Console.WriteLine("Asking about design patterns!");
    }
}

class CommunityExecutive : IInterviewer
{
    public void AskQuestions()
    {
        Console.WriteLine("Asking about community building!");
    }
}

abstract class HiringManager
{
    //Factory Method
    abstract public IInterviewer CreateInterviewer();
    public void TakeInterview()
    {
        var interviewer = this.CreateInterviewer();
        interviewer.AskQuestions();
    }
}

class DevelopmentManager : HiringManager
{
    protected override IInterviewer MakeInterviewer()
    {
        return new Developer();
    }
}

class MarketingManager : HiringManager
{
    protected override IInterviewer MakeInterviewer()
    {
        return new CommunityExecutive();
    }
}

var devManager = new DevelopmentManager();
devManager.TakeInterview();

var marketingManager = new MarketingManager();
marketingManager.TakeInterview();//Output : Asking about community building!


