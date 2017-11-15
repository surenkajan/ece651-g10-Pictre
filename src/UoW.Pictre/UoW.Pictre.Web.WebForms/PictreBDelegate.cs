using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UoW.Pictre.Web.WebForms
{
    //Thread Safety Singleton using Double Check Locking
    public sealed class PictreBDelegate
    {
        private static readonly object padlock = new object();
        private static PictreBDelegate instance = null;
        private PictreBDelegate()
        {

        }
        
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
}