using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ma_game
{
    /// <summary>
    /// Interaction logic for hLoadWND.xaml
    /// </summary>
    public partial class hLoadWND : Window
    {
        List<string> pass = new List<string> ();
        public hLoadWND()
        {
            InitializeComponent();

            Game.readHeroList();
            if (Game.Heroes.Count <= 0)
            {
                MessageBox.Show("You do not have any Heroes.");
                return;
            }
            else
            {
                foreach (var item in Game.Heroes)
                {
                    loadName.Items.Add(item.name);
                    pass.Add(item.Pass);
                }
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            if (loadName.Text.CompareTo("") == 0)
            {
                MessageBox.Show("Please, enter name...");
                return;
            }
           
            if (loadPass.Password.CompareTo(pass[loadName.SelectedIndex]) == 0)
            {
                Game.Personage = Game.Heroes[loadName.SelectedIndex];
                MessageBox.Show("Personage was loaded.");
                Close();
            }
            else
            {
                MessageBox.Show("Password is wrong.");
            }            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
