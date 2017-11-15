using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;

namespace WCFTestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //SoapClient();

            HttpRequest();

            //AddUserWebRequest();

            //TestPostrequest();
        }

        static void SoapClient()
        {
            PictreService.UserServiceClient proxy = new PictreService.UserServiceClient();
            PictreService.UserDto newUser = new PictreService.UserDto() {
                FirstName = "Kajaruban3",
                LastName = "Surendran3",
                FullName = "Kajaruban3 Surendran3",
                EmailAddress = "surenkajan3@gmail.com",
                DateOfBirth = DateTime.Now,
                Sex = "Male" };
            int val = proxy.AddUserByEmailID(newUser);
            Console.WriteLine("Status: " + val);
            Console.ReadLine();
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
            string val = MakeHttpRequest(Service_BaseAddress + "/AddUserByEmailID", "POST", json_type, userjson);
            Console.WriteLine("POST(Add) Status: " + val);

            //Get the User
            string usr = MakeHttpRequest(Service_BaseAddress + "/GetUserByEmailID?Email=" + user.EmailAddress, "GET", json_type, null);
            Console.WriteLine("GET Status: " + usr);

            //How to Consume this in Pictre Front End: Deserialize the object(s)
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            UserDto usrdto = json_serializer.Deserialize<UserDto>(usr);

            // Deserialize JSON data into list of Vehicles.
            //List<UserDto> finalResult = json_serializer.Deserialize<List<UserDto>>(jsonData);
            ShowUser(usrdto);

            //Get the list of  User
            string usrList = MakeHttpRequest(Service_BaseAddress + "/GetAllUsers", "GET", json_type, null);
            Console.WriteLine("GET Status: " + usrList);
            JavaScriptSerializer json_list_serializer = new JavaScriptSerializer();
            List<UserDto> usrListdto = json_serializer.Deserialize<List<UserDto>>(usrList);


            // Deserialize JSON data into list of Vehicles.
            //List<UserDto> finalResult = json_serializer.Deserialize<List<UserDto>>(jsonData);
            ShowUserList(usrListdto);

            //Update the user
            user.UserName = "FooBoo2";
            user.LastName = "Boo2";
            userjson = js.Serialize(user);
            val = MakeHttpRequest(Service_BaseAddress + "/UpdateUserByEmailID", "PUT", json_type, userjson);
            Console.WriteLine("PUT(Update) Status: " + val);


            //DELETE the User
            val = MakeHttpRequest(Service_BaseAddress + "/DeleteUserByEmailID?Email=" + user.EmailAddress, "DELETE", json_type, null);
            Console.WriteLine("DELETE Status: " + val);

            Console.ReadLine();
        }

        //USE this to consume the service in your Pictre Presentation Tier
        public static string MakeHttpRequest(string endPoint, string method, string contentType, string data)
        {
            string responseBody = null;

            if (!(method.ToUpper().Equals("GET") || method.ToUpper().Equals("POST")
                || method.ToUpper().Equals("PUT") || method.ToUpper().Equals("DELETE")))
            {
                return null;
            }


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            
            request.Method = method.ToUpper();

            if (("POST,PUT").Split(',').Contains(method.ToUpper()))
            {
                request.Accept = "application/json";
                if (!String.IsNullOrEmpty(contentType))
                {
                    request.ContentType = contentType;
                }

                if (data != null)
                {                   
                    request.ContentLength = data.Length;
                    using (StreamWriter requestWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        requestWriter.Write(data);
                    }
                }
                else
                {
                    request.ContentLength = 0;
                }
            }

            HttpWebResponse response;
            try
            {
                using (response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new WebException("Error code from Pictre: " + response.StatusCode);
                    }
                    //Process response stream can be JSON, XML or HTML ... etc
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                responseBody = reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (WebException e)
            {
                response = (HttpWebResponse)e.Response;
            }

            return responseBody;
            
        }

        #region Other approached to consume REST Services - Haven't finished yet

        static void AddUserWebRequest()
        {
            try
            {
                UserDto user = new UserDto();

                user.FirstName = "KajarubanTest";
                user.LastName = "SurendranTest";
                user.FullName = "KajarubanTest SurendranTest";
                user.EmailAddress = "surenkajanTest@gmail.com";
                user.DateOfBirth = DateTime.Now;
                user.Sex = "Male";

                //create new request
                //This will match AddBook in IBookService.cs
                WebRequest request = WebRequest.Create(@"http://localhost:1893/Service.svc/userRest/help/operations/AddUserByEmailID");
                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";

                //add new update book info to request
                Stream stream = request.GetRequestStream();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(UserDto));
                ser.WriteObject(stream, user);

                //invoke REST method
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(int));
                        int res = (int)serializer.ReadObject(responseStream); // since we get collection back

                        //bindingSource1.DataSource = usr;
                        //dvBooks.DataSource = bindingSource1;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        static string TestPostrequest()
        {
            string responseBody = null;
            UserDto user = new UserDto();

            user.FirstName = "KajarubanTest";
            user.LastName = "SurendranTest";
            user.FullName = "KajarubanTest SurendranTest";
            user.EmailAddress = "surenkajanTest@gmail.com";
            user.DateOfBirth = DateTime.Now;
            user.Sex = "Male";


            //JavaScriptSerializer js = new JavaScriptSerializer();
            //string postData = js.Serialize(obj);
            string userjson = JsonConvert.SerializeObject(user);

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:1893/Service.svc/userRest/AddUserByEmailID");
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            webRequest.ContentLength = userjson.Length;
            try
            {
                using (StreamWriter requestWriter2 = new StreamWriter(webRequest.GetRequestStream()))
                {
                    requestWriter2.Write(userjson);
                }

                using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                {
                    // dumps the HTML from the response into a string variable
                    responseBody = responseReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            return responseBody;
        }

        static void ShowUser(UserDto user)
        {
            Console.WriteLine($"FirstName: {user.FirstName}\tUserName: {user.UserName}\tLastName: {user.LastName}\tFullName: {user.FullName}\tEmailAddress: {user.EmailAddress}\tDateOfBirth: {user.DateOfBirth}\tSex: {user.Sex}");
        }

        static void ShowUserList(List<UserDto> userList)
        {
            foreach(UserDto user in userList)
            {
                Console.WriteLine($"FirstName: {user.FirstName}\tUserName: {user.UserName}\tLastName: {user.LastName}\tFullName: {user.FullName}\tEmailAddress: {user.EmailAddress}\tDateOfBirth: {user.DateOfBirth}\tSex: {user.Sex}\n");
            }

        }

        #endregion
    }

    [Serializable]
    [DataContract]
    public class UserDto
    {
        #region Database Properties

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
        private string profileImage;
        [DataMember]
        public string ProfileImage
        {
            get { return profileImage; }
            set { profileImage = value; }
        }
        #endregion
    }
}
