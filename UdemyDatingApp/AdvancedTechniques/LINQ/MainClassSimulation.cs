using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using UdemyDatingApp.Entities;

namespace UdemyDatingApp.AdvancedTechniques.LINQ
{
    public class MainClassSimulation
    {
        public void ExecuteLinq()
        {
            var person = new List<Person>
            {
                new Person(){Name = "Alex" , Occupation = "SoftwareEngineer", Id = 1},
                new Person(){Name = "Ermioni" , Occupation = "Entrepreneur", Id = 2},
                new Person(){Name = "Jordan" , Occupation = "Mailman", Id = 11},
                new Person(){Name = "Jet" , Occupation = "Blacksmither", Id = 30}
            };
            //LINQ Extension Methods
            var filtered = person
                            .Where(ps => ps.Id > 10)
                            .OrderBy(ps => ps.Name)
                            .Select(ps => ps.Occupation);
            //LINQ Query Operators
            var filteredQuery =
                            from ps in person
                            where ps.Id > 10
                            orderby ps.Name
                            select ps.Occupation;

            var personList = person.FirstOrDefault(ps => ps.Occupation == "SoftwareEngineer");
            var personListD = person.SingleOrDefault(ps => ps.Occupation == "SoftwareEngineer");
            var personSkip = person.Skip(3).Take(1);

            foreach (var item in filtered)
            {
                Console.WriteLine(item);
            }
            /*
             //Filtering
             person.Where()
             person.Single()
             person.SingleOrDefault()

             person.First()
             person.FirstOrDefault()
             person.Last()
             person.LastOrDefault()

             //Aggregate 
             person.Min()
             person.Max()
             person.Count()
             person.Average()
             person.Sum()

             //Paging
             person.Skip(2).Take(3)
             */


        }
    }
}
