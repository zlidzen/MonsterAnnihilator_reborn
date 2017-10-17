using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ma_srart
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
            ShowBtns(strtList);
        }

        private void BtnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnScores_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Scores!",Properties.Resources.MainTitle + Properties.Resources.ScoresTitle);
        }

        private void BtnGame_Click(object sender, RoutedEventArgs e)
        {
            btnQuit.IsEnabled = false;            

            List<Control> strtList = new List<Control>();
            strtList.Add(btnGame);
            strtList.Add(btnAbout);            
            strtList.Add(btnScores);           
            ShowBtns(strtList, false);

            strtList.Clear();
            strtList.Add(btnNewGame);
            strtList.Add(btnLoadGame);
            strtList.Add(btnBack);
            ShowBtns(strtList);

            btnQuit.IsEnabled = true;
            Title = Properties.Resources.MainTitle + Properties.Resources.GameTitle;
        }

        private void BtnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Help!", Properties.Resources.MainTitle + Properties.Resources.HelpTitle);
        }

        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("About!", Properties.Resources.MainTitle + Properties.Resources.AboutTitle);
        }

        private static void ShowBtns(List<Control> arrBtn, bool ok = true) {
            Double startA = ok ? 0.0 : 1.0;
            Double endA = ok ? 1.0 : 0.0;
           
            DoubleAnimation dblAnim = new DoubleAnimation();
            dblAnim.From = startA;
            dblAnim.To = endA;
            dblAnim.Duration = new Duration(TimeSpan.FromMilliseconds(500));

            foreach (Button item in arrBtn)
            {
                item.Visibility = ok ? Visibility.Visible : Visibility.Hidden;
                item.BeginAnimation(OpacityProperty, dblAnim);                
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            btnQuit.IsEnabled = false;

            List<Control> strtList = new List<Control>();

            switch (backStep) {
                case 0:
                    strtList.Add(btnNewGame);
                    strtList.Add(btnLoadGame);
                    strtList.Add(btnBack);
                    ShowBtns(strtList);

                    strtList.Clear();
                    strtList.Add(btnGame);
                    strtList.Add(btnAbout);
                    strtList.Add(btnScores);
                    ShowBtns(strtList, true);
                    break;

                case 1:
                    strtList.Add(btnMake);
                    ShowBtns(strtList, false);

                    strtList.Clear();
                    strtList.Add(btnNewGame);
                    strtList.Add(btnLoadGame);                    
                    ShowBtns(strtList);
                    break;
                case 2:
                    strtList.Add(btnLoad);
                    ShowBtns(strtList, false);

                    strtList.Clear();
                    strtList.Add(btnNewGame);
                    strtList.Add(btnLoadGame);                    
                    ShowBtns(strtList);
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
            ShowBtns(strtList, false);

            strtList.Clear();
            strtList.Add(btnMake);
            strtList.Add(heroName);
            /* need pannel!!!!
            strtList.Add(tbxPassword);
            strtList.Add(lblHeroSpec);
            strtList.Add(cbxHeroSpec);
                        
            strtList.Add(lblHeroLvl);
            strtList.Add(lblHeroHealth);
            strtList.Add(lblHeroPower);
            strtList.Add(lblHeroResist);
            strtList.Add(lblHeroAttack);
            strtList.Add(lblHeroDefence);
            strtList.Add(lblHeroExperience);
            */
            ShowBtns(strtList);

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
            ShowBtns(strtList, false);

            strtList.Clear();
            strtList.Add(btnLoad);
            ShowBtns(strtList);

            btnQuit.IsEnabled = true;
            Title = Properties.Resources.MainTitle + Properties.Resources.LoadHeroTitle;

            backStep = 2;
            lblTest.Content = backStep.ToString();
        }
    }
}
