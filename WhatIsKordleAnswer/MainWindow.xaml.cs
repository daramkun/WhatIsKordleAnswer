using System;
using System.Collections.Generic;
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

namespace WhatIsKordleAnswer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly char[] TotalChars = {
            '\0', 'ㄱ', 'ㄴ', 'ㄷ', 'ㄹ', 'ㅁ', 'ㅂ', 'ㅅ', 'ㅇ', 'ㅈ', 'ㅊ', 'ㅋ', 'ㅌ', 'ㅍ', 'ㅎ', 'ㅏ', 'ㅑ', 'ㅓ', 'ㅕ', 'ㅗ', 'ㅛ',
            'ㅜ', 'ㅠ', 'ㅡ', 'ㅣ'
        };
        
        public MainWindow()
        {
            InitializeComponent();
            
            WordLoader.LoadWords();

            ComboBoxSpecificChar1.ItemsSource = TotalChars;
            ComboBoxSpecificChar2.ItemsSource = TotalChars;
            ComboBoxSpecificChar3.ItemsSource = TotalChars;
            ComboBoxSpecificChar4.ItemsSource = TotalChars;
            ComboBoxSpecificChar5.ItemsSource = TotalChars;
            ComboBoxSpecificChar6.ItemsSource = TotalChars;

            ComboBoxSpecificChar1.SelectedIndex = 0;
            ComboBoxSpecificChar2.SelectedIndex = 0;
            ComboBoxSpecificChar3.SelectedIndex = 0;
            ComboBoxSpecificChar4.SelectedIndex = 0;
            ComboBoxSpecificChar5.SelectedIndex = 0;
            ComboBoxSpecificChar6.SelectedIndex = 0;
            
            ComboBoxExistChar1.ItemsSource = TotalChars;
            ComboBoxExistChar2.ItemsSource = TotalChars;
            ComboBoxExistChar3.ItemsSource = TotalChars;
            ComboBoxExistChar4.ItemsSource = TotalChars;
            ComboBoxExistChar5.ItemsSource = TotalChars;
            ComboBoxExistChar6.ItemsSource = TotalChars;

            ComboBoxExistChar1.SelectedIndex = 0;
            ComboBoxExistChar2.SelectedIndex = 0;
            ComboBoxExistChar3.SelectedIndex = 0;
            ComboBoxExistChar4.SelectedIndex = 0;
            ComboBoxExistChar5.SelectedIndex = 0;
            ComboBoxExistChar6.SelectedIndex = 0;
        }

        private void ButtonFindAnswer_OnClick(object sender, RoutedEventArgs e)
        {
            var specificWords = new[]
            {
                TotalChars[ComboBoxSpecificChar1.SelectedIndex],
                TotalChars[ComboBoxSpecificChar2.SelectedIndex],
                TotalChars[ComboBoxSpecificChar3.SelectedIndex],
                TotalChars[ComboBoxSpecificChar4.SelectedIndex],
                TotalChars[ComboBoxSpecificChar5.SelectedIndex],
                TotalChars[ComboBoxSpecificChar6.SelectedIndex]
            };
            var existWords = new List<char>();
            if (ComboBoxExistChar1.SelectedIndex != 0)
                existWords.Add(TotalChars[ComboBoxExistChar1.SelectedIndex]);
            if (ComboBoxExistChar2.SelectedIndex != 0)
                existWords.Add(TotalChars[ComboBoxExistChar2.SelectedIndex]);
            if (ComboBoxExistChar3.SelectedIndex != 0)
                existWords.Add(TotalChars[ComboBoxExistChar3.SelectedIndex]);
            if (ComboBoxExistChar4.SelectedIndex != 0)
                existWords.Add(TotalChars[ComboBoxExistChar4.SelectedIndex]);
            if (ComboBoxExistChar5.SelectedIndex != 0)
                existWords.Add(TotalChars[ComboBoxExistChar5.SelectedIndex]);
            if (ComboBoxExistChar6.SelectedIndex != 0)
                existWords.Add(TotalChars[ComboBoxExistChar6.SelectedIndex]);

            var foundWords = WordLoader.GetMatchingWords(specificWords, existWords.ToArray());
            ListBoxResult.ItemsSource = foundWords;
        }
    }
}