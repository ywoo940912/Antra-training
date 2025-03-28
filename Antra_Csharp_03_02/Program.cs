using System;

namespace OOPExample
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }
        
        public Person(string name, DateTime birthDate, decimal salary)
        {
            Name = name;
            BirthDate = birthDate;
            Salary = salary;
        }
        
        public virtual decimal CalculateSalary()
        {
            return Salary;
        }
        
        public int CalculateAge()
        {
            int age = DateTime.Now.Year - BirthDate.Year;
            if (DateTime.Now.DayOfYear < BirthDate.DayOfYear)
                age--;

            return age;
        }
    }

    // Instructor class that inherits from Person
    public class Instructor : Person
    {
        public string Department { get; set; }
        public DateTime JoinDate { get; set; }

        // Constructor
        public Instructor(string name, DateTime birthDate, decimal salary, string department, DateTime joinDate)
            : base(name, birthDate, salary)
        {
            Department = department;
            JoinDate = joinDate;
        }

        // Override CalculateSalary to include bonus based on years of experience
        public override decimal CalculateSalary()
        {
            // Calculate the years of experience based on JoinDate
            int yearsOfExperience = DateTime.Now.Year - JoinDate.Year;

            // Add bonus based on years of experience (example: $1000 per year of experience)
            decimal bonus = yearsOfExperience * 1000;

            // Add the bonus to the base salary
            return Salary + bonus;
        }

        // Method to calculate years of experience
        public int CalculateExperience()
        {
            return DateTime.Now.Year - JoinDate.Year;
        }
    }

    // Main method for testing
    class Program
    {
        static void Main(string[] args)
        {
            // Creating instances of Person and Instructor
            Person person = new Person("Yeon Woo", new DateTime(1990, 5, 15), 50000);
            Instructor instructor = new Instructor("Rachel Paik", new DateTime(1985, 3, 10), 60000, "Computer Science", new DateTime(2010, 8, 1));

            // Displaying information about the Person
            Console.WriteLine($"{person.Name} is {person.CalculateAge()} years old.");
            Console.WriteLine($"{person.Name}'s salary: ${person.CalculateSalary()}");

            // Displaying information about the Instructor
            Console.WriteLine($"{instructor.Name} is {instructor.CalculateAge()} years old.");
            Console.WriteLine($"{instructor.Name}'s department: {instructor.Department}");
            Console.WriteLine($"{instructor.Name}'s years of experience: {instructor.CalculateExperience()} years.");
            Console.WriteLine($"{instructor.Name}'s salary (with bonus): ${instructor.CalculateSalary()}");
        }
    }
}
