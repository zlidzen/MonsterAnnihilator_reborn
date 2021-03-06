﻿using System;
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
            ShowPanel(wpStart);
        }

        private void BtnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnScores_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Scores!", Properties.Resources.MainTitle + Properties.Resources.ScoresTitle);
        }

        private void BtnGame_Click(object sender, RoutedEventArgs e)
        {
            btnQuit.IsEnabled = false;

            List<Control> strtList = new List<Control>();
            strtList.Add(btnGame);
            strtList.Add(btnAbout);
            strtList.Add(btnScores);
            ShowControl(strtList, false);
            ShowPanel(wpStart, false);

            strtList.Clear();
            strtList.Add(btnNewGame);
            strtList.Add(btnLoadGame);
            strtList.Add(btnBack);
            ShowControl(strtList);
            ShowPanel(wpGame);

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
            dblAnim.Duration = new Duration(TimeSpan.FromMilliseconds(500));

            pan.Visibility = ok ? Visibility.Visible : Visibility.Hidden;
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
                    ShowPanel(wpGame, false);

                    strtList.Clear();
                    strtList.Add(btnGame);
                    strtList.Add(btnAbout);
                    strtList.Add(btnScores);
                    ShowControl(strtList);
                    ShowPanel(wpStart);
                    break;

                case 1:
                    strtList.Add(btnMake);
                    ShowControl(strtList, false);
                    ShowPanel(wpNewHero, false);

                    strtList.Clear();
                    strtList.Add(btnNewGame);
                    strtList.Add(btnLoadGame);
                    ShowControl(strtList);
                    ShowPanel(wpGame);
                    break;
                case 2:
                    strtList.Add(btnLoad);
                    ShowControl(strtList, false);

                    strtList.Clear();
                    strtList.Add(btnNewGame);
                    strtList.Add(btnLoadGame);
                    ShowControl(strtList);
                    ShowPanel(wpGame);
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
            ShowPanel(wpGame, false);

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

            strtList.Clear();
            strtList.Add(btnLoad);
            ShowControl(strtList);

            btnQuit.IsEnabled = true;
            Title = Properties.Resources.MainTitle + Properties.Resources.LoadHeroTitle;

            backStep = 2;
            lblTest.Content = backStep.ToString();
        }



    }
}
