using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;   // Entity katmanını kullanacağımız için ekledik.
using DataAccessLayer; // Entity katmanına erişim sağlandı
namespace BusinessLayer
{
   public class Book_BL
    {
        //Girilen KitapId' ye ait kitap veri tabanında kayıtlı mı diye DAL katmanı kullanılarak kontrol edildi
        public static bool BookQuery_BL(Book_Data book)
        {
            if (book.BkId != 0) // Gelen verilerin boş olmadığı kontrol edildi
            {
                return Book_Dal.bookQuery(book); // Veritabanından girilen değerlere ait kitap kontrol edildi
            }

            else                    //Eğer gelen veri boş ise false döndürdü
                return false;
        }


        //Kitap ekleme işlemi DAL katmanı kullanılarak gerçekleştirildi
        public static int BookAdd(Book_Data book)
        {
            if (book.BkName != "" && book.BkType != "" && book.BkPage != "" && book.BkWriter != "")
            {

                return Book_Dal.bookAdd(book);
            }

            else
                return -1;
        }

        //Kİtap bilgilerinin olduğu liste DAL katmanı kullanılarak aktarıldı
        public static List<Book_Data> BookList()
        {

            return Book_Dal.bookList();
        }


        // Id ' ye ait kitap  DAL katmanı kullanılara silindi
        public static int BookDelete(Book_Data book)
        {
            if (book.BkId != 0)
            {

                return Book_Dal.bookDelete(book);
            }

            else
                return -1;
        }


        // Id' ye kitap DAL katmanı kullanılarak güncellendi
        public static int BookUpdate(Book_Data book)
        {
            if (book.BkId != 0 && book.BkName != "" && book.BkType != "" && book.BkPage != "" && book.BkWriter != "")
            {

                return Book_Dal.bookUpdate(book);
            }

            else
                return -1;
        }

        // DAL katmanı kullanılarak Kitap id ile kitap bilgileri çekildi
        public static Book_Data BookIdInfo(Book_Data book)
        {
            if (book.BkId != 0) // Gelen verilerin boş olmadığı kontrol edildi
            {
                return Book_Dal.bookIdInformation(book); // Veritabanından girilen değerlere ait öğrenci kontrol edildi
            }

            else                    //Eğer gelen veri boş ise false döndürdü
                return null;
        }

    }
}
