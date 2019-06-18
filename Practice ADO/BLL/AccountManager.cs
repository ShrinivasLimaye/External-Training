using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BOLayer;

namespace BLL
{
    public static class AccountManager
    {
        //Membership and Roles management related functionality

        public static bool Validate(string userName, string password)
        {
            bool status = false;
            status = AccountDAL.Validate(userName, password);
            return status;

        }

        public static bool Insert(Customer cust)
        {

            bool status = false;
            status = CustomerDAL.Insert(cust);
            return status;//Query Processing

        }


        public static bool ChangePassword(string userName, string oldpassword, string newPassword)
        {

            bool status = false;
            // CRUD Operation
            //DML commands


            return status;
        }
    }
}
