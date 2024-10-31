using Microsoft.Win32;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Прак__1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Height += 40;
            Width += 40;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e) // Диалоговое окно и с условием задания
        {
            MessageBox.Show("Кашаев Кирилл \r\n ИСП-24 \r\n " +
                         "Номер задания 1: Вычислить сумму целых случайных чисел, " +
                         "распределенных в диапазоне от 2 до 10, пока эта сумма не превышает некоторого числа K. " +
                         "Вывести на экран сгенерированные числа, значение суммы, и количество сгенерированных чисел.", "О проге");
        }
        private void Button_Click_2(object sender, RoutedEventArgs e) // Закрытие практического задания
        {
            Close();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e) 
        {
            if (!int.TryParse(Ks.Text, out int K) || K <= 0)
            {
                MessageBox.Show("Пожалуйста, введите корректное значение для K.");  // Диалоговое окно с ошибкой ввода значения
                return; 
            }

            List<int> numbers = new List<int>();
            int sum = 0;

            while (true)
            {
                Random rnd = new Random();
                int randomNumber = rnd.Next(2, 10); 
                if (sum + randomNumber > K)
                {
                    break;
                }
                numbers.Add(randomNumber);
                sum += randomNumber;
            }
            GN.Text = string.Join(", ", numbers); // Сгенерированные числа
            TS.Text = sum.ToString(); // Сумма
            NC.Text = numbers.Count.ToString(); // Количество чисел

        }

        private void Button_Click(object sender, RoutedEventArgs e) // Удаление текстового бокса и текстовых блоков 
        {
            Ks.Clear();
            TS.Text = "";
            GN.Text = "";
            NC.Text = "";
        }

        private void Save_MenuItem_Click(object sender, RoutedEventArgs e) // Окно с сохранением файла
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            if (save.ShowDialog() == true) // Получаем путь к файлу
            {
                StreamWriter file = new StreamWriter(save.FileName);
                file.WriteLine(Ks.Text);
                for (int i = 0; i < 0; i++)
                {
                    file.WriteLine(Ks.Text);
                }
                file.Close();

                // Диалоговое окно после сохранения таблицы
                try
                {
                    File.WriteAllText(Ks.Text, "данные");
                    MessageBox.Show("Файл успешно сохранен");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения файла: {ex.Message}");
                }
            }
        }

        private void Open_MenuItem_Click(object sender, RoutedEventArgs e) // Окно с открытием файла
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            if (open.ShowDialog() == true) // Получаем путь к файлу
            {
                using (StreamReader file = new StreamReader(open.FileName))
                {
                    Ks.Text = file.ReadToEnd();
                }

                // Диалоговое окно с открытием файла
                try
                {
                    MessageBox.Show("Файл успешно открыт");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка открытия файла: {ex.Message}");
                }
            }
        }

        private void Spravka_MenuItem_Click(object sender, RoutedEventArgs e) 
        {
         MessageBox.Show("Кашаев Кирилл \r\n ИСП-24 \r\n " +
             "Номер задания 1: Вычислить сумму целых случайных чисел, " +
             "распределенных в диапазоне от 2 до 10, пока эта сумма не превышает некоторого числа K. " +
             "Вывести на экран сгенерированные числа, значение суммы, и количество сгенерированных чисел.", "Справка о проге");
        }
    }
}