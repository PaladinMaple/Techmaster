using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CynthiaTicanteEmployees
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ELEMENTS
            /*Note: I'm not completely sure if employee's list should be entered by user or should be static, so I decided static.*/
            ExternalEmployee externalEmployee = new ExternalEmployee("Damon", "Albarn");
            LocalEmployee localEmployee = new LocalEmployee(null, null);

            externalEmployee.SalaryPerHour = 100;
            localEmployee.SalaryPerHour = 100;
            externalEmployee.WorkedHours = 60;
            localEmployee.WorkedHours = 62;

            List<Employee> employees = new List<Employee>();
            employees.Add(externalEmployee);
            employees.Add(localEmployee);
            employees.Add(externalEmployee);
            employees.Add(localEmployee);
            #endregion

            Console.WriteLine("This program will tell you the average salary per hour of the registered employees \nbased on your worker type selection \n");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("Select an option from the list \n 1) Locals \n 2) Externals \n 3) Both");

            string input;
            int selection = 0;
            bool isNumber = false;

            while (true)
            {
                input = Console.ReadLine();
                isNumber = int.TryParse(input, out selection);
                if (!int.TryParse(input, out selection))
                    Console.WriteLine("Input not a number");
                else if (selection > 3 || selection < 1)
                {
                    selection = 0;
                    Console.WriteLine("Please enter a valid option");
                }
                else
                {
                    string message = "Your selection: ";
                    message += selection == 3 ? "Both" : ((WorkerType)selection).ToString();
                    Console.WriteLine(message);
                    Console.WriteLine("Average per hour: " + GetAverageSalaryPerHour(employees, (WorkerType)selection));
                    Console.ReadKey();
                    break;
                }
            }
        }

        /// <summary>
        /// Given a list of employees calculates the average salary based on worker type, can be 1 type of worker or both
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="workerTypeRequested"></param>
        /// <returns></returns>
        public static int GetAverageSalaryPerHour(List<Employee> employees, WorkerType workerTypeRequested)
        {
            try
            {
                List<int> total = new List<int>();
                if ((int) workerTypeRequested != 3)
                    total = employees.Where(w => w.WorkerType == workerTypeRequested).Select(s => (s.Salary(s.WorkedHours) + s.ExtraSalary(s.WorkedHours)) / s.WorkedHours).ToList();
                else
                    total = employees.Select(s => (s.Salary(s.WorkedHours) + s.ExtraSalary(s.WorkedHours)) / s.WorkedHours).ToList();

                return (int)total.Average();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
