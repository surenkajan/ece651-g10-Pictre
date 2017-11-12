using System;
using System.Data;
using System.Diagnostics;
using UoW.Pictre.BusinessObjects;
using UoW.Pictre.DataObjects.ADO.NET;

public class FriendsDao
{
    /// <summary>
    /// Gets the Details of the friends by ID.
    /// </summary>
    /// <param name="loginName">Name of the login.</param>
    /// <returns></returns>
    public Friend GetFriendsByID(int ID)
    {
        try
        {
            return UoW.Pictre.DataObjects.ADO.NET.Db.Read(Db.QueryType.StoredProcedure, "[pictre].[CoreGetFriendsByID]", GetFriendFromReader, "PictreMSSQLConnection",
                new object[] { "ID", ID });
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
        Friend friend = new Friend();

        //TODO : Enable the Prefix later here and Stored Procedure
        //user.FirstName = Db.GetValue(reader, namePreFix + "FirstName", "");
        //user.LastName = Db.GetValue(reader, namePreFix + "LastName", "");
        //user.FullName = Db.GetValue(reader, namePreFix + "FullName", "");
        //user.EmailAddress = Db.GetValue(reader, namePreFix + "EmailAddress", "");
        //user.DateOfBirth = Db.GetValue(reader, namePreFix + "DateOfBirth", DateTime.Now);
        //user.Sex = Db.GetValue(reader, namePreFix + "Sex", "");

        friend.ID = Db.GetValue(reader, "ID", 0);
        friend.FriendID = Db.GetValue(reader, "FriendID", 0);

        FriendsDao frienddao = new FriendsDao();
        return friend;
    }
}

