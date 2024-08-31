using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size / 2;
            this.Resize += (sender, e) => Invalidate();
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    //string str = "Hello Draw GDI+";
        //    //Font myFont = new Font(this.Font.FontFamily, 25);
        //    //Brush myBrush = new SolidBrush(
        //    //    Color.FromArgb(this.Width % 255, this.Height % 255,
        //    //        (this.Height / 2 + this.Width / 2) % 255));
        //    //var strSize = e.Graphics.MeasureString(str, myFont);
        //    //Point point = new Point((this.ClientSize.Width - (int)strSize.Width) / 2
        //    //    , (this.ClientSize.Height - (int)strSize.Height) / 2);
        //    //e.Graphics.DrawString(str, myFont, myBrush, point);
        //    //------------------------------------------------------


        //    base.OnPaint(e);
        //}

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
                this.ForeColor = dlgColor.Color;
            this.btnColor.ForeColor = Color.Black;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Graphics grfx = this.CreateGraphics();

            if (e.Button == MouseButtons.Left)
            {
                grfx.FillEllipse(new SolidBrush(this.ForeColor), e.X - 3f, e.Y - 3f
                    , 6f, 6f);
            }
            else if (e.Button == MouseButtons.Right)
            {
                grfx.FillEllipse(new SolidBrush(this.BackColor), e.X - 15, e.Y - 15, 30, 30);
            }

            base.OnMouseMove(e);
        }
    }
}