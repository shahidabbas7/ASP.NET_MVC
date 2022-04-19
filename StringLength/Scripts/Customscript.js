/// <reference path="jquery-3.4.1.js" />
$(function () {
    $("#btnsubmit").mouseover(function () {
        $("#btnsubmit").css("backgroundColor","red")
    });
    $("#btnsubmit").mouseout(function () {
        $("#btnsubmit").css("backgroundColor", "grey")
    });
});