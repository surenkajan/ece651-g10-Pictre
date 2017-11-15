using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using UoW.Pictre.BusinessObjects;
using UoW.Pictre.DataObjects.ADO.NET;



namespace UoW.Pictre.Core
{
    public class FriendDao
    {
        public List<Friend> GetFriendByEmailID(string emailID)
        {
            try
            {
                return Db.ReadList(Db.QueryType.StoredProcedure, "[pictre].[CoreGetFriendByEmailID]", GetFriendFromReader, "PictreMSSQLConnection",
                    new object[] { "EmailAddress", emailID });
                //return new User() { FirstName = "User1FN", LastName = "User1LN", EmailAddress = "user1@gmail.com   ", DateOfBirth = DateTime.Now, FullName = "User1 User 1", Sex = "Male" };
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
                throw;
            }
        }

     

        private Friend GetFriendFromReader(IDataReader reader)
        {
            return GetFriendFromReader(reader, "AU");
        }

        /// <summary>
        /// Gets the employee from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="namePreFix">The name pre fix.</param>
        /// <returns></returns>
        public static Friend GetFriendFromReader(IDataReader reader, string namePreFix)
        {
            Friend frnd = new Friend();

            //TODO : Enable the Prefix later here and Stored Procedure
            //user.FirstName = Db.GetValue(reader, namePreFix + "FirstName", "");
            //user.LastName = Db.GetValue(reader, namePreFix + "LastName", "");
            //user.FullName = Db.GetValue(reader, namePreFix + "FullName", "");
            //user.EmailAddress = Db.GetValue(reader, namePreFix + "EmailAddress", "");
            //user.DateOfBirth = Db.GetValue(reader, namePreFix + "DateOfBirth", DateTime.Now);
            //user.Sex = Db.GetValue(reader, namePreFix + "Sex", "");

            frnd.FirstName = Db.GetValue(reader, "FirstName", "");
            frnd.LastName = Db.GetValue(reader, "LastName", "");
            frnd.EmailAddress = Db.GetValue(reader, "EmailAddress", "");

            if (!DBNull.Value.Equals(reader["ProfilePhoto"]))
            {
                byte[] imgBytes = (byte[])reader["ProfilePhoto"];
                string imgString = Convert.ToBase64String(imgBytes);
                frnd.ProfilePhoto = String.Format("data:image/jpg;base64,{1}", "jpg", imgString);
            }
            else
            {
                //Image image = Image.FromFile(@"\images\avator.png");
                //user.ProfilePhoto = Common.ImageToBase64(image);
                frnd.ProfilePhoto = null;
            }
            FriendDao frnddao = new FriendDao();
            return frnd;
        }

    }
}
