namespace ConsoleApp1
{
    internal class Class1
    {
        public void divide()
        {
            try
            {
                Console.WriteLine("Enter First Number:");
                int num1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Second Number:");
                int num2 = Convert.ToInt32(Console.ReadLine());

                int result = num1 / num2;
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("⚠️ Error:can't divide by zero");
                Console.WriteLine($"Details of error: {ex.Message}");
            }

            catch (OverflowException ex)
            {
                Console.WriteLine("⚠️ happened OverflowException!");
                Console.WriteLine($"Details of error: {ex.Message}");
            }

            catch (NullReferenceException ex)
            {
                Console.WriteLine("⚠️ happened NullReferenceException");
                Console.WriteLine($"Details of error: {ex.Message}");
            }

            catch (FormatException ex)
            {
                Console.WriteLine("⚠️ happened FormatException"); //diffrent type
                Console.WriteLine($"Details of error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("⚠️ happened error can't expected!");
                Console.WriteLine($"Details of error: {ex.Message}");
            }

            finally
            {
                Console.WriteLine(" Program finished.");
            }
        }

    }
}
