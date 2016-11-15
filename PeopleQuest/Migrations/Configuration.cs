using System.Drawing;
using PeopleQuest.Models;

namespace PeopleQuest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PeopleQuestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PeopleQuestContext context)
        {
            //  This method will be called after migrating to the latest version.
            var converter = new ImageConverter();
            context.Persons.AddOrUpdate(p => new { p.FirstName, p.LastName },
                new Person
                {
                    FirstName = "Tyrion",
                    LastName = "Lannister",
                    Address1 = "King's Landing",
                    BirthDate = DateTime.Parse("1/1/1977"),
                    Interests = "Drinking, Sarcasm, Companionship",
                    Image = (byte[])converter.ConvertTo(SeedResource.Tyrion_Lannister, typeof(byte[]))
                });
            context.Persons.AddOrUpdate(p => new { p.FirstName, p.LastName },
                new Person
                {
                    FirstName = "Cersei",
                    LastName = "Lannister",
                    Address1 = "King's Landing",
                    BirthDate = DateTime.Parse("1/1/1975"),
                    Interests = "Treachery, Plotting, Brotherly Love",
                    Image = (byte[])converter.ConvertTo(SeedResource.Cersei_Lannister, typeof(byte[]))
                });
            context.Persons.AddOrUpdate(p => new { p.FirstName, p.LastName },
                new Person
                {
                    FirstName = "Jon",
                    LastName = "Snow",
                    Address1 = "The Wall",
                    BirthDate = new DateTime(1989, 1, 1),
                    Interests = "Wildlings, Night's Watch, Direwolves, Redheads",
                    Image = (byte[])converter.ConvertTo(SeedResource.Jon_Snow, typeof(byte[]))
                });
            context.Persons.AddOrUpdate(p => new { p.FirstName, p.LastName },
                new Person
                {
                    FirstName = "Daenerys",
                    LastName = "Targaryen",
                    Address1 = "Great Pyramid",
                    Address2 = "Bay of Dragons, Essos",
                    BirthDate = new DateTime(1990, 1, 1),
                    Interests = "Dragons, Dothraki, Fire",
                    Image = (byte[])converter.ConvertTo(SeedResource.Daenerys_Targaryen, typeof(byte[]))
                });
            context.Persons.AddOrUpdate(p => new { p.FirstName, p.LastName },
                new Person
                {
                    FirstName = "Jaime",
                    LastName = "Lannister",
                    Address1 = "King's Landing",
                    BirthDate = new DateTime(1975, 1, 1),
                    Interests = "Swords, Oaths, Cersei",
                    Image = (byte[])converter.ConvertTo(SeedResource.Jaime_Lannister, typeof(byte[]))
                });
            context.Persons.AddOrUpdate(p => new { p.FirstName, p.LastName },
                new Person
                {
                    FirstName = "Petyr",
                    LastName = "Baelish",
                    Address1 = "Baelish Castle",
                    BirthDate = DateTime.Parse("1/1/1980"),
                    Interests = "Chaos, The Vale, Redheads",
                    Image = (byte[])converter.ConvertTo(SeedResource.Petyr_Baelish, typeof(byte[]))
                });
            context.Persons.AddOrUpdate(p => new { p.FirstName, p.LastName },
                new Person
                {
                    FirstName = "Sansa",
                    LastName = "Stark",
                    Address1 = "Winterfell",
                    BirthDate = DateTime.Parse("1/1/2000"),
                    Interests = "Family, Direwolves, Lemon Squares",
                    Image = (byte[])converter.ConvertTo(SeedResource.Sansa_Stark, typeof(byte[]))
                });
            context.Persons.AddOrUpdate(p => new { p.FirstName, p.LastName },
                new Person
                {
                    FirstName = "Arya",
                    LastName = "Stark",
                    Address1 = "House of Black and White",
                    Address2 = "Braavos",
                    BirthDate = DateTime.Parse("1/1/2002"),
                    Interests = "Swordfighting, Justice, Direwolves",
                    Image = (byte[])converter.ConvertTo(SeedResource.Arya_Stark, typeof(byte[]))
                });
            context.Persons.AddOrUpdate(p => new { p.FirstName, p.LastName },
                new Person
                {
                    FirstName = "Jorah",
                    LastName = "Mormont",
                    Address1 = "House Mormont",
                    Address2 = "Bear Island, Westeros",
                    BirthDate = DateTime.Parse("1/1/1960"),
                    Interests = "Spying, Loyalty, Fiery Blondes",
                    Image = (byte[])converter.ConvertTo(SeedResource.Jorah_Mormont, typeof(byte[]))
                });

            context.Persons.AddOrUpdate(p => new { p.FirstName, p.LastName },
                new Person
                {
                    FirstName = "Sandor \"The Hound\"",
                    LastName = "Clegane",
                    Address1 = "",
                    Address2 = "Westeros",
                    BirthDate = DateTime.Parse("1/1/1975"),
                    Interests = "Fighting, Drinking, Chicken",
                    Image = (byte[])converter.ConvertTo(SeedResource.Sandor_Clegane, typeof(byte[]))
                });

            context.Persons.AddOrUpdate(p => new { p.FirstName, p.LastName },
                new Person
                {
                    FirstName = "Khal",
                    LastName = "Drogo",
                    Address1 = "",
                    Address2 = "Essos",
                    BirthDate = DateTime.Parse("1/1/1990"),
                    Interests = "Horses, War, Pillaging, Fiery Blondes",
                    Image = (byte[])converter.ConvertTo(SeedResource.Khal_Drogo, typeof(byte[]))
                });


            context.Persons.AddOrUpdate(p => new { p.FirstName, p.LastName },
                new Person
                {
                    FirstName = "Melisandre",
                    Address1 = "House Baratheon",
                    Address2 = "The Stormlands, Westeros",
                    BirthDate = DateTime.Parse("1/1/1790"),
                    Interests = "Magic, Fire, Burning People at the Stake",
                    Image = (byte[])converter.ConvertTo(SeedResource.Melisandre, typeof(byte[]))
                });
        }
    }
}
