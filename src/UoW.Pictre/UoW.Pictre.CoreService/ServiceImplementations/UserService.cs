using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using UoW.Pictre.Core;
using UoW.Pictre.CoreService.DataTransferObjectMapper;
using UoW.Pictre.CoreService.DataTransferObjects;


namespace UoW.Pictre.CoreService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
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
            return CoreObjectMapper.UserDaoToDto(userDao.GetUserByEmailID(EmailID));
        }

        /// <summary>
        /// Add new user to the system
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUserByEmailID(UserDto user)
        //public int AddUserByEmailID()
        {
            //UserDto user = new UserDto();
            //user.FirstName = "Kajaruban21";
            //user.LastName = "Surendran21";
            //user.FullName = "Kajaruban21 Surendran21";
            //user.EmailAddress = "surenkajan21@gmail.com";
            //user.DateOfBirth = DateTime.Now;
            //user.Sex = "Male";

            UserDao userDao = new UserDao();
            return userDao.AddNewUserByEmailID(CoreObjectMapper.UserDtoToDao(user));
        }

        public int AddFriendByUID(FriendRequestDto user)
        {
            UserDao userDao = new UserDao();
            return userDao.AddFriendByUID(CoreObjectMapper.AddFriendDtoToDao(user));
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

        public List<UserDto> GetAllUsers()
        {
            UserDao userDao = new UserDao();
            return CoreObjectMapper.UserDaoToDto(userDao.GetAllUsers());
        }

        public int UpdateUserByEmailID(UserDto user)
        {
            UserDao userDao = new UserDao();
            return userDao.UpdateUserByEmailID(CoreObjectMapper.UserDtoToDao(user));

        }

        public int DeleteUserByEmailID(string EmailID)
        {
            UserDao userDao = new UserDao();
            return userDao.DeleteUserByEmailID(EmailID);
        }
    }
}
