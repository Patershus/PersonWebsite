using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonWebsite.Models
{
    static public class DataManager
    {

        static List<Person> people = new List<Person>
        {
            new Person{Id=1, Name="Petter", Email="Petter@hotmail.com"},
            new Person{Id=2, Name="Håkan", Email="Håkan@academicwork.com"},
            new Person{Id=3, Name="Pontus", Email="Pontus@warmkitten.com"},
        };
        static int lastId = 3;

        public static void AddPerson(Person person)
        {
            lastId++;
            person.Id = lastId;
            people.Add(person);
        }

        public static Person[] GetAllPeople()
        {
            return people.ToArray();
        }

        public static Person GetAPerson(int id)
        {
            return people[id-1];
        }


    }
}
