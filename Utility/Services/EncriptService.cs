using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Utility.Services
{
    public static class EncriptService
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMD5(this string value)
        {
            string strResult = string.Empty;
            try
            {
                using (var md5 = MD5.Create())
                {
                    var result = md5.ComputeHash(Encoding.ASCII.GetBytes(value));
                    strResult = BitConverter.ToString(result);
                    strResult = strResult.Replace("-", "");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("GetMD5Str Error:{0}", ex.Message));
            }
            return strResult;
        }
    }
}
