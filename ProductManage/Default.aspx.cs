using ProductManage.DAL;
using ProductManage.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductManage
{
    public partial class Default : System.Web.UI.Page
    {
        ProductRepository repo = new ProductRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }

        void LoadData()
        {
            GridView1.DataSource = repo.GetAll();
            GridView1.DataBind();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(GridView1.DataKeys[index].Value);

            if (e.CommandName == "DeleteRow")
            {
                DeleteProduct(id);
                LoadData();
            }
        }
        private void DeleteProduct(int id)
        {
            using (var con = new Oracle.ManagedDataAccess.Client.OracleConnection(
                ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString))
            {
                con.Open();

                using (var cmd = new Oracle.ManagedDataAccess.Client.OracleCommand(
                    "DELETE FROM TbProduct WHERE Id = :Id", con))
                {
                    cmd.Parameters.Add(":Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Product p = new Product
            {
                Id = int.Parse(TxtId.Text),
                Name = TxtName.Text,
                Price = decimal.Parse(TxtPrice.Text),
                Quantity = int.Parse(TxtQuantity.Text)
            };

            repo.Insert(p);
            LoadData();
        }
    }
}