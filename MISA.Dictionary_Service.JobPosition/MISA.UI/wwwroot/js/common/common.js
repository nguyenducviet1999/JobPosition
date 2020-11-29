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

function newguid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}