﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SYS.Core
{
    /// <summary>
    /// MD5加密工具类
    /// </summary>
    public class Md5LockedUtil
    {
        /// <summary>
        /// 对字符串进行32位MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5Encrypt32(string str)
        {
            string cl = str;
            string pwd = "";
            MD5 md5 = MD5.Create(); //实例化一个md5对像　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                pwd = pwd + s[i].ToString("X");
            }
            return pwd;

        }

        /// <summary>
        /// 对字符串进行32位MD5解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5DeEncrypt32(string str)
        {
                String encryptKey = "Oyea";
                DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();
                byte[] key = Encoding.Unicode.GetBytes(encryptKey);
                byte[] data = Convert.FromBase64String(str);
                System.IO.MemoryStream MStream = new System.IO.MemoryStream();
                CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);
                CStream.Write(data, 0, data.Length);
                CStream.FlushFinalBlock();
                return Encoding.Unicode.GetString(MStream.ToArray());

        }
    }
}
