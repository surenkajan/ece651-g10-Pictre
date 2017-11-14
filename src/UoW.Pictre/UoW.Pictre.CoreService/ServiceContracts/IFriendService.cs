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
  public   interface IFriendService
    {
        [OperationContract]
        [Description("Get frnd By EmailID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
      RequestFormat = WebMessageFormat.Json,
      ResponseFormat = WebMessageFormat.Json,
      UriTemplate = "GetFriendByEmailID?Email={EmailID}")]
        List<FriendDto> GetFriendByEmailID(string EmailID);
    }
}
