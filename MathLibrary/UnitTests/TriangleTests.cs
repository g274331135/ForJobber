using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
using MathLibrary;

namespace UnitTests
{
    [TestClass]
    public class TriagleTests
    {
        [TestMethod]
        [ExpectedException(typeof(NotFiniteNumberException))]
        public void TriangleZeroLine1Exception()
        {
            /* Вызов тестируемого объекта */
            Triangle triangle = new Triangle(0, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFiniteNumberException))]
        public void TriangleNegativeLine1Exception()
        {
            /* Вызов тестируемого объекта */
            Triangle triangle = new Triangle(-1, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFiniteNumberException))]
        public void TriangleNaNLine1Exception()
        {
            /* Создание и вызов объекта */
            Triangle triangle = new Triangle(double.NaN, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFiniteNumberException))]
        public void TriangleZeroLine2Exception()
        {
            /* Вызов тестируемого объекта */
            Triangle triangle = new Triangle(1, 0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFiniteNumberException))]
        public void TriangleNegativeLine2Exception()
        {
            /* Вызов тестируемого объекта */
            Triangle triangle = new Triangle(1, -1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFiniteNumberException))]
        public void TriangleNaNLine2Exception()
        {
            /* Создание и вызов объекта */
            Triangle triangle = new Triangle(1, double.NaN, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFiniteNumberException))]
        public void TriangleZeroLine3Exception()
        {
            /* Вызов тестируемого объекта */
            Triangle triangle = new Triangle(1, 1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFiniteNumberException))]
        public void TriangleNegativeLine3Exception()
        {
            /* Вызов тестируемого объекта */
            Triangle triangle = new Triangle(1, 1, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFiniteNumberException))]
        public void TriangleNaNLine3Exception()
        {
            /* Создание и вызов объекта */
            Triangle triangle = new Triangle(1, 1, double.NaN);
        }

        [TestMethod]
        public void TrianglePositiveParams()
        {
            var values = new[] { new[] { 0.000003, 0.00002, 0.0001 }
                               , new[] { 0.1, 0.2, 0.3 }
                               , new[] { 0.3, 0.2, 0.1 }
                               , new[] { 1.0, 2.0, 3.0 }
                               , new[] { 101.1, 200.0, 777.77 } };

            values.ToList().ForEach(prms =>
            {
                /* Создание тестовой конфигурации */
                double lineA = prms[0];
                double lineB = prms[1];
                double lineC = prms[2];

                double perimeter = lineA + lineB + lineC;
                double expectedResult = Math.Sqrt(perimeter * (perimeter - lineA) * (perimeter - lineB) * (perimeter - lineC));
                Triangle triangle = new Triangle(lineA: lineA, lineB: lineB, lineC: lineC);

                /* Вызов тестируемого метода */
                double actualResult = triangle.Square();

                /* Проверка результата */
                Assert.AreEqual(expectedResult, actualResult, "Неверный результат вычисления с параметрами: lineA={0}; lineB={1}; lineC={2}", lineA, lineB, lineC);
            });
        }

        [TestMethod]
        public void TriagleIsRectangular()
        {
            var values = new[] { new[] { 0.3, 0.4, 0.5 }
                               , new[] { 0.5, 0.3, 0.4 }
                               , new[] { 4.0, 3.0, 5.0 } };

            values.ToList().ForEach(prms =>
            {
                /* Создание тестовой конфигурации */
                double lineA = prms[0];
                double lineB = prms[1];
                double lineC = prms[2];

                Triangle triangle = new Triangle(lineA: lineA, lineB: lineB, lineC: lineC);

                /* Проверка результата */
                Assert.IsTrue(triangle.IsRectangular, "Тругольник не прямоугольный с параметрами: lineA={0}; lineB={1}; lineC={2}", lineA, lineB, lineC);
            });
        }

        [TestMethod]
        public void TriagleIsIsosceles()
        {
            var values = new[] { new[] { 0.3, 0.3, 0.5 }
                               , new[] { 0.05, 0.03, 0.05 }
                               , new[] { 4.0, 5.0, 5.0 } };

            values.ToList().ForEach(prms =>
            {
                /* Создание тестовой конфигурации */
                double lineA = prms[0];
                double lineB = prms[1];
                double lineC = prms[2];

                Triangle triangle = new Triangle(lineA: lineA, lineB: lineB, lineC: lineC);

                /* Проверка результата */
                Assert.IsTrue(triangle.IsIsosceles, "Тругольник не равносторонний с параметрами: lineA={0}; lineB={1}; lineC={2}", lineA, lineB, lineC);
            });
        }

        [TestMethod]
        public void TriagleIsEquilateral()
        {
            var values = new[] { new[] { 0.3, 0.3, 0.3 }
                               , new[] { 0.05, 0.05, 0.05 }
                               , new[] { 4.0, 4.0, 4.0 } };

            values.ToList().ForEach(prms =>
            {
                /* Создание тестовой конфигурации */
                double lineA = prms[0];
                double lineB = prms[1];
                double lineC = prms[2];

                Triangle triangle = new Triangle(lineA: lineA, lineB: lineB, lineC: lineC);

                /* Проверка результата */
                Assert.IsTrue(triangle.IsEquilateral, "Тругольник не равносторонний с параметрами: lineA={0}; lineB={1}; lineC={2}", lineA, lineB, lineC);
            });
        }
    }
}
