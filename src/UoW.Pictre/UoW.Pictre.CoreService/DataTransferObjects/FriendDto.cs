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
    public class FriendDto
    {
        #region Database Properties

        private int id;
        [DataMember]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int friendID;
        [DataMember]
        public int FriendID
        {
            get { return friendID; }
            set { friendID = value; }
        }

        #endregion
    }
}
