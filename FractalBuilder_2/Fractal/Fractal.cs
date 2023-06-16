using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FractalBuilder_2.Fractal
{
    //Базовый класс для фракталов
    public abstract class Fractal
    {
        private SolidColorBrush? fractalFillColor;
        private SolidColorBrush? fractalLineColor;
        private SolidColorBrush? backGroundColor;

        public SolidColorBrush? FractalFillColor { get => fractalFillColor; set => fractalFillColor = value; }
        public SolidColorBrush? FractalLineColor { get => fractalLineColor; set => fractalLineColor = value; }
        public int Depth { get => depth; set => depth = value; }
        public SolidColorBrush? BackGroundColor { get => backGroundColor; set => backGroundColor = value; }

        private int depth;

        public Fractal(int depth)
        {
            this.Depth = depth;
        }

        public abstract void Draw(Canvas canvas);

    }
}
