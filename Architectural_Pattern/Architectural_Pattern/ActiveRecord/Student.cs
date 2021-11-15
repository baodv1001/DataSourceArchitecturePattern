using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architectural_Pattern.ActiveRecord
{

    public class Student
    {
        private long id;
        private string fullName;
        private string address;
        private float gpa;
        private DateTime dateOfBirth;

        //constructor
        public Student(long id, string name, string address, float gpa, DateTime dateOfBirth)
        {
            this.id = id;
            this.fullName = name;
            this.address = address;
            this.gpa = gpa;
            this.dateOfBirth = dateOfBirth;
        }
        public Student() { }

        //Getter , setter

        public long Id { get => id; set => id = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Address { get => address; set => address = value; }
        public float GPA { get => gpa; set => gpa = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }

        //domain logic method
        public bool checkBirthDate()
        {
            if (DateTime.Today.Day == dateOfBirth.Day && DateTime.Today.Month == dateOfBirth.Month)
                return true;
            return false;
        }
        public int CaculateAge()
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;
            return age;
        }
        public int checkGPA()
        {
            if (gpa >= 9)
            {
                //Xuất sắc
                return 4;
            }
            else if (gpa >= 8 && gpa < 9)
            {
                //Giỏi
                return 3;
            }
            else if (gpa >= 6.5 && gpa < 8)
            {
                //Khá
                return 2;
            }
            else if (gpa >= 5 && gpa < 6.5)
            {
                //Trung bình
                return 1;
            }
            else
            {
                //Yếu
                return 0;
            }
        }

        //SQL Operation Methods
        public void insert()
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.Open();
                string query = "INSERT INTO Student value(@id, @fullName, @address, @gpa, @dateOfBirth)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", this.Id.ToString());
                cmd.Parameters.AddWithValue("@fullName", this.FullName);
                cmd.Parameters.AddWithValue("@address", this.Address);
                cmd.Parameters.AddWithValue("@gpa", this.GPA);
                cmd.Parameters.AddWithValue("@dateOfBirth", this.DateOfBirth.ToString());

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {

                throw new Exception("Error occured reading Students from the data source.", e);
            }
            finally
            {
                connection.Close();
            }
        }
        public void update()
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.Open();
                string query = "Update Student set fullName = @fullName, address= @address, gpa = @gpa, dateOfBirth = @dateOfbBirth where id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", this.Id.ToString());
                cmd.Parameters.AddWithValue("@fullName", this.FullName);
                cmd.Parameters.AddWithValue("@address", this.Address);
                cmd.Parameters.AddWithValue("@gpa", this.GPA);
                cmd.Parameters.AddWithValue("@dateOfBirth", this.DateOfBirth.ToString());

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                // We don't want any types which use the Data Mapper
                // to be coupled to java.sql.SQLException
                // So instead, we throw a custom DataMapperException 
                throw new Exception("Error occured reading Students from the data source.", e);
            }
            finally
            {
                connection.Close();
            }
        }
        public void delete()
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.Open();
                string query = "delete from Student where id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", this.Id.ToString());

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                // We don't want any types which use the Data Mapper
                // to be coupled to java.sql.SQLException
                // So instead, we throw a custom DataMapperException 
                throw new Exception("Error occured reading Students from the data source.", e);
            }
            finally
            {
                connection.Close();
            }
        }
        public Student FindById()
        {
            Student student = new Student();
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.Open();
                string query = "select * from Student where id = " + this.Id.ToString();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                student.Id = int.Parse(dt.Rows[0].ItemArray[0].ToString());
                student.FullName = dt.Rows[0].ItemArray[1].ToString();
                student.Address = dt.Rows[0].ItemArray[2].ToString();
                student.GPA = float.Parse(dt.Rows[0].ItemArray[3].ToString());
                student.DateOfBirth = DateTime.Parse(dt.Rows[0].ItemArray[4].ToString());
                return student;
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
    }

}
