using Architectural_Pattern.RowDataGateway.TechnicalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architectural_Pattern.RowDataGateway.DomainLayer
{
    class Student //Domain Model
    {
        private StudentGateway data;
        public Student(StudentGateway data)
        {
            this.data = data;
        }
        public string GetName()
        {
            return data.Name;
        }
        public Guid GetGuid()
        {
            return data.Guid;
        }
        public string GetGrade()
        {
            return data.Grade;
        }
        public int GetStudentID()
        {
            return data.StudentID;
        }
        public int GetMinGrade()
        {
            int numberGrade = 0;
            switch (data.Grade)
            {
                case "A":
                    numberGrade = 8;
                    break;
                case "B":
                    numberGrade = 6;
                    break;
                case "C":
                    numberGrade = 4;
                    break;
                default:
                    numberGrade = 1;
                    break;
            }
            return numberGrade;
        }
    }
}
