use master

if exists (select * from sys.databases where name='QLCHMT')
drop database QLCHMT

go

create database QLCHMT
go
use QLCHMT
go

create table TaiKhoan(
	UserName varchar(255) primary key,
	Password varchar(255),
	TenHienThi nvarchar(255),
	LoaiTaiKhoan int --0:admin       1:member
)
go
create table DanhMuc(
	ID int identity primary key,
	TenDanhMuc nvarchar(255)
)
go
create table MayTinh(
	Ma varchar(255) primary key,
	Ten nvarchar(255),
	IdDanhMuc int,
	Anh nvarchar(255),
	DonGiaNhap int,
	DonGiaXuat int,
	SoLuong int,
	ChiTiet ntext,
)
go
create table Nhap(
	ID int identity primary key,
	MaNhaCungCap varchar(255),
	NgayNhap datetime,
	NguoiNhapHang varchar(255)
)



go
create table Xuat(
	ID int identity primary key,
	IdKhachHang varchar(20),
	NgayXuat datetime,
	NguoiBanHang varchar(255)
)
go
create table CTNhap(
	ID int identity primary key,
	IdNhap int,
	MaMayTinh varchar(255),
	SoLuong int
)
go
create table CTXuat(
	ID int identity primary key,
	IdXuat int,
	MaMayTinh varchar(255),
	SoLuong int
)
go
create table KhachHang(
	Cmtnd varchar(20) primary key,
	Ten nvarchar(255),
	DiaChi nvarchar(255),
	Tuoi int,
	SoDienThoai varchar(20),
	Email nvarchar(255)
)
go
create table NhaCungCap(
	Ma varchar(255) primary key,
	Ten nvarchar(255),
	DiaChi nvarchar(255),
	Email varchar(255),
	SoDienThoai varchar(20)
)

go
alter table MayTinh
add foreign key(IdDanhMuc) references DanhMuc(ID)


go
alter table CTNhap
add foreign key(IdNhap) references Nhap(ID)
on delete cascade 
on update cascade

go
alter table CTXuat
add foreign key(IdXuat) references Xuat(ID)
on delete cascade 
on update cascade

go
alter table Nhap
add foreign key(MaNhaCungCap) references NhaCungCap(Ma)


go
alter table Xuat
add foreign key(IdKhachHang) references KhachHang(Cmtnd)


go
alter table CTNhap
add foreign key(MaMayTinh) references MayTinh(Ma)


go
alter table CTXuat
add foreign key(MaMayTinh) references MayTinh(Ma)


go
alter table Nhap
add foreign key(NguoiNhapHang) references TaiKhoan(UserName)


go
alter table Xuat
add foreign key(NguoiBanHang) references TaiKhoan(UserName)


go
insert into TaiKhoan(UserName,Password,TenHienThi,LoaiTaiKhoan) values('Admin','12345','SuperAdmin',0)
insert into TaiKhoan(UserName,Password,TenHienThi,LoaiTaiKhoan) values('Member','12345','member',1)

go
insert into NhaCungCap(Ma,Ten,DiaChi,SoDienThoai,Email) values('NCC01',N'nhà cung cấp số 1',N'Hà Nội','0123456789','ncc1@gmail.com')
insert into NhaCungCap(Ma,Ten,DiaChi,SoDienThoai,Email) values('NCC02',N'nhà cung cấp số 2',N'Thái Bình','0987654321','ncc2@gmail.com')
go
insert into DanhMuc(TenDanhMuc) values('Dell')
insert into DanhMuc(TenDanhMuc) values('Mac')
insert into DanhMuc(TenDanhMuc) values('Asus')
go
insert into MayTinh(Ma,IdDanhMuc,Ten,DonGiaNhap,DonGiaXuat,SoLuong,ChiTiet,Anh) values('Dell-123',1,'dell 123',8000000,9000000,10,N'chi tiet',null)
insert into MayTinh(Ma,IdDanhMuc,Ten,DonGiaNhap,DonGiaXuat,SoLuong,ChiTiet,Anh) values('Asus-123',3,'asus 123',10000000,12000000,10,N'chi tiet',null)


go


create proc uspCheckLogin --@username = 'admin', @password = '12345'
@username varchar(255),
@password varchar(255)
as
begin
	select * from TaiKhoan
	where UserName = @username and Password = @password
end




