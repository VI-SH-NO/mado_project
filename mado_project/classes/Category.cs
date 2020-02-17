using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mado.classes
{
    class Category
    {
        public int id { get; set; }
        public string category_name { get; set; }
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=Mado;Integrated Security=True");

        public Category()
        {

        }

        public int add()
        {
            string sql;
            if (search() == 0)
            {
                sql = $"insert into categories(category_name) values('{category_name}')";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                cn.Close();
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int modify()
        {
            string sql;
            if (search() == 1)
            {
                sql = $"update categories set category_name='{category_name}' where id ={id}";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                cn.Close();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int delete()
        {
            string sql;
            if (search() == 1)
            {
                sql = $"delete from categories where id ={id}";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                cn.Close();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int search()
        {
            string sql=$"select * from categories where id={id}";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                cn.Close();
                return 1;
            }
            cn.Close();
            return 0;

        }
    }
}
