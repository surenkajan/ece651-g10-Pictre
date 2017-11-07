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
        [Description("Accepts LoginName and Get User By EmailID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetUserByEmailID/{EmailID}")]
        UserDto GetUserByEmailID(string EmailID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/EmpsalaryDetail/{EmpId}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        string TestGetEmpSalary(string EmpId);
    }
}
