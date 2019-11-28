using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WbService
{
    #region 1. 계약인터페이스(클라이언트->서버)
   [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IAiServiceCallback))]
    public interface IAiService
    {

       [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
       bool AiSettingMessage(string msg,string target,string type);

        [OperationContract(IsOneWay = false, IsInitiating = true, IsTerminating = false)]
        bool Join(bool state, string name, int Channel);

        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = true)]
        void Leave(int stunumber);



       [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
       bool SendMessage(string msg);

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        List<Data> GetDataList();
       
     }
    #endregion

    #region 2. 콜백인터페이스(서버->클라이언트)
    public interface IAiServiceCallback
    {
        [OperationContract(IsOneWay = false)]
        bool CTv_On(bool power);
 
        [OperationContract(IsOneWay = false)]
        bool CLight_On(bool power);

        [OperationContract(IsOneWay = false)]
        bool CTv_ChannelUp(int chenl);

        [OperationContract(IsOneWay = false)]
        bool CLight_ChannelUp(int chenl);

        [OperationContract(IsOneWay = false)]
        bool CAiSet(string msg, string target, string type);
    }
    #endregion


    //Callback 1. 델리게이트 선언
    
    public delegate void DeviceDel(string msg, string name,string type);

    public delegate void AiMsgDel(string msg,string target,string type);

    public class MainService : IAiService
    {
        //Callback 2. 델리게이트 레퍼런스 2개 선언 =====
        // 개인용 델리게이트
        private DeviceData MyDeviceDel;
        //전체에게 보낼 정보를 담고 있는 델리게이트
        private static List<DeviceData> DeviceList
                            = new List<DeviceData>();
        //=========================================

         private AiMsgDel MyAiDel;

         private static AiMsgDel AiList;

        //=========================================
        //동기화 1 : 동기화 작업을 위해서 가상의 객체 생성

        private static Object syncObj = new Object();
        IAiServiceCallback callback = null;
              
        #region ICatService 구현 상속
        public bool Join(bool state, string name, int Channel)
        {
         
            lock (syncObj)
            {
                callback = OperationContext.Current.GetCallbackChannel<IAiServiceCallback>();


              if(name.Equals("Ai"))
              {
                  MyAiDel  = new AiMsgDel(AiHandlerManager);
                    AiList += MyAiDel;
                  return true;
              }
              else if(name.Equals("Nothing"))
                return false;

                MyDeviceDel = new DeviceData(new DeviceDel(AiHandler),state,name,Channel);
                DeviceList.Add(MyDeviceDel);

                Console.WriteLine("입장"+name);

              }
            return true;
        }

        public void Leave(int idx)
        {
            DeviceList.Remove(MyDeviceDel);
            callback = null;
        }


        #endregion



        #region Ai
        public List<Data> GetDataList()
        {
            return MemberProcess.Singleton.GetDataList();
        }
        public bool SendMessage(string msg)
        {
           Data data=  MemberProcess.Singleton.SendMessage(msg);
           if (data == null)
               return false;
           BroadcastMessage(msg, data.Target, data.Type);
           return true;
        }
        #endregion
        // 1대 다  구현.
        #region 브로드케스트 
        public void BroadcastMessage(string msg, string name,string type)
        {
            lock (syncObj)
            {           
                
                //현재 이벤트들을 전달한다.
                foreach (DeviceData cdata in DeviceList)
                {
                    if (cdata.Name.Equals(name))
                    {
                        cdata.UserDevice.BeginInvoke(msg, name, type, new AsyncCallback(EndAsync), null);
                    }
                    
                }             
            }
        }

        
      
        private void AiHandler(string msg, string name,string type)
        {
            try
            {
                switch (type)
                {
                    case "TV전원버튼":
                        callback.CTv_On(true);
                        break;
                    case "TV채널":
                        callback.CTv_ChannelUp(0);
                        break;
                    case "전등전원버튼":
                        callback.CLight_On(true);
                        break;
                    case "전등단계":
                        callback.CLight_ChannelUp(0);
                        break;
                }
            }
            catch
            {
                Leave(0);
            }

        }

        private void EndAsync(IAsyncResult ar)
        {
            DeviceDel d = null;
            try
            {
                System.Runtime.Remoting.Messaging.AsyncResult asres = (System.Runtime.Remoting.Messaging.AsyncResult)ar;
                d = ((DeviceDel)asres.AsyncDelegate);
                d.EndInvoke(ar);
            }
            catch
            {
                DeviceList.Remove(MyDeviceDel);
            }
        }
        #endregion

        #region Ai 컨트롤 브로드
        public void BroadcastMessageManger(string msg,string target,string type)
        {
            lock (syncObj)
            {

                //현재 이벤트들을 전달한다.
                foreach (AiMsgDel cdata in AiList.GetInvocationList())
                {

                    cdata.BeginInvoke(msg, target, type, new AsyncCallback(EndAsyncManager), null);
                    

                }
            }
        }



        private void AiHandlerManager(string msg,string target,string type)
        {
            try
            {
                callback.CAiSet(msg, target, type);
            }
            catch//에러가 발생했을 경우
            {
              //  Leave(chennl);
            }

        }

        private void EndAsyncManager(IAsyncResult ar)
        {
            AiMsgDel d = null;
            try
            {
                System.Runtime.Remoting.Messaging.AsyncResult asres = (System.Runtime.Remoting.Messaging.AsyncResult)ar;
                d = ((AiMsgDel)asres.AsyncDelegate);
                d.EndInvoke(ar);
            }
            catch
            {
                DeviceList.Remove(MyDeviceDel);
            }
        }




        public bool AiSettingMessage(string msg, string target, string type)
        {

           if(MemberProcess.Singleton.AiSettingMessage(msg, target, type))
                BroadcastMessageManger(msg, target, type);
            return true;
        }

        #endregion


   
    }
}

