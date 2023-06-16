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
    internal class HarterHeighwayDragon : Fractal
    {
        public HarterHeighwayDragon(int depth) : base(depth)
        {
        }

        public override void Draw(Canvas canvas)
        {
            canvas.Children.Clear();

            var path = new Path
            {
                Stroke = this.FractalLineColor,
                StrokeThickness = 1
            };
            // Создаем новый объект PathGeometry для фрактала
            var pathGeometry = new PathGeometry();
            // Устанавливаем PathGeometry в Data объекта Path
            path.Data = pathGeometry;

            var height = (int)canvas.ActualHeight;
            var width = (int)canvas.ActualWidth;

            var startPoint = new Point(width / 3, 2 * height / 3);
            var endPoint = new Point(2 * width / 3, 2 * height / 3);

            // Рекурсивно рисуем фрактал
            DrawDragon(path, startPoint, endPoint, Depth);

            // Добавляем объект Path на существующий Canvas
            canvas.Children.Add(path);
        }

        private void DrawDragon(Path path, Point startPoint, Point endPoint, int depth)
        {
            if (depth == 0)
            {
                // Добавляем отрезок линии в объект Path при достижении
                // максимальной глубины рекурсии
                var lineGeometry = new LineGeometry(startPoint, endPoint);
                ((PathGeometry)path.Data).AddGeometry(lineGeometry);
            }
            else
            {
                var point = new Point(
                    (startPoint.X + endPoint.X)/2 + (endPoint.Y - startPoint.Y)/2,
                    (endPoint.Y + startPoint.Y) / 2 - (endPoint.X - startPoint.X) / 2);

                DrawDragon(path, endPoint, point, depth - 1);
                DrawDragon(path, startPoint, point, depth - 1);
            }
        }
    }
}
