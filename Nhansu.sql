--Store lấy thông tin về nhansu :
 create proc showns
       as
       begin
       select *from Nhansu
       end
--Store thực hiện insert 1 hạn nộp mới,delete hạn nộp,update hạn nộp,tìm kiếm

		Create proc nhansu_insert(
     @ngaysinh date,
	@ten nvarchar(50),
	@ma varchar (10),
	@quequan nvarchar (100),
	@hesoluong varchar(20),
	@phongbanma varchar(10)
	)
	as
	begin
 Insert into dbo.Nhansu( ngaysinh , ten , ma , quequan , hesoluong, phongbanma) 
			values(@ngaysinh,@ten,@ma,@quequan,@hesoluong,@phongbanma)
	end
	go

	
Create proc Nhansu_delete(
    @ngaysinh date,
	@ten nvarchar(50),
	@ma varchar (10),
	@quequan nvarchar (100),
	@hesoluong varchar(20),
	@phongbanma varchar(10)
	)
	as
begin
Delete from nhansu where ma = @ma
end
go

	Create proc Nhansu_update(
      @ngaysinh date,
	@ten nvarchar(50),
	@ma varchar (10),
	@quequan nvarchar (100),
	@hesoluong varchar(20),
	@phongbanma varchar(10)
	)
	as
   Update Nhansu SET
		   ngaysinh = @ngaysinh ,
	ten = @ten ,
	ma = @ma ,
	quequan =@quequan ,
	hesoluong = @hesoluong ,
	phongbanma = @phongbanma 
            Where ma = @ma


create proc Nhansu_Search
        @ma varchar(10)
        as
        begin
        select * from Nhansu where ma = @ma
        end
