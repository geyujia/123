using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    /// <summary>
    /// IFCA 2.83用户名密码加密类
    /// </summary>
    public class HashFunc
    {
        private static readonly byte[] salt = new byte[32]
        {
            1,
            35,
            69,
            103,
            131,
            171,
            205,
            239,
            254,
            220,
            186,
            152,
            118,
            84,
            50,
            16,
            17,
            34,
            51,
            51,
            68,
            85,
            102,
            119,
            0,
            119,
            170,
            187,
            204,
            221,
            238,
            byte.MaxValue
        };

        private HashFunc()
        {
        }

        public static string HashValue(string Value2Hash)
        {
            if (Value2Hash.Length < 32)
            {
                Value2Hash += new string('x', 31 - Value2Hash.Length);
            }
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(Value2Hash, salt, 1024);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(32));
        }

        public static string HashValue(string Value2Hash, string ExtraKey)
        {
            return HashValue(Value2Hash);
        }

        public static string HashObjectValue(object obj)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);
                HMACSHA1 hMACSHA = new HMACSHA1(salt);
                byte[] inArray = hMACSHA.ComputeHash(stream);
                stream.Close();
                return Convert.ToBase64String(inArray);
            }
        }
    }
}
