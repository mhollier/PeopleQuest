using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;

namespace PeopleQuest.Models
{
    /// <summary>
    /// The database context for the PeopleQuest database.
    /// </summary>
    public class PeopleQuestContext : DbContext
    {
        public PeopleQuestContext() 
            : base("DefaultConnection")
        {
        }

        public PeopleQuestContext(DbConnection conn) 
            : base(conn, true)
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}