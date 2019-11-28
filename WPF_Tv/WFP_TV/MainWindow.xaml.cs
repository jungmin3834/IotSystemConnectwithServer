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

namespace WFP_TV
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {


        TvController tvcontroll;

         int channel  =1;
        public bool power=false;
        public MainWindow()
        {
            InitializeComponent();
            tvcontroll  = new TvController(this);
        }
   
        
        private void TV_Click(object sender, RoutedEventArgs e)
        {
            power = !power;
            if (power == false)
            {
                canvas.Background = new SolidColorBrush(Colors.Gray);
                tb_tv.Text = "";
            }
            else
            {
                canvas.Background = new SolidColorBrush(Colors.Violet);
                tb_tv.Text = channel.ToString();
            }
            
        }

        private Color GetChannel(int i)
        {
            switch(i)
            {
                case 1: return Colors.Tomato;
                case 2: return Colors.SpringGreen; 
                case 3: return Colors.SlateBlue; 
                case 4: return Colors.Gold; 
                case 5: return Colors.YellowGreen; 
                case 6: return Colors.MediumOrchid; 
                case 7: return Colors.Olive; 
                case 8: return Colors.LightGreen; 
                case 9: return Colors.Coral;
                default: return Colors.Gray;
            }
        }

        private void Channel_Click_1(object sender, RoutedEventArgs e)
        {
            if (power == false)
            {
                channel = 1;
                return;
            }
            if (++channel % 10 == 0)
                channel = 1;
            tb_tv.Text = channel.ToString();
            canvas.Background = new SolidColorBrush(GetChannel(channel));

        }
    }
}
