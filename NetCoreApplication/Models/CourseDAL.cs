using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using System.Configuration;

namespace NetCoreApplication.Models

{
    public class CourseDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public CourseDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public List<Course> GetAllCourse()
        {
            List<Course> list = new List<Course>();
            string str = "Select * from Course";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Course cr = new Course();
                    cr.Id = Convert.ToInt32(dr["Id"]);
                    cr.Name = dr["Name"].ToString();
                    cr.Fees = Convert.ToDouble(dr["Fees"]);
                    list.Add(cr);
                }
                con.Close();
                return list;
            }
            else
            {
                return list;
            }
        }
        public Course GetCourseById(int id)
        {
            Course cr = new Course();
            string str = "select * from Course where Id=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    cr.Id = Convert.ToInt32(dr["Id"]);
                    cr.Name = dr["Name"].ToString();
                    cr.Fees = Convert.ToDouble(dr["Fees"]);

                }
                con.Close();
                return cr;
            }
            else
            {
                con.Close();
                return cr;
            }
        }
        public int Save(Course cr)
        {
            string str = "insert into Course values(@name,@fees)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", cr.Name);
            cmd.Parameters.AddWithValue("@fees", cr.Fees);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int Update(Course cr)
        {
            string str = "update Course set Name=@name,Fees=@fees where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", cr.Id);
            cmd.Parameters.AddWithValue("@name", cr.Name);
            cmd.Parameters.AddWithValue("@fees", cr.Fees);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int Delete(int id)
        {
            string str = "delete from Course where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }

    }
}
