using Microsoft.Data.SqlClient;
using System.Data;
using System.Drawing;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True;TrustServerCertificate=True;";

        // Disconnected mode DataTable
        SqlDataAdapter adapter;
        SqlCommandBuilder builder;
        DataTable dt = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadDataDisconnected();

        }


        private void LoadDataDisconnected()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM MyTable";
                adapter = new SqlDataAdapter(selectQuery, con);
                builder = new SqlCommandBuilder(adapter);
                dt = new DataTable();
                adapter.Fill(dt);


                dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
                if (!dt.Columns.Contains("id"))
                {
                    MessageBox.Show("Column 'id' not found. Required for Disconnected Mode.");
                    return;
                }
                dataGridView1.DataSource = dt;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string selectQuery = "SELECT * FROM MyTable";
                    adapter = new SqlDataAdapter(selectQuery, con);
                    builder = new SqlCommandBuilder(adapter);
                    dt = new DataTable();
                    adapter.Fill(dt);

                    dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
                    DataRow rowToUpdate = dt.Rows.Find(102);
                    if (rowToUpdate != null)
                    {
                        rowToUpdate["department"] = "sales";
                    }

                    adapter.Update(dt);
                    MessageBox.Show("Disconnected Mode: Update completed!");
                    LoadDataDisconnected();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // حذف أول صف كمثال
                if (dt.Rows.Count > 0)
                {
                    dt.Rows[0].Delete();
                    adapter.Update(dt);
                    MessageBox.Show("Disconnected Mode: Delete completed!");
                    LoadDataDisconnected();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnInsertDisconnected_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string selectQuery = "SELECT * FROM MyTable";
                    adapter = new SqlDataAdapter(selectQuery, con);
                    builder = new SqlCommandBuilder(adapter);
                    dt = new DataTable();
                    adapter.Fill(dt);

                    DataRow newRow = dt.NewRow();
                    newRow["id"] = 2002;
                    newRow["name"] = "soso";
                    newRow["department"] = "Marketing";
                    dt.Rows.Add(newRow);
                    adapter.Update(dt);

                    MessageBox.Show("Disconnected Mode: Insert completed!");
                    LoadDataDisconnected();

                }
            }
            catch (Exception ex)

            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // مثال Insert
                    string insertQuery = "INSERT INTO MyTable (id, name, department) VALUES (1001, 'Ahmed', 'IT')";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                    insertCmd.ExecuteNonQuery();
                    MessageBox.Show("Inserted Successfully!");
                    LoadDataDisconnected();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // مثال Update
                    string updateQuery = "UPDATE MyTable SET department='HR' WHERE id=1001";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                    updateCmd.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully!");
                    LoadDataDisconnected();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    // مثال Delete
                    string deleteQuery = "DELETE FROM MyTable WHERE id=1001";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, con);
                    deleteCmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted Successfully!");
                    LoadDataDisconnected();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
