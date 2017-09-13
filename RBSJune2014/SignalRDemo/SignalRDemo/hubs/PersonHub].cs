using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRDemo.hubs
{
    public class PersonHub : Hub
    {
        List<Person> people = new List<Person>
        {
            new Person{Name = "Kevin", Age=52},
            new Person{Name = "Sam", Age=22},
        }; 

        public IEnumerable<Person> GetPeople()
        {
            return people;
        }

        public Person GetPerson(string name)
        {
            return people[0];
        }

        public void UpdatePerson()
        {
            Clients.All.Update(people[1]);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}