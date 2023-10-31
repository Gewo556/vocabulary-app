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
using System.Windows.Shapes;
using MyLanguage = Vocabulary_app.Data.Const.Language;
using Vocabulary_app.Data.Model;
using System.Threading;

namespace Vocabulary_app
{
    /// <summary>
    /// Logika interakcji dla klasy MainApp.xaml
    /// </summary>
    public partial class MainApp : Window
    {
        private MyLanguage language;
        private static string vocabularyPath = @"..\..\..\..\..\Vocabulary\slowa.txt";
        private List<WordPair> wordPairs;
        private string actualWords;
        private int rounds;
        private int points;

        public MainApp() : this(MyLanguage.Polish) { }
        public MainApp(MyLanguage language)
        {
            InitializeComponent();
            this.language = language;
            wordPairs = GetWordPairs(vocabularyPath);
        }

        private List<WordPair> GetWordPairs(string path)
        {
            List<WordPair> wordList = new List<WordPair>();

            try
            {
                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        string? line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] columns = line.Split(',');

                            if (columns.Length == 2)
                            {
                                wordList.Add(new WordPair(columns[0], columns[1]));
                            }
                        }
                    }
                }
                else
                {
                    var logText = "Plik nie istnieje.";

                    LogService.AddToLogs(logText);
                }
            }
            catch (Exception ex)
            {
                var logText = $"Błąd odczytu pliku: {ex.Message}";

                LogService.AddToLogs(logText);
            }

            return wordList;
        }


        private void RandomizeRoundWords()
        {
            if (wordPairs.Count > 0)
            {
                rounds++;
                Random random = new Random();

                int index = random.Next(0, wordPairs.Count);
                WordPair word = wordPairs[index];

                if (language == MyLanguage.Polish)
                {
                    txtWord.Text = word.PolishWord;
                    actualWords = word.EnglishWord;
                }
                else
                {
                    txtWord.Text = word.EnglishWord;
                    actualWords = word.PolishWord;
                }
            }
            else
            {
                EndScreen endScreen = new EndScreen(points, rounds);
                endScreen.ShowDialog();
                this.Close();
            }
        }

        private void CheckTranslate()
        {
            if (txtbUserTranslation.Text == actualWords)
            {
                txtSuccess.Visibility = Visibility.Visible;
                points++;
                var correctWord = wordPairs.First(x => x.PolishWord == actualWords || x.EnglishWord == actualWords);

                wordPairs.Remove(correctWord);

            }
            else
            {
                txtFail.Visibility = Visibility.Visible;
                txtCorrectWord.Text = "Poprawne słowo to: " + actualWords;
                txtCorrectWord.Visibility = Visibility.Visible;
            }
        }

        private void ResetInterface()
        {

            txtFail.Visibility = Visibility.Hidden;
            txtSuccess.Visibility = Visibility.Hidden;
            txtCorrectWord.Visibility = Visibility.Hidden;
            txtbUserTranslation.Text = "";
            RandomizeRoundWords();
        }


        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            btnStart.Visibility = Visibility.Hidden;
            txtWord.Visibility = Visibility.Visible;
            txtEqual.Visibility = Visibility.Visible;
            txtTranslate.Visibility = Visibility.Visible;
            txtbUserTranslation.Visibility = Visibility.Visible;
            rounds = 0;
            points = 0;
            RandomizeRoundWords();
        }

        private void txtbUserTranslation_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter && txtFail.Visibility != Visibility.Visible && txtSuccess.Visibility != Visibility.Visible)
            {
                CheckTranslate();
            }
            else if (e.Key == Key.Space)
            {
                ResetInterface();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void txtbUserTranslation_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                txtbUserTranslation.Text = txtbUserTranslation.Text.TrimStart();
            }
        }
    }
}
