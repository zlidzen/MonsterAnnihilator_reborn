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
    /// Interaction logic for hMakeWND.xaml
    /// </summary>
    public partial class hMakeWND : Window
    {
        public hMakeWND()
        {
            InitializeComponent();
            specialization.SelectedIndex = 0;
        }

        private void Make_Click(object sender, RoutedEventArgs e)
        {
            if (makeName.Text.CompareTo("") == 0)
            {
                MessageBox.Show("Please, enter name...");
                return;
            }

            if (makePass.Password.CompareTo("") == 0)
            {
                MessageBox.Show("Please, enter password...");
                return;
            }
            try
            {
                if (Game.makeNewPersonage(specialization.SelectedIndex, makeName.Text, makePass.Password))
                {
                    MessageBox.Show("New Hero was created!");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
       
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string helth = "30";
            string power = "1";
            string resist = "1";
            string heroImg = "Guardian.png";
            string attack = "5";
            string defence = "6";

            if (specialization.SelectedIndex == 0)
            {
                helth = "25";
                power = "2";
                resist = "0";
                attack = "6";
                defence = "5";
                heroImg = "Berserker.png"; 
            }

            hHelth.Content = "Helth: " + helth;
            hPower.Content = "Power: " + power;
            hResist.Content = "Resist: " + resist;
            hAttack.Content = "Attack: 1d" + attack;
            hDefence.Content="Defence: 1d" + defence;
            imgHero.Source = new BitmapImage(new Uri("Resources/" + heroImg, UriKind.Relative));
        }           
    }
}
