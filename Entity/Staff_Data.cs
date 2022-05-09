using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Staff_Data {


    int StaffId;
    string StaffName, StaffLastname, StaffIn, StaffPassword;

    public int StfId { get => StaffId; set => StaffId = value; }
    public string StfName { get => StaffName; set => StaffName = value; }
    public string StfLastname { get => StaffLastname; set => StaffLastname = value; }
    public string StfIn { get => StaffIn; set => StaffIn = value; }
    public string StfPassword { get => StaffPassword; set => StaffPassword = value; }
}
}
