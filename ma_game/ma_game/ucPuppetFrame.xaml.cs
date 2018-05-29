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
using ma_krnl;

namespace ma_game
{
    /// <summary>
    /// Interaction logic for ucPuppetFrame.xaml
    /// </summary>
    public partial class ucPuppetFrame : UserControl
    {
        public ucPuppetFrame()
        {
            InitializeComponent();           
        }

        void Refresh()
        {
            pupName.Content = "Name: 12345678901234567890";
            pupSpec.Content = "Spec: Maker";
            pupLevel.Content = "Level: 100";
            pupHelth.Content = "Helth: 100";
            pupPower.Content = "Power: 100";
            pupResist.Content = "Resist: 100";
            pupAttack.Content = "Attack: 1d99";
            pupDefence.Content = "Defence: 1d99";
        }

        public string strScreen
        {
            set
            {
                ImageBrush myBrush = new ImageBrush();
                myBrush.ImageSource = new BitmapImage(new Uri(@value, UriKind.Relative));
                picPuppet.Background = myBrush;
            }
        }

        public void updateData(Human objData)
        {
            if (objData == null)
            {
                this.Visibility = Visibility.Hidden;
                Refresh();
                return;
            }

            this.Visibility = Visibility.Visible;
            pupName.Content = "Name: " + objData.name;
            pupSpec.Content = "Spec.: " + ((objData.Sp == 0) ? "Berserker" : "Guardian");
            pupLevel.Content = "Level: " + objData.Lvl.ToString();
            pupHelth.Content = "Helth: " + objData.Helsh.ToString();
            pupPower.Content = "Power: " + objData.Power.ToString();
            pupResist.Content = "Resist: " + objData.Resist.ToString();
            pupAttack.Content = "Attack: " + objData.attackDice.ToString();
            pupDefence.Content = "Defence: " + objData.defenceDice.ToString();
        }
    }
}
