using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Script.Serialization;
using UoW.Pictre.ServiceUtils;

namespace UoW.Pictre.Web.WebForms
{
    public sealed class PictreBDelegate
    {
        private static readonly object padlock = new object();
        private static PictreBDelegate instance = null;
        string Service_BaseAddress;
        string json_type;

        private PictreBDelegate()
        {
            Service_BaseAddress = ConfigurationManager.AppSettings["PictreServicesBaseAddress"];
            json_type = "application/json;charset=utf-8";
        }

        //Thread Safety Singleton using Double Check Locking
        public static PictreBDelegate Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new PictreBDelegate();
                        }
                    }
                }
                return instance;
            }
        }

        public object CurrentUserEmailID { get; private set; }
        public object Uid { get; private set; }

        public UserDto GetUserByEmailID(string EmailID)
        {
            UserDto user = null;
            //TODO : Do not hard code the method name here, Move to App.Settings
            //Get the User
            string usr = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/userRest/GetUserByEmailID?Email=" + EmailID, "GET", json_type, null);

            //How to Consume this in Pictre Front End: Deserialize the object(s)
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            if (usr != null)
            {
                user = json_serializer.Deserialize<UserDto>(usr);
            }
            return user;
        }

        public UserDto GetUserByUid(int uid)
        {
            UserDto user = null;
            //TODO : Do not hard code the method name here, Move to App.Settings
            //Get the User
            string usr = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/userRest/GetUserByUid?Uid=" + uid, "GET", json_type, null);

            //How to Consume this in Pictre Front End: Deserialize the object(s)
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            if (usr != null)
            {
                user = json_serializer.Deserialize<UserDto>(usr);
            }
            return user;
        }


        public List<UserDto> GetAllUsers()
        {
            List<UserDto> usrList = null;
            //TODO : Do not hard code the method name here, Move to App.Settings
            string Json_usrList = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/userRest/GetAllUsers", "GET", json_type, null);
            JavaScriptSerializer json_list_serializer = new JavaScriptSerializer();

            if (Json_usrList != null)
            {
                usrList = json_list_serializer.Deserialize<List<UserDto>>(Json_usrList);
            }
            return usrList;
        }

        public int InsertUser(UserDto newUser)
        {
            int status = -1;

            if (newUser != null)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string userjson = js.Serialize(newUser);

                //Add New user
                string val = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/userRest/AddUserByEmailID", "POST", json_type, userjson);
                status = val != null ? Int32.Parse(val) : -1;
            }
            return status;
        }

        public int InsertFriend(FriendRequestDto friendRequestDto)
        {
            int status = -1;

            if (friendRequestDto != null)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string userjson = js.Serialize(friendRequestDto);

                //Add New user
                string val = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/userRest/AddFriendByUID", "POST", json_type, userjson);
                status = val != null ? Int32.Parse(val) : -1;
            }
            return status;
        }

        public int UpdateUser(UserDto user)
        {
            int status = -1;
            if (user != null)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string userjson = js.Serialize(user);

                //Update existing user
                string val = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/userRest/UpdateUserByEmailID", "PUT", json_type, userjson);
                status = val != null ? Int32.Parse(val) : -1;
            }
            return status;
        }

        public int DeleteUserByEmailID(string EmailID)
        {
            //DELETE the User
            string val = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/userRest/DeleteUserByEmailID?Email=" + EmailID, "DELETE", json_type, null);
            int status = val != null ? Int32.Parse(val) : -1;
            return status;
        }
        public List<FriendDto> GetFriendByEmailID(string EmailID)
        {
            //TODO : Do not hard code the method name here, Move to App.Settings
            string Json_usrList = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/friendrest/GetFriendByEmailID?Email=" + EmailID, "GET", json_type, null);
            JavaScriptSerializer json_list_serializer = new JavaScriptSerializer();
            List<FriendDto> usrList = null;

            if (Json_usrList != null)
            {
                 usrList = json_list_serializer.Deserialize<List<FriendDto>>(Json_usrList);
            }

            return usrList;
        }
        public List<CommentDto> GetCommentsByID(int photoID)
        {
            //TODO : Do not hard code the method name here, Move to App.Settings
            string Json_usrList = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "PhotoRest/GetCommentsByID?PhotoId=" + photoID, "GET", json_type, null);
            JavaScriptSerializer json_list_serializer = new JavaScriptSerializer();
            List<CommentDto> commentList = null;

            if (Json_usrList != null)
            {
                commentList = json_list_serializer.Deserialize<List<CommentDto>>(Json_usrList);
            }

            return commentList;
        }

        #region SecurityQuestions

        public List<SecurityQuestionDto> GetSecurityQuestions()
        {
            List<SecurityQuestionDto> questions = null;

            string Json_usrList = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/securityRest/GetSecurityQuestions", "GET", json_type, null);
            JavaScriptSerializer json_ques_serializer = new JavaScriptSerializer();

            if (Json_usrList != null)
            {
                questions = json_ques_serializer.Deserialize<List<SecurityQuestionDto>>(Json_usrList);
            }
            return questions;
        }

        public int InsertSecurityAnswers(SecurityAnswersDto Answers)
        {
            int status = -1;

            if (Answers != null)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string ansjson = js.Serialize(Answers);

                //Add New user
                string val = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/securityRest/AddSecurityAnswersEmailID", "POST", json_type, ansjson);
                status = val != null ? Int32.Parse(val) : -1;
            }
            return status;
        }

        #endregion

    }

    #region All Dto
    //TODO : handle this differently
    [Serializable]
    [DataContract]
    public class UserDto
    {
        #region Database Properties
        private int uid;
        [DataMember]
        public int Uid
        {
            get { return uid; }
            set { uid = value; }
        }
        private string userName;
        [DataMember]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string lastName;
        [DataMember]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private DateTime? dateOfBirth;
        [DataMember]
        public DateTime? DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        private string emailAddress;
        [DataMember]
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        private string firstName;
        [DataMember]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string fullName;
        [DataMember]
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        private string sex;
        [DataMember]
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
       

        #endregion

        #region External Properties
        private string profilePhoto;
        [DataMember]
        public string ProfilePhoto
        {
            get { return profilePhoto; }
            set { profilePhoto = value; }
        }
        #endregion
    }

    [Serializable]
    [DataContract]
    public class FriendDto
    {
        private string Firstname;
        [DataMember]
        public string FirstName
        {
            get { return Firstname; }
            set { Firstname = value; }
        }

        private int uid;
        [DataMember]
        public int Uid
        {
            get { return uid; }
            set { uid = value; }
        }
        private string Lastname;
        [DataMember]
        public string LastName
        {
            get { return Lastname; }
            set { Lastname = value; }
        }

        private string Emailaddress;
        [DataMember]
        public string EmailAddress
        {
            get { return Emailaddress; }
            set { Emailaddress = value; }
        }

        private string Profilephoto;
        [DataMember]
        public string ProfilePhoto
        {
            get { return Profilephoto; }
            set { Profilephoto = value; }
        }
    }

    [Serializable]
    [DataContract]
    public class FriendRequestDto
    {
        private int UID;
        [DataMember]
        public int Uid
        {
            get { return UID; }
            set { UID = value; }
        }

        private string currentUserEmailID;
        [DataMember]
        public string CurrentUserEmailID
        {
            get { return currentUserEmailID; }
            set { currentUserEmailID = value; }
        }

    }

    [Serializable]
    [DataContract]
    public class SecurityQuestionDto
    {
        #region Database Properties

        private int id;
        [DataMember]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }


        private string question;
        [DataMember]
        public string Question
        {
            get { return question; }
            set { question = value; }
        }

        #endregion
    }

    [Serializable]
    [DataContract]
    public class SecurityAnswersDto
    {
        #region Database Properties

        private string userEmailId;
        [DataMember]
        public string UserEmailID
        {
            get { return userEmailId; }
            set { userEmailId = value; }
        }


        private Dictionary<string, string> questionAnswer;
        [DataMember]
        public Dictionary<string, string> QuestionAnswer
        {
            get { return questionAnswer; }
            set { questionAnswer = value; }
        }

        #endregion
    }


    public class CommentDto
    {
        #region Database properties
        private int userID;
        [DataMember]
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private String Firstname;
        [DataMember]
        public string FirstName
        {
            get { return Firstname; }
            set { Firstname = value; }
        }
        private String emailAddress;
        [DataMember]
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        private DateTime? uploadTimeStamp;
        [DataMember]
        public DateTime? UploadTimeStamp
        {
            get { return uploadTimeStamp; }
            set { uploadTimeStamp = value; }
        }

        private String comments;
        [DataMember]
        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        private int photoID;
        [DataMember]
        public int PhotoID
        {
            get { return photoID; }
            set { photoID = value; }
        }
        #endregion
    }
    
    #endregion
}