using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class Triangle : Shape
    {
        public double LineA { get; protected set; }
        public double LineB { get; protected set; }
        public double LineC { get; protected set; }

        public bool IsRectangular { get; private set; }
        public bool IsIsosceles { get; protected set; }
        public bool IsEquilateral { get; protected set; }

        private Triangle() { }

        public Triangle(double lineA, double lineB, double lineC)
        {
            if (lineA <= 0 || double.IsNaN(lineA))
                throw new NotFiniteNumberException("Параметр lineA должен быть больше 0", lineA);
            this.LineA = lineA;

            if (lineB <= 0 || double.IsNaN(lineB))
                throw new NotFiniteNumberException("Параметр lineB должен быть больше 0", lineB);
            this.LineB = lineB;

            if (lineC <= 0 || double.IsNaN(lineC))
                throw new NotFiniteNumberException("Параметр lineC должен быть больше 0", lineC);
            this.LineC = lineC;

            /* Вычисляем является ли треугольник прямоугольным */
            if ((this.LineA * this.LineA + this.LineB * this.LineB == this.LineC * this.LineC) 
                || (this.LineA * this.LineA + this.LineC * this.LineC == this.LineB * this.LineB) 
                || (this.LineC * this.LineC + this.LineB * this.LineB == this.LineA * this.LineA))
                this.IsRectangular = true;

            /* Является ли треугольник равнобедренным */
            if (this.LineA == this.LineB || this.LineB == this.LineC || this.LineC == this.LineA)
                this.IsIsosceles = true;

            /* Является ли треугольник равносторонним */
            if (this.LineA == this.LineB && this.LineB == this.LineC)
                this.IsEquilateral = true;
        }
        public override double Square()
        {
            /* Вычисляем периметр */
            double perimeter = this.LineA + this.LineB + this.LineC;

            return Math.Sqrt(perimeter * (perimeter - this.LineA) * (perimeter - this.LineB) * (perimeter - this.LineC));
        }
    }
}
