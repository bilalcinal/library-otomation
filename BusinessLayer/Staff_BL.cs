using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;      // DAL katmanını kullandık
using Entity;   // Entity katmanını kullandık
namespace BusinessLayer
{
    public class Staff_BL
    {
        //Class'i public olarak tanımlamamızın sebebi diğer classlardan erişim sağlayabilmek için

        //Girilen tc ve sifreye ait görevli veri tabanında kayıtlı mı diye DAL katmanı kullanılarak kontrol edildi
        public static bool staffControl_BL(Staff_Data staff)
        {
            if (staff.StfIn != "" && staff.StfPassword != "")
                return Staff_Dal.staffControl(staff);

            else
                return false;
        }
    }
}
