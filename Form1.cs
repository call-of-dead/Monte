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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.label4.Visible = false;
            this.label5.Visible = false;
            this.label6.Visible = false;
            this.textBox2.Visible = false;
            this.textBox2.Text = "";
            this.textBox3.Visible = false;
            this.textBox3.Text = "";
            this.textBox4.Visible = false;
            this.textBox4.Text = "";
            this.textBox5.Visible = false;
            this.textBox5.Text = "";
            this.label7.Visible = false;
            string text = this.comboBox1.Text;
            if (text == "Прямоугольник")
            {
                this.label4.Visible = true;
                this.label4.Text = "Xn";
                this.label5.Visible = true;
                this.label5.Text = "Yn";
                this.label6.Visible = true;
                this.label6.Text = "Xb";
                this.label7.Visible = true;
                this.label7.Text = "Yb";
                this.textBox2.Visible = true;
                this.textBox3.Visible = true;
                this.textBox4.Visible = true;
                this.textBox5.Visible = true;
            }
            else
            {
                this.textBox2.Visible = true;
                this.textBox3.Visible = true;
                this.textBox4.Visible = true;
                this.label4.Visible = true;
                this.label4.Text = "X";
                this.label5.Visible = true;
                this.label5.Text = "Y";
                this.label6.Visible = true;
                this.label6.Text = "R";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.label8.Visible = false;
            this.label9.Visible = false;
            this.label10.Visible = false;
            this.textBox6.Visible = false;
            this.textBox6.Text = "";
            this.textBox7.Visible = false;
            this.textBox7.Text = "";
            this.textBox8.Visible = false;
            this.textBox8.Text = "";
            this.textBox9.Visible = false;
            this.textBox9.Text = "";
            this.label11.Visible = false;
            string text = this.comboBox2.Text;
            if (text == "Прямоугольник")
            {
                this.label8.Visible = true;
                this.label8.Text = "Xn";
                this.label9.Visible = true;
                this.label9.Text = "Yn";
                this.label10.Visible = true;
                this.label10.Text = "Xb";
                this.label11.Visible = true;
                this.label11.Text = "Yb";
                this.textBox6.Visible = true;
                this.textBox7.Visible = true;
                this.textBox8.Visible = true;
                this.textBox9.Visible = true;
            }
            else
            {
                this.textBox6.Visible = true;
                this.textBox7.Visible = true;
                this.textBox8.Visible = true;
                this.label8.Visible = true;
                this.label8.Text = "X";
                this.label9.Visible = true;
                this.label9.Text = "Y";
                this.label10.Visible = true;
                this.label10.Text = "R";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Инициализирую кол-во испытаний
            string tmp = this.textBox1.Text;
            int N = Convert.ToInt32(tmp);
            if (N < 0) throw new System.Exception();
            Program.N = N;
            //Инициализирую рабочую область
            double x1, x2, y1, y2;
            tmp = this.textBox10.Text;
            x1 = Convert.ToDouble(tmp);
            tmp = this.textBox11.Text;
            y1 = Convert.ToDouble(tmp);
            tmp = this.textBox12.Text;
            x2 = Convert.ToDouble(tmp);
            tmp = this.textBox13.Text;
            y2 = Convert.ToDouble(tmp);
            Program.Obl = new Rectangle(x1, y1, x2, y2);
            //Инициализирую первую область
            Program.A = new oblast();
            if (this.comboBox1.Text == "Прямоугольник")
            {
                tmp = this.textBox2.Text;
                x1 = Convert.ToDouble(tmp);
                tmp = this.textBox3.Text;
                y1 = Convert.ToDouble(tmp);
                tmp = this.textBox4.Text;
                x2 = Convert.ToDouble(tmp);
                tmp = this.textBox5.Text;
                y2 = Convert.ToDouble(tmp);
                Program.A = new Rectangle(x1, y1, x2, y2);
            }
            else
            {
                tmp = this.textBox2.Text;
                x1 = Convert.ToDouble(tmp);
                tmp = this.textBox3.Text;
                y1 = Convert.ToDouble(tmp);
                tmp = this.textBox4.Text;
                x2 = Convert.ToDouble(tmp);
                Program.A = new Circle(x1,y1,x2);
            }
            //Инициализация области 2
            Program.B = new oblast();
            if (this.comboBox2.Text == "Прямоугольник")
            {
                tmp = this.textBox6.Text;
                x1 = Convert.ToDouble(tmp);
                tmp = this.textBox7.Text;
                y1 = Convert.ToDouble(tmp);
                tmp = this.textBox8.Text;
                x2 = Convert.ToDouble(tmp);
                tmp = this.textBox9.Text;
                y2 = Convert.ToDouble(tmp);
                Program.B = new Rectangle(x1, y1, x2, y2);
            }
            else
            {
                tmp = this.textBox6.Text;
                x1 = Convert.ToDouble(tmp);
                tmp = this.textBox7.Text;
                y1 = Convert.ToDouble(tmp);
                tmp = this.textBox8.Text;
                x2 = Convert.ToDouble(tmp);
                Program.B = new Circle(x1,y1,x2);
            }

            Program.Obl.b.Color = System.Drawing.Color.Blue;
            Program.A.b.Color = System.Drawing.Color.Green;
            Program.B.b.Color = System.Drawing.Color.Red;
            //Передаю все свои данные графическому интерфейсу
            Graph p = new Graph();
            p.Visible = true;
        }
    }
}
