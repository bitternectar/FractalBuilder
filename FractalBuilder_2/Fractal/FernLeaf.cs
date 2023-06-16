using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Point = System.Windows.Point;

/*Смирновский Михаил*/
namespace FractalBuilder_2.Fractal
{
    public class FernLeaf : Fractal
    {
        public FernLeaf(int depth) : base(depth)
        {
        }

        public override void Draw(Canvas canvas)
        {
            canvas.Children.Clear();

            var height = (int)canvas.ActualHeight;
            var width = (int)canvas.ActualWidth;

            double size = Math.Min(width, height) * 0.8;
            double startX = (width - size) / 2;
            double startY = (height - size) / 2;

            var point = new Point(startX + size / 2, startY + size);

            DrawFern(point, size / 4, -90, Depth, canvas);
        }

        private void DrawFern(Point point, double length, double angle, int depth, Canvas canvas)
        {
            if (depth == 0)
            {
                // Рисование точки
                Ellipse p = new Ellipse();
                p.Width = 1;
                p.Height = 1;
                p.Fill = FractalFillColor;
                Canvas.SetLeft(p, point.X);
                Canvas.SetTop(p, point.Y);
                canvas.Children.Add(p);
            }
            else
            {
                // Рекурсивные вызовы для ветвей папоротника
                var newPoint = new System.Windows.Point(
                    point.X + length * Math.Cos(angle * Math.PI / 180),
                    point.Y + length * Math.Sin(angle * Math.PI / 180)
                    );

                DrawFern(newPoint, length / 3, angle - 45, depth - 1, canvas);
                DrawFern(newPoint, length / 3, angle + 45, depth - 1, canvas);
                DrawFern(newPoint, length * 2 / 3, angle, depth - 1, canvas);
            }
        }
    }
}
