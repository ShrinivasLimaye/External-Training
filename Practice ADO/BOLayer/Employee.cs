using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLayer
{


    public enum Gender
    {
        Male,
        Female
    }

    public class Employee
    {

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


        public string FullName { get; set; }

        public string Designation { get; set; }

        public DateTime JoinDate { get; set; }
    }
}
