var me;
$(document).ready(function () {
    var employeejs = new EmployeeJS();
    insert_dialog = $(".dialog-modal").dialog({
        height: 600,
        width: 800,
        modal: true,
        title: "Thêm danh mục",
        autoOpen: false
    });

})
class EmployeeJS {
    constructor() {
        me = this;
        this.loadData();
        this.click();
        
    }
    loadData() {
        //Lấy th từ html
        me.getall();
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
    callajax(method, url, data) {
        var result = false;
        $.ajax({
            type: method,
            url: url,
            dataType: 'json',
            contentType: 'application/json',
            data: data,
            async: false,
            success: function (data) {
                result = data;
            }
        });
        return result;
    }
    getall() {
        try {
            var res = me.callajax("GET", "api/Jobpositions", null);
            if (res != false) {
                var tbody = document.getElementById("bodytable");
                for (var i = 0; i < res.length; i++) {
                    var tmp = $(`<tr>
                                <td>`+ res[i]["jobPositionId"] + `</td>
                                <td>`+ res[i]["jobPositionName"] + `</td>
                                <td datatype="datetime">`+ formatDate(res[i]["createdDate"]) + `</td> 
                                <td datatype="datetime">`+ formatDate(res[i]["modifiedDate"]) + `</td > ` +
                        `<td><button class="btn btn-info active btn-square editIcon">Edit</button>
                                </td><td><button class="btn btn-square btn-danger deleteIcon">Delete</button></td>
                            </tr>`);
                   
                    $("#bodytable").append(tmp);

                };
                $('#datatb').dataTable();
            }

        }
        catch (e) {
            console.log(e);
        }

    }

}