/**
 * 格式化日期
 * @param {Datetime} date
 */
function formatDate(date) {
    var day = fillDigit(date.getDate(), 10);
    var month = fillDigit(date.getMonth() + 1, 10);
    var year = date.getFullYear();
    return year + '/' + month + '/' + day;
}

function fillDigit(number, threshold) {
    if (number < threshold) {
        return '0' + number;
    } else {
        return number;
    }
}