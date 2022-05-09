using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;      // DAL katmanını kullandık
using Entity;   // Entity katmanını kullandık
namespace BusinessLayer
{
  public  class Book_Return_BL
    {
        // DAL katmanı kullanılarak kitap id ye ait ogrenci verileri çekildi
        public static List<Student_Book_Data> studentBookList(Student_Book_Data book)
        {
            if (book.BkId != 0)
                return Book_Return_Dal.StudentBookList(book);
            else
                return null;
        }


        //Ogrencinin aldiği kitaplar DAL katmanı kullanılarak listelendi
        public static List<string> TakeBookList(Book_Return_Data book)
        {

            return Book_Return_Dal.TakeBookList(book);
        }


        //Ogrencinin teslim etmesi gereken kitaplar DAL katmanı kullanılarak listelendi
        public static List<string> BookDeliveryList(Book_Return_Data book)
        {

            return Book_Return_Dal.DeliveryBookList(book);
        }

        //kitabın Alinma tarihini DAL katmanı kullanarak öğrendik
        public static List<string> bookDate(Book_Return_Data book)
        {

            return Book_Return_Dal.bookDate(book);
        }

        // Ogrenciye ait ceza bilgisini  DAL katmanını kullanrak öğrendik
        public static List<string> studentFine(Book_Return_Data book)
        {

            return Book_Return_Dal.studentFine(book);
        }


        //Öğrenciye ait güncel ceza DAL katmanı kullanılarak eklendi
        public static int studentFineProcess(Book_Return_Data student)
        {
            if (student.StdntFine >= 0)
            {

                return Book_Return_Dal.studentFineProcess(student);
            }

            else
                return -1;
        }


        // öğrenciye ait alinabilir kitaplarin sayisi DAL katmanı kullanılarak int döndürüldü
        public static int graphicReceivable(Book_Return_Data book)
        {
            if (book.StdntId != 0)
            {
                return Book_Return_Dal.graphicReceivable(book);
            }
            return 0;
        }

        // öğrenciye ait almış olduğu kitaplarin sayisi DAL katmanı kullanılarak int döndürüldü
        public static int graphicReturned(Book_Return_Data book)
        {
            if (book.StdntId != 0)
            {
                return Book_Return_Dal.graphicReturned(book);
            }
            return 0;
        }

        // Tüm kitapların sayisi DAL katmanı kullanılarak int döndürüldü
        public static int Graphics()
        {
            return Book_Return_Dal.Graphics();
        }


        // Id ile öğrencini almış olduğu kitaplar tarihsel bir şekilde  DAL katmanı kullanılarak listelendi
        public static List<Received_Book_Data> StudentIdList(Received_Book_Data book)
        {

            return Book_Return_Dal.StudentIdList(book);
        }

        //Kİtap alma işlemi DAL katmanı kullanılarak gerçekleştirildi
        public static int takeBookProcess(Book_Return_Data book)
        {
            if (book.BkId != 0 && book.StdntId != 0 && book.BkTake != null)
            {

                return Book_Return_Dal.takeBookProcess(book);
            }

            else
                return -1;
        }

        //Kitap teslim etme işlemi DAL katmanı kullanılarak gerçekleştirildi
        public static int bookDeliveryProcess(Book_Return_Data book)
        {
            if (book.BkId != 0)
            {

                return Book_Return_Dal.bookDeliveryProcess(book);
            }

            else
                return -1;
        }



        // Kitap adı ile kitap Id bilgisi DAL katmanı kullanılarak int döndürüldü
        public static int bookId(Student_Book_Data book)
        {
            if (book.BkName != "")
            {

                return Book_Return_Dal.bookId(book);
            }

            else
                return -1;
        }
    }
}
