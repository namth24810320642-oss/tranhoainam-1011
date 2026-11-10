using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ProjectTaskManagement.DTO;

namespace ProjectTaskManagement.DAL
{
    public class TaskDAL
    {
        public bool InsertTask(CongViecDTO task)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "insert into congviec (maduan, tentask, mota, hannop, douutien, trangthai) values (@maduan, @tentask, @mota, @hannop, @douutien, @trangthai)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maduan", task.MaDuAn);
                cmd.Parameters.AddWithValue("@tentask", task.TenTask);
                cmd.Parameters.AddWithValue("@mota", (object)task.MoTa ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@hannop", task.HanNop);
                cmd.Parameters.AddWithValue("@douutien", task.DoUuTien);
                cmd.Parameters.AddWithValue("@trangthai", task.TrangThai);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateTask(CongViecDTO task)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "update congviec set tentask = @tentask, mota = @mota, hannop = @hannop, douutien = @douutien, trangthai = @trangthai where matask = @matask";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@matask", task.MaTask);
                cmd.Parameters.AddWithValue("@tentask", task.TenTask);
                cmd.Parameters.AddWithValue("@mota", (object)task.MoTa ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@hannop", task.HanNop);
                cmd.Parameters.AddWithValue("@douutien", task.DoUuTien);
                cmd.Parameters.AddWithValue("@trangthai", task.TrangThai);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteTask(int maTask)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                conn.Open();
                string deletePhanCong = "delete from phancong where matask = @matask";
                SqlCommand cmdPC = new SqlCommand(deletePhanCong, conn);
                cmdPC.Parameters.AddWithValue("@matask", maTask);
                cmdPC.ExecuteNonQuery();

                string deleteTask = "delete from congviec where matask = @matask";
                SqlCommand cmdTask = new SqlCommand(deleteTask, conn);
                cmdTask.Parameters.AddWithValue("@matask", maTask);
                return cmdTask.ExecuteNonQuery() > 0;
            }
        }

        public bool AssignTaskToMember(int maTask, int maThanhVien)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "insert into phancong (matask, mathanhvien, ngaygiao) values (@matask, @mathanhvien, getdate())";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@matask", maTask);
                cmd.Parameters.AddWithValue("@mathanhvien", maThanhVien);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateTaskStatus(int maTask, string meTrangThai)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "update congviec set trangthai = @trangthai where matask = @matask";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@trangthai", meTrangThai);
                cmd.Parameters.AddWithValue("@matask", maTask);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable GetTasksByProjectAndStatus(int maDuAn, string trangThai)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "select matask, maduan, tentask, mota, hannop, douutien, trangthai from congviec where maduan = @maduan";
                if (!string.IsNullOrEmpty(trangThai) && !trangThai.Equals("tất cả", StringComparison.OrdinalIgnoreCase))
                {
                    query += " and trangthai = @trangthai";
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maduan", maDuAn);
                if (!string.IsNullOrEmpty(trangThai) && !trangThai.Equals("tất cả", StringComparison.OrdinalIgnoreCase))
                {
                    cmd.Parameters.AddWithValue("@trangthai", trangThai);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public List<OverdueTaskDTO> GetOverdueTasksDataReader()
        {
            List<OverdueTaskDTO> list = new List<OverdueTaskDTO>();
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "select c.matask, c.tentask, d.tenduan, c.hannop, c.trangthai " +
                               "from congviec c inner join duan d on c.maduan = d.maduan " +
                               "where c.hannop < getdate() and lower(c.trangthai) != 'done'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new OverdueTaskDTO
                        {
                            MaTask = reader.GetInt32(0),
                            TenTask = reader.GetString(1),
                            TenDuAn = reader.GetString(2),
                            HanNop = reader.GetDateTime(3),
                            TrangThai = reader.GetString(4)
                        });
                    }
                }
            }
            return list;
        }

        public double GetMemberCompletionRateExecuteScalar(int maThanhVien, int maDuAn)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                conn.Open();
                string queryTotal = "select count(*) from phancong p inner join congviec c on p.matask = c.matask where p.mathanhvien = @mathanhvien and c.maduan = @maduan";
                SqlCommand cmdTotal = new SqlCommand(queryTotal, conn);
                cmdTotal.Parameters.AddWithValue("@mathanhvien", maThanhVien);
                cmdTotal.Parameters.AddWithValue("@maduan", maDuAn);
                int total = Convert.ToInt32(cmdTotal.ExecuteScalar());

                if (total == 0) return 0.0;

                string queryDone = "select count(*) from phancong p inner join congviec c on p.matask = c.matask where p.mathanhvien = @mathanhvien and c.maduan = @maduan and lower(c.trangthai) = 'done'";
                SqlCommand cmdDone = new SqlCommand(queryDone, conn);
                cmdDone.Parameters.AddWithValue("@mathanhvien", maThanhVien);
                cmdDone.Parameters.AddWithValue("@maduan", maDuAn);
                int done = Convert.ToInt32(cmdDone.ExecuteScalar());

                return (double)done / total * 100.0;
            }
        }
    }
}