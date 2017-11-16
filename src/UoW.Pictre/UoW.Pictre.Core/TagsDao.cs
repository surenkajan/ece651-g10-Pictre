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
    public class TagsDao
    {
        public List<Tags> GetTagsByPhotoID(int PhotoID)
        {
            try
            {
                return Db.ReadList(Db.QueryType.StoredProcedure, "[pictre].[CoreGetTagsByID]", GetTagsFromReader, "PictreMSSQLConnection",
                    new object[] { "PhotoID", PhotoID });
                //return new User() { FirstName = "User1FN", LastName = "User1LN", EmailAddress = "user1@gmail.com   ", DateOfBirth = DateTime.Now, FullName = "User1 User 1", Sex = "Male" };
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
                throw;
            }

        }

        private Tags GetTagsFromReader(IDataReader reader)
        {
            return GetTagsFromReader(reader, "AU");
        }


        /// <summary>
        /// Gets the employee from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="namePreFix">The name pre fix.</param>
        /// <returns></returns>
        public static Tags GetTagsFromReader(IDataReader reader, string namePreFix)
        {
            Tags tags = new Tags();


            //TODO : Enable the Prefix later here and Stored Procedure
            //user.FirstName = Db.GetValue(reader, namePreFix + "FirstName", "");
            //user.LastName = Db.GetValue(reader, namePreFix + "LastName", "");
            //user.FullName = Db.GetValue(reader, namePreFix + "FullName", "");
            //user.EmailAddress = Db.GetValue(reader, namePreFix + "EmailAddress", "");
            //user.DateOfBirth = Db.GetValue(reader, namePreFix + "DateOfBirth", DateTime.Now);
            //user.Sex = Db.GetValue(reader, namePreFix + "Sex", "");

            tags.FirstName = Db.GetValue(reader, "FirstName", "");


            TagsDao tagsdao = new TagsDao();
            return tags;
        }

    }
}
