using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject();
            Observer observer1 = new Observer("Observer 1");
            subject.Subscribe(observer1);
            subject.Subscribe(new Observer("Observer 2"));
            subject.Inventory++;
            subject.Unsubscribe(observer1);
            subject.Subscribe(new Observer("Observer 3"));
            subject.Inventory++;
            Console.ReadKey();
        }
    }
   
}
