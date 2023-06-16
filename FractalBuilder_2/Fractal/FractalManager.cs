using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace FractalBuilder_2.Fractal
{
    internal class FractalManager
    {
        private SolidColorBrush backgroundColor;
        private SolidColorBrush fractalFillColor;
        private SolidColorBrush fractalLineColor;
        private Canvas canvas;

        public FractalManager(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public SolidColorBrush BackgroundColor { get => backgroundColor; set => backgroundColor = value; }
        public SolidColorBrush FractalFillColor { get => fractalFillColor; set => fractalFillColor = value; }
        public SolidColorBrush FractalLineColor { get => fractalLineColor; set => fractalLineColor = value; }

        public void drawFractal(FractalType fractalType, int recursionDepth)
        {
            FractalBuilder_2.Fractal.Fractal? fr = null;

            switch (fractalType)
            {
                case FractalType.KochSnowflake:
                    fr = new KochSnowflake(recursionDepth);
                    break;
                case FractalType.HarterHeighwayDragon:
                    fr = new HarterHeighwayDragon(recursionDepth);
                    break;
                case FractalType.FernLeaf:
                    fr = new FernLeaf(recursionDepth);
                    break;
                case FractalType.SierpinskiCarpet:
                    fr = new SierpinskiCarpet(recursionDepth);
                    break;
                case FractalType.SierpinskiTriangle:
                    fr = new SierpinskiTriangle(recursionDepth);
                    break;
                case FractalType.WeierstrassFunction:
                    fr = new WeierstrassFunction(recursionDepth);
                    break;
                case FractalType.VanDerVaardenFunction:
                    fr = new VanDerVaardenFunction(recursionDepth);
                    break;
                case FractalType.MandelbrotSet:
                    fr = new MandelbrotSet(recursionDepth);
                    break;
                case FractalType.JuliaSet:
                    fr = new JuliaSet(recursionDepth);
                    break;
            }
            if (fr != null)
            {
                fr.FractalFillColor = FractalFillColor;
                fr.FractalLineColor = FractalLineColor;
                fr.BackGroundColor = BackgroundColor;
                fr.Draw(canvas);
            }
        }
    }
}
