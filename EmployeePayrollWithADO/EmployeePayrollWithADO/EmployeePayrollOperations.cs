using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollWithADO
{
    public class EmployeePayrollOperations
    {
        List<EmployeeModel> employeePayrollDetailList = new List<EmployeeModel>();

        public void addEmployeeToPayroll(List<EmployeeModel> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {

                Console.WriteLine("Employee being added: " + employeeData.name);
                this.addEmployeePayroll(employeeData);
                Console.WriteLine("Employee Added: " + employeeData.name);
            });

            Console.WriteLine(this.employeePayrollDetailList.ToString());
        }

        public void addEmployeeToPayrollWithThread(List<EmployeeModel> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Employee being added: " + employeeData.name);
                    this.addEmployeePayroll(employeeData);
                    Console.WriteLine("Employee Added: " + employeeData.name);
                });
                thread.Start();
            });
            Console.WriteLine(this.employeePayrollDetailList.Count);
        }


        public void addEmployeePayroll(EmployeeModel emp)
        {
            employeePayrollDetailList.Add(emp);
        }

    }
}
