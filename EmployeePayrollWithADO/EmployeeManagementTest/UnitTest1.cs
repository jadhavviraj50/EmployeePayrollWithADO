using EmployeePayrollWithADO;
using EmployeePayrollWithADO.Model.SalaryModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayrollWithADO;
using System.Collections.Generic;
using System;

namespace EmployeePayrollTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenSalaryDetails_AbleToUpdateSalaryDetails()
        {
            //Arrange
            Salary salary = new Salary();
            SalaryUpdateModel updateModel = new SalaryUpdateModel()
            {
                SalaryId = 2,
                Month = "JAN",
                EmployeeSalary = 0,
                EmployeeId = 20
            };

            //Act
            int EmpSalary = salary.UpdateEmployeeSalary(updateModel);

            //Assert
            Assert.AreEqual(updateModel.EmployeeSalary, EmpSalary);
        }

        [TestMethod]
        public void Given10Employee_WhenAddedToList_ShouldMaatchEmployeeEntries()
        {
            List<EmployeeModel> employeeDetails = new List<EmployeeModel>();
            employeeDetails.Add(new EmployeeModel(id: 1, name: "Viraj", salary: 7000, gender: 'M', phone: "9999999999", address: "Panvel", department: "Engineer", basicpay: 10000, deduction: 200, taxablepay: 2000, netpay: 6800, incometax: 1000));
            employeeDetails.Add(new EmployeeModel(id: 2, name: "Vaibhav", salary: 7000, gender: 'M', phone: "9999999999", address: "Calgary", department: "Engineer", basicpay: 10000, deduction: 200, taxablepay: 2000, netpay: 6800, incometax: 1000));
            employeeDetails.Add(new EmployeeModel(id: 3, name: "Varad", salary: 7000, gender: 'M', phone: "9999999999", address: "Alibag", department: "Engineer", basicpay: 10000, deduction: 200, taxablepay: 2000, netpay: 6800, incometax: 1000));
            employeeDetails.Add(new EmployeeModel(id: 4, name: "Mayuri", salary: 7000, gender: 'F', phone: "9999999999", address: "Sagaon", department: "Engineer", basicpay: 10000, deduction: 200, taxablepay: 2000, netpay: 6800, incometax: 1000));
            employeeDetails.Add(new EmployeeModel(id: 5, name: "Mitali", salary: 7000, gender: 'F', phone: "9999999999", address: "Karjat", department: "Engineer", basicpay: 10000, deduction: 200, taxablepay: 2000, netpay: 6800, incometax: 1000));
            employeeDetails.Add(new EmployeeModel(id: 6, name: "Ram", salary: 7000, gender: 'M', phone: "9999999999", address: "Neral", department: "Engineer", basicpay: 10000, deduction: 200, taxablepay: 2000, netpay: 6800, incometax: 1000));
            employeeDetails.Add(new EmployeeModel(id: 7, name: "Shyam", salary: 7000, gender: 'M', phone: "9999999999", address: "Uran", department: "Engineer", basicpay: 10000, deduction: 200, taxablepay: 2000, netpay: 6800, incometax: 1000));
            employeeDetails.Add(new EmployeeModel(id: 8, name: "Raju", salary: 7000, gender: 'M', phone: "9999999999", address: "Shelu", department: "Engineer", basicpay: 10000, deduction: 200, taxablepay: 2000, netpay: 6800, incometax: 1000));
            employeeDetails.Add(new EmployeeModel(id: 9, name: "Babu", salary: 7000, gender: 'M', phone: "9999999999", address: "Pali", department: "Engineer", basicpay: 10000, deduction: 200, taxablepay: 2000, netpay: 6800, incometax: 1000));
            employeeDetails.Add(new EmployeeModel(id: 10, name: "Pratik", salary: 7000, gender: 'M', phone: "9999999999", address: "Mahad", department: "Engineer", basicpay: 10000, deduction: 200, taxablepay: 2000, netpay: 6800, incometax: 1000));

            EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
            DateTime startDateTime = DateTime.Now;
            employeePayrollOperations.addEmployeeToPayroll(employeeDetails);
            DateTime stopDateTime = DateTime.Now;
            Console.WriteLine("Duration without thread: " + (stopDateTime - startDateTime));

            DateTime startDateTimeThread = DateTime.Now;
            employeePayrollOperations.addEmployeeToPayrollWithThread(employeeDetails);
            DateTime stopDateTimeThread = DateTime.Now;
            Console.WriteLine("Duration with Thread: " + (stopDateTimeThread - startDateTimeThread));

        }
    }

    
}

