/* 

IMP -> Separating out the command from client and reciever, with abstracting so that these 3 units become independent.

A generic example would be you ordering food at a restaurant. You (i.e. Client) ask the waiter (i.e. Invoker) to bring 
some food (i.e. Command) and waiter simply forwards the request to Chef (i.e. Receiver) who has the knowledge of what 
and how to cook. Another example would be you (i.e. Client) switching on (i.e. Command) 
the television (i.e. Receiver) using a remote control (Invoker).

Allows you to encapsulate actions in objects. The key idea behind this pattern is to provide the means to 
decouple client from receiver.

*/

// We have a remote control bulb, bulb(reciever) , remote control(invoker) , turnOn/turnOff(Command) , client is the user

class Bulb
{
    public void TurnOn()
    {
        Console.WriteLine("Bulb has been lit");
    }
    public void TurnOff()
    {
        Console.WriteLine("DarkNess");
    }
}

// Now we create commands

interface ICommand
{
    void Execute();
    void undo();
    void redo();
}

class TurnOn : ICommand
{
    private Bulb mBulb;

    public TurnOn(Bulb bulb)
    {
        mBulb = bulb;
    }

    public void Execute()
    {
        mBulb.TurnOn();
    }

    public void Undo()
    { 
        mBulb.TurnOff();
    }

    public void Redo()
    {
        Execute();
    }
}

class TurnOff : ICommand
{
  private Bulb mBulb;

  public TurnOff(Bulb bulb)
  {
    mBulb = bulb;
  }

  public void Execute()
  {
    mBulb.TurnOff();
  }

  public void Undo()
  {
    mBulb.TurnOn();
  }

  public void Redo()
  {
    Execute();
  }
}

// Invoker remote control

// Invoker
class RemoteControl
{
  public void Submit(ICommand command)
  {
    command.Execute();
  }
}

// client code

var newBulb = new Bulb();
var turnOff = new TurnOff(newBulb);
var turnOn = new TurnOn(newBulb);


RemoteControl newControl = new RemoteControl();

newControl.Submit(turnOff);
newControl.Submit(turnOn);
