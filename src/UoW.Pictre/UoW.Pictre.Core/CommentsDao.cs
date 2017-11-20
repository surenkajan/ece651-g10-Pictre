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
   public  class CommentsDao
    {

        public List<Comments> GetCommentsByID(int photoID)
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

        private Comments GetCommentsFromReader(IDataReader reader)
        {
            return GetCommentsFromReader(reader, "AU");
        }

        public static Comments GetCommentsFromReader(IDataReader reader, string namePreFix)
        {
            Comments comment = new Comments();

            //TODO : Enable the Prefix later here and Stored Procedure
            //user.FirstName = Db.GetValue(reader, namePreFix + "FirstName", "");
            //user.LastName = Db.GetValue(reader, namePreFix + "LastName", "");
            //user.FullName = Db.GetValue(reader, namePreFix + "FullName", "");
            //user.EmailAddress = Db.GetValue(reader, namePreFix + "EmailAddress", "");
            //user.DateOfBirth = Db.GetValue(reader, namePreFix + "DateOfBirth", DateTime.Now);
            //user.Sex = Db.GetValue(reader, namePreFix + "Sex", "");
            comment.Comment = Db.GetValue(reader, "Comment", "0");
            comment.FirstName = Db.GetValue(reader, "FirstName", "");
            comment.CommentsTime = Db.GetValue(reader, "CommentTime", DateTime.Now);
            comment.LastName = Db.GetValue(reader, "LastName", "");
            comment.FullName = Db.GetValue(reader, "FullName", "");
            comment.UserID = Db.GetValue(reader, "UserID", 0);
            comment.PhotoID = Db.GetValue(reader, "PhotoID", 0);

            CommentsDao commentdao = new CommentsDao();
            return comment;
        }

        public int AddCommentsByEmailID(Comments comment)
        {
            if (comment != null)
            {
                return Db.Insert(
                    Db.QueryType.StoredProcedure,
                    "[pictre].[CoreAddCommentsByEmailID]",
                    "PictreMSSQLConnection",
                    new object[]
                {
                    "PhotoId", comment.PhotoID,
                    "currentUserEmailID", comment.EmailAddress,
                    "Comment", comment.Comment ,
                    "CommentsTime", comment.CommentsTime
                    //"CheckinLocation", photo.CheckinLocation
                });
            }
            else
            {
                return -1;
            }
        }

    }
}
