using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoW.Pictre.BusinessObjects;
using UoW.Pictre.CoreService.DataTransferObjects;

namespace UoW.Pictre.CoreService.DataTransferObjectMapper
{
    public class CoreObjectMapper
    {
        public static UserDto EmployeeDaoToDto(User userDao)
        {
            if (userDao == null) return null;
            UserDto dto = new UserDto();
            dto.DateOfBirth = userDao.DateOfBirth;
            dto.EmailAddress = userDao.EmailAddress;
            dto.FirstName = userDao.FirstName;
            dto.FullName = userDao.FullName;
            dto.LastName = userDao.LastName;
            dto.Sex = userDao.Sex;
            dto.ProfileImage = userDao.ProfileImage;
            return dto;
        }
    }
}
