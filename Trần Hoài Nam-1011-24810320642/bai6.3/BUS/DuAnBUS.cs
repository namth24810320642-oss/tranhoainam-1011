using System.Data;
using ProjectTaskManagement.DAL;
using ProjectTaskManagement.DTO;

namespace ProjectTaskManagement.BUS
{
    public class DuAnBUS
    {
        private DuAnDAL duAnDAL = new DuAnDAL();

        public DataTable GetAllProjects()
        {
            return duAnDAL.GetAllProjects();
        }

        public bool AddProject(DuAnDTO duAn)
        {
            return duAnDAL.InsertProject(duAn);
        }

        public bool EditProject(DuAnDTO duAn)
        {
            return duAnDAL.UpdateProject(duAn);
        }

        public bool RemoveProject(int maDuAn)
        {
            return duAnDAL.DeleteProject(maDuAn);
        }
    }
}