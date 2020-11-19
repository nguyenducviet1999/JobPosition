$(document).ready(function () {
    var employeejs = new EmployeeJS();
    insert_dialog = $(".dialog-modal").dialog({
        height: 600,
        width: 800,
        modal: true,
        title: "Thêm danh mục",
        autoOpen: true
    });

})
class EmployeeJS {
    constructor() {
        this.loadData();
        this.click();
    }
    loadData() {
        //Lấy th từ html
        var ths = $('table tr th');
        $.ajax({
            url: "https://localhost:44357/api/v1/DictionarySchools/GetByLevel",
            method: "GET"
        }).done(function (res) {
            debugger
            $("table#tbListDictionary tbody").empty();
            var data = res.data.data;
            var stt = 0;
            $.each(data, function (index, obj) {
                var tr = $('<tr></tr>');
                $.each(ths, function (index, th) {
                    var td = $('<td><div><span></span></div></td>');
                    // Lấy fielname th
                    var value;
                    var fieldName = $(th).attr('fieldName');
                    //Lấy giá trị của thuộc tính tương ứng với fieldName trong obj
                    if (fieldName == "STT") {
                        stt += 1;
                        value = stt;
                    }
                    else {
                        value = obj[fieldName];
                    }

                    td.append(value);
                    tr.append(td);
                })
                $("table#tbListDictionary tbody").append(tr);
            })
        }).fail(function (res) {
            alert("Load Data Failed.");
        })
    }
    click() {
        var mythis = this;
        $("#filter-right-icon").click(function () {
            alert("Nạp thành công.")
            mythis.loadData();
        });
        $("#btn-insert").click(function () {
            insert_dialog.dialog("open");

        });
    }

}