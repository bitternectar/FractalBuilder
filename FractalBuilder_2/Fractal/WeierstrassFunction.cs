using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FractalBuilder_2.Fractal
{
    internal class WeierstrassFunction : Fractal
    {
        public WeierstrassFunction(int depth) : base(depth)
        {
        }

        public override void Draw(Canvas canvas)
        {
            // Очистка холста
            canvas.Children.Clear();

            // Расчет размеров
            double width = canvas.ActualWidth;
            double height = canvas.ActualHeight;
            double xScale = width / 10;
            double yScale = height / 4;
            double xStep = 0.01;

            // Рисование графика функции Вейерштрасса
            Path path = new Path();
            path.Stroke = FractalLineColor;
            path.StrokeThickness = 1;
            PathGeometry pathGeometry = new PathGeometry();
            PathFigure pathFigure = new PathFigure();

            double x = 0;
            double y = 0;
            pathFigure.StartPoint = new Point(x * xScale, height / 2 - y * yScale);

            for (int i = 0; i < 1000; i++)
            {
                double sum = 0;
                for (int n = 0; n < 10; n++)
                {
                    double a = Math.Pow(0.5, n);
                    double b = Math.Pow(3, n);
                    sum += a * Math.Sin(b * Math.PI * x);
                }
                y = sum;
                pathFigure.Segments.Add(new LineSegment(new Point(x * xScale, height / 2 - y * yScale), true));
                x += xStep;
            }

            pathGeometry.Figures.Add(pathFigure);
            path.Data = pathGeometry;
            canvas.Children.Add(path);
        }
    }
}
