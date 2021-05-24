using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CynthiaTicanteEmployees
{
    public abstract class Employee
    {
        #region PROPERTIES
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value ?? "John"; }
        }
        private string _FirstName;
        //can receive nulls
        public string MiddleName { get; set; }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value ?? "Doe"; }
        }
        private string _LastName;
        public int SalaryPerHour { get; set; }
        public string FullName { get; }
        int HoursPerWeek
        {
            get { return WorkerType == WorkerType.External ? 40 : 48; }
        }
        public WorkerType WorkerType { get; set; }
        public int WorkedHours { get; set; }
        #endregion
        #region METHODS
        /// <summary>
        /// Base salary just returns worked hours by salary per hour
        /// </summary>
        /// <param name="hoursWorked">Number of worked hours</param>
        /// <returns></returns>
        public int Salary(int hoursWorked)
        {
            hoursWorked = WorkedHours;
            return hoursWorked * SalaryPerHour;
        }

        /// <summary>
        /// There're 2 types of workers Locals and externals externals just can have 50% by extra worked hour
        /// Local workers can have two cases
        /// 1) 30% over extra by over worked hour
        /// 2) If overworked hours exeeds 12 hours then 60% over base salary is added.
        /// </summary>
        /// <param name="hoursWorked"></param>
        /// <returns></returns>
        public int ExtraSalary(int hoursWorked)
        {
            hoursWorked = WorkedHours;
            if(WorkerType == WorkerType.Local)
            {
                if (hoursWorked > HoursPerWeek)
                {
                    if (hoursWorked - HoursPerWeek > 12)
                    {
                        int paymentOverTwelve = (int)((Salary(WorkedHours) * .6) * (hoursWorked - HoursPerWeek - 12));
                        return ((int)((hoursWorked - HoursPerWeek) * (.3 * SalaryPerHour))) + paymentOverTwelve;
                    }
                    else
                        return (int)((hoursWorked - HoursPerWeek) * (.3 * SalaryPerHour));
                }
            }
            else if (WorkerType == WorkerType.External)
            {
                if (hoursWorked > HoursPerWeek)
                    return (int)((hoursWorked - HoursPerWeek) * (.5 * SalaryPerHour));
            }
            return 0;
        }
        #endregion
    }
}
