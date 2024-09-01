#region Old Work
//using System.Drawing.Drawing2D;
//using System.Drawing.Imaging;

//namespace Paint
//{
//    public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();
//        }

//        private void Form1_Load(object sender, EventArgs e)
//        {
//            this.MinimumSize = this.Size / 2;
//            this.Resize += (sender, e) => Invalidate();
//        }

//        //protected override void OnPaint(PaintEventArgs e)
//        //{
//        //    //string str = "Hello Draw GDI+";
//        //    //Font myFont = new Font(this.Font.FontFamily, 25);
//        //    //Brush myBrush = new SolidBrush(
//        //    //    Color.FromArgb(this.Width % 255, this.Height % 255,
//        //    //        (this.Height / 2 + this.Width / 2) % 255));
//        //    //var strSize = e.Graphics.MeasureString(str, myFont);
//        //    //Point point = new Point((this.ClientSize.Width - (int)strSize.Width) / 2
//        //    //    , (this.ClientSize.Height - (int)strSize.Height) / 2);
//        //    //e.Graphics.DrawString(str, myFont, myBrush, point);
//        //    //------------------------------------------------------


//        //    base.OnPaint(e);
//        //}

//        private void btnColor_Click(object sender, EventArgs e)
//        {
//            if (dlgColor.ShowDialog() == DialogResult.OK)
//                this.ForeColor = dlgColor.Color;
//            this.btnColor.ForeColor = Color.Black;
//        }

//        protected override void OnMouseMove(MouseEventArgs e)
//        {
//            Graphics grfx = this.CreateGraphics();

//            if (e.Button == MouseButtons.Left)
//            {
//                grfx.FillEllipse(new SolidBrush(this.ForeColor), e.X - 3f, e.Y - 3f
//                    , 6f, 6f);
//            }
//            else if (e.Button == MouseButtons.Right)
//            {
//                grfx.FillEllipse(new SolidBrush(this.BackColor), e.X - 15, e.Y - 15, 30, 30);
//            }

//            base.OnMouseMove(e);
//        }
//    }
//} 
#endregion

#region New Work
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Paint
{
    public partial class Form1 : Form
    {
        bool isDrawing = false;
        SolidBrush myBrush = new SolidBrush(Color.Black);
        Point clickPosition;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size / 2;
            //this.Resize += (sender, e) => Invalidate();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
                myBrush = new SolidBrush(dlgColor.Color);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                clickPosition = new Point(e.X, e.Y);
                this.Cursor = Cursors.Cross;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (isDrawing)
            {
                Graphics grfx = this.CreateGraphics();

                Point currentPosition = new Point(e.X, e.Y);
                grfx.DrawLine(new Pen(myBrush, 3), clickPosition, currentPosition);
                clickPosition = currentPosition; // updating along with the movement of the cursor
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            isDrawing = false;
            this.Cursor = Cursors.Default;
        }
    }
}
#endregion

#region Smoother Way
//using System.Drawing.Drawing2D;
//using System.Drawing.Imaging;

//namespace Paint
//{
//    public partial class Form1 : Form
//    {
//        bool isDrawing = false;
//        SolidBrush myBrush = new SolidBrush(Color.Black);
//        Point previousPoint;
//        Bitmap drawingBitmap;
//        Graphics drawingGraphics;

//        public Form1()
//        {
//            InitializeComponent();
//            this.DoubleBuffered = true;
//            drawingBitmap = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
//            drawingGraphics = Graphics.FromImage(drawingBitmap);
//            drawingGraphics.SmoothingMode = SmoothingMode.AntiAlias;
//        }

//        private void Form1_Load(object sender, EventArgs e)
//        {
//            this.MinimumSize = this.Size / 2;
//            this.Resize += (s, ev) =>
//            {
//                Bitmap newBitmap = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
//                Graphics newGraphics = Graphics.FromImage(newBitmap);
//                newGraphics.DrawImage(drawingBitmap, 0, 0);
//                drawingBitmap = newBitmap;
//                drawingGraphics = newGraphics;
//                drawingGraphics.SmoothingMode = SmoothingMode.AntiAlias;
//            };
//        }

//        private void btnColor_Click(object sender, EventArgs e)
//        {
//            if (dlgColor.ShowDialog() == DialogResult.OK)
//                myBrush = new SolidBrush(dlgColor.Color);
//        }

//        protected override void OnMouseDown(MouseEventArgs e)
//        {
//            if (e.Button == MouseButtons.Left)
//            {
//                isDrawing = true;
//                previousPoint = new Point(e.X, e.Y);
//                this.Cursor = Cursors.Cross;
//            }
//        }

//        protected override void OnMouseMove(MouseEventArgs e)
//        {
//            base.OnMouseMove(e);

//            if (isDrawing)
//            {
//                Point currentPoint = new Point(e.X, e.Y);
//                drawingGraphics.DrawLine(new Pen(myBrush, 7), previousPoint, currentPoint);
//                previousPoint = currentPoint;
//                this.Invalidate(); // Request a redraw of the form
//            }
//        }

//        protected override void OnMouseUp(MouseEventArgs e)
//        {
//            isDrawing = false;
//            this.Cursor = Cursors.Default;
//        }

//        protected override void OnPaint(PaintEventArgs e)
//        {
//            base.OnPaint(e);
//            e.Graphics.DrawImage(drawingBitmap, Point.Empty);
//        }
//    }
//}

#endregion