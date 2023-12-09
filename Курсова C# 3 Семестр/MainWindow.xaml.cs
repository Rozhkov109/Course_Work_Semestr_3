using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CourseWork
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Point> fxPointsCollection = new ObservableCollection<Point>();
        private ObservableCollection<Point> gxPointsCollection = new ObservableCollection<Point>();
        public MainWindow()
        {
            InitializeComponent();
            ErrorManager.ErrorHandler = (errorMessage) => ErrorManager.GetErrorMessage(errorMessage);
            FxDataGrid.ItemsSource = fxPointsCollection;
            GxDataGrid.ItemsSource = gxPointsCollection;
        }

        private void FxAddPoint_Click(object sender, RoutedEventArgs e)
        {
            Point newPoint = new Point(0, 0);
            fxPointsCollection.Add(newPoint);
        }

        private void FxRemovePoint_Click(object sender, RoutedEventArgs e)
        {
            if (FxDataGrid.SelectedItems.Count > 0)
            {
                List<Point> selectedPoints = new List<Point>();

                foreach (var selectedItem in FxDataGrid.SelectedItems)
                {
                    if (selectedItem is Point selectedPoint)
                    {
                        selectedPoints.Add(selectedPoint);
                    }
                }

                foreach (var selectedPoint in selectedPoints)
                {
                    fxPointsCollection.Remove(selectedPoint);
                }
            }
        }

        private void GxAddPoint_Click(object sender, RoutedEventArgs e)
        {
            Point newPoint = new Point(0, 0);
            gxPointsCollection.Add(newPoint);
        }

        private void GxRemovePoint_Click(object sender, RoutedEventArgs e)
        {
            if (GxDataGrid.SelectedItems.Count > 0)
            {
                List<Point> selectedPoints = new List<Point>();

                foreach (var selectedItem in GxDataGrid.SelectedItems)
                {
                    if (selectedItem is Point selectedPoint)
                    {
                        selectedPoints.Add(selectedPoint);
                    }
                }

                foreach (var selectedPoint in selectedPoints)
                {
                    gxPointsCollection.Remove(selectedPoint);
                }
            }
        }

        private void MenuItem_LoadFromXml_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Фільтр пошуку
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                fxPointsCollection.Clear();
                gxPointsCollection.Clear();

                string filePath = openFileDialog.FileName; // шлях до файлу


                FunctionWithPointsFileManager filemanager = new FunctionWithPointsFileManager();
                FunctionWithPoints Fx = new FunctionWithPoints();
                FunctionWithPoints Gx = new FunctionWithPoints();
                (Fx,Gx) = filemanager.DeserializeFunctionsFromXML(filePath);

                // Запис в PointsCollection
                Fx.PointsList.ForEach(point => fxPointsCollection.Add(new Point { X = point.X, Y = point.Y }));
                Gx.PointsList.ForEach(point => gxPointsCollection.Add(new Point { X = point.X, Y = point.Y }));
            }
        }



        private void EnterNumbersToTextBox(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                string newText = textBox.Text;
                if (!string.IsNullOrEmpty(newText) && newText.All(c => char.IsDigit(c) || c == '.' || c == '-'))
                {
                    // Дозволяємо запис
                }
                else
                {
                    // Не дозволяємо запис
                    textBox.Text = string.Concat(newText.Where(c => char.IsDigit(c) || c == '.' || c == '-'));
                    textBox.CaretIndex = textBox.Text.Length; // установить каретку в конец текста
                }
            }
        }

        private void EnterNumbersToEpsTextBox(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                string newText = textBox.Text;
                if (!string.IsNullOrEmpty(newText) && newText.All(c => char.IsDigit(c) || c == '.'))
                {
                    // Дозволяємо запис
                }
                else
                {
                    // Не дозволяємо запис
                    textBox.Text = string.Concat(newText.Where(c => char.IsDigit(c) || c == '.'));
                    textBox.CaretIndex = textBox.Text.Length; // установить каретку в конец текста
                }
            }
        }

        private void FindMaximumButton_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
