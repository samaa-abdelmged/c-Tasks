using ConsoleApp1;
using System.Collections;

class Program
{
    static void Main()
    {
        Class1 obj1 = new Class1();
        obj1.divide();

        ////////////////////////////////////////////////////


        MyArrayListExample example = new MyArrayListExample();

        example.AddItem("Ahmed");
        example.AddItem(25);
        example.AddItem(3.14);

        example.PrintAll();

        example.GetItem(1);

        example.RemoveAtIndex(0);

        example.PrintAll();

        example.GetItem(10);

        /////////////////////////////////////////////////////

        using (MyFileWriter f = new MyFileWriter("text.txt"))
        {
            f.WriteData("Hello World!");
            f.WriteData("Dispose Example");
        }

        Console.WriteLine("Program finished.");

        ////////////////////////////////////////////////////

        ArrayList list = new ArrayList();
        list.Add("Ahmed");
        list.Add(true);
        list.Add(30);
        list.Add(3.14);

        MyArrayListToFile fileWriter = new MyArrayListToFile("data.txt");

        try
        {
            fileWriter.SaveArrayList(list);
        }
        finally
        {
            fileWriter.Dispose();
        }

        Console.WriteLine("Finished writing ArrayList to file.");
        Console.ReadLine();
    }
}
