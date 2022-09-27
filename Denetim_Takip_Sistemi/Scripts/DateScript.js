function dateConvert(dateJson) {
    if (dateJson == null) {
        return null;
    }
    var dateString = dateJson.substr(6);
    var currentTime = new Date(parseInt(dateString));
    var month = currentTime.getMonth() + 1;
    if (month < 10) {
        var month = "0" + month;
    }
    var day = currentTime.getDate();
    if (day < 10) {
        var day = "0" + day;
    }
    var year = currentTime.getFullYear();
    var date = year + "-" + month + "-" + day;
    return date;
}