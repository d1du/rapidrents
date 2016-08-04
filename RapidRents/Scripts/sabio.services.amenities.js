sabio.services.amenities = sabio.services.amenities || {};

sabio.services.amenities.add = function (amenityData, onSuccess, onError) {
    var url = "/api/amenities/";
    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: amenityData
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "POST"
    };
    $.ajax(url, settings);
}

sabio.services.amenities.update = function (amenityId, amenityData, onSuccess, onError) {
    var url = "/api/amenities/" + amenityId;
    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , data: amenityData
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "PUT"
    };
    $.ajax(url, settings);
}

sabio.services.amenities.getEdit = function (amenityId, onSuccess, onError) {
    $.ajax({
        url: "/api/amenities/" + amenityId,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "GET"
    })

}

sabio.services.amenities.getList = function (onSuccess, onError) {
    $.ajax({
        url: "/api/amenities",
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "GET"
    })
}

sabio.services.amenities.delete = function (amenityId, onSuccess, onError) {
    $.ajax({
        url: "/api/amenities/" + amenityId,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "DELETE"
    })

}

