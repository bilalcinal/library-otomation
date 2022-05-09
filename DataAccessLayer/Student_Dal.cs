using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DataAccessLayer
{
  public class Student_Dal
    {
        //Öğrencinin tabloda kayıtlı olma durumu kontrol edildi
        public static bool studentControl(Student_Data student)
        {
            OleDbCommand command = new OleDbCommand("Select * from Student where StdntNo=@StdntNo and StdntPassword=@StdntPassword", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@StdntNo", student.StdntNo);
            command.Parameters.AddWithValue("@StdntPassword", student.StdntPassword);

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

        //Yeni eklenecek öğrenci ile veri tabanındaki herhangi bir öğrencinin numraları çakışmaması için kontrol edildi
        public static bool studentNoControl(Student_Data student)
        {
            OleDbCommand command = new OleDbCommand("Select count(StdntNo) FROM Student Where StdntNo=@StdntNo", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@StdntNo", student.StdntNo);
            int count = Convert.ToInt32(command.ExecuteScalar());

            if (count > 0)
            {
                return false;
            }
            return true;

        }

        //Ogrenci no ve şifreye ait id çekildi ve int döndürüldü
        public static int studentIdQuery(Student_Data student)
        {
            OleDbCommand command = new OleDbCommand("Select StdntId from Student where StdntNo=@StdntNo and StdntPassword=@StdntPassword", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@StdntNo", student.StdntNo);
            command.Parameters.AddWithValue("@StdntPassword", student.StdntPassword);

            OleDbDataReader reader = command.ExecuteReader();

            int id = 0;

            while (reader.Read())
            {
                id = int.Parse(reader["StdntId"].ToString());
            }
            return id;
        }

        //Öğrenci id ile veritabanında kayıtlı olma durumu kontrol edildi
        public static bool studentQuery(Student_Data student)
        {
            OleDbCommand command = new OleDbCommand("Select * from Student where StdntId=@StdntId", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@StdntId", student.StdntId);

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


        // Öğrenci tablosuna girilen öğrenci bilgileri eklendi
        public static int studentAdd(Student_Data student)
        {
            OleDbCommand command = new OleDbCommand("insert into Student(StdntName,StdntLastname,StdntNo,StdntPassword) values(@StdntName,@StdntLastname,@StdntNo,@StdntPassword)", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@StdntName", student.StdntName);
            command.Parameters.AddWithValue("@StdntLastname", student.StdntLastname);
            command.Parameters.AddWithValue("@StdntNo", student.StdntNo);
            command.Parameters.AddWithValue("@StdntPassword", student.StdntPassword);
           

            return command.ExecuteNonQuery();
        }


        // İd ye ait öğrenci , Ogrenci tablosundan silindi
        public static int studentDelete(Student_Data student)
        {
            OleDbCommand command = new OleDbCommand("Delete from Student where StdntId=@StdntId ", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@StdntId", student.StdntId);

            return command.ExecuteNonQuery();
        }


        // Ogrenci Id ye ait bilgilerin güncellenme işlemi gerçekleştirildi
        public static int studentUpdate(Student_Data student)
        {
            OleDbCommand command = new OleDbCommand("Update Student set StdntName=@StdntName,StdntLastname=@StdntLastname,StdntNo=@StdntNo,StdntPassword=@StdntPassword  where StdntId=@StdntId", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@StdntName", student.StdntName);
            command.Parameters.AddWithValue("@StdntLastname", student.StdntLastname);
            command.Parameters.AddWithValue("@StdntNo", student.StdntNo);
            command.Parameters.AddWithValue("@StdntPassword", student.StdntPassword);
            command.Parameters.AddWithValue("@StdntId", student.StdntId);

            return command.ExecuteNonQuery();
        }


        // Öğrenciye ait tüm bilgilerin listelenmesi gerçekleştirildi
        public static List<Student_Data> list()
        {
            OleDbCommand command = new OleDbCommand("Select * from Student", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            OleDbDataReader read = command.ExecuteReader();
            List<Student_Data> student = new List<Student_Data>();

            while (read.Read())
            {
                student.Add(new Student_Data()
                {
                    StdntId = int.Parse(read["StdntId"].ToString()),
                    StdntName = read["StdntName"].ToString(),
                    StdntLastname = read["StdntLastname"].ToString(),
                    StdntNo = read["StdntNo"].ToString(),
                    StdntPassword = read["StdntPassword"].ToString(),
                    
                    StdntFine = float.Parse(read["StdntFine"].ToString())
                });
            }

            return student;
        }




        //Ogrenci id ye ait tüm bilgiler Ogrenci tablosundan çekildi
        public static Student_Data studentIdInfo(Student_Data student)
        {
            OleDbCommand command = new OleDbCommand("Select * from Student where StdntId = @StdntId", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@StdntId", student.StdntId);
            OleDbDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                student.StdntName = read["StdntName"].ToString();
                student.StdntLastname = read["StdntLastname"].ToString();
                student.StdntNo = read["StdntNo"].ToString();
                student.StdntPassword = read["StdntPassword"].ToString();
                
                student.StdntFine = float.Parse(read["StdntFine"].ToString());
            }

            return student;
        }
    }
}
