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
            dto.UserID = userDao.UserID;

            return dto;

        }
        public static Comments AddCommentsDtoToDao(CommentsDto comments)
        {
            if (comments == null) return null;
            return new Comments()
            {
                UserID = comments.UserID,
                PhotoID   = comments.PhotoID,
                Comment = comments.Comments,
                CommentsTime= comments.UploadTimeStamp,
                FirstName = comments.FirstName,
                LastName = comments.LastName,
                FullName = comments.FullName,
                EmailAddress = comments.EmailAddress

            };

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
				 ProfilePhoto = userDto.ProfilePhoto,
                 UserID = userDto.UserID

            };
        }
        public static Photo DeletePhotoDtotoDao(PhotoDto photo)
        {
            if (photo == null) return null;
            return new Photo()
            {
                PhotoID = photo.PhotoID
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
            dto.LastName = friend.LastName;
            dto.EmailAddress = friend.EmailAddress;
            dto.ProfilePhoto= friend.ProfilePhoto;
            dto.Uid = friend.Uid;
            dto.FullName = friend.FullName; 
            return dto;

        }

        public static List<FriendDto> FriendDaoToDto(List<Friend> friendDaoList)
        {
            if (friendDaoList == null) return null;

            var frndList = (from userObj in friendDaoList
                            select FriendDaoToDto(userObj)).ToList();
            return frndList;
        }


	 public static LikesDto LikesDaoToDto(Likes likes)
        {
            if (likes == null) return null;
            LikesDto dto = new LikesDto();
            dto.FirstName = likes.FirstName;
            dto.FullName = likes.FullName;
            dto.Lastname = likes.LastName;
            dto.ProfilePhoto = likes.ProfilePhoto;
            dto.UserID = likes.UserID;
           
            return dto;

        }
        public static List<LikesDto> LikesDaoToDto(List<Likes> likesDaoList)
        {
            if (likesDaoList == null) return null;

            var likesList = (from userObj in likesDaoList
                             select LikesDaoToDto(userObj)).ToList();
            return likesList;
        }

        public static Photo PhotoDtoToDao(PhotoDto photo)
        {
            if (photo == null) return null;
            return new Photo()
            {
                PhotoID = photo.PhotoID,
                EmailAddress = photo.EmailAddress
            };
        }

        public static Photo AddPhotoDtoToDao(PhotoDto photodto)
        {
            if (photodto == null) return null;
            return new Photo()
            {
                PhotoDescription = photodto.PhotoDescription,
                UploadTimeStamp = photodto.UploadTimeStamp,
                ActualPhoto = photodto.ActualPhoto,
                Tags = photodto.Tags,
                Location = photodto.Location,
                EmailAddress = photodto.EmailAddress
            };

        }

        public static CommentsDto CommentDaoToDto(Comments comment)
        {
            if (comment == null) return null;
            CommentsDto dto = new CommentsDto();
            dto.Comments = comment.Comment;
            dto.FirstName = comment.FirstName;
            dto.UploadTimeStamp = comment.CommentsTime;
            dto.LastName = comment.LastName;
            dto.FullName = comment.FullName;
            dto.UserID = comment.UserID;
            dto.PhotoID = comment.PhotoID;
            dto.ProfilePhoto = comment.ProfilePhoto;
            return dto;

        }

        public static List<CommentsDto> CommentDaoToDto(List<Comments> CommentDaoList)
        {
            if (CommentDaoList == null) return null;

            var commentList = (from userObj in CommentDaoList
                             select CommentDaoToDto(userObj)).ToList();
            return commentList;



        }

        public static PhotoDto PhotoDaoToDto(Photo photo)
        {
            if (photo == null) return null;
            PhotoDto dto = new PhotoDto();
            dto.UserID = photo.UserID;
            dto.FirstName = photo.FirstName;
            dto.LastName = photo.LastName;
            dto.EmailAddress = photo.EmailAddress;
            dto.ProfilePhoto = photo.ProfilePhoto;
            dto.ActualPhoto = photo.ActualPhoto;
            dto.PhotoDescription = photo.PhotoDescription;
            dto.UploadTimeStamp = photo.UploadTimeStamp;
            //dto.Comments= photo.Comments;
            //dto.CommentsTime = photo.CommentsTime;
            dto.Location = photo.Location;
            dto.Tags = photo.Tags;
            dto.PhotoID = photo.PhotoID;

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

        public static TagFriendDto TagsDaoToDto(Tags tags)
        {
            if (tags == null) return null;
            TagFriendDto dto = new TagFriendDto();
            dto.FirstName = tags.FirstName;
            return dto;

        }

        public static List<TagFriendDto> TagsDaoToDto(List<Tags> tagsDaoList)
        {
            if (tagsDaoList == null) return null;
            var tagsList = (from obj in tagsDaoList select TagsDaoToDto(obj)).ToList();
            return tagsList;
        }

        public static FriendRequest AddFriendDtoToDao(FriendRequestDto userDto)
         {
             if (userDto == null) return null;
             return new FriendRequest()
             {
                 Uid = userDto.Uid,
                 CurrentUserEmailID = userDto.CurrentUserEmailID
             };
        }

        public static SecurityQuestionDto SecurityQuestionDaoToDto(SecurityQuestion SecurityQuestion)
        {
            if (SecurityQuestion == null) return null;
            SecurityQuestionDto dto = new SecurityQuestionDto();
            dto.ID = SecurityQuestion.ID;
            dto.Question = SecurityQuestion.Question;


            return dto;
        }

        public static List<SecurityQuestionDto> SecurityQuestionsDaoToDto(List<SecurityQuestion> SecurityQuestionDaoList)
        {
            if (SecurityQuestionDaoList == null) return null;
            var secList = (from secObj in SecurityQuestionDaoList
                           select SecurityQuestionDaoToDto(secObj)).ToList();
            return secList;
        }

        //SecurityAnswersDaoToDto
        public static SecurityAnswersDto SecurityAnswersDaoToDto(SecurityAnswers SecurityAnswersDao)
        {
            if (SecurityAnswersDao == null) return null;
            SecurityAnswersDto dto = new SecurityAnswersDto();
            dto.UserEmailID = SecurityAnswersDao.UserEmailID;
            dto.QuestionsAnswers = SecurityAnswersDao.QuestionsAnswers;

            return dto;
        }

        public static SecurityAnswers SecurityAnswersDtoToDao(SecurityAnswersDto secAnsDto)
        {
            if (secAnsDto == null) return null;
            return new SecurityAnswers()
            {
                UserEmailID = secAnsDto.UserEmailID,
                QuestionsAnswers = new List<SecurityAnswerPair>()
                {
                    new SecurityAnswerPair(){
                            Question = new SecurityQuestion(){ Question = secAnsDto.QuestionsAnswers[0].Question.Question},
                            Answer =  secAnsDto.QuestionsAnswers[0].Answer
                        },
                        new SecurityAnswerPair(){
                            Question = new SecurityQuestion(){ Question = secAnsDto.QuestionsAnswers[1].Question.Question},
                            Answer =  secAnsDto.QuestionsAnswers[1].Answer
                        }
                }
            };
        }

        public static SecurityAnswersDto SecurityQuestionDaoToDto(SecurityAnswers SecurityQuestionAnswer)
        {
            if (SecurityQuestionAnswer == null) return null;
            return new SecurityAnswersDto()
            {
                UserEmailID = SecurityQuestionAnswer.UserEmailID,
                QuestionsAnswers = new List<SecurityAnswerPair>()
                {
                    new SecurityAnswerPair(){
                            Question = new SecurityQuestion(){ Question = SecurityQuestionAnswer.QuestionsAnswers[0].Question.Question},
                            Answer =  SecurityQuestionAnswer.QuestionsAnswers[0].Answer
                        },
                        new SecurityAnswerPair(){
                            Question = new SecurityQuestion(){ Question = SecurityQuestionAnswer.QuestionsAnswers[1].Question.Question},
                            Answer =  SecurityQuestionAnswer.QuestionsAnswers[1].Answer
                        }
                }
            };
        }


        //public static List<SecurityAnswersDto> SecurityQuestionsAnswersDaoToDto(List<SecurityAnswers> SecurityQuestionAnswersDaoList)
        //{
        //    if (SecurityQuestionAnswersDaoList == null) return null;
        //    var secList = (from secAnsObj in SecurityQuestionAnswersDaoList
        //                   select SecurityQuestionDaoToDto(secAnsObj)).ToList();
        //    return secList;
        //}

    }
}
