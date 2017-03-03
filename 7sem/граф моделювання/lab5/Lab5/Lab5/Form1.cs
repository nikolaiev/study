using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        Font drawFont = new Font("Arial", 10);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        Graphics g;
        public PointF[] mas3 = new PointF[101];

        //default points
        Point p1 = new Point(300, 150);
        Point p2 = new Point(100, 0);
        Point p3 = new Point(120, 160);
        Point p4 = new Point(150, 200);

        Point p2_1 = new Point(220, 135);
        Point p2_2 = new Point(200, 0);
        Point p2_3 = new Point(490, 50);
        Point p2_4 = new Point(275, 145);

        public Form1()
        {           
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Black, 2);
            g.Clear(Color.White);
            g.DrawLine(pen, p1, p2);
            g.DrawLine(pen, p2, p3);
            g.DrawLine(pen, p3, p4);
            Pen pen1 = new Pen(Color.DeepSkyBlue);
            Pen pen2 = new Pen(Color.LightBlue);
            pen = new Pen(Color.Purple, 4);
            double d;
            for (int i = 0; i <= 100; i++)
            {
                d = i * 0.01;
                PointF pt1 = createPoint((float)d, p1, p2);
                PointF pt2 = createPoint((float)d, p2, p3);
                PointF pt4 = createPoint((float)d, p3, p4);
                g.DrawLine(pen1, pt1, pt2);
                g.DrawLine(pen1, pt2, pt4);
                PointF ptt1 = createPoint((float)d, pt1, pt2);
                PointF ptt2 = createPoint((float)d, pt2, pt4);
                g.DrawLine(pen2, ptt1, ptt2);
                PointF pk = createPoint((float)d, ptt1, ptt2);
                g.DrawEllipse(pen, pk.X, pk.Y, 2, 2);
                Thread.Sleep(50);
            }


            g.Clear(Color.White);
            pen = new Pen(Color.SkyBlue, 3);
            g.DrawEllipse(pen, p1.X, p1.Y, 2, 2);
            g.DrawEllipse(pen, p2.X, p2.Y, 2, 2);
            g.DrawEllipse(pen, p3.X, p3.Y, 2, 2);
            g.DrawEllipse(pen, p4.X, p4.Y, 2, 2);
            g.DrawString("1", drawFont, drawBrush, p1);
            g.DrawString("2", drawFont, drawBrush, p2);
            g.DrawString("3", drawFont, drawBrush, p3);
            g.DrawString("4", drawFont, drawBrush, p4);
            pen = new Pen(Color.Black);
            g.DrawLine(pen, p1, p2);
            g.DrawLine(pen, p2, p3);
            g.DrawLine(pen, p3, p4);
            pen = new Pen(Color.Goldenrod);
            g.DrawBezier(pen, p1, p2, p3, p4);
        }

        private PointF createPointB(float t, PointF p1, PointF p2, PointF p3, PointF p4)
        {
            PointF point = new PointF();
            point.X = (float)(Math.Pow((1 - t), 3) * p1.X + 3 * Math.Pow((1 - t), 2) * t * p2.X + 3 * (1 - t) * t * t * p3.X + t * t * t * p4.X);
            point.Y = (float)(Math.Pow((1 - t), 3) * p1.Y + 3 * Math.Pow((1 - t), 2) * t * p2.Y + 3 * (1 - t) * t * t * p3.Y + t * t * t * p4.Y);
            return point;
        }       

        private PointF createPoint(float t, PointF p1, PointF p2)
        {
            PointF pt = new PointF();
            pt.X = p1.X * (1 - t) + p2.X * t;
            pt.Y = p1.Y * (1 - t) + p2.Y * t;
            return pt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                p1 = new Point(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Probably not all fields was filled. Or some value is incorrect!");
            }
            try
            {
                p2 = new Point(Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text));
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Probably not all fields was filled. Or some value is incorrect!");
            }
            try
            {
                p3 = new Point(Int32.Parse(textBox5.Text), Int32.Parse(textBox6.Text));
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Probably not all fields was filled. Or some value is incorrect!");
            }
            try
            {
                p4 = new Point(Int32.Parse(textBox7.Text), Int32.Parse(textBox8.Text));
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Probably not all fields was filled. Or some value is incorrect!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            Pen pen = new Pen(Color.SkyBlue, 3);
            g.DrawEllipse(pen, p1.X, p1.Y, 2, 2);
            g.DrawEllipse(pen, p2.X, p2.Y, 2, 2);
            g.DrawEllipse(pen, p3.X, p3.Y, 2, 2);
            g.DrawEllipse(pen, p4.X, p4.Y, 2, 2);

            g.DrawString("1", drawFont, drawBrush, p1);
            g.DrawString("2", drawFont, drawBrush, p2);
            g.DrawString("3", drawFont, drawBrush, p3);
            g.DrawString("4", drawFont, drawBrush, p4);
            pen = new Pen(Color.Black);
            g.DrawLine(pen, p1, p2);
            g.DrawLine(pen, p2, p3);
            g.DrawLine(pen, p3, p4);
            pen = new Pen(Color.Goldenrod);
            g.DrawBezier(pen, p1, p2, p3, p4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            Pen pen = new Pen(Color.BlueViolet);
            //Pen pen1 = new Pen(Color.Black);
            g.DrawLine(pen, p1, p2);
            g.DrawLine(pen, p2, p3);
            g.DrawLine(pen, p3, p4);
            g.DrawBezier(pen, p1, p2, p3, p4);

            //g.DrawEllipse(Pens.Red, 185, 185, 150, 150);
            //g.FillEllipse(Brushes.BlueViolet, 177, 123, 120, 120);

            g.DrawLine(pen, p2_1, p2_2);
            g.DrawLine(pen, p2_2, p2_3);
            g.DrawLine(pen, p2_3, p2_4);
            g.DrawBezier(pen, p2_1, p2_2, p2_3, p2_4);
            findIntersec();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                p2_1 = new Point(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Probably not all fields was filled. Or some value is incorrect!");
            }
            try
            {
                p2_2 = new Point(Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text));
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Probably not all fields was filled. Or some value is incorrect!");
            }
            try
            {
                p2_3 = new Point(Int32.Parse(textBox5.Text), Int32.Parse(textBox6.Text));
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Probably not all fields was filled. Or some value is incorrect!");
            }
            try
            {
                p2_4 = new Point(Int32.Parse(textBox7.Text), Int32.Parse(textBox8.Text));
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Probably not all fields was filled. Or some value is incorrect!");
            }
        }

        private void findIntersec()
        {
            int prevX = p1.X;
            int prevY = p1.Y;
            double d;
            for (int i = 0; i <= 100; i++)
            {
                d = i * 0.01;
                PointF pt1 = createPoint((float)d, p1, p2);
                PointF pt2 = createPoint((float)d, p2, p3);
                PointF pt4 = createPoint((float)d, p3, p4);

                PointF ptt1 = createPoint((float)d, pt1, pt2);
                PointF ptt2 = createPoint((float)d, pt2, pt4);
                PointF pk = createPoint((float)d, ptt1, ptt2);
                //g.DrawEllipse(pen, pk.X, pk.Y, 2, 2);
                
                int _prevX = p2_1.X;
                int _prevY = p2_1.Y;

                for (int j = 0; j <= 100; j++)
                {
                    d = i * 0.01;
                    PointF _pt1 = createPoint((float)d, p2_1, p2_2);
                    PointF _pt2 = createPoint((float)d, p2_2, p2_3);
                    PointF _pt4 = createPoint((float)d, p2_3, p2_4);

                    PointF _ptt1 = createPoint((float)d, _pt1, _pt2);
                    PointF _ptt2 = createPoint((float)d, _pt2, _pt4);

                    PointF _pk = createPoint((float)d, _ptt1, _ptt2);

                    if ((int)pk.X== (int)_pk.X&& (int)pk.Y == (int)_pk.Y)
                    {
                        MessageBox.Show("Intersection point is " + pk.X + " " + pk.Y);
                    }
                    
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
           /* Bitmap b = new Bitmap(pictureBox1.Image);
            Color color = b.GetPixel(e.X, e.Y);*/
            MessageBox.Show("Point is "+e.X+" " +e.Y+"");
        }
    }
}
