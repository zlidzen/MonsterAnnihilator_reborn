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
            RefreshForm();
        }

        void RefreshForm()
        {  
            foreach (var item in Game.Heroes)
            {
                loadName.Items.Add(item.name);
                pass.Add(item.Pass);
            }

            loadPass.Clear();
            loadName.SelectedIndex = -1;
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
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Password is wrong.");
            }            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (loadName.Text.CompareTo("") == 0)
            {
                MessageBox.Show("Please, enter name...");
                return;
            }

            if (loadPass.Password.CompareTo(pass[loadName.SelectedIndex]) == 0)
            {
                if ((Game.Personage.name.CompareTo(Game.Heroes[loadName.SelectedIndex].name) == 0) &&
                    (Game.Personage.Pass.CompareTo(pass[loadName.SelectedIndex]) == 0))
                {
                    Game.Personage = null;                    
                }
                Game.Heroes.RemoveAt(loadName.SelectedIndex);
                pass.RemoveAt(loadName.SelectedIndex);
                Game.writeHeroList();
                RefreshForm();
                MessageBox.Show("Personage was deleted.");
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
