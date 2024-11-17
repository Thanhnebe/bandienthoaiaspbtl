using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Web_BanDT.Models.csdl;


namespace Web_BanDT.Models.connect
{
    public class CNcategory
    {
        string constr = ConfigurationManager.ConnectionStrings["qlBanHang"].ConnectionString;
        SqlConnection con;
        SqlDataReader reader;

        public List<Category> categories()
        {
            List<Category> Listcategories = new List<Category>();
            string sqlcategory = "select *from tb_Category, NHANVIEN where tb_Category.idNhanVien = NHANVIEN.ID";
            con = new SqlConnection(constr);
            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sqlcategory, con);
            DataAdapter.Fill(table);
            foreach (DataRow dr in table.Rows)
            {
                var cate = new Category();
                cate.Id = (int)dr["Id"];
                cate.TieuDe = dr["TieuDe"].ToString();
                cate.MieuTa = dr["MieuTa"].ToString();
                cate.SeoTieuDe = dr["SeoTieuDe"].ToString();
                cate.SeoMoTa = dr["SeoMoTa"].ToString();
                cate.biDanh = dr["biDanh"].ToString();
                cate.SeoTuKhoa = dr["SeoTuKhoa"].ToString();
                cate.tenNhanVien= dr["tenNhanVien"].ToString();
                Listcategories.Add(cate);

            }

            return Listcategories;
        }
        public void themCategory(Category cate, DateTime date, string bidanh, int idnhanvien)
        {
            string sqlInset = "INSERT INTO tb_Category (TieuDe, MieuTa, SeoTieuDe, SeoMoTa, SeoTuKhoa, CreatyDate,  biDanh, idNhanVien) " +
                "values(N'"+cate.TieuDe+"', N'"+cate.MieuTa+"', N'"+cate.SeoTieuDe+"', N'"+cate.SeoMoTa+"', N'"+cate.SeoTuKhoa+"','"+date+"','"+bidanh+"',"+idnhanvien+"  )";
            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlInset, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public Category showcateGory(int id)
        {

            string sql = "select * from tb_Category where Id='" + id + "';";
            con = new SqlConnection(constr);
            con.Open();
            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sql, con);
            DataAdapter.Fill(table);
            var cate = new Category();
            foreach (DataRow dr in table.Rows)
            {

                cate.Id = (int)dr["Id"];
                cate.TieuDe = dr["TieuDe"].ToString();
                cate.MieuTa = dr["MieuTa"].ToString();
                cate.SeoTieuDe = dr["SeoTieuDe"].ToString();
                cate.SeoMoTa = dr["SeoMoTa"].ToString();
                cate.biDanh = dr["biDanh"].ToString();
                cate.SeoTuKhoa = dr["SeoTuKhoa"].ToString();
     

            }
            con.Close();
            return cate;

        }
        public void editCateGory(Category cate, DateTime date, string bidanh, int idnhanvien, string ModifiedBy)
        {
            string updateSQL = "UPDATE tb_Category "+
                "SET TieuDe = N'" +cate.TieuDe + "', MieuTa =N'" + cate.MieuTa + "', SeoTieuDe=N'" + cate.SeoTieuDe + "', SeoMoTa=N'" + cate.SeoMoTa + "', SeoTuKhoa=N'" + cate.SeoTuKhoa + "', biDanh='" + bidanh + "',idnhanvien=" + idnhanvien +" WHERE id=" + cate.Id + ";";
            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(updateSQL, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteCategory(int id)
        {
            string sqlDelte = "DELETE FROM  tb_Category where Id=" + id + ";";
            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlDelte, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
     



    }
}