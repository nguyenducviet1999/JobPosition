/// <reference path="../common/resurce.js" />
var me;
var CurrentPageIndex = 1;
var PageSize=20;
var TotalRecord = 0;
var PageStatus = 1;
var DialogStatus;
$(document).ready(function () {
    var jobpositionjs = new JobpositionJS();
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
        //this.loadData();
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
        //xử lí sự kiện Click vào nút thêm chức danh chức vụ
        $("#btn-insert").click(this.addOnClick);
        //xử lí sự kiện trong dialog
        $("#btn-cancel").click(this.cancelOnClick);
        $("#btn-save").click(this.saveOnClick);
    }
    loadData(data) {
        //Lấy th từ html
        me.getall();
       // me.loadTable(data);
        me.LoadPageInfor();
        Enum.PageStatus.NomalData
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
            me.loadTable(res);
            me.LoadPageInfor();
        }
        catch (e) {
            console.log(e);
        }

    }
  
    loadTable(data) {
        if (data != null) {
            var tbody = $("#bodytable");
            tbody.empty();
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
            PageStatus = Enum.PageStatus.SearchData;
            me.pagination();
        }
    }
    saveData() {
        var jobposition = {
            jobPositionId: $("#jobpositionId").val(),
            jobPositionName: $("#jobpositionName").val()
        }

       // $("#jobpositionId").val();
      //  $("#jobpositionName").val();
        switch (DialogStatus) {

            case Enum.DialogStatus.Add:
                {
                  var  data = me.callajax("POST", "api/Jobpositions", jobposition);
                   
                    break;
                }
            case Enum.DialogStatus.Edit:
                {
                   
                   var data = me.callajax("PUT", "api/Jobpositions", jobposition);
                   
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
                    data = me.callajax("GET", "api/Jobpositions/paging/" + CurrentPageIndex + "/" + PageSize, null);
                    totalRecord = me.callajax("GET", "api/Jobpositions/countalljobposition", null);
                    break;
                }
            case Enum.PageStatus.SearchData:
                {
                    var searchKey = $("#search").val();
                    data = me.callajax("GET", "api/Jobpositions/searchpaging/" + CurrentPageIndex + "/" + PageSize + "?searchKey=" + searchKey,null);
                    totalRecord = me.callajax("GET", "api/Jobpositions/countallsearchdata?searchKey=" + searchKey, null);
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
        $("#jobpositionName").val(Name);
        insert_dialog.dialog("open");


    }
    addOnClick() {
        DialogStatus = Enum.DialogStatus.Add;
        me.clearDialog();
        insert_dialog.dialog("open");
        $("#jobpositionId").val(newguid());
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

}