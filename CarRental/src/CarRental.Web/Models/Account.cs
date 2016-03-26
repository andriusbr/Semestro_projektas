using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CarRental.Web.Models
{
    public class Account
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember on this computer")]
        public bool RememberMe { get; set; }


        /*public string VerifyAccount(string _username, string _password)
        {
            using (var cn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string _sql = @"SELECT [Status] FROM [dbo].[User]" +
                       @"WHERE [Username] = @u AND [Password] = @p";
                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                    .Value = _username;
                cmd.Parameters
                    .Add(new SqlParameter("@p", SqlDbType.NVarChar))
                    .Value = Encode(_password);
                cn.Open();
                SqlDataReader reader;
                try {
                    reader = cmd.ExecuteReader();
                }catch(Exception e)
                {
                    return "Database Error";
                }
                
                if (reader.HasRows)
                {
                    cn.Close();
                    cn.Open();
                    string status;
                    try
                    {
                        status = (string)cmd.ExecuteScalar();
                    }
                    catch (Exception e)
                    {
                        return "Database Error";
                    }

                    if (status.Equals("admin"))
                    {
                        return "Admin";
                    }
                    else if (status.Equals("master"))
                    {
                        return "Master";
                    }
                    
                    reader.Dispose();
                    cmd.Dispose();
                    return "Success";
                }
                else
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return "Incorrect username or password";
                }
            }
        }




        public static string Encode(string value)
        {
            var hash = System.Security.Cryptography.SHA1.Create();
            var encoder = new ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
        }*/
    }
}
