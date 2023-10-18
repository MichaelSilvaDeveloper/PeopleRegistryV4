using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Person
    {
        public Person(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}