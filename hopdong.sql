--Store lấy thông tin về hopdong :
 create proc showhd
       as
       begin
       select *from hopdong
       end
--Store thực hiện insert ,delete,update ,tìm kiếm

		Create proc hopdong_insert(
		@ma varchar (10),

     
	@ten nvarchar(50),
	@ngayki date,
	@ngayhethan date,
	@nhanvienma varchar(10)
	)
	as
	begin
 Insert into hopdong( ma, ten, ngayki, ngayhethan, nhanvienma) 
			values(@ma, @ten, @ngayki, @ngayhethan, @nhanvienma)
	end
	go

	
Create proc hopdong_delete(
  @ma varchar (10),

     
	@ten nvarchar(50),
	@ngayki date,
	@ngayhethan date,
	@nhanvienma varchar(10)
	)
	as
begin
Delete from hopdong where ma = @ma
end
go

	Create proc hopdong_update(
     @ma varchar (10),

     
	@ten nvarchar(50),
	@ngayki date,
	@ngayhethan date,
	@nhanvienma varchar(10)
	)
	as
   Update hopdong SET
		ma =  @ma ,
		ten = @ten ,
		ngayki = @ngayki ,
		ngayhethan = @ngayhethan ,
		nhanvienma = @nhanvienma 
            Where ma = @ma


create proc hopdong_Search
        @ma varchar(10)
        as
        begin
        select * from hopdong where ma = @ma
        end
