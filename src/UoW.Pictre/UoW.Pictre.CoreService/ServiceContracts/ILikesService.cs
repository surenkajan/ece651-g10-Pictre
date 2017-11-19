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
    public interface ILikesService
    {

        [OperationContract]
        [Description("Get Likes By PhotoID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
              RequestFormat = WebMessageFormat.Json,
              ResponseFormat = WebMessageFormat.Json,
              UriTemplate = "GetLikesByPhotoID?PhotoID={PhotoID}")]
              List<LikesDto> GetLikesByPhotoID(int PhotoID);

        [OperationContract]
        [Description("Add Likes to the Photo")]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/AddLikesByPhotoID")]
        int AddLikesByPhotoID(PhotoDto photo);
    }
}