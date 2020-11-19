function formatDate(date) {
    if (Date.IsNaN)
        return ""
    else {
        var date = new Date(date);
        var day = date.getDate();
        var month = date.getMonth() + 1;
        var year = date.getFullYear();
        day = day < 0 ? '0' + day : day;
        return day + "/" + month + "/" + year;
    }
}
/**
 * Hàm xử lý dữ liệu tiền tệ
 * @param {int} money Số tiền
 */
function formatMoney(money) {

}