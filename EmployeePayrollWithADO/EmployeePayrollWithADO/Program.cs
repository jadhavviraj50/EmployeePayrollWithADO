using System;

namespace EmployeePayrollWithADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll!");

            EmployeeRepo repo = new EmployeeRepo();
            EmployeeModel employee = new EmployeeModel();

            while (true)
            {
                Console.WriteLine("Choose the option :\n1)Create and retrieve values from Database\n2)Add data in database\n3)Salary Update\n4)Start date range\n5)Aggregate Operations");
                int option = Convert.ToInt16(Console.ReadLine());
                switch (option)
                {
                    case 1:

                        repo.GetAllEmployee();
                        break;
                    case 2:
                    /*
                    employee.name = "Bruce Wayne";
                    employee.salary = 25000;
                    employee.startdate = "05-05-2019";
                    employee.gender = 'M';
                    employee.phone = "0123586489";
                    employee.address = "3-161-21";
                    employee.department = "Hr";
                    employee.basicpay = 22000;
                    employee.deduction = 1500;
                    employee.taxablepay = 200;
                    employee.incometax = 5000;
                    employee.netpay = 25000;

                    repo.AddEmployee(employee);
                    break;*/

                    case 3:
                        repo.updateSalary();
                        int salary = repo.updateSalary();
                        Console.WriteLine(salary);
                        break;

                    case 4:
                        repo.GetEmployeedetails_with_StartDate();
                        break;

                    case 5:

                        int count = repo.CountOfRows();
                        Console.WriteLine("Count of Records :" + count);

                        int AverageSalary = repo.AverageOfSalary();
                        Console.WriteLine("Average salary is :" + AverageSalary);

                        int SumOfTheSalary = repo.SumOfSalary();
                        Console.WriteLine("Sum of salaries is :" + SumOfTheSalary);

                        int minimum = repo.MinimumOfSalary();
                        Console.WriteLine("Minimum of salaries is :" + minimum);

                        int maximum = repo.MaximumOfSalary();
                        Console.WriteLine("Maximum of salaries is :" + maximum);
                        break;


                    default:
                        Console.WriteLine("Please choose the correct option");
                        break;
                }
            }

        }
    }
}