

//Connected Mode

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
                con.Open();

                // 1- Insert
                string insertQuery = "INSERT INTO MyTable (id, name, department) VALUES (101, 'Ahmed', 'IT')";
                SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                insertCmd.ExecuteNonQuery();

                // 2- Update
                string updateQuery = "UPDATE MyTable SET department = 'HR' WHERE id = 101";
                SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                updateCmd.ExecuteNonQuery();

                // 3- Delete
                string deleteQuery = "DELETE FROM MyTable WHERE id = 101";
                SqlCommand deleteCmd = new SqlCommand(deleteQuery, con);
                deleteCmd.ExecuteNonQuery();

                // 4- Insert مرة ثانية
                string insert2Query = "INSERT INTO MyTable (id, name, department) VALUES (102, 'Mona', 'Finance')";
                SqlCommand insert2Cmd = new SqlCommand(insert2Query, con);
                insert2Cmd.ExecuteNonQuery();

                Console.WriteLine("Connected Mode: Operations completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        Console.ReadKey();
    }
}
