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

function GetFriendsListService(emailID) {
    return (PictreGETService(PictreServicesBaseAddress + "/friendrest/GetFriendByEmailID?Email=" + emailID))
}

function GetFriendPhotosService(emailID) {
    return (PictreGETService(PictreServicesBaseAddress + "/PhotoRest/GetFriendPhotosByEmailID?EmailId=" + emailID))
}

function GetUserDetailsService(emailID) {
    return (PictreGETService(PictreServicesBaseAddress + "/userrest/GetUserByEmailID?Email=" + emailID))
}

function GetUserDetailsbyFullName(fullName) {
    return (PictreGETService(PictreServicesBaseAddress + "/userrest/GetUserByFullName?FullName=" + fullName));
}

function UploadPhotoService(photodetails)
{
    var url = PictreServicesBaseAddress + "/PhotoRest/AddPhotoByEmailID";
    var result = PictrePOSTService(url, photodetails);
    return result;

}

function PostCommentRestService(commentobj) {
    var commentData = {
        PhotoID: '4',
        EmailAddress: "s@s.com",
        Comments: "haan mujhe bhi badi mast lagi raapchik",
        UploadTimeStamp: "/Date(753636849000-0500)/",
        FullName: null,
        FirstName: null,
        LastName: null
    }
    var result = PictrePOSTService(PictreServicesBaseAddress + "/photoRest/AddCommentsByEmailID", commentobj);

    console.log("Result of the Service is" + result);

}
