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
        public DataSet GetPersons()
        {
            try
            {
                DataSet mydataset;
                PersonDao action = new PersonDao();
                mydataset = action.Read();
                return mydataset;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public bool AddPersonD(Person req)
        {
            try
            {
                PersonDao action = new PersonDao();
                action.DisconectedInsert(req);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool UpdatePersonD(UpdateDto req) {
            try
            {
                PersonDao action = new PersonDao();
                action.DisconectedUpdate(req);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeletePersonD(int dni)
        {
            try
            {
                PersonDao action = new PersonDao();
                action.DisconectedDelete(dni);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
