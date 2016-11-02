$(function () {
    populateSearchDataSource(desktopExamples);

    var isRoot = window.location.href.match("/(.+kendo-ui|aspnet-mvc|aspnet-core|staging-mvc|staging-core|php-ui|jsp-ui)/?$") !== null;
    var baseUrl = isRoot ? "" : "../";

    $("#example-search").kendoExampleSearch({
        product: product,
        minLength: 3,
        template: '<a href="' + baseUrl + '#: url #"> #: text # </a>',
        dataTextField: "text",
        select: function (e) {
            location.href = e.item.find("a").attr("href");
        },
        height: 300
    });

    $("#example-sidebar").kendoResponsivePanel({
        breakpoint: 1200,
        orientation: "left",
        toggleButton: "#sidebar-toggle"
    });

    $("#sidebar-toggle").click(function() {
        $("#example-search").focus();
    });
});
