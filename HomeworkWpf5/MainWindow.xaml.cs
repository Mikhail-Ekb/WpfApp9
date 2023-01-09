using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeworkWpf5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (textBox != null)
            {
                string fontName = ((sender as ComboBox).SelectedItem as string);
                textBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (textBox != null)
            {
                double fontSize = Convert.ToDouble(((sender as ComboBox).SelectedItem as string));
                textBox.FontSize = fontSize;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.FontWeight == FontWeights.Normal)
                textBox.FontWeight = FontWeights.Bold;
            else textBox.FontWeight = FontWeights.Normal;
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontStyle = textBox.FontStyle != FontStyles.Italic ? FontStyles.Italic : FontStyles.Normal;
        }

        private void ToggleButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox.TextDecorations.Count == 0)
                textBox.TextDecorations.Add(TextDecorations.Underline);
            else textBox.TextDecorations.Remove(TextDecorations.Underline[0]);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Black;
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Red;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Закрыть программу?", "Внимание", MessageBoxButton.OKCancel);
            if (res == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
        }
        private void themes_SelectionChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Application.Current.MergedDictionarles.Clear();
            Uri theme -new Uri(Themes.SelectedIndex--0 ? "Lingt.xaml" : "Dark.xaml", UriKind.Relative);
            ResourceDictionary themeDict = Application.LoadComponent(theme) as ResourceDictionary;
            Application.Current.MergedDictionarles.Add(themeDict);
        }
    }
}