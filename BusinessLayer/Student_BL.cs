using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;      // DAL katmanını kullandık
using Entity;   // Entity katmanını kullandık
namespace BusinessLayer
{
   public class Student_BL
    {
        public static bool studentControl_BL(Student_Data student)
        {
            if (student.StdntNo != "" && student.StdntPassword != "") // Gelen verilerin boş olmadığı kontrol edildi
            {
                return Student_Dal.studentControl(student); // Veritabanından girilen değerlere ait öğrenci kontrol edildi
            }

            else                    //Eğer gelen veri boş ise false döndürdü
                return true;
        }

        public static bool studentNoControl(Student_Data student)
        {
            if (student.StdntNo != "") // Gelen verilerin boş olmadığı kontrol edildi
            {
                return Student_Dal.studentNoControl(student); // Veritabanından girilen değerlere ait öğrenci kontrol edildi
            }

            else                    //Eğer gelen veri boş ise false döndürdü
                return false;
        }

        public static int studentIdQuery(Student_Data student)
        {
            if (student.StdntNo != "" && student.StdntNo != "") // Gelen verilerin boş olmadığı kontrol edildi
            {
                return Student_Dal.studentIdQuery(student); // Veritabanından girilen değerlere ait öğrenci kontrol edildi
            }

            else                    //Eğer gelen veri boş ise false döndürdü
                return -1;
        }

        public static Student_Data studentIdInfo(Student_Data student)
        {
            if (student.StdntId!= 0) // Gelen verilerin boş olmadığı kontrol edildi
            {
                return Student_Dal.studentIdInfo(student); // Veritabanından girilen değerlere ait öğrenci kontrol edildi
            }

            else                    //Eğer gelen veri boş ise NULL döndürdü
                return null;
        }

        public static bool studentQuery_BL(Student_Data student)
        {
            if (student.StdntId != 0) // Gelen verilerin boş olmadığı kontrol edildi
            {
                return Student_Dal.studentQuery(student); // Veritabanından girilen değerlere ait öğrenci kontrol edildi
            }

            else                    //Eğer gelen veri boş ise false döndürdü
                return false;
        }


        //Girilen öğrenci bilgileri DAL katmanı kullanılarak veritabanına eklendi
        public static int studentAdd(Student_Data student)
        {
            if (student.StdntName != "" && student.StdntLastname != "" && student.StdntNo != "" && student.StdntPassword != "" )
            {

                return Student_Dal.studentAdd(student);
            }

            else
                return -1;
        }


        //Girilen id 'ye  ait öğrenci DAL katmanı kullanılarak veri tabanından silindi
        public static int studentDelete(Student_Data student)
        {
            if (student.StdntId != 0)
            {

                return Student_Dal.studentDelete(student);
            }

            else
                return -1;
        }

        //Girilen id 'ye  ait öğrenci DAL katmanı kullanılarak veri tabanındaki verileri güncellendi
        public static int studentUpdate(Student_Data student)
        {
            if (student.StdntName != "" && student.StdntLastname != "" && student.StdntNo != "" && student.StdntPassword != ""  && student.StdntId != 0)
            {

                return Student_Dal.studentUpdate(student);
            }

            else
                return -1;
        }


        //Veri tabanındaki tüm öğrenci bilgileri DAL katmanı kullanılarak listeye aktarıldı
        public static List<Student_Data> list()
        {

            return Student_Dal.list();
        }
    }
}
