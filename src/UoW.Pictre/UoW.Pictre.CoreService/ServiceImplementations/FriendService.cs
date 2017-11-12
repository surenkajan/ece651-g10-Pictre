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
        /// <summary>
        /// Gets the Details of the User by Email ID.
        /// </summary>
        /// <param name="EmailID"></param>
        /// <returns></returns>
        public FriendDto GetFriendsByID(int ID)
        {
            FriendsDao friendDao = new FriendsDao();
            return CoreObjectMapper.FriendDaoToDto(friendDao.GetFriendsByID(ID));
        }
    }
}
