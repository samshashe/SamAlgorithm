using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStuffOOP.DesignPatterns
{
    // Define an interface for creating an object, but let subclasses decide which class to instantiate. Factory Method lets a class defer instantiation to subclasses. 
    class FactoryMethodMainApp
    {
        static void Main1()
        {
            Factory factory = new Factory();
            IPeople ruralPeople = factory.GetPeople(PeopleType.RURAL);
            Console.WriteLine(ruralPeople.GetName());

            IPeople urbanPeople = factory.GetPeople(PeopleType.URBAN);
            Console.WriteLine(urbanPeople.GetName());
            Console.ReadKey();
        }

    }

    //IVSR:Factory Pattern
    //Empty vocabulary of Actual object
    public interface IPeople
    {
        string GetName();
    }

    public class Villagers : IPeople
    {
        public string GetName()
        {
            return "Village Guy";
        }
    }

    public class CityPeople : IPeople
    {
        public string GetName()
        {
            return "City Guy";
        }
    }

    public enum PeopleType
    {
        RURAL,
        URBAN
    }

    /// <summary>
    /// Implementation of Factory - Used to create objects
    /// </summary>
    public class Factory
    {
        public IPeople GetPeople(PeopleType type)
        {
            IPeople people = null;
            switch (type)
            {
                case PeopleType.RURAL:
                    people = new Villagers();
                    break;
                case PeopleType.URBAN:
                    people = new CityPeople();
                    break;
                default:
                    break;
            }
            return people;
        }
    }
}
