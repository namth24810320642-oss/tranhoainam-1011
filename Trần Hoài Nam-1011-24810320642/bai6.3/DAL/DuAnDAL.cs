using System;
using System.Data;
using System.Data.SqlClient;
using ProjectTaskManagement.DTO;

namespace ProjectTaskManagement.DAL
{
    public class DuAnDAL
    {
        public DataTable GetAllProjects()
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "select maduan, tenduan, ngaybatdau, ngayketthuc, trangthai from duan";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool InsertProject(DuAnDTO duAn)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "insert into duan (tenduan, ngaybatdau, ngayketthuc, trangthai) values (@tenduan, @ngaybatdau, @ngayketthuc, @trangthai)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tenduan", duAn.TenDuAn);
                cmd.Parameters.AddWithValue("@ngaybatdau", duAn.NgayBatDau);
                cmd.Parameters.AddWithValue("@ngayketthuc", duAn.NgayKetThuc);
                cmd.Parameters.AddWithValue("@trangthai", duAn.TrangThai);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateProject(DuAnDTO duAn)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "update duan set tenduan = @tenduan, ngaybatdau = @ngaybatdau, ngayketthuc = @ngayketthuc, trangthai = @trangthai where maduan = @maduan";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maduan", duAn.MaDuAn);
                cmd.Parameters.AddWithValue("@tenduan", duAn.TenDuAn);
                cmd.Parameters.AddWithValue("@ngaybatdau", duAn.NgayBatDau);
                cmd.Parameters.AddWithValue("@ngayketthuc", duAn.NgayKetThuc);
                cmd.Parameters.AddWithValue("@trangthai", duAn.TrangThai);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteProject(int maDuAn)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "delete from duan where maduan = @maduan";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maduan", maDuAn);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}