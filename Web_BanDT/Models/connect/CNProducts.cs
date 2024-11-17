using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Web_BanDT.Models.csdl;
using System.Runtime.CompilerServices;

namespace Web_BanDT.Models.connect
{
    public class CNProducts
    {
        string constr = ConfigurationManager.ConnectionStrings["qlBanHang"].ConnectionString;
        SqlConnection con;
        SqlDataAdapter DataAdapter;
        public List<product_image> listSP()
        {
            List<product_image> ListSP = new List<product_image>();
            string sqlSP = " select tb_ProductImage.image,tb_ProductImage.idDefault ,TB_PRODUCT.ID , tieuDe, Quantity, Price, TB_PRODUCT.CreatedDate from TB_PRODUCT , tb_ProductImage where TB_PRODUCT.ID = ProductId and tb_ProductImage.idDefault='True'";
            con = new SqlConnection(constr);
            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sqlSP, con);
            DataAdapter.Fill(table);
            foreach (DataRow dr in table.Rows)
            {
                var sp = new product_image();
                sp.id = (int)dr["Id"];
                sp.tieuDe = dr["tieuDe"].ToString();
                sp.image = dr["image"].ToString();
                sp.quantity = (int)dr["Quantity"];
                sp.price = (decimal)dr["price"];
                sp.CreatyDate = (DateTime)dr["CreatedDate"];
                ListSP.Add(sp);

            }
            return ListSP;
        }


