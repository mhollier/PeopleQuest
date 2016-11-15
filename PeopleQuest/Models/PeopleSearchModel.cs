using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleQuest.Models
{
    
    public class PersonListModel
    {
        public ICollection<Person> People { get; set; }
    }
}