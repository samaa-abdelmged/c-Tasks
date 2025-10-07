
using System.Xml.Linq;

namespace L2O___D09
{
    public class Customer
    {
        public Customer(string customerID, string companyName)
        {
            CustomerID = customerID;
            CompanyName = companyName;
            Orders = new Order[10];
        }

        public Customer() { }

        public string CustomerID;
        public string CompanyName;
        public string Address;
        public string City;
        public string Region;
        public string PostalCode;
        public string Country;
        public string Phone;
        public string Fax;
        public Order[] Orders;


        public override string ToString()
        {
            return $"{CustomerID},{CompanyName},{Address}, {City} , {Region}, {PostalCode} , {Country} , {Phone} , {Fax}";
        }
    }

    public class Order
    {
        public Order(int orderID, DateTime orderDate, decimal total)
        {
            OrderID = orderID;
            OrderDate = orderDate;
            Total = total;
        }

        public Order() { }

        public int OrderID;
        public DateTime OrderDate;
        public decimal Total;

        public override string ToString()
        {
            return $"Order Id: {OrderID},Date: {OrderDate.ToShortTimeString()},Total: {Total}";
        }
    }

    public class Product
    {
        public Int64 ProductID { get; set; }
        public String ProductName { get; set; }
        public String Category { get; set; }
        public Decimal UnitPrice { get; set; }
        public Int32 UnitsInStock { get; set; }

        public override string ToString()
        {
            return $"ProductID:{ProductID},ProductName:{ProductName},Category{Category},UnitPrice:{UnitPrice},UnitsInStock:{UnitsInStock}";
        }
    }

    public static class ListGenerators
    {
        public static List<Customer> CustomerList;
        public static List<Product> ProductList;
        static ListGenerators()
        {
            #region CustomerList
            CustomerList = (
                from e in XDocument.Load("customers.xml").
                          Root.Elements("customer")
                select new Customer
                {
                    CustomerID = (string)e.Element("id"),
                    CompanyName = (string)e.Element("name"),
                    Address = (string)e.Element("address"),
                    City = (string)e.Element("city"),
                    Region = (string)e.Element("region"),
                    PostalCode = (string)e.Element("postalcode"),
                    Country = (string)e.Element("country"),
                    Phone = (string)e.Element("phone"),
                    Fax = (string)e.Element("fax"),
                    Orders = (
                        from o in e.Elements("orders").Elements("order")
                        select new Order
                        {
                            OrderID = (int)o.Element("id"),
                            OrderDate = (DateTime)o.Element("orderdate"),
                            Total = (decimal)o.Element("total")
                        })
                        .ToArray()
                }
                ).ToList();
            #endregion

            #region ProductList
            ProductList = new List<Product>() {
              new Product{ ProductID = 1, ProductName = "Chai", Category = "Beverages",
                UnitPrice = 18.0000M, UnitsInStock = 39 },
               };
            #endregion
        }

    }


}
