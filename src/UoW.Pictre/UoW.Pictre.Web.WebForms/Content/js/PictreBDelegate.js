var PictreServicesBaseAddress = "http://localhost:32785/Service.svc";

//GET
function PictreGETService(Url) {
    var result;
    $.ajax({
        type: "GET",
        url: Url,
        contentType: "application/json; charset=utf-8",
        async: false,
        dataType: "json",
        success: function (data, textStatus, jqXHR) {
            result = data;
        },
        error: function (jqXHR, textStatus, errorThrown) {
            result = -1;
        }
    });
    return result;
}

//POST
function PictrePOSTService(Url, data) {
    var result;
    $.ajax({
        type: "POST",
        url: Url,
        contentType: "application/json; charset=utf-8",
        async: false,
        data: JSON.stringify(data),
        dataType: "json",
        success: function (data, textStatus, jqXHR) {
            result = data;
        },
        error: function (jqXHR, textStatus, errorThrown) {
            result = -1;
        }
    });
    return result;
}

//Update
function PictrePUTService(Url, data) {
    var result;
    $.ajax({
        type: "PUT",
        url: Url,
        contentType: "application/json; charset=utf-8",
        async: false,
        data: JSON.stringify(data),
        dataType: "json",
        success: function (data, textStatus, jqXHR) {
            result = data;
        },
        error: function (jqXHR, textStatus, errorThrown) {
            result = -1;
        }
    });
    return result;
}

//Delete
function PictrePUTService(Url, data) {
    var result;
    $.ajax({
        type: "DELETE",
        url: Url,
        contentType: "application/json; charset=utf-8",
        async: false,
        data: JSON.stringify(data),
        dataType: "json",
        success: function (data, textStatus, jqXHR) {
            result = data;
        },
        error: function (jqXHR, textStatus, errorThrown) {
            result = -1;
        }
    });
    return result;
}

function CallPhotoRestService(EmailId) {
    var url = PictreServicesBaseAddress + "/PhotoRest/GetPhotosByEmailID?EmailId=" + EmailId;
    var people = PictreGETService(url)
    return people;
}
function CallGetMyLikesService(id) {
    var url = PictreServicesBaseAddress + "/likesRest/GetLikesByPhotoID?PhotoID=" + id;
    var likes = PictreGETService(url)
    return likes;
}
function CallCommentRestService(PhotoId) {
    var url = PictreServicesBaseAddress + "/PhotoRest/GetCommentsByID?PhotoId=" + PhotoId;
    var comment = PictreGETService(url)
    return comment;
}
function CallAddMyLikesService(likeData) {
    var url = PictreServicesBaseAddress + "/likesRest/AddLikesByPhotoID";
    PictrePOSTService(url, likeData);
    //return addLikes;
}
function CallRestService() {
    var userData = {
        DateOfBirth: "/Date(753636849000-0500)/",
        EmailAddress: "surenkajan456@gmail.com",
        FirstName: "Kajaruban456",
        FullName: "Kajaruban456 Surendran456",
        LastName: "Surendran456",
        ProfilePhoto: null,
        Sex: "Male",
        UserName: "surenkajan456"
    }
    var result = PictrePOSTService(PictreServicesBaseAddress + "/userRest/AddUserByEmailID", userData);

    alert("Result of the Service is" + result);

}

function PostLikesService(likedata)
{
        PictrePOSTService(PictreServicesBaseAddress + "/likesRest/AddLikesByPhotoID", likedata);
}

function GetLikesService(photoID)
{
    return(PictreGETService(PictreServicesBaseAddress + "/likesRest/GetLikesByPhotoID?PhotoID=" + photoID))
}

function UploadPhotoService(photodetails)
{
    var result = PictrePOSTService(PictreServicesBaseAddress + "/PhotoRest/AddPhotoByEmailID", photodetails);

}