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
using _1107Ai리모컨.ServiceReference1;
using System.ServiceModel;

namespace _1107Ai리모컨
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window,IAiServiceCallback
    {

        AiServiceClient aiclient;
        public MainWindow()
        {
            InitializeComponent();
            InstanceContext site = new InstanceContext(this);
            aiclient = new AiServiceClient(site);
            aiclient.Join(true, "Ai리모컨", 0);
               list.Items.Add("TV전원버튼");
              list.Items.Add("TV채널");
              list.Items.Add("전등전원버튼");
              list.Items.Add("전등단계");
 
        }

  
        private void Set_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool sort = false;
                string type = string.Empty;
                string msg;
                if (Rbtv.IsChecked == true)
                    sort = true;
                else
                    sort = false;
                type = Lblist.Content.ToString();
                if (type.Trim().Equals("") || TbName.Text.Trim().Equals(""))
                {
                    MessageBox.Show("리스트 선택 해주세요 혹은 문자열을 채워주세요");
                    return;
                }
                msg = TbName.Text;
                aiclient.AiSettingMessage(msg, sort == true ? "TV" : "LIGHT", type);
            }
            catch(Exception ex)
            {
                MessageBox.Show("[에러] "+ex.Message);
            }
            
        }

        #region 콜백 구현
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
            return true;
        }
        #endregion

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            Lblist.Content = list.Items[list.SelectedIndex].ToString(); 
      
            
        }
    }
}
