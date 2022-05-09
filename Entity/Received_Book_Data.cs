using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Entity
{
    public class Received_Book_Data
    {

    int StudentId;
    string BookName, BookDelivery;
    DateTime BookTake;
    bool BookControl;

    public int StdntId { get => StudentId; set => StudentId = value; }
    public string BkName { get => BookName; set => BookName = value; }
    public DateTime BkTake { get => BookTake; set => BookTake = value; }
    public string BkDelivery { get => BookDelivery; set => BookDelivery = value; }
    public bool BkControl { get => BookControl; set => BookControl = value; }
}
}
