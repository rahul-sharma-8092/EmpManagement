using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class EmployeeMGNT
    {

        public int AddEditEmployee(Entity.Employee emp, string type)
        {
            return new DAL.EmployeeSQL().AddEditEmployee(emp, type);
        }

        public Entity.Employee GetEmployeeDetailsByID(long EmpId)
        {
            return new DAL.EmployeeSQL().GetEmployeeDetailsByID(EmpId);
        }

        public List<Entity.Employee> GetAllEmployees(int pageSize, int pageIndex, string search)
        {
            return new DAL.EmployeeSQL().GetAllEmployees(pageIndex, pageSize, search);
        }

        public DataSet GetAllEmployeesDataSet(int pageSize, int pageIndex, string search)
        {
            return new DAL.EmployeeSQL().GetAllEmployeesDataSet(pageIndex, pageSize, search);
        }

        public int DeleteEmployeeByID(long empId)
        {
            return new DAL.EmployeeSQL().DeleteEmployeeByID(empId);
        }
    }
}
