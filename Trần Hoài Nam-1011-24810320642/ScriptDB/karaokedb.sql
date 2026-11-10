create database karaokedb;
go
use karaokedb;
go

create table phonghat (
    maphong int identity(1,1) primary key,
    tenphong nvarchar(50) not null,
    loaiphong nvarchar(30),
    giatheogio decimal(18,2),
    trangthai nvarchar(20) default N'trống'
);

create table dichvu (
    madv int identity(1,1) primary key,
    tendv nvarchar(100) not null,
    dongia decimal(18,2),
    tonkho int
);

create table hoadon (
    mahd int identity(1,1) primary key,
    maphong int foreign key references phonghat(maphong),
    giovao datetime not null,
    giora datetime null,
    tongtienphong decimal(18,2),
    tongtiendichvu decimal(18,2),
    trangthai bit default 0
);

create table chitietdichvu (
    mahd int foreign key references hoadon(mahd),
    madv int foreign key references dichvu(madv),
    soluong int check (soluong > 0),
    dongia decimal(18,2),
    primary key (mahd, madv)
);

insert into phonghat (tenphong, loaiphong, giatheogio, trangthai) values 
(N'phòng vip 01', N'vip', 250000, N'trống'),
(N'phòng vip 02', N'vip', 250000, N'trống'),
(N'phòng thường 01', N'thường', 150000, N'trống'),
(N'phòng thường 02', N'thường', 150000, N'trống');

insert into dichvu (tendv, dongia, tonkho) values 
(N'bia heineken', 35000, 200),
(N'trái cây dĩa lớn', 120000, 50),
(N'nước suối', 15000, 150);
go