var PictreServicesBaseAddress = "http://localhost:1893/Service.svc";
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