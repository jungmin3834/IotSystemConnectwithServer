using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WFP_TV.ServiceReference1;

namespace WFP_TV
{
    class TvController : IAiServiceCallback
    {

        MainWindow mainwindow;
        AiServiceClient aiclient;
        public TvController(MainWindow main)
        {
            mainwindow = main;
        
            InstanceContext site = new InstanceContext(this);
            aiclient = new AiServiceClient(site);
            aiclient.Join(true, "TV", 0);
        }

         int channel  =1;
         bool Pow = false;
        public Color GetChannel(int i)
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

        public void Channel_Change()
        {



            if (Pow == false)
            {
                channel = 1;
                return;
            }

            if (++channel % 10 == 0)
                channel = 1;
            mainwindow.tb_tv.Text = channel.ToString();
            mainwindow.canvas.Background = new SolidColorBrush(GetChannel(channel));

        }

        #region 콜백
        public bool CTv_On(bool power)
        {
            Pow = !Pow;

            if (Pow == true)
            {
                mainwindow.canvas.Background = new SolidColorBrush(Colors.Violet);
                mainwindow.tb_tv.Text = channel.ToString();
            }
            else if (Pow == false)
            {
                mainwindow.canvas.Background = new SolidColorBrush(Colors.Gray);
                mainwindow.tb_tv.Text = "";
            }
            return true;
        }

        public bool CTv_ChannelUp(int chenl)
        {
            Channel_Change();
            return true;
        }

        public bool CLight_ChannelUp(int chenl)
        {
            return true;
        }
        public bool CLight_On(bool power)
        {
            return true;
        }

        public bool CAiSet(string msg, string target, string type)
        {
            return true;
        }

        #endregion
    }
}
