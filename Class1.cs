using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte
{
    /// <summary>
    /// Точка в плоскости
    /// </summary>
    class Point{
        public double x;
        public double y;
        /// <summary>
        /// Конструктор класса точки
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        public Point(double _x,double _y){
            x=_x;
            y=_y;
        }
        public override string ToString()
        {
            return x.ToString() + " " + y.ToString();
        }
    }
    /// <summary>
    /// Область плоскости
    /// </summary>
    class oblast
    {
        public System.Drawing.SolidBrush b;
        private System.Random r;
        /// <summary>
        /// Принадлежит ли заданная точка области
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        virtual public bool IN(double x, double y)
        {
            return false;
        }
        /// <summary>
        /// Возвращает площадь данной фигуры
        /// </summary>
        /// <returns></returns>
        virtual public double S()
        {
            return 0;
        }
        /// <summary>
        /// Максимальная точка данной области
        /// </summary>
        /// <returns></returns>
        public virtual Point Max()
        {
            return new Point(0,0);
        }
        /// <summary>
        /// Рисует данную фигуру
        /// </summary>
        /// <param name="g">Где рисовать</param>
        /// <param name="px">Погрешность на оси х</param>
        /// <param name="py">Погрешность на оси у</param>
        public virtual void Draw(System.Drawing.Graphics g, double px, double py, int tmp) { }
        /// <summary>
        /// Рисует данную фигуру, без заливки
        /// </summary>
        /// <param name="g">Где рисовать</param>
        /// <param name="px">Погрешность оси х</param>
        /// <param name="py">Погрешность оси у</param>
        public virtual void NoFill(System.Drawing.Graphics g, double px, double py, int tmp) { }
        /// <summary>
        /// Минимальная точка данной области
        /// </summary>
        /// <returns></returns>
        public virtual Point Min()
        {
            return new Point(0, 0);
        }
        /// <summary>
        /// Принадлежит ли данная точка данной области?
        /// </summary>
        /// <param name="x">Точка на плоскости</param>
        /// <returns></returns>
        virtual public bool IN(Point x)
        {
            return IN(x.x, x.y);
        }
        /// <summary>
        /// Возвращает рандомную точку внутри данной области
        /// </summary>
        /// <returns></returns>
        virtual public Point Random()
        {
            return new Point(0, 0);
        }
        public oblast()
        {
            r = new Random();
            this.b = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        }
        /// <summary>
        /// Генерация рандомного числа
        /// </summary>
        /// <param name="Max">Максимальное число</param>
        /// <returns></returns>
        public double Rand(int Max)
        {
            double f = r.Next(Max);
            f += r.Next(9999999) / 10000000.0;
            return f;
        }
    }
    class Circle:oblast
    {
        private double _x;
        private double _y;
        private double _r;
        public Circle(double x, double y, double r)
        {
            _x = x;
            _y = y;
            _r = r;
        }
        public override void Draw(System.Drawing.Graphics g, double px, double py, int tmp)
        {
           // g.FillEllipse(b, 102, 102,204,204);
            g.FillEllipse(b, Convert.ToInt32(System.Math.Round((_x - _r)*px)), Convert.ToInt32(System.Math.Round((_y - _r)*py)), Convert.ToInt32(System.Math.Round(2*_r*px)), Convert.ToInt32(System.Math.Round(2*_r*py)));
            //throw new System.Exception();
        }
        public override void NoFill(System.Drawing.Graphics g, double px, double py, int tmp)
        {
            g.DrawEllipse(new System.Drawing.Pen(new System.Drawing.SolidBrush(System.Drawing.Color.Black)),  Convert.ToInt32(System.Math.Round((_x - _r) * px)), Convert.ToInt32(System.Math.Round((_y - _r) * py)), Convert.ToInt32(System.Math.Round(2 * _r * px)), Convert.ToInt32(System.Math.Round(2 * _r * py)));
        }
        public override double S()
        {
            return System.Math.PI*_r*_r;
        }
        public override Point Max()
        {
            return new Point(_x+_r,_y+_r);
        }
        public override Point Min()
        {
            return new Point(_x-_r,_y-_r);
        }
        public override bool IN(double x, double y)
        {
            return System.Math.Sqrt((x-_x)*(x-_x)+(y-_y)*(y-_y))<=_r;
        }
        override public bool IN(Point x)
        {
            return IN(x.x, x.y);
        }
    }
    class Rectangle : oblast
    {
        private double _x1;
        private double _y1;
        private double _x2;
        private double _y2;
        public Rectangle(double x1, double y1, double x2, double y2)
        {
            if (x1 > x2)
            {
                throw new System.Exception();
            }
            if (y1 > y2)
            {
                throw new System.Exception();
            }
            _x1 = x1;
            _x2 = x2;
            _y1 = y1;
            _y2 = y2;
        }
        public override void Draw(System.Drawing.Graphics g, double px, double py, int tmp)
        {
            g.FillRectangle(b, Convert.ToInt32(System.Math.Round(_x1*px)), Convert.ToInt32(System.Math.Round(_y1*py)),Convert.ToInt32(System.Math.Round( (_x2 - _x1)*px)), Convert.ToInt32(System.Math.Round((_y2 - _y1)*py)));
        }
        public override void NoFill(System.Drawing.Graphics g, double px, double py,int tmp)
        {
            g.DrawRectangle(new System.Drawing.Pen(new System.Drawing.SolidBrush(System.Drawing.Color.Black)), Convert.ToInt32(System.Math.Round(_x1 * px)), Convert.ToInt32(System.Math.Round(_y1 * py)), Convert.ToInt32(System.Math.Round((_x2 - _x1) * px)), Convert.ToInt32(System.Math.Round((_y2 - _y1) * py)));
        }
        public override Point Max()
        {
            return new Point(_x2,_y2);
        }
        public override double S()
        {
            return (_x2-_x1)*(_y2-_y1);
        }
        public override Point Min()
        {
            return new Point(_x1,_y1);
        }
        override public bool IN(double x, double y)
        {
            bool tm = (x >= _x1) && (x <= _x2) && (y <= _y2) && (y >= _y1);
            return tm;
        }
        public override Point Random()
        {
            double x, y;
            x = base.Rand(Convert.ToInt32(System.Math.Round(_x2 - _x1))) + _x1;
            y = base.Rand(Convert.ToInt32(System.Math.Round(_y2 - _y1))) + _y1;
            return new Point(x, y);
        }
        override public bool IN(Point x)
        {
            return this.IN(x.x, x.y);
        }
    }
}
