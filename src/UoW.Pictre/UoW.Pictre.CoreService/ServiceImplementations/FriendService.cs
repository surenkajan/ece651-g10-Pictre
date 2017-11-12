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
    public partial class Service : IFriendService
    {
        
       public List<FriendDto> GetFriendByEmailID(string EmailID)
        {
            FriendDao frndDao = new FriendDao();
            return CoreObjectMapper.FriendDaoToDto(frndDao.GetFriendByEmailID(EmailID));
        }

    }
}
