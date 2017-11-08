$(document).ready(function () {
    var contacts = [
    {
        "firstName": "Peter",
        "lastName": "Parker",
        "heroName": "Spiderman",
        "imgUrl": "https://www.w3schools.com/images/w3schools_green.jpg"
    },
    {
        "firstName": "Bruce",
        "lastName": "Banner",
        "heroName": "Hulk",
        "imgUrl": "https://www.w3schools.com/images/w3schools_green.jpg"
    }, {
        "firstName": "Tony",
        "lastName": "Stark",
        "heroName": "Ironman",
        "imgUrl": "https://www.w3schools.com/images/w3schools_green.jpg"
    }, {
        "firstName": "Bruce",
        "lastName": "Wayne",
        "heroName": "Batman",
        "imgUrl": "https://www.w3schools.com/images/w3schools_green.jpg"
    }
    ];
    
    for (var i = 0; i < contacts.length; i++)
    {
        contacts[i].value = contacts[i].firstName + " " + contacts[i].lastName;
    }

    $("#searchbox").autocomplete({
        source: contacts,
        minLength: 1,
        focus: function (event, ui) {
            $("#searchbox").val(ui.item.heroName)
            return false;
        },
        select: function (event, ui) {
            location.href = ui.item.imgUrl;
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
        $img.attr("src", item.imgUrl);
        $img.appendTo($imageDiv);

        $name = $("<div>");
        $name.addClass("nameDiv");
        $name.append(item.firstName + " " + item.lastName);
        $name.appendTo($outerDiv);

        $li.appendTo(ul);

        return $li;
    };

})