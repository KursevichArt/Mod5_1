using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Mod5_4
{
    public partial class MainWindow : Window
    {
        private BitmapImage originalImage;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                originalImage = new BitmapImage(new Uri(openFileDialog.FileName));
                imageViewer.Source = originalImage;
                zoomSlider.Value = 1; // Сброс масштаба
            }
        }

        private void ZoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (imageViewer.Source != null)
            {
                // Масштабирование изображения с помощью ScaleTransform
                imageScaleTransform.ScaleX = zoomSlider.Value;
                imageScaleTransform.ScaleY = zoomSlider.Value;
            }
        }
    }
}