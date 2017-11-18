namespace UoW.Pictre.Core
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
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
