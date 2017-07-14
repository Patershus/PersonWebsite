using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonWebsite.Models
{
    static public class DataManager
    {
        static string path = @"C:\projects\PersonWebsite\PersonWebsite\PersonWebsite\wwwroot\people.json";
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
            JsonToFile();
        }

        public static Person[] GetAllPeople()
        {
            return people.ToArray();
        }

        public static Person GetAPerson(int id)
        {
            return people[id-1];
        }

        public static void EditPerson(Person person)
        {
            var personToChange =people.SingleOrDefault(p => p.Id == person.Id);

            personToChange.Name = person.Name;
            personToChange.Email = person.Email;

        }

        public static void JsonToFile()
        {
            //StreamWriter file = File.CreateText(@"C:\projects\PersonWebsite\PersonWebsite\PersonWebsite\wwwroot\people.json");
                
            //JsonSerializer serializer = new JsonSerializer();
            //serializer.Serialize(file,people);

            File.WriteAllText(path, JsonConvert.SerializeObject(people, Formatting.Indented));

        }

        public static List<Person> GetListFromJson()
        {
            string textFromJson = File.ReadAllText(path);
            var peopleList = JsonConvert.DeserializeObject<List<Person>>(textFromJson);

            
            return peopleList;

        }


    }
}
