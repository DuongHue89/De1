create table nhanvien
(
	manv varchar(20) primary key(manv),
	tennv nvarchar(100),
	ngaysinh datetime,
	sdt varchar(20),
	diachi nvarchar(100)
)
create table nhacc
(
	macc varchar(20) primary key (macc),
	tencc nvarchar(100),
	diachi nvarchar(100),
	sdt varchar(20),
	nuocsx nvarchar(50) 
)
create table loaihang
(
	maloaihang varchar(20) primary key (maloaihang),
	tenloaihang nvarchar(50),
	chitietloaihang nvarchar(100)
)
create table phieunhap
(
	mapn varchar(20) primary key (mapn),
	ngaynhap datetime,
	manv varchar(20)foreign key (manv) references nhanvien(manv),
)
create table chitietphieunhap(
	tenhang nvarchar(50),
	macc varchar(20)foreign key (macc) references nhacc(macc),
	mapn varchar(20)foreign key(mapn) references phieunhap(mapn),
	maloaihang varchar(20) foreign key (maloaihang) references loaihang(maloaihang),
	SLtheoLT int,
	SLthuc int,
	dongia bigint,
	thanhtien bigint
)

create table khohang
(
	mahang varchar(20) primary key,
	tenhang nvarchar(100),
	soluong int,
	gianhap int,
	giaxuat int,
	macc varchar(20)foreign key (macc) references nhacc(macc),
	maloaihang varchar(20) foreign key (maloaihang) references loaihang(maloaihang) 
)

create table khachhang
(
	makh varchar(20) primary key (makh),
	tenkh nvarchar(100),
	sdt varchar(20),
	diachi nvarchar(100)
)
create table phieuxuat
(
	mapx varchar(20) primary key (mapx),
	ngayxuat datetime,
	manv varchar(20)foreign key (manv) references nhanvien(manv),
	makh varchar(20)foreign key (makh) references khachhang(makh)
)
create table chitietphieuxuat
(
	mapx varchar(20)foreign key (mapx) references phieuxuat(mapx),
	mahang varchar(20)foreign key (mahang) references khohang(mahang),
	soluong int,
	dongia bigint
)
create table dangnhap
(
	username nvarchar(10) not null,
	pass nvarchar(10) not null 
)
/*================================================================*/

--proc them nhân viên
create proc themnv @manv varchar(20), @tennv nvarchar(100),@ngaysinh datetime,@sdt varchar(20),@diachi nvarchar(100)
as
begin
if exists(select manv from nhanvien where manv=@manv)
	print 'Da ton tai nhan vien'
else insert into nhanvien (manv,tennv,ngaysinh,sdt,diachi)
	values (@manv,@tennv,@ngaysinh,@sdt,@diachi)
end

--proc xóa nhanvien
create proc xoanv @manv varchar(20)
as
begin
if not exists(select manv from nhanvien where manv=@manv)
	print'Khong ton tai nhan vien'
else		
update phieunhap set manv=null where manv=@manv
update phieuxuat set manv=null where manv=@manv
delete nhanvien where manv=@manv
end

--trigger mahang tự tăng
CREATE TRIGGER themhang
ON khohang
FOR INSERT
AS
BEGIN
DECLARE @MAXValue VARCHAR(20),@NEWValue VARCHAR(20),@NEW_ID VARCHAR(20), @OLD_ID VARCHAR(20);
SELECT @MAXValue = MAX(mahang) FROM khohang
select @OLD_ID = mahang from INSERTED
SET @NEWValue= REPLACE(@MaxValue,'H','')+1
SET @NEW_ID = 'H'+
    CASE
       WHEN LEN(@NEWValue)<3
          THEN REPLICATE('0',3-LEN(@newValue))
          ELSE ''
       END +
       @NEWValue
UPDATE khohang SET mahang = @NEW_ID WHERE mahang = @OLD_ID
END


--proc thêm phiếu nhập
create proc thempn @mapn varchar(20), @ngaynhap datetime,@manv varchar(20)
as
begin 
insert into phieunhap values(@mapn,@ngaynhap,@manv)
end
        
--proc xoaphieunhap
CREate proc xoaphieunhap @mapn varchar(20)
as
begin
delete chitietphieunhap where mapn=@mapn
delete phieunhap where mapn=@mapn
end

--them chitietphieunhap
create proc themchitietpn @macc varchar(20),@mapn varchar(20),@SLtheoLT int,@maloaihang varchar(20),@SLthuc int,@dongia bigint,@thanhtien bigint,@tenhang nvarchar(50)
as
begin
insert into chitietphieunhap values(@tenhang,@macc,@mapn,@maloaihang,@SLtheoLT,@SLthuc,@dongia,@thanhtien)
if exists(select maloaihang,macc,tenhang from khohang where maloaihang=@maloaihang and tenhang=@tenhang and macc=@macc)
	update khohang set soluong=soluong+@SLthuc where maloaihang=@maloaihang and tenhang=@tenhang and macc=@macc
