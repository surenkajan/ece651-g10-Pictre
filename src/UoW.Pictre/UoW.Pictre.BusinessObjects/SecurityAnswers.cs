using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.Pictre.BusinessObjects
{
    public class SecurityAnswers : BusinessObject
    {
        #region Database Properties

        private string userEmailId;
        /// <summary>
        /// Gets or sets the user Email Id.
        /// </summary>
        /// <value>
        /// The ID.
        /// </value>
        public string UserEmailID
        {
            get { return userEmailId; }
            set { userEmailId = value; }
        }


        private Dictionary<string, string> questionAnswer;
        /// <summary>
        /// Gets or sets the question.
        /// </summary>
        /// <value>
        /// The question.
        /// </value>
        public Dictionary<string, string> QuestionAnswer
        {
            get { return questionAnswer; }
            set { questionAnswer = value; }
        }

        #endregion
    }
}
