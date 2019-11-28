using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using WPF_전등.ServiceReference1;

namespace WPF_전등
{
    class LightController:IAiServiceCallback
    {

        MainWindow mainwindow;
        AiServiceClient aiclient;
        int channel = 1;
        bool Pow = false;
   
        public LightController(MainWindow main)
        {
            mainwindow = main;
            InstanceContext site = new InstanceContext(this);
            aiclient = new AiServiceClient(site);
            aiclient.Join(true, "LIGHT", 0);
        }

        private void Power_Click(bool pw)
        {
            Pow = !Pow;

            if (Pow == true)
            {
                channel = 1;
                mainwindow.canvas1.Background = new SolidColorBrush(Colors.Blue);
            }
            else if (Pow == false)
            {
                for (int i = 1; i < 6; i++)
                {
                    Canvas canvas = (Canvas)mainwindow.FindName("canvas" + i);
                    canvas.Background = new SolidColorBrush(Colors.White);
                }
            }
        }


        private void Light_Change()
        {
            if (Pow == false)
            {
                channel = 1;
                return;
            }

            if (++channel % 7 == 0)
            {
                channel = 1;
                for (int i = 1; i < 6; i++)
                {
                    Canvas canvas = (Canvas)mainwindow.FindName("canvas" + i.ToString());
                    canvas.Background = new SolidColorBrush(Colors.White);
                }
                return;
            }
            for (int i = 1; i < channel; i++)
            {
                Canvas canvas = (Canvas)mainwindow.FindName("canvas" + i.ToString());
                canvas.Background = new SolidColorBrush(Colors.Blue);
            }


        }


        #region
        public bool CLight_On(bool power)
        {
            Pow = !Pow;

            if (Pow == true)
            {
                channel = 1;
                mainwindow.canvas1.Background = new SolidColorBrush(Colors.Blue);
            }
            else if (Pow == false)
            {
                for (int i = 1; i < 6; i++)
                {
                    Canvas canvas = (Canvas)mainwindow.FindName("canvas" + i);
                    canvas.Background = new SolidColorBrush(Colors.White);
                }
            }

            return true;
        }
        public bool CLight_ChannelUp(int chenl)
        {
            Light_Change();
            return true;
        }
        #region 안쓰는거
        public bool CTv_On(bool power)
        {
            return true;
        }

        public bool CTv_ChannelUp(int chenl)
        {
            return true;
        }

 
        public bool CAiSet(string msg, string target, string type)
        {
            return true;
        }
        #endregion
#endregion
    }
}
