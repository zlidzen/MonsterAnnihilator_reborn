using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ma_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();           
        }

        private void MenuHeroLoad_Click(object sender, RoutedEventArgs e)
        {
            hLoadWND hlwnd = new hLoadWND();
            hlwnd.Owner = this;
            hlwnd.ShowDialog();
        }

        private void MenuHeroMake_Click(object sender, RoutedEventArgs e)
        {
            hMakeWND hmwnd = new hMakeWND();
            hmwnd.Owner = this;
            hmwnd.ShowDialog();
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
