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
    public partial class Service : IPhotoService
    {

        public List<CommentsDto> GetCommentsByID(int photoID)
        {
            CommentsDao commentdao = new CommentsDao();

            
            return CoreObjectMapper.CommentDaoToDto(commentdao.GetCommentsByID(photoID));
        }

        public List<PhotoDto> GetFriendPhotosByEmailID(string EmailID)
        {
            PhotoDao photodao = new PhotoDao();
            return CoreObjectMapper.PhotoDaoToDto(photodao.GetFriendPhotosByEmailID(EmailID));
        }

        public List<PhotoDto> GetPhotosByEmailID(string EmailID)
        {
            PhotoDao photodao = new PhotoDao();
            return CoreObjectMapper.PhotoDaoToDto(photodao.GetPhotosByEmailID(EmailID));
        }

       public  int AddCommentsByEmailID(CommentsDto comments)
        {
            CommentsDao commentdao = new CommentsDao();
            return commentdao.AddCommentsByEmailID(CoreObjectMapper.AddCommentsDtoToDao(comments));
        }

        public int AddPhotoByEmailID(PhotoDto photo)
        {
            PhotoDao photodao = new PhotoDao();
            return photodao.AddPhotoByEmailID(CoreObjectMapper.AddPhotoDtoToDao(photo));
        }
    }
}
