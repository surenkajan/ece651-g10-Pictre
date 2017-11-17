using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UoW.Pictre.CoreService.DataTransferObjects
{
    [Serializable]
    [DataContract]
    public class FriendRequestDto
    {
        private int UID;
        [DataMember]
        public int Uid
        {
            get { return UID; }
            set { UID = value; }
        }

        private string currentUserEmailID;
        [DataMember]
        public string CurrentUserEmailID
        {
            get { return currentUserEmailID; }
            set { currentUserEmailID = value; }
        }

    }
}
