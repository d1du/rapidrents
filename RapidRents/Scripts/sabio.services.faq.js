sabio.services.faq = sabio.services.faq || {};

sabio.services.faq.add = function (faqData, onSuccess, onError) {
    var url = "/api/faq/";
    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: faqData
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "POST"
    };
    $.ajax(url, settings);
}

sabio.services.faq.update = function (faqId, faqData, onSuccess, onError) {
    var url = "/api/faq/" + faqId;
    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , data: faqData
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "PUT"
    };
    $.ajax(url, settings);
}

sabio.services.faq.getEdit = function (faqId, onSuccess, onError) {
    $.ajax({
        url: "/api/faq/" + faqId,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "GET"
    })

}

sabio.services.faq.getList = function (onSuccess, onError) {
    $.ajax({
        url: "/api/faq",
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "GET"
    })
}

sabio.services.faq.delete = function (faqId, onSuccess, onError) {
    $.ajax({
        url: "/api/faq/" + faqId,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "DELETE"
    })

}