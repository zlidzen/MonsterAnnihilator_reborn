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
            Game.readHeroList();  
      
            // will change in future
            hFrame.Visibility = Visibility.Hidden;
            mFrame.Visibility = Visibility.Hidden;
            dAction.Visibility = Visibility.Hidden;
        }

        private void MenuHeroLoad_Click(object sender, RoutedEventArgs e)
        {
            if (Game.Heroes.Count <= 0)
            {
                MessageBox.Show("You do not have any Heroes.");
                return;
            }

            hLoadWND hlwnd = new hLoadWND();
            hlwnd.Owner = this;

            if (hlwnd.ShowDialog().Value || (Game.Personage == null))
            {
                hFrame.updateData(Game.Personage);
            }
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

        // test add control to grid
        private void addCntrl(object sender, RoutedEventArgs e)
        {
            /* ucAbility t = new ucAbility();
             Grid.SetColumn(t, 2);
             Grid.SetRow(t, 2);
             mainGrid.Children.Add(t);            */

            mFrame.Visibility = hFrame.IsEnabled ? Visibility.Hidden : Visibility.Visible;
            hFrame.IsEnabled = !hFrame.IsEnabled;

            int action = 2;
            string strAction = "Attack";

            if (dAction.iState == 2) {
                action = 1;
                strAction = "Prottect";
            }
                
            dAction.iState = action;
            dAction.strTitle = strAction;
        }

        private void MenuGameStart_Click(object sender, RoutedEventArgs e)
        {
            if (Game.Personage == null)
            {
                MessageBox.Show("Please make or load Hero before start game.");
                return;
            }

            if (Game.Monster == null)
            {
                MessageBox.Show("Please load any Monster before start game.");
                return;
            }

            try
            {
                Game.setStart();
            }
            catch (NotImplementedException notImp)
            {
                Console.WriteLine(notImp.Message);
            }            
        }

        private void CheckBox_Checked_Unchecked(object sender, RoutedEventArgs e)
        {
            Visibility param = chbxShowComponents.IsChecked.Value ? Visibility.Visible : Visibility.Hidden;
            hFrame.Visibility = param;
            mFrame.Visibility = param;
            dAction.Visibility = param;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            hFrame.updateData(null);
        }
    }
}