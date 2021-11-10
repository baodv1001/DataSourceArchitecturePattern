using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Architectural_Pattern.TableDataGateway.Gateways
{
    public class StudentGateway
    {
        private const string GET_STUDENT_BY_ID = "SELECT * FROM STUDENT WHERE ID = @ID";
        private const string DELETE_STUDENT_BY_ID = "DELETE FROM STUDENT WHERE ID = @ID";
        private const string INSERT_STUDENT = "INSERT INTO STUDENTS(ID, NAME, GRADE) VALUES(@ID, @NAME, @GRADE)";
        private const string UPDATE_STUDENT = "UPDATE STUDENT SET NAME=@NAME, GRADE=@GRADE WHERE ID=@ID";

        private readonly string _connectionString;

        public StudentGateway (string connectionString)
        {
            _connectionString = connectionString;
        }

        public void insert(int id, string name, string grade)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(INSERT_STUDENT, connection);

                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("grade", grade);

                command.ExecuteNonQuery();
            }
        }

        public void update(int id, string name, string grade)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(UPDATE_STUDENT, connection);

                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("grade", grade);

                command.ExecuteNonQuery();
            }
        }

        public DataTable getStudentById (int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable data = new DataTable();

                SqlCommand command = new SqlCommand(GET_STUDENT_BY_ID, connection);

                command.Parameters.AddWithValue("id", id);

                adapter.SelectCommand = command;
                adapter.Fill(data);

                return data;
            }
        }

        public bool deleteStudentById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                bool success = false;   
                connection.Open();

                SqlCommand command = new SqlCommand(DELETE_STUDENT_BY_ID, connection);

                command.Parameters.AddWithValue("id", id);

                success = command.ExecuteNonQuery() > 0;
                
                return success;
            }
        }
    }
}
