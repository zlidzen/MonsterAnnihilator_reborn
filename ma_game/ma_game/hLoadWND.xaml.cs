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

namespace ma_game
{
    /// <summary>
    /// Interaction logic for hLoadWND.xaml
    /// </summary>
    public partial class hLoadWND : Window
    {
        public hLoadWND()
        {
            InitializeComponent();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            if (loadName.Text.CompareTo("") == 0)
            {
                MessageBox.Show("Please, enter name...");
            }

            if (loadPass.Password.CompareTo("") == 0)
            {
                MessageBox.Show("Please, enter password...");
            }
            MessageBox.Show("Loading...");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
