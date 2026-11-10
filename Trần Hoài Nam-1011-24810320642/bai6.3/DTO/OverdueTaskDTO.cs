using System;

namespace ProjectTaskManagement.DTO
{
    public class OverdueTaskDTO
    {
        public int MaTask { get; set; }
        public string TenTask { get; set; }
        public string TenDuAn { get; set; }
        public DateTime HanNop { get; set; }
        public string TrangThai { get; set; }
    }
}