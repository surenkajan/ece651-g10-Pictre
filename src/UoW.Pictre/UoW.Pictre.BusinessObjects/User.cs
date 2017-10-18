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

        private string loginName;
        /// <summary>
        /// Gets or sets the name of the login.
        /// </summary>
        /// <value>
        /// The name of the login.
        /// </value>
        public string LoginName
        {
            get { return loginName; }
            set
            {
                string receivedLoginName = value;
                if (receivedLoginName != null)
                {
                    string[] loginNameParts = receivedLoginName.Split(new char[] { '|' });
                    if (loginNameParts.Length > 1)
                        loginName = loginNameParts[1];
                    else
                        loginName = receivedLoginName;

                    if (loginName.ToLower().Contains("virtusa"))
                        loginName = loginName.ToLower().Replace("virtusa\\", "");
                }
            }
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
