using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architectural_Pattern.RowDataGateway.TechnicalServices
{
    class StudentFinder //Technical Service
    {
        public static SqlConnection conn = new SqlConnection("");
        public  StudentGateway FindByGuId(Guid uniqueID)
        {

            try
            {
                SqlConnection db = null; //connection string here
                db.Open();

                string statement = "SELECT `guid`, `grade`, `studentID`, `name` FROM `students` where `guid`=@guid";

                SqlCommand command = new(statement, conn);
                command.Parameters.AddWithValue("@guid", uniqueID);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new(command);

                DataTable dataTable = new();
                adapter.Fill(dataTable);

                Guid guid = Guid.Parse(dataTable.Rows[0].ItemArray[0].ToString());
                String name = dataTable.Rows[0].ItemArray[1].ToString();
                string grade = dataTable.Rows[0].ItemArray[2].ToString();
                int studentID = int.Parse(dataTable.Rows[0].ItemArray[3].ToString());

                StudentGateway student = new StudentGateway(guid);
                student.Name = name;
                student.Grade = grade;
                student.StudentID = studentID;

                return student;

            }
            catch (Exception e)
            {
                throw new Exception("Error occured reading Students from the data source.", e);
            }
        }
        public List<StudentGateway> FindAll()
        {
            return new List<StudentGateway>();
        }
        public List<StudentGateway> FindGoodStudents() //grade A
        {
            try
            {
                SqlConnection db = null; //connection string here
                db.Open();
                string statement = "SELECT * FROM `students` where grade='A'";
                SqlCommand command = new(statement, conn);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new(command);

                DataTable dataTable = new();
                adapter.Fill(dataTable);
                List<StudentGateway> result = new List<StudentGateway>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Guid guid = Guid.Parse(dataTable.Rows[i].ItemArray[0].ToString());
                    String name = dataTable.Rows[i].ItemArray[1].ToString();
                    string grade = dataTable.Rows[i].ItemArray[2].ToString();
                    int studentID = int.Parse(dataTable.Rows[i].ItemArray[3].ToString());

                    StudentGateway student = new StudentGateway(guid);
                    student.Name = name;
                    student.Grade = grade;
                    student.StudentID = studentID;
                    result.Add(student);
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Error occured reading Students from the data source.", e);
            }
        }
    }
}
