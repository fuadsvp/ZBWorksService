using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileBillSoft.DomainModel;
using ZBWorks.Domain_Models;
using ZBWorksService.DataLayer;

namespace ZBWorksService.Facade
{
    public class EmployeeFacade
    {
        internal static MbsResult AuthenticateEmployee(
            ZBUserDetails employee)
        {
            if (employee == null)
            {
                return new MbsResult(false, "Invalid Employee Details");
            }

            if (string.IsNullOrEmpty(employee.EmployeeName))
            {
                return new MbsResult(false, "Invalid Employee Name");
            }

            if (string.IsNullOrEmpty(employee.Password))
            {
                return new MbsResult(false, "Invalid Employee password");
            }

            return DbEngine.AuthenticateEmployee(employee);
        }
        internal static MbsResult GetAllEmployees()
        {
            MbsResult retVal = DbEngine.GetAllEmployees();
            return (retVal);
        }
        internal static MbsResult AddEmployee(ZBUserDetails newEmployee)
        {
            if (newEmployee == null)
            {
                return new MbsResult(false, "Invalid Employee Details");
            }

            if (string.IsNullOrEmpty(newEmployee.EmployeeName))
            {
                return new MbsResult(false, "Invalid Employee Name");
            }

            if (string.IsNullOrEmpty(newEmployee.Password))
            {
                return new MbsResult(false, "Invalid Employee password");
            }
            return DbEngine.AddNewEmployee(newEmployee);
        }

        internal static MbsResult GetEmployeeList()
        {
            MbsResult retVal = DbEngine.GetEmployeeList();
            return (retVal);
        }
        internal static MbsResult GetEmployeeDetails(string internalEmployeeId)
        {
            MbsResult retVal = DbEngine.GetEmployeeDetails(internalEmployeeId);
            return (retVal);
        }
        internal static MbsResult UpdateEmployee(ZBUserDetails updateEmployee)
        {
            if (updateEmployee == null)
            {
                return new MbsResult(false, "Invalid Employee Details");
            }

            if (string.IsNullOrEmpty(updateEmployee.EmployeeName))
            {
                return new MbsResult(false, "Invalid Employee Name");
            }

            if (string.IsNullOrEmpty(updateEmployee.Password))
            {
                return new MbsResult(false, "Invalid Employee password");
            }
            return DbEngine.UpdateEmployee(updateEmployee);
        }
        internal static MbsResult AddEmployeeTask(List<ZbWorks> Newtask)
        {
            //if (Newtask == null)
            //{
            //    return new MbsResult(false, "Invalid Employee Details");
            //}

            //if (string.IsNullOrEmpty(Newtask.TaskName))
            //{
            //    return new MbsResult(false, "Invalid Employee Name");
            //}

            //if (int.IsNullOrEmpty(employeeTask.))
            //{
            //    return new MbsResult(false, "Invalid Employee password");
            //}
            return DbEngine.AddEmployeeTask(Newtask);
        }
        internal static MbsResult GetEmployeeWorksheetDetailsByDate(string internalEmployeeId, long TaskDate, long TaskDate2)
        {
            MbsResult retVal = DbEngine.GetEmployeeWorksheetDetailsByDate(internalEmployeeId, TaskDate, TaskDate2);
            return (retVal);
        }

    }
}