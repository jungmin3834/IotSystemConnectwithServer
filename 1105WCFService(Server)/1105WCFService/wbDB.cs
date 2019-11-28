using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace WbService
{
    class WbDB
    {
        #region 싱글톤
        public static WbDB Singleton;
        static WbDB()
        {
            Singleton = new WbDB();
            Console.WriteLine("dusruf");
        }
        private WbDB()
        {
            Connect();
        }

        ~WbDB()
        {
              Dispose();
        }
        #endregion

        MySqlConnection conn; 

        public void Connect()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = 
                ConfigurationManager.ConnectionStrings["Server = localhost; database ={ 0};UID=root; password=qudwns12"].ToString();
            conn.Open();    //  데이터베이스 연결         
            Console.WriteLine("연결 성공");  
        }

        public void Dispose()
        {
            conn.Close();       //  연결 해제
        }

        #region 명령어 관리

        public bool AddAiSetting(string msg, string target, string type)
        {
            try
            {
                //1. 쿼리문 작성
                string sql = "INSERT INTO Example4 " +
                    "VALUES" +
                    " (@MSG, @TARGET,@TYPE)";

                //2. 명령객체 생성
                MySqlCommand cmd = new MySqlCommand(sql, conn);


                MySqlParameter param_name = new MySqlParameter("@MSG", msg);
                cmd.Parameters.Add(param_name);

                MySqlParameter param_subject = new MySqlParameter("@TARGET", target);
                cmd.Parameters.Add(param_subject);

                MySqlParameter param_male = new MySqlParameter("@TYPE", type);
                cmd.Parameters.Add(param_male);

                //4. 쿼리문 실행
                if (cmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Data SelectCommend(string msg)
        {
            try
            {
                string sql = "SELECT * FROM Example4 where commandtext = @MSG";
                MySqlCommand cmd = new MySqlCommand(sql, conn);


                MySqlParameter param_name = new MySqlParameter("@MSG", msg);
                cmd.Parameters.Add(param_name);

               MySqlDataReader myDataReader = cmd.ExecuteReader();
               Data stulist = new Data("","","");

                while (myDataReader.Read())
                {
                    Data stu = new Data(myDataReader["commandtext"].ToString(), myDataReader["targettext"].ToString(), myDataReader["messagetext"].ToString());

                    stulist = stu;
                }
                myDataReader.Close();
                return stulist;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Data> GetDataList()
        {
             try
             {
                 string sql = "SELECT * FROM Example4";
                 MySqlCommand cmd = new MySqlCommand(sql, conn);
                 MySqlDataReader myDataReader = cmd.ExecuteReader();
                 List<Data> stulist = new List<Data>();

                 while (myDataReader.Read())
                 {
                     Data stu = new Data(myDataReader["commandtext"].ToString(), myDataReader["targettext"].ToString(), myDataReader["messagetext"].ToString());

                     stulist.Add(stu);
                 }
                 myDataReader.Close();
                 return stulist;
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
                 return null;
             }
        }
        
        #endregion

    }
}
