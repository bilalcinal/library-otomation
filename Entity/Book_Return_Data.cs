using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity
{
    //Kİtap iade işlemleri için verilerini diğer katmanlarda kullanabilmek amacı ile get set işlemi yapıldı
    public class Book_Return_Data
    {
        int BookRegistrationId, StudentId, BookId;
        DateTime BookDelivery;
        DateTime BookTake;
        bool BookControl;
        float StudentFine;


        public int BkRgrtId { get => BookRegistrationId; set => BookRegistrationId = value; }
        public int BkId { get => BookId; set => BookId = value; }
        public int StdntId { get => StudentId; set => StudentId = value; }
        public DateTime BkTake { get => BookTake; set => BookTake = value; }
        public DateTime BkDelivery { get => BookDelivery; set => BookDelivery = value; }
        public bool BkControl { get => BookControl; set => BookControl = value; }
        public float StdntFine { get => StudentFine; set => StudentFine = value; }
    }
}
