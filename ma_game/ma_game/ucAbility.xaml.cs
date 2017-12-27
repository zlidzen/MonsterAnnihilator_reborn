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
    /// Interaction logic for ucAbility.xaml
    /// </summary>
    public partial class ucAbility : UserControl
    {
        public ucAbility()
        {
            InitializeComponent();
        }

        public string strScreen
        {
            set
            {
                ImageBrush myBrush = new ImageBrush();
                myBrush.ImageSource = new BitmapImage(new Uri(@value, UriKind.Relative));
                picAbility.Background = myBrush;
            }
        }
    }
}
