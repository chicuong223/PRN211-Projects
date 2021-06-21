using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    class MyCollection<T>:IEnumerable where T:class, new()
    {
        private List<T> myList = new List<T>();
        public void AddItem(params T[] item) => myList.AddRange(item);
        IEnumerator IEnumerable.GetEnumerator() => myList.GetEnumerator();
    }

    class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person() { }
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, Age: {Age}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person {FirstName="Vito", LastName="Scaletta", Age=20},
                new Person {FirstName="Joe", LastName="Barbaro", Age=21},
                new Person {FirstName="Henry", LastName="Tomasino", Age=30},
                new Person {FirstName="Tommy", LastName="Vercetti", Age=32}
            };
            Console.WriteLine("Items in List: {0}", people.Count);
            foreach(Person p in people)
            {
                Console.WriteLine(p);
            }
            Console.ReadLine();

            //SortedSet
            SortedSet<int> mySet = new SortedSet<int>() { 8, 7, 9, 1, 3 };
            mySet.Add(5);
            mySet.Add(4);
            mySet.Add(6);
            mySet.Add(2);
            Console.WriteLine("Elements of mySet:\n");
            foreach(var val in mySet)
            {
                Console.WriteLine($"{val, 3}");
            }
            Console.ReadLine();

            //IEnumerable<T>
            var p1 = new Person { FirstName = "Yukimura", LastName = "Sanada", Age = 25 };
            var p2 = new Person { FirstName = "Nobuyuki", LastName = "Sanada", Age = 30 };
            var p3 = new Person { FirstName = "Nobunaga", LastName = "Oda", Age = 42 };
            MyCollection<Person> collection = new MyCollection<Person>();
            collection.AddItem(p1, p2, p3);
            foreach(Person p in collection)
            {
                Console.WriteLine(p);
            }
        }
    }
}
