using System;

namespace DelegateExercise
{
    public delegate int Dele1(int a);
    public delegate float Dele2(int a);
    public delegate int Dele3();
    public delegate Tuple<int, float> Result(int a, ref int result, ref float root);
    class Program
    {
        static int NhapSo()
        {
            Console.Write("Nhap so nguyen tu 1 toi 100: ");
            int n = int.Parse(Console.ReadLine());
            return n;

        }

        static int BinhPhuong(int a)
        {
            return a * a;
        }

        static float CanBac2(int a) => (float)Math.Sqrt(a);
        static void Main(string[] args)
        {
            int square = 0;
            float sqrt = 0;
            int n = 0;
            Dele3 dele3 = new Dele3(NhapSo);
            Dele1 dele1 = BinhPhuong;
            Dele2 dele2 = CanBac2;
            
            Result print = delegate (int n, ref int a, ref float b)
            {
                n = dele3();
                a = dele1.Invoke(n);
                b = dele2.Invoke(n);
                Tuple<int, float> result = new Tuple<int, float>(a,b);
                return result;
            };
            Tuple<int, float> result = print(n, ref square, ref sqrt);
            Console.WriteLine($"Square = {result.Item1}; Sqrt = {result.Item2}");
        }
    }
}