        public List<product_image> HienThiSanPham()
        {
            List<product_image> ListSP = new List<product_image>();
            string sqlSP = "select tb_ProductImage.image,tb_ProductImage.idDefault,tb_LoaiSanPham.biDanhLSP ,TB_PRODUCT.ID,TB_PRODUCT.tieuDe, Quantity, Price, TB_PRODUCT.CreatedDate, Pricesales, TB_PRODUCT.isHome , TB_PRODUCT.biDanh,TB_PRODUCT.isSale, TB_PRODUCT.ProductCategoryId from TB_PRODUCT , tb_ProductImage, tb_LoaiSanPham  where TB_PRODUCT.ID = ProductId and TB_PRODUCT.ProductCategoryId= tb_LoaiSanPham.ID and tb_ProductImage.idDefault='True'";
            con = new SqlConnection(constr);
            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sqlSP, con);
            DataAdapter.Fill(table);
            foreach (DataRow dr in table.Rows)
            {
                var sp = new product_image();
                sp.id = (int)dr["Id"];
                sp.productCategoryID = (int)dr["ProductCategoryId"];
                sp.tieuDe = dr["tieuDe"].ToString();
                sp.image = dr["image"].ToString();
                sp.quantity = (int)dr["Quantity"];
                sp.biDanh = dr["biDanh"].ToString();
                sp.price = (decimal)dr["price"];
                sp.pricesale = (decimal)dr["Pricesales"];
                sp.isHome = bool.Parse(dr["isHome"].ToString());
                sp.isSale = bool.Parse(dr["isSale"].ToString());
                sp.idDefault = bool.Parse(dr["idDefault"].ToString());
                sp.CreatyDate = (DateTime)dr["CreatedDate"];
           

                ListSP.Add(sp);

            }
            return ListSP;
        }
        public product_image DetailSanPham(int id)
        {

            string sqlSP = "  select tb_ProductImage.image,TB_PRODUCT.ChiTiet,tb_ProductImage.IDImage,tb_ProductImage.idDefault,tb_LoaiSanPham.biDanhLSP ,tb_LoaiSanPham.tieuDeLSP,TB_PRODUCT.ID,TB_PRODUCT.tieuDe, Quantity, Price, Pricesales, TB_PRODUCT.biDanh,TB_PRODUCT.isSale , TB_PRODUCT.ProductCategoryId, TB_PRODUCT.SeoMoTa, TB_PRODUCT.SeoTieuDe, TB_PRODUCT.SeoTuKhoa from TB_PRODUCT , tb_ProductImage, tb_LoaiSanPham  where TB_PRODUCT.ID = ProductId and TB_PRODUCT.ProductCategoryId= tb_LoaiSanPham.ID and tb_ProductImage.ProductId=" + id + "";
            con = new SqlConnection(constr);
            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sqlSP, con);
            DataAdapter.Fill(table);
            product_image sp = new product_image();
            foreach (DataRow dr in table.Rows)
            {

                sp.id = (int)dr["Id"];
                sp.productCategoryID = (int)dr["ProductCategoryId"];
                sp.TieuDeLSP = dr["tieuDeLSP"].ToString();
                sp.tieuDe = dr["tieuDe"].ToString();
                sp.image = dr["image"].ToString();
                sp.quantity = (int)dr["Quantity"];
                sp.biDanh = dr["biDanh"].ToString();
                sp.price = (decimal)dr["price"];
                sp.price = (decimal)dr["price"];
                sp.ChiTiet = dr["ChiTiet"].ToString();

                sp.pricesale = (decimal)dr["Pricesales"];
                sp.idDefault = bool.Parse(dr["idDefault"].ToString());
                sp.SeoTieuDe = dr["SeoTieuDe"].ToString();
                sp.SeoMoTa = dr["SeoMoTa"].ToString();
                sp.SeoTuKhoa = dr["SeoTuKhoa"].ToString();
            }
            return sp;
        }
        public List<ProductImage> GetProductImages(int id)
        {
             List<ProductImage> productImages = new List<ProductImage>();

            string sqlSP = "  select IDImage, ProductId, image, idDefault from tb_ProductImage where ProductId= "+id+"";
            con = new SqlConnection(constr);
            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sqlSP, con);
            DataAdapter.Fill(table);
            foreach (DataRow dr in table.Rows)
            {
                var sp = new ProductImage();
                sp.image = dr["image"].ToString();
                sp.id = (int)dr["IDImage"];
                sp.ProductId = (int)dr["ProductId"];
                sp.idDefault = bool.Parse(dr["idDefault"].ToString());
          
                productImages.Add(sp);

            }
            return productImages;
        }
        public string GetProductImagesBia(int id)
        {
            string sqlSP = " select image from tb_ProductImage where ProductId= "+id+" and idDefault='True'";
            con = new SqlConnection(constr);
            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sqlSP, con);
            DataAdapter.Fill(table);
            string urlAnhBia = "";
            foreach (DataRow dr in table.Rows)
            {
                urlAnhBia = dr["image"].ToString();
              
            }

            return urlAnhBia;
        }

        public void inserProducts(string tieude, string chiTiet, string moTa, string image, string seoTieuDe, string seoMoTa, string seoTuKhoa, System.DateTime CreateDate, int category_id, string bidanh/*, bool isActive*/, string CreatedBy)
        {
            string sqlInsert = "INSERT INTO tb_ThongBaoMoi (tieuDe, Categoryld, moTa, ChiTiet, image, SeoTieuDe, SeoMoTa, SeoTuKhoa, biDanh,  CreatedDate, CreatedBy)" +
                "VALUES (N'" + tieude + "', " + category_id + ", N'" + moTa + "', N'" + chiTiet + "', '" + image + "', N'" + seoTieuDe + "',N'" + seoMoTa + "', N'" + seoTuKhoa + "', '" + bidanh + "', '" + CreateDate + "', N'" + CreatedBy + "');";
            //string sqlInsert = "INSERT INTO tb_ThongBaoMoi (tieuDe, Categoryld, moTa, ChiTiet, image, SeoTieuDe, SeoMoTa, SeoTuKhoa, biDanh, IsActive, CreatedDate, CreatedBy)" +
            //"VALUES (N'" + tieude + "', " + category_id + ", N'" + moTa + "', N'" + chiTiet + "', '" + image + "', N'" + seoTieuDe + "',N'" + seoMoTa + "', N'" + seoTuKhoa + "', '" + bidanh + "', " + isActive + ", '" + CreateDate + "', N'" + CreatedBy + "');";

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
                news.ChiTiet = dr["ChiTiet"].ToString();
                news.image = dr["image"].ToString();
            }
            con.Close();
            return news;

        }
        public void editNews(int id, string tieude, string mota, string chitiet, string image, string seoTieude, string seomota, string seoTuKhoa, string modifiby, DateTime ModifiedDate, string bidanh)
        {
            string updateSQL = "update tb_ThongBaoMoi " +
                " set tieuDe=N'" + tieude + "',moTa=N'" + mota + "', ChiTiet=N'" + chitiet + "', image='" + image + "', SeoTieuDe=N'" + seoTieude + "', SeoMoTa=N'" + seomota + "', SeoTuKhoa=N'" + seoTuKhoa + "', ModifiedBy=N'" + modifiby + "', ModifiedDate= '" + ModifiedDate + "', bidanh='" + bidanh + "'" +
                " where ID= " + id + ";";
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
                lstLoaiSp.Add(laoiSp);
            }
            return lstLoaiSp;
        }
 
        public void InsertProductImages(int productId, string image, bool Isdefault, DateTime createDate, string createBY)
        {

                string sqlInsert = "insert into tb_ProductImage(ProductId, image, idDefault, CreatedDate, Craetedby) " +
                    "values(" + productId + ", '" + image + "', '" + Isdefault + "', '" + createDate + "',  '" + createBY + "' )";
            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlInsert, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void insertIntoProduct(string tieude, int ProductCategoryId, string productCode, string moTa, string ChiTiet, decimal Price, decimal Pricesales, int Quantity, DateTime CreatedDate, string CreatedBy, string SeoMoTa, string SeoTuKhoa, string seoTieuDe, bool isHome, bool isFeature, bool isHost, bool isSale, string bidanh)
        {
            string sqlInsert = "insert into TB_PRODUCT(tieuDe,ProductCategoryId ,productCode,moTa,ChiTiet,Price, Pricesales, Quantity, CreatedDate, CreatedBy, SeoMoTa, SeoTuKhoa, SeoTieuDe, isHome, isFeature, isHost, isSale, biDanh)" +
                " values(N'" + tieude + "'," + ProductCategoryId + ", '" + productCode + "', N'" + moTa + "', N'" + ChiTiet + "', " + Price + ", " + Pricesales + ", " + Quantity + ", '" + CreatedDate + "', N'" + CreatedBy + "', N'" + SeoMoTa + "', N'" + SeoTuKhoa + "', N'" + seoTieuDe + "', '" + isHome + "', '" + isFeature + "', '" + isHost + "', '" + isSale + "', '"+ bidanh + "')";
            con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand(sqlInsert, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public int getID()
        {
            string sqlInsert = "select max(id) from TB_PRODUCT";
            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlInsert, con);
            int k = (int)cmd.ExecuteScalar();
            con.Close();
            return k;

        }

        public string GetDefaultProductImage(int productId)
        {
            string image = null;

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string sqlSelect = "SELECT Image FROM tb_ProductImage WHERE ProductId = @ProductId AND idDefault = 'True'";
                SqlCommand cmd = new SqlCommand(sqlSelect, con);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    image = result.ToString();
                }

                con.Close();
            }

            return image;
        }
        public product Showproduct(int id)
        {
     
            string sqlSP = "select * from TB_PRODUCT where id = "+id+"";
            con = new SqlConnection(constr);
            DataTable table = new DataTable();
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sqlSP, con);
            DataAdapter.Fill(table);
            var sp = new product();
            foreach (DataRow dr in table.Rows)
            {
                sp.tieuDe = dr["tieuDe"].ToString();
                sp.productCode = dr["productCode"].ToString();
                sp.moTa = dr["moTa"].ToString();
                sp.productCategoryID= Convert.ToInt32(dr["productCategoryID"].ToString());
                sp.CreatyBy = dr["CreatedBy"].ToString();
                sp.ChiTiet = dr["ChiTiet"].ToString();
                sp.quantity = Convert.ToInt32(dr["quantity"].ToString());
                sp.price = (decimal)dr["Price"];
                sp.priceSale = (decimal)dr["Pricesales"];
                sp.SeoMoTa = dr["SeoMoTa"].ToString();
                sp.SeoTuKhoa = dr["SeoTuKhoa"].ToString();
                sp.SeoTieuDe = dr["SeoTieuDe"].ToString();
            }
            return sp;
        }
        public void editProduct(int id, string tieude, int ProductCategoryId, string productCode, string moTa, string ChiTiet, decimal Price, decimal Pricesales, int Quantity, System.DateTime ModifiedDate, string ModifiedBy, string SeoMoTa, string SeoTuKhoa, string seoTieuDe, bool isHome, bool isFeature, bool isHost, bool isSale, string Tenbidanh)
        {
            string sqlInsert = "UPDATE TB_PRODUCT" +
                " SET tieuDe = N'"+tieude+"', ProductCategoryId = "+ProductCategoryId+", productCode='"+productCode+"', moTa= N'"+moTa+"', ChiTiet=N'"+ChiTiet+"', Price="+Price+", Pricesales="+Pricesales+", Quantity= "+Quantity+ ",  SeoMoTa=N'"+SeoMoTa+"',SeoTuKhoa=N'"+SeoTuKhoa+"', SeoTieuDe=N'"+seoTieuDe+"', isHome='"+isHome+"',isFeature ='"+isFeature+"', isHost='"+isHost+"', isSale='"+isSale+"', biDanh='"+Tenbidanh+"'" +
                " WHERE id="+id+"";

            con = new SqlConnection(constr);

            con.Open();
            SqlCommand cmd = new SqlCommand(sqlInsert, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteProducts(int id)
        {

            string sqlDelte = "DELETE FROM  TB_PRODUCT where Id=" + id + ";";
            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlDelte, con);
             cmd.ExecuteNonQuery();
            con.Close();
     

        }
        public int deleteIamge(int id)
        {

            string sqlDelte = "DELETE FROM  tb_ProductImage where ProductId=" + id + ";";
            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlDelte, con);
            int k = cmd.ExecuteNonQuery();
            con.Close();
            return k;
           

        }
       






    }
}