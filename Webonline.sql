CREATE DATABASE WEBSITE_BANHANG
GO
USE WEBSITE_BANHANG
go

CREATE TABLE tb_Category
(
	ID INT PRIMARY KEY identiTy(1,1),
	TieuDe nvarchar(150),
	SeoTieuDe nvarchar(250), 
	MieuTa nvarchar(500),
	SeoMoTa nvarchar(500),
	SeoTuKhoa nvarchar(250),
	CreatyDate  datetime,
	CreatyBy nvarchar(150),
	biDanh nvarchar(150), 
	ChucVu int, 
    isActive varchar(10),
	idNhanVien int 
)

CREATE TABLE tb_LoaiSanPham
(
	ID int primary key identity(1, 1), 
	tieuDeLSP  nvarchar(150),
	CreatedDate datetime,
	SeoMoTa nvarchar(500),
	SeoTuKhoa nvarchar(250),
	SeoTieuDe nvarchar(250), 
	biDanhLSP nvarchar(150),  
	icon nvarchar(300),


)

CREATE TABLE TB_PRODUCT(
	ID int primary key identity(1, 1),
	tieuDe  nvarchar(150),
	ProductCategoryId  int,	
	productCode nvarchar(100),
	moTa nvarchar(150),
	ChiTiet  nvarchar(MAX),
	Price decimal(18, 2),
	Pricesales decimal(18,2),
	Quantity int,
	CreatedDate datetime,
	CreatedBy nvarchar(250),
	SeoMoTa nvarchar(500),
	SeoTuKhoa nvarchar(250),
	SeoTieuDe nvarchar(250), 
	isHome varchar(10),
	isFeature varchar(10),
	isHost varchar(10),
	isSale varchar(10),
	biDanh nvarchar(150),

)

CREATE TABLE tb_ThongBaoMoi
(
	ID int primary key identity(1,1),
	tieuDe  nvarchar(150),
	Categoryld int,
	moTa  nvarchar(400),
	ChiTiet  nvarchar(max),
	image  nvarchar(500),
	SeoTieuDe  nvarchar(250),
	SeoMoTa  nvarchar(550),
	SeoTuKhoa  nvarchar(250),
	biDanh nvarchar(100),
	isActive varchar,
	ModifiedDate dateTime,
	ModifiedBy nvarchar(150),
		idNhanVien int 

)

CREATE TABLE tb_postBaiViet(
	ID int primary key identity(1,1),
	tieuDe  nvarchar(250),
	CategoryID int,
	moTa  nvarchar(400),
	ChiTiet  nvarchar(max),
	image  nvarchar(500),
	SeoTieuDe  nvarchar(250),
	SeoMoTa  nvarchar(550),
	SeoTuKhoa  nvarchar(250),
	CreatedDate datetime,
	Craetedby nvarchar(250),
	ModifiedDate Datetime,
	ModifiedBy nvarchar(250),
	biDanh nvarchar(100),
	isActive varchar,
	idNhanVien int 
	
)

CREATE TABLE TB_datNhanThongBao
(
	ID int primary key identity(1,1),
	email nvarchar(150),
	name nvarchar(100),
	CreateDate DateTime,
	CreateBy nvarchar(250),
	ModifiedDate datetime,
	ModifiedBy nvarchar(250),

)




CREATE TABLE tb_Order
(
	ID int primary key identity(1,1),
	MaSanPham nvarchar(200),
	Tenkh nvarchar(100),
	Phone nvarchar(100),
	address nvarchar(200),
	tongTien decimal ,
	CreatedDate datetime,
	Craetedby nvarchar(250),
	idKhacHang int,
	Email nvarchar(200)

)


CREATE TABLE tb_orderDeTail(
	 ID int primary key identity(1,1),
	 orderId  int ,
	 ProductId  int,
	 price  decimal(18,2),
	 Quantity  int,

)



CREATE TABLE tb_ProductImage(
	IDImage int primary key identiTy(1,1),
	ProductId int,
	image nvarchar(100),
	idDefault varchar(10),
	CreatedDate datetime,
	Craetedby nvarchar(250),
	ModifiedDate Datetime,
	ModifiedBy nvarchar(250)
)



-- Tạo bảng NHANVIEN
CREATE TABLE NHANVIEN (
    ID int PRIMARY KEY IDENTITY(1,1),
    tenNhanVien nvarchar(100),
    SDT varchar(20),
    NgaySinh date,
    DiaChi nvarchar(100),
    idPhanQuyen int,
    UserNmae varchar(200),
    passWord varchar(200),

);

CREATE TABLE KHACHHANG(
 ID int PRIMARY KEY IDENTITY(1,1),
 PHONE VARCHAR(11),
 ADDRESS NVARCHAR(100),
 EMAIL VARCHAR(50),
 USERNAME VARCHAR(50),
 PASSSWORD VARCHAR(50),
 NgaySinh date,
 tenKhachHang nvarchar(500)

)

CREATE TABLE ACOUNT(
 USERNAME VARCHAR(50),
  PASSSWORD VARCHAR(50),
  ROLE int,
  PRIMARY KEY(USERNAME)
)

-- Tạo bảng PHANQUYEN
CREATE TABLE PHANQUYEN (
    ID int PRIMARY KEY IDENTITY(1,1),
    tenQuyen nvarchar(100)  -- Đảm bảo rằng bạn đã đặt độ dài cho trường nvarchar
);


