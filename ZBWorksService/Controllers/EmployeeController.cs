 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MobileBillSoft.DomainModel;
using ZBWorks.Domain_Models;
using ZBWorksService.Facade;

namespace ZBWorksService.Controllers
{
    [RoutePrefix("api/EmployeeWorks")]
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("Employees")]
        public IHttpActionResult GetAllEmployees()
        {
            MbsResult retVal = EmployeeFacade.GetAllEmployees();
            return Ok(retVal);
        }

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult AuthenticateEmployee([FromBody] ZBUserDetails employee)
        {
            MbsResult retVal = EmployeeFacade.AuthenticateEmployee(employee);
            return Ok(retVal);
        }

        [HttpPost]
        [Route("AddEmployee")]
        public IHttpActionResult AddEmployee([FromBody] ZBUserDetails newEmployee)
        {
            MbsResult retVal = EmployeeFacade.AddEmployee(newEmployee);
            return Ok(retVal);
        }

        [HttpGet]
        [Route("EmployeesList")]
        public IHttpActionResult GetEmployeeList()
        {
            MbsResult retVal = EmployeeFacade.GetEmployeeList();
            return Ok(retVal);
        }

        [HttpGet]
        [Route("EmployeesDetails")]
        public IHttpActionResult GetEmployeeDetails(string internalEmployeeId)
        {
            MbsResult retVal = EmployeeFacade.GetEmployeeDetails(internalEmployeeId);
            return Ok(retVal);
        }
        [HttpPost]
        [Route("UpdateEmployee")]
        public IHttpActionResult UpdateEmployee([FromBody] ZBUserDetails updateEmployee)
        {
            MbsResult retVal = EmployeeFacade.UpdateEmployee(updateEmployee);
            return Ok(retVal);
        }
        [HttpPost]
        [Route("AddEmployeeTask")]
        public IHttpActionResult AddEmployeeTask([FromBody] List<ZbWorks> Newtask)
        {
            MbsResult retVal = EmployeeFacade.AddEmployeeTask(Newtask);
            return Ok(retVal);
        }

        [HttpGet]
        [Route("WorksheetDetailsByDate")]
        public IHttpActionResult GetEmployeeWorksheetDetailsByDate(string internalEmployeeId,long TaskDate, long TaskDate2)
        {
            MbsResult retVal = EmployeeFacade.GetEmployeeWorksheetDetailsByDate(internalEmployeeId,TaskDate, TaskDate2);
            return Ok(retVal);
        }
    }
}