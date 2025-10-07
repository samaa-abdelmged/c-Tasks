namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        private int ballX = 50;
        private int ballY = 50;
        private int ballSize = 50;
        private int dx = 5;
        private int dy = 2;


        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // الحركة يمين وشمال
            ballX += dx;

            // الحركة فوق وتحت
            ballY += dy;

            // لو الكورة لمست الحافة اليمين أو الشمال
            if (ballX + ballSize >= this.ClientSize.Width || ballX <= 0)
            {
                dx = -dx; // عكس الاتجاه
            }

            // لو الكورة لمست الحافة فوق أو تحت
            if (ballY + ballSize >= this.ClientSize.Height || ballY <= 0)
            {
                dy = -dy; // عكس الاتجاه
            }

            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.FillEllipse(Brushes.Red, ballX, ballY, ballSize, ballSize);

        }


    }
}
