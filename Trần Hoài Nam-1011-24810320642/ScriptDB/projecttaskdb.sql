create database projecttaskdb;
go
use projecttaskdb;
go

create table duan (
    maduan int identity(1,1) primary key,
    tenduan nvarchar(150) not null,
    ngaybatdau datetime,
    ngayketthuc datetime,
    trangthai nvarchar(50)
);

create table thanhvien (
    mathanhvien int identity(1,1) primary key,
    hoten nvarchar(100) not null,
    email varchar(100) unique,
    chuyenmon nvarchar(100)
);

create table congviec (
    matask int identity(1,1) primary key,
    maduan int foreign key references duan(maduan),
    tentask nvarchar(200) not null,
    mota nvarchar(max),
    hannop datetime,
    douutien nvarchar(20),
    trangthai nvarchar(50)
);

create table phancong (
    matask int foreign key references congviec(matask),
    mathanhvien int foreign key references thanhvien(mathanhvien),
    ngaygiao datetime default getdate(),
    primary key (matask, mathanhvien)
);

insert into duan (tenduan, ngaybatdau, ngayketthuc, trangthai) values 
(N'hệ thống erp enterprise', '2026-01-01', '2026-06-30', N'đang chạy'),
(N'ứng dụng mobile banking', '2026-02-15', '2026-08-15', N'đang chạy');

insert into thanhvien (hoten, email, chuyenmon) values 
(N'nguyễn văn nam', 'nam.nv@example.com', N'backend developer'),
(N'trần thị hoa', 'hoa.tt@example.com', N'frontend developer'),
(N'lê hoàng long', 'long.lh@example.com', N'tester / qa');

insert into congviec (maduan, tentask, mota, hannop, douutien, trangthai) values 
(1, N'thiết kế cơ sở dữ liệu', N'xây dựng er diagram và script sql', '2026-02-01', N'cao', N'done'),
(1, N'xây dựng api đăng nhập', N'sử dụng jwt và oauth2', '2026-03-01', N'cao', N'in progress'),
(1, N'kiểm thử hiệu năng', N'test tải 10000 user', '2026-02-10', N'trung bình', N'to do');

insert into phancong (matask, mathanhvien, ngaygiao) values 
(1, 1, '2026-01-05'),
(2, 1, '2026-02-01'),
(3, 3, '2026-02-05');
go
select*from phancong