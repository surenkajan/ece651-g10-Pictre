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
            if (user != null && user.EmailAddress != null && user.FirstName != null && user.DateOfBirth != null && user.Sex != null)
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

        public int AddFriendByUID(FriendRequest user)
        {
            if (user != null  )
            {
                return Db.Insert(
                    Db.QueryType.StoredProcedure,
                    "[pictre].[CoreAddFriendByUID]",
                    "PictreMSSQLConnection",
                    new object[]
                {
                    "CurrentUserEmailID",user.CurrentUserEmailID,
                    "Uid",user.Uid
                });
            }
            else
            {
                return -1;
            }
        }
        




        //UpdateUserByEmailID
        /// <summary>
        /// Add New user the DB once the ASP.Net Auth registration completes
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateUserByEmailID(User user)
        {
            if (user != null && user.EmailAddress != null && user.FirstName != null && user.DateOfBirth != null && user.Sex != null)
            {
                return Db.Update(
                    Db.QueryType.StoredProcedure,
                    "[pictre].[CoreUpdateUserByEmailID]",
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


        /// <summary>
        /// Delete User By EmailID
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int DeleteUserByEmailID(string emailID)
        {
            if (emailID != null)
            {
                return Db.Delete(
                    Db.QueryType.StoredProcedure,
                    "[pictre].[CoreDeleteUserByEmailID]",
                    "PictreMSSQLConnection",
                   new object[] { "EmailAddress", emailID });
            }
            else
            {
                return -1;
            }
        }

        //

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

            user.UserName = Db.GetValue(reader, "UserName", "");
            user.FirstName = Db.GetValue(reader, "FirstName", "");
            user.LastName = Db.GetValue(reader, "LastName", "");
            user.FullName = Db.GetValue(reader, "FullName", "");
            user.EmailAddress = Db.GetValue(reader, "EmailAddress", "");
            user.DateOfBirth = Db.GetValue(reader, "DateOfBirth", DateTime.Now);
            user.Sex = Db.GetValue(reader, "Sex", "");
            if (!DBNull.Value.Equals(reader["ProfilePhoto"]))
            {
                byte[] imgBytes = (byte[])reader["ProfilePhoto"];
                string imgString = Convert.ToBase64String(imgBytes);
                user.ProfilePhoto = String.Format("data:image/jpg;base64,{1}", "jpg", imgString);
            }
            else
            {
                //Image image = Image.FromFile(@"\images\avator.png");
                //user.ProfilePhoto = Common.ImageToBase64(image);
                user.ProfilePhoto = null;
            }
            UserDao userdao = new UserDao();
            return user;
        }
    }
}
