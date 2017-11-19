﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoW.Pictre.BusinessObjects
{
    public class Comments
    {
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

        private string comments;
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string Comment
        {
            get { return comments; }
            set { comments = value; }
        }

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

        private string emailAddress;
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
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

        private string Fullname;
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string FullName
        {
            get { return Fullname; }
            set { Fullname = value; }
        }


        private int photoID;
        public int PhotoID
        {
            get { return photoID; }
            set { photoID = value; }
        }
    }
}
