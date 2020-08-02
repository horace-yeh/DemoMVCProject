/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/moment/moment.d.ts" />

function jQueryPost(url, data, callback) {
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            callback(response);
        },
        error: function (error) {
            console.error(error);
        }
    });
}

function jQueryGet(url, callback) {
    $.ajax({
        type: "GET",
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            callback(response);
        },
        error: function (error) {
            console.error(error);
        }
    });
}

function isEmpty(val) {
    return (val === undefined || val == null || val.trim().length == 0) ? true : false;
}

function bsModalToggle(modalId) {
    $('#' + modalId).modal('toggle');
}

function momentDateFormat(date) {
    var formatStr = 'YYYY/MM/DD HH:mm:ss';
    return moment(String(date)).format(formatStr)
}