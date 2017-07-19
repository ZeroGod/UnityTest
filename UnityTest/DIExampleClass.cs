using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace UnityTest
{
    public class DIExampleClass
    {
        //属性注入  
        [Dependency]
        public IExampleClass example { get; set; }

        private IExampleClass testInject;

        public void DoWork()
        {
            example.DoHelloWord();
            testInject.DoHelloWord();
        }

        //方法注入  
        [InjectionMethod]
        public void Initialize(IExampleClass instance)
        {
            testInject = instance;
        }
    }
}
