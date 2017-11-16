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
    public interface ITagService
    {
        [OperationContract]
        [Description("Get Tags By PhotoID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
      RequestFormat = WebMessageFormat.Json,
      ResponseFormat = WebMessageFormat.Json,
      UriTemplate = "GetTagsByPhotoID?PhotoID={PhotoID}")]
        List<TagFriendDto> GetTagsByPhotoID(int PhotoID);
    }
}
