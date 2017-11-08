using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoW.Pictre.Core;
using UoW.Pictre.CoreService.DataTransferObjectMapper;
using UoW.Pictre.CoreService.DataTransferObjects;


namespace UoW.Pictre.CoreService
{
    public partial class Service : IUserService
    {
        /// <summary>
        /// Gets the Details of the User by Email ID.
        /// </summary>
        /// <param name="EmailID"></param>
        /// <returns></returns>
        public UserDto GetUserByEmailID(string EmailID)
        {
            UserDao userDao = new UserDao();
            return CoreObjectMapper.EmployeeDaoToDto(userDao.GetUserByEmailID(EmailID));
        }

        //TODO : Detelet this
        public string TestGetEmpSalary(string EmpId)
        {
            return "Salary of " + EmpId + " is " + 123456789;
        }
    }
}
