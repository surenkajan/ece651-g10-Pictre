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
    public class LikesDto
    {
        #region Database Properties
        private string Firstname;
        [DataMember]
        public string FirstName
        {
            get { return Firstname; }
            set { Firstname = value; }
        }

        private string lastname;
        [DataMember]
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        private int userID;
        [DataMember]
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private string profilePhoto;
        [DataMember]
        public string ProfilePhoto
        {
            get { return profilePhoto; }
            set { profilePhoto = value; }
        }

        private string Fullname;
        [DataMember]
        public string FullName
        {
            get { return Fullname; }
            set { Fullname = value; }
        }

        #endregion
    }
}
