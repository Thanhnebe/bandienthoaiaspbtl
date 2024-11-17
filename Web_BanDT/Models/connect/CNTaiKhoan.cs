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
    public class CNTaiKhoan
    {
        string constr = ConfigurationManager.ConnectionStrings["qlBanHang"].ConnectionString;
        SqlConnection con;
        SqlDataReader reader;

        public List<NHANVIEN> ListNV()
        {
            List<NHANVIEN> ListNhanVien = new List<NHANVIEN>();
            string sqlcategory = "select NHANVIEN.ID,UserNmae, SDT, tenNhanVien, tenQuyen from NHANVIEN, PHANQUYEN where NHANVIEN.idPhanQuyen = PHANQUYEN.ID";
            con = new SqlConnection(constr);
            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sqlcategory, con);
            DataAdapter.Fill(table);
            foreach (DataRow dr in table.Rows)
            {
                var nv = new NHANVIEN();
                nv.ID = (int)dr["Id"];
                nv.tenNhanVien = dr["tenNhanVien"].ToString();
                nv.userName = dr["UserNmae"].ToString();
                nv.soDienThoai = dr["SDT"].ToString();
                nv.tenQuyen = dr["tenQuyen"].ToString();
                ListNhanVien.Add(nv);

            }

            return ListNhanVien;
        }
        public List<PHANQUYEN> listPhanQuyen()
        {
            List<PHANQUYEN> lstLoaiSp = new List<PHANQUYEN>();
            string sqlNews = "select * from PHANQUYEN";
            con = new SqlConnection(constr);
            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sqlNews, con);
            DataAdapter.Fill(table);
            foreach (DataRow dr in table.Rows)
            {
                var pq = new PHANQUYEN();
                pq.ID = (int)dr["id"];
                pq.tenQuyen = dr["tenQuyen"].ToString();
                lstLoaiSp.Add(pq);

            }
            return lstLoaiSp;
        }
        public void themTK(string user, string pass)
        {
            con.Open();  
            string sqltk = "insert into ACOUNT(USERNAME, PASSSWORD, ROLE) values('" + user + "', '" + pass + "', 1)";
            con = new SqlConnection(constr);       
            SqlCommand cmd = new SqlCommand(sqltk, con);
            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void themNV(NHANVIEN nv)
        {
            string sqlInset = "insert into NHANVIEN(tenNhanVien, SDT, NgaySinh, DiaChi, idPhanQuyen, UserNmae, passWord) values(N'"+nv.userName+"', '"+nv.soDienThoai+"', '"+nv.ngaySinh+"',N'"+nv.diaChi+"', "+nv.idPhanQuyen+", '"+nv.userName+"', '"+nv.passWord+"')";
            
            con = new SqlConnection(constr);
           
            if (sqlInset != null)
            {
                themTK(nv.userName, nv.passWord);
            }
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlInset, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public NHANVIEN showNhanVien(int id)
        {

            string sql = "select * from NHANVIEN where Id='" + id + "';";
            con = new SqlConnection(constr);
            con.Open();
            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sql, con);
            DataAdapter.Fill(table);
            var nv = new NHANVIEN();
            foreach (DataRow dr in table.Rows)
            {
                nv.ID = (int)dr["Id"];
                nv.tenNhanVien = dr["tenNhanVien"].ToString();
                nv.userName = dr["UserNmae"].ToString();
                nv.soDienThoai = dr["SDT"].ToString();
                nv.idPhanQuyen = (int)dr["idPhanQuyen"];
                nv.ngaySinh = (DateTime)dr["NgaySinh"];
                nv.passWord = dr["passWord"].ToString();
                nv.diaChi = dr["DiaChi"].ToString();
            }
            con.Close();
            return nv;

        }
        public NHANVIEN checkTKNV(string userName, string passsWord)
        {

            string sql = "select * from NHANVIEN where UserNmae='"+userName+"' and passWord='"+passsWord+"'";
            con = new SqlConnection(constr);
            con.Open();
            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sql, con);
            DataAdapter.Fill(table);
            var nv = new NHANVIEN();
            foreach (DataRow dr in table.Rows)
            {
                nv.ID = (int)dr["Id"];
                nv.tenNhanVien = dr["tenNhanVien"].ToString();
                nv.userName = dr["UserNmae"].ToString();
                nv.soDienThoai = dr["SDT"].ToString();
                nv.idPhanQuyen = (int)dr["idPhanQuyen"];
                nv.ngaySinh = (DateTime)dr["NgaySinh"];
                nv.passWord = dr["passWord"].ToString();
                nv.diaChi = dr["DiaChi"].ToString();
            }
            con.Close();
            return nv;

        }
        public void editNhanVien(NHANVIEN nv)
        {
            string updateSQL = "update NHANVIEN " +
                "set tenNhanVien =N'"+nv.tenNhanVien+"', SDT='"+nv.soDienThoai+"', NgaySinh='"+nv.ngaySinh+"', DiaChi=N'"+nv.diaChi+"', idPhanQuyen="+nv.idPhanQuyen+",UserNmae ='"+nv.userName+"', passWord='"+nv.passWord+"' " +
                "where ID="+nv.ID+"";
            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(updateSQL, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteNhanVien(int id)
        {
            string sqlDelte = "DELETE FROM  NHANVIEN where Id=" + id + ";";
            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlDelte, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        

    }
}