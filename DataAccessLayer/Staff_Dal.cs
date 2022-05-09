using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DataAccessLayer
{
     public class Staff_Dal
    {
        //Görevlinin sistemde kayıtlı olma durumu kontrol edildi
        public static bool staffControl(Staff_Data staff)
        {
            OleDbCommand command = new OleDbCommand("Select * from Staff where StfIn=@StfIn and StfPassword=@StfPassword", Connection_Dal.connect);
            Connection_Dal.Connection(command);
            command.Parameters.AddWithValue("@StfIn", staff.StfIn);
            command.Parameters.AddWithValue("@StfPassword", staff.StfPassword);

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
    }
}
