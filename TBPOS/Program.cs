using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Windows.Forms;


namespace TBPOS
{
    static class Program
    {
        static MINIFRAME.FormMain frmmain;
        static FormSplash frmSplash;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            frmSplash = new FormSplash();
            frmSplash.TopMost = true;
            frmSplash.StartPosition = FormStartPosition.CenterScreen;
            frmSplash.Show();

            bool doUpdate = true; // set true untuk update POS05EN.dll dari server
            if (doUpdate)
            {
                UpdatePOS05EnDll();
            }



            frmmain = new MINIFRAME.FormMain();
            frmmain.Text = "POS";
            frmmain.Load += new EventHandler(frmmain_Load);


            Application.Run(frmmain);
        }

        static void frmmain_Load(object sender, EventArgs e)
        {
            MINIFRAME.FormLogin frmlogin = new MINIFRAME.FormLogin();
            frmlogin.PreferenceSet += new EventHandler(frmlogin_PreferenceSet);
            frmlogin.Load += (s, ev) => { frmSplash.Close(); };

            DialogResult res = frmlogin.ShowDialog();

            if (res != DialogResult.Yes)
                frmmain.Close();

            frmmain.InitUserInfo();

            try
            {
                object browser = new FakeBrowser();
                POS05EN.uiTrnPosEN ui = new POS05EN.uiTrnPosEN();
                //POS05EN.uiQRTest ui = new POS05EN.uiQRTest();
                ui.InitializeControl("", MINIFRAME.User.UserId, MINIFRAME.Preference.CentralServerAddress, MINIFRAME.Preference.CentralServerAddress, ref browser, ui.GetType().Assembly);
                ui.SetDSNLocal(MINIFRAME.Preference.getOleDbConnection().ConnectionString);


                frmmain.InitUserControl(ui);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on embedding POS05EN.\r\n" + ex.Message, "TBPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {

            }

        }

        static void frmlogin_PreferenceSet(object sender, EventArgs e)
        {
            frmmain.InitPreferenceInfo();
        }


        public static bool TryDeleteFile(string filePath, out string message)
        {
            //string filePath = Path.Combine(dirPath, "POS05EN.dll");
            if (!File.Exists(filePath))
            {
                message = $"File not found: {filePath}";
                return false;
            }

            try
            {
                File.Delete(filePath);
                message = $"Deleted: {filePath}";
                return true;
            }
            catch (IOException ex)
            {
                message = $"IO error (possibly in use): {ex.Message}";
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                message = $"Access denied: {ex.Message}";
                return false;
            }
            catch (Exception ex)
            {
                message = $"Error: {ex.Message}";
                return false;
            }
        }


        static void UpdatePOS05EnDll()
        {
            // Implementasi update POS05EN.dll dari server
            string cwd = Directory.GetCurrentDirectory();
            string envCwd = Environment.CurrentDirectory;
            string startup = Application.StartupPath;                  // typical for WinForms
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;   // also common and stable
            string asmDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);




            // Cek pos05en json di server 
            frmSplash.setStatus("Checking for updates...");
            string urlJson = "http://ws.transbrowser.com/crossroads/updatedllpos/POS05EN.json";
            string destJson = Path.Combine(cwd, "download", "POS05EN.json");
            bool jsonOk = Downloader.DownloadAssetAsync(urlJson, destJson).GetAwaiter().GetResult();
            if (!jsonOk)
            {
                frmSplash.setStatus("Unavailabel Update Information");
                return;
            }

            // buka file json
            string jsonContent = File.ReadAllText(destJson);
            var serializer = new JavaScriptSerializer();
            var obj = serializer.Deserialize<PosVersion>(jsonContent);


            string currentVersion = getCurrentVersion();
            if (currentVersion != null && obj.version == currentVersion)
            {
                frmSplash.setStatus("POS05EN.dll is up to date");
                return;
            }


            Version localVer = new Version(currentVersion);
            Version serverVer = new Version(obj.version);


            int result = localVer.CompareTo(serverVer);
            if (result >= 0)
            {
                frmSplash.setStatus("POS05EN.dll is up to date");
                return;
            }

            // Versi di server lebih baru, lakukan update
            frmSplash.setStatus($"Downloading update version {obj.version} ...");
            string url = "http://ws.transbrowser.com/crossroads/updatedllpos/POS05EN.dll";
            string dest = Path.Combine(cwd, "download", "POS05EN.dll");
            bool ok = Downloader.DownloadAssetAsync(url, dest).GetAwaiter().GetResult();

            if (ok)
            {
                // cek datahash
                string downloadedHash = getMd5Hash(dest);
                if (downloadedHash != obj.md5hash) {
                    MessageBox.Show($"Error downloading POS05EN.dll version {obj.version}. Try again later ", "Download", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                frmSplash.setStatus("Updating DLL");
                // copy POS05EN.dll dari cwd/download ke cwd jika tidak ada
                string sourcePathDll = Path.Combine(cwd, "download", "POS05EN.dll");
                string destPathDll = Path.Combine(cwd, "POS05EN.dll");

                string sourcePathJson = Path.Combine(cwd, "download", "POS05EN.json");
                string destPathJson = Path.Combine(cwd, "POS05EN.json");


                string msg;
                TryDeleteFile(destPathDll, out msg);
                if (File.Exists(sourcePathDll))
                {
                    File.Copy(sourcePathDll, destPathDll);
                    // File.Delete(sourcePathDll);
                }
               
 
                TryDeleteFile(destPathJson, out msg);
                if (File.Exists(sourcePathJson))
                {
                    File.Copy(sourcePathJson, destPathJson);
                    // File.Delete(sourcePathJson);
                }

            }




            // jika ada update di server, download dulu
            // download update dari server ke cwd/download
            // synchronous call dari Main:
            /*
            string url = "http://localhostsdfr/crossroads/updatedllpos/POS05EN.dll";
            string dest = Path.Combine(cwd, "download", "POS05EN.dll");

            bool ok = Downloader.DownloadAssetAsync(url, dest).GetAwaiter().GetResult();

            if (ok) {

                frmSplash.setStatus("Updating DLL");


                string msg;
                TryDeletePos05EnDll(cwd, out msg);

                // copy POS05EN.dll dari cwd/download ke cwd jika tidak ada
                string sourcePath = Path.Combine(cwd, "download", "POS05EN.dll");
                string destPath = Path.Combine(cwd, "POS05EN.dll");

                if (File.Exists(sourcePath))
                {
                    File.Copy(sourcePath, destPath);
                }

                // hapus file di cwd/download
                File.Delete(sourcePath);
            }
            */


        }


        static string getCurrentVersion()
        {
            string cwd = Directory.GetCurrentDirectory();
            string localDllPath = Path.Combine(cwd, "POS05EN.dll");
            if (!File.Exists(localDllPath))
            {
                return null;
            }

            try
            {
                var versionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(localDllPath);
                var version = versionInfo.FileVersion;
                return version;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading local POS05EN.dll: " + ex.Message, "TBPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }


        }


        static string getMd5Hash(string filepath)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                using (var stream = System.IO.File.OpenRead(filepath))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

    }
}