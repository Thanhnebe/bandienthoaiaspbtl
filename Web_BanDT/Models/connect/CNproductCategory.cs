using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Web_BanDT.Models.csdl;
using System.Data;
using System.Reflection;
using System.Drawing;

namespace Web_BanDT.Models.connect
{
    public class CNproductCategory
    {
        string constr = ConfigurationManager.ConnectionStrings["qlBanHang"].ConnectionString;
        SqlConnection con;
        SqlDataAdapter DataAdapter;
        public List<LoaiSanPham> listLoaiSP()
        {
            List<LoaiSanPham> lstLoaiSp = new List<LoaiSanPham>();
            string sqlNews = "select * from tb_LoaiSanPham";
            con = new SqlConnection(constr);
            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sqlNews, con);
            DataAdapter.Fill(table);
            foreach (DataRow dr in table.Rows)
            {
                var laoiSp = new LoaiSanPham();
                laoiSp.id = (int)dr["id"];
                laoiSp.tieuDe = dr["tieuDeLSP"].ToString();
                laoiSp.CreatyDate = (DateTime)dr["CreatedDate"];
                laoiSp.icon = dr["icon"].ToString();
                laoiSp.biDanh = dr["biDanhLSP"].ToString();

                lstLoaiSp.Add(laoiSp);

            }
            return lstLoaiSp;
        }

        public void insertLoaiSP(string tieuDe, string seoTieuDe, string seoMoTa, string seoTuKhoa, DateTime createDate, string bidanh)
        {
            string sqlInsert = "insert into tb_LoaiSanPham(tieuDeLSP, SeoTieuDe, SeoMoTa, SeoTuKhoa, CreatedDate, biDanhLSP)" +
                " values(N'" + tieuDe + "',N'" + seoTieuDe + "', N'" + seoMoTa + "', N'" + seoTuKhoa + "' ,'" + createDate + "', '" + bidanh + "');";
            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlInsert, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public LoaiSanPham showLoaiSp(int id)
        {
            string sql = "select * from tb_LoaiSanPham where Id='" + id + "';";
            con = new SqlConnection(constr);

            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sql, con);
            DataAdapter.Fill(table);
            var laoiSp = new LoaiSanPham();
            foreach (DataRow dr in table.Rows)
            {
                laoiSp.id = (int)dr["id"];
                laoiSp.tieuDe = dr["tieuDeLSP"].ToString();
                laoiSp.CreatyDate = (DateTime)dr["CreatedDate"];
                laoiSp.SeoTieuDe = dr["SeoTieuDe"].ToString();
                laoiSp.SeoMoTa = dr["SeoMoTa"].ToString();
                laoiSp.SeoTuKhoa = dr["SeoTuKhoa"].ToString();


            }

            return laoiSp;


        }
        public void editLoaiSP(int id, string masp, string tieude, string mieuta, string seoMoTa, string seoTuKhoa, string seoTieuDe, string bidanh)
        {
            string updateSQL = "update tb_LoaiSanPham " +
                "set  tieuDeLSP=N'"+ tieude + "',  SeoMoTa=N'"+ seoMoTa + "', SeoTuKhoa=N'"+ seoTuKhoa + "', SeoTieuDe=N'"+ seoTieuDe + "', biDanhLSP='" + bidanh + "' " +
                "where ID="+id+"";
            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(updateSQL, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteLoaiSP(int id)
        {
            string sqlDelte = "DELETE FROM  tb_LoaiSanPham where Id=" + id + ";";
            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlDelte, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}