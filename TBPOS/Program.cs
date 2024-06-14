using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace TBPOS
{
    static class Program
    {
        static MINIFRAME.FormMain frmmain; 

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmmain = new MINIFRAME.FormMain();
            frmmain.Text = "POS";
            frmmain.Load += new EventHandler(frmmain_Load);


            Application.Run(frmmain);
        }

        static void frmmain_Load(object sender, EventArgs e)
        {
            MINIFRAME.FormLogin frmlogin = new MINIFRAME.FormLogin();
            frmlogin.PreferenceSet += new EventHandler(frmlogin_PreferenceSet);
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

        }

        static void frmlogin_PreferenceSet(object sender, EventArgs e)
        {
            frmmain.InitPreferenceInfo();
        }


    }
}