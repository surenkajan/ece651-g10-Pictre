using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoW.Pictre.BusinessObjects
{
    public class FriendRequest : BusinessObject
    {
        private string currentUserEmailID;
        public string CurrentUserEmailID
        {
            get { return currentUserEmailID; }
            set { currentUserEmailID = value; }
        }

        private int uid;
        public int Uid
        {
            get { return uid; }
            set { uid = value; }
        }
    }
}
