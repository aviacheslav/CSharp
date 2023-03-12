using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Graph_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            float l = g.DpiX;
            float h = g.DpiY;
            RectangleF a = g.VisibleClipBounds;
            float x1, x2, y1, y2;
            y1 = a.Bottom;
            x1 = a.Left;
            x2 = a.Right;
            y2 = a.Top;
            MessageBox.Show("Resolution x=" + l.ToString() + " h=" + h.ToString()+"\n"+" top="+a.Top.ToString()+" bottom="+a.Bottom.ToString()+" left="+a.Left.ToString()+" right="+a.Right.ToString()+"\n"+" width="+a.Width.ToString()+" height="+a.Height.ToString());
            g.Clear(System.Drawing.Color.White);
            //g.DrawLine(new Pen(Brushes.Red, 4), new Point((int)x1, (int)y1), new Point((int)x2, (int)y2));//works gut
            Pen myPen = new Pen(Color.ForestGreen, 4.0F);
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            //g.DrawLine(myPen, new Point((int)x1, (int)y1), new Point((int)x2, (int)y2));//works gut
            //g.DrawLine(myPen,(int)x1, (int)y1, (int)x2, (int)y2); //works gut
            g.DrawLine(myPen, x1, y1, x2, y2);
        }
    }
}
