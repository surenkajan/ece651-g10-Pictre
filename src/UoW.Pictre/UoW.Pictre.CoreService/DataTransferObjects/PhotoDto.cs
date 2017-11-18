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
    public class PhotoDto
    {
        #region Database properties

        private int userID;
        [DataMember]
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private String Firstname;
        [DataMember]
        public string FirstName
        {
            get { return Firstname; }
            set { Firstname = value; }
        }

        private String Lastname;
        [DataMember]
        public string LastName
        {
            get { return Lastname; }
            set { Lastname = value; }
        }

        private String emailAddress;
        [DataMember]
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        private String actualPhoto;
        [DataMember]
        public string ActualPhoto
        {
            get { return actualPhoto; }
            set { actualPhoto = value; }
        }

        private String profilePhoto;
        [DataMember]
        public string ProfilePhoto
        {
            get { return profilePhoto; }
            set { profilePhoto = value; }
        }

        private String photoDescription;
        [DataMember]
        public string PhotoDescription
        {
            get { return photoDescription; }
            set { photoDescription = value; }
        }

        private String tags;
        [DataMember]
        public string Tags
        {
            get { return tags; }
            set { tags = value; }
        }

        private DateTime? uploadTimeStamp;
        [DataMember]
        public DateTime? UploadTimeStamp
        {
            get { return uploadTimeStamp; }
            set { uploadTimeStamp = value; }
        }

        private String comments;
        [DataMember]
        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }
        private String location;
        [DataMember]
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        private DateTime? commentstime;
        [DataMember]
        public DateTime? CommentsTime
        {
            get { return commentstime; }
            set { commentstime = value; }
        }

        private int photoID;
        [DataMember]
        public int PhotoID
        {
            get { return photoID; }
            set { photoID = value; }
        }

        #endregion
    }
}