go
create proc uspInsertNhap-- 'NCC01','admin'
@maNhaCC varchar(255),
@nguoiNhap varchar(255)
as
begin
	insert Nhap(MaNhaCungCap, NgayNhap, NguoiNhapHang) values(@maNhaCC,getdate(),@nguoiNhap)
	select max(id) as 'ID' from Nhap
end
go

go
create proc uspInsertXuat-- 'NCC01','admin'
@idKhachHang varchar(255),
@nguoiXuat varchar(255)
as
begin
	insert Xuat(IdKhachHang, NgayXuat, NguoiBanHang) values(@idKhachHang,getdate(),@nguoiXuat)
	select max(id) as 'ID' from Xuat
end
go
create proc uspAddChiTietNhap 
@idNhap int,
@maMayTinh varchar(255),
@soLuong int
as
begin 

	update MayTinh set SoLuong = SoLuong + @soLuong where ma = @maMayTinh
	
	insert CTNhap(IdNhap,MaMayTinh,SoLuong) values(@idNhap, @maMayTinh, @soLuong)

end
go
create proc uspDelChiTietNhap 
@id int
as
begin 
	declare @maMayTinh varchar(255) = (select MaMayTinh from CTNhap where id = @id)
	declare @soLuong int = (select SoLuong from CTNhap where id = @id)
	update MayTinh set SoLuong = SoLuong - @soLuong where ma = @maMayTinh
	
	delete CTNhap where id = @id

end
go

create proc uspAddChiTietXuat
@idXuat int,
@maMayTinh varchar(255),
@soLuong int
as
begin 
	declare @sl int = (select SoLuong from MayTinh where ma = @maMayTinh)
	if(@sl < @soLuong)
	begin
		return
	end

	update MayTinh set SoLuong = SoLuong - @soLuong where ma = @maMayTinh
	
	insert CTXuat(IdXuat,MaMayTinh,SoLuong) values(@idXuat, @maMayTinh, @soLuong)

end
go
create proc uspDelChiTietXuat 
@id int
as
begin 
	declare @maMayTinh varchar(255) = (select MaMayTinh from CTXuat where id = @id)
	declare @soLuong int = (select SoLuong from CTXuat where id = @id)
	update MayTinh set SoLuong = SoLuong + @soLuong where ma = @maMayTinh
	delete CTXuat where id = @id

end
go





go


create proc uspGetTotalPriceByIDNhap
@id int
as
begin
	select sum(CTNhap.SoLuong*MayTinh.DonGiaNhap) as 'TotalPrice'
	from CTNhap join MayTinh on CTNhap.MaMayTinh = MayTinh.Ma
	where CTNhap.IdNhap = @id
end
go

go
create proc uspGetTotalPriceByIDXuat 
@id int
as
begin
	select sum(CTXuat.SoLuong*MayTinh.DonGiaXuat) as 'TotalPrice'
	from CTXuat join MayTinh on CTXuat.MaMayTinh = MayTinh.Ma
	where CTXuat.IdXuat = @id
end
go

create proc uspDelTaiKhoanByUserName
@username varchar(255)
as
begin
	update Nhap
	set NguoiNhapHang = null
	where NguoiNhapHang = @username

	update Xuat
	set NguoiBanHang = null
	where NguoiBanHang = @username

	delete TaiKhoan
	where UserName = @username
end
select * from Nhap

go
create proc uspGetHoaDonNhapByTime
@fromDay Datetime,
@toDay Datetime
as
select Nhap.ID, MaNhaCungCap,NgayNhap,NguoiNhapHang,TongTien
from Nhap join
	(select IdNhap, sum(CTNhap.SoLuong*DonGiaNhap) as 'TongTien'
	from CTNhap join MayTinh on CTNhap.MaMayTinh = MayTinh.Ma
	group by IdNhap) as tam on Nhap.ID = tam.IdNhap
where Nhap.NgayNhap <= @toDay and Nhap.NgayNhap >=@fromDay

go
create proc uspGetHoaDonXuatByTime
@fromDay Datetime,
@toDay Datetime
as

begin
select Xuat.ID, Ten,NgayXuat,NguoiBanHang,TongTien
from Xuat join
	(select IdXuat, sum(CTXuat.SoLuong*DonGiaXuat) as 'TongTien'
	from CTXuat join MayTinh on CTXuat.MaMayTinh = MayTinh.Ma
	group by IdXuat
	) as tam on Xuat.ID = tam.IdXuat
			join
	KhachHang on Xuat.IdKhachHang = KhachHang.Cmtnd
where Xuat.NgayXuat <= @toDay and Xuat.NgayXuat >=@fromDay
end


