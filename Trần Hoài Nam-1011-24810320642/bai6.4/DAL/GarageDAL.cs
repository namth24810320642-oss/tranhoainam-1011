using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using GarageManagement.DTO;

namespace GarageManagement.DAL
{
    public class GarageDAL
    {
        public DataRow GetCarByBienSo(string bienSo)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "select x.bienso, x.hieuxe, x.namsanxuat, k.makh, k.tenkh, k.dienthoai, k.diachi " +
                               "from xe x inner join khachhang k on x.makh = k.makh where lower(x.bienso) = lower(@bienso)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@bienso", SqlDbType.VarChar, 20) { Value = bienSo });
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public bool AddCustomerAndCar(KhachHangDTO kh, XeDTO xe)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string insertCustomer = "insert into khachhang (tenkh, dienthoai, diachi) values (@tenkh, @dienthoai, @diachi); select scope_identity();";
                    SqlCommand cmdKh = new SqlCommand(insertCustomer, conn, trans);
                    cmdKh.Parameters.AddWithValue("@tenkh", kh.TenKH);
                    cmdKh.Parameters.AddWithValue("@dienthoai", kh.DienThoai);
                    cmdKh.Parameters.AddWithValue("@diachi", (object)kh.DiaChi ?? DBNull.Value);
                    int maKH = Convert.ToInt32(cmdKh.ExecuteScalar());

                    string insertCar = "insert into xe (bienso, makh, hieuxe, namsanxuat) values (@bienso, @makh, @hieuxe, @namsanxuat)";
                    SqlCommand cmdXe = new SqlCommand(insertCar, conn, trans);
                    cmdXe.Parameters.AddWithValue("@bienso", xe.BienSo);
                    cmdXe.Parameters.AddWithValue("@makh", maKH);
                    cmdXe.Parameters.AddWithValue("@hieuxe", xe.HieuXe);
                    cmdXe.Parameters.AddWithValue("@namsanxuat", xe.NamSanXuat);
                    cmdXe.ExecuteNonQuery();

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

        public DataTable GetAllParts()
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "select maphutung, tenphutung, dongia, soluongton from phutung";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool UpdatePart(PhuTungDTO pt)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "update phutung set tenphutung = @tenphutung, dongia = @dongia, soluongton = @soluongton where maphutung = @maphutung";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maphutung", pt.MaPhuTung);
                cmd.Parameters.AddWithValue("@tenphutung", pt.TenPhuTung);
                cmd.Parameters.AddWithValue("@dongia", pt.DonGia);
                cmd.Parameters.AddWithValue("@soluongton", pt.SoLuongTon);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool CreateRepairTicketTransaction(PhieuSuaChuaDTO ticket, List<ChiTietSuaChuaDTO> details)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    string insertTicketQuery = "insert into phieusuachua (bienso, ngaynhan, noidungsua, tongtien, trangthai) " +
                                               "values (@bienso, getdate(), @noidungsua, @tongtien, n'Đang sửa'); select scope_identity();";
                    SqlCommand cmdTicket = new SqlCommand(insertTicketQuery, conn, trans);
                    cmdTicket.Parameters.AddWithValue("@bienso", ticket.BienSo);
                    cmdTicket.Parameters.AddWithValue("@noidungsua", ticket.NoiDungSua);
                    cmdTicket.Parameters.AddWithValue("@tongtien", ticket.TongTien);

                    int maPhieu = Convert.ToInt32(cmdTicket.ExecuteScalar());

                    foreach (var item in details)
                    {
                        string checkStockQuery = "select soluongton from phutung where maphutung = @maphutung";
                        SqlCommand cmdStock = new SqlCommand(checkStockQuery, conn, trans);
                        cmdStock.Parameters.AddWithValue("@maphutung", item.MaPhuTung);
                        object result = cmdStock.ExecuteScalar();
                        int currentStock = result != null ? Convert.ToInt32(result) : 0;

                        if (currentStock < item.SoLuong)
                        {
                            throw new Exception($"Phụ tùng '{item.TenPhuTung}' (mã {item.MaPhuTung}) không đủ tồn kho (còn lại: {currentStock}, yêu cầu: {item.SoLuong}).");
                        }

                        string insertDetailQuery = "insert into chitietsuachua (maphieu, maphutung, soluong, tiencong) values (@maphieu, @maphutung, @soluong, @tiencong)";
                        SqlCommand cmdDetail = new SqlCommand(insertDetailQuery, conn, trans);
                        cmdDetail.Parameters.AddWithValue("@maphieu", maPhieu);
                        cmdDetail.Parameters.AddWithValue("@maphutung", item.MaPhuTung);
                        cmdDetail.Parameters.AddWithValue("@soluong", item.SoLuong);
                        cmdDetail.Parameters.AddWithValue("@tiencong", item.TienCong);
                        cmdDetail.ExecuteNonQuery();

                        string updateStockQuery = "update phutung set soluongton = soluongton - @soluong where maphutung = @maphutung";
                        SqlCommand cmdUpdateStock = new SqlCommand(updateStockQuery, conn, trans);
                        cmdUpdateStock.Parameters.AddWithValue("@soluong", item.SoLuong);
                        cmdUpdateStock.Parameters.AddWithValue("@maphutung", item.MaPhuTung);
                        cmdUpdateStock.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return true;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public DataTable GetUnpaidTickets()
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "select p.maphieu, p.bienso, p.ngaynhan, p.noidungsua, p.tongtien, p.trangthai " +
                               "from phieusuachua p where p.trangthai != n'Đã thanh toán'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool CheckoutTicket(int maPhieu)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "update phieusuachua set trangthai = n'Đã thanh toán' where maphieu = @maphieu";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maphieu", maPhieu);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}