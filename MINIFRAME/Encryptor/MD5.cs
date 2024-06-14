using System;
using System.Collections.Generic;
using System.Text;



namespace MINIFRAME.Encryptor
{

    public class MD5
    {


        public static string Encrypt(string str)
        {
            Byte[] textBytes = System.Text.Encoding.Default.GetBytes(str);
            System.Text.StringBuilder ret = new System.Text.StringBuilder();

            try
            {
                System.Security.Cryptography.MD5CryptoServiceProvider cryptHandler = new System.Security.Cryptography.MD5CryptoServiceProvider();
                Byte[] hash = cryptHandler.ComputeHash(textBytes);

                foreach (Byte a in hash)
                {
                    if (a < 16)
                    {
                        ret.Append("0" + a.ToString("x"));
                    }
                    else
                    {
                        ret.Append(a.ToString("x"));
                    }
                }
            }
            catch
            {
            }

            return ret.ToString();
        }
    }

}