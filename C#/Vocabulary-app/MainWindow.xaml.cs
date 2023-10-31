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
using MyLanguage = Vocabulary_app.Data.Const.Language;

namespace Vocabulary_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPolish_Click(object sender, RoutedEventArgs e)
        {
            MainApp mainApp = new MainApp(MyLanguage.Polish);
            this.Close();
            mainApp.Show();
        }

        private void btnEnglish_Click(object sender, RoutedEventArgs e)
        {
            MainApp mainApp = new MainApp(MyLanguage.English);
            this.Close();
            mainApp.Show();
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
