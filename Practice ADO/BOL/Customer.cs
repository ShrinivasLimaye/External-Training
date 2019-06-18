using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BOL
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string City { get; set; }
        public int Id { get; set; }

        [DisplayName("Full Name")]
        public string Name { get; set; }
        public string Email { get; set; }

        [DisplayName("Registration Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }
        public string Membership { get; set; }
        public string Location { get; set; }
        public int zip;
        [DisplayName("Most Valueable Customer")]
        public bool isMVC { get; set; }


    }
}

/*
 OutoftheBox Annotations

Required	        Indicates that the property is a required field
StringLength	    Defines a maximum length for string field
Range	            Defines a maximum and minimum value for a numeric field
RegularExpression	Specifies that the field value must match with specified Regular Expression
CreditCard	        Specifies that the specified field is a credit card number
CustomValidation	Specified custom validation method to validate the field
EmailAddress	    Validates with email address format
FileExtension	    Validates with file extension
MaxLength	        Specifies maximum length for a string field
MinLength	        Specifies minimum length for a string field
Phone	            Specifies that the field is a phone number using regular expression for phone numbers
 */
