# BÁO CÁO BÀI TẬP / ĐỒ ÁN

## THÔNG TIN SINH VIÊN
- **Họ và tên:** Trần Hoài Nam
- **Mã số sinh viên:** 24810320642
- **Lớp:** D19QTANM1
- **Tên môn học:** Lập trình C# / Windows Forms
- **Tên bài tập:** ÔN TẬP WINDOW FORM (BÀI 6.3, 6.4, 6.5)

---

## CÔNG NGHỆ SỬ DỤNG

- **Ngôn ngữ & Nền tảng:** C# (.NET Framework / .NET Core), WinForms (Windows Desktop Application).
- **Cơ sở dữ liệu:** Microsoft SQL Server (`ProjectTaskDB`, `GarageDB`, `KaraokeDB`).
- **Thư viện ADO.NET:** `Microsoft.Data.SqlClient`.
- **Mô hình Kiến trúc:** Kiến trúc 3 tầng chuẩn (**3-Tier Architecture**):
  * **DTO (Data Transfer Object):** Ánh xạ dữ liệu các bảng thành đối tượng C#.
  * **DAL (Data Access Layer):** Truy vấn dữ liệu ADO.NET an toàn, tách biệt hoàn toàn truy vấn SQL.
  * **BUS (Business Logic Layer):** Xử lý quy tắc nghiệp vụ, kiểm tra ràng buộc và tính toán logic.
  * **GUI (Graphical User Interface):** Giao diện WinForms tương tác trực quan người dùng (Visual Grid, Kanban Board).
- **Kỹ thuật ADO.NET & An toàn dữ liệu:**
  * **SqlParameter:** Phòng chống 100% lỗ hổng bảo mật **SQL Injection** trong mọi thao tác tra cứu, thêm, sửa, xóa.
  * **SqlTransaction:** Đảm bảo tính toàn vẹn dữ liệu **ACID** khi lập phiếu sửa chữa trừ kho, lập hóa đơn karaoke ngắt kết nối và cập nhật trạng thái hệ thống.
  * **Disconnected Model (Mô hình ngắt kết nối):** Sử dụng `DataTable`, `SqlDataAdapter` để quản lý giỏ dịch vụ, gọi món tại phòng karaoke ngắt kết nối trước khi chốt hóa đơn.
  * **ExecuteScalar & SqlDataReader:** Tối ưu hiệu năng khi tính tỷ lệ % hoàn thành công việc của nhân viên và xuất danh sách công việc trễ hạn.

---

## BẢNG YÊU CẦU ĐÃ THỰC HIỆN

### 1. Bài 6.3: Hệ Thống Quản Lý Công Việc & Tiến Độ Dự Án (ProjectTaskDB)
| STT | Yêu cầu nghiệp vụ / Chức năng | Trạng thái | Giải pháp kỹ thuật đã áp dụng |
| :---: | :--- | :---: | :--- |
| **1** | Thiết kế CSDL ProjectTaskDB (4 bảng) | **Hoàn thành** | Tạo các bảng `DuAn`, `ThanhVien`, `CongViec`, `PhanCong` với chuẩn khóa chính, khóa ngoại. |
| **2** | Quản lý Dự án & Task (3-Tier Layered) | **Hoàn thành** | Xây dựng CRUD Dự án và Công việc con tách biệt qua các tầng DTO/DAL/BUS/GUI. |
| **3** | Phân công công việc (Giao việc) | **Hoàn thành** | Giao 1 hoặc nhiều Task cho thành viên thông qua bảng trung gian `PhanCong`. |
| **4** | Lọc Task & Giao diện Kanban / List View | **Hoàn thành** | Lọc Task theo Dự án và Trạng thái (`To Do`, `In Progress`, `Review`, `Done`), hiển thị dạng Kanban Board linh hoạt. |
| **5** | Cập nhật tiến độ & Chuyển trạng thái | **Hoàn thành** | Cập nhật trạng thái công việc thời gian thực qua Parameterized SQL Update. |
| **6** | Cảnh báo trễ hạn (Overdue) | **Hoàn thành** | Dùng `SqlDataReader` duyệt các Task quá `HanNop` mà `TrangThai != 'Done'`. |
| **7** | Báo cáo tỷ lệ % hoàn thành | **Hoàn thành** | Sử dụng `ExecuteScalar` để tính tỷ lệ % công việc hoàn thành của từng thành viên trong dự án. |

