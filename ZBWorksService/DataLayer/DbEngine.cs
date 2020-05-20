using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileBillSoft.DomainModel;
using ZBWorks.Domain_Models;
using ZBWorksService.Data_Models;
using ZBWorksService.DBContext;

namespace ZBWorksService.DataLayer
{
    public class DbEngine
    {
        internal static MbsResult GetAllEmployees()
        {
            ZBWorksDBContext dbContext = new ZBWorksDBContext();

            List<ZB_USERDETAILS> EmployeeListDB =
                dbContext.ZBUSERDETAILs.Where(src =>
              src.EmployeeName != null).ToList();

            List<ZBUserDetails> EmployeeList = new List<ZBUserDetails>();

            foreach (ZB_USERDETAILS item in EmployeeListDB)
            {
                EmployeeList.Add(new ZBUserDetails
                {
                    EmployeeName = item.EmployeeName,
                });
            }

            MbsResult retVal = new MbsResult(true, EmployeeList);

            return retVal;
        }
        internal static MbsResult AuthenticateEmployee(ZBUserDetails employee)
        {
            using (ZBWorksDBContext dbContext = new ZBWorksDBContext())
            {
                ZB_USERDETAILS matchingEmployee =dbContext.ZBUSERDETAILs.Where(src =>
                        src.EmployeeName == employee.EmployeeName &&
                        src.Password == employee.Password).FirstOrDefault();
                //cheking and feching data from DB 

                if (matchingEmployee == null)
                {
                    return new MbsResult(false, "Invalid credentails");
                }

                ZBUserDetails retVal = new ZBUserDetails()
                {
                    EmployeeName = matchingEmployee.EmployeeName,
                    InternalEmployeeID = matchingEmployee.InternalEmployeeID,
                    Role = matchingEmployee.Role,
                };
                return new MbsResult(true, retVal);
            }
        }
        internal static MbsResult AddNewEmployee(ZBUserDetails newEmployee)
        {
            using (ZBWorksDBContext dbContext = new ZBWorksDBContext())
            {
                ZB_USERDETAILS matchingEmployee = new ZB_USERDETAILS()
                {
                    InternalEmployeeID = Guid.NewGuid().ToString(),
                    EmployeeName = newEmployee.EmployeeName,
                    Password = newEmployee.Password,
                    Role = newEmployee.Role
                };
                dbContext.ZBUSERDETAILs.Add(matchingEmployee);
                dbContext.SaveChanges();
                return new MbsResult(true, "");

            }

        }

        internal static MbsResult GetEmployeeList()
        {
            ZBWorksDBContext dbContext = new ZBWorksDBContext();

            List<ZB_USERDETAILS> EmployeeListDB =
                dbContext.ZBUSERDETAILs.Where(src =>
              src.EmployeeName != null).ToList();

            List<ZBUserDetails> EmployeeList = new List<ZBUserDetails>();

            foreach (ZB_USERDETAILS item in EmployeeListDB)
            {
                EmployeeList.Add(new ZBUserDetails
                {
                    EmployeeName = item.EmployeeName,
                    Role = item.Role,
                    Password=item.Password,
                    InternalEmployeeID=item.InternalEmployeeID,
                                       
                });
            }

            MbsResult retVal = new MbsResult(true, EmployeeList);

            return retVal;
        }
        internal static MbsResult GetEmployeeDetails(string internalEmployeeId)
        {
            using (ZBWorksDBContext dbContext = new ZBWorksDBContext())
            {

                ZB_USERDETAILS matchingEmployee = dbContext.ZBUSERDETAILs.Where
                    (src => src.InternalEmployeeID == internalEmployeeId).FirstOrDefault();

                if(matchingEmployee==null)
                {
                    return new MbsResult(false, "invalid");
                }
                ZB_USERDETAILS retval=new ZB_USERDETAILS()
                    {
                        InternalEmployeeID = Guid.NewGuid().ToString(),
                        EmployeeName = matchingEmployee.EmployeeName,
                        Password = matchingEmployee.Password,
                        Role = matchingEmployee.Role
                    };           
                    return new MbsResult(true, retval);                
            }
        }
        internal static MbsResult UpdateEmployee(ZBUserDetails updateEmployee)
        {
            using (ZBWorksDBContext dbContext = new ZBWorksDBContext())
            {
                ZB_USERDETAILS matchingEmployee = dbContext.ZBUSERDETAILs.Where
                    (src => src.InternalEmployeeID == updateEmployee.InternalEmployeeID).FirstOrDefault();

                if (matchingEmployee == null)
                {
                    return new MbsResult(false, "invalid Credentails");
                }
               
                if (updateEmployee.EmployeeName != matchingEmployee.EmployeeName)
                {
                    matchingEmployee.EmployeeName = updateEmployee.EmployeeName;
                }

                if (updateEmployee.Role != matchingEmployee.Role)
                {
                    matchingEmployee.Role = updateEmployee.Role;
                }

                if (updateEmployee.Password != matchingEmployee.Password)
                {
                    matchingEmployee.Password = updateEmployee.Password;
                }

                dbContext.SaveChanges();
                return new MbsResult(true, "");

            }

        }
        internal static MbsResult AddEmployeeTask(List<ZbWorks> Newtask)
        {
            using (ZBWorksDBContext dbContext = new ZBWorksDBContext())
            {
                List<ZB_WORKS> NewEmployeeTask = new List<ZB_WORKS>();
                foreach (var item in Newtask)
                {
                    ZB_WORKS employeetask = new ZB_WORKS()
                    {
                        InternalZBWorksId = Guid.NewGuid().ToString(),
                        EmployeeName =item.EmployeeName,
                        InternalEmployeeID=item.InternalEmployeeID,
                        TaskName = item.TaskName,
                        TaskDuration = item.TaskDuration,
                        TaskDate = item.TaskDate
                    };
                    
                    dbContext.ZBWORKs.Add(employeetask);
                    
                }
                dbContext.SaveChanges();
                
                return new MbsResult(true, "");
               
            }

        }
        internal static MbsResult GetEmployeeWorksheetDetailsByDate(string internalEmployeeId, long TaskDate, long TaskDate2)
        {
            using (ZBWorksDBContext dbContext = new ZBWorksDBContext())
            {

                List<ZB_WORKS> matchingTask = dbContext.ZBWORKs.Where
                    (src => src.InternalEmployeeID == internalEmployeeId &&
                     src.TaskDate==TaskDate || src.TaskDate==TaskDate2).ToList();

                if (matchingTask == null)
                {
                    return new MbsResult(false, "No Tasks");
                }

                List<ZbWorks> TaskList = new List<ZbWorks>();

                foreach (var item in matchingTask)
                {
                    TaskList.Add(new ZbWorks
                    {
                        TaskName = item.TaskName,
                        TaskDate=item.TaskDate,
                        InternalEmployeeID=item.InternalEmployeeID,
                        EmployeeName=item.EmployeeName,
                        InternalZBWorksId=item.InternalZBWorksId
                    });
                }
                MbsResult retVal = new MbsResult(true, TaskList);

                return retVal;               
            }
        }
    }
}
