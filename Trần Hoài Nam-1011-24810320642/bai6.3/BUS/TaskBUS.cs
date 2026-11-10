using System.Collections.Generic;
using System.Data;
using ProjectTaskManagement.DAL;
using ProjectTaskManagement.DTO;

namespace ProjectTaskManagement.BUS
{
    public class TaskBUS
    {
        private TaskDAL taskDAL = new TaskDAL();

        public bool AddTask(CongViecDTO task)
        {
            return taskDAL.InsertTask(task);
        }

        public bool EditTask(CongViecDTO task)
        {
            return taskDAL.UpdateTask(task);
        }

        public bool RemoveTask(int maTask)
        {
            return taskDAL.DeleteTask(maTask);
        }

        public bool AssignTask(int maTask, int maThanhVien)
        {
            return taskDAL.AssignTaskToMember(maTask, maThanhVien);
        }

        public bool ChangeStatus(int maTask, string trangThaiMoi)
        {
            return taskDAL.UpdateTaskStatus(maTask, trangThaiMoi);
        }

        public DataTable FilterTasks(int maDuAn, string trangThai)
        {
            return taskDAL.GetTasksByProjectAndStatus(maDuAn, trangThai);
        }

        public List<OverdueTaskDTO> GetOverdueTasks()
        {
            return taskDAL.GetOverdueTasksDataReader();
        }

        public double GetMemberCompletionRate(int maThanhVien, int maDuAn)
        {
            return taskDAL.GetMemberCompletionRateExecuteScalar(maThanhVien, maDuAn);
        }
    }
}