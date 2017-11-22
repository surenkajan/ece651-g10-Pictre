using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoW.Pictre.BusinessObjects
{
    public class Likes : BusinessObject
    {
        #region Database Properties
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private int userID;
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private string profilePhoto;
        public string ProfilePhoto
        {
            get { return profilePhoto; }
            set { profilePhoto = value; }
        }

        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        #endregion
    }
}
