using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            var sum = numbers.Sum();
            var avg = numbers.Average();
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Average: {avg}");

            var asc = numbers.OrderBy(num => num);
            var desc = numbers.OrderByDescending(num => num);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Least to greatest:");
            foreach(var num in asc)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Greatest to least:");
            foreach(var num in desc)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Numbers above six:");
            var aboveSix = numbers.Where(num => num > 6);
            foreach(var num in aboveSix)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("First 4 in ascending:");
            foreach (var num in asc.Take(4))
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Replacing index 4 with my age, then descending:");
            numbers[4] = 30;
            foreach(var num in desc)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("----------------------------------------");

            //TODO: Print the Sum of numbers

            //TODO: Print the Average of numbers

            //TODO: Order numbers in ascending order and print to the console

            //TODO: Order numbers in descending order and print to the console

            //TODO: Print to the console only the numbers greater than 6

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            var filter = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S'));
            filter.OrderBy(person => person.FirstName);
            Console.WriteLine("First names that start with C or S:");
            
            foreach (var employee in filter)
            {
                Console.WriteLine(employee.FullName);
            }
            Console.WriteLine("----------------------------------------------");

            var ageAndName = employees.Where(person => person.Age > 26)
                .OrderBy(person => person.Age)
                .ThenBy(person => person.FirstName);
            Console.WriteLine("Ordered by age over 26, then by first name:");
            
            foreach (var person in ageAndName)
            {
                Console.WriteLine($"{person.Age} {person.FullName}");
            }
            Console.WriteLine("--------------------------------------------------");

            var experience = employees.Where(person => person.YearsOfExperience <= 10)
                .Where(person => person.Age > 35);

            var sumExperience = experience.Sum(person => person.YearsOfExperience);
            var avgExperience = experience.Average(person => person.YearsOfExperience);

            Console.WriteLine("Years of experience sum:");
            Console.WriteLine($"{sumExperience}");
            Console.WriteLine("Years of experience average:");
            Console.WriteLine($"{avgExperience}");
            Console.WriteLine("---------------------------------------------------");

            Console.WriteLine("List of emplyees after adding new one:");
            employees = employees.Append(new Employee("Eltaco", "Burrito", 207, 50 )).ToList();
            foreach (var person in employees)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName} {person.Age} {person.YearsOfExperience}");
            }


            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            //TODO: Add an employee to the end of the list without using employees.Add()


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
