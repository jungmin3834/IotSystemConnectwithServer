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
using _20181107마지막_시험_클라.ServiceReference1;
using System.ServiceModel;
namespace _20181107마지막_시험_클라
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window, IAiServiceCallback
    {
        AiServiceClient aiclient;
        AiController aicontrol;

        public MainWindow()
        {
            try
            {
          
                InitializeComponent();
                aicontrol = new AiController(this);
                InstanceContext site = new InstanceContext(this);
               
                aiclient = new AiServiceClient(site);
                
                aiclient.Join(true, "Ai", 0);
               
                foreach (Data data in aiclient.GetDataList())
                {
                    List.Items.Add("명령어 : " + data.Msg);
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show("에러 : "+ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tb_main.Text.Equals("") == true)
                return;
           lb_main.Content = tb_main.Text;
           aiclient.SendMessage(tb_main.Text);
           tb_main.Text = "";
        }



        public bool CTv_On(bool power)
        {
            return true;
        }

        public bool CTv_Off(bool power)
        {
            return true;
        }

        public bool CLight_On(bool power)
        {
            return true;
        }

        public bool CLight_Off(bool power)
        {
            return true;
        }

        public bool CTv_ChannelUp(int chenl)
        {
            return true;
        }

        public bool CLight_ChannelUp(int chenl)
        {
            return true;
        }

        public bool CAiSet(string msg, string target, string type)
        {
            List.Items.Add("명령어 : " + msg);
            return false;
        }

    }
}
