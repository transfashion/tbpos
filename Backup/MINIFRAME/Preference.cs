using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace MINIFRAME
{
    public class Preference
    {
        private static string __Encryptor = "KambingLiarMakOnah";
       

        public static string DbServer
        {
            get
            {
                return Properties.Settings.Default.DbServer;
            }

            set
            {
                Properties.Settings.Default.DbServer = value;
            }
        }

        public static string DbCatalog
        {
            get
            {
                return Properties.Settings.Default.DbCatalog;
            }

            set
            {
                Properties.Settings.Default.DbCatalog = value;
            }
        }

        public static string DbRole
        {
            get
            {
                return Properties.Settings.Default.DbRole;
            }

            set
            {
                Properties.Settings.Default.DbRole = value;
            }
        }

        public static string DbUsername
        {
            get
            {
                return Properties.Settings.Default.DbUsername;
            }

            set
            {
                Properties.Settings.Default.DbUsername = value;
            }
        }


        public static string DbPassword
        {
            get
            {
                try
                {
                    string password = Properties.Settings.Default.DbPassword;
                    if (password == "")
                    {
                        return "";
                    }
                    else
                    {
                        return Encryptor.DES.Decrypt(password, __Encryptor);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Cannot read password from preference!\r\n" + ex.Message);
                }
            }
        }


        public static string CentralServerAddress
        {
            get
            {
                return Properties.Settings.Default.CentralServerAddress;
            }

            set
            {
                Properties.Settings.Default.CentralServerAddress = value;
            }

        }

        public static void setDbPassword(string password)
        {
            Properties.Settings.Default.DbPassword = Encryptor.DES.Encrypt(password, __Encryptor);
        }


        public static string LoginUsername
        {
            get
            {
                return Properties.Settings.Default.LoginUsername;
            }

            set
            {
                Properties.Settings.Default.LoginUsername = value;
            }
        }

        public static string LoginPassword
        {
            get
            {
                try
                {
                    string password = Properties.Settings.Default.LoginPassword;
                    if (password == "")
                    {
                        return "";
                    }
                    else
                    {
                        return Encryptor.DES.Decrypt(password, __Encryptor);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Cannot read password from preference!\r\n" + ex.Message);
                }
            }
        }

        public static void setLoginPassword(string password)
        {
            Properties.Settings.Default.LoginPassword = Encryptor.DES.Encrypt(password, __Encryptor);
        }

        public static void ClearLoginPassword()
        {
            Properties.Settings.Default.LoginPassword = "";
        }



        public static bool LoginRemember
        {
            get
            {
                return Properties.Settings.Default.LoginRemember;
            }

            set
            {
                Properties.Settings.Default.LoginRemember = value;
            }

        }



        public static void Write()
        {
            Properties.Settings.Default.Save();
        }



        public static SqlConnection getSqlConnection()
        {
            SqlConnectionStringBuilder dsnsb = new SqlConnectionStringBuilder();
            dsnsb.ApplicationName = "TBPOS";
            dsnsb.DataSource = DbServer;
            dsnsb.InitialCatalog = DbCatalog;
            dsnsb.UserID = DbUsername;
            dsnsb.Password = DbPassword;

            SqlConnection conn = new SqlConnection(dsnsb.ToString());

            return conn;
        }

        public static OleDbConnection getOleDbConnection() {
            //OleDbConnectionStringBuilder dsnsb = new OleDbConnectionStringBuilder();
            String DSN_Template = "User ID={0}; Password={1}; Data Source=\"{2}\"; Initial Catalog={3}; Tag with column collation when possible=False; Use Procedure for Prepare=1; Auto Translate=True; Persist Security Info=True; Provider=\"SQLOLEDB.1\"; Use Encryption for Data=False; Packet Size=4096";
            String DSN = string.Format(DSN_Template, DbUsername, DbPassword, DbServer, DbCatalog);

            OleDbConnection conn = new OleDbConnection(DSN);

            return conn;
        }

    }
}
