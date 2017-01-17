using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class Subject : ISubject
    {
        private List<Observer> observers = new List<Observer>();
        private int _int;
        public int Inventory
        {
            get { return _int; }
            set
            {
                if (value > _int)
                    Notify();
                _int = value;
            }
        }
        public void Subscribe(Observer observer)
        {
            observers.Add(observer);
        }
        public void Unsubscribe(Observer observer)
        {
            observers.Remove(observer);
        }
        public void Notify()
        {
            observers.ForEach(x => x.Update());
        }
    }

    interface ISubject
    {
        void Subscribe(Observer observer);
        void Unsubscribe(Observer observer);
        void Notify();
    }
}
