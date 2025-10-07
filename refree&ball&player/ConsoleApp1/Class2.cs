using System.Collections;
namespace ConsoleApp1
{
    internal class MyArrayListExample
    {
        private ArrayList list = new ArrayList();

        public void AddItem(object item)
        {
            try
            {
                list.Add(item);
                Console.WriteLine($"Added: {item}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while adding item");
                Console.WriteLine($"Details: {ex.Message}");
            }
        }

        public void RemoveAtIndex(int index)
        {
            try
            {
                list.RemoveAt(index);
                Console.WriteLine($"Removed item at index {index}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Error: Index not valid (ArgumentOutOfRangeException)");
                Console.WriteLine($"Details: {ex.Message}");
            }
        }

        public void GetItem(int index)
        {
            try
            {
                var item = list[index];
                Console.WriteLine($"Item at index {index} = {item}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Error: Index not valid (ArgumentOutOfRangeException)");
                Console.WriteLine($"Details: {ex.Message}");
            }
        }

        public void PrintAll()
        {
            Console.WriteLine("\nCurrent Elements in ArrayList:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
