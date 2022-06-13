using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace EmployeePayrollWithADO
{
    class EmployeeRepo
    {
       
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-2DTGFII; Initial Catalog =payroll_service; Integrated Security = True;");
       
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"SELECT id,name,salary,startdate,gender,phone,address,department,basicpay,deduction,taxablepay,netpay FROM employee_payroll;";

                    //define the SqlCommand Object
                    SqlCommand cmd = new SqlCommand(query, this.connection);

                    this.connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    //check if there are records

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.id = dr.GetInt32(0);
                            employeeModel.name = dr.GetString(1);
                            employeeModel.salary = dr.GetInt32(2);
                            employeeModel.startdate = dr.GetDateTime(3);
                            //employeeModel.gender = Convert.ToChar(dr.GetString(4));
                            //employeeModel.department = dr.GetString(5);
                            //employeeModel.basicpay = dr.GetInt32(6); 
                            //employeeModel.netpay = dr.GetInt32(7);
                            //employeeModel.startdate = dr.GetDateTime(8);


                            //display retrieve record
                            Console.WriteLine("{0},{1},{2},{3}", employeeModel.id, employeeModel.name, employeeModel.salary, employeeModel.startdate);
                            Console.WriteLine("\n");

                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    //close data reader
                    dr.Close();

                    this.connection.Close();
                }
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            
        }

        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", model.name);
                    command.Parameters.AddWithValue("@salary", model.salary);
                    command.Parameters.AddWithValue("@startdate", model.startdate);
                    command.Parameters.AddWithValue("@gender", model.gender);
                    command.Parameters.AddWithValue("@phone", model.phone);
                    command.Parameters.AddWithValue("@address", model.address);
                    command.Parameters.AddWithValue("@department", model.department);
                    command.Parameters.AddWithValue("@basicpay", model.basicpay);
                    command.Parameters.AddWithValue("@deduction", model.deduction);
                    command.Parameters.AddWithValue("@taxablepay", model.taxablepay);
                    command.Parameters.AddWithValue("@incometax", model.incometax);
                    command.Parameters.AddWithValue("@netpay", model.netpay);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public int updateSalary()
        {
            EmployeeModel employee = new EmployeeModel();
            SqlConnection connection = new(@"Data Source=DESKTOP-2DTGFII; Initial Catalog =payroll_service; Integrated Security = True;");
            connection.Open();
            SqlCommand command = new SqlCommand("update employee_payroll set salary=3000000 where name='Terissa'", connection);
            Console.WriteLine("salary updated");

            int result = command.ExecuteNonQuery();
            

            if (result == 1)
            {
                string query = @"Select salary from employee_payroll where name='Viraj';";
                SqlCommand cmd = new SqlCommand(query, connection);
                object res = cmd.ExecuteScalar();
                connection.Close();
                employee.salary = (int)res;
            }
            connection.Close();
            return (employee.salary);

        }

        public void GetEmployeedetails_with_StartDate()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select * from employee_payroll where startdate BETWEEN cast('2019-01-01' as date) and GETDATE();";
                    SqlCommand cmd = new SqlCommand(query, this.connection);

                    this.connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {

                            employeeModel.id = dr.GetInt32(0);
                            employeeModel.name = dr.GetString(1);
                            employeeModel.salary = dr.GetInt32(2);
                            employeeModel.startdate = dr.GetDateTime(3);
                            employeeModel.gender  = dr.GetChar(4);
                            employeeModel.phone = dr.GetString(5);
                            employeeModel.address = dr.GetString(6);
                            employeeModel.department = dr.GetString(7);
                            employeeModel.basicpay = dr.GetInt32(8);
                            employeeModel.deduction = dr.GetInt32(9);
                            employeeModel.taxablepay = dr.GetInt32(10);
                            employeeModel.incometax = dr.GetInt32(11);
                            employeeModel.netpay = dr.GetInt32(12);
                            

                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}",

                            employeeModel.id,
                            employeeModel.name,
                            employeeModel.salary,
                            employeeModel.startdate,
                            employeeModel.gender,
                            employeeModel.phone,
                            employeeModel.address,
                            employeeModel.department,
                            employeeModel.basicpay,
                            employeeModel.deduction,
                            employeeModel.taxablepay,
                            employeeModel.incometax,
                            employeeModel.netpay);

                            Console.WriteLine("\n");

                        };

                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    //close data reader
                    dr.Close();
                    this.connection.Close();
                }
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                this.connection.Close();
            }

        }

       



    }
}
