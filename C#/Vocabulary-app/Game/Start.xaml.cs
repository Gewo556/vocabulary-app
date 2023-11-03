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
using Vocabulary_app.Services;

namespace Vocabulary_app.Game
{
    /// <summary>
    /// Logika interakcji dla klasy Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        public Start(MyLanguage language)
        {
            InitializeComponent();
        }

        
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("Game.xaml", UriKind.Relative));
        }
    }
}
