/* Hunter hunts Lions
So we have hunter and lion with different types
So a hunter class with Hunt method and a Lion interface for the types of lion */

interface ILion 
{
    void Roar();
}

class AsianLion : ILion
{
    public void Roar()
    {
        Console.WriteLine("ROAR!!");
    }
}

class AfricanLion : ILion
{
    public void Roar()
    {
        Console.WriteLine("ROAR!!");
    }
}

class Hunter 
{
    public void Hunt(ILion Lion)
    (

    )
}

// Now the hunter's Hunt function should be able to hunt wild dogs as well

class WildDogs
{
    public void Bark()
    {
        Console.WriteLine("BARK!!");
    }
}

// Now will create an adaptor that will make the wild dog object compatible with Ilion

class WildDogAdapter : ILion
{
  private WildDogs mDog;
  public WildDogAdapter(WildDogs dog)
  {
    this.mDog = dog;
  }
  public void Roar()
  {
    mDog.bark();
  }
}

// In client code

WildDogs wildDog = new WildDogs();
WildDogAdapter wildDogAdapter= new WildDogAdapter(wildDog);

Hunter hunter= new Hunter();
hunter.Hunt(wildDog);
