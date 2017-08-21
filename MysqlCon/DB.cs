using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
namespace MysqlCon
{
    class DB
    {
        protected MySqlConnection _database_connection;
        protected MySqlCommand _command;
        protected MySqlDataReader _data_reader;
        protected string _connection_string;
        protected string _sql_query;

        public DB() {
            _connection_string = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (_database_connection = new MySqlConnection()) {
                try {
                    _database_connection.ConnectionString = _connection_string;
                    _database_connection.Open();
                   
                }
                catch (MySqlException ex) {
                    throw new ArgumentException(ex.Message);
                }
                
            }
        }
        protected bool ConnectionIsOpen() {
            try {
                _database_connection.Open();
                return true;
            }
            catch (MySqlException ex) {
                //throw new ArgumentException(ex.Message);
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        
    }
}
