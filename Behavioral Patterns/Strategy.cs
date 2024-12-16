/* 
Strategy pattern allows you to switch the algorithm or strategy based upon the situation.


*/

// First we create a generic strategy interface and create 2 concrete strategies

interface ISortStrategy
{
  List<int> Sort(List<int> dataset);
}

class BubbleSortStrategy : ISortStrategy
{
  public List<int> Sort(List<int> dataset)
  {
    Console.WriteLine("Sorting using Bubble Sort !");
    return dataset;
  }
}

class QuickSortStrategy : ISortStrategy
{
  public List<int> Sort(List<int> dataset)
  {
    Console.WriteLine("Sorting using Quick Sort !");
    return dataset;
  }
}

//the abstract methods that uses the diff strategy and call to execute them

class Sorter
{
  private readonly ISortStrategy mSorter;

  public Sorter(ISortStrategy sorter)
  {
    mSorter = sorter;
  }

  public List<int> Sort(List<int> unSortedList)
  {
    return mSorter.Sort(unSortedList);
  }
}


// client code to use this

var unSortedList = new List<int> { 1, 10, 2, 16, 19 };

var sorter = new Sorter(new BubbleSortStrategy());
sorter.Sort(unSortedList); // // Output : Sorting using Bubble Sort !

sorter = new Sorter(new QuickSortStrategy());
sorter.Sort(unSortedList); // // Output : Sorting using Quick Sort !