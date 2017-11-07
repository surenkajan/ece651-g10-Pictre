namespace UoW.Pictre.Core
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Text;
    using UoW.Pictre.BusinessObjects;
    using UoW.Pictre.DataObjects.ADO.NET;

    public class UserDao
    {
        /// <summary>
        /// Gets the name of the user by login.
        /// </summary>
        /// <param name="loginName">Name of the login.</param>
        /// <returns></returns>
        public User GetUserByEmailID(string emailID)
        {
            string receivedLoginName = emailID;
            try
            {
                //return Db.Read(Db.QueryType.StoredProcedure, "[pictre].[CoreGetUserByLoginName]", GetUserFromReader, "PictreMSSQLConnection",
                //    new object[] { "LoginName", emailID, "UserTablePreFix", "AU" });
                return new User() { FirstName = "User1FN", LastName = "User1LN", EmailAddress = "user1@gmail.com   ", DateOfBirth = DateTime.Now, FullName = "User1 User 1", Sex = "Male" };
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Gets the employee from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        private User GetUserFromReader(IDataReader reader)
        {
            return GetUserFromReader(reader, "AU");
        }

        /// <summary>
        /// Gets the employee from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="namePreFix">The name pre fix.</param>
        /// <returns></returns>
        public static User GetUserFromReader(IDataReader reader, string namePreFix)
        {
            User user = new User();
            user.DateOfBirth = Db.GetValue(reader, namePreFix + "DateOfBirth", DateTime.Now);
            user.EmailAddress = Db.GetValue(reader, namePreFix + "EmailAddress", "");
            user.FirstName = Db.GetValue(reader, namePreFix + "FirstName", "");
            user.FullName = Db.GetValue(reader, namePreFix + "FullName", "");
            user.LastName = Db.GetValue(reader, namePreFix + "LastName", "");
            user.MiddleNames = Db.GetValue(reader, namePreFix + "MiddleNames", "");
            user.Sex = Db.GetValue(reader, namePreFix + "Sex", "");
            UserDao userdao = new UserDao();
            return user;
        }
    }
}
