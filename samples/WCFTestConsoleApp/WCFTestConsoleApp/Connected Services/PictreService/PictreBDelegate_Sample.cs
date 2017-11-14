using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using UoW.Pictre.ServiceUtils;

namespace UoW.Pictre.Web.WebForms
{
    public class PictreBDelegate
    {
        static void HttpRequest()
        {
            string Service_BaseAddress = "http://localhost:1893/Service.svc/userRest";
            string json_type = "application/json;charset=utf-8";

            UserDto user = new UserDto();

            user.UserName = "FooBoo";
            user.FirstName = "Foo";
            user.LastName = "Boo";
            user.FullName = "Foo Boo";
            user.EmailAddress = "fooboo@gmail.com";
            user.DateOfBirth = DateTime.Now;
            user.Sex = "Male";

            //string userjson = JsonConvert.SerializeObject(user);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string userjson = js.Serialize(user);

            //Add New user
            string val = RestClient.MakeHttpRequest(Service_BaseAddress + "/AddUserByEmailID", "POST", json_type, userjson);
            
            //Get the User
            string usr = RestClient.MakeHttpRequest(Service_BaseAddress + "/GetUserByEmailID?Email=" + user.EmailAddress, "GET", json_type, null);
            
            //How to Consume this in Pictre Front End: Deserialize the object(s)
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            UserDto usrdto = json_serializer.Deserialize<UserDto>(usr);

            // Deserialize JSON data into list of Vehicles.
            //List<UserDto> finalResult = json_serializer.Deserialize<List<UserDto>>(jsonData);
            
            //Update the user
            user.UserName = "FooBoo2";
            user.LastName = "Boo2";
            userjson = js.Serialize(user);
            val = RestClient.MakeHttpRequest(Service_BaseAddress + "/UpdateUserByEmailID", "PUT", json_type, userjson);
            

            //DELETE the User
            val = RestClient.MakeHttpRequest(Service_BaseAddress + "/DeleteUserByEmailID?Email=" + user.EmailAddress, "DELETE", json_type, null);
            
         
        }

    }

    [Serializable]
    public class UserDto
    {
        #region Database Properties

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private DateTime? dateOfBirth;
        public DateTime? DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        private string emailAddress;
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        private string sex;
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        #endregion
        #region External Properties
        private string profilePhoto;
        public string ProfilePhoto
        {
            get { return profilePhoto; }
            set { profilePhoto = value; }
        }
        #endregion
    }

}
