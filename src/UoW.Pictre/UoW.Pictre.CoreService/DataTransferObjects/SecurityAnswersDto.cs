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
    public class SecurityAnswersDto
    {
        #region Database Properties

        private string userEmailId;
        [DataMember]
        public string UserEmailID
        {
            get { return userEmailId; }
            set { userEmailId = value; }
        }


        private Dictionary<string, string> questionAnswer;
        [DataMember]
        public Dictionary<string, string> QuestionAnswer
        {
            get { return questionAnswer; }
            set { questionAnswer = value; }
        }

        #endregion
    }
}
