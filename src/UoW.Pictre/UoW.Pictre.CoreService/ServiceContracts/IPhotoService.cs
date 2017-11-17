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
    public interface IPhotoService
    {
        [OperationContract]
        [Description("Get Comment By PhotoID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetCommentsByID?PhotoId={photoID}")]
        List<PhotoDto> GetCommentsByID(int photoID);

        [OperationContract]
        [Description("Get Friend Photos By EmailID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetFriendPhotosByEmailID?EmailId={EmailID}")]
        List<PhotoDto> GetFriendPhotosByEmailID(string EmailID);


        [OperationContract]
        [Description("Get My Photos By EmailID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetPhotosByEmailID?EmailId={EmailID}")]
        List<PhotoDto> GetPhotosByEmailID(string EmailID);
    }
}
