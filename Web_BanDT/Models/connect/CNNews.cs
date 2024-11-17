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
    public class CNNews
    {
        string constr = ConfigurationManager.ConnectionStrings["qlBanHang"].ConnectionString;
        SqlConnection con;
        SqlDataAdapter DataAdapter;
        public List<ThongBaoMoi> listTB()
        {
            List<ThongBaoMoi> ListNews = new List<ThongBaoMoi>();
            string sqlNews = "select* from tb_ThongBaoMoi";
            con = new SqlConnection(constr);
            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sqlNews, con);
            DataAdapter.Fill(table);
            foreach (DataRow dr in table.Rows)
            {
                var news = new ThongBaoMoi();
                news.id = (int)dr["id"];
                news.image = dr["image"].ToString();
                news.tieuDe = dr["tieuDe"].ToString();
                news.CreatyDate = (DateTime)dr["CreatedDate"];
                ListNews.Add(news);

            }
            return ListNews;
        }

        public void insertNews(ThongBaoMoi news, DateTime date, string bidanh, int idNV)
        {
            string sqlInsert = "INSERT INTO tb_ThongBaoMoi (tieuDe,moTa, Categoryld, image, SeoTieuDe, SeoMoTa, SeoTuKhoa, biDanh,  CreatedDate, idNhanVien) " +
                "VALUES (N'"+news.tieuDe+"',N'"+news.moTa+"', "+news.Categoryld+", '"+news.image+"', N'"+news.SeoTieuDe+"', N'"+news.SeoTuKhoa+"', N'"+news.SeoMoTa+"', '"+bidanh+"', '"+date+"', "+news.idNhanVien+" );";


            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlInsert, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public ThongBaoMoi showNews(int id)
        {

            string sql = "select * from tb_ThongBaoMoi where Id='" + id + "';";
            con = new SqlConnection(constr);
            con.Open();
            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sql, con);
            DataAdapter.Fill(table);
            var news = new ThongBaoMoi();
            foreach (DataRow dr in table.Rows)
            {

                news.id = (int)dr["Id"];
                news.tieuDe = dr["tieuDe"].ToString();
                news.moTa = dr["moTa"].ToString();
                news.SeoTieuDe = dr["SeoTieuDe"].ToString();
                news.SeoMoTa = dr["SeoMoTa"].ToString();
                news.biDanh = dr["biDanh"].ToString();
                news.SeoTuKhoa = dr["SeoTuKhoa"].ToString();
         
                news.image = dr["image"].ToString();
            }
            con.Close();
            return news;

        }
        public void editNews(int id, string tieude, string mota, string image, string seoTieude, string seomota, string seoTuKhoa,  DateTime ModifiedDate, string bidanh)
        {
            string updateSQL = "update tb_ThongBaoMoi " +
                " set tieuDe=N'"+ tieude + "',moTa=N'"+mota+"', image='"+image+"', SeoTieuDe=N'"+seoTieude+"', SeoMoTa=N'"+seomota+"', SeoTuKhoa=N'"+seoTuKhoa+"', ModifiedDate= '"+ModifiedDate+"', bidanh='"+bidanh+"'" +
                " where ID= "+id+";";
            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(updateSQL, con);    
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteNews(int id)
        {

            string sqlDelte = "DELETE FROM  tb_ThongBaoMoi where Id=" + id + ";";
            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlDelte, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public List<ThongBaoMoi> search(string text)
        {
            List<ThongBaoMoi> ListNews = new List<ThongBaoMoi>();
            string search = "SELECT * FROM tb_ThongBaoMoi WHERE tieuDe LIKE '%"+ text + "%';";
            con = new SqlConnection(constr);
            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(search, con);
            DataAdapter.Fill(table);
            foreach (DataRow dr in table.Rows)
            {
                var news = new ThongBaoMoi();
                news.id = (int)dr["id"];
                news.image = dr["image"].ToString();
                news.tieuDe = dr["tieuDe"].ToString();
                ListNews.Add(news);

            }
            return ListNews;

        }
        public int getID()
        {
            string sqlInsert = "select max(id) from tb_Category";
            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlInsert, con);
            int k = (int)cmd.ExecuteScalar();
            con.Close();
            return k;

        }
        public List<Category> listCateGory()
        {
            List<Category> lsCategory = new List<Category>();
            string sqlNews = "select ID, TieuDe from tb_Category";
            con = new SqlConnection(constr);
            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sqlNews, con);
            DataAdapter.Fill(table);
            foreach (DataRow dr in table.Rows)
            {
                var pq = new Category();
                pq.Id = (int)dr["ID"];
                pq.TieuDe = dr["TieuDe"].ToString();
                lsCategory.Add(pq);

            }
            return lsCategory;
        }
        public List<NHANVIEN> listNhanVien()
        {
            List<NHANVIEN> lsCategory = new List<NHANVIEN>();
            string sqlNews = "SELECT ID, tenNhanVien FROM NHANVIEN";
            con = new SqlConnection(constr);
            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sqlNews, con);
            DataAdapter.Fill(table);
            foreach (DataRow dr in table.Rows)
            {
                var pq = new NHANVIEN();
                pq.ID = (int)dr["ID"];
                pq.tenNhanVien = dr["tenNhanVien"].ToString();
                lsCategory.Add(pq);
            }
            return lsCategory;
        }
    }


}