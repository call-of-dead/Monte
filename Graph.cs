using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monte
{
    public partial class Graph : Form
    {
        private Graphics g1;
        private double px1;
        private double py1;
        private Graphics g2;
        private double px2;
        private double py2;
        private Graphics g3;
        private double px3;
        private double py3;
        public Graph()
        {
            InitializeComponent();
        }
        private void Graph_Load(object sender, EventArgs e)
        {


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }
        private void Update(int A, int B, int AB, int AIB)
        {
            this.label3.Text = A.ToString();
            this.label4.Text = B.ToString();
            this.label5.Text = AB.ToString();
            this.label6.Text = AIB.ToString();

            double N = Program.N;
            this.label8.Text = (A / N).ToString();
            this.label9.Text = (B / N).ToString();
            this.label10.Text = (AB / N).ToString();
            this.label11.Text = (AIB / N).ToString();
        }
        //private void 
        private void button2_Click(object sender, EventArgs e)
        {
            //Инициализация графиков
            g1 = this.pictureBox1.CreateGraphics();
            SolidBrush b = new SolidBrush(Color.White);
            g1.FillRectangle(b, 0, 0, 204, 204);
            g2 = this.pictureBox2.CreateGraphics();
            g2.FillRectangle(b, 0, 0, 204, 204);
            g3 = this.pictureBox3.CreateGraphics();
            g3.FillRectangle(b, 0, 0, 408, 408);
            //инициализация множителя
            Point tmp = Program.Obl.Max();
            if ((tmp.x < Program.A.Max().x))
            {
                tmp.x = Program.A.Max().x;
            }
            if (tmp.y < Program.A.Max().y)
            {
                tmp.y = Program.A.Max().y;
            }
            Point tmp1 = Program.Obl.Min();
            if ((tmp1.x > Program.A.Min().x))
            {
                tmp1.x = Program.A.Min().x;
            }
            if (tmp1.y > Program.A.Min().y)
            {
                tmp1.y = Program.A.Min().y;
            }
            double px = tmp.x - tmp1.x;
            px = px / 98 * 100;
            this.px1 =  204/px;
            px = tmp.y - tmp1.y;
            px = px / 98 * 100;
            this.py1 = 204/px;

            tmp = Program.Obl.Max();
            if ((tmp.x < Program.B.Max().x))
            {
                tmp.x = Program.B.Max().x;
            }
            if (tmp.y < Program.B.Max().y)
            {
                tmp.y = Program.B.Max().y;
            }
            tmp1 = Program.Obl.Min();
            if ((tmp1.x > Program.B.Min().x))
            {
                tmp1.x = Program.B.Min().x;
            }
            if (tmp1.y > Program.B.Min().y)
            {
                tmp1.y = Program.B.Min().y;
            }
            px = tmp.x - tmp1.x;
            px = px / 98 * 100;
            this.px2 = 204/px;
            px = tmp.y - tmp1.y;
            px = px / 98 * 100;
            this.py2 = 204/px;

            tmp = Program.Obl.Max();
            if ((tmp.x < Program.A.Max().x))
            {
                tmp.x = Program.A.Max().x;
            }
            if (tmp.x < Program.B.Max().x)
            {
                tmp.x = Program.B.Max().x;
            }
            if (tmp.y < Program.A.Max().y)
            {
                tmp.y = Program.A.Max().y;
            }
            if (tmp.y < Program.B.Max().y)
            {
                tmp.y = Program.B.Max().y;
            }
            tmp1 = Program.Obl.Min();
            if ((tmp1.x > Program.A.Min().x))
            {
                tmp1.x = Program.A.Min().x;
            }
            if (tmp1.x > Program.B.Min().x)
            {
                tmp1.x = Program.B.Min().x;
            }
            if (tmp1.y > Program.A.Min().y)
            {
                tmp1.y = Program.A.Min().y;
            }
            if (tmp1.y > Program.B.Min().y)
            {
                tmp1.y = Program.B.Min().y;
            }
            px = tmp.x - tmp1.x;
            px = px / 98 * 100;
            this.px3 = 408 / px;
            px = tmp.y - tmp1.y;
            px = px / 98 * 100;
            this.py3 = 408 / px;

            //Инициализация первичных данных
            int A,B,AB,AIB;
            A = 0;
            B = 0;
            AB = 0;
            AIB = 0;

            Program.B.Draw(g2, px2, py2,204);
            Program.A.Draw(g1, px1, py1,204);
            Program.Obl.Draw(g3, px3, py3,408);
            Program.Obl.NoFill(g3, px3, py3, 408);
            Program.A.Draw(g3, px3, py3,408);
            Program.B.Draw(g3, px3, py3,408);
            Program.A.NoFill(g3, px3, py3,408);
            Program.B.NoFill(g3, px3, py3,408);

            System.Drawing.SolidBrush b1=new SolidBrush(Color.Black);
            double _r = 0.1;
            Label l1;
            //Подсчет
            for (int i = 0; i < Program.N; i++)
            {
                bool t = false;
                Point x=Program.Obl.Random();
                if (Program.A.IN(x))
                {
                    t = true;
                    AIB++;
                    A++;
                    if (Program.B.IN(x))
                    {
                        AB++;
                        B++;
                        //throw new System.Exception();
                        //continue;

                        goto l1;
                    }
                }
                if (Program.B.IN(x))
                {
                    B++;
                    if (!t)
                    {
                        AIB++;
                    }
                }
                l1: this.Update(A, B, AB, AIB);
                g1.FillEllipse(b1, Convert.ToInt32(System.Math.Round((x.x ) * px1)), Convert.ToInt32(System.Math.Round((x.y ) * py1)), Convert.ToInt32(System.Math.Round(2 * _r * px1)), Convert.ToInt32(System.Math.Round(2 * _r * py1)));
                g2.FillEllipse(b1, Convert.ToInt32(System.Math.Round((x.x ) * px2)), Convert.ToInt32(System.Math.Round((x.y ) * py2)), Convert.ToInt32(System.Math.Round(2 * _r * px2)), Convert.ToInt32(System.Math.Round(2 * _r * py2)));
                g3.FillEllipse(b1, Convert.ToInt32(System.Math.Round((x.x ) * px3)), Convert.ToInt32(System.Math.Round((x.y ) * py3)), Convert.ToInt32(System.Math.Round(2 * _r * px3)), Convert.ToInt32(System.Math.Round(2 * _r * py3)));
            }
            this.label18.Text = (Program.Obl.S() * A / Program.N).ToString();
            this.label19.Text = (Program.Obl.S() * B / Program.N).ToString();
            this.label20.Text = (Program.Obl.S() * AB / Program.N).ToString();
            this.label21.Text = (Program.Obl.S() * AIB / Program.N).ToString();

            this.label27.Text = (Program.A.S()/Program.Obl.S()).ToString();
            this.label28.Text = (Program.B.S() / Program.Obl.S()).ToString();
            this.label29.Text = ((Program.Obl.S() * AB / Program.N) / Program.Obl.S()).ToString();
            this.label30.Text = ((Program.Obl.S() * AIB / Program.N) / Program.Obl.S()).ToString();

            this.label13.Text = ((Convert.ToDouble(this.label8.Text) - Convert.ToDouble(this.label27.Text)) / Convert.ToDouble(this.label8.Text)).ToString();
            this.label14.Text = ((Convert.ToDouble(this.label9.Text) - Convert.ToDouble(this.label28.Text)) / Convert.ToDouble(this.label9.Text)).ToString();
            this.label15.Text = ((Convert.ToDouble(this.label10.Text) - Convert.ToDouble(this.label29.Text)) / Convert.ToDouble(this.label10.Text)).ToString();
            this.label16.Text = ((Convert.ToDouble(this.label11.Text) - Convert.ToDouble(this.label30.Text)) / Convert.ToDouble(this.label11.Text)).ToString();
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
    }
}
