using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MINIFRAME
{
    public class User
    {
        private static string _UserId;
        private static string _UserName;


        public static string UserId
        {
            get
            {
                return _UserId;
            }
        }

        public static string UserName
        {
            get
            {
                return _UserName;
            }
        }

        public static bool Authenticate(string username, string password) {

            SqlConnection conn = Preference.getSqlConnection();

            try
            {
                conn.Open();

                try
                {
                    string sql = @"
                        SELECT 
                        username, user_fullname, user_password 
                        FROM master_user 
                        WHERE
                        user_isdisabled=0
                        AND username = @username
                    ";


                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(new SqlParameter[] {
                        new SqlParameter("@username", System.Data.SqlDbType.VarChar, 30)
                    });

                    cmd.Parameters["@username"].Value = username;

                    DataTable tbl = new DataTable("master_user");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(tbl);

                    if (tbl.Rows.Count == 0)
                        throw new User.NotFoundException(string.Format("User '{0} not found!", username));

                    string md5password = tbl.Rows[0]["user_password"].ToString();

                    IST.DataHash.MD5 md5 = new IST.DataHash.MD5();
                    if (!md5.Verify(password, md5password))
                        throw new User.NotFoundException(string.Format("Wrong password!", username));


                    _UserId = tbl.Rows[0]["username"].ToString();
                    _UserName = tbl.Rows[0]["user_fullname"].ToString();

                    return true;
                }
                catch (User.NotFoundException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
            catch (User.NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "/r/nError in User::Authenticate()");
            }
        }



        public class NotFoundException :  Exception
        {
            public NotFoundException(string message)
                : base(message)
            {
            }


        }


    }
}
