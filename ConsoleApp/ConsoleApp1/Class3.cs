namespace ConsoleApp1
{
    class MyFileWriter : IDisposable
    {
        private StreamWriter writer;

        //open file
        public MyFileWriter(string path)
        {
            writer = new StreamWriter(path, append: true);
            Console.WriteLine("File opened.");
        }

        //write data
        public void WriteData(string data)
        {
            writer.WriteLine(data);
            Console.WriteLine($"Wrote: {data}");
        }

        //close file
        public void Dispose()
        {
            if (writer != null)
            {
                writer.Dispose();
                Console.WriteLine("File closed & resources disposed.");
            }
        }
    }
}