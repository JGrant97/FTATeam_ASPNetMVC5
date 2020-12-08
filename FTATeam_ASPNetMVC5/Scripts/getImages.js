$(document).ready(function () {
    var cardGroup = $(".row")
    $.ajax({
        type: "GET",
        url: '/api/teamimages',
        dataType: 'json',
        success: function (data) {
            $.each(data, function (index, item) {
                var files = item.file;
                var date = new Date(item.datePosted);
                var id = item.id;
                cardGroup.append(
                    "<div class='col-sm-4' data-id='" + id + "'>"
                    + "<div id='card' class='card'>"
                    + "<img id = 'card-img' class='card-img' src = 'data:image/png;base64," + files + "' alt = 'Card image cap'>"
                    + "<div class= 'card-footer' >"
                    + "<small class='text-muted'>Uploaded: " + date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear() + "</small>"
                    + "</div>"
                    + "</div>"
                    + "</div>");
            })
        }
    });
});