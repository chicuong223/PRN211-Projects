using System;

namespace abcde.fghjk.lmnop
{
    public class MyClass
    {
        public static void Print() => Console.Write("Hello World");
    }
}

namespace NamespaceDemo
{
    //change refName of namespace
    //using ABC = abcde.fghjk.lmnop

    //import class from namespace, set name = ABC
    //using ABC = abcde.fghjk.lmnop.MyClass;

    //using static -> dont't need to mention namespace and class
    using static abcde.fghjk.lmnop.MyClass;

    class Program
    {
        static void Main(string[] args)
        {
            ////ABC.Print();
            ////Print();

            ////commandline argument
            //String msg = "Welcome to C# .Net Programming";
            //Console.WriteLine("{0}", msg);
            ////process any incoming args
            //for (int i = 0; i < args.Length; i++)
            //{
            //    Console.WriteLine($"Arg: {args[i]}");
            //}
            //Console.ReadLine();

            ////var keyword
            //var myInt = 1;
            //var myBool = true;
            //var myString = "Hello World !";
            //var myDouble = 0.5;
            //Console.WriteLine("myInt is a: {0}", myInt.GetType().Name);
            //Console.WriteLine("myBool is a: {0}", myBool.GetType().Name);
            //Console.WriteLine("myString is a: {0}", myString.GetType().Name);
            //Console.WriteLine("myDouble is a: {0}", myDouble.GetType().Name);
            //Console.ReadLine();

            ////dynamic type
            //dynamic a;
            //a = 1;
            //Console.WriteLine("a is: {0}", a.GetType().Name);
            //a = true;
            //Console.WriteLine("a is: {0}", a.GetType().Name);
            //a = "Hello World";
            //Console.WriteLine("a is: {0}", a.GetType().Name);
            //Console.ReadLine();

            ////string interpolation
            //String name = "Cuong";
            //double no = 12.123;
            ////old way, use curly braces
            //String str1 = string.Format("Name{0,6}, Salary{1,7:N2}", name, no);
            //Console.WriteLine("str1: {0} ", str1);
            ////using string interpolation
            //String str2 = $"Name{name,7}, Salary{no,8:N2}";
            //Console.WriteLine("str2: {0} ", str2);
            //Console.ReadLine();

            ////DateTime type
            //DateTime date;
            //Console.Write("Enter a date: ");
            //date = DateTime.Parse(Console.ReadLine());
            //Console.WriteLine($"Date:{date:dd/MMM/yyyy}");
            //Console.ReadLine();

            ////Numeric Literal Syntax
            //Console.WriteLine("***** Digit Separators *****");
            //Console.WriteLine("Integer: 123_456");
            //Console.WriteLine(123_456);
            //Console.WriteLine("Double: 123_456.12");
            //Console.WriteLine(123_456.12);
            //Console.WriteLine("Hex: 0x_00_00_FF");
            //Console.WriteLine(0x_00_00_FF);
            //Console.WriteLine("***** Binary Literals *****");
            //Console.WriteLine("Sixteen: {0}", 0b_0001_0000);
            //Console.WriteLine("Thirty Two: {0}", 0b_0010_0000);
            //Console.WriteLine("Sixty Four {0}", 0b_0100_0000);
            //Console.ReadLine();

            ////Passing parameters with ref, out and params
            ////ref must be initialized
            ////out must have a value to return
            ////params always stand last in the parameters
            ////if we don't use params, we have to pass an array to the method every time we call it
            //int x = 1, y = 2, z;
            //MyMethod(x, ref y, out z);
            //Console.WriteLine($"x:{x}, y:{y}, z:{z}");
            //int s;
            //SumArray(out s, 1, 2, 3, 4);
            //Console.WriteLine($"s={s}");
            //int[] arr = { 5, 6, 7, 8, 9 };
            //SumArray(out s, arr);
            //Console.WriteLine($"s={s}");
            //SumArray(out s);
            //Console.WriteLine($"s={s}");
            //Console.ReadLine();

            ////ref local, ref returns
            ////ref local
            //Console.WriteLine($"Original Array: {string.Join(" ", numbers)}");
            //ref int value = ref FindNumber(3);
            //value *= 2;
            //Console.WriteLine($"New Array: {string.Join(" ", numbers)}");
            //Console.ReadLine();

            ////local function: a function inside a function
            ////in this case, this function is in the main method
            ////static local function can't reference any variable outside of it
            //void CalculateCircle(double a)
            //{
            //    const double PI = 3.14;
            //    double ar;
            //    double cr = 0;
            //    static double Area(double ra)
            //    {
            //        //ar = ra * ra * PI; => Exception
            //        return ra * ra * PI;
            //    }

            //    void Circumference(double a)
            //    {
            //        cr = a * 2 * PI; // No exception
            //    }
            //    ar = Area(a);
            //    Console.WriteLine("Area: " + ar);
            //    Circumference(a);
            //    Console.WriteLine("Circummference: " + cr);
            //}
            //CalculateCircle(3);
            //Console.ReadLine();

            //tuples: like Python
            (string str, int no) values = ("Hello World !", 2020);
            Console.WriteLine($"String is {values.str}");
            Console.WriteLine($"Number if {values.no}");
            Console.ReadLine();

            int[] noArr = { 2, 6, 7, 4, 2, 6, 4, 8, 9, 3, 5 };
            var (sum, count) = TupleDemo(noArr);
            Console.WriteLine($"Sum={sum}, Count={count}");
            Console.ReadLine();

        }
        static int[] numbers = { 1, 2, 3, 4, 5 };

        static void MyMethod(int a, ref int b, out int c)
        {
            a = 1;
            b = 4;
            c = 5;
        }

        static void SumArray(out int s, params int[] list)
        {
            int i;
            s = 0;
            for(i = 0; i<list.Length; i++)
            {
                s += list[i];
            }
        }

        //ref local: return the address of the element INSIDE an array
        //we can modify elements inside the array
        static ref int FindNumber(int target)
        {
            bool flag = true;
            ref int value = ref numbers[0];
            for(int ctr = 0; ctr < numbers.Length; ctr++)
            {
                if(numbers[ctr] == target)
                {
                    value = ref numbers[ctr];
                    flag = false;
                }
            }
            return ref value;
        }

        //Tuple demo
        //calculate number of even numbers in an array and sum of them
        static (int sum, int count) TupleDemo(int[] values)
        {
            var r = (sum: 0, count: 0);
            for(int i=0; i<values.Length; i++)
            {
                if (IsEvenNumber(values[i]))
                {
                    r.sum += values[i];
                    r.count++;
                }
            }
            return r;

            bool IsEvenNumber(int n)
            {
                return n % 2 == 0;
            }
        }
    }
}
