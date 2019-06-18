using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayer;
using DAL;
namespace BLL
{
    public class EmployeeManager
    {
        public static bool Insert(Employee emp)
        {

            bool status = false;
            status = EmployeeDAL.Insert(emp);
            return status;

        }

    }
}
