using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FractalBuilder_2.Fractal
{
    internal class JuliaSet : Fractal
    {
        public JuliaSet(int depth) : base(depth)
        {
        }

        public override void Draw(Canvas canvas)
        {
            canvas.Children.Clear();

            int MaxIterations = 200;
            double EscapeRadius = 2.0;

            int canvasWidth = (int)canvas.ActualWidth;
            int canvasHeight = (int)canvas.ActualHeight;
            double xMin = -2.0;
            double xMax = 2.0;
            double yMin = -2.0;
            double yMax = 2.0;

            // Параметры множества Жюлиа
            double cReal = -0.7;
            double cImaginary = 0.27015;

            for (int xPixel = 0; xPixel < canvasWidth; xPixel++)
            {
                for (int yPixel = 0; yPixel < canvasHeight; yPixel++)
                {
                    // Преобразование координат пикселей в комплексную плоскость
                    double x0 = Map(xPixel, 0, canvasWidth, xMin, xMax);
                    double y0 = Map(yPixel, 0, canvasHeight, yMin, yMax);

                    // Вычисление количества итераций для точки в множестве Жюлиа
                    int iterations = CalculateJuliaIterations(
                        x0, 
                        y0, 
                        EscapeRadius, 
                        MaxIterations, 
                        cReal, cImaginary);

                    // Задание цвета заполнения в зависимости от количества итераций
                    Color fillColor = iterations == MaxIterations ? FractalFillColor.Color : BackGroundColor.Color;

                    // Создание прямоугольника с заданным цветом заполнения
                    Rectangle rect = new Rectangle
                    {
                        Width = 1,
                        Height = 1,
                        Fill = new SolidColorBrush(fillColor)
                    };

                    // Установка позиции прямоугольника на холсте
                    Canvas.SetLeft(rect, xPixel);
                    Canvas.SetTop(rect, yPixel);
                    canvas.Children.Add(rect);
                }
            }

        }

        private int CalculateJuliaIterations(double x0, double y0, double EscapeRadius, int MaxIterations, double cReal, double cImaginary)
        {
            // Инициализация начальных значений
            double x = x0;
            double y = y0;
            int iterations = 0;

            // Итерационный расчет точки в множестве Жюлиа
            while (x * x + y * y <= EscapeRadius * EscapeRadius && iterations < MaxIterations)
            {
                double xTemp = x * x - y * y + cReal;
                y = 2 * x * y + cImaginary;
                x = xTemp;
                iterations++;
            }

            return iterations;
        }

        private double Map(double value, double inMin, double inMax, double outMin, double outMax)
        {
            // Масштабирование значения из одного диапазона в другой
            return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }
    }
}
