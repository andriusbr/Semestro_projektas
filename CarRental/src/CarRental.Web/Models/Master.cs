
using CarRental.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Web.Models
{
    public class Master
    {
        public static void LoadValues()
        {
            /*SqlConnection cn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Users]", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            .DataSource = ds;
            GridView1.DataBind();*/
        }
    }
}
