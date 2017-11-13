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
    public class LikesDto
    {
        #region Database Properties
        private string Firstname;
        [DataMember]
        public string FirstName
        {
            get { return Firstname; }
            set { Firstname = value; }
        }
        #endregion
    }
}
