using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DataAccessLayer
{
   public class Book_Return_Dal
    {
        //Kitabı alanların detaylı listesini inner join yöntemi ile 3 tablodan verilerini çekerek aldık
        public static List<Student_Book_Data> StudentBookList(Student_Book_Data book)
        {


            OleDbCommand command = new OleDbCommand("Select b.BkId,s.StdntName,s.StdntLastname,b.BkName,bb.BkTake,bb.BkDelivery,bb.BkControl from ((book b inner join BookRegistration bb on b.BkId=bb.BkId) inner join Student s on s.StdntId=bb.StdntId) where b.BkId = @BkId", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@BkId", book.BkId);
            OleDbDataReader read = command.ExecuteReader();
            List<Student_Book_Data> studentBook = new List<Student_Book_Data>();

            while (read.Read())
            {
                studentBook.Add(new Student_Book_Data()
                {
                    BkId = int.Parse(read["BkId"].ToString()),
                    StdntName = read["BkName"].ToString(),
                    StdntLastname = read["BkLastname"].ToString(),
                    BkName = read["BkName"].ToString(),
                    BkTake = DateTime.Parse(read["BkTake"].ToString()),
                    BkDelivery = read["BkDelivery"].ToString(),
                    BkControl = bool.Parse(read["BkControl"].ToString())
                });
            }

            return studentBook;
        }


        //Ogrencinin almış olduğu kitaplar tarihsel olarak listelendi. Yine inner join yöntemi ile veriler çekildi
        public static List<Received_Book_Data> StudentIdList(Received_Book_Data book)
        {


            OleDbCommand command = new OleDbCommand("Select s.StdntId,b.BkName,bb.BkTake,bb.BkDelivery,bb.BkControl from ((book b inner join BookRegistration bb on b.BkId=bb.BkId) inner join Student s on s.StdntId=bb.StdntId) where s.StdntId = @StdntId", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@StdntId", book.StdntId);
            OleDbDataReader read = command.ExecuteReader();
            List<Received_Book_Data> studentBook = new List<Received_Book_Data>();
            while (read.Read())
            {
                studentBook.Add(new Received_Book_Data()
                {
                    StdntId = int.Parse(read["StdntId"].ToString()),
                    BkName = read["BkName"].ToString(),
                    BkTake = DateTime.Parse(read["BkTake"].ToString()),
                    BkDelivery = read["BkDelivery"].ToString(),
                    BkControl = bool.Parse(read["BkControl"].ToString())
                });
            }

            return studentBook;
        }

        //Alinabilir durumdaki kitapların teslim edilme durumlarına göre listeleme işlemi gerçekleştirildi
        public static List<string> TakeBookList(Book_Return_Data book)
        {
            OleDbCommand command = new OleDbCommand("Select BkName from Book where BkId not in(select BkId from BookRegistration where StdntId=@StdntId and BkControl=false)", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@StdntId", book.StdntId);
            OleDbDataReader read = command.ExecuteReader();

            List<string> liste = new List<string>();

            while (read.Read())
            {
                liste.Add(read["BkName"].ToString());
            }

            return liste;
        }

        //Teslim edilmesi gereken kitaplar teslim edilmeme durumuna göre listeye aktarıldı
        public static List<string> DeliveryBookList(Book_Return_Data book)
        {
            OleDbCommand command = new OleDbCommand("Select BkName from Book where BkId in(select BkId from BookRegistration where StdntId=@StdntId  and BkControl=false)", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@BkId", book.StdntId);
            OleDbDataReader read = command.ExecuteReader();

            List<string> liste = new List<string>();

            while (read.Read())
            {
                liste.Add(read["BkName"].ToString());
            }

            return liste;
        }

        //Öğrenciye verilmiş kitapların sayısı int olarak döndürüldü
        public static int graphicReturned(Book_Return_Data book)
        {
            OleDbCommand command = new OleDbCommand("Select BkName from Book where BkId in(select BkId from BookRegistration where StdntId=@StdntId  and BkControl=false)", Connection_Dal.connect); 
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@StdntId", book.StdntId);
            OleDbDataReader read = command.ExecuteReader();
            int counter = 0;
            while (read.Read())
            {
                counter++;
            }

            return counter;
        }

        //Tüm kitapların sayısı int olarak döndürüldü
        public static int Graphics()
        {
            OleDbCommand command = new OleDbCommand("Select * from Book", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            OleDbDataReader read = command.ExecuteReader();
            int counter = 0;
            while (read.Read())
            {
                counter++;
            }

            return counter;
        }

        //Alınabilir kitapların sayısı int olarak döndürüldü
        public static int graphicReceivable(Book_Return_Data book)
        {
            OleDbCommand command = new OleDbCommand("Select BkName from Book where BkId not in(select BkId from BookRegistration where StdntId=@StdntId and BkControl=false)", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@StdntId", book.StdntId);
            OleDbDataReader read = command.ExecuteReader();
            int counter = 0;
            while (read.Read())
            {
                counter++;
            }

            return counter;
        }

        // Alınma tarihini kitapkayıt tablosundan çekip listeye aktardık
        public static List<string> bookDate(Book_Return_Data book)
        {
            OleDbCommand command = new OleDbCommand("Select BkTake from BookRegistration where BkId=@BkId and StdntId=@StdntId", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@BkId", book.BkId);
            command.Parameters.AddWithValue("@StdntId", book.StdntId);
            OleDbDataReader read = command.ExecuteReader();

            List<string> liste = new List<string>();

            while (read.Read())
            {
                book.BkTake = DateTime.Parse(read["BkTake"].ToString());
            }

            return liste;
        }


        //Veritabanından öğrenciye ait ceza bilgisi listeye aktarıldı
        public static List<string> studentFine(Book_Return_Data book)
        {
            OleDbCommand command = new OleDbCommand("Select s.StdntFine from ((Book b inner join BookRegistration bb on b.BkId=bb.BkId) inner join Student s on s.StdntId=bb.StdntId) where s.StdntId = @StdntId", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@StdntId", book.StdntId);
            OleDbDataReader read = command.ExecuteReader();

            List<string> liste = new List<string>();

            while (read.Read())
            {
                book.StdntFine = float.Parse(read["StdntFine"].ToString());
            }

            return liste;
        }

        //Ceza işlemi gerçekleştirildikten sonra ogrenciye ait ceza verisinde guncelleme yapıldı
        public static int studentFineProcess(Book_Return_Data student)
        {
            OleDbCommand command = new OleDbCommand("Update Student set StdntFine=@StdntFine where StdntId=@StdntId", Connection_Dal.connect);
            Connection_Dal.Connection(command);

            command.Parameters.AddWithValue("@StdntFine", student.StdntFine);
            command.Parameters.AddWithValue("@StdntId", student.StdntId);

            return command.ExecuteNonQuery();
        }






        //Kitap alındğında veri tabanına veriler eklendi
        public static int takeBookProcess(Book_Return_Data book)
        {
            OleDbCommand command = new OleDbCommand("insert into  BookRegistration(BkId,StdntId,BkTake) values(@BkId,StdntId,@BkTake)", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@BkId", book.BkId);
            command.Parameters.AddWithValue("@StdntId", book.StdntId);
            command.Parameters.AddWithValue("@BkTake", book.BkTake);
            return command.ExecuteNonQuery();
        }

        //Kitap teslim edildiğinde veriler güncellendi
        public static int bookDeliveryProcess(Book_Return_Data book)
        {
            OleDbCommand command = new OleDbCommand("Update BookRegistration set BkDelivery=@BkDelivery,BkControl=@BkControl where BkId=@BkId  and  StdntId=@Student", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@BkDelivery", book.BkDelivery);
            command.Parameters.AddWithValue("@BkControl", book.BkControl);
            command.Parameters.AddWithValue("@BkId", book.BkId);
            command.Parameters.AddWithValue("@StdntId", book.StdntId);
            return command.ExecuteNonQuery();
        }


        //Kitap adı sorgusu ile ada ait kitapId verisi int döndürüldü
        public static int bookId(Student_Book_Data book)
        {
            OleDbCommand command = new OleDbCommand("Select BkId from Book where BkName=@BkName", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@BkName", book.BkName);
            OleDbDataReader read = command.ExecuteReader();

            int id = 0;
            while (read.Read())
            {

                id = int.Parse(read["BkId"].ToString());
            }

            return id;


        }
    }
}
