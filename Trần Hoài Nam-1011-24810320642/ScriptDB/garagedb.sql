create database garagedb;
go
use garagedb;
go

create table khachhang (
    makh int identity(1,1) primary key,
    tenkh nvarchar(100) not null,
    dienthoai varchar(15) unique,
    diachi nvarchar(200)
);

create table xe (
    bienso varchar(20) primary key,
    makh int foreign key references khachhang(makh),
    hieuxe nvarchar(50),
    namsanxuat int
);

create table phutung (
    maphutung int identity(1,1) primary key,
    tenphutung nvarchar(150) not null,
    dongia decimal(18,2),
    soluongton int check (soluongton >= 0)
);

create table phieusuachua (
    maphieu int identity(1,1) primary key,
    bienso varchar(20) foreign key references xe(bienso),
    ngaynhan datetime default getdate(),
    noidungsua nvarchar(max),
    tongtien decimal(18,2),
    trangthai nvarchar(30)
);

create table chitietsuachua (
    maphieu int foreign key references phieusuachua(maphieu),
    maphutung int foreign key references phutung(maphutung),
    soluong int check (soluong > 0),
    tiencong decimal(18,2),
    primary key (maphieu, maphutung)
);

insert into khachhang (tenkh, dienthoai, diachi) values 
(N'nguyễn văn an', '0901234567', N'123 nguyễn trãi, hà nội'),
(N'trần văn bình', '0912345678', N'456 lê lợi, hà nội');

insert into xe (bienso, makh, hieuxe, namsanxuat) values 
('30a-12345', 1, N'toyota camry', 2021),
('29b-98765', 2, N'honda cr-v', 2023);

insert into phutung (tenphutung, dongia, soluongton) values 
(N'lọc nhớt ô tô', 150000, 50),
(N'má phanh trước', 850000, 20),
(N'dầu động cơ 4l', 650000, 30);
go