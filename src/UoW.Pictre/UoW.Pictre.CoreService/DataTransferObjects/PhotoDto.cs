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

        private String Firstname;
        [DataMember]
        public string FirstName
        {
            get { return Firstname; }
            set { Firstname = value; }
        }
        private String comments;
        [DataMember]
        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }
        private DateTime? commentstime;
        [DataMember]
        public DateTime? CommentsTime
        {
            get { return commentstime; }
            set { commentstime = value; }
        }
        #endregion
    }
}
