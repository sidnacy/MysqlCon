using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysqlCon
{
    class Program:DB
    {
        static void Main(string[] args)
        {
            Users user = new Users();
            List<Users> userdata =user.SelectAllUsers();

            foreach (var data in userdata) {
                Console.WriteLine("Id {0}, Name {1}", data.ID, data.Name);
            }
            user.ID = 5;
            userdata = user.SelectUserPerId();
            foreach (var data in userdata)
            {
                Console.WriteLine("Id {0}, Name {1}", data.ID, data.Name);
            }
            Console.ReadKey();
        }
    }
}