else 
	insert into khohang(mahang,tenhang,soluong,gianhap,macc,maloaihang,giaxuat) values('',@tenhang,@SLthuc,@dongia,@macc,@maloaihang,@dongia+@dongia/2)
end


--proc them khachhang
create proc themkh @makh varchar(20), @tenkh nvarchar(100),@sdt varchar(20),@diachi nvarchar(100)
as
begin
if exists(select makh from khachhang where makh=@makh)
	print 'Da ton tai khach hang'
else insert into khachhang(makh,tenkh,sdt,diachi)
	values (@makh,@tenkh,@sdt,@diachi)
end

--proc xoa khachhang
create proc xoakh @makh varchar(20)
as
begin
if not exists(select makh from khachhang where makh=@makh)
	print'Khong ton tai khach hang'
else		
update phieuxuat set makh=null where makh=@makh;
delete khachhang where makh=@makh
end

--proc thêm phiếu xuất
create proc thempx @mapx varchar(20), @ngayxuat datetime, @manv varchar(20), @makh varchar(20)
as
begin 
	insert into phieuxuat(mapx,ngayxuat,manv,makh)
	values(@mapx,@ngayxuat,@manv,@makh)
end

--them chitietpx
create proc themchitietpx @mapx varchar(20), @mahang varchar(20), @soluong int, @dongia bigint
as
begin
if exists(select soluong from khohang where mahang=@mahang and soluong=0)
	print 'Hang nay da het'
if exists(select soluong from khohang where mahang=@mahang and soluong<@soluong)
	print 'Hang trong kho khong du'
else insert into chitietphieuxuat values(@mapx,@mahang,@soluong,@dongia)
update khohang set soluong=soluong-@soluong where mahang=@mahang
end 

--proc xóa phiếu xuất đồng thời 
create proc xoaphieuxuat @mapx varchar(20)
as
begin
if not exists(select mapx from phieuxuat where mapx=@mapx)
	print'Khong ton tai phieu xuat'
else 	
	delete chitietphieuxuat where mapx=@mapx;
	delete phieuxuat where mapx=@mapx 
end

--proc xoahanghoa trongkho
create proc xoahang @mahang varchar(20)
as
begin
update chitietphieuxuat set mahang=null where  mahang=@mahang
delete khohang where mahang=@mahang
end


--thong ke luu luong nhap hang
create proc luuluongnhap @thang int
as
begin
select mahang,khohang.tenhang,SLthuc,ngaynhap, manv, phieunhap.mapn 
from khohang,chitietphieunhap,phieunhap
where month(ngaynhap)=@thang and khohang.tenhang=chitietphieunhap.tenhang and chitietphieunhap.mapn=phieunhap.mapn
end

--thong ke luu luong xuat hang
create proc luuluongxuat @thang int
as
begin
select khohang.mahang,tenhang,chitietphieuxuat.soluong,ngayxuat,manv
from khohang,chitietphieuxuat,phieuxuat
where khohang.mahang=chitietphieuxuat.mahang and chitietphieuxuat.mapx=phieuxuat.mapx and month(ngayxuat)=@thang
end
--proc themuser
create proc themuser @username nvarchar(10), @pass nvarchar(10)
as
begin
insert into dangnhap values(@username,@pass)
end               



/*=========================================================*/
insert into nhanvien values
	('NV01',N'Nguyễn Văn A','10-11-1986','0123456789','Hà Nội'),
	('NV02',N'Trần Thị B','09-08-1986','0123456788','Hà Nội'),
	('NV03',N'Đinh Công C','08-09-1986','0123456787','Hà Nội'),
	('NV04',N'Vũ Liên D','07-10-1986','0123456786','Hà Nội'),
	('NV05',N'Phạm Tuấn E','06-12-1986','0123456785','Hà Nội')
insert into nhacc values
	('NCC01','A',N'Hà Nội','0969123456',N'Việt Nam'),
	('NCC02','B',N'TP Hồ Chí Minh','0969123455',N'Nhật Bản'),
	('NCC03','C',N'Hà Nội','0969123454',N'Hà Lan')
insert into loaihang values
	('01','Ly Nước',N'Đồ dễ vỡ'),
	('02','Tàu hỏa',N'Đồ chơi'),
	('03','Vở viết ',N'Đồ dùng học tập'),
	('04','Panado; Extra',N'Thuốc')
insert into khachhang values
	('KH01',N'Đinh Vân A','0975123456',N'Hà Nội'),
	('KH02',N'Nguyễn Thị M','0975123455',N'Hà Nội'),
	('KH03',N'Trương Văn N','0975123454',N'Hà Nội'),
	('KH04',N'Vương Thị H','0975123453',N'Hà Nội')
insert into dangnhap values 
	('NV01','123456'),
	('NV02','123456'),
	('NV03','123456'),
	('NV04','123456')
 