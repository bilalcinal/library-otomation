using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DataAccessLayer
{
  public  class Book_Dal
    {
        // Kİtabın veri tabanındaki kitap tablosunda kayıtlı mı  diye id sorgusu ile kontrol edildi
        public static bool bookQuery(Book_Data book)
        {
            OleDbCommand command = new OleDbCommand("Select * from Book where BkId=@BkId", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@BkId", book.BkId);

            OleDbDataReader reader = command.ExecuteReader();
            bool conclusion = false;
            int counter = 0;

            while (reader.Read())
            {
                counter++;
            }


            if (counter > 0)
            {
                conclusion = true;
            }

            return conclusion;
        }

        ////public static bool bookQuery()
        //{
        //    throw new NotImplementedException();
        //}

        //Veri tabanındaki Kitap tablosuna ekleme işlemi gerçekleştirildi
        public static int bookAdd(Book_Data book)
        {
            OleDbCommand command = new OleDbCommand("insert into Book(BkName,BkType,BkPage,BkWriter) values(@BkName,@BkType,@BkPage,@BkWriter)", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@BkName", book.BkName);
            command.Parameters.AddWithValue("@BkType", book.BkType);
            command.Parameters.AddWithValue("@BkPage", book.BkPage);
            command.Parameters.AddWithValue("@BkWriter", book.BkWriter);

            return command.ExecuteNonQuery();
        }

        //public static List<Book_Data> BookList()
        //{
        //    throw new NotImplementedException();
        //}


        //Veri tabanındaki Kitap tablosundaki veriler listelendi
        public static List<Book_Data> bookList()
        {
            OleDbCommand command = new OleDbCommand("Select * from Book", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            OleDbDataReader read = command.ExecuteReader();
            List<Book_Data> book = new List<Book_Data>();

            while (read.Read())
            {
                book.Add(new Book_Data()
                {
                    BkId = int.Parse(read["BkId"].ToString()),
                    BkName = read["BkName"].ToString(),
                    BkType = read["BkType"].ToString(),
                    BkPage = read["BkPage"].ToString(),
                    BkWriter = read["BkWriter"].ToString()
                });
            }

            return book;
        }


        // Veri tabanındaki kitap tablosunda bulunan id sorgusundaki kitap silindi
        public static int bookDelete(Book_Data book)
        {
            OleDbCommand command = new OleDbCommand("Delete from Book where BkId=@BkId ", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@BkId", book.BkId);

            return command.ExecuteNonQuery();
        }

        // Veri tabanında bulunan kitap tablosundaki kitap id ile eşleşen kitap güncellendi
        public static int bookUpdate(Book_Data book)
        {
            OleDbCommand command = new OleDbCommand("Update Book set BkName=@BkName,BkType=@BkType,BkPage=@BkPage,BkWriter=@BkWriter where BkId=@BkId", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@BkName", book.BkName);
            command.Parameters.AddWithValue("@BkType", book.BkType);
            command.Parameters.AddWithValue("@BkPage", book.BkPage);
            command.Parameters.AddWithValue("@BkWriter", book.BkWriter);
            command.Parameters.AddWithValue("@BkId", book.BkId);

            return command.ExecuteNonQuery();
        }

        // Sorgudaki id ye sahip kitabın bilgileri kitap tablosundan çekildi
        public static Book_Data bookIdInformation(Book_Data book)
        {
            OleDbCommand command = new OleDbCommand("Select * from Book where BkId = @BkId", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@BkId", book.BkId);
            OleDbDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                book.BkName = read["BkName"].ToString();
                book.BkType = read["BkType"].ToString();
                book.BkPage = read["BkPage"].ToString();
                book.BkWriter = read["BkWriter"].ToString();
            }

            return book;
        }
    }
}
