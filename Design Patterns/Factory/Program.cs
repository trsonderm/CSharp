using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {

            Factory animalFactory = new Factory();
            Console.Write(animalFactory.GetAnimal(AnimalType.Water).GetName());

            IAnimal fishAnimal = animalFactory.GetAnimal(AnimalType.Water);
            Console.Write(animalFactory.GetAnimal(AnimalType.Air).GetName());
            Console.ReadKey();

        }
    }
    public interface IAnimal
    {
        string GetName();
    }
    public class Aquatic : IAnimal
    {
        public string GetName()
        {
            return "Fish";
        }
    }

    public class Avian : IAnimal
    {
        public string GetName()
        {
            return "Bird";
        }
    }


    public enum AnimalType
    {
        Water,
        Air
    }

    public class Factory
    {
        public IAnimal GetAnimal(AnimalType type)
        {
            IAnimal animal = null;

            switch (type)
            {
                case AnimalType.Air:
                    animal = new Avian();
                    break;
                case AnimalType.Water:
                    animal = new Aquatic();
                    break;
                default:
                    break;
            }
            return animal;
        }
    }
}
