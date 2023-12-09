using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
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
            ErrorManager.ErrorHandler = ErrorManager.GetErrorMessage;
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


        private void MenuItem_SaveToXml_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                FunctionWithPointsFileManager fileManager = new FunctionWithPointsFileManager();

                FunctionWithPoints Fx = new FunctionWithPoints();
                FunctionWithPoints Gx = new FunctionWithPoints();

                foreach (var point in fxPointsCollection)
                {
                    Fx.AddPointToEnd(point.X, point.Y);
                }

                foreach (var point in gxPointsCollection)
                {
                    Gx.AddPointToEnd(point.X, point.Y);
                }

                fileManager.SerializeFunctionsToXML(Fx, Gx,filePath);
            }
        }

        private void MenuItem_GeneratePDF_Click(object sender, RoutedEventArgs e)
        {
            // Создаем диалоговое окно сохранения файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Устанавливаем фильтр для файлов PDF
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";

            // Открываем диалоговое окно и проверяем результат
            if (saveFileDialog.ShowDialog() == true)
            {
                // Получаем путь к выбранному файлу
                string filePath = saveFileDialog.FileName;

                // Создаем объект FunctionWithPointsFileManager
                FunctionWithPointsFileManager fileManager = new FunctionWithPointsFileManager();

                // Создаем объект FunctionWithPoints и добавляем в него данные из таблицы
                FunctionWithPoints Fx = new FunctionWithPoints();
                FunctionWithPoints Gx = new FunctionWithPoints();

                // Считываем данные из таблицы
                List<Point> fxPoints = fxPointsCollection.ToList();
                List<Point> gxPoints = gxPointsCollection.ToList();

                // Добавляем точки в объекты Fx и Gx
                fxPoints.ForEach(point => Fx.AddPointToEnd(point.X, point.Y));
                gxPoints.ForEach(point => Gx.AddPointToEnd(point.X, point.Y));

                // Создаем объект PDFGenerator и генерируем PDF-отчет
                FunctionWithPointsFileManager pdfGenerator = new FunctionWithPointsFileManager();
                pdfGenerator.GeneratePDFReport (
                    Fx, 
                    Gx, 
                    double.Parse(StartTextBox.Text, CultureInfo.InvariantCulture), 
                    double.Parse(EndTextBox.Text, CultureInfo.InvariantCulture), 
                    double.Parse(EpsTextBox.Text, CultureInfo.InvariantCulture), 
                    filePath
                );
            }
        }

        private void MenuItem_About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Назва програми: Пошук максимуму функції\r\n\r\nОпис:\r\n" +
                "Призначення програми полягає в обчисленні максимуму функції за допомогою введення точок " +
                "інтервалів та заданої точності. Програма надає можливість введення точок функцій F(x) та G(x), " +
                "збереження цих даних у файл формату XML, а також генерації звіту у форматі PDF з результатами обчислень." +
                "\n\nПримітка: Функції які будуть використовуватися у обчисленні повинні бути УНІМОДАЛЬНИМИ. У іншому випадку " +
                "обчислення відбуватися не буде та з`явиться повідомлення про помилку.\n" +
                "Перед обчисленням максимуму переконайтеся, що введені дані є коректними числовими значеннями та вибрано всі необхідні параметри." +
                "\r\n\r\nКнопки та їх функції:\r\n\r\n\nЗавантажити з XML (Файл -> Завантажити з XML):\r\nФункція: " +
                "Завантажити дані точок функцій F(x) та G(x) з XML-файлу.\r\n\nЗберегти дані в XML (Файл -> Зберегти дані в XML):" +
                "\r\nФункція: Зберегти введені точки функцій F(x) та G(x) у XML-файл.\r\n\nСтворити звіт в PDF (Файл -> Створити звіт в PDF):" +
                "\r\nФункція: Створити звіт у форматі PDF з результатами обчислень на введених точках.\r\n\nДодати Точку (F(x) та G(x)):\r\nФункція: " +
                "Додати нову точку у таблицю для функції F(x) або G(x).\r\n\nВидалити Точку (F(x) та G(x)):\r\nФункція: Видалити вибрані точки із таблиці для функції F(x) або G(x)." +
                "\r\n\nЗнайти максимум:\r\nФункція: Обчислити максимум функції на введених інтервалах та зазначеній точності.\r\nПочаток інтервалу, Кінець інтервалу, Точність обчислень:\r\n" +
                "Введення: Вказання початку та кінця інтервалу, а також точності обчислень для пошуку максимуму.\r\nРезультат:\r\nВиведення: Максимум функції на заданому інтервалі та графік F(x) - Gx у окремому вікні.\r\n");
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
            FunctionWithPoints Fx = new FunctionWithPoints();
            FunctionWithPoints Gx = new FunctionWithPoints();

            List<Point> fxPoints = fxPointsCollection.ToList();
            List<Point> gxPoints = gxPointsCollection.ToList();

            fxPoints.ForEach(point => Fx.AddPointToEnd(point.X, point.Y));
            gxPoints.ForEach(point => Gx.AddPointToEnd(point.X, point.Y));


            if (double.TryParse(StartTextBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double start) &&
                double.TryParse(EndTextBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double end) &&
                double.TryParse(EpsTextBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double eps))
            {

                if (!string.IsNullOrWhiteSpace(StartTextBox.Text) &&
                    !string.IsNullOrWhiteSpace(EndTextBox.Text) &&
                    !string.IsNullOrWhiteSpace(EpsTextBox.Text))
                {
                    FunctionWithPointsCalculator calc = new FunctionWithPointsCalculator();
                    double result = calc.FindMaximum(start,end,Fx, Gx,eps);

                    if(Fx.IsUnimodal && Gx.IsUnimodal) 
                    {
                        AnswerTextBox.Text = result.ToString(CultureInfo.InvariantCulture);
                        Graph graphWindow = new Graph(Fx, Gx, eps);
                        graphWindow.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Будь ласка, заповніть всі поля для введення інтервалів та точності.", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть коректні числові значення для інтервалів та точності.", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


    }
}
