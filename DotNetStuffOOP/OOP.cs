using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStuffOOP
{
    class OOP
    {
        static void Main1(string[] args)
        {
            //A a1 = new A();
            //A a2 = new B();
            //B b = new B();

            //a1.Foo();
            //a1.Bar();

            //a2.Foo();
            //a2.Bar();

            //b.Foo();
            //b.Bar();

            
            //foreach (Action a in actions) a(); // 012
            MySerializer();
            Console.ReadKey();
        }
        public static void MySerializer()
        {
            Person p = new Person { Name = "Stacey", Age = 30 };
            var ds = new DataContractSerializer(typeof(Person));

            using (Stream s = File.Create("person.xml"))
                ds.WriteObject(s, p); // Serialize
            Person p2;
            using (Stream s = File.OpenRead("person.xml"))
                p2 = (Person)ds.ReadObject(s); // Deserialize
            Console.WriteLine(p2.Name + " " + p2.Age); // Stacey 30
        }
    }

    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name;
        [DataMember]
        public int Age;
    }

    class A
    {
        public void Foo()
        {
            Console.WriteLine("A");
        }
        public virtual void Bar()
        {
            Console.WriteLine("A");
        }
    }

    class B:A
    {
        public void Foo()
        {
            Console.WriteLine("B");
        }
        public override void Bar()
        {
            Console.WriteLine("B");
        }
    }
}
