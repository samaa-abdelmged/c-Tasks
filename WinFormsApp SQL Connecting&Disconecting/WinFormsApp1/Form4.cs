namespace WinFormsApp1
{
    public partial class Form4 : Form
    {

        public Form4()
        {
            InitializeComponent();
            LoadStudents();
        }

        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Year { get; set; }
            public string Major { get; set; }


        }

        List<Student> students = new List<Student>()
        {
            new Student { Id = 1, Name = "Ahmed", Year = 2, Major = "Computer Science" },
            new Student { Id = 2, Name = "Mona", Year = 3, Major = "Information Systems" },
            new Student { Id = 3, Name = "Omar", Year = 1, Major = "Math" }
        };


        private void LoadStudents()
        {
            comboBox1.DataSource = students;
            comboBox1.DisplayMember = "Name";
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "Choose Student Name!";
            textBox1.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Student selected = comboBox1.SelectedItem as Student;

            if (selected != null)
            {
                textBox1.Text =
                selected.Id + Environment.NewLine +
                selected.Name + Environment.NewLine +
                selected.Year + Environment.NewLine +
                selected.Major + Environment.NewLine;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
