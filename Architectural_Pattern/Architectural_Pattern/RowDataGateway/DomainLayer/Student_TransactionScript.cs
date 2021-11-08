using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architectural_Pattern.RowDataGateway.TechnicalServices;


namespace Architectural_Pattern.RowDataGateway.DomainLayer
{
    class Student_TransactionScript //can use more finder class 
    {
        public StringBuilder GetAllGoodStudents()
        {
            StudentFinder finder = new StudentFinder();
            List<StudentGateway> goodStudents = finder.FindGoodStudents();
            StringBuilder result = new StringBuilder();
            for(int i = 0; i < goodStudents.Count; i++)
            {
                StudentGateway eachStudent = goodStudents[i];
                result.Append(eachStudent.StudentID);
                result.Append(" ");
                result.Append(eachStudent.Name);
                result.Append(" "); 
                result.Append(eachStudent.Grade);
                result.Append(";\n");
            }
            return result;
        }
    }
}
