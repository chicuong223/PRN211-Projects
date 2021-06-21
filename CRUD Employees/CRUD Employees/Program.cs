using dao;
using dto;
using System;
using System.Collections.Generic;

namespace dao
{
    public class Employee
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public double salary { get; set; }
        public Employee()
        {
            id = "";
            name = "";
            address = "";
            salary = 0;
        }

        public Employee(string id, string name, string address, double salary)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.salary = salary;
        }

        public override string ToString()
        {
            return id + ";" + name + ";" + address + ";" + salary;
        }
    }
}

namespace dto
{
    public class EmployeeDAO
    {
        private List<Employee> lst;

        public List<Employee> Lst { get => lst; set => lst = value; }

        public EmployeeDAO()
        {
            Lst = new List<Employee>();
        }

        public Employee SearchEmpById(string id)
        {
            foreach(Employee e in Lst)
            {
                if (e.id.Equals(id)) return e;
            }
            return null;
        }

        public Employee createEmployee()
        {
            Console.Write("ID: ");
            string id = Console.ReadLine();
            if(SearchEmpById(id) != null)
            {
                return null;
            }
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Salary: ");
            double salary = Double.Parse(Console.ReadLine());
            Employee e = new Employee(id, name, address, salary);
            return e;
        }

        public void addEmp(Employee e)
        {
            Lst.Add(e);
        }

        public void printList()
        {
            foreach(Employee e in Lst)
            {
                Console.WriteLine(e);
            }
        }
    }
}

namespace CRUD_Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            string count = "";
            EmployeeDAO dao = new EmployeeDAO();
            do
            {
                Console.WriteLine("Press 1 to continue");
                count = Console.ReadLine();
                Employee e = dao.createEmployee();
                if (e != null)
                {
                    dao.addEmp(e);
                }
                else
                {
                    Console.WriteLine("This ID exists");
                }
                dao.printList();
            } while (count.Equals("1"));
            
        }
    }
}
