using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
      
        static void Main(string[] args)
        {

            AnimalAbstractFactory aFactory = new LargeAnimalFactory();
            AnimalClient aClient = new AnimalClient(aFactory);
            Console.WriteLine("***********Large Animals");
            Console.WriteLine(aClient.GetBirdName());
            Console.WriteLine(aClient.GetDogName());
            Console.WriteLine("***********Small Animals");
            AnimalAbstractFactory aFactory2 = new SmallAnimalFactory();


            AnimalClient aClient2 = new AnimalClient(aFactory2);
            Console.WriteLine(aClient2.GetBirdName());
            Console.WriteLine(aClient2.GetDogName());
            Console.ReadKey();

        }
    }

    public interface AnimalAbstractFactory
    {
        Bird GetBird();

        Dog GetDog();

    }

    public class LargeAnimalFactory : AnimalAbstractFactory
    {
        public Bird GetBird()
        {
            return new Eagle();
        }
        public Dog GetDog()
        {
            return new Husky();
        }
    }

    public class SmallAnimalFactory : AnimalAbstractFactory
    {
        public Bird GetBird()
        {
            return new Sparrow();
        }
        public Dog GetDog()
        {
            return new Terrier();
        }
    }

    public interface Dog
    {
        string Name();
    }

    public interface Bird
    {
        string Name();
    }

   

    public class Terrier : Dog {
        public string Name()
        {
            return "Terrier";
        }
    }

    public class Husky : Dog {
        public string Name()
        {
            return "Husky";
        }
    }

 

    public class Sparrow : Bird {
        public string Name()
        {
            return "Sparrow";
        }
    }

    public class Eagle : Bird {
        public string Name()
        {
            return "Eagle";
        }
    }

    public class AnimalClient
    {
        Dog dog;
        Bird bird;

        public AnimalClient(AnimalAbstractFactory factory)
        {
            dog = factory.GetDog();
            bird = factory.GetBird();
        }

        public string GetBirdName()
        {
            return bird.Name();
        }
        public string GetDogName()
        {
            return dog.Name();
        }
    }

   

   
}
