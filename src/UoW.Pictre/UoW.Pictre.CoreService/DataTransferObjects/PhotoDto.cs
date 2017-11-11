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
        private string name;
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