### 2. Bài 6.4: Hệ Thống Quản Lý Garage Và Bảo Dưỡng Xe Ô Tô (GarageDB)
| STT | Yêu cầu nghiệp vụ / Chức năng | Trạng thái | Giải pháp kỹ thuật đã áp dụng |
| :---: | :--- | :---: | :--- |
| **1** | Thiết kế CSDL GarageDB (5 bảng) | **Hoàn thành** | Tạo cấu trúc `KhachHang`, `Xe`, `PhuTung`, `PhieuSuaChua`, `ChiTietSuaChua`. |
| **2** | Tiếp nhận xe & Quản lý Chủ xe | **Hoàn thành** | Tra cứu biển số xe bằng `SqlParameter`. Tự động chuyển đăng ký xe mới nếu chưa có dữ liệu. |
| **3** | Quản lý Phụ tùng & Tồn kho | **Hoàn thành** | Quản lý danh mục phụ tùng, cập nhật đơn giá và số lượng tồn kho có ràng buộc `CHECK (SoLuongTon >= 0)`. |
| **4** | Lập Phiếu sửa chữa & Vật tư | **Hoàn thành** | Chọn dịch vụ, phụ tùng thay thế và số lượng tương ứng cho phiếu sửa chữa. |
| **5** | Giao dịch `SqlTransaction` an toàn | **Hoàn thành** | Thực thi duy nhất 1 Transaction: Thêm `PhieuSuaChua`, thêm `ChiTietSuaChua` và trừ `SoLuongTon` phụ tùng. |
| **6** | Cơ chế Rollback khi thiếu kho | **Hoàn thành** | Tự động gọi `trans.Rollback()` và xuất thông báo lỗi nếu phụ tùng trong kho không đủ cung ứng. |
| **7** | Thanh toán & Xuất Hóa đơn | **Hoàn thành** | Tự động tính tổng tiền `(SoLuong * DonGia) + TienCong` và cập nhật trạng thái phiếu sang "Đã thanh toán". |

### 3. Bài 6.5: Hệ Thống Quản Lý Đặt Phòng & Dịch Vụ Karaoke (KaraokeDB)
| STT | Yêu cầu nghiệp vụ / Chức năng | Trạng thái | Giải pháp kỹ thuật đã áp dụng |
| :---: | :--- | :---: | :--- |
| **1** | Thiết kế CSDL KaraokeDB (4 bảng) | **Hoàn thành** | Tạo các bảng `PhongHat`, `DichVu`, `HoaDon`, `ChiTietDichVu`. |
| **2** | Sơ đồ phòng trực quan (Visual Room Grid) | **Hoàn thành** | Động hóa danh sách nút bấm (Button Grid): Mã màu xanh (Phòng Trống), màu đỏ (Đang Hát). |
| **3** | Mở phòng hát tự động | **Hoàn thành** | Chọn phòng trống $\rightarrow$ Bấm mở phòng $\rightarrow$ Tự động tạo `HoaDon` ghi nhận `GioVao` và cập nhật phòng sang "Đang hát". |
| **4** | Gọi dịch vụ ngắt kết nối (Disconnected Model) | **Hoàn thành** | Sử dụng `SqlDataAdapter` + `DataTable` hiển thị và thao tác thêm đồ uống/dịch vụ trên DataGridView. |
| **5** | Tính tiền giờ tự động | **Hoàn thành** | Tự động làm tròn số giờ hát = `GioRa - GioVao` và tính `TongTienPhong = SoGio * GiaTheoGio`. |
| **6** | Thanh toán bằng `SqlTransaction` | **Hoàn thành** | Transaction thực hiện: Cập nhật giờ ra/tổng tiền hóa đơn, trừ tồn kho `DichVu`, đổi trạng thái phòng về "Trống" và `Commit()`. |

