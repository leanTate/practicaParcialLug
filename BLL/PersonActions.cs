using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using BE.DTO;
using DAL;
using System.Threading.Tasks;
using DAL.DAO;
using System.Data;

namespace BLL
{
    public class PersonActions
    {
        public bool AddPerson(Person req) { 
            try {
                PersonDao action = new PersonDao();
                action.Insert(req);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool UpdatePerson(UpdateDto req)
        {
            try
            {
                PersonDao action = new PersonDao();
                action.Update(req);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeletePerson(int dni) {
            try
            {
                PersonDao action = new PersonDao();
                action.Delete(dni);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public List<Person> GetPersons()
        {
            try
            {
                DataSet mydataset;
                PersonDao action = new PersonDao();
                mydataset=action.Read();
                if (mydataset.Tables[0].Rows.Count > 0)
                {
                    List<Person> persons = new List<Person>();
                    foreach (DataRow row in mydataset.Tables[0].Rows)
                    {
                        Person person = new Person(row["nombre"].ToString(), row["apellido"].ToString(), int.Parse(row["dni"].ToString()), int.Parse(row["telefono"].ToString()));
                        persons.Add(person);
                    }
                    return persons;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
