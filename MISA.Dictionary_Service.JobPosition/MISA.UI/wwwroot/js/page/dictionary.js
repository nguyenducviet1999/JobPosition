/// <reference path="../common/resurce.js" />
var me;
var CurrentPageIndex;
var PageSize;
var TotalRecord;
var PageStatus;
var DialogStatus;
var OrganizationType;
$(document).ready(function () {
    //khởi tạo ban đầu giá trị các biến
    CurrentPageIndex = Enum.DefaultValue.CurrentPageIndexDefault;
    PageSize = Enum.DefaultValue.PageSizeDefault;
    TotalRecord = Enum.DefaultValue.TotalRecordDefault;
    PageStatus = Enum.DefaultValue.PageStatusDefault;
    OrganizationType = Enum.DefaultValue.OrganizationType;
    jobpositionjs = new JobpositionJS();
    insert_dialog = $(".dialog-modal").dialog({
        minHeight: 180,
        minWidth: 465,
        maxHeight: 180,
        maxWidth: 465,
        modal: true,
        title: "Thêm danh mục",
        autoOpen: false
    });
   
})
class JobpositionJS {

    constructor() {
        me = this;
        this.loadOrganizationType();
        this.pagination();
        this.initEvent();


    }
    initEvent() {
        //xử lý sự kiện phân trang
        $("#firstPage").click(this.firstPage);
        $("#prePage").click(this.prePage);
        $("#nextPage").click(this.nextPage);
        $("#lastPage").click(this.lastPage);
        $("#pageNumber").on("keypress", this.selectPage);
        $("#refreshPage").click(me.pagination);
        $("#numberRecordPage").on("keypress", this.selectNumberRecordPage);
        //xử lí sự kiện tìm kiếm
        $("#search").on("keypress", this.searchData);
        // xử lý sự kiện chỉnh sửa bản ghi
        $("table").on("click", "tbody tr", this.rowOnClick);
        $("table").on("dblclick", "tbody tr", this.rowOnDoubleClick);
        //xử lí sự kiện Click vào nút trên thanh công cụ
        $("#btn-insert").click(this.addOnClick);
        $("#btn-edit").click(this.editOnClick);
        $("#btn-delete").click(this.deleteOnClick);
        //xử lí sự kiện trong dialog
        $("#btn-cancel").click(this.cancelOnClick);
        $("#btn-save").click(this.saveOnClick);
        //xử lí dự kiện chọn loại tổ chức
        $("#organizationType").change(me.selectOrganizationType);
        //xử lý dữ
        $("#jobpositionName").change(me.changeJobpositionName);
        $("#jobpositionName").keypress(me.changeJobpositionName);
    }
    //lấy danh sách các loại tổ chức
    loadOrganizationType() {
        var data = me.callajax("GET", "api/Oganizationtypes", null)["data"];
        if (data != null) {
            for (var i = 0; i < data.length; i++) {
                var tmp = $(`<option value="` + data[i]['organizationTypeId'] + `">` + data[i]['organizationTypeName'] + `</option>`);
                $("#organizationType").append(tmp);
            }
           
        }
        
    }
    loadInsertData() {
        var tmp = $("#brow");
        tmp.empty();
        var data = me.callajax("GET", "api/Jobpositions/insertdata" + "?organizationType=" + OrganizationType, null)["data"];
        if (data != null) {
            for (var i = 0; i < data.length; i++) {
                var tmp = $(`<option class="insertdata" id="`+data[i]["jobPositionId"]+`" value="` + data[i]['jobPositionName'] + `"></option>`);
                //tmp.data["jobPositionId"] = data["jobPositionId"];
                $("#brow").append(tmp);
            }
        }
           
        
    }
    changeJobpositionName() {
        var tmp = $('#brow option[value="' + $("#jobpositionName").val() + '"]');

        if (tmp.length != 0) {
            tmp = tmp[0].id;
            $("#jobpositionId").val(tmp);
            
        }
        else {
            $("#jobpositionId").val(newguid());
        }
    }
    /**
     * Hàm xử lý sự kiện chọn loại tổ chức
     * C
     * */
    selectOrganizationType() {
        OrganizationType = $("#organizationType").val();
        CurrentPageIndex = Enum.DefaultValue.CurrentPageIndexDefault;
        PageSize = Enum.DefaultValue.PageSizeDefault;
        me.loadInsertData();
        me.pagination();

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
    
  
    loadTable(data) {
            var tbody = $("#bodytable");
            tbody.empty();
        if (data != null) {
           
            for (var i = 0; i < data.length; i++) {
                var tmp = $(`<tr>
                                <td datatype="centrel">`+ 1 + `</td> 
                                <td class="displaynone">`+ data[i]["jobPositionId"] + `</td>
                                <td>`+ data[i]["jobPositionName"] + `</td>
                                <td datatype="centrel">`+ formatDate(data[i]["createdDate"]) + `</td> 
                                <td datatype="centrel">`+ formatDate(data[i]["modifiedDate"]) + `</td > </tr>`);

                $("#bodytable").append(tmp);

            };
        }
        if (data == null) {
            var tbody = $("#bodytable");
            $("#bodytable").append($(`<img style="display: block;margin-left: auto;margin-right: auto;" src="../content/img/NoData.jpg" />`))
        }


    }
    LoadPageInfor(totalRecord) {

        TotalRecord = totalRecord;
        $("#pageNumber").val(CurrentPageIndex);
        $("#numberRecordPage").val(PageSize);
        $("#totalPageNuber").text("trên " + (Math.ceil(TotalRecord / PageSize)));
        $("#totalCustomer").text(TotalRecord);
        $("#listCustomerShow").text(((CurrentPageIndex - 1) * PageSize + 1) + " - " + (CurrentPageIndex * PageSize < TotalRecord ? CurrentPageIndex * PageSize : TotalRecord));
        // load số thứ tự
        var tmp = 0;
        for (var i = (CurrentPageIndex - 1) * PageSize + 1; i <= (CurrentPageIndex * PageSize < TotalRecord ? CurrentPageIndex * PageSize : TotalRecord); i = i + 1) {

            tmp = tmp + 1;
            $("tbody tr:nth-child(" + tmp + ") td:nth-child(1)").text(i);
            
        }
    }
    nextPage() {
        if (CurrentPageIndex < Math.ceil(TotalRecord / PageSize)) {
            CurrentPageIndex++;
        }
        me.pagination();

    }
    /**
    * Hàm chuyển tới trang sau
    * CreatedBy: NDViet (27/11/2020)
    * */
    prePage() {
        if (CurrentPageIndex > 1) {
            CurrentPageIndex--;
        }
        me.pagination();
    }
    /**
    * Hàm trở lại đầu liên
    * CreatedBy: NDViet (27/11/2020)
    * */
    firstPage() {
        CurrentPageIndex = 1;
        me.pagination();
    }
    /**
    * Hàm chuyển tới trang cuối cùng 
    * CreatedBy: NDViet (27/11/2020)
    * */
    lastPage() {
        CurrentPageIndex = Math.ceil(TotalRecord / PageSize);
        me.pagination();
    }

    selectNumberRecordPage(e) {
        if (e.keyCode == 13) {
            PageSize = $("#numberRecordPage").val();
            me.pagination();
        }
    }
    /**
     * hàm xử lý load dữ liệu phân trang
     * CreatedBy: NDViet (27/11/2020)
     * */
    searchData(e) {
        if (e.keyCode == 13) {
            CurrentPageIndex = Enum.DefaultValue.CurrentPageIndexDefault;
            PageSize = Enum.DefaultValue.PageSizeDefault;
            PageStatus = Enum.PageStatus.SearchData;
            me.pagination();
        }
    }
    saveData() {
        var success = false;
        var oldJobPositionId = $("#oldJobpositionId").val();
        var jobposition = {
            jobPositionId: $("#jobpositionId").val(),
            jobPositionName: $("#jobpositionName").val()
        }

       // $("#jobpositionId").val();
      //  $("#jobpositionName").val();
        switch (DialogStatus) {

            case Enum.DialogStatus.Add:
                {
                    var data = me.callajax("POST", "api/Jobpositions?organizationType=" + OrganizationType , JSON.stringify(jobposition));
                    if (data.success == true) {
                        $.alert({
                            title: 'Thông Báo',
                            content: "Thêm dữ liệu thành công.",
                        });
                    }
                    else {
                        $.alert({
                            title: 'Thông Báo',
                            content: "Thêm dữ liệu thất bại.",
                        });
                    }
                    break;
                }
            case Enum.DialogStatus.Edit:
                {

                    var data = me.callajax("PUT", "api/Jobpositions/" + oldJobPositionId +"?organizationType=" + OrganizationType , JSON.stringify(jobposition));
                    if (data.success == true) {
                        $.alert({
                            title: 'Thông Báo',
                            content: "Sửa dữ liệu thành công.",
                        });
                    }
                    else {
                        $.alert({
                            title: 'Thông Báo',
                            content: "Sửa dữ liệu thất bại.",
                        });
                    }
                   
                    break;
                }
        }
        me.pagination();
    }
    pagination() {
        var data;
        var totalRecord;
        switch (PageStatus) {
            case Enum.PageStatus.NomalData:
                {
                    data = me.callajax("GET", "api/Jobpositions/paging/" + CurrentPageIndex + "/" + PageSize +"?organizationType=" + OrganizationType, null)["data"];
                    totalRecord = me.callajax("GET", "api/Jobpositions/countalljobposition?organizationType=" + OrganizationType, null)["data"];
                    break;
                }
            case Enum.PageStatus.SearchData:
                {
                    var searchKey = $("#search").val();
                    data = me.callajax("GET", "api/Jobpositions/searchpaging/" + CurrentPageIndex + "/" + PageSize + "?searchKey=" + searchKey +"&organizationType=" + OrganizationType ,null)["data"];
                    totalRecord = me.callajax("GET", "api/Jobpositions/countallsearchdata?organizationType=" + OrganizationType +"&searchKey=" + searchKey, null)["data"];
                    break;
                }    
        }
        me.loadTable(data);
        me.LoadPageInfor(totalRecord);
        
    }
    rowOnClick(event) {
        if (event.ctrlKey) {


            if ($(this).hasClass('row-selected')) {
                $(this).removeClass("row-selected");
            }
            else
                this.classList.add("row-selected");

        }
        else {
            if ($(this).hasClass('row-selected')) {
                $(this).removeClass("row-selected");
            }
            else {
                this.classList.add("row-selected");
                $(this).siblings().removeClass("row-selected");
            }
        }
    }
    rowOnDoubleClick() {
        this.classList.add("row-selected");
        DialogStatus = Enum.DialogStatus.Edit;
        me.clearDialog();
        insert_dialog.dialog("open");
        var id = $(this).children()[1].textContent;
        var Name = $(this).children()[2].textContent;
        $("#jobpositionId").val(id);
        $("#oldJobpositionId").val(id);   
        $("#jobpositionName").val(Name);
    


    }
    addOnClick() {
        DialogStatus = Enum.DialogStatus.Add;
        me.clearDialog();
        insert_dialog.dialog("open");
        $("#jobpositionId").val(newguid());
       
    }
    editOnClick() {
        
        if ($(".row-selected").length < 1) {
            $.alert({
                title: 'Chú ý',
                content: "Vui lòng chọn một bản ghi trước",
            });
        }
        else if ($(".row-selected").length > 1) {
            $.alert({
                title: 'Chú ý',
                content: "Chỉ được chọn một bản ghi",
            });
        }
        else {
            DialogStatus = Enum.DialogStatus.Edit;
            me.clearDialog();
            insert_dialog.dialog("open");
            var id = $(".row-selected").children()[1].textContent;
            var Name = $(".row-selected").children()[2].textContent;
            $("#jobpositionId").val(id);
            $("#oldJobpositionId").val(id);   
            $("#jobpositionName").val(Name);
        }
    }
    deleteOnClick() {
        if ($(".row-selected").length < 1) {
            $.alert({
                title: 'Chú ý',
                content: "Vui lòng chọn ít nhất một bản ghi trước",
            });
        }
        else {
            var listId=[];
            for (var i = 0; i < $(".row-selected").length; i = i + 1) {
                listId.push($($(".row-selected")[i]).children()[1].textContent);
            }
            var data = me.callajax("DELETE", "api/Jobpositions/deleteListJobpositionId?organizationType=" + OrganizationType, JSON.stringify(listId))["data"];
            if (data.length <= 0) {
                $.alert({
                    title: 'Thông báo',
                    content: "Xóa dữ liệu thất bại.",
                });
            }
            else {
                $.alert({
                    title: 'Thông báo',
                    content: "Xóa dữ liệu thành công.",
                });
                me.showToastMsgSuccess("Xóa dữ liệu thành công");
                me.pagination();
            }
        }
    }
   /**
    * xử lý sự kiện click nút hủy trong dialog
    * */
    cancelOnClick() {
        $.confirm({
            title: 'Confirm!',
            content: 'Bạn có chắc muốn đóng khung nhập liệu',
            buttons: {
                confirm: function () {
                    insert_dialog.dialog("close");
                },
                cancel: function () {
                    
                }
               
            }
        });
        
    }
    saveOnClick() {
       var tmp = me.validate();
        if (tmp == "") {
            me.saveData();
            insert_dialog.dialog("close");
        }
        else {
            $.alert({
                title: 'Chú ý',
                content: tmp,
            });

        }
       
    }
    validate() {
        var mess = "";
        if ($("#jobpositionId").val().length < 36) {
            mess = mess + "ID chức danh/ chức vụ cần nhập đủ 36 kí tự.\r\n";
        }
        if ($("#jobpositionName").val().length < 1) {
            mess = mess + "Tên chức danh/ chức vụ không được bỏ trống.";
        }
        return mess;
    }

    clearDialog() {
        $("#jobpositionId").val("");
        $("#jobpositionName").val("");
    }

    showToastMsgSuccess(text) {
    $('.toastMsg-text').text(text);
    $('.toastMsg').show();
    setTimeout(function () {
        $('.toastMsg').hide();
    }, 4000);
}

}