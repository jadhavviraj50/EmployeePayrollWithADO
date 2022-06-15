using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollWithADO
{
    public class EmployeeModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int salary { get; set; }
        public DateTime startdate { get; set; }
        public char gender { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string department { get; set; }
        public int basicpay { get; set; }
        public int deduction { get; set; }
        public int taxablepay { get; set; }
        public int netpay { get; set; }
        public int incometax { get; set; }


        public EmployeeModel(int id, string name, int salary, char gender, string phone, string address, string department,
            int basicpay, int deduction, int taxablepay, int netpay, int incometax)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
            this.gender = gender;
            this.phone = phone;
            this.address = address;
            this.department = department;
            this.basicpay = basicpay;
            this.deduction = deduction;
            this.taxablepay = taxablepay;
            this.netpay = netpay;
            this.incometax = incometax;
        }

    }
}
