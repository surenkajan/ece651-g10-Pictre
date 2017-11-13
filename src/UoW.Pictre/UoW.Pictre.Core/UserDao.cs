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
        /// Gets the Deatils of the user by Email ID.
        /// </summary>
        /// <param name="loginName">Name of the login.</param>
        /// <returns></returns>
        public User GetUserByEmailID(string emailID)
        {
            try
            {
                return Db.Read(Db.QueryType.StoredProcedure, "[pictre].[CoreGetUserByEmailID]", GetUserFromReader, "PictreMSSQLConnection",
                    new object[] { "EmailAddress", emailID, "UserTablePreFix", "AU" });
                //return new User() { FirstName = "User1FN", LastName = "User1LN", EmailAddress = "user1@gmail.com   ", DateOfBirth = DateTime.Now, FullName = "User1 User 1", Sex = "Male" };
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Add New user the DB once the ASP.Net Auth registration completes
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddNewUserByEmailID(User user)
        {
            if(user != null && user.EmailAddress != null && user.FirstName != null && user.DateOfBirth != null && user.Sex != null)
            {
                return Db.Insert(
                    Db.QueryType.StoredProcedure,
                    "[pictre].[CoreAddUserByEmailID]",
                    "PictreMSSQLConnection",
                    new object[]
                {
                    "UserName", user.UserName,
                    "FirstName", user.FirstName,
                    "LastName", user.LastName,
                    "FullName", user.FullName,
                    "EmailAddress", user.EmailAddress,
                    "DateOfBirth", user.DateOfBirth,
                    "Sex", user.Sex
                });
            }
            else
            {
                return -1;
            }
        }

        public List<User> GetAllUsers()
        {
            return Db.ReadList(Db.QueryType.StoredProcedure, "[pictre].[CoreAllUsers]",
                GetUserFromReader, "PictreMSSQLConnection",
                new object[] { "UserTablePreFix", "AU" });
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

            //TODO : Enable the Prefix later here and Stored Procedure
            //user.FirstName = Db.GetValue(reader, namePreFix + "FirstName", "");
            //user.LastName = Db.GetValue(reader, namePreFix + "LastName", "");
            //user.FullName = Db.GetValue(reader, namePreFix + "FullName", "");
            //user.EmailAddress = Db.GetValue(reader, namePreFix + "EmailAddress", "");
            //user.DateOfBirth = Db.GetValue(reader, namePreFix + "DateOfBirth", DateTime.Now);
            //user.Sex = Db.GetValue(reader, namePreFix + "Sex", "");

            user.FirstName = Db.GetValue(reader, "FirstName", "");
            user.LastName = Db.GetValue(reader, "LastName", "");
            user.FullName = Db.GetValue(reader, "FullName", "");
            user.EmailAddress = Db.GetValue(reader, "EmailAddress", "");
            user.DateOfBirth = Db.GetValue(reader, "DateOfBirth", DateTime.Now);
            user.Sex = Db.GetValue(reader, "Sex", "");

            UserDao userdao = new UserDao();
            return user;
        }
    }
}
