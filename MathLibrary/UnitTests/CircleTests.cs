using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
using MathLibrary;

namespace UnitTests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        [ExpectedException(typeof(NotFiniteNumberException))]
        public void CircleZeroRadiusException()
        {
            /* Вызов тестируемого объекта */
            Circle circle = new Circle(0);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFiniteNumberException))]
        public void CircleNegativeRadiusException()
        {
            /* Вызов тестируемого объекта */
            Circle circle = new Circle(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFiniteNumberException))]
        public void CircleNaNRadiusException()
        {
            /* Вызов тестируемого объекта */
            Circle circle = new Circle(double.NaN);
        }

        [TestMethod]
        public void CirclePositiveRadius()
        {
            var values = new[] { 0.0000001, 0.1, 0.2, 1, 2, 1024 };

            values.ToList().ForEach(val =>
            {
                /* Создание тестовой конфигурации */
                double expectedResult = Math.PI * val * val;
                Circle circle = new Circle(val);

                /* Вызов тестируемого метода */
                double actualResult = circle.Square();

                /* Проверка результата */
                Assert.AreEqual(expectedResult, actualResult, "Неверный результат вычисления с параметром radius={0}", val);
            });
        }

        [TestMethod]
        [ExpectedException(typeof(NotFiniteNumberException))]
        public void CircleNotFiniteResult()
        {
            /* Создание тестовой конфигурации */
            Circle circle = new Circle(double.MaxValue);

            /* Вызов тестируемого метода */
            double result = circle.Square();
        }
    }
}
