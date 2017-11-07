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
        /// GetUserByEmailID
        /// </summary>
        /// <param name="EmailID"></param>
        /// <returns></returns>
        public UserDto GetUserByEmailID(string EmailID)
        {
            UserDao userDao = new UserDao();
            //return CoreObjectMapper.EmployeeDaoToDto(userDao.GetUserByEmailID(EmailID));
            return new UserDto() { FirstName = "User1FN", LastName = "User1LN", EmailAddress = "user1@gmail.com   ", DateOfBirth = DateTime.Now, FullName = "User1 User 1", Sex = "Male" };
        }
    }
}
