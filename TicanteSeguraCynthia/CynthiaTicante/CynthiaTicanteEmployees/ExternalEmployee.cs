using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CynthiaTicanteEmployees
{
    public class ExternalEmployee : Employee
    {
        public ExternalEmployee(string _FirstName, string _LastName, string _MiddleName = "")
        {
            WorkerType = WorkerType.External;
            FirstName = _FirstName;
            LastName = _LastName;
            MiddleName = _MiddleName;
        }
    }
}
