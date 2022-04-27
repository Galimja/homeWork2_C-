using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// Структура описывает комплексное число
    /// </summary>
    public struct Complex
    {
        /// <summary>
        /// Действительная часть комплексного числа
        /// </summary>
        public double re;

        /// <summary>
        /// Мнимая часть комплексного числа
        /// </summary>
        public double im;

        /// <summary>
        /// Сложение комплексных чисел
        /// </summary>
        /// <param name="x">Комплексное число</param>
        /// <returns>Результат сложения комплексных чисел</returns>
        public Complex Plus(Complex x)
        {
            Complex complexRes;
            complexRes.re = re + x.re;
            complexRes.im = im + x.im;
            return complexRes;
        }
        public Complex Minus(Complex x)
        {
            Complex complexRes;
            complexRes.re = re - x.re;
            complexRes.im = im - x.im;
            return complexRes;
        }

        public static Complex Plus(Complex a, Complex b)
        {
            Complex complexRes;
            complexRes.re = a.re + b.re;
            complexRes.im = a.im + b.im;
            return complexRes;
        }
        public static Complex Minus(Complex a, Complex b)
        {
            Complex complexRes;
            complexRes.re = a.re - b.re;
            complexRes.im = a.im - b.im;
            return complexRes;
        }
        
        public override string ToString()
        {
            return $"{re} + {im}i";
        }


    }
    public class ComplexClass
    {
        /// <summary>
        /// Действительная часть комплексного числа
        /// </summary>
        private double re;

        /// <summary>
        /// Мнимая часть комплексного числа
        /// </summary>
        private double im;

        public double Re
        {
            get
            {
                return re;
            }
            set
            { 
                re = value;
            }
        }

        public double Im
        {
            get
            {
                return im;
            }
            set
            {
                im = value;
            }
        }

        public ComplexClass(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        #region сложение, вычетание, умножение, деление
        /// <summary>
        /// Сложение комплексных чисел
        /// </summary>
        /// <param name="x">Комплексное число</param>
        /// <returns>Результат сложения комплексных чисел</returns>
        public ComplexClass Plus(ComplexClass x)
        {
            return new ComplexClass(re + x.re, im + x.im);
        }
        public ComplexClass Minus(ComplexClass x)
        {
            return new ComplexClass(re - x.re, im - x.im);
        }
        public ComplexClass Mult(ComplexClass x)
        {
            return new ComplexClass(re * x.re - im * x.im, im * x.re + re * x.im);
        }
        public ComplexClass Devide(ComplexClass x)
        {
            double norm = 1 / (x.re * x.re + x.im * x.im);
            return new ComplexClass(norm * (re * x.re + im * x.im), norm * (x.re * im - re * x.im));
        }
        #endregion

        #region сложение, вычетание, умножение, деление. Статические методы
        public static ComplexClass Plus(ComplexClass a, ComplexClass b)
        {
            return new ComplexClass(a.re + b.re, a.im + b.im);
        }
        public static ComplexClass Minus(ComplexClass a, ComplexClass b)
        {
            return new ComplexClass(a.re - b.re, a.im - b.im);
        }
        public static ComplexClass Mult(ComplexClass a, ComplexClass b)
        {
            return new ComplexClass(a.re * b.re - a.im * b.im, a.im * b.re + a.re * b.im);
        }
        public static ComplexClass Devide(ComplexClass a, ComplexClass b)
        {
            double norm = 1 / (b.re * b.re + b.im * b.im);
            return new ComplexClass(norm * (a.re * b.re + a.im * b.im), norm * (a.re * b.im - a.re * b.im));
        }
        #endregion

        #region сложение, вычетание, умножение, деление, перегрузка операторов +, -, *, /
        public static ComplexClass operator +(ComplexClass complex1, ComplexClass complex2)
        {
            return new ComplexClass(complex1.Re + complex2.Re, complex1.Im + complex2.Im);
        }
        public static ComplexClass operator -(ComplexClass complex1, ComplexClass complex2)
        {
            return new ComplexClass(complex1.Re - complex2.Re, complex1.Im - complex2.Im);
        }
        public static ComplexClass operator *(ComplexClass a, ComplexClass b)
        {
            return new ComplexClass(a.re * b.re - a.im * b.im, a.im * b.re + a.re * b.im);
        }
        public static ComplexClass operator /(ComplexClass a, ComplexClass b)
        {
            double norm = 1 / (b.re * b.re + b.im * b.im);
            return new ComplexClass(norm * (a.re * b.re + a.im * b.im), norm * (b.re * a.im - a.re * b.im));
        }
        #endregion

        public override string ToString()
        {
            //return base.ToString();
            return $"{re} + {im}i";
        }
    }

    public class Fraction
    {
        /// <summary>
        /// числитель
        /// </summary>
        int p;
        /// <summary>
        /// знаменатель
        /// </summary>
        int q;
        /// <summary>
        /// упрощение дроби
        /// </summary>
        /// <param name="p">числитель</param>
        /// <param name="q">знаменатель</param>
        void reduction(ref int p, ref int q)
        {
            int max = p > q ? p : q;
            for (int i = 2; i <= max; i++)
            {
                if (p % i == 0 && q % i == 0)
                {
                    p /= i;
                    q /= i;
                    max /= i;
                    i--;                    
                }
            }
        }
        
        public Fraction()
        {
            p = 0;
            q = 1;
        }
        public Fraction(int p, int q)
        {
            if (q == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен 0");
            }
            if (q < 0)
            {
                p *= -1;
                q *= -1;
            }
            reduction(ref p, ref q);
            this.p = p;
            this.q = q;
        }
        public int P
        {
            get
            {
                return p;
            }
            set
            {
                p = value;
                reduction(ref p, ref q);
            }
        }
        public int Q
        {
            get
            {
                return q;
            }
            set
            {
                q = value;
                if (q == 0)
                {
                    throw new ArgumentException("Знаменатель не может быть равен 0");
                }
                if (q < 0)
                {
                    p *= -1;
                    q *= -1;
                }
                reduction(ref p, ref q);
            }
        }
        public double Decim
        {
            get
            {
                return ((double)p / (double)q);
            }
        }

        public Fraction Plus(Fraction x)
        {
            return new Fraction(p * x.Q + x.P * q, q * x.Q);
        }
        public Fraction Minus(Fraction x)
        {
            return new Fraction(p * x.Q - x.P * q, q * x.Q);
        }
        public Fraction Mult(Fraction x)
        {
            return new Fraction(p * x.P, q * x.Q);
        }
        public Fraction Devide(Fraction x)
        {
            return new Fraction(p * x.Q, q * x.P);
        }

        public static Fraction operator +(Fraction x, Fraction y)
        {
            return new Fraction(x.p * y.Q + y.P * x.q, x.q * y.Q);
        }
        public static Fraction operator -(Fraction x, Fraction y)
        {
            return new Fraction(x.p * y.Q - y.P * x.q, x.q * y.Q);
        }
        public static Fraction operator *(Fraction x, Fraction y)
        {
            return new Fraction(x.p * y.P, x.q * y.Q);
        }
        public static Fraction operator /(Fraction x, Fraction y)
        {
            return new Fraction(x.p * y.Q, x.q * y.P);
        }
        public override string ToString()
        {
            return $"{p}/{q}";
        }
    }
    
}
