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
        private int uid;
        public int Uid
        {
            get { return uid; }
            set { uid = value; }
        }
        private string Firstname;
        //[DataMember]
        public string FirstName
        {
            get { return Firstname; }
            set { Firstname = value; }
        }

        private string Lastname;
        //[DataMember]
        public string LastName
        {
            get { return Lastname; }
            set { Lastname = value; }
        }

        private string Emailaddress;
        //[DataMember]
        public string EmailAddress
        {
            get { return Emailaddress; }
            set { Emailaddress = value; }
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

