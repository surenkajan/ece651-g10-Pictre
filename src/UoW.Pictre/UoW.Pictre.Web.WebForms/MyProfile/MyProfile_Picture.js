function initialize(person) {
    //console.log($('#FriendContainer'));
    var comments = CallCommentRestService(person.PhotoID);
    var commentString = "";

    for (index in comments) {
        commentString += "<li> <div class='commentText'><p><strong>" + comments[index].FullName + "</strong></p><p>" + comments[index].Comments + "</p></div></li>"
    }

    $('#FriendContainer').append('<div id="rect' + person.LastName + '" class="rect" style="height:650px;border-radius:8px;">' +
        '<div style="height:50px;display:block;border-bottom-style:inset;">' +
        '<h4 class="usernameDiv" style="color:black">' +
        '<img class ="img-circle" src="' + person.ProfilePhoto + '" />' +
        '<p style="display:inline">' + person.FirstName + " " + person.LastName + '</p> <p style="display:inline" class="checkinclass small" style="color:black">' + person.Location + '</p></h4> </div > ' +
        '<div id="userpicDiv" style="height:350px;display:block;border-bottom-style:inset;">' +
        '<img src="' + person.ActualPhoto + '" style="max-width:100%;max-height:100%;object-fit: contain" />' +
        '</div > ' +
        '<span id="' + person.PhotoID + '"class="glyphicon glyphicon-heart" style="margin-left: 12px; font-size:30px; color:crimson" onclick="likecounter(this.id)"></span>' +
        '<span style="position: relative; font-size: 30px; margin-left: 15px;color:crimson" class="glyphicon glyphicon-comment" onclick="showcommentDiv()"></span> ' +
        '<div id="likeres" style="height: 20px"></div>' +
        '<div class="actionBox"> <ul class="commentList">' + commentString + '</ul></div>' +
        '<div id="commenttxtbox" style="height: 50px; margin-top: 60px; bottom: 0px; border-top-style: inset;">' +
        '<div id="commentDiv"  class="tagorCheckin" data-placeholder="Add a comment..." contenteditable="true" style="height: 82%;" "></div>' +

        '</div>' +
        '</div > ' +
        '<hr/>'
    );
}

var peopleData = [{
    'username': "Jaspreet",
    'fullname': "Jaspreet Singh Sambee",
    'place': "Delhi",
    'imgsrc': "../Home/Images/Eiffel.jpg"
},
{
    'username': "Shitij",
    'fullname': "Shitij Vashisht",
    'place': "Dehradun",
    'imgsrc': "../Content/Images/dog.jpg"
}

];



//initialize();
$(document).ready(function () {
    var LoggeedInUser = document.getElementById("pictre_hdnf_CurrentUserEmailID").value;
    //console.log(peopleData);
    //$.ajax({
    //    type: "GET",
    //    dataType: "jsonp",
    //    url: "http://localhost:32785/Service.svc/PhotoRest/GetPhotosByEmailID?EmailId=enlil@gmail.com",
    //    success: function (data) {
    //        for (var i = 0; i < Object.keys(data).length; i++) {
    //            console.log(data[i]);
    //            initialize(data[i]);

    //        }



    //    }
    //});
    var data = CallPhotoRestService(LoggeedInUser);
    for (var i = 0; i < Object.keys(data).length; i++) {
        console.log(data[i]);
        initialize(data[i]);

    }
    //initialize(data);

});

/*   $('#thirdlvl').click(function () {

});

    $('#TagFriend').click(function () {
    $('#thirdlvl').hide();
}); */

function showthirdDiv() {
    console.log("Yayy");
    document.getElementById("tagDiv").focus();
    //document.getElementsByClassName("tagorCheckin")[0].fo
    return false;
}

function showcommentDiv(PhotoId) {
    //console.log("Yayy");
    //var LoggedInUser =""

    //var comment = document.getElementById("commentDiv").focus();
    //console.log('[{"PhotoID":"' + PhotoId + '"} ,{"UserEmail": "' + LoggedInUser + '"},{"Comment": "' + comment +'"});
    ////document.getElementsByClassName("tagorCheckin")[0].fo

}
/*function showthirdDiv() {
    console.log("Yayy");

    div = document.getElementById('thirdlvl');
    div.style.display = "block";
    return false;
}*/

