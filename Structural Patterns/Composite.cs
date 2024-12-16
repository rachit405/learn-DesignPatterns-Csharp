// When you want to break down the hierarchy in a tree like structure
/* 
When you want to create a file system, you want treat files and folders the same way
So it allows us to treat individual objects and compositon of objects uniformly;
Since a folder is nothing but just a collection of files.

So it's gonna allow you to create a tree structre and handle files and folders in a consistent way

*/

interface IEmployee
{
    float GetSalary();
    string GetName();
    string GetRole();
}

class Developer : IEmployee
{
    private string mName;
    private float mSalary;

    public Developer(string name, float salary)
  {
    this.mName = name;
    this.mSalary = salary;
  }
    public float GetSalary()
    {
        return this.mSalary;
    }
    public string GetName()
    {
        return this.mName;
    }
    public string GetRole()
    {
        return "DEV";
    }
}


class Designer : IEmployee
{
    private string mName;
    private float mSalary;

    public Designer(string name, float salary)
    {
        this.mName = name;
        this.mSalary = salary;
    }
    public float GetSalary()
    {
        return this.mSalary;
    }
    public string GetName()
    {
        return this.mName;
    }
    public string GetRole()
    {
        return "DESIGN";
    }
    
   
}

class Organization
{
    protected List<IEmployee> employees;

    public Organization()
    {
        employees = new List<IEmployee>();
    }

    public void AddEmployee(IEmployee employee)
    {
        employees.Add(employee);
    }

    public float GetNetSalaries()
    {
    float netSalary = 0;

        foreach (var e in employees) {
        netSalary += e.GetSalary();
        }
        return netSalary;
    }

    // IN client code

    var developer = new Developer("ABC", 10);
    var designer = new Designer("DEF", 10);

    var organization = new Organization();
    organization.AddEmployee(developer);
    organization.AddEmployee(designer);

    Console.WriteLine($"Net Salary of Employees in Organization is {organization.GetNetSalaries():c}");
}


