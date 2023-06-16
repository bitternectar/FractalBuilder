using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace FractalBuilder_2.Fractal
{
    internal class SierpinskiCarpet : Fractal
    {
        public SierpinskiCarpet(int depth) : base(depth)
        {
        }

        public override void Draw(Canvas canvas)
        {
            canvas.Children.Clear();

            var height = (int)canvas.ActualHeight;
            var width  = (int)canvas.ActualWidth;

            double size   = Math.Min(width, height) * 0.8;
            double startX = (width - size) / 2;
            double startY = (height - size) / 2;

            var point = new Point(startX , startY );

            DrawCarpet(point, size, Depth, canvas);
        }


        private void DrawCarpet(Point point, double size, int depth, Canvas canvas)
        {
            if (depth == 0)
            {
                // Рисование прямоугольника
                Rectangle rectangle = new Rectangle();
                rectangle.Width     = size;
                rectangle.Height    = size;
                rectangle.Fill      = FractalFillColor;
                rectangle.Stroke    = FractalLineColor;
                rectangle.StrokeThickness = 1;
                Canvas.SetLeft(rectangle, point.X);
                Canvas.SetTop(rectangle, point.Y);
                canvas.Children.Add(rectangle);
            }
            else
            {
                double newSize = size / 3;

                // Рекурсивные вызовы для внутренних прямоугольников
                DrawCarpet(point, newSize, depth - 1, canvas);
                DrawCarpet(new Point(point.X + newSize, point.Y), newSize, depth - 1, canvas);
                DrawCarpet(new Point(point.X + 2 * newSize, point.Y), newSize, depth - 1, canvas);
                DrawCarpet(new Point(point.X , point.Y + newSize), newSize, depth - 1, canvas);
                DrawCarpet(new Point(point.X + 2 * newSize, point.Y + newSize), newSize, depth - 1, canvas);
                DrawCarpet(new Point(point.X , point.Y + 2 * newSize), newSize, depth - 1, canvas);
                DrawCarpet(new Point(point.X +  newSize, point.Y + 2*newSize), newSize, depth - 1, canvas);
                DrawCarpet(new Point(point.X + 2 * newSize, point.Y + 2*newSize), newSize, depth - 1, canvas);
            }
        }
    }
}
