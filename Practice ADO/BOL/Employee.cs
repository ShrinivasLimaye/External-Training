using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{


    public enum Gender
    {
        Male,
        Female
    }

    public class Employee
    {

        public int ID { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string City { get; set; }

        public string Gender { get; set; }
        public Gender EmployeeGender { get; set; }

        public int Age { get; set; }

        public bool isNewlyJoined { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string FullName { get; set; }

        public DateTime JoinDate { get; set; }
        public string Designation { get; set; }


    }
}
