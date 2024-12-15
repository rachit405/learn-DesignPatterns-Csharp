using System.Net;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Please find out the progress");

        //Only un-comment the methods that you are testing

        //1.
        //ReverseString("ABCD");

        //2.
        //IfPalindrome("AABBAA");

        //3. How to count the occurrence of each character in a string?
        //FindOccurOfEachWord("How to count the occurrence of each character in a string?");

        //4.
        //Remove Repeated Elements in an Array
        int[] arr = { 1, 2, 3, 1, 2, 4, 5 };
        //RemoveRepeatedElementsInArray(arr);

        //5. Find the Maximum Element in an Array
        //FindMaxElement(arr);
                
        //6. Given an array of integers, find the sum of all elements.
        //SumOfAllElements(arr);

        //7.  How to remove duplicate characters from a string
        //RemoveDuplicateChar("aabbccdd");

        //8.

    }

    // Write a Program to reverse a string

    static void ReverseString(string str)
    {
        char[] charArray = str.ToCharArray();
        for (int i = 0, j = charArray.Length - 1; i < j; i++, j--)
        {
            char c = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = c;
        }
        Console.WriteLine(charArray);
        string reversedString = new string(charArray);
        Console.WriteLine(reversedString);
    }

    // Write to check if the given string is a palendrome

    static void IfPalindrome(string str)
    {
        var charArray = str.ToArray();
        bool flag = true;
        for (int i = 0, j = charArray.Length - 1; i < (charArray.Length / 2); i++, j--)
        {
            if (charArray[i] != charArray[j])
            {
                flag = false;
                break;
            }
        }
        if (flag)
            Console.WriteLine("This string is a Palindrome");
        else
            Console.WriteLine("This string is not a Palindrome");

    }

    static void FindOccurOfEachWord(string str)
    {
        Dictionary<char, int> charCounter = new Dictionary<char, int>();
        foreach (var a in str)
        {
            if (a != ' ')
            {
                if (charCounter.ContainsKey(a))
                {
                    charCounter[a]++;
                }
                else
                    charCounter.Add(a, 1);
            }

        }

        foreach(var a in charCounter.Keys)
        {
            Console.WriteLine("The character {0} occured {1} times" , a, charCounter[a]);
        }
    }

    static void RemoveRepeatedElementsInArray(int[] arr)
    {
        HashSet<int> uniqueSet = new HashSet<int>();
        foreach (var a in arr)
        {
            if (uniqueSet.Contains(a))
                continue;
            else
                uniqueSet.Add(a);    
        }

        foreach(var a in uniqueSet)
        {
            Console.Write(a + " ");       
        }
    }

    static void FindMaxElement(int[] arr)
    {
        int maxElement = 0;
        foreach (var a in arr)
        {
            if(a>maxElement)
            {
                maxElement = a;
            }
        }
        Console.WriteLine(" The maximum element is : {0}" , maxElement);
    }
    static void SumOfAllElements(int[] arr)
    {
        int sum = 0;
        foreach(var a in arr)
            sum += a;
        Console.WriteLine("The total sum is : {0} " , sum);
    }

    static void RemoveDuplicateChar(string str)
    {
        StringBuilder uniqElementString = new StringBuilder();
        HashSet<char> uniqChars= new HashSet<char>();
        foreach(var a in str)
        {
            if(!uniqChars.Contains(a))
            {
                uniqChars.Add(a);
                uniqElementString.Append(a);
            }
            else
                continue;
        }

        Console.WriteLine($" The unique Element string is {uniqElementString}");       
    }
}