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
    /**
     * Hàm khởi tạo ban đầu
     * Created By:NDVIET
     * Created Date: 1/12/2020
     * */

    constructor() {
        me = this;
        me.host = "https://localhost:44398";
        me.apiRouter = "/api/v1/";
        this.loadOrganizationType();
        this.pagination();
        this.initEvent();


    }
/**
* Hàm gán sự kiện 
* Created By:NDVIET
* Created Date: 1/12/2020
* */
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
        var data = me.callajax("GET", "Organizationtypes", null)["data"];
        if (data != null) {
            for (var i = 0; i < data.length; i++) {
                var tmp = $(`<option value="` + data[i]['organizationTypeId'] + `">` + data[i]['organizationTypeName'] + `</option>`);
                $("#organizationType").append(tmp);
            }
           
        }
        
    }
/**
* Hàm load dữ liệu cho ô lựa chọn loại tổ chức
* Created By:NDVIET
* Created Date: 1/12/2020
* */
    loadInsertData() {
        var tmp = $("#brow");
        tmp.empty();
        var data = me.callajax("GET", "Organizationtypes/insertings-jobpositions" + "?organizationTypeId=" + OrganizationType, null)["data"];
        if (data != null) {
            for (var i = 0; i < data.length; i++) {
                var tmp = $(`<option class="insertdata" id="`+data[i]["jobPositionId"]+`" value="` + data[i]['jobPositionName'] + `"></option>`);
                //tmp.data["jobPositionId"] = data["jobPositionId"];
                $("#brow").append(tmp);
            }
        }
           
        
    }
      /**
     * Hàm xử lý sự kiện khi giá trị dữ liệu nhập tên chức danh chức vụ thay đổi
     * Created By:NDVIET
     * Created Date: 1/12/2020
     * */
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
* Hàm Xử lí sự kiện thay đổi giá trị lựa chọn loại tổ chức
* Created By:NDVIET
* Created Date: 1/12/2020
* */
    selectOrganizationType() {
        OrganizationType = $("#organizationType").val();
        CurrentPageIndex = Enum.DefaultValue.CurrentPageIndexDefault;
        PageSize = Enum.DefaultValue.PageSizeDefault;
        me.loadInsertData();
        me.pagination();

    }
/**
* Hàm gọi ajax
* Created By:NDVIET
* Created Date: 1/12/2020
* */
    callajax(method, url, data) {
        var result = false;
        $.ajax({
            type: method,
            url: me.host  + me.apiRouter + url,
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
    
/**
* Hàm load dữ liệu vào bảng với dữ liệu được truyền vào
* Created By:NDVIET
* Created Date: 1/12/2020
* */
    loadTable(data) {
        me.showLoader();
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
/**
* Hàm load dữ liệu thông tin trang(số trang, số lượng hiển thị, trang hiện tại,..)
* Created By:NDVIET
* Created Date: 1/12/2020
* */
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
/**
* Xử lí sự kiện chuyển trang tiếp theo
* Created By:NDVIET
* Created Date: 1/12/2020
* */
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
/**
* Xử lí sự kiện thay đổi số lượng hiển thị trên một trang
* Created By:NDVIET
* Created Date: 1/12/2020
* */
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
/**
* Xử lí sự kiện tìm kiếm dữ liệu
* Created By:NDVIET
* Created Date: 1/12/2020
* */
    searchData() {
         {
            CurrentPageIndex = Enum.DefaultValue.CurrentPageIndexDefault;
            PageSize = Enum.DefaultValue.PageSizeDefault;
            PageStatus = Enum.PageStatus.SearchData;
            me.pagination();
        }
    }
/**
* Xử lí lưu dữ liệu nhập từ dialog
* Created By:NDVIET
* Created Date: 1/12/2020
* */
    saveData() {
        var success = false;
        var oldJobPositionId = $("#oldJobpositionId").val();
        var jobposition = {
            jobPositionId: $("#jobpositionId").val(),
            jobPositionName: $("#jobpositionName").val()
        }


        switch (DialogStatus) {

            case Enum.DialogStatus.Add:
                {
                    var data = me.callajax("POST", "Jobpositions?organizationTypeId=" + OrganizationType , JSON.stringify(jobposition));
                    if (data.message == "Success") {
                        me.showToastMsg(Enum.MsgType.Success, "Thêm dữ liệu thành công.");

                    }
                    else {
                        me.showToastMsg(Enum.MsgType.Failure, "Thêm dữ liệu thất bại.");

                    }

                    break;
                }
            case Enum.DialogStatus.Edit:
                {

                    var data = me.callajax("PUT", "Jobpositions/" + oldJobPositionId +"?organizationTypeId=" + OrganizationType , JSON.stringify(jobposition));
                    if (data.message == "Success") {
                        me.showToastMsg(Enum.MsgType.Success, "Sửa dữ liệu thành công.");
                     
                    }
                    else {
                        me.showToastMsg(Enum.MsgType.Failure, "Sửa dữ liệu thất bại.");
                      
                    }
                   
                    break;
                }
        }
        me.pagination();
    }
/**
* Xử lí lấy dữ liệu phân trang
* Created By:NDVIET
* Created Date: 1/12/2020
* */
    pagination() {
        var data;
        var totalRecord;
       
        var searchKey = $("#search").val();
        data = me.callajax("GET", "Jobpositions/" + CurrentPageIndex + "/" + PageSize + "?searchKey=" + searchKey +"&organizationTypeId=" + OrganizationType ,null)["data"];
        totalRecord = me.callajax("GET", "Jobpositions/total?organizationTypeId=" + OrganizationType +"&searchKey=" + searchKey, null)["data"];
        me.loadTable(data);
        me.LoadPageInfor(totalRecord);
        me.loadInsertData();
        
    }
/**
* Xử lí sự kiện click một bản ghi trong bảng
* Created By:NDVIET
* Created Date: 1/12/2020
* */
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
/**
* Xử lí sự kiện double click vào một bản ghi trong bảng để chỉnh sửa
* Created By:NDVIET
* Created Date: 1/12/2020
* */
    rowOnDoubleClick() {
        this.classList.add("row-selected");
        DialogStatus = Enum.DialogStatus.Edit;
        me.clearDialog();
        me.showDialog();
        var id = $(this).children()[1].textContent;
        var Name = $(this).children()[2].textContent;
        $("#jobpositionId").val(id);
        $("#oldJobpositionId").val(id);   
        $("#jobpositionName").val(Name);
    


    }
/**
* Xử lí sự kiện khi click vào nút thêm bản ghi
* Created By:NDVIET
* Created Date: 1/12/2020
* */
    addOnClick() {
        DialogStatus = Enum.DialogStatus.Add;
        me.clearDialog();
        me.showDialog();
        $("#jobpositionId").val(newguid());
       
    }
/**
* Xử lí sự kiện khi click vào nút sửa bản ghi
* Created By:NDVIET
* Created Date: 1/12/2020
* */
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
            me.showDialog();
            var id = $(".row-selected").children()[1].textContent;
            var Name = $(".row-selected").children()[2].textContent;
            $("#jobpositionId").val(id);
            $("#oldJobpositionId").val(id);   
            $("#jobpositionName").val(Name);
        }
    }
/**
* Xử lí sự kiện khi click nút xóa bản ghi
* Created By:NDVIET
* Created Date: 1/12/2020
* */
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
            var data = me.callajax("DELETE", "Jobpositions?organizationTypeId=" + OrganizationType, JSON.stringify(listId))["data"];
            if (data.length <= 0) {
                me.showToastMsg(Enum.MsgType.Success, "Xóa dữ liệu thất bại");
            }
            else {
              
                me.showToastMsg(Enum.MsgType.Success, "Xóa dữ liệu thành công");
                me.pagination();
            }
        }
    }
