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

        
        ///// <summary>
        ///// Get Security Questions.
        ///// </summary>
        ///// <param></param>
        ///// <returns></returns>
        //public List<SecurityAnswers> GetSecurityAnswersListsByEmailID(string EmailID)
        //{
        //    return Db.ReadList(Db.QueryType.StoredProcedure, "[pictre].[GetSecurityAnswersByEmailID]",
        //        GetSecurityAnswerFromReader, "PictreMSSQLConnection",
        //        new object[] { "EmailAddress", EmailID });
        //}

        /// <summary>
        /// Get Security Questions.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public SecurityAnswers GetSecurityAnswersByEmailID(string EmailID)
        {
            //return Db.Read(Db.QueryType.StoredProcedure, "[pictre].[GetSecurityAnswersByEmailID]",
            //    GetSecurityAnswerFromReader, "PictreMSSQLConnection",
            //    new object[] { "EmailAddress", EmailID });
            return null;
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
        /// Gets the SecurityQuestion from reader.
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

        /// <summary>
        /// Gets the employee from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        private SecurityAnswers GetSecurityAnswerFromReader(IDataReader reader)
        {
            return GetSecurityAnswerFromReader(reader, "AU");
        }

        /// <summary>
        /// Gets the employee from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="namePreFix">The name pre fix.</param>
        /// <returns></returns>
        public static SecurityAnswers GetSecurityAnswerFromReader(IDataReader reader, string namePreFix)
        {
            SecurityAnswers answer = new SecurityAnswers();

            //TODO : Enable the Prefix later here and Stored Procedure
            answer.UserEmailID = Db.GetValue(reader, "EmailAddress", "");
            //answer.QuestionAnswer = Db.GetValue(reader, "Question", "");

            return answer;
        }
    }
}
