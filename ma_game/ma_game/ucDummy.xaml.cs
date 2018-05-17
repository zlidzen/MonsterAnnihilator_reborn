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

namespace ma_game
{
    /// <summary>
    /// Interaction logic for ucDummy.xaml
    /// </summary>
    public partial class ucDummy : UserControl
    {
        protected int istate;
        protected int[] point = { 0, 0 };

        public ucDummy()
        {
            InitializeComponent();
        }

        public string strTitle
        {
            set { lblAction.Content = value; }
            get { return lblAction.Content.ToString(); }
        }

        int iArms
        {
            set
            {
                string sImgL = "arm_l2.png";
                string sImgR = "arm_r2.png";

                switch (value)
                {
                    case 1: sImgL = "arm_l2b.png"; sImgR = "arm_r2b.png"; break;
                    case 2: sImgL = "arm_l2r.png"; sImgR = "arm_r2r.png"; break;
                }


                imgArmL.Source = new BitmapImage(new Uri("Resources/" + sImgL, UriKind.Relative));
                imgArmR.Source = new BitmapImage(new Uri("Resources/" + sImgR, UriKind.Relative));
            }
        }

        int iLegs
        {
            set
            {
                string sImgL = "l_leg_2.png";
                string sImgR = "r_leg_2.png";

                switch (value)
                {
                    case 1: sImgL = "l_leg_2b.png"; sImgR = "r_leg_2b.png"; break;
                    case 2: sImgL = "l_leg_2r.png"; sImgR = "r_leg_2r.png"; break;
                }
                imgLegL.Source = new BitmapImage(new Uri("Resources/" + sImgL, UriKind.Relative));
                imgLegR.Source = new BitmapImage(new Uri("Resources/" + sImgR, UriKind.Relative));
            }
        }

        int iHead
        {
            set
            {
                string sImg = "Head_2.png";

                switch (value)
                {
                    case 1: sImg = "Head_2b.png"; break;
                    case 2: sImg = "Head_2r.png"; break;
                }             
                    
                imgHead.Source = new BitmapImage(new Uri("Resources/" + sImg, UriKind.Relative));                
            }
        }

        int iBoby
        {
            set
            {
                string sImg = "body_2.png";

                switch (value)
                {
                    case 1: sImg = "body_2b.png"; break;
                    case 2: sImg = "body_2r.png"; break;
                }

                imgBody.Source = new BitmapImage(new Uri("Resources/" + sImg, UriKind.Relative));
              
            }
        }

        int iTr
        {
            set
            {
                string sImg = "tr_2.png";

                switch (value)
                {
                    case 1: sImg = "tr_2b.png"; break;
                    case 2: sImg = "tr_2r.png"; break;
                }
                imgTr.Source = new BitmapImage(new Uri("Resources/" + sImg, UriKind.Relative));
            }
        }

        public int iState
        {
            set
            {
                if (value == 1 || value == 2) istate = value;
                else istate = 0;
            }
            get { return istate; }
        }

        private void imgHead_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {            
            chekPointMK(iState, 1);
        }

        private void imgArmL_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            chekPointMK(iState, 2);
        }

        private void imgBody_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            chekPointMK(iState, 3);
        }

        private void imgTr_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            chekPointMK(iState, 4);
        }

        private void imgLegL_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            chekPointMK(iState, 5);
        }

        // выбор точек атаки и защиты
        private void chekPointMK(int st, int pImg)
        {
            if (st == 2) // attack
                point[0] = pImg;

            if (st == 1) // protect
            {
                if (point[1] != pImg)
                    if (point[1] != 0) point[0] = point[1];
                point[1] = pImg;
            }

            paintPointMK(st, point);
        }// выбор точек атаки и защиты

        // раскраска точек атаки и защиты
        private void paintPointMK(int st, int[] p)
        {
            iHead = 0;
            iArms = 0;
            iBoby = 0;
            iTr = 0;
            iLegs = 0;

            if (st == 2) // attack
            {
                switch (p[0])
                {
                    case 1: iHead = st; break;
                    case 2: iArms = st; break;
                    case 3: iBoby = st; break;
                    case 4: iTr = st; break;
                    case 5: iLegs = st; break;
                }
            }

            if (st == 1) // protect
            {
                switch (p[0])
                {
                    case 1: iHead = st; break;
                    case 2: iArms = st; break;
                    case 3: iBoby = st; break;
                    case 4: iTr = st; break;
                    case 5: iLegs = st; break;
                }

                switch (p[1])
                {
                    case 1: iHead = st; break;
                    case 2: iArms = st; break;
                    case 3: iBoby = st; break;
                    case 4: iTr = st; break;
                    case 5: iLegs = st; break;
                }
            }
        } // раскраска точек атаки и защиты        
    }
}
