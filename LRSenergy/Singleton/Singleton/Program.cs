using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadSafeSingleton tss1 = ThreadSafeSingleton.GetInstance();
            ThreadSafeSingleton tss2 = ThreadSafeSingleton.GetInstance();
            Debug.Assert(tss1 == tss2);
            //SimpleSingleton simpleSingleton1 = SimpleSingleton.GetInstance();
            //SimpleSingleton simpleSingleton2 = SimpleSingleton.GetInstance();

            //Debug.Assert(simpleSingleton1 == simpleSingleton2);

            //NBFISingleton nbfiSingleton1 = NBFISingleton.GetInstance();
            //NBFISingleton nbfiSingleton2 = NBFISingleton.GetInstance();
            //Debug.Assert(nbfiSingleton1 == nbfiSingleton2);
        }
    }

    public class SimpleSingleton
    {
        static SimpleSingleton instance = new SimpleSingleton();
        private SimpleSingleton()
        {
            
        }

        public static SimpleSingleton GetInstance()
        {
            return instance;
        }
    }

    public class NBFISingleton
    {
        private static NBFISingleton instance;

        static NBFISingleton()
        {
            instance = new NBFISingleton();
        }

        private NBFISingleton()
        {

        }

        public static NBFISingleton GetInstance()
        {
            return instance;
        }
    }

    public class Singleton<T> where T : class
    {
        private static T instance;

        static Singleton()
        {
            instance = (T)Activator.CreateInstance(typeof(T), true);
        }

        public static T GetInstance()
        {
            return instance;
        }
    }

    public class Highlander : Singleton<Highlander>
    {
        private Highlander()
        {
            
        }
    }

    public class ThreadSafeSingleton
    {
        private static ThreadSafeSingleton instance;
        private static object _lock = new object();

        public static ThreadSafeSingleton GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ThreadSafeSingleton();
                    }
                }
            }
            return instance;
        }
    }
}
