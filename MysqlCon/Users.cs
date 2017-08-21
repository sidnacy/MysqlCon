using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace MysqlCon
{
    class Users:DB
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Users> SelectAllUsers()
        {
            var list_of_users = new List<Users>();
            this._sql_query = "SELECT * FROM sampleData";
            if (ConnectionIsOpen() == true)
            {

                using (_command = new MySqlCommand(this._sql_query, this._database_connection))
                {
                    using (_data_reader = _command.ExecuteReader())
                    {
                        while (_data_reader.Read())
                        {
                            Users user = new Users();
                            user.ID = int.Parse(_data_reader["ID"].ToString());
                            user.Name = _data_reader["sample"].ToString();
                            list_of_users.Add(user);
                        }
                    }
                }
            }
            return list_of_users;
        }
        public List<Users> SelectUserPerId() {
            var selected_user = new List<Users>();
            _sql_query = "SELECT * from sampleData WHERE id = @id";
            using (_command = new MySqlCommand(this._sql_query, this._database_connection)) {
                _command.Parameters.AddWithValue("@id",this.ID);
                _command.Prepare();
                using (_data_reader = _command.ExecuteReader()) {
                    while (_data_reader.Read()) ;
                    Users user = new Users();
                    user.ID = int.Parse(_data_reader["ID"].ToString());
                    user.Name = _data_reader["sample"].ToString();
                    selected_user.Add(user);
                }
            }
            return selected_user;
        }

    }
}
