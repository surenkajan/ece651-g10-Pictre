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
        public User GetUserByLoginName(string loginName)
        {
            string receivedLoginName = loginName;
            try
            {
                string[] loginNameParts = receivedLoginName.Split(new char[] { '|' });
                if (loginNameParts.Length > 1)
                    loginName = loginNameParts[1];
                else
                    loginName = receivedLoginName;

                return Db.Read(Db.QueryType.StoredProcedure, "[vplus].[CoreGetUserByLoginName]", GetUserFromReader, "VplusMSSQLConnection",
                    new object[] { "LoginName", loginName, "UserTablePreFix", "AU" });
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
            //NamePreFix = NamePreFix + ".";
            User user = new User();
            user.DateOfBirth = Db.GetValue(reader, namePreFix + "DateOfBirth", DateTime.Now);
            user.EmailAddress = Db.GetValue(reader, namePreFix + "EmailAddress", "");
            user.FirstName = Db.GetValue(reader, namePreFix + "FirstName", "");
            user.FullName = Db.GetValue(reader, namePreFix + "FullName", "");
            user.LastName = Db.GetValue(reader, namePreFix + "LastName", "");
            user.LoginName = Db.GetValue(reader, namePreFix + "LoginName", "");
            //user.MaritalStatus = Db.GetValue(reader, namePreFix + "MaritalStatus", "");
            user.MiddleNames = Db.GetValue(reader, namePreFix + "MiddleNames", "");
            user.Sex = Db.GetValue(reader, namePreFix + "Sex", "");
            //user.Title = Db.GetValue(reader, namePreFix + "Title", "");
            UserDao userdao = new UserDao();
            //userdao.SetExternalProperties(ref user);
            return user;
        }
    }
}
