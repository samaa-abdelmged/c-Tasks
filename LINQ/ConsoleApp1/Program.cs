
namespace L2O___D09
{

    class SameCharactersComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            if (x == null || y == null) return false;

            // ترتيب الأحرف أبجدياً ثم مقارنة النصوص
            return String.Concat(x.OrderBy(c => c)) == String.Concat(y.OrderBy(c => c));
        }

        public int GetHashCode(string obj)
        {
            if (obj == null) return 0;

            // نرتب الأحرف ونحسب HashCode
            return String.Concat(obj.OrderBy(c => c)).GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var products = ListGenerators.ProductList;


            // Find all products that are out of stock
            var outOfStock = from p in products
                             where p.UnitsInStock == 0
                             select p;

            Console.WriteLine("Products out of stock:");
            foreach (var p in outOfStock)
                Console.WriteLine(p);

            Console.WriteLine(new string('-', 40));


            // Find all products that are in stock and cost more than 3.00 per unit
            var inStockAndExpensive = from p in products
                                      where p.UnitsInStock > 0 && p.UnitPrice > 3.00M
                                      select p;

            Console.WriteLine("Products in stock and cost > 3.00:");
            foreach (var p in inStockAndExpensive)
                Console.WriteLine(p);

            Console.WriteLine(new string('-', 40));


            // Returns digits whose name is shorter than their value
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var shortNames = from d in Arr
                             let index = Array.IndexOf(Arr, d)
                             where d.Length < index
                             select new { DigitName = d, Index = index };

            Console.WriteLine("Digits whose name is shorter than their value:");
            foreach (var d in shortNames)
                Console.WriteLine($"{d.DigitName} ({d.Index})");

            // Get first Product out of Stock
            var firstOutOfStock = ListGenerators.ProductList
                                     .FirstOrDefault(p => p.UnitsInStock == 0);

            Console.WriteLine("First product out of stock:");
            Console.WriteLine(firstOutOfStock != null ? firstOutOfStock.ToString() : "No product out of stock");


            // Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            var expensiveProduct = ListGenerators.ProductList
                                    .FirstOrDefault(p => p.UnitPrice > 1000);

            Console.WriteLine("First product with price > 1000:");
            Console.WriteLine(expensiveProduct != null ? expensiveProduct.ToString() : "No product found");

            // Retrieve the second number greater than 5 
            int[] ArrGreaterNumber = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var secondGreaterThanFive = ArrGreaterNumber.Where(n => n > 5)
                                           .Skip(1)   // نتجاوز أول عنصر
                                           .FirstOrDefault();

            Console.WriteLine("Second number greater than 5:");
            Console.WriteLine(secondGreaterThanFive);

            //Find the unique Category names from Product List
            var uniqueCategories = ListGenerators.ProductList
                                     .Select(p => p.Category)
                                     .Distinct();

            Console.WriteLine("Unique categories:");
            foreach (var c in uniqueCategories)
                Console.WriteLine(c);

            // Produce a sequence containing the unique first letter from both product and customer names
            var productFirstLetters = ListGenerators.ProductList
                                        .Select(p => p.ProductName[0]);
            var customerFirstLetters = ListGenerators.CustomerList
                                                     .Select(c => c.CompanyName[0]);

            var uniqueFirstLetters = productFirstLetters
                                     .Union(customerFirstLetters);

            Console.WriteLine("Unique first letters from products & customers:");
            foreach (var l in uniqueFirstLetters)
                Console.WriteLine(l);

            // Create one sequence that contains the common first letter from both product and customer names
            var commonFirstLetters = productFirstLetters
                         .Intersect(customerFirstLetters);

            Console.WriteLine("Common first letters:");
            foreach (var l in commonFirstLetters)
                Console.WriteLine(l);

            // Create one sequence that contains the first letters of product names that are not also first letters of customer names
            var productNotInCustomer = productFirstLetters
                           .Except(customerFirstLetters);

            Console.WriteLine("Product first letters not in customer names:");
            foreach (var l in productNotInCustomer)
                Console.WriteLine(l);

            // Create one sequence that contains the last three characters in each name of all customers and products, including duplicates
            var productLastThree = ListGenerators.ProductList
                                     .Select(p => p.ProductName.Length >= 3 ?
                                                  p.ProductName[^3..] : p.ProductName);

            var customerLastThree = ListGenerators.CustomerList
                                                  .Select(c => c.CompanyName.Length >= 3 ?
                                                               c.CompanyName[^3..] : c.CompanyName);

            var allLastThree = productLastThree.Concat(customerLastThree);

            Console.WriteLine("Last three characters from all product & customer names:");
            foreach (var s in allLastThree)
                Console.WriteLine(s);


            // Count the number of odd numbers in the array
            int[] OddNumbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int oddCount = OddNumbers.Count(n => n % 2 != 0);

            Console.WriteLine($"Number of odd numbers: {oddCount}");


            // Return a list of customers and how many orders each has
            var customerOrderCounts = ListGenerators.CustomerList
                                        .Select(c => new
                                        {
                                            CustomerName = c.CompanyName,
                                            OrdersCount = c.Orders.Length
                                        });

            Console.WriteLine("Customers and number of orders:");
            foreach (var c in customerOrderCounts)
                Console.WriteLine($"{c.CustomerName} => {c.OrdersCount} orders");


            // Return a list of categories and how many products each has
            var categoryCounts = ListGenerators.ProductList
                                  .GroupBy(p => p.Category)
                                  .Select(g => new
                                  {
                                      Category = g.Key,
                                      ProductsCount = g.Count()
                                  });

            Console.WriteLine("Categories and number of products:");
            foreach (var c in categoryCounts)
                Console.WriteLine($"{c.Category} => {c.ProductsCount} products");


            // Get the total of the numbers in an array
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int total = numbers.Sum();

            Console.WriteLine($"Total of numbers: {total}");

            // Get the total number of characters of all words in dictionary_english.txt
            string[] words = File.ReadAllLines("dictionary_english.txt");

            int totalChars = words.Sum(word => word.Length);

            Console.WriteLine($"Total number of characters in dictionary: {totalChars}");

            //Get the total units in stock for each product category
            var totalUnitsPerCategory = ListGenerators.ProductList
                                          .GroupBy(p => p.Category)
                                          .Select(g => new
                                          {
                                              Category = g.Key,
                                              TotalUnits = g.Sum(p => p.UnitsInStock)
                                          });

            Console.WriteLine("Total units in stock per category:");
            foreach (var c in totalUnitsPerCategory)
                Console.WriteLine($"{c.Category} => {c.TotalUnits} units");


            //Get the length of the shortest word in dictionary_english.txt

            string[] ShortestWords = File.ReadAllLines("dictionary_english.txt");

            int shortestLength = ShortestWords.Min(w => w.Length);

            Console.WriteLine($"Length of the shortest word: {shortestLength}");


            // Get the cheapest price among each category's products
            var cheapestPricePerCategory = ListGenerators.ProductList
                                            .GroupBy(p => p.Category)
                                            .Select(g => new
                                            {
                                                Category = g.Key,
                                                MinPrice = g.Min(p => p.UnitPrice)
                                            });

            Console.WriteLine("Cheapest price per category:");
            foreach (var c in cheapestPricePerCategory)
                Console.WriteLine($"{c.Category} => {c.MinPrice:C}");


            // Get the products with the cheapest price in each category (Use Let)
            var cheapestProductsPerCategory = from p in ListGenerators.ProductList
                                              group p by p.Category into g
                                              let minPrice = g.Min(x => x.UnitPrice)
                                              select new
                                              {
                                                  Category = g.Key,
                                                  Products = g.Where(x => x.UnitPrice == minPrice)
                                              };

            Console.WriteLine("Products with cheapest price per category:");
            foreach (var group in cheapestProductsPerCategory)
            {
                Console.WriteLine($"Category: {group.Category}");
                foreach (var p in group.Products)
                    Console.WriteLine($"  {p.ProductName} => {p.UnitPrice:C}");
            }

            // Get the length of the longest word in dictionary_english.txt
            int longestLength = words.Max(w => w.Length);

            Console.WriteLine($"Length of the longest word: {longestLength}");

            // Get the most expensive price among each category's products
            var mostExpensivePricePerCategory = ListGenerators.ProductList
                                                 .GroupBy(p => p.Category)
                                                 .Select(g => new
                                                 {
                                                     Category = g.Key,
                                                     MaxPrice = g.Max(p => p.UnitPrice)
                                                 });

            Console.WriteLine("Most expensive price per category:");
            foreach (var c in mostExpensivePricePerCategory)
                Console.WriteLine($"{c.Category} => {c.MaxPrice:C}");

            // Get the products with the most expensive price in each category
            var mostExpensiveProductsPerCategory = from p in ListGenerators.ProductList
                                                   group p by p.Category into g
                                                   let maxPrice = g.Max(x => x.UnitPrice)
                                                   select new
                                                   {
                                                       Category = g.Key,
                                                       Products = g.Where(x => x.UnitPrice == maxPrice)
                                                   };

            Console.WriteLine("Products with the most expensive price per category:");
            foreach (var group in mostExpensiveProductsPerCategory)
            {
                Console.WriteLine($"Category: {group.Category}");
                foreach (var p in group.Products)
                    Console.WriteLine($"  {p.ProductName} => {p.UnitPrice:C}");
            }


            // Get the average length of the words in dictionary_english.txt

            string[] AverageLengthWords = File.ReadAllLines("dictionary_english.txt");

            double averageWordLength = AverageLengthWords.Average(w => w.Length);

            Console.WriteLine($"Average length of words in dictionary: {averageWordLength:F2}");


            // Get the average price of each category's products
            var averagePricePerCategory = ListGenerators.ProductList
                                           .GroupBy(p => p.Category)
                                           .Select(g => new
                                           {
                                               Category = g.Key,
                                               AvgPrice = g.Average(p => p.UnitPrice)
                                           });

            Console.WriteLine("Average price per category:");
            foreach (var c in averagePricePerCategory)
                Console.WriteLine($"{c.Category} => {c.AvgPrice:C}");


            // Sort a list of products by name
            var productsSortedByName = ListGenerators.ProductList
                                         .OrderBy(p => p.ProductName);

            Console.WriteLine("Products sorted by name:");
            foreach (var p in productsSortedByName)
                Console.WriteLine(p.ProductName);


            // Uses a custom comparer to do a case-insensitive sort of the words in an array
            string[] CaseInsensitiveSort = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var caseInsensitiveSorted = CaseInsensitiveSort.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);

            Console.WriteLine("Words sorted case-insensitive:");
            foreach (var w in caseInsensitiveSorted)
                Console.WriteLine(w);


            // Sort a list of products by units in stock from highest to lowest
            var productsByStockDesc = ListGenerators.ProductList
                                        .OrderByDescending(p => p.UnitsInStock);

            Console.WriteLine("Products sorted by units in stock (highest to lowest):");
            foreach (var p in productsByStockDesc)
                Console.WriteLine($"{p.ProductName} => {p.UnitsInStock}");


            // Sort a list of digits, first by length of their name, and then alphabetically
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var sortedDigits = digits.OrderBy(d => d.Length)
                                     .ThenBy(d => d);

            Console.WriteLine("Digits sorted by length, then alphabetically:");
            foreach (var d in sortedDigits)
                Console.WriteLine(d);


            // Sort first by word length and then by a case-insensitive sort of the words in an array
            string[] LengthThenCaseInsensitiveArray = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedByLengthThenCaseInsensitive = LengthThenCaseInsensitiveArray
                .OrderBy(w => w.Length)
                .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

            Console.WriteLine("Words sorted by length, then case-insensitive:");
            foreach (var w in sortedByLengthThenCaseInsensitive)
                Console.WriteLine(w);


            // Sort a list of products, first by category, and then by unit price, from highest to lowest
            var productsSortedByCategoryAndPrice = ListGenerators.ProductList
                                                    .OrderBy(p => p.Category)
                                                    .ThenByDescending(p => p.UnitPrice);

            Console.WriteLine("Products sorted by category, then by unit price (high to low):");
            foreach (var p in productsSortedByCategoryAndPrice)
                Console.WriteLine($"{p.Category} - {p.ProductName} => {p.UnitPrice:C}");


            // Sort first by word length and then by a case-insensitive descending sort of the words in an array
            string[] CaseInsensitiveDescArr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedByLengthThenCaseInsensitiveDesc = CaseInsensitiveDescArr
                .OrderBy(w => w.Length)
                .ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);

            Console.WriteLine("Words sorted by length, then case-insensitive descending:");
            foreach (var w in sortedByLengthThenCaseInsensitiveDesc)
                Console.WriteLine(w);

            // Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array
            string[] digitsArr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var filteredReversedDigits = digitsArr.Reverse()
                                               .Where(d => d.Length > 1 && d[1] == 'i');

            Console.WriteLine("Digits whose second letter is 'i', reversed from original order:");
            foreach (var d in filteredReversedDigits)
                Console.WriteLine(d);


            // Get the first 3 orders from customers in Washington
            var first3OrdersWashington = ListGenerators.CustomerList
                                           .Where(c => c.City == "Washington")
                                           .SelectMany(c => c.Orders)
                                           .Take(3);

            Console.WriteLine("First 3 orders from customers in Washington:");
            foreach (var o in first3OrdersWashington)
                Console.WriteLine(o);

            // Get all but the first 2 orders from customers in Washington
            var allButFirst2OrdersWashington = ListGenerators.CustomerList
                                                 .Where(c => c.City == "Washington")
                                                 .SelectMany(c => c.Orders)
                                                 .Skip(2);

            Console.WriteLine("All but first 2 orders from customers in Washington:");
            foreach (var o in allButFirst2OrdersWashington)
                Console.WriteLine(o);


            // Return elements starting from the beginning of the array until a number is hit that is less than its position
            int[] numbersArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var takeWhileCondition = numbersArr.TakeWhile((n, index) => n >= index);

            Console.WriteLine("Elements until a number < its position:");
            foreach (var n in takeWhileCondition)
                Console.WriteLine(n);


            // Get the elements of the array starting from the first element divisible by 3
            var skipUntilDivisibleBy3 = numbers.SkipWhile(n => n % 3 != 0);

            Console.WriteLine("Elements starting from first divisible by 3:");
            foreach (var n in skipUntilDivisibleBy3)
                Console.WriteLine(n);


            // Get the elements of the array starting from the first element less than its position
            var skipUntilLessThanPosition = numbers.SkipWhile((n, index) => n >= index);

            Console.WriteLine("Elements starting from first element < its position:");
            foreach (var n in skipUntilLessThanPosition)
                Console.WriteLine(n);


            // Return a sequence of just the names of a list of products
            var productNames = ListGenerators.ProductList
                                 .Select(p => p.ProductName);

            Console.WriteLine("Product names:");
            foreach (var name in productNames)
                Console.WriteLine(name);


            // Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types)
            string[] WordsArray = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var upperLowerWords = WordsArray.Select(w => new
            {
                Upper = w.ToUpper(),
                Lower = w.ToLower()
            });

            Console.WriteLine("Words in uppercase and lowercase:");
            foreach (var w in upperLowerWords)
                Console.WriteLine($"Upper: {w.Upper}, Lower: {w.Lower}");


            // Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type
            var productInfo = ListGenerators.ProductList
                                .Select(p => new
                                {
                                    p.ProductID,
                                    p.ProductName,
                                    p.Category,
                                    Price = p.UnitPrice
                                });

            Console.WriteLine("Selected product properties (Price renamed):");
            foreach (var p in productInfo)
                Console.WriteLine($"ID: {p.ProductID}, Name: {p.ProductName}, Category: {p.Category}, Price: {p.Price:C}");

            // Determine if the value of ints in an array match their position in the array
            int[] NumbersArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var matchPosition = NumbersArr.Select((value, index) => new
            {
                Value = value,
                Position = index,
                Matches = value == index
            });

            Console.WriteLine("Do array values match their positions?");
            foreach (var item in matchPosition)
                Console.WriteLine($"Value: {item.Value}, Position: {item.Position}, Matches: {item.Matches}");


            // Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var numberPairs = from a in numbersA
                              from b in numbersB
                              where a < b
                              select (a, b);

            Console.WriteLine("Pairs where number from A < number from B:");
            foreach (var pair in numberPairs)
                Console.WriteLine($"({pair.a}, {pair.b})");


            // Determine if any of the words in dictionary_english.txt contain the substring 'ei'
            string[] FileInWords = File.ReadAllLines("dictionary_english.txt");

            bool anyContainsEi = FileInWords.Any(w => w.Contains("ei"));

            Console.WriteLine($"Any word contains 'ei'? {anyContainsEi}");


            // Return a grouped list of products only for categories that have at least one product that is out of stock
            var categoriesWithOutOfStock = ListGenerators.ProductList
                                             .GroupBy(p => p.Category)
                                             .Where(g => g.Any(p => p.UnitsInStock == 0));

            Console.WriteLine("Categories with at least one product out of stock:");
            foreach (var g in categoriesWithOutOfStock)
            {
                Console.WriteLine($"Category: {g.Key}");
                foreach (var p in g)
                    Console.WriteLine($"  {p.ProductName} => UnitsInStock: {p.UnitsInStock}");
            }


            // Return a grouped list of products only for categories that have all of their products in stock
            var categoriesAllInStock = ListGenerators.ProductList
                                         .GroupBy(p => p.Category)
                                         .Where(g => g.All(p => p.UnitsInStock > 0));

            Console.WriteLine("Categories where all products are in stock:");
            foreach (var g in categoriesAllInStock)
            {
                Console.WriteLine($"Category: {g.Key}");
                foreach (var p in g)
                    Console.WriteLine($"  {p.ProductName} => UnitsInStock: {p.UnitsInStock}");
            }


            // Use group by to partition a list of numbers by their remainder when divided by 5
            int[] numbersArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var groupsByRemainder = numbersArray.GroupBy(n => n % 5);

            Console.WriteLine("Numbers grouped by remainder when divided by 5:");
            foreach (var g in groupsByRemainder)
            {
                Console.WriteLine($"Remainder {g.Key}: {string.Join(", ", g)}");
            }

            // Use group by to partition a list of words by their first letter (using dictionary_english.txt)
            string[] WordsArrayInFile = File.ReadAllLines("dictionary_english.txt");

            var groupsByFirstLetter = WordsArrayInFile.GroupBy(w => w[0]);

            Console.WriteLine("Words grouped by first letter:");
            foreach (var g in groupsByFirstLetter)
            {
                Console.WriteLine($"Letter '{g.Key}': {string.Join(", ", g.Take(10))}..."); // عرض أول 10 كلمات فقط
            }


            // Use Group By with a custom comparer that matches words that consist of the same characters together
            string[] WordsArr = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

            // تنظيف المسافات الزائدة
            var trimmedWords = WordsArr.Select(w => w.Trim()).ToArray();

            /////////////
            var groupsBySameCharacters = trimmedWords.GroupBy(w => w, new SameCharactersComparer());

            Console.WriteLine("Words grouped by same characters:");
            foreach (var g in groupsBySameCharacters)
            {
                Console.WriteLine($"Group: {string.Join(", ", g)}");
            }

        }
    }
}
