using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architectural_Pattern.RowDataGateway.TechnicalServices
{
    class StudentGateway
    {
        private Guid guid; // Note that unique ID is read-only!
        private int studentID;
        private string name;
        private string grade;

        public StudentGateway()
        {
            this.Guid = Guid.NewGuid();
        }

        public StudentGateway(Guid guid)
        {
            this.Guid = guid;
        }

        public Guid Guid { get => guid; set => guid = value; }
        public int StudentID { get => studentID; set => studentID = value; }
        public string Name { get => name; set => name = value; }
        public string Grade { get => grade; set => grade = value; }


        public void Update()
        {
            try
            {
                SqlConnection conn = new SqlConnection("");
                SqlConnection db = null; //connection string here
                db.Open();

                string statement = "UPDATE `students` SET `grade`=@grade, `studentID`=@studentID, `name`=@name where `guid`=@guid";
                SqlCommand command = new(statement, conn);
                command.Parameters.AddWithValue("@grade", this.grade);
                command.Parameters.AddWithValue("@studentID", this.studentID);
                command.Parameters.AddWithValue("@name", this.name);
                command.Parameters.AddWithValue("@guid", this.guid);
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception("Error occured updateing Students to the data source.", e);
            }
        }
        public void Insert()
        {
            try
            {
                SqlConnection conn = new SqlConnection("");
                SqlConnection db = null; //connection string here
                db.Open();

                string statement = "INSERT INTO `students`(guid,studentID,name,grade) values(@guid,@studentID,@name,@grade)";
                SqlCommand command = new(statement, conn);
                command.Parameters.AddWithValue("@grade", this.grade);
                command.Parameters.AddWithValue("@studentID", this.studentID);
                command.Parameters.AddWithValue("@name", this.name);
                command.Parameters.AddWithValue("@guid", this.guid);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error occured inserting Students to the data source.", e);
            }
        }
    }
}
