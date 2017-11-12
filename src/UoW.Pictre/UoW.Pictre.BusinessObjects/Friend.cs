using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoW.Pictre.BusinessObjects
{
    public class Friend : BusinessObject
    {
        #region Database properties

        private int id;
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>
        /// ID.
        /// </value>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int friendID;
        /// <summary>
        /// Gets or sets the FriendID.
        /// </summary>
        /// <value>
        /// FriendID.
        /// </value>
        public int FriendID
        {
            get { return friendID; }
            set { friendID = value; }
        }

        #endregion
    }
}