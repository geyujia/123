using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{

    #region 官方示例链接
    //https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/concepts/attributes/accessing-attributes-by-using-reflection
    #endregion
    // <summary>
    /// 该特性表明了该类可以用来生成sql语句，参数为空的情况下，则使用该类的名称作为表名
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class TableNameAttribute: Attribute
    {
        readonly string tableName;

        /// <summary>
        /// 指定表名
        /// </summary>
        /// <param name="tableName"></param>
        public TableNameAttribute(string tableName = null)
        {
            if (string.IsNullOrEmpty(tableName))
                tableName = this.GetType().Name;
            this.tableName = tableName;
        }

        public string TableName
        {
            get { return tableName; }
        }
    }

    //demo 
    [TableName("media5555")]
    public class Media
    {

    }
}
