using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


/*Смирновский Михаил*/
namespace FractalBuilder_2.Fractal
{
    //Снежинка Коха
    public class KochSnowflake : Fractal
    {
        public KochSnowflake(int depth) : base(depth)
        {
        }

        public override void Draw(Canvas canvas)
        {
            canvas.Children.Clear();

            var path = new System.Windows.Shapes.Path
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

            var line1StartPoint = new Point(width/3, 2 * height/3);
            var line1EndPoint = new Point(2 * width / 3, 2 * height / 3);

            var line2StartPoint = new Point(width / 3, 2 * height / 3);
            var line2EndPoint = new Point(1.5 * width / 3,  height / 3);

            var line3StartPoint = new Point(1.5 * width / 3, height / 3);
            var line3EndPoint = new Point(2 * width / 3, 2 * height / 3);

            // Рекурсивно рисуем фрактал
            DrawKochLine(path, line1StartPoint, line1EndPoint, Depth, 1);
            DrawKochLine(path, line2StartPoint, line2EndPoint, Depth, 0);
            DrawKochLine(path, line3StartPoint, line3EndPoint, Depth, 0);

            // Добавляем объект Path на существующий Canvas
            canvas.Children.Add(path);
        }

        private void DrawKochLine(Path path, Point startPoint, Point endPoint, int depth, int dirFlag)
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
                // Вычисляем координаты новых точек для рисования фрактала

                var dx = (endPoint.X - startPoint.X) / 3;
                var dy = (endPoint.Y - startPoint.Y) / 3;



                var p1 = new Point(startPoint.X + dx, startPoint.Y + dy);
                var p3 = new Point(endPoint.X - dx, endPoint.Y - dy);

                var angle = 60 * (Math.PI / 180);

                if (dirFlag > 0) angle = -angle;

                var p2 = new Point(p1.X + dx * Math.Cos(angle) + dy * Math.Sin(angle),
                                   p1.Y - dx * Math.Sin(angle) + dy * Math.Cos(angle));

                // Рекурсивно вызываем функцию рисования для каждого из 4 отрезков

                DrawKochLine(path, startPoint, p1, depth - 1, dirFlag);
                DrawKochLine(path, p1, p2, depth - 1, dirFlag);
                DrawKochLine(path, p2, p3, depth - 1, dirFlag);
                DrawKochLine(path, p3, endPoint, depth - 1, dirFlag);
            }
        }
    }
}
