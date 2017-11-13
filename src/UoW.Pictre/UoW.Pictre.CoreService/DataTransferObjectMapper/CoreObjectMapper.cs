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
            dto.UserName = userDao.UserName;
            dto.FirstName = userDao.FirstName;
            dto.LastName = userDao.LastName;
            dto.FullName = userDao.FullName;
            dto.EmailAddress = userDao.EmailAddress;
            dto.DateOfBirth = userDao.DateOfBirth;
            dto.Sex = userDao.Sex;
			 dto.ProfilePhoto = userDao.ProfilePhoto;

            return dto;

        }
        public static UserDto UserDaoToDto(User userDao)
        {
            if (userDao == null) return null;
            UserDto dto = new UserDto();
            dto.UserName = userDao.UserName;
            dto.FirstName = userDao.FirstName;
            dto.LastName = userDao.LastName;
            dto.FullName = userDao.FullName;
            dto.EmailAddress = userDao.EmailAddress;
            dto.DateOfBirth = userDao.DateOfBirth;
            dto.Sex = userDao.Sex;
			    dto.ProfilePhoto = userDao.ProfilePhoto;

            return dto;

        }

        public static User UserDtoToDao(UserDto userDto)
        {
            if (userDto == null) return null;
            return new User()
            {
                UserName = userDto.UserName,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                FullName = userDto.FullName,
                EmailAddress = userDto.EmailAddress,
                DateOfBirth = userDto.DateOfBirth,
                Sex = userDto.Sex,
				 ProfilePhoto = userDto.ProfilePhoto
            };
        }

        public static List<UserDto> UserDaoToDto(List<User> userDaoList)
        {
            if (userDaoList == null) return null;
            var userList = (from userObj in userDaoList
                            select UserDaoToDto(userObj)).ToList();
            return userList;
        }


        public static FriendDto FriendDaoToDto(Friend friend)
        {
            if (friend == null) return null;
            FriendDto dto = new FriendDto();
            dto.FirstName = friend.FirstName;
            dto.ProfilePhoto= friend.ProfilePhoto;

            return dto;

        }
        public static List<FriendDto> FriendDaoToDto(List<Friend> friendDaoList)
        {
            if (friendDaoList == null) return null;

            var frndList = (from userObj in friendDaoList
                            select FriendDaoToDto(userObj)).ToList();
            return frndList;



        }

        public static PhotoDto PhotoDaoToDto(Photo photo)
        {
            if (photo == null) return null;
            PhotoDto dto = new PhotoDto();

            dto.FirstName = photo.FirstName;
            dto.Comments= photo.Comments;
            dto.CommentsTime = photo.CommentsTime;
           
            return dto;

        }
        public static List<PhotoDto> PhotoDaoToDto(List<Photo> photoDaoList)
        {
            if (photoDaoList == null) return null;

            var photoList = (from userObj in photoDaoList
                             select PhotoDaoToDto(userObj)).ToList();
            return photoList;



        }
        public static User EmployeeDtoToDao(UserDto userDto)
        {
            if (userDto == null) return null;
            return new User()
            {
                UserName = userDto.UserName,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                FullName = userDto.FullName,
                EmailAddress = userDto.EmailAddress,
                DateOfBirth = userDto.DateOfBirth,
                Sex = userDto.Sex
            };
        }

    }
}
