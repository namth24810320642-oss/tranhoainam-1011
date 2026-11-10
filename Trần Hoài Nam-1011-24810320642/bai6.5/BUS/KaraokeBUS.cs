using System;
using System.Data;
using KaraokeManagement.DAL;

namespace KaraokeManagement.BUS;

public class KaraokeBUS
{
    public DataTable GetRooms() => KaraokeDAL.GetAllRooms();

    public DataTable GetServices() => KaraokeDAL.GetAllServices();

    public bool OpenRoom(int maPhong) => KaraokeDAL.OpenRoomTransaction(maPhong);

    public DataRow? GetActiveInvoice(int maPhong) => KaraokeDAL.GetActiveInvoiceByRoom(maPhong);

    public DataTable GetInvoiceServicesDisconnected(int maHD) => KaraokeDAL.GetServicesByInvoiceDisconnected(maHD);

    public bool AddService(int maHD, int maDV, int soLuong, decimal donGia) => KaraokeDAL.AddServiceToInvoice(maHD, maDV, soLuong, donGia);

    public bool PayBill(int maHD, int maPhong, DateTime gioVao, decimal giaTheoGio, decimal tongTienDichVu, out decimal tongTienPhong, out double soGio)
    {
        DateTime gioRa = DateTime.Now;
        TimeSpan duration = gioRa - gioVao;
        soGio = Math.Ceiling(duration.TotalMinutes / 60.0);
        if (soGio < 1) soGio = 1;

        tongTienPhong = (decimal)soGio * giaTheoGio;
        return KaraokeDAL.CheckoutTransaction(maHD, maPhong, tongTienPhong, tongTienDichVu);
    }
}