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
        public static UserDto UserDaoToDto(User userDao)
        {
            if (userDao == null) return null;
            UserDto dto = new UserDto();
            dto.FirstName = userDao.FirstName;
            dto.LastName = userDao.LastName;
            dto.FullName = userDao.FullName;
            dto.EmailAddress = userDao.EmailAddress;
            dto.DateOfBirth = userDao.DateOfBirth;
            dto.Sex = userDao.Sex;

            return dto;

        }

        public static User UserDtoToDao(UserDto userDto)
        {
            if (userDto == null) return null;
            return new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                FullName = userDto.FullName,
                EmailAddress = userDto.EmailAddress,
                DateOfBirth = userDto.DateOfBirth,
                Sex = userDto.Sex
            };
        }

        public static List<UserDto> UserDaoToDto(List<User> userDaoList)
        {
            if (userDaoList == null) return null;
            var userList = (from userObj in userDaoList
                           select UserDaoToDto(userObj)).ToList();
            return userList;
        }

        public static FriendDto FriendDaoToDto(Friend friendDao)
        {
            if (friendDao == null) return null;
            FriendDto dto = new FriendDto();
            dto.ID = friendDao.ID;
            dto.FriendID = friendDao.FriendID;

            return dto;

        }

        public static Friend FriendDtoToDao(FriendDto friendDto)
        {
            if (friendDto == null) return null;
            return new Friend()
            {
                ID = friendDto.ID,
                FriendID = friendDto.FriendID,
            };
        }
    }
}
