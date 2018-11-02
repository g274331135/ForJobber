using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class Circle : Shape
    {
        public double Radius { get; protected set; }
        private Circle() { }
        public Circle(double radius)
        {
            if (radius <= 0 || double.IsNaN(radius))
                throw new NotFiniteNumberException("Параметр radius должен быть больше 0", radius);

            this.Radius = radius;
        }
        public override double Square()
        {
            double result = Math.PI * this.Radius * this.Radius;
            if (double.IsInfinity(result))
                throw new NotFiniteNumberException(this.Radius);

            return result;
        }
    }
}
