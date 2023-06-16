using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
/*Смирновский Михаил Евгеньевич*/
namespace FractalBuilder_2.Fractal
{
    internal class MandelbrotSet : Fractal
    {
        public MandelbrotSet(int depth) : base(depth)
        {
        }

        public override void Draw(Canvas canvas)
        {
            canvas.Children.Clear();

            int MaxIterations   = 200;
            double EscapeRadius = 2.0;

            int canvasWidth  = (int)canvas.ActualWidth;
            int canvasHeight = (int)canvas.ActualHeight;

            double xMin = -2.5;
            double xMax = 1.0;
            double yMin = -1.5;
            double yMax = 1.5;

            for (int xPixel = 0; xPixel < canvasWidth; xPixel++)
            {
                for (int yPixel = 0; yPixel < canvasHeight; yPixel++)
                {
                    // Преобразуем координаты пикселей в комплексную плоскость
                    double x0 = Map(xPixel, 0, canvasWidth, xMin, xMax);
                    double y0 = Map(yPixel, 0, canvasHeight, yMin, yMax);

                    // Вычисляем количество итераций для точки в множестве Мандельброта
                    int iterations = CalculateMandelbrotIterations(x0, y0, EscapeRadius, MaxIterations );
                    Color fillColor = iterations == MaxIterations ? FractalFillColor.Color : BackGroundColor.Color;
                    
                    // Создаем прямоугольник с заданным цветом заполнения
                    Rectangle rect = new Rectangle
                    {
                        Width = 1,
                        Height = 1,
                        Fill = new SolidColorBrush(fillColor)
                    };

                    // Устанавливаем позицию прямоугольника на холсте
                    Canvas.SetLeft(rect, xPixel);
                    Canvas.SetTop(rect, yPixel);
                    canvas.Children.Add(rect);
                }
            }
        }

        private int CalculateMandelbrotIterations(double x0, double y0, double EscapeRadius, int MaxIterations)
        {
            // Инициализация начальных значений
            double x = 0;
            double y = 0;
            int iterations = 0;

            // Итерационный расчет точки в множестве Мандельброта
            while (x * x + y * y <= EscapeRadius * EscapeRadius && iterations < MaxIterations)
            {
                double xTemp = x * x - y * y + x0;
                y = 2 * x * y + y0;
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
