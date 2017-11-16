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

    public class TagFriendDto
    {
        #region Database Properties
        private string firstName;
        [DataMember]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        #endregion

    }
}