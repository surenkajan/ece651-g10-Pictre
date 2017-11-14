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
        //public Photo GetPhotosByEmailID(string emailID)
        //{
        //    try
        //    {
        //        return Db.Read(Db.QueryType.StoredProcedure, "[pictre].[CoreGetPhotoByEmailID]", GetPhotoFromReader, "PictreMSSQLConnection",
        //            new object[] { "EmailAddress", emailID, "UserTablePreFix", "AU" });
        //    }
        //    catch (Exception ex)
        //    {
        //        EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
        //        throw;
        //    }
        //}

        public List<Photo> GetCommentsByID(int photoID)
        {
            try
            {
                return Db.ReadList(Db.QueryType.StoredProcedure, "[pictre].[CoreGetCommentsByID]", GetCommentsFromReader, "PictreMSSQLConnection",
                    new object[] { "PhotoId", photoID });
                //return new User() { FirstName = "User1FN", LastName = "User1LN", EmailAddress = "user1@gmail.com   ", DateOfBirth = DateTime.Now, FullName = "User1 User 1", Sex = "Male" };
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
                throw;
            }
        }
        private Photo GetCommentsFromReader(IDataReader reader)
        {
            return GetCommentsFromReader(reader, "AU");
        }
        public static Photo GetCommentsFromReader(IDataReader reader, string namePreFix)
        {
            Photo photo = new Photo();

            //TODO : Enable the Prefix later here and Stored Procedure
            //user.FirstName = Db.GetValue(reader, namePreFix + "FirstName", "");
            //user.LastName = Db.GetValue(reader, namePreFix + "LastName", "");
            //user.FullName = Db.GetValue(reader, namePreFix + "FullName", "");
            //user.EmailAddress = Db.GetValue(reader, namePreFix + "EmailAddress", "");
            //user.DateOfBirth = Db.GetValue(reader, namePreFix + "DateOfBirth", DateTime.Now);
            //user.Sex = Db.GetValue(reader, namePreFix + "Sex", "");
            photo.Comments= Db.GetValue(reader, "Comment", "0");
            photo.FirstName = Db.GetValue(reader, "FirstName", "");
            photo.CommentsTime = Db.GetValue(reader, "CommentTime", DateTime.Now);


            PhotoDao photodao = new PhotoDao();


            
            return photo;
        }
        /// <summary>
        /// Gets the employee from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        private Photo GetPhotoFromReader(IDataReader reader)
        {
            return GetPhotoFromReader(reader, "AU");
        }

        /// <summary>
        /// Gets the Photo from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="namePreFix">The name pre fix.</param>
        /// <returns></returns>
        public static Photo GetPhotoFromReader(IDataReader reader, string namePreFix)
        {
            Photo photo = new Photo();
            
            PhotoDao userdao = new PhotoDao();
            return photo;
        }
    }
}
