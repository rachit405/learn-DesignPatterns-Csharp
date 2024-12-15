public class President
{
    private static President president = null;
    private static readonly object padlock = new object();
    
    private President
    {

    }

    public static President getInstance()
    {
        lock (padlock)
        {
            if(president == null)
            {
                president = new President();
            }
            return president;
        }
        
    }
}