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
    public partial class Service : ILikesService
    {

        public List<LikesDto> GetLikesByPhotoID(int PhotoID)
        {
            LikesDao likesDao = new LikesDao();
            return CoreObjectMapper.LikesDaoToDto(likesDao.GetLikesByPhotoID(PhotoID));
        }

        public int AddLikesByPhotoID(PhotoDto photo)
        {
            LikesDao likesdao = new LikesDao();
            return likesdao.AddNewLikesByFriendID(CoreObjectMapper.PhotoDtoToDao(photo));
        }

    }
}