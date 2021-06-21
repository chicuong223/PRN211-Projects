using System;

namespace GenericClass
{
    class MyClass<T> //use <> to define parameter type
    {
        private T data;
        public T Value
        {
            get => data;
            set => data = value;
        }

        public override string ToString()
        {

            return $"Value:{data}";
        }
    }

    public class MyClass1
    {
        //Generic method with 2 types T and U
        public void Display<T, U>(T msg, U value)
        {
            Console.WriteLine($"{msg} : {value}");
        }
    }


    //generic interface
    interface IBasic<T> where T : struct
    {
        T Add(T a, T b);
    }

    class FirstClass : IBasic<int>
    {
        public int Add(int a, int b) => a + b;
    }

    class SecondClass : IBasic<double>
    {
        public double Add(double a, double b) => a + b;
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Instance of string type
            MyClass<string> name = new MyClass<string>() { Value = "Jack" };
            Console.WriteLine(name);
            //Instance of float type
            MyClass<float> version = new MyClass<float>() { Value = 5.5f };
            Console.WriteLine(version);
            //instance of dynamic type
            dynamic obj = new { Id = 1, Name = "David " };
            MyClass<dynamic> myClass = new MyClass<dynamic>() { Value = obj };
            Console.WriteLine(myClass);
            Console.ReadLine();

            MyClass1 obj1 = new MyClass1();
            obj1.Display<string, int>("Integer", 2050);
            obj1.Display(155.9, 'A');   //No need to specify parameter type
            obj1.Display<float, double>(358.9F, 255.67);
            Console.ReadLine();

            FirstClass firstClass = new FirstClass();
            dynamic r = firstClass.Add(10, 20);
            Console.WriteLine(r);
            SecondClass secondClass = new SecondClass();
            r = secondClass.Add(10.5, 20.5);
            Console.WriteLine(r);
            Console.ReadLine();
        }
    }
}
