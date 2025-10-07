namespace WinFormsApp1
{
    public partial class Form3 : Form
    {

        private int ballX = 50;
        private int ballY = 50;
        private int ballSize = 50;
        private int dx = 5;
        private int dy = 5;


        public Form3()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ballX += dx;

            ballY += dy;

            if (ballX + ballSize >= this.ClientSize.Width || ballX <= 0)
            {
                dx = -dx;
            }

            if (ballY + ballSize >= this.ClientSize.Height || ballY <= 0)
            {
                dy = -dy;
            }

            this.Invalidate();
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, ballX, ballY, ballSize, ballSize);

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}