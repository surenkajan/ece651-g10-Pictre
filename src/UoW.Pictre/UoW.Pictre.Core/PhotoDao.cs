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
        public Photo GetPhotosByEmailID(string emailID)
        {
            try
            {
                return Db.Read(Db.QueryType.StoredProcedure, "[pictre].[CoreGetPhotoByEmailID]", GetPhotoFromReader, "PictreMSSQLConnection",
                    new object[] { "EmailAddress", emailID, "UserTablePreFix", "AU" });
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
