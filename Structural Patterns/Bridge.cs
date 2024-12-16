// Bridge pattern
/* 
Used when you have a large class under which you have different hierarchies, 
that you want to scale up separately, otherwise it will end up being too confusing and messy code.

Example
1st example
Remote and a device class, where we have different types of remotes and devices having different properties
but every device needs a remote to function

2nd example
we have a webpage and a lot of different themes under it
*/

interface IWebPage
{
    void GetContent();
}

class HomePage : IWebPage
{
    protected ITheme theme;

    public HomePage(ITheme theme)
    {
        this.theme = theme;
    }
    public void GetContent()
    {
        return $"Home page in {theme.GetColor()}";
    }
}

class AboutPage : IWebPage
{
    protected ITheme theme;

    public AboutPage(ITheme theme)
    {
        this.theme = theme;
    }
    public void GetContent()
    {
        return $"About page in {theme.GetColor()}";
    }
}


// For themes, since every webpage needs a theme

interface ITheme
{
    string GetColor();
}

class LightTheme : ITheme
{
    public string GetColor()
    {
        return "Off White";
    }
}

class DarkTheme : ITheme
{
    public string GetColor()
    {
        return "Dark Black";
    }
}


// Client Code 

var darkTheme = new DarkTheme();
var lightTheme = new LightTheme();

var about= new About(darkTheme);
var careers = new Careers(lightTheme);

Console.WriteLine(about.GetContent()); //Output: About page in Dark Black
Console.WriteLine(careers.GetContent()); //Output: Careers page in Off White

