using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace UnityTest
{
    /// <summary>  
    /// Unity IOC单例模式   
    /// </summary>  
    public class UnitySingleton
    {
        // 定义一个标识确保线程同步
        private static readonly object locker = new object();

        //单例  
        private static UnitySingleton instance;

        //ioc容器  
        public IUnityContainer container;

        //获取单例  
        public static UnitySingleton getInstance()
        {
            if (instance == null || instance.container == null)
            {
                lock (locker)
                {
                    if (instance == null || instance.container == null)
                    {
                        //获取配置节  
                        UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                        instance = new UnitySingleton()
                        {
                            container = new UnityContainer().LoadConfiguration(section)
                        };
                    }
                }
            }

            return instance;
        }

        //IOC注入实体  
        public static T GetInstanceDAL<T>()
        {
            return getInstance().container.Resolve<T>();
        }

        public static IEnumerable<T> ResolveAll<T>()
        {
            return getInstance().container.ResolveAll<T>();
        }
    }
}
