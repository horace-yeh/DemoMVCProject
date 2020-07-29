using Demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test();
        }




        public static void Test()
        {
            var repo = new UserRepository();
            var temp = repo.GetAll();
            var tt = "";
        }
    }
}
