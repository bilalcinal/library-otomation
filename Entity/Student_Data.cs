using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity
{
   public class Student_Data
    {
        int StudentId;
        string StudentName, StudentLastname, StudentNo, StudentPassword ;
        float StudentFine;

        public int StdntId { get => StudentId; set => StudentId = value; }
        public string StdntName { get => StudentName; set => StudentName = value; }
        public string StdntLastname { get => StudentLastname; set => StudentLastname = value; }
        public string StdntNo { get => StudentNo; set => StudentNo = value; }
        public string StdntPassword { get => StudentPassword; set => StudentPassword = value; }
       
        public float StdntFine { get => StudentFine; set => StudentFine = value; }
    }
}
