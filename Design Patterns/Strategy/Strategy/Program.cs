using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            SortList animals = new SortList();
            animals.Add("Penguin");
            animals.Add("Dog");
            animals.Add("Llama");
            animals.Add("Bird");

            animals.SetSortStrategy(new MergeSort());
            animals.Sort();
            Console.WriteLine("-----------------");
            animals.SetSortStrategy(new QuickSort());
            animals.Sort();

            Console.ReadKey();

        }

       
    }
    abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }

    class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort();
            //implmentation here for Merge Sort
            Console.WriteLine("*****Merge Sort");

        }
    }

    class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort();
            Console.WriteLine("*****Quick Sort");
            
        }
    }

    class SortList
    {
        private List<string> _list = new List<string>();
        private SortStrategy _sortstrategy;

        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this._sortstrategy = sortstrategy;
        }

        public void Add(string name)
        {
            _list.Add(name);
        }

        public void Sort()
        {
            _sortstrategy.Sort(_list);

            foreach (string name in _list)
            {
                Console.WriteLine(name);
            }
        }
    }
}
