using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mado.classes
{
    class Bill
    {
        public int id { get; set; }
        public DateTime bill_date { get; set; }
        public int id_order { get; set; }
        public string bill_state { get; set; }
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=Mado;Integrated Security=True");

        public Bill(){}
        public int add()
        {
            string sql;
            if (search() == 0)
            {
                sql = $"insert into bills(bill_date,id_order,bill_state) values('{bill_date}',{id_order},'{bill_state}')";
                SqlCommand cmd = new SqlCommand(sql,cn);
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
                sql = $"update bills set  bill_date='{bill_date}',id_order={id_order},bill_state='{bill_state}' where id ={id}";
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
                sql = $"delete from bills where id ={id}";
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
            string sql = $"select * from bills where id ={id}";
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
