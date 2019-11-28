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

namespace WPF_전등
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        LightController lightcontorl;
        int channel = 1;
        bool power = false;
        public MainWindow()
        {
            InitializeComponent();
            lightcontorl = new LightController(this);
        }

        private void Power_Click(object sender, RoutedEventArgs e)
        {
            power = !power;
            if (power == false)
            {
                for (int i = 1; i < 6; i++)
                {
                    Canvas canvas = (Canvas)this.FindName("canvas" + i);
                    canvas.Background = new SolidColorBrush(Colors.White);
                }
            }
            else
            {
                channel = 1;
                canvas1.Background = new SolidColorBrush(Colors.Blue);
            }
        }

        private void Level_Click(object sender, RoutedEventArgs e)
        {
            if (power == false)
            {
                channel = 1;
                return;
            }

            if (++channel % 7 == 0)
            {
                channel = 1;
                for (int i = 1; i < 6; i++)
                {
                    Canvas canvas = (Canvas)this.FindName("canvas" + i.ToString());
                    canvas.Background = new SolidColorBrush(Colors.White);
                }
                return;
            }
            for (int i = 1; i < channel; i++)
            {
                Canvas canvas = (Canvas)this.FindName("canvas" + i.ToString());
                canvas.Background = new SolidColorBrush(Colors.Blue);
            }


        }
    }
}
