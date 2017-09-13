using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.AspNet.SignalR;

namespace SignalR
{
    public class PersonHub : Hub
    {
        private static List<Person> people = new List<Person>
        {
            new Person{Name = "Kevin", Age=21},
            new Person{ Name="Jan", Age=32}
        };
        public List<Person> GetPeople()
        {
            return people;
        }

        public void ShowPerson()
        {            
            Clients.All.Person(people[0]);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}