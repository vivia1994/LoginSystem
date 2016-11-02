
//鼠标移过时，如何向一个页面上的锚标签添加或从中删除highlight类
$("a").mouseover(function () {
    $(this).addClass("highlight");
}).mouseout(function () {
    $(this).removeClass("highlight");
});

//=

$("a").hover(function () {
    $(this).toggleClass("highlight");
});

function searchFailed() {
    $("searchresults").html("Sorry,there was a problem with the search.")
}