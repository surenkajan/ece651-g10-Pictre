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
    public class PhotoDao
    {
        /// <summary>
        /// Gets the Deatils of the Photo by Email ID.
        /// </summary>
        /// <param name="loginName">Name of the login.</param>
        /// <returns></returns>
        public List<Photo> GetFriendPhotosByEmailID(string emailID)
        {
            try
            {
                return Db.ReadList(Db.QueryType.StoredProcedure, "[pictre].[CoreGetFriendPhotosByEmailID]", GetPhotosFromReader, "PictreMSSQLConnection",
                    new object[] { "EmailAddress", emailID});
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
                throw;
            }
        }

        public List<Photo> GetPhotosByEmailID(string emailID)
        {
            try
            {
                return Db.ReadList(Db.QueryType.StoredProcedure, "[pictre].[CoreGetPhotosByEmailID]", GetMyPhotosFromReader, "PictreMSSQLConnection",
                    new object[] { "EmailAddress", emailID });
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
                throw;
            }
        }

        //public List<Photo> GetCommentsByID(int photoID)
        //{
        //    try
        //    {
        //        return Db.ReadList(Db.QueryType.StoredProcedure, "[pictre].[CoreGetCommentsByID]", GetCommentsFromReader, "PictreMSSQLConnection",
        //            new object[] { "PhotoId", photoID });
        //        //return new User() { FirstName = "User1FN", LastName = "User1LN", EmailAddress = "user1@gmail.com   ", DateOfBirth = DateTime.Now, FullName = "User1 User 1", Sex = "Male" };
        //    }
        //    catch (Exception ex)
        //    {
        //        EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
        //        throw;
        //    }
        //}

        //private Photo GetCommentsFromReader(IDataReader reader)
        //{
        //    return GetCommentsFromReader(reader, "AU");
        //}

        //public static Photo GetCommentsFromReader(IDataReader reader, string namePreFix)
        //{
        //    Photo photo = new Photo();

        //    //TODO : Enable the Prefix later here and Stored Procedure
        //    //user.FirstName = Db.GetValue(reader, namePreFix + "FirstName", "");
        //    //user.LastName = Db.GetValue(reader, namePreFix + "LastName", "");
        //    //user.FullName = Db.GetValue(reader, namePreFix + "FullName", "");
        //    //user.EmailAddress = Db.GetValue(reader, namePreFix + "EmailAddress", "");
        //    //user.DateOfBirth = Db.GetValue(reader, namePreFix + "DateOfBirth", DateTime.Now);
        //    //user.Sex = Db.GetValue(reader, namePreFix + "Sex", "");
        //    photo.Comments= Db.GetValue(reader, "Comment", "0");
        //    photo.FirstName = Db.GetValue(reader, "FirstName", "");
        //    photo.CommentsTime = Db.GetValue(reader, "CommentTime", DateTime.Now);


        //    PhotoDao photodao = new PhotoDao();            
        //    return photo;
        //}

        private Photo GetMyPhotosFromReader(IDataReader reader)
        {
            return GetMyPhotosFromReader(reader, "AU");
        }
        public static Photo GetMyPhotosFromReader(IDataReader reader, string namePreFix)
        {
            Photo photo = new Photo();
            photo.FirstName = Db.GetValue(reader, "FirstName", "");
            //photo.LastName = Db.GetValue(reader, "LastName", "");
            //photo.EmailAddress = Db.GetValue(reader, "EmailAddress", "");
            photo.PhotoDescription = Db.GetValue(reader, "PhotoDescription", "");
            photo.UploadTimeStamp = Db.GetValue(reader, "UploadTimeStamp", DateTime.Now);
            //photo.EmailAddress = Db.GetValue(reader, "EmailAddress", "");
            photo.Location=Db.GetValue(reader, "CheckinLocation", "");
            photo.Tags = Db.GetValue(reader, "Tags", "");
            //if (!DBNull.Value.Equals(reader["ProfilePhoto"]))
            //{
            //    byte[] imgBytes = (byte[])reader["ProfilePhoto"];
            //    string imgString = Convert.ToBase64String(imgBytes);
            //    photo.ProfilePhoto = String.Format("data:image/jpg;base64,{1}", "jpg", imgString);
            //}
            //else
            //{
            //    //Image image = Image.FromFile(@"\images\avator.png");
            //    //user.ProfilePhoto = Common.ImageToBase64(image);
            //    photo.ProfilePhoto = null;
            //}

            if (!DBNull.Value.Equals(reader["ActualPhoto"]))
            {
                byte[] imgBytes = (byte[])reader["ActualPhoto"];
                string imgString = Convert.ToBase64String(imgBytes);
                photo.ActualPhoto = String.Format("data:image/jpg;base64,{1}", "jpg", imgString);
            }
            else
            {
                //Image image = Image.FromFile(@"\images\avator.png");
                //user.ProfilePhoto = Common.ImageToBase64(image);
                photo.ActualPhoto = null;
            }
            return photo;
        }
        //public int AddCommentsByEmailID(Photo photo)
        //{
        //    if (photo != null)
        //    {
        //        return Db.Insert(
        //            Db.QueryType.StoredProcedure,
        //            "[pictre].[CoreAddCommentsByEmailID]",
        //            "PictreMSSQLConnection",
        //            new object[]
        //        {
        //            "PhotoId", photo.PhotoID,
        //            "currentUserEmailID", photo.EmailAddress,
        //            "Comment", photo.Comments ,
        //            "CommetsTime", photo.CommentsTime
        //            //"CheckinLocation", photo.CheckinLocation
        //        });
        //    }
        //    else
        //    {
        //        return -1;
        //    }
        //}

        /// <summary>
        /// Gets the employee from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        private Photo GetPhotosFromReader(IDataReader reader)
        {
            return GetPhotosFromReader(reader, "AU");
        }

        /// <summary>
        /// Gets the Photo from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="namePreFix">The name pre fix.</param>
        /// <returns></returns>
        public static Photo GetPhotosFromReader(IDataReader reader, string namePreFix)
        {
            Photo photo = new Photo();
            photo.UserID = Db.GetValue(reader, "UserId", 0);
            photo.FirstName = Db.GetValue(reader, "FirstName", "");
            photo.LastName = Db.GetValue(reader, "LastName", "");
            photo.EmailAddress = Db.GetValue(reader, "EmailAddress", "");
            photo.PhotoDescription = Db.GetValue(reader, "PhotoDescription", "");
            photo.UploadTimeStamp = Db.GetValue(reader, "UploadTimeStamp", DateTime.Now);
            photo.EmailAddress = Db.GetValue(reader, "EmailAddress", "");
            photo.Tags = Db.GetValue(reader, "Tags", "");
            photo.Location = Db.GetValue(reader, "CheckinLocation", "");
            photo.PhotoID = Db.GetValue(reader,"PhotoID", 0);
            if (!DBNull.Value.Equals(reader["ProfilePhoto"]))
            {
                byte[] imgBytes = (byte[])reader["ProfilePhoto"];
                string imgString = Convert.ToBase64String(imgBytes);
                photo.ProfilePhoto = String.Format("data:image/jpg;base64,{1}", "jpg", imgString);
            }
            else
            {
                //Image image = Image.FromFile(@"\images\avator.png");
                //user.ProfilePhoto = Common.ImageToBase64(image);
                photo.ProfilePhoto = null;
            }

            if (!DBNull.Value.Equals(reader["ActualPhoto"]))
            {
                byte[] imgBytes = (byte[])reader["ActualPhoto"];
                string imgString = Convert.ToBase64String(imgBytes);
                photo.ActualPhoto = String.Format("data:image/jpg;base64,{1}", "jpg", imgString);
            }
            else
            {
                //Image image = Image.FromFile(@"\images\avator.png");
                //user.ProfilePhoto = Common.ImageToBase64(image);
                photo.ActualPhoto = null;
            }

            PhotoDao userdao = new PhotoDao();
            return photo;
        }
    }
}
