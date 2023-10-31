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
using System.Windows.Shapes;

namespace Vocabulary_app
{
    /// <summary>
    /// Logika interakcji dla klasy EndScreen.xaml
    /// </summary>
    public partial class EndScreen : Window
    {
        public EndScreen(int points, int rounds)
        {
            InitializeComponent();
            CountRating(points, rounds);
        }

        private void CountRating(int points, int rounds)
        {
            var rating = Math.Pow((points / (double)rounds), 1.5) * 100;
            string mark;

            if (rating >= 95)
            {
                mark = "6";
            }
            else if (rating >= 90)
            {
                mark = "6-";
            }
            else if (rating >= 85)
            {
                mark = "5+";
            }
            else if (rating >= 80)
            {
                mark = "5";
            }
            else if (rating >= 75)
            {
                mark = "5-";
            }
            else if (rating >= 70)
            {
                mark = "4+";
            }
            else if (rating >= 65)
            {
                mark = "4";
            }
            else if (rating >= 60)
            {
                mark = "4-";
            }
            else if (rating >= 55)
            {
                mark = "3+";
            }
            else if (rating >= 50)
            {
                mark = "3";
            }
            else if (rating >= 45)
            {
                mark = "3-";
            }
            else if (rating >= 40)
            {
                mark = "2+";
            }
            else if (rating >= 35)
            {
                mark = "2";
            }
            else if (rating >= 30)
            {
                mark = "2-";
            }
            else if (rating >= 25)
            {
                mark = "1+";
            }
            else
            {
                mark = "1";
            }

            DisplayEndingText(points, rounds, mark);
        }

        private void DisplayEndingText(int points, int rounds, string mark)
        {
            txtSummary.Text = $"Wszystkie słowa zostały przetłumaczone.\nZdobyłeś {points} punktów w {rounds} próbach,\na to daje ocenę {mark}.";
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
