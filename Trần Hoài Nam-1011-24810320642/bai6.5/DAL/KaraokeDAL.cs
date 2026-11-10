using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace KaraokeManagement.DAL;

public class KaraokeDAL
{
    public static DataTable GetAllRooms()
    {
        using var conn = DatabaseAccess.GetConnection();
        const string query = "select maphong, tenphong, loaiphong, giatheogio, trangthai from phonghat";
        using var da = new SqlDataAdapter(query, conn);
        DataTable dt = new();
        da.Fill(dt);
        return dt;
    }

    public static DataTable GetAllServices()
    {
        using var conn = DatabaseAccess.GetConnection();
        const string query = "select madv, tendv, dongia, tonkho from dichvu";
        using var da = new SqlDataAdapter(query, conn);
        DataTable dt = new();
        da.Fill(dt);
        return dt;
    }

    public static bool OpenRoomTransaction(int maPhong)
    {
        using var conn = DatabaseAccess.GetConnection();
        conn.Open();
        using var trans = conn.BeginTransaction();
        try
        {
            const string insertInvoice = "insert into hoadon (maphong, giovao, tongtienphong, tongtiendichvu, trangthai) values (@maphong, getdate(), 0, 0, 0)";
            using var cmdInvoice = new SqlCommand(insertInvoice, conn, trans);
            cmdInvoice.Parameters.Add("@maphong", SqlDbType.Int).Value = maPhong;
            cmdInvoice.ExecuteNonQuery();

            const string updateRoom = "update phonghat set trangthai = N'đang hát' where maphong = @maphong";
            using var cmdRoom = new SqlCommand(updateRoom, conn, trans);
            cmdRoom.Parameters.Add("@maphong", SqlDbType.Int).Value = maPhong;
            cmdRoom.ExecuteNonQuery();

            trans.Commit();
            return true;
        }
        catch
        {
            trans.Rollback();
            throw;
        }
    }

    public static DataRow? GetActiveInvoiceByRoom(int maPhong)
    {
        using var conn = DatabaseAccess.GetConnection();
        const string query = "select top 1 mahd, maphong, giovao, giora, tongtienphong, tongtiendichvu, trangthai " +
                             "from hoadon where maphong = @maphong and trangthai = 0 order by mahd desc";
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.Add("@maphong", SqlDbType.Int).Value = maPhong;
        using var da = new SqlDataAdapter(cmd);
        DataTable dt = new();
        da.Fill(dt);
        return dt.Rows.Count > 0 ? dt.Rows[0] : null;
    }

    public static DataTable GetServicesByInvoiceDisconnected(int maHD)
    {
        using var conn = DatabaseAccess.GetConnection();
        const string query = "select c.mahd, c.madv, d.tendv, c.soluong, c.dongia, (c.soluong * c.dongia) as thanhtien " +
                             "from chitietdichvu c inner join dichvu d on c.madv = d.madv where c.mahd = @mahd";
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.Add("@mahd", SqlDbType.Int).Value = maHD;
        using var da = new SqlDataAdapter(cmd);
        DataTable dt = new();
        da.Fill(dt);
        return dt;
    }

