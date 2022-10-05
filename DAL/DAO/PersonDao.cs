using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BE;
using System.Threading.Tasks;
using System.Diagnostics;
using BE.DTO;

namespace DAL.DAO
{
    public class PersonDao
    {
        public bool Insert(Person req)
        {
            ConnectionDB.Instance.Open();
            SqlTransaction transact = ConnectionDB.Instance.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"insert into personas (nombre,apellido,dni,telefono) values ('{req.Name}','{req.LastName}',{req.Dni},{req.Phone})";
                command.Connection = ConnectionDB.Instance;
                command.Transaction = transact;
                command.ExecuteNonQuery();
                transact.Commit();
                ConnectionDB.Close();
                return true;
            }
            catch (Exception ex)
            {
                ConnectionDB.Instance.Close();
                transact.Rollback();
                Console.WriteLine(ex.Message.ToString());
                return false;
            }
        }
        public bool Update(UpdateDto req) {
            ConnectionDB.Instance.Open();
            SqlTransaction transact = ConnectionDB.Instance.BeginTransaction();
            try {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"update personas set {req.Type} = '{req.Newdata}' where dni={req.Dni} ";
                command.Connection = ConnectionDB.Instance;
                command.Transaction = transact;
                command.ExecuteNonQuery();
                transact.Commit();
                ConnectionDB.Close();
                return true;
            }
            catch (Exception ex)
            {
                ConnectionDB.Close();
                transact.Rollback();
                Console.WriteLine(ex.Message.ToString());
                return false;
            }
        }
        public bool Delete(int dni)
        {
            ConnectionDB.Instance.Open();
            SqlTransaction transact = ConnectionDB.Instance.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"delete from personas where dni={dni}";
                command.Connection = ConnectionDB.Instance;
                command.Transaction = transact;
                command.ExecuteNonQuery();
                transact.Commit();
                ConnectionDB.Close();
                return true;
            }
            catch (Exception ex) {
                ConnectionDB.Close();
                transact.Rollback();
                Console.WriteLine(ex.Message.ToString());
                return false;
            }
        }
        public DataSet Read() {
            DataSet myset = new DataSet();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from personas", ConnectionDB.Instance);
                adapter.Fill(myset);
                return myset;
            }
            catch(Exception ex) {
                return myset;
            }
        }
    }
}
