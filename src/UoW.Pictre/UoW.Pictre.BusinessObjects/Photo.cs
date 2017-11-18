using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoW.Pictre.BusinessObjects
{
    public class Photo : BusinessObject
    {
        #region Database properties

        private int userID;
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private string Firstname;
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string FirstName
        {
            get { return Firstname; }
            set { Firstname = value; }
        }

        private string Lastname;
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName
        {
            get { return Lastname; }
            set { Lastname = value; }
        }

        private string emailAddress;
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        private string profilePhoto;
        public string ProfilePhoto
        {
            get { return profilePhoto; }
            set { profilePhoto = value; }
        }

        private string actualPhoto;
        public string ActualPhoto
        {
            get { return actualPhoto; }
            set { actualPhoto = value; }
        }

        private string photoDescription;
        public string PhotoDescription
        {
            get { return photoDescription; }
            set { photoDescription = value; }
        }

        private string tags;
        public string Tags
        {
            get { return tags; }
            set { tags = value; }
        }

        private DateTime? uploadTimeStamp;
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public DateTime? UploadTimeStamp
        {
            get { return uploadTimeStamp; }
            set { uploadTimeStamp = value; }
        }

        private string comments;
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }
        private string location;
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        private DateTime? commentstime;
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public DateTime? CommentsTime
        {
            get { return commentstime; }
            set { commentstime = value; }
        }

        private int photoID;
        public int PhotoID
        {
            get { return photoID; }
            set { photoID = value; }
        }
        #endregion
    }
}
