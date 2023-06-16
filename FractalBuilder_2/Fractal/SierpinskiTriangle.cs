using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

/*Смирновский Михаил*/
namespace FractalBuilder_2.Fractal
{
    internal class SierpinskiTriangle : Fractal
    {
        public SierpinskiTriangle(int depth) : base(depth)
        {
        }

        public override void Draw(Canvas canvas)
        {
            canvas.Children.Clear();

            var height = (int)canvas.ActualHeight;
            var width = (int)canvas.ActualWidth;

            double size = Math.Min(width, height) * 0.8;
            double startX = (width - size) / 2;
            double startY = (height - size * Math.Sqrt(3) / 2) / 2;

            var point = new Point(startX, startY + size * Math.Sqrt(3) / 2);

            DrawTriangle(point, size, Depth, canvas);
        }

        private void DrawTriangle(Point point, double size, int depth, Canvas canvas)
        {
            if (depth == 0)
            {
                // Рисование треугольника
                DrawPolygon(
                    new Point(point.X, point.Y), 
                    new Point(point.X + size, point.Y), 
                    new Point(point.X + size / 2, point.Y - size * Math.Sqrt(3) / 2), 
                    canvas);
            }
            else
            {
                double newSize = size / 2;

                // Рекурсивные вызовы для треугольников внутри
                DrawTriangle(new Point(point.X, point.Y), newSize, depth - 1, canvas);
                DrawTriangle(new Point(point.X + newSize, point.Y), newSize, depth - 1, canvas);
                DrawTriangle(new Point(point.X + newSize / 2, point.Y - newSize * Math.Sqrt(3) / 2), 
                    newSize, 
                    depth - 1, 
                    canvas);
            }
        }

        private void DrawPolygon(Point point1, Point point2, Point point3, Canvas canvas)
        {
            Polygon polygon = new Polygon();
            polygon.Points.Add(point1);
            polygon.Points.Add(point2);
            polygon.Points.Add(point3);
            polygon.Fill = FractalFillColor;
            polygon.Stroke = FractalLineColor;
            polygon.StrokeThickness = 1;
            canvas.Children.Add(polygon);
        }
    }
}
