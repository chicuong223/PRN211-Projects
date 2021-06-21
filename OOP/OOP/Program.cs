using System;

namespace OOP
{
    class Car
    {
        public string make;
        public string model;

        public Car() { }

        public Car(string make, string model)
        {
            this.make = make;
            this.model = model;
        }

        public void Driving()
        {
            Console.WriteLine("Driving");
        }

        public void Accelerating()
        {
            Console.WriteLine("Accelerating");
        }

        public void Braking()
        {
            Console.WriteLine("Braking");
        }

        static void Main(string[] args)
        {
            Car wwPolo = new Car("2050", "Volkswagen Polo");
            //wwPolo.make = "2050";
            //wwPolo.model = "Volkswagen Polo";
            Console.WriteLine("Make: " + wwPolo.make);
            Console.WriteLine("Model: " + wwPolo.model);
            wwPolo.Accelerating();
            wwPolo.Driving();
            wwPolo.Braking();
            Console.ReadLine();
        }
    }
}
