using FractalBuilder_2.Fractal;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FractalBuilder_2
{
    public partial class MainWindow : Window
    {

        private FractalManager manager;

        public MainWindow()
        {
            InitializeComponent();

            manager = new FractalManager(FractalCanvas);
            // Установка значений по умолчанию
            manager.BackgroundColor  = Brushes.Black;
            manager.FractalFillColor = Brushes.Gray;
            manager.FractalLineColor = Brushes.White;

            FractalCanvas.Background = manager.BackgroundColor;
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            FractalType fractalType = (FractalType)FractalComboBox.SelectedIndex;
            int recursionDepth      = Convert.ToInt32(RecursionTextBox.Text);

            manager.drawFractal(fractalType, recursionDepth);
        }

        private void SaveImage_Click(object sender, RoutedEventArgs e)
        {
            // Создаем растровое изображение
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
                (int)FractalCanvas.ActualWidth,
                (int)FractalCanvas.ActualHeight,
                96d,
                96d,
                PixelFormats.Pbgra32);

            // Рисуем содержимое Canvas на растровое изображение
            renderBitmap.Render(FractalCanvas);

            // Создаем диалог сохранения файла
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter   = "PNG Image|*.png";
            saveDialog.Title    = "Сохранить изображение";
            saveDialog.FileName = "FractalImage.png";

            if (saveDialog.ShowDialog() == true)
            {
                // Создаем кодировщик изображений PNG
                PngBitmapEncoder pngEncoder = new PngBitmapEncoder();
                pngEncoder.Frames.Add(BitmapFrame.Create(renderBitmap));

                // Сохраняем изображение в выбранный файл
                using (FileStream fileStream = new FileStream(saveDialog.FileName, FileMode.Create))
                {
                    pngEncoder.Save(fileStream);
                }
            }
        }

        private void AboutProgramButton_Click(object sender, RoutedEventArgs e)
        {
            AboutProgram ap = new AboutProgram();

            ap.ShowDialog();
        }

    }
}