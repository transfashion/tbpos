using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;



namespace MINIFRAME.Encryptor
{
    public class DES
    {

        private static Byte[] __SALT = { 0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0xF1, 0xF0, 0xEE, 0x21, 0x22, 0x45 };

        public static string Encrypt(string str, string password)
        {
            Rfc2898DeriveBytes k1 = new Rfc2898DeriveBytes(password, __SALT, 1000);
            TripleDES encAlg = TripleDES.Create();
            encAlg.Key = k1.GetBytes(16);
            MemoryStream encryptionStream = new MemoryStream();
            CryptoStream encrypt = new CryptoStream(encryptionStream, encAlg.CreateEncryptor(), CryptoStreamMode.Write);
            Byte[] utfD1 = new System.Text.UTF8Encoding(false).GetBytes(str);

            encrypt.Write(utfD1, 0, utfD1.Length);
            encrypt.FlushFinalBlock();
            encrypt.Close();

            Byte[] edata1 = encryptionStream.ToArray();

            k1.Reset();

            return Convert.ToBase64String(edata1) + Convert.ToBase64String(encAlg.IV);

        }



        public static string Decrypt(string encryptedstring, string password)
        {

            Rfc2898DeriveBytes k2 = new Rfc2898DeriveBytes(password, __SALT);
            string strIV = encryptedstring.Substring(encryptedstring.Length - 12, 12);
            encryptedstring = encryptedstring.Substring(0, encryptedstring.Length - 12);
            TripleDES decAlg = TripleDES.Create();

            decAlg.Key = k2.GetBytes(16);
            decAlg.IV = Convert.FromBase64String(strIV);

            MemoryStream decryptionStreamBacking = new MemoryStream();
            CryptoStream decrypt = new CryptoStream(decryptionStreamBacking, decAlg.CreateDecryptor(), CryptoStreamMode.Write);

            decrypt.Write(Convert.FromBase64String(encryptedstring), 0, Convert.FromBase64String(encryptedstring).Length);
            decrypt.Flush();
            decrypt.Close();

            k2.Reset();

            return new System.Text.UTF8Encoding(false).GetString(decryptionStreamBacking.ToArray());
        }

    }

}