/**
 * Hàm định dạng thời gian hiển thị
 * @param {any} datetime chuỗi chứa thông tin thời điểm
 */
function formatDate(datetime) {
    if (datetime == null || datetime== "")
        return ""
    //else {
    //    var date = new Date(date);
    //    var day = date.getDate();
    //    var month = date.getMonth() + 1;
    //    var year = date.getFullYear();
    //    day = day < 0 ? '0' + day : day;
    //    return day + "/" + month + "/" + year;
    //}
    var date = datetime.split("T")[0];
    var time = datetime.split("T")[1];
    var result = date.split("-")[2] + "/" + date.split("-")[1] + "/" + date.split("-")[0] + " " + time
    return result;

}

/**
 * Hàm xử lý dữ liệu tiền tệ
 * @param {int} money Số tiền
 */
function formatMoney(money) {


}