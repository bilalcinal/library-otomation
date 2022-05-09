using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Student_Book_Data {


    int BookId;
    string StudentName, StudentLastname, BookName, BookDelivery;
    DateTime BookTake;
    bool BookControl;


    public int BkId { get => BookId; set => BookId = value; }
    public string StdntName { get => StudentName; set => StudentName = value; }
    public string StdntLastname { get => StudentLastname; set => StudentLastname = value; }
    public string BkName { get => BookName; set => BookName = value; }
    public DateTime BkTake { get => BookTake; set => BookTake = value; }
    public string BkDelivery { get => BookDelivery; set => BookDelivery = value; }
    public bool BkControl { get => BookControl; set => BookControl = value; }
}
}