/**
* Xử lí sự kiện khi click nút hủy trong bản ghi
* Created By:NDVIET
* Created Date: 1/12/2020
* */
    cancelOnClick() {
        
        //$.confirm({
        //    title: 'Xác nhận!',
        //    content: 'Bạn có chắc muốn đóng khung nhập liệu',
        //    buttons: {
        //        "Đồng ý": function () {
        //            me.hideDialog();
        //        },
        //        "Hủy": function () {
                    
        //        }
               
        //    }
        //});
        //$($(".btn-default")[0]).text("Xác nhận");
        //$($(".btn-default")[1]).text("Hủy");
        me.hideDialog();
    }
/**
* Xử lí sự kiện click nút lưu trong dialog
* Created By:NDVIET
* Created Date: 1/12/2020
* */
    saveOnClick() {
       var tmp = me.validate();
        if (tmp == "") {
            me.saveData();
            me.hideDialog();
        }
        else {
            $.alert({
                title: 'Chú ý',
                content: tmp,
            });

        }
       
    }
/**
* Hàm kiểm tra dữ liệu nhập
* Created By:NDVIET
* Created Date: 1/12/2020
* */
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

/**
* Hàm làm rỗng giá trị nhập trong dialog
* Created By:NDVIET
* Created Date: 1/12/2020
* */
    clearDialog() {
        $("#jobpositionId").val("");
        $("#jobpositionName").val("");
    }
/**
* Hàm hiển thị toast message 
* Created By:NDVIET
* Created Date: 1/12/2020
* */
    showToastMsg(type, text) {
        switch (type) {
            case Enum.MsgType.Success:
                {
                    $("#toastMsg").removeClass();
                    $("#iconTypeMsg").removeClass();
                    
                    $("#toastMsg").addClass("color-success");
                    $("#iconTypeMsg").addClass("icon-success");
                   $("#typeMsg").text("Thành công")
                    break;
                }
            case Enum.MsgType.Failure:
                {
                    $("#toastMsg").removeClass();
                    $("#iconTypeMsg").removeClass();

                    $("#toastMsg").addClass("color-failure");
                    $("#iconTypeMsg").addClass("icon-failure");
                    $("#typeMsg").text("Thất bại")
                    break;
                }
        }

        $('#text-msg').text(text);
    $('#toastMsg').show();
    setTimeout(function () {
        $('#toastMsg').hide();
    }, 4000);
    }
/**
* Hàm mở dialog
* Created By:NDVIET
* Created Date: 1/12/2020
* */
    showDialog() {
        insert_dialog.dialog("open");
        var tmp = "";
        if ($("#organizationType option:selected").val() != "") {
            tmp = " của " + $("#organizationType option:selected").text();
        }
       
        switch (DialogStatus) {

            case Enum.DialogStatus.Add:
                {
                    $(".ui-dialog-title").text("Thêm danh mục"+tmp);
                    break;
                }
            case Enum.DialogStatus.Edit:
                {
                    $(".ui-dialog-title").text("Sửa danh mục"+ tmp);
                    break;
                }
        }
       
    }
/**
* Hàm ẩn dialog
* Created By:NDVIET
* Created Date: 1/12/2020
* */
    hideDialog() {
        insert_dialog.dialog("close");
        me.clearDialog();
    }
    showLoader() {
        $(".loader").show();
        setTimeout(function () {
            $('.loader').hide();
        }, 500);
    }
}