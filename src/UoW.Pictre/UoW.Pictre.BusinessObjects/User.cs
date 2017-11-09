using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.Pictre.BusinessObjects
{
    public class User : BusinessObject
    {
        #region Database properties

        private string lastName;
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string userName;
        /// <summary>
        /// Gets or sets the userName.
        /// </summary>
        /// <value>
        /// The userName.
        /// </value>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private DateTime? dateOfBirth;
        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        public DateTime? DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        private string emailAddress;
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        private string middleNames;
        public string MiddleNames
        {
            get { return middleNames; }
            set { middleNames = value; }
        }

        private string sex;
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        #endregion

        #region External Properties
        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        /// <value>
        /// The profile image.
        /// </value>
        public string ProfileImage { get; set; }

        #endregion

    }
}