---

## KẾT QUẢ THỰC HÀNH

# bai6.3

<img width="1498" height="972" alt="bai6 3" src="https://github.com/user-attachments/assets/5025c096-da30-4565-9d1a-9a05b95b5898" />

<img width="1502" height="975" alt="bai6 3-3" src="https://github.com/user-attachments/assets/e5e16d3f-d9c9-492f-bb8b-2cc3dc6a38b8" />

<img width="1497" height="972" alt="bai6 3-2" src="https://github.com/user-attachments/assets/1ecc0a70-f8b8-4b16-a6d2-d04b46ebff6d" />

# bai6.4

<img width="1253" height="853" alt="bai6 4" src="https://github.com/user-attachments/assets/30484ee8-a594-46ba-8c2b-68ddcf8ccfb7" />

<img width="1250" height="848" alt="bai6 4-2" src="https://github.com/user-attachments/assets/3b57b1ec-ee8e-42ac-ab84-9a40e5930847" />

<img width="1252" height="852" alt="bai6 4-3" src="https://github.com/user-attachments/assets/e96a4e4b-d140-4d2a-90de-2c5cb50a84b7" />

# bai6.5

<img width="1500" height="975" alt="bai6 5" src="https://github.com/user-attachments/assets/c2d69263-63c8-46a0-8dce-ad50068a72cd" />

---

## CẤU TRÚC THƯ MỤC SOLUTION

```text
├── Database/
│   └── ScriptDB.sql                  # Script SQL Server khởi tạo CSDL (ProjectTaskDB, GarageDB, KaraokeDB)
├── bai6.3/                           # Project QUẢN LÝ CÔNG VIỆC & DỰ ÁN
│   ├── DTO/                          # DuAnDTO, CongViecDTO, ThanhVienDTO, OverdueTaskDTO
│   ├── DAL/                          # DatabaseAccess, DuAnDAL, TaskDAL
│   ├── BUS/                          # DuAnBUS, TaskBUS
│   ├── GUI/                          # FormMain.cs, FormMain.Designer.cs
│   ├── App.config
│   └── Program.cs
├── bai6.4/                           # Project QUẢN LÝ GARAGE Ô TÔ
│   ├── DTO/                          # KhachHangDTO, XeDTO, PhuTungDTO, PhieuSuaChuaDTO, ChiTietSuaChuaDTO
│   ├── DAL/                          # DatabaseAccess, GarageDAL
│   ├── BUS/                          # GarageBUS
│   ├── GUI/                          # FormGarage.cs, FormGarage.Designer.cs
│   ├── App.config
│   └── Program.cs
├── bai6.5/                           # Project QUẢN LÝ KARAOKE & ĐẶT PHÒNG
│   ├── DTO/                          # PhongHatDTO, DichVuDTO, HoaDonDTO, ChiTietDichVuDTO
│   ├── DAL/                          # DatabaseAccess, KaraokeDAL
│   ├── BUS/                          # KaraokeBUS
│   ├── GUI/                          # FormKaraoke.cs, FormKaraoke.Designer.cs
│   ├── App.config
│   └── Program.cs
├── images/                           # Chứa hình ảnh báo cáo Markdown
│   ├── bai6 3.png
│   ├── bai6 3-2.png
│   ├── bai6 3-3.png
│   ├── bai6 4.png
│   ├── bai6 4-2.png
│   ├── bai6 4-3.png
│   └── bai6 5.png
├── README.md                         # File báo cáo GitHub Markdown
└── SolutionName.sln
