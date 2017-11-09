
$(document).ready(function () {
    console.log("ready!");
    //initialize();
});

    /*   $('#thirdlvl').click(function () {

    });

        $('#TagFriend').click(function () {
        $('#thirdlvl').hide();
    }); */

        function showthirdDiv() {
        console.log("Yayy");
    div = document.getElementById('thirdlvl');
            div.style.display = "block";
            return false;
        }

        function likecounter()
        {
            if (typeof (Storage) !== "undefined") {
                if (sessionStorage.clickcount) {
                    sessionStorage.clickcount = Number(sessionStorage.clickcount) + 1;
                } else {
                    sessionStorage.clickcount = 1;
                }
                var count = 0;
                count++;
                document.getElementById("likeres").innerHTML = "  "+ sessionStorage.clickcount + " Likes";
            }
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




function Pictre_Div()
{
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

 function Pictre_LoadDiv(url,x)
 {
     var img = new Image();
    //document.getElementById("divImage1").style.top = "60px";
    var bcgDiv = document.getElementById("divBackground");
    var imgDiv = document.getElementById("divImage1");
    var imgFull = document.getElementById("imgFull");
        //var imgLoader = document.getElementById("imgLoader");
    var captionText = document.getElementById("pcaption")

    //imgLoader.style.display = "block";
    img.onload = function() {
            imgFull.src = img.src;
        imgFull.style.display = "block";
        //imgLoader.style.display = "none";
        captionText.innerHTML = x;
        console.log(url);
        console.log(x);
    };
    img.src= url;
    var width = document.body.clientWidth;
    if (document.body.clientHeight > document.body.scrollHeight)
    {
            bcgDiv.style.height = document.body.clientHeight + "px";
        }
    else
    {
            bcgDiv.style.height = document.body.scrollHeight + "px" ;
        }

    imgDiv.style.left = (width-650)/2 + "px";
    imgDiv.style.top =  "20px";
    bcgDiv.style.width="100%";

     bcgDiv.style.display="block";
    imgDiv.style.display="block";
    return false;
 }
 function Pictre_HideDiv()
 {
            console.log("EnteredHide");
        var bcgDiv = document.getElementById("divBackground");
    var imgDiv = document.getElementById("divImage1");
    var imgFull = document.getElementById("imgFull");
    if (bcgDiv != null)
    {
            bcgDiv.style.display = "none";
        imgDiv.style.display="none";
        imgFull.style.display = "none";
    }
        }

function cancel()
{
    var bckgrnd = document.getElementById("divBackground");
        var imgDiv1 = document.getElementById("uploadwin1");
        if (bckgrnd != null) {
            bckgrnd.style.display = "none";
        imgDiv1.style.display = "none";
 
        }

 }


function initialize() {
    console.log($('#FriendContainer'));
    $('#FriendContainer').append('<div id="rect" style="height:650px;border-radius:8px;">' +
        '<div id="usernameDiv" style="height:50px;display:block;border-bottom-style:inset;"></div>' +
        '<div id="userpicDiv" style="height:350px;display:block;border-bottom-style:inset;"></div>' +
        '<span class="material-icons cloud"></span>' +
        '<span style="position:relative;font-size:30px;margin-left:15px;" onclick="likecounter()" class="fa" >&#xf0e5;</span > ' +
        '<div id="addComm" style="height:50px;display:block;border-bottom-style:inset;margin-top:100px;"></div>'+
        
        '</div > ');
}



