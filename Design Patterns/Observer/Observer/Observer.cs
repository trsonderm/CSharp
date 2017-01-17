using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class Observer : IObserver
    {
        public string ObserverName { get; private set; }
        public Observer(string name)
        {
            this.ObserverName = name;
        }
        public void Update()
        {
            Console.WriteLine($"{this.ObserverName} A new product has arrived");
        }
    }

    interface IObserver
    {
        void Update();
    }
}
