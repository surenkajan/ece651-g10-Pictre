using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using UoW.Pictre.CoreService.DataTransferObjects;

namespace UoW.Pictre.CoreService
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [Description("Get User By EmailID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetUserByEmailID?Email={EmailID}")]
        UserDto GetUserByEmailID(string EmailID);

        [OperationContract]
        [Description("Add User to the System")]
        [WebInvoke(Method = "POST", 
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/AddUserByEmailID")]
        int AddUserByEmailID(UserDto user);
        //int AddUserByEmailID();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/EmpsalaryDetail/{EmpId}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        string TestGetEmpSalary(string EmpId);

        [OperationContract]
        [WebInvoke(UriTemplate = "/TestGetEmpSalaryPost",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        string TestGetEmpSalaryPost(string EmpId);


        [OperationContract]
        [Description("Get All Users")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetAllUsers")]
        List<UserDto> GetAllUsers();

    }
}
