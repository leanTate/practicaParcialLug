using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Person
    {
        public Person(string name, string lastName, int dni, int phone)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Dni = dni;
            this.Phone = phone;
        }
        public Person(int id,string name, string lastName, int dni, int phone) {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
            this.Dni = dni;
            this.Phone = phone;
        }

        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public int Dni { get; set; }
        public int Phone { get; set; }
    }
}
