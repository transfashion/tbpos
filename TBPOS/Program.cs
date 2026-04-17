using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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


        public static bool TryDeletePos05EnDll(string dirPath, out string message)
        {
            string filePath = Path.Combine(dirPath, "POS05EN.dll");
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


            // jika ada update di server, download dulu
            // download update dari server ke cwd/download
            // synchronous call dari Main:
            frmSplash.setStatus("Checking for updates...");
            string url = "http://localhostsdfr/crossroads/updatedllpos/POS05EN.dll";
            string dest = Path.Combine(cwd, "download", "POS05EN.dll");

            bool ok = Downloader.DownloadPos05EnDllAsync(url, dest).GetAwaiter().GetResult();

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

            frmSplash.setStatus("");
        }



    }
}