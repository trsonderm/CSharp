using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {

            //get new instance
            Singleton test = Singleton.Instance;
            Console.Write(test.sampleText);
            Console.ReadKey();
        }
    }

    public sealed class Singleton
    {
        private static volatile Singleton _instance = null;
        private static object syncRoot = new Object();

        private string _sampleText = "bird";
        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if(_instance==null)
                            _instance = new Singleton();
                        
                    }
                }
                return _instance;
                
                
            }
        }

        public string sampleText
        {
            get
            {
                return _sampleText;
            }
        }
    }
}
