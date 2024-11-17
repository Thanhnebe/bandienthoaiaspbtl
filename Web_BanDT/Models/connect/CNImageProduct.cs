using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Web_BanDT.Models.csdl;
using System.Web.UI.WebControls;

namespace Web_BanDT.Models.connect
{
    public class CNImageProduct
    {

        string constr = ConfigurationManager.ConnectionStrings["qlBanHang"].ConnectionString;
        SqlConnection con;
        SqlDataReader reader;
        public List<ProductImage> ListIamge(int productId)
        {
            List<ProductImage> list = new List<ProductImage>();
            con = new SqlConnection(constr);
            con.Open();
            string sqlImg = "select * from tb_ProductImage where ProductId=" + productId + "";
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sqlImg, con);
            DataTable table = new DataTable();
            DataAdapter.Fill(table);
            foreach (DataRow dr in table.Rows)
            {
                var item = new ProductImage();
                item.id = Convert.ToInt32(dr["IDImage"]);
                item.ProductId = Convert.ToInt32(dr["ProductId"]);
                item.image = dr["image"].ToString();
                list.Add(item);
            }

            return list;
        }
        public void deleteIamge(int id)
        {
            string sql = "delete from tb_ProductImage where IDImage= " + id + "";
            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void InsertProductImages(int productId, string image, bool Isdefault)
        {

            string sqlInsert = "insert into tb_ProductImage(ProductId, image, idDefault) " +
                "values(" + productId + ", '" + image + "', '" + Isdefault + "' )";
            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlInsert, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}