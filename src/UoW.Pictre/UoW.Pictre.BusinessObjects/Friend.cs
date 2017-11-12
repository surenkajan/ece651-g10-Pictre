using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoW.Pictre.BusinessObjects
{
    public class Friend : BusinessObject
    {
        #region Database Properties
        private string Firstname;
        //[DataMember]
        public string FirstName
        {
            get { return Firstname; }
            set { Firstname = value; }
        }
        private string Profilephoto;
        //[DataMember]
        public string ProfilePhoto
        {
            get { return Profilephoto; }
            set { Profilephoto = value; }
        }
        #endregion
    }

}

