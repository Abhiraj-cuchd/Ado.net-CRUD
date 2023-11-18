using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CrudAppAdo.Models
{
    public class EmployeeDBContext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public List<Employee> GetEmployees()
        {
            List<Employee> EmployeesList = new List<Employee>();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spGetEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Employee emp = new Employee();
                    emp.id = Convert.ToInt32(dr.GetValue(0).ToString());
                    emp.name = dr.GetValue(1).ToString();
                    emp.gender = dr.GetValue(2).ToString();
                    emp.age = Convert.ToInt32(dr.GetValue(3).ToString());
                    emp.salary = Convert.ToInt32(dr.GetValue(4).ToString());
                    emp.city = dr.GetValue(5).ToString();
                    EmployeesList.Add(emp);
                }
                con.Close();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



            return EmployeesList;
        }

        public bool AddEmployee(Employee emp)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spAdddEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", emp.id);
            cmd.Parameters.AddWithValue("@name", emp.name);
            cmd.Parameters.AddWithValue("@gender", emp.gender);
            cmd.Parameters.AddWithValue("@age", emp.age);
            cmd.Parameters.AddWithValue("@salary", emp.salary);
            cmd.Parameters.AddWithValue("@city", emp.city);
            try
            {
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();  
                
                if( i > 0)
                {
                    return true;
                } 
                else
                {
                    return false;
                }

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateEmployee(Employee emp)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", emp.id);
            cmd.Parameters.AddWithValue("@name", emp.name);
            cmd.Parameters.AddWithValue("@gender", emp.gender);
            cmd.Parameters.AddWithValue("@age", emp.age);
            cmd.Parameters.AddWithValue("@salary", emp.salary);
            cmd.Parameters.AddWithValue("@city", emp.city);
            try
            {
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteEmployee(int id)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}