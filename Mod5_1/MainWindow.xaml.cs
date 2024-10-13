using System;
using static System.Math;
using static System.Windows.Controls.Canvas;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Mod5_1
{
    public partial class MainWindow : Window
    {
        private bool _isDrawing;
        private Point _startPoint;
        private string _currentShape;
        private Shape _currentShapeObject; // Текущая фигура, которую мы рисуем

        public MainWindow()
        {
            InitializeComponent();
            _currentShape = "Line"; // По умолчанию линия
            ShapeSelector.SelectionChanged += ShapeSelector_SelectionChanged;
        }

        private void ShapeSelector_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _currentShape = ((ComboBoxItem)ShapeSelector.SelectedItem).Content.ToString();
        }

        private void DrawingCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _isDrawing = true;
                _startPoint = e.GetPosition(DrawingCanvas);

                // Создание фигуры на основе текущего выбора
                switch (_currentShape)
                {
                    case "Line":
                        _currentShapeObject = new Line
                        {
                            Stroke = Brushes.Black,
                            StrokeThickness = 2
                        };
                        break;
                    case "Circle":
                        _currentShapeObject = new Ellipse
                        {
                            Stroke = Brushes.Black,
                            StrokeThickness = 2
                        };
                        break;
                    case "Square":
                        _currentShapeObject = new Rectangle
                        {
                            Stroke = Brushes.Black,
                            StrokeThickness = 2
                        };
                        break;
                }

                if (_currentShapeObject != null)
                    DrawingCanvas.Children.Add(_currentShapeObject);
            }
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDrawing && _currentShapeObject != null)
            {
                var endPoint = e.GetPosition(DrawingCanvas);

                // Обновление фигуры
                switch (_currentShape)
                {
                    case "Line":
                        var line = (Line)_currentShapeObject;
                        line.X1 = _startPoint.X;
                        line.Y1 = _startPoint.Y;
                        line.X2 = endPoint.X;
                        line.Y2 = endPoint.Y;
                        break;
                    case "Circle":
                        var radius = Max(Abs(endPoint.X - _startPoint.X), Abs(endPoint.Y - _startPoint.Y));
                        var ellipse = (Ellipse)_currentShapeObject;
                        ellipse.Width = radius;
                        ellipse.Height = radius;
                        SetLeft(ellipse, _startPoint.X);
                        SetTop(ellipse, _startPoint.Y);
                        break;
                    case "Square":
                        var size = Max(Abs(endPoint.X - _startPoint.X), Abs(endPoint.Y - _startPoint.Y));
                        var rectangle = (Rectangle)_currentShapeObject;
                        rectangle.Width = size;
                        rectangle.Height = size;
                        SetLeft(rectangle, _startPoint.X);
                        SetTop(rectangle, _startPoint.Y);
                        break;
                }
            }
        }

        private void DrawingCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released)
            {
                _isDrawing = false;
                _currentShapeObject = null; // Сброс текущей фигуры после завершения рисования
            }
        }
    }
}