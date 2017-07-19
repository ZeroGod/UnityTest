using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var dao = UnitySingleton.GetInstanceDAL<DIExampleClass>();
            var test = UnitySingleton.GetInstanceDAL<IExampleClass>();
            dao.DoWork();
            test.DoHelloWord();
            Console.ReadLine();
        }
    }
}
