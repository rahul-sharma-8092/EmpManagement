using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace DAL
{
    public class EmployeeSQL
    {
        private readonly string connString = Convert.ToString(ConfigurationManager.ConnectionStrings["dbConnection"]);

        public int AddEditEmployee(Entity.Employee emp, string type)
        {
            int result = 0;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            try
            {
                cmd.CommandText = "AddEditEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", emp.EmpID);
                cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Phone", emp.Phone);
                cmd.Parameters.AddWithValue("@HireDate", emp.HireDate);
                cmd.Parameters.AddWithValue("@Position", emp.Position);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                cmd.Parameters.AddWithValue("@Type", type);

                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                result = 0;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
            }
            return result;
        }

        public Entity.Employee GetEmployeeDetailsByID(long EmpId)
        {
            Entity.Employee emp = new Entity.Employee();
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("GetEmployeeByID", conn);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", EmpId);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        emp.EmpID = Convert.ToInt64(dr["EmpID"]);
                        emp.FirstName = Convert.ToString(dr["FirstName"]);
                        emp.LastName = Convert.ToString(dr["LastName"]);
                        emp.Email = Convert.ToString(dr["Email"]);
                        emp.Phone = Convert.ToString(dr["Phone"]);
                        emp.HireDate = Convert.ToDateTime(dr["HireDate"]);
                        emp.Position = Convert.ToString(dr["Position"]);
                        emp.Salary = Convert.ToDecimal(dr["Salary"]);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
            }
            return emp;
        }

        public List<Entity.Employee> GetAllEmployees(int pageIndex, int pageSize, string search)
        {
            List<Entity.Employee> listEmp = new List<Entity.Employee>();
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("GetAllEmployees", conn);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pageIndex", pageIndex);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                cmd.Parameters.AddWithValue("@search", search);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Entity.Employee emp = new Entity.Employee();

                        emp.EmpID = Convert.ToInt64(dr["EmpID"]);
                        emp.FirstName = Convert.ToString(dr["FirstName"]);
                        emp.LastName = Convert.ToString(dr["LastName"]);
                        emp.Email = Convert.ToString(dr["Email"]);
                        emp.Phone = Convert.ToString(dr["Phone"]);
                        emp.HireDate = Convert.ToDateTime(dr["HireDate"]);
                        emp.Position = Convert.ToString(dr["Position"]);
                        emp.Salary = Convert.ToDecimal(dr["Salary"]);
                        emp.RowCount = Convert.ToInt32(dr["RowCount"]);

                        listEmp.Add(emp);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
            }
            return listEmp;
        }

        public int DeleteEmployeeByID(long empID)
        {
            int rowAffected = 0;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("DeleteEmployeeByID", conn);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empID", empID);
                conn.Open();

                rowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
            }
            return rowAffected;
        }
    }
}
