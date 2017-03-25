using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math_stuff
{
    public class Employee
    {
        public static int NumberOfEmployees;
        private static int counter;
        private string name;

        // A read-write instance property:
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // A read-only static property:        
        public static int Counter
        {
            get { return counter; }
        }

        // A Constructor:        
        public Employee()
        {
            // Calculate the employee's number:
            throw new Exception("oh no");
            counter = ++counter + NumberOfEmployees;
            throw new Exception("oh no2");
        }
    }

    [TestClass]
    class TestEmployee
    {        
        static void Main()
        {
            Employee.NumberOfEmployees = 107;
            Employee e1 = new Employee();
            e1.Name = "Claude Vige";
            Employee e2 = new Employee();            
        }
    }
}

