$(document).ready(function () {
    $(".focused-box").on("click", ".delete", function (event) {
        var button = $(this);
        var id = button.attr("data-id");

        $.ajax({
            url: "/api/teamimages/" + id,
            method: "DELETE",
            success: function () {
                $(".col-sm-4[data-id='" + id + "']").remove();
            }
        })
    });
});