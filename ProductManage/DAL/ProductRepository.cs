using Oracle.ManagedDataAccess.Client;
using ProductManage.Model;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ProductManage.DAL
{
    public class ProductRepository
    {
        string connStr =
            ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

        private OracleConnection GetConn()
        {
            return new OracleConnection(connStr);
        }

        public List<Product> GetAll()
        {
            List<Product> list = new List<Product>();

            using (var con = GetConn())
            using (var cmd = new OracleCommand("SELECT * FROM TbProduct", con))
            {
                con.Open();
                var r = cmd.ExecuteReader();

                while (r.Read())
                {
                    list.Add(new Product
                    {
                        Id = Convert.ToInt32(r["Id"]),
                        Name = r["Name"].ToString(),
                        Price = Convert.ToDecimal(r["Price"]),
                        Quantity = Convert.ToInt32(r["Quantity"])
                    });
                }
            }

            return list;
        }

        public void Insert(Product p)
        {
            using (var con = GetConn())
            using (var cmd = new OracleCommand(@"
                INSERT INTO TbProduct VALUES (:Id,:Name,:Price,:Quantity)", con))
            {
                cmd.Parameters.Add(":Id", p.Id);
                cmd.Parameters.Add(":Name", p.Name);
                cmd.Parameters.Add(":Price", p.Price);
                cmd.Parameters.Add(":Quantity", p.Quantity);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var con = GetConn())
            using (var cmd = new OracleCommand("DELETE FROM TbProduct WHERE Id=:Id", con))
            {
                cmd.Parameters.Add(":Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}