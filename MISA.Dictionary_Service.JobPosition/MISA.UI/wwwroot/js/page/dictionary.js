var me;
var CurrentPageIndex = 1;
var PageSize=20;
var TotalRecord = 0;
var PageStatus;
var DialogStatus;
$(document).ready(function () {
    var jobpositionjs = new JobpositionJS();
    insert_dialog = $(".dialog-modal").dialog({
        minHeight: 600,
        minWidth: 800,
        maxHeight: 600,
        maxWidth: 800,
        modal: true,
        title: "Thêm danh mục",
        autoOpen: false
    });
   
})
class JobpositionJS {

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
            var res = me.callajax("GET", "api/Jobpositions/paging/" + CurrentPageIndex + "/" + PageSize, null);
            if (res != false) {
                var tbody = document.getElementById("bodytable");
                for (var i = 0; i < res.length; i++) {
                    var tmp = $(`<tr>
                                <td datatype="centrel">`+ 1 + `</td> 
                                <td>`+ res[i]["jobPositionId"] + `</td>
                                <td>`+ res[i]["jobPositionName"] + `</td>
                                <td datatype="centrel">`+ formatDate(res[i]["createdDate"]) + `</td> 
                                <td datatype="centrel">`+ formatDate(res[i]["modifiedDate"]) + `</td > </tr>`);

                    $("#bodytable").append(tmp);

                };

            }

        }
        catch (e) {
            console.log(e);
        }

    }
    loadTable(data) {
        if (data != false) {
            var tbody = document.getElementById("bodytable");
            for (var i = 0; i < data.length; i++) {
                var tmp = $(`<tr>
                                <td datatype="centrel">`+ 1 + `</td> 
                                <td>`+ data[i]["jobPositionId"] + `</td>
                                <td>`+ data[i]["jobPositionName"] + `</td>
                                <td datatype="centrel">`+ formatDate(data[i]["createdDate"]) + `</td> 
                                <td datatype="centrel">`+ formatDate(data[i]["modifiedDate"]) + `</td > </tr>`);

                $("#bodytable").append(tmp);

            };
        }


    }
    LoadPageInfor() {
        $("#pageNumber").val(CurrentPageIndex);
        $("#numberRecordPage").val(PageSize);
        $("#totalPageNuber").text("trên " + totalPage);
        $("#totalCustomer").text(TotalRecord);
        $("#listCustomerShow").text(((CurrentPageIndex - 1) * PageSize + 1) + " - " + (CurrentPageIndex * PageSize < TotalRecord ? CurrentPageIndex * PageSize : TotalRecord));
    }
}