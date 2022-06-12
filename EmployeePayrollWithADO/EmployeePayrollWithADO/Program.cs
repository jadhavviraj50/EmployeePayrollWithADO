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
            //repo.GetAllEmployee();

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

        }
    }
}