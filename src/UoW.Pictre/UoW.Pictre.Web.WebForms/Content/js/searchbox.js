$(document).ready(function () {
    $.ajax({
        type: "GET",
        dataType: "jsonp",
        url: "http://localhost:1893/Service.svc/userrest/GetAllUsers",
        success: function (friends) {

            for (index in friends) {
                friends[index].value = friends[index].FullName;
            }

            if ($('#searchbox').is(":visible")) {
                $("#searchbox").autocomplete({
                    source: friends,
                    minLength: 1,
                    focus: function (event, ui) {
                        $("#searchbox").val(ui.item.FullName)
                        return false;
                    },
                    select: function (event, ui) {
                        location.href = "http://localhost:2587/myprofile/myprofile?uid=" + ui.item.UserID;
                        return false;
                    },
                }).autocomplete("instance")._renderItem = function (ul, item) {
                    var $li = $("<li>");
                    $li.addClass("searchItem");

                    $outerDiv = $("<div>");
                    $outerDiv.appendTo($li);

                    $imageDiv = $("<div>");
                    $imageDiv.addClass("contactImageDiv");
                    $imageDiv.appendTo($outerDiv);

                    $img = $("<img>");
                    $img.addClass("contactImage");
                    $img.attr("src", item.ProfilePhoto);
                    $img.appendTo($imageDiv);

                    $name = $("<div>");
                    $name.addClass("nameDiv");
                    $name.append(item.FullName);
                    $name.appendTo($outerDiv);

                    $li.appendTo(ul);

                    return $li;
                };
            }
        }
    });    
})