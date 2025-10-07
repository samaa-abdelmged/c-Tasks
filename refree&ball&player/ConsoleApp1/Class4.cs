using System.Collections;

namespace ConsoleApp1
{
    internal class MyArrayListToFile : IDisposable
    {
        private TextWriter writer;
        private bool disposed = false;

        public MyArrayListToFile(string path)
        {
            writer = new StreamWriter(path, append: true);
            Console.WriteLine("File opened.");
        }

        public void SaveArrayList(ArrayList list)
        {
            foreach (var item in list)
            {
                writer.WriteLine(item);
                Console.WriteLine($"Wrote: {item}");
            }
        }

        public void Dispose()
        {
            if (!disposed)
            {
                if (writer != null)
                {
                    writer.Dispose();
                    Console.WriteLine("File closed & resources disposed.");
                }
                disposed = true;
            }
        }
    }
}