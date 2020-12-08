$(document).ready(function () {
    $(".focused-box").on("click", ".update", function (event) {
        var button = $(this);
        var id = button.attr("data-id");

        button.attr("href", "/teamimages/edit/" + id);
    });
});