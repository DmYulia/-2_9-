using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wpf9
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
            string font_name = ((sender as ComboBox).SelectedItem as string);
            if (text_box != null)
            {
                text_box.FontFamily = new FontFamily(font_name);
            }
        }
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            double font_size = Convert.ToDouble(((sender as ComboBox).SelectedItem as string));
            if (text_box != null)
            {
                text_box.FontSize = font_size;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (text_box.FontWeight == FontWeights.Normal)
            {
                text_box.FontWeight = FontWeights.Bold;
            }
            else
            {
                text_box.FontWeight = FontWeights.Normal;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (text_box.FontStyle == FontStyles.Normal)
            {
                text_box.FontStyle = FontStyles.Italic;
            }
            else
            {
                text_box.FontStyle = FontStyles.Normal;
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (text_box.TextDecorations == null)
            {
                text_box.TextDecorations = TextDecorations.Underline;
            }
            else
            {
                text_box.TextDecorations = null;
            }
        }
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            text_box.Foreground = Brushes.Black;
        }
        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            text_box.Foreground = Brushes.Red;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open_file_dialog = new OpenFileDialog();
            open_file_dialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (open_file_dialog.ShowDialog() == true)
            {
                text_box.Text = File.ReadAllText(open_file_dialog.FileName);
            }
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save_file_dialog = new SaveFileDialog();
            save_file_dialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (save_file_dialog.ShowDialog() == true)
            {
                File.WriteAllText(save_file_dialog.FileName, text_box.Text);
            }
        }
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void themes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            Uri theme = new Uri(themes.SelectedIndex == 0 ? "Green.xaml" : "Violet.xaml", UriKind.Relative);
            ResourceDictionary themeDict = Application.LoadComponent(theme) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(themeDict);
        }
    }
}
