using System;

namespace PeopleQuest.Models
{
    public class PersonSummaryViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public DateTime BirthDate { get; set; }
        public int Age => new DateTime((DateTime.Now - BirthDate).Ticks).Year - 1;
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Interests { get; set; }
    }
}