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
        #endregion
    }
}
