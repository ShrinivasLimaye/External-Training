using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        [DisplayName("Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }
    }


    //public class StudentViewModel
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public List<Subject> Subjects { get; set; }

    //}


    public class Subject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Question> Questions { get; set; }
    }
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionString { get; set; }
        public ICollection<PossibleAnswer> PossibleAnswers { get; set; }
        public int SelectedAnswerId { get; set; }
    }
    public class PossibleAnswer
    {
        public int Id { get; set; }
        public string Answer { get; set; }
    }
}
