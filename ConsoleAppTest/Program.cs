using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DateTime date = new DateTime();
            Console.WriteLine(date.ToLongDateString());
            //01
            TestIFCAPWD();
            //02
            string businessobject= "RMS_PROJECT";
            string[] busobjects = new string[] { "RMS_PROJECT", "UNITID", "CONTRACTNO" };
            if (busobjects.Contains(businessobject))
            {
                Console.WriteLine(businessobject);
            }
            //03
            decimal amount = 1400.864M;
            decimal MonthDays = 30.416666667m;
            decimal MonthlyRent = Math.Round(amount * MonthDays, 0);
            Console.WriteLine("MonthlyRent:"+ MonthlyRent);//42609.61333M;
            //04 自定义Attribute Test
            string result = GetTableName<Media>();
            Console.WriteLine(result);
            TestAuthorAttribute.Test();
            
           Console.ReadKey();
        }
        /// <summary>
        /// 01、竞优密码加密
        /// </summary>
       static void TestIFCAPWD()
        {
            //要加密的值
            string pwd = "bei1jing#";//TjfucRALD3P90TXlopHLWj7GvPTpY+VfeNNV81FVoZY=
            string jmh = "TjfucRALD3P90TXlopHLWj7GvPTpY+VfeNNV81FVoZY=";
            string loginUserName = "zhanggq";
            //加密后的值
            string password = HashFunc.HashValue(pwd, loginUserName);
            Console.WriteLine("加密后密码：" + password);
            if (password.Equals(jmh))
            {
                Console.WriteLine("一模一样");
            }
            else
            {
                Console.WriteLine("有差异");
            }
        }
        /// <summary>
        /// 02 、获得表名
        /// 若没有使用TableName 指定表名，则使用类名作为表名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        static string GetTableName<T>()
        {
            var type = typeof(T);
            var result = ((TableNameAttribute)type
            .GetCustomAttributes(typeof(TableNameAttribute), false).FirstOrDefault())
            ?.TableName ?? type.Name;
            return result;
        }
    }

   
    
   
}
