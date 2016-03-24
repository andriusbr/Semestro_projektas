using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Web.Models
{
    public class Register
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        public string addUser(string _email, string _username, string _password)
        {
            using (var cn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                if (!doesUserExist(cn, _email, _username))
                {
                    return "Account already exists!";
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO [User] (Email, Password, Username) VALUES (@email, @passw, @usern)", cn);

                cmd.Parameters.AddWithValue("@email", _email);
                cmd.Parameters.AddWithValue("@passw", Encode(_password));
                cmd.Parameters.AddWithValue("@usern", _username);

                /*cmd.Parameters
                    .Add(new SqlParameter("@email", SqlDbType.NVarChar))
                    .Value = _email;
                cmd.Parameters
                    .Add(new SqlParameter("@passw", SqlDbType.NVarChar))
                    .Value = Encode(_password);
                cmd.Parameters
                    .Add(new SqlParameter("@usern", SqlDbType.NVarChar))
                    .Value = _username;*/

                cn.Open();
                try {
                    cmd.ExecuteNonQuery();
                }catch(Exception e)
                {
                    cn.Close();
                    return "Database error";
                }
                cn.Close();
                return "Success";
            }
        }

        private static bool doesUserExist(SqlConnection cn, string _email, string _username)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM [User] WHERE Email=@email AND Username=@username", cn);
            cmd.Parameters.AddWithValue("@email", _email);
            cmd.Parameters.AddWithValue("@username", _username);
            cn.Open();
            SqlDataReader dr;
            try
            {
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                cn.Close();
                return false;
            }
            while (dr.Read())
            {
                if (dr.HasRows == true)
                {
                    cn.Close();
                    return false;
                }
            }
            cn.Close();
            return true;
        }


        public static string Encode(string value)
        {
            var hash = System.Security.Cryptography.SHA1.Create();
            var encoder = new ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
        }

    }
}