CREATE TABLE CHUCNANG(
	ID int primary key identiTy(1,1),
	tenChucNang nvarchar(100),
	MaChucNang nvarchar(100)
)
CREATE TABLE NhanVien_ChucNang(
	IDnhanVien int,
	IDnchucNang int,
	GhiChu nvarchar(50),
	primary key(IDnhanVien, IDnchucNang)
)


ALTER TABLE NhanVien_ChucNang
ADD CONSTRAINT FK_NhanVienChucNang
FOREIGN KEY (IDnhanVien) REFERENCES NHANVIEN(ID);

ALTER TABLE NhanVien_ChucNang
ADD CONSTRAINT FK_ChucNangPhanQuyen
FOREIGN KEY (IDnchucNang) REFERENCES CHUCNANG(ID);

-- Thêm khóa ngoại từ bảng NHANVIEN tới bảng PHANQUYEN
ALTER TABLE NHANVIEN
ADD CONSTRAINT FK_NhanVienPHANQUYEN
FOREIGN KEY (idPhanQuyen) 
REFERENCES PHANQUYEN(ID);


-- Thêm khóa ngoại từ trường ProductId của tb_OrderDetail đến trường Id của tb_Product
ALTER TABLE tb_OrderDetail
ADD CONSTRAINT FK_tb_OrderDetail_Product
FOREIGN KEY (ProductId)
REFERENCES tb_Product(Id);

-- Thêm khóa ngoại từ trường CategoryId của tb_postBaiViet đến trường Id của tb_Category
ALTER TABLE tb_postBaiViet
ADD CONSTRAINT FK_tb_Posts_Category
FOREIGN KEY (CategoryId)
REFERENCES tb_Category(Id);
-- Thêm khóa ngoại từ trường ProductCategoryId của tb_Product đến trường Id của tb_Category
ALTER TABLE tb_Product
ADD CONSTRAINT FK_tb_Product_Category
FOREIGN KEY (ProductCategoryId)
REFERENCES tb_Category(Id);
ALTER TABLE tb_Product
DROP CONSTRAINT FK_tb_Product_Category;


-- Thêm khóa ngoại từ trường ProductId của tb_ProductImage đến trường Id của tb_Product
ALTER TABLE tb_ProductImage
ADD CONSTRAINT FK_tb_ProductImage_Product
FOREIGN KEY (ProductId)
REFERENCES tb_Product(Id);

ALTER TABLE tb_Category
ADD CONSTRAINT FK_tb_Category_NhanVien
FOREIGN KEY (idNhanVien)
REFERENCES NHANVIEN(ID);

-- Thêm trường khóa ngoại "OrderId" trong bảng tb_orderDetail
ALTER TABLE tb_orderDetail
ADD CONSTRAINT FK_tb_orderDetail_tb_order
FOREIGN KEY (orderId)
REFERENCES tb_order(ID);

-- Thêm trường khóa ngoại "Categoryld" trong bảng tb_ThongBaoMoi
ALTER TABLE tb_ThongBaoMoi
ADD CONSTRAINT FK_tb_ThongBaoMoi_tb_Category
FOREIGN KEY (Categoryld)
REFERENCES tb_Category(ID);

-- Thêm trường khóa ngoại "ProductCategoryId" trong bảng TB_PRODUCT
ALTER TABLE TB_PRODUCT
ADD CONSTRAINT FK_TB_PRODUCT_tb_LoaiSanPham
FOREIGN KEY (ProductCategoryId)
REFERENCES tb_LoaiSanPham(ID);


ALTER TABLE tb_ThongBaoMoi
ADD CONSTRAINT FK_THONGBAO_NHANVIEN
FOREIGN KEY (idNHanVien)
REFERENCES NHANVIEN(ID);

ALTER TABLE tb_Category
ADD CONSTRAINT FK_tb_Category_NhanVien
FOREIGN KEY (idNhanVien)
REFERENCES NHANVIEN(ID);

ALTER TABLE tb_Order
ADD CONSTRAINT FK_tb_Order_KHACHHANG
FOREIGN KEY (idKhacHang)
REFERENCES KHACHHANG(ID);

select * from KHACHHANG
select * from TB_datNhanThongBao

ALTER TABLE TB_datNhanThongBao
DROP COLUMN ModifiedDate;
ALTER TABLE TB_datNhanThongBao
DROP COLUMN ModifiedBy;
ALTER TABLE TB_datNhanThongBao
DROP COLUMN CreateBy;



select biDanhLSP from tb_LoaiSanPham

select * from tb_Order
select * from tb_orderDeTail



select * from ACOUNT
select * from NHANVIEN

select * from tb_Category

CREATE TABLE tb_ThongBaoMoi
(
	ID int primary key identity(1,1),
	tieuDe  nvarchar(150),
	Categoryld int,
	moTa  nvarchar(400),
	ChiTiet  nvarchar(max),
	image  nvarchar(500),
	SeoTieuDe  nvarchar(250),
	SeoMoTa  nvarchar(550),
	SeoTuKhoa  nvarchar(250),
	biDanh nvarchar(100),
	isActive varchar,
	ModifiedDate dateTime,
	ModifiedBy nvarchar(150),
		idNhanVien int 

)

