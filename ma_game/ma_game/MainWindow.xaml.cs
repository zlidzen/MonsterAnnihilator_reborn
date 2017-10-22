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
        static int backStep = 0;

        public StartWindow()
        {
            InitializeComponent();
            this.Title = Properties.Resources.MainTitle + Properties.Resources.StartTitle;
            List<Control> strtList = new List<Control>();
            strtList.Add(btnGame);
            strtList.Add(btnAbout);
            strtList.Add(btnHelp);
            strtList.Add(btnScores);
            strtList.Add(btnQuit);
            ShowControl(strtList);
            strtList.Clear();
            ShowPanel(wpStart);
            ShowPanel(wpLoadHero, false);
            ShowPanel(wpLoadHero, false);
            txbStart.Text = Properties.Resources.StartText;
        }

        private void BtnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnScores_Click(object sender, RoutedEventArgs e)
        {
            txbStart.Text = Properties.Resources.ScoresText;            
        }

        private void BtnGame_Click(object sender, RoutedEventArgs e)
        {
            btnQuit.IsEnabled = false;

            List<Control> strtList = new List<Control>();
            strtList.Add(btnGame);
            strtList.Add(btnAbout);
            strtList.Add(btnScores);
            ShowControl(strtList, false);            

            strtList.Clear();
            strtList.Add(btnNewGame);
            strtList.Add(btnLoadGame);
            strtList.Add(btnBack);
            ShowControl(strtList);
            strtList.Clear();
            txbStart.Text = Properties.Resources.GameText;            

            btnQuit.IsEnabled = true;
            Title = Properties.Resources.MainTitle + Properties.Resources.GameTitle;
        }

        private void BtnHelp_Click(object sender, RoutedEventArgs e)
        {
            txbStart.Text = Properties.Resources.HelpText;            
        }

        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
            txbStart.Text = Properties.Resources.AboutText;           
        }

        private static void ShowControl(List<Control> arrBtn, bool ok = true)
        {
            Double startA = ok ? 0.0 : 1.0;
            Double endA = ok ? 1.0 : 0.0;

            DoubleAnimation dblAnim = new DoubleAnimation();
            dblAnim.From = startA;
            dblAnim.To = endA;
            dblAnim.Duration = new Duration(TimeSpan.FromMilliseconds(500));

            foreach (Control item in arrBtn)
            {
                item.Visibility = ok ? Visibility.Visible : Visibility.Hidden;
                item.BeginAnimation(OpacityProperty, dblAnim);
            }
        }

        private static void ShowPanel(Panel pan, bool ok = true)
        {
            Double startA = ok ? 0.0 : 1.0;
            Double endA = ok ? 1.0 : 0.0;

            DoubleAnimation dblAnim = new DoubleAnimation();
            dblAnim.From = startA;
            dblAnim.To = endA;
            dblAnim.Duration = new Duration(TimeSpan.FromMilliseconds(300));

            pan.Visibility = ok ? Visibility.Visible : Visibility.Hidden;
            pan.IsEnabled = ok;
            pan.BeginAnimation(OpacityProperty, dblAnim);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            btnQuit.IsEnabled = false;

            List<Control> strtList = new List<Control>();

            switch (backStep)
            {
                case 0:
                    strtList.Add(btnNewGame);
                    strtList.Add(btnLoadGame);
                    strtList.Add(btnBack);
                    ShowControl(strtList, false);
                    txbStart.Text = Properties.Resources.StartText;

                    strtList.Clear();
                    strtList.Add(btnGame);
                    strtList.Add(btnAbout);
                    strtList.Add(btnScores);
                    ShowControl(strtList);
                    strtList.Clear();
                    break;
                case 1:
                    strtList.Add(btnMake);
                    ShowControl(strtList, false);
                    ShowPanel(wpNewHero, false);

                    strtList.Clear();
                    strtList.Add(btnNewGame);
                    strtList.Add(btnLoadGame);
                    ShowControl(strtList);
                    strtList.Clear();
                    ShowPanel(wpStart);
                    break;
                case 2:
                    strtList.Add(btnLoad);
                    ShowControl(strtList, false);
                    ShowPanel(wpLoadHero, false);

                    strtList.Clear();
                    strtList.Add(btnNewGame);
                    strtList.Add(btnLoadGame);
                    ShowControl(strtList);
                    strtList.Clear();
                    ShowPanel(wpStart);
                    break;
            }
            backStep = 0;
            lblTest.Content = backStep.ToString();

            btnQuit.IsEnabled = true;
            Title = Properties.Resources.MainTitle + Properties.Resources.StartTitle;
        }

        private void BtnNewGame_Click(object sender, RoutedEventArgs e)
        {
            btnQuit.IsEnabled = false;

            List<Control> strtList = new List<Control>();
            strtList.Add(btnNewGame);
            strtList.Add(btnLoadGame);
            ShowControl(strtList, false);
            ShowPanel(wpStart, false);

            strtList.Clear();
            strtList.Add(btnMake);
            ShowControl(strtList);
            ShowPanel(wpNewHero);

            btnQuit.IsEnabled = true;
            Title = Properties.Resources.MainTitle + Properties.Resources.MakeHeroTitle;

            backStep = 1;
            lblTest.Content = backStep.ToString();
        }

        private void btnLoadGame_Click(object sender, RoutedEventArgs e)
        {
            btnQuit.IsEnabled = false;

            List<Control> strtList = new List<Control>();
            strtList.Add(btnNewGame);
            strtList.Add(btnLoadGame);
            ShowControl(strtList, false);
            ShowPanel(wpStart, false);

            strtList.Clear();
            strtList.Add(btnLoad);
            ShowControl(strtList);
            ShowPanel(wpLoadHero);
            LoadHeroList();

            btnQuit.IsEnabled = true;
            Title = Properties.Resources.MainTitle + Properties.Resources.LoadHeroTitle;

            backStep = 2;
            lblTest.Content = backStep.ToString();
        }

        private void LoadHeroList()
        {
            String line;
            lbxListHero.Items.Clear();
            try
            {
                StreamReader sr = new StreamReader("SampleH.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    lbxListHero.Items.Add(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
            }
        }

        private void cbxSpec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            Human aH = Game.b;
            if (cbxSpec.SelectedIndex == Game.g.Sp) aH = Game.g;

            lblHeroLvl.Content = "Level: 1";
            lblHeroHelth.Content = "Health: " + aH.Helsh.ToString();
            lblHeroPower.Content = "Power: " + aH.Power.ToString();
            lblHeroResist.Content = "Resist: " + aH.Resist.ToString();
            lblHeroAttack.Content = "Attack: " + aH.attackDice.ToString();
            lblHeroDefence.Content = "Defence: " + aH.defenceDice.ToString();
        }
    }
}
