using System;

public class Program
{

    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.
        var numbers = new[] { 1, 2, 3 };//fixed array
            
        int[] num=new int[5];//fixed array
              num=new int[] {3,4,6,7,9};
              

        List<string> fruits=new List<string>();//dynamic array
        fruits.Add("mango");
        fruits.Add("pear");
        fruits.Add("banana");
        fruits.RemoveAt(1);
        fruits.Insert(2,"Orange");
        fruits.Insert(1,"kiwi");

        List<int> numb=new List<int>() {4,5,6,6,8,9,10};
                numb.Add(20);
                numb.Add(22);
                numb.Insert(0,45);

        foreach(var num1 in numb)
        {
            Console.WriteLine(num1);
        }

        for (var i=0;i<fruits.Count;i++)
        {
          Console.WriteLine($"{i+1}. fruit : {fruits[i]}");
        }

       var myList=new List<string>() {"A","B","C","D"};
           Console.WriteLine(myList.Count);
           Console.WriteLine(myList.Capacity);
           myList.Add("E");
            Console.WriteLine($"The size or count is now :{myList.Count}");
           Console.WriteLine($"The capacity is now : {myList.Capacity}");
           myList.Remove("B");
           Console.WriteLine(myList);
           Console.WriteLine(string.Join(" * ", myList)); // OUTPUT : A * C * D * E
           Console.WriteLine($"[{string.Join(", ", myList)}]"); //this is actual array [A,C,D,E]
           myList.Insert(myList.Count-1,"B");
           Console.WriteLine(string.Join(" * ", myList)); 
           Console.WriteLine($"[{string.Join(", ", myList)}]"); 
            myList.Insert(myList.Capacity-3,"F");
            Console.WriteLine($"[{string.Join(", ", myList)}]");//output : [A, C, D, B, E, F]
            Console.WriteLine($"The new size is {myList.Count} and capacity is {myList.Capacity}");//size  6 capacity 8
           
      List<int> ints=new List<int>() {1,2,3,4,5,6,7,8,9};

      int lastIndex=ints.Count-1;
      Console.WriteLine($"The last index of the list is {lastIndex}");//output : 8
      int length=ints.Count;
      Console.WriteLine($"The length of the list is {length}");//output : 9
      int capacity=ints.Capacity;
      Console.WriteLine($"The capacity of the list is {capacity}");//output : 12
      int middle=ints.Count/2;
      Console.WriteLine($"The middle of the list is {middle}");//output : 4
      int getRange=ints.GetRange(2,4).Count;
      Console.WriteLine($"The count of the range is {getRange}");//output : 4
      List<int> getAnotherRange = ints.GetRange(3, ints.Count - 3);

     Console.WriteLine($"The range is {string.Join(", ", getAnotherRange)}");

        // Console.WriteLine(fruits[0])
        // Console.WriteLine("Hello Sandbox World!");
        // Console.WriteLine(num[2]);
        // Console.WriteLine(numb[5]);
        // Console.WriteLine(numb.Count);
        // Console.WriteLine(fruits[3]);
        // Console.WriteLine(fruits.Count);
        // Console.WriteLine($"The number of fruits in my basket is {fruits.Count}");
        // Console.WriteLine($"The capacity of my numb arrray(list)  is {numb.Capacity}");
        // Console.WriteLine($"The number of items in my numb arrray(list)  is {numb.Count}");
    }
}