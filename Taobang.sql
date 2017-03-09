create table Nhansu (
ten nvarchar(50) not null ,
ma varchar(10) primary key,
ngaysinh datetime not null,
quequan nvarchar(100) not null,
hesoluong varchar(20) not null,
phongbanma varchar(10)  not null ,
--ma varchar(10) references bomon(ma) notnull,
);
create table phongban(
ma varchar(10) primary key not null,
ten nvarchar(50) not null ,
diachi nvarchar(50) not null ,
sodienthoai nvarchar(20) not null,
);
create table hopdong(
ma varchar(10) not null,
ten nvarchar(50) not null,
ngayki datetime not null ,
ngayhethan datetime not null,
nhanvienma varchar(10),
);