namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private bool isDrawing = false;
        private Color currentColor = Color.Red;

        public Form2()
        {
            this.MouseDown += Form2_MouseDown;
            this.MouseMove += Form2_MouseMove;
            this.MouseUp += Form2_MouseUp;
            InitializeComponent();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                currentColor = Color.Red;
            else if (e.Button == MouseButtons.Right)
                currentColor = this.BackColor;

            isDrawing = true;
        }
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                using (Graphics grx = this.CreateGraphics())
                {
                    grx.FillEllipse(new SolidBrush(currentColor), e.X, e.Y, 5, 5);
                }
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isDrawing = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
