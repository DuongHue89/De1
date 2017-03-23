--Store lấy thông tin về phongban :
 create proc showpb
       as
       begin
       select *from phongban
       end
--Store thực hiện insert ,delete,update ,tìm kiếm

		Create proc phongban_insert(
		@ma varchar (10),

     
	@ten nvarchar(50),
	@diachi nvarchar(50),
	@sodienthoai varchar(20)
	)
	as
	begin
 Insert into phongban( ma, ten, diachi , sodienthoai) 
			values(@ma, @ten, @diachi, @sodienthoai)
	end
	go

	
Create proc phongban_delete(
  @ma varchar (10),

     
	@ten nvarchar(50),
	@diachi nvarchar(50),
	@sodienthoai varchar(20)
	)
	as
begin
Delete from phongban where ma = @ma
end
go

	Create proc phongban_update(
     @ma varchar (10),

     
	@ten nvarchar(50),
	@diachi nvarchar(50),
	@sodienthoai varchar(20)
	)
	as
   Update phongban SET
		ma =  @ma ,
		ten = @ten ,
		diachi = @diachi ,
		sodienthoai = @sodienthoai 
            Where ma = @ma


create proc phongban_Search
        @ma varchar(10)
        as
        begin
        select * from phongban where ma = @ma
        end