    public static bool AddServiceToInvoice(int maHD, int maDV, int soLuong, decimal donGia)
    {
        using var conn = DatabaseAccess.GetConnection();
        conn.Open();
        const string checkQuery = "select soluong from chitietdichvu where mahd = @mahd and madv = @madv";
        using var cmdCheck = new SqlCommand(checkQuery, conn);
        cmdCheck.Parameters.Add("@mahd", SqlDbType.Int).Value = maHD;
        cmdCheck.Parameters.Add("@madv", SqlDbType.Int).Value = maDV;
        var result = cmdCheck.ExecuteScalar();

        if (result != null)
        {
            const string updateQuery = "update chitietdichvu set soluong = soluong + @soluong where mahd = @mahd and madv = @madv";
            using var cmdUpdate = new SqlCommand(updateQuery, conn);
            cmdUpdate.Parameters.Add("@soluong", SqlDbType.Int).Value = soLuong;
            cmdUpdate.Parameters.Add("@mahd", SqlDbType.Int).Value = maHD;
            cmdUpdate.Parameters.Add("@madv", SqlDbType.Int).Value = maDV;
            return cmdUpdate.ExecuteNonQuery() > 0;
        }
        else
        {
            const string insertQuery = "insert into chitietdichvu (mahd, madv, soluong, dongia) values (@mahd, @madv, @soluong, @dongia)";
            using var cmdInsert = new SqlCommand(insertQuery, conn);
            cmdInsert.Parameters.Add("@mahd", SqlDbType.Int).Value = maHD;
            cmdInsert.Parameters.Add("@madv", SqlDbType.Int).Value = maDV;
            cmdInsert.Parameters.Add("@soluong", SqlDbType.Int).Value = soLuong;
            cmdInsert.Parameters.Add("@dongia", SqlDbType.Decimal).Value = donGia;
            return cmdInsert.ExecuteNonQuery() > 0;
        }
    }

    public static bool CheckoutTransaction(int maHD, int maPhong, decimal tongTienPhong, decimal tongTienDichVu)
    {
        using var conn = DatabaseAccess.GetConnection();
        conn.Open();
        using var trans = conn.BeginTransaction();

        try
        {
            const string getServicesQuery = "select madv, soluong from chitietdichvu where mahd = @mahd";
            using var cmdServices = new SqlCommand(getServicesQuery, conn, trans);
            cmdServices.Parameters.Add("@mahd", SqlDbType.Int).Value = maHD;

            List<Tuple<int, int>> items = new();
            using (var reader = cmdServices.ExecuteReader())
            {
                while (reader.Read())
                {
                    items.Add(new(reader.GetInt32(0), reader.GetInt32(1)));
                }
            }

            foreach (var (maDV, soLuongDung) in items)
            {
                const string checkStockQuery = "select tonkho from dichvu where madv = @madv";
                using var cmdStock = new SqlCommand(checkStockQuery, conn, trans);
                cmdStock.Parameters.Add("@madv", SqlDbType.Int).Value = maDV;
                int currentStock = Convert.ToInt32(cmdStock.ExecuteScalar());

                if (currentStock < soLuongDung)
                {
                    throw new Exception($"Mặt hàng mã #{maDV} không đủ tồn kho (còn lại: {currentStock}, yêu cầu: {soLuongDung}).");
                }

                const string updateStockQuery = "update dichvu set tonkho = tonkho - @soluong where madv = @madv";
                using var cmdUpdateStock = new SqlCommand(updateStockQuery, conn, trans);
                cmdUpdateStock.Parameters.Add("@soluong", SqlDbType.Int).Value = soLuongDung;
                cmdUpdateStock.Parameters.Add("@madv", SqlDbType.Int).Value = maDV;
                cmdUpdateStock.ExecuteNonQuery();
            }

            const string updateInvoiceQuery = "update hoadon set giora = getdate(), tongtienphong = @tongtienphong, " +
                                               "tongtiendichvu = @tongtiendichvu, trangthai = 1 where mahd = @mahd";
            using var cmdInvoice = new SqlCommand(updateInvoiceQuery, conn, trans);
            cmdInvoice.Parameters.Add("@tongtienphong", SqlDbType.Decimal).Value = tongTienPhong;
            cmdInvoice.Parameters.Add("@tongtiendichvu", SqlDbType.Decimal).Value = tongTienDichVu;
            cmdInvoice.Parameters.Add("@mahd", SqlDbType.Int).Value = maHD;
            cmdInvoice.ExecuteNonQuery();

            const string updateRoomQuery = "update phonghat set trangthai = N'trống' where maphong = @maphong";
            using var cmdRoom = new SqlCommand(updateRoomQuery, conn, trans);
            cmdRoom.Parameters.Add("@maphong", SqlDbType.Int).Value = maPhong;
            cmdRoom.ExecuteNonQuery();

            trans.Commit();
            return true;
        }
        catch
        {
            trans.Rollback();
            throw;
        }
    }
}