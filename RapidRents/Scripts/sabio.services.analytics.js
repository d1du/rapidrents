﻿sabio.services.analytics = sabio.services.analytics || {};

sabio.services.analytics.anaTypeIds = { RENDER: 0, CLICK: 1 };
sabio.services.analytics.anaCategoryIds = { PAGE: 0, LISTING: 1, BUTTON: 2, HREF: 3 };


sabio.services.analytics.insert = function (dataObj, onSuccess, onError) {
    var url = "/api/analytics?";
    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "GET"
    , data: dataObj
    };
    $.ajax(url, settings);
}

sabio.services.analytics.insertV2 = function (dataObj, onSuccess, onError) {
    var url = "/api/analytics/V2?";
    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "GET"
    , data: dataObj
    };
    $.ajax(url, settings);
}