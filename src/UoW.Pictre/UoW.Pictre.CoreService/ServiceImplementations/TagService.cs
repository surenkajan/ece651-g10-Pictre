﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoW.Pictre.Core;
using UoW.Pictre.CoreService.DataTransferObjectMapper;
using UoW.Pictre.CoreService.DataTransferObjects;

namespace UoW.Pictre.CoreService
{
    public partial class Service : ITagService
    {
        public List<TagFriendDto> GetTagsByPhotoID(int PhotoID)
        {
            TagsDao tagsDao = new TagsDao();
            return CoreObjectMapper.TagsDaoToDto(tagsDao.GetTagsByPhotoID(PhotoID));
        }
    }

}
