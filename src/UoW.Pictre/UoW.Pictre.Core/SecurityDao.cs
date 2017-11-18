namespace UoW.Pictre.Core
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using UoW.Pictre.BusinessObjects;
    using UoW.Pictre.DataObjects.ADO.NET;
    using UoW.Pictre.PictreUtilities;

    public class SecurityDao
    {
        /// <summary>
        /// Get Security Questions.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public List<SecurityQuestion> GetSecurityQuestions()
        {
            return Db.ReadList(Db.QueryType.StoredProcedure, "[pictre].[CoreGetSecurityQuestions]",
                GetSecurityFromReader, "PictreMSSQLConnection",
                new object[] { "UserTablePreFix", "AU" });
        }

        /// <summary>
        /// <summary>
        /// Add Security Answers once the ASP.Net Auth registration completes
        /// </summary>
        /// <param name="secAns"></param>
        /// <returns></returns>
        public int AddSecurityAnswersEmailID(SecurityAnswers secAns)
        {
            if (secAns != null && secAns.UserEmailID != null && secAns.QuestionAnswer != null)
            {
                string QuestionAndAnswers = string.Join(";", secAns.QuestionAnswer.Select(x => x.Key + "=" + x.Value));
                return Db.Insert(
                    Db.QueryType.StoredProcedure,
                    "[pictre].[AddSecurityAnswersEmailID]",
                    "PictreMSSQLConnection",
                    new object[]
                    {
                        "EmailAddress", secAns.UserEmailID,
                        "QuestionAndAnswers", QuestionAndAnswers
                    });
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Gets the employee from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        private SecurityQuestion GetSecurityFromReader(IDataReader reader)
        {
            return GetUserFromReader(reader, "AU");
        }

        /// <summary>
        /// Gets the employee from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="namePreFix">The name pre fix.</param>
        /// <returns></returns>
        public static SecurityQuestion GetUserFromReader(IDataReader reader, string namePreFix)
        {
            SecurityQuestion question = new SecurityQuestion();

            //TODO : Enable the Prefix later here and Stored Procedure
            question.ID = Db.GetValue(reader, "ID", 0);
            question.Question = Db.GetValue(reader, "Question", "");

            return question;
        }
    }
}
