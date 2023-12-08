using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CourseWork
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ErrorManager.ErrorHandler = (errorMessage) => ErrorManager.GetErrorMessage(errorMessage);
        }

        private void FxAddPoint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FxRemovePoint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GxAddPoint_Click(object sender, RoutedEventArgs e)
        {

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
