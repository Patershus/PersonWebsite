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
        static string path = @"C:\projects\PersonWebsite\PersonWebsite\PersonWebsite\JsonFile\people.json";
        static List<Person> people = new List<Person>
        {
            new Person{Id=1, Name="Petter", Email="Petter@hotmail.com"},
            new Person{Id=2, Name="Håkan", Email="Hakan@academicwork.com"},
            new Person{Id=3, Name="Pontus", Email="Pontus@warmkitten.com"},
        };
        static int lastId = 3;

        public static void AddPerson(PeopleCreateVM person)
        {
            LoadJson();
            lastId++;
            Person tempPerson = new Person();
            tempPerson.Name = person.Name;
            tempPerson.Email = person.Email;
            tempPerson.Id = lastId;
            people.Add(tempPerson);
            JsonToFile();

        }

        private static void LoadJson()
        {
            string jsonString = File.ReadAllText(path);
            var jsonList = JsonConvert.DeserializeObject<List<Person>>(jsonString);
            people = jsonList;
            lastId =people
                .Max(p => p.Id);
        }

        public static PeopleIndexVM[] GetAllPeople()
        {
            LoadJson();
            return people
                .Select(c => new PeopleIndexVM
                {
                    Name = c.Name,
                    Email = c.Email,
                    Id = c.Id,
                    ShowAsHighlighted = c.Email.EndsWith(".com"),
                })
                .ToArray();
        }

        public static Person GetAPerson(int id)
        {
            LoadJson();
            return people[id-1];
        }

        public static void EditPerson(int id, PeopleEditVM person)
        {
            LoadJson();
            var personToChange =people.SingleOrDefault(p => p.Id == id);

            personToChange.Name = person.Name;
            personToChange.Email = person.Email;
            JsonToFile();

        }

        public static void JsonToFile()
        {
            //StreamWriter file = File.CreateText(@"C:\projects\PersonWebsite\PersonWebsite\PersonWebsite\wwwroot\people.json");
                
            //JsonSerializer serializer = new JsonSerializer();
            //serializer.Serialize(file,people);

            File.WriteAllText(path, JsonConvert.SerializeObject(people, Formatting.Indented));

        }

        //public static List<Person> GetListFromJson()
        //{
        //    string textFromJson = File.ReadAllText(path);
        //    var peopleList = JsonConvert.DeserializeObject<List<Person>>(textFromJson);

            
        //    return peopleList;

        //}
    }
}
