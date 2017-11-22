using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoW.Pictre.BusinessObjects;
using UoW.Pictre.DataObjects.ADO.NET;



namespace UoW.Pictre.Core
{
    public class LikesDao
    {
        public List<Likes> GetLikesByPhotoID(int PhotoID)
        {
            try
            {
                return Db.ReadList(Db.QueryType.StoredProcedure, "[pictre].[CoreGetLikesByID]", GetLikesFromReader, "PictreMSSQLConnection",
                    new object[] { "PhotoID", PhotoID });
                //return new User() { FirstName = "User1FN", LastName = "User1LN", EmailAddress = "user1@gmail.com   ", DateOfBirth = DateTime.Now, FullName = "User1 User 1", Sex = "Male" };
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
                throw;
            }
        }



        private Likes GetLikesFromReader(IDataReader reader)
        {
            return GetLikesFromReader(reader, "AU");
        }

        /// <summary>
        /// Gets the employee from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="namePreFix">The name pre fix.</param>
        /// <returns></returns>
        public static Likes GetLikesFromReader(IDataReader reader, string namePreFix)
        {
            Likes likes = new Likes();

            //TODO : Enable the Prefix later here and Stored Procedure
            //user.FirstName = Db.GetValue(reader, namePreFix + "FirstName", "");
            //user.LastName = Db.GetValue(reader, namePreFix + "LastName", "");
            //user.FullName = Db.GetValue(reader, namePreFix + "FullName", "");
            //user.EmailAddress = Db.GetValue(reader, namePreFix + "EmailAddress", "");
            //user.DateOfBirth = Db.GetValue(reader, namePreFix + "DateOfBirth", DateTime.Now);
            //user.Sex = Db.GetValue(reader, namePreFix + "Sex", "");

            likes.FirstName = Db.GetValue(reader, "FirstName", "");
            likes.FullName = Db.GetValue(reader, "FullName", "");
            likes.LastName = Db.GetValue(reader, "LastName", "");
            likes.UserID = Db.GetValue(reader, "ID", 0);
            if (!DBNull.Value.Equals(reader["ProfilePhoto"]))
            {
                byte[] imgBytes = (byte[])reader["ProfilePhoto"];
                string imgString = Convert.ToBase64String(imgBytes);
                likes.ProfilePhoto = String.Format("data:image/jpg;base64,{1}", "jpg", imgString);
            }
            else
            {
                //Image image = Image.FromFile(@"\images\avator.png");
                //user.ProfilePhoto = Common.ImageToBase64(image);
                likes.ProfilePhoto = null;
            }



            LikesDao likesdao = new LikesDao();
            return likes;
        }

        public int AddNewLikesByFriendID(Photo photo)
        {
            if (photo != null && photo.EmailAddress != null )
            {
                return Db.Insert(
                    Db.QueryType.StoredProcedure,
                    "[pictre].[CoreAddLikesByUID]",
                    "PictreMSSQLConnection",
                    new object[]
                {
                    "currentUserEmailID", photo.EmailAddress,
                    "PhotoID", photo.PhotoID
                    
                });
            }
            else
            {
                return -1;
            }
        }

    }
}


