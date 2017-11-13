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

        public List<PhotoDto> GetCommentsByID(int photoID)
        {
            PhotoDao photodao = new PhotoDao();

            
            return CoreObjectMapper.PhotoDaoToDto(photodao.GetCommentsByID(photoID));
        }
    }
}
