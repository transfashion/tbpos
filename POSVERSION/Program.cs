using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSVERSION
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generate POS Version");

            // Cek apakah file POS05EN.dll ada di direktori yang sama dengan program ini
            string dllPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "POS05EN.dll");
            if (System.IO.File.Exists(dllPath))
            {
                // Ambil versi dari file POS05EN.dll
                string version = GetVersionFromDll(dllPath);
                Console.WriteLine("POS Version: " + version);


                string hashString = GetMd5HashFromDll(dllPath);
                Console.WriteLine("MD5 Hash: " + hashString);


                GenerateVersionJson(version, hashString);
            }
            else
            {
                Console.WriteLine("File POS05EN.dll tidak ditemukan.");
            }
        }

        static string GetVersionFromDll(string dllPath)
        {
            var versionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(dllPath);
            return versionInfo.FileVersion;
        }


        static string GetMd5HashFromDll(string dllPath)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                using (var stream = System.IO.File.OpenRead(dllPath))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }


        static void GenerateVersionJson(string version, string md5hash)
        {

            string json = "{\"version\":\""  + version +  "\", \"md5hash\":\""+  md5hash+"\"}";
            System.IO.File.WriteAllText("POS05EN.json", json);
        }

    }
}
