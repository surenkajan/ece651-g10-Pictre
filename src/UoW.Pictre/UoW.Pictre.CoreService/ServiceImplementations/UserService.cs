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

        /// <summary>
        /// Add new user to the system
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUserByEmailID(UserDto user)
        //public int AddUserByEmailID()
        {
            //UserDto dto = new UserDto();
            //dto.FirstName = "Kajaruban2";
            //dto.LastName = "Surendran2";
            //dto.FullName = "Kajaruban2 Surendran2";
            //dto.EmailAddress = "surenkajan2@gmail.com";
            //dto.DateOfBirth = DateTime.Now;
            //dto.Sex = "Male";

            UserDao userDao = new UserDao();
            return userDao.AddNewUserByEmailID(CoreObjectMapper.EmployeeDtoToDao(user));
        }

        //TODO : Detelet this
        public string TestGetEmpSalary(string EmpId)
        {
            return "Salary of " + EmpId + " is " + 123456789;
        }

        public string TestGetEmpSalaryPost(string EmpId)
        {
            return "Salary of TestGetEmpSalaryPost " + EmpId + " is " + 123456789;
        }
    }
}
