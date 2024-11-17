using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using Web_BanDT.Models.csdl;
using System.Configuration;

namespace Web_BanDT.Models.connect
{
    public class CNTaiKhoanKH
    {

        string constr = ConfigurationManager.ConnectionStrings["qlBanHang"].ConnectionString;
        SqlConnection con;
        SqlDataReader reader;
        public void themTKKH(string user, string pass)
        {
            con.Open();
            string sqltk = "insert into ACOUNT(USERNAME, PASSSWORD, ROLE) values('" + user + "', '" + pass + "', 0)";
            con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sqltk, con);
            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void themKH(KhachHang kh)
        {
            string sqlInset = "insert into KHACHHANG(tenKhachHang, NgaySinh, PHONE, ADDRESS, EMAIL, USERNAME,PASSSWORD) " +
                "values(N'" + kh.TenKH + "','"+kh.ngaySinh+"', '" + kh.phone + "', N'" + kh.address + "', '" + kh.email + "','" + kh.userName + "','" + kh.passWord + "')";

            con = new SqlConnection(constr);

            if (sqlInset != null)
            {
                themTKKH(kh.userName, kh.passWord);
            }
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlInset, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
      
        public ACOUNT checkTK(string userName, string passsWord)
        {

            string sql = "select * from ACOUNT where USERNAME='"+userName+"' and PASSSWORD='"+passsWord+"' ";
            con = new SqlConnection(constr);
            con.Open();
            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sql, con);
            DataAdapter.Fill(table);
            var tk = new ACOUNT();
            foreach (DataRow dr in table.Rows)
            {
                tk.userName=dr["USERNAME"].ToString();
                tk.passWord = dr["PASSSWORD"].ToString();
                tk.role = (int)dr["ROLE"]; 
            }
            con.Close();
            return tk;

        }

        public KhachHang user(string userName, string passsWord)
        {

            string sql = "select * from KHACHHANG where USERNAME='" + userName + "' and PASSSWORD='" + passsWord + "' ";
            con = new SqlConnection(constr);
            con.Open();
            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sql, con);
            DataAdapter.Fill(table);
            var kh = new KhachHang();
            foreach (DataRow dr in table.Rows)
            {
                kh.ID = (int)dr["ID"];
                kh.TenKH = dr["tenKhachHang"].ToString();
                kh.email = dr["EMAIL"].ToString();
                kh.phone = dr["PHONE"].ToString();
                kh.ngaySinh = (DateTime)dr["NgaySinh"];
                kh.address = dr["ADDRESS"].ToString();
            }
            con.Close();
            return kh;

        }
    }
}