$(document).ready(function () {
    var cardGroup = $(".row")

    cardGroup.on("mouseenter", ".card-img", function (event) {
        $(this).stop().fadeTo(400, 0.7);
    });

    cardGroup.on("mouseleave", ".card-img", function (event) {
        $(this).stop().fadeTo(400, 1);
    });

    cardGroup.on("click", ".card", function (event) {
        var itemID = $(this).parent().attr("data-id");
        var img = $(this).children(".card-img").attr("src");
        var date = $(this).children().find(".text-muted").text();

        $(".focused-box").stop().fadeIn(500);
        $(".focused-box").css("display", "block");
        $(".focused-box").children(".focused-img").attr("src", img);

        $(".focused-box").children(".item-group").children(".delete")
            .attr("data-id", itemID);

        $(".focused-box").children(".item-group").children(".update")
            .attr("data-id", itemID);
    });

    $(".focused-box").on("click", function () {
        var box = $(this);
        box.stop().fadeOut(500);

        setTimeout(function () {
            box.css("display", "none");
            box.children(".focused-img").attr("src", "");
            box.children(".date").text("");
        }, 500);
    });
});