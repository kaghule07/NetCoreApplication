using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using System.Configuration;
namespace NetCoreApplication.Models
{
    public class EmployeeDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public EmployeeDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public List<Employee> GetAllEmployee()
        {
            List<Employee> list = new List<Employee>();
            string str = "Select * from Employee";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = Convert.ToInt32(dr["Id"]);
                    emp.Name = dr["Name"].ToString();
                    emp.Salary = Convert.ToDouble(dr["Salary"]);
                    list.Add(emp);
                }
                con.Close();
                return list;
            }
            else
            {
                return list;
            }
        }
        public Employee GetEmployeeById(int id)
        {
            Employee emp = new Employee();
            string str = "select * from Employee where Id=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    emp.Id = Convert.ToInt32(dr["Id"]);
                    emp.Name = dr["Name"].ToString();
                    emp.Salary = Convert.ToDouble(dr["Salary"]);

                }
                con.Close();
                return emp;
            }
            else
            {
                con.Close();
                return emp;
            }
        }
        public int Save(Employee emp)
        {
            string str = "insert into Employee values(@name,@salary)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Update(Employee emp)
        {
            string str = "update Employee set Name=@name,Salary=@salary where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", emp.Id);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int Delete(int id)
        {
            string str = "delete from Employee where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
    }
}
