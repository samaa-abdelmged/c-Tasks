

//Disconnected Mode

using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True;TrustServerCertificate=True;";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            try
            {
                string selectQuery = "SELECT * FROM MyTable";
                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, con);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // 1- Insert
                DataRow newRow = dt.NewRow();
                newRow["id"] = 201;
                newRow["name"] = "Sara";
                newRow["department"] = "Marketing";
                dt.Rows.Add(newRow);

                // 2- Update 
                dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
                DataRow rowToUpdate = dt.Rows.Find(201);
                if (rowToUpdate != null)
                {
                    rowToUpdate["department"] = "Sales";
                }

                // 3- Delete 
                DataRow rowToDelete = dt.Rows.Find(201);
                if (rowToDelete != null)
                {
                    rowToDelete.Delete();
                }

                // 4- Insert مرة ثانية
                DataRow anotherRow = dt.NewRow();
                anotherRow["id"] = 202;
                anotherRow["name"] = "Ali";
                anotherRow["department"] = "IT";
                dt.Rows.Add(anotherRow);

                // تحديث قاعدة البيانات
                adapter.Update(dt);

                Console.WriteLine("Disconnected Mode: Operations completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        Console.ReadKey();
    }
}
