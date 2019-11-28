using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbService
{
    /// <summary>
    /// 회원관리기능
    /// </summary>
    public class MemberProcess
    {
        #region 싱글톤
        public static MemberProcess Singleton;
        static MemberProcess()
        {
            Singleton = new MemberProcess();
        }
        private MemberProcess()
        {
        }

        ~MemberProcess()
        {
            WbDB.Singleton.Dispose();
        }
        #endregion


        public bool AiSettingMessage(string msg, string target, string type)
        {
            return WbService.WbDB.Singleton.AddAiSetting(msg, target, type);
        }

        public List<Data> GetDataList()
        {
            return WbService.WbDB.Singleton.GetDataList();
        }

        public Data SendMessage(string msg)
        {
            return WbService.WbDB.Singleton.SelectCommend(msg);
        }
    }
}