function likecounter(photoID) {
    //document.getElementById("usernameDiv").innerHTML = "Jaspreet";
    //console.log("heyHi");
    var LoggedInUser = document.getElementById('pictre_hdnf_CurrentUserEmailID').value;
    //console.log(serverName);
    var likeData = {
        "PhotoID": parseInt(photoID),
        "EmailAddress": LoggedInUser

    };
    //if (typeof (Storage) !== "undefined") {
    //    if (sessionStorage.clickcount) {
    //        sessionStorage.clickcount = Number(sessionStorage.clickcount) + 1;
    //    } else {
    //        sessionStorage.clickcount = 1;
    //    }
    //    var count = 0;
    //    count++;
    //    var count1 = Object.keys(getlikes).length;
    //    document.getElementById("likeres").innerHTML = getlikes + " Likes";
    //    document.getElementById("likeres").style.marginLeft = "15px";
    //    document.getElementById("likeres").style.fontWeight = "700";
    //}
    //var url = "http://localhost:32785/Service.svc/likesRest/AddLikesByPhotoID";

    //PictrePOSTService(url, likeData);
    CallAddMyLikesService(likeData)
    //var likeurl = "http://localhost:32785/Service.svc/likesRest/GetLikesByPhotoID?PhotoID=" + id;
    //var  likes = PictreGETService(url)
    var getlikes = CallGetMyLikesService(photoID);
    //document.getElementById("likeres").innerHTML = Object.keys(getlikes).length + " Likes";
    document.getElementById("likeres" + photoID).innerHTML = Object.keys(getlikes).length + " Likes";
    //document.getElementById("likeres").style.marginLeft = "15px";
    //document.getElementById("likeres").style.fontWeight = "700";
    console.log("LikeDataNow");
    console.log(getlikes);
}

/*  function addcomment()
  {
      console.log("addedcomment");
      document.getElementById("commenttext").innerHTML = "Haha"
  }
*/
function addcomment() {
    console.log("addedcomment");
    document.getElementById("commenttxtbox").style.display = "block";

}


/*  function ShowImagePreview(input) {
   console.log(input);
console.log(input.files.length);
       if (input.files && input.files.length > 0) {
           for (var i = 0; i < input.files.length; i++) {
               var reader = new FileReader();
               $('#ImgPrv').empty();
               reader.onload = function (e) {
   $('#ImgPrv').attr('src', e.target.result);
$('#ImgPrv').append($('<img>', {src: e.target.result, width: '200px', height: '150' }));
               }
               reader.readAsDataURL(input.files[i]);
           }
       }
   }  */

$("#FileUpload1").change(function () {
    ShowImagePreview(this);
});




function Pictre_Div() {
    var bckgrnd = document.getElementById("divBackground");
    var imgDiv1 = document.getElementById("uploadwin1");
    var width = document.body.clientWidth;
    if (document.body.clientHeight > document.body.scrollHeight) {
        bckgrnd.style.height = document.body.clientHeight + "px";
    }
    else {
        bckgrnd.style.height = document.body.scrollHeight + "px";
    }
    console.log(imgDiv1);
    imgDiv1.style.left = (width - 650) / 2 + "px";
    imgDiv1.style.top = "20px";
    bckgrnd.style.width = "100%";

    bckgrnd.style.display = "block";
    imgDiv1.style.display = "block";
    return false;
}

function Pictre_LoadDiv(url, x) {
    var img = new Image();
    //document.getElementById("divImage1").style.top = "60px";
    var bcgDiv = document.getElementById("divBackground");
    var imgDiv = document.getElementById("divImage1");
    var imgFull = document.getElementById("imgFull");
    //var imgLoader = document.getElementById("imgLoader");
    var captionText = document.getElementById("pcaption")

    //imgLoader.style.display = "block";
    img.onload = function () {
        imgFull.src = img.src;
        imgFull.style.display = "block";
        //imgLoader.style.display = "none";
        captionText.innerHTML = x;
        console.log(url);
        console.log(x);
    };
    img.src = url;
    var width = document.body.clientWidth;
    if (document.body.clientHeight > document.body.scrollHeight) {
        bcgDiv.style.height = document.body.clientHeight + "px";
    }
    else {
        bcgDiv.style.height = document.body.scrollHeight + "px";
    }

    imgDiv.style.left = (width - 650) / 2 + "px";
    imgDiv.style.top = "20px";
    bcgDiv.style.width = "100%";

    bcgDiv.style.display = "block";
    imgDiv.style.display = "block";
    return false;
}
function Pictre_HideDiv() {
    console.log("EnteredHide");
    var bcgDiv = document.getElementById("divBackground");
    var imgDiv = document.getElementById("divImage1");
    var imgFull = document.getElementById("imgFull");
    if (bcgDiv != null) {
        bcgDiv.style.display = "none";
        imgDiv.style.display = "none";
        imgFull.style.display = "none";
    }
}

function cancel() {
    var bckgrnd = document.getElementById("divBackground");
    var imgDiv1 = document.getElementById("uploadwin1");
    if (bckgrnd != null) {
        bckgrnd.style.display = "none";
        imgDiv1.style.display = "none";

    }

}

jQuery(function ($) {
    $(".tagorCheckin").focusout(function () {
        console.log(this);
        var element = $(this);
        if (!element.text().replace(" ", "").length) {
            element.empty();
        }
    });
});