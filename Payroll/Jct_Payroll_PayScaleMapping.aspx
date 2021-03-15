<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_PayScaleMapping.aspx.cs" Inherits="Payroll_Jct_Payroll_PayScaleMapping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .buttonc
        {
            background-color: black;
            font-family: Tahoma;
            font-size: 8pt;
            font-weight: bold;
            text-align: center;
            text-decoration: none;
            color: White;
            display: inline-block;
            width: 84px;
            line-height: 22px;
        }
    </style>
    <script src="jquery-1.11.3.js" type="text/javascript"></script>
    <script src="jquery-ui.1.11.3.js" type="text/javascript"></script>
    <link href="jquery-ui.1.11.3.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#imgwait').hide();
            $('#img1').hide();
            $('#lnkSave').click(function () {
                if ($('#txtSeriesCode').val() == '' || $('#txtEmployeeName').val() == '') {
                    alert('EmployeeName Or Series Code Cannot Be Blank');
                    return false;
                }
                $('#imgwait').show();
                SaveValues();
            });

            function SaveValues() {
                $.ajax({
                    url: "Jct_Payroll_PayScaleMapping.aspx/Save",
                    data: '{txtSeriesCode: "' + $("#txtSeriesCode").val() + '" ,txtEmployeeName: "' + $("#txtEmployeeName").val() + '",txtQualification: "' + $("#txtQualification").val() + '" ,txtExperience: "' + $("#txtExperience").val() + '",txtDesignation: "' + $("#txtDesignation").val() + '" ,txtDepartment: "' + $("#txtDepartment").val() + '",txtProbationPd: "' + $("#txtProbationPd").val() + '" ,txtDateofjoining: "' + $("#txtDateofjoining").val() + '",txtOfferAccepted: "' + $("#txtOfferAccepted").val() + '",txtYearofPassing: "' + $("#txtYearofPassing").val() + '",txtPlant: "' + $("#txtPlant").val() + '"}',
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: OnSuccess2,
                    error: function (response) {
                        alert(response.responseText);
                        $('#imgwait').hide();
                    },
                    failure: function (response) {
                        alert(response.responseText);
                        $('#imgwait').hide();
                    }
                });
            }

            function OnSuccess2(response) {
                alert('Record Saved Successfully');
                ResetInputNullAll();
                $('#imgwait').hide();
                return;
            }

            $("#txtSearchEmployecode").autocomplete({           
                source: function (request, response) {
                    $.ajax({
                        url: "Jct_Payroll_PayScaleMapping.aspx/GetCustomers",
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                            $('#img1').hide();
                        },
                        error: function (response) {
                            alert(response.responseText);
                            $('#img1').hide();
                        },
                        failure: function (response) {
                            alert(response.responseText);
                            $('#img1').hide();
                        }
                    });
                },
                select: function (e, i) {
                    $("#hfCustomerId").val(i.item.val);
                },
                minLength: 3
            });

            $("#btnQueryString").bind("click", function () {
                var url = "Jct_Payroll_PayScale_Print.aspx?name=" + encodeURIComponent($("#txtEmployeeName").val()) + "&code=" + encodeURIComponent($("#txtSeriesCode").val());
                window.location.href = url;
            });


            $("#btnprintctc").bind("click", function () {
                var url = "Jct_Payroll_PayScale_Print_Personal.aspx?name=" + encodeURIComponent($("#txtEmployeeName").val()) + "&code=" + encodeURIComponent($("#txtSeriesCode").val());
                window.location.href = url;
            });




            $("#btnback").bind("click", function () {
                var url = "Jct_Payroll_PayScaleEntry.aspx";
                window.location.href = url;
            });


            $('#txtSearchEmployecode').blur(function () {
                $('#img1').show();
                ResetInputNull();
                FetchExistingRecord();
            });

            function FetchExistingRecord() {
                $.ajax({
                    url: "Jct_Payroll_PayScaleMapping.aspx/FetchExisting",
                    data: '{txtSearchEmployecode: "' + $("#txtSearchEmployecode").val() + '"}',
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {                        
                        if (data.d.txtEmployeeName != null) {
                            $('#txtSeriesCode').val(data.d.txtSeriesCode);
                            $('#txtEmployeeName').val(data.d.txtEmployeeName);
                            $('#txtQualification').val(data.d.txtQualification);
                            $('#txtExperience').val(data.d.txtExperience);
                            $('#txtDesignation').val(data.d.txtDesignation);
                            $('#txtDepartment').val(data.d.txtDepartment);
                            $('#txtProbationPd').val(data.d.txtProbationPd);
                            $('#txtDateofjoining').val(data.d.txtDateofjoining);
                            $('#txtOfferAccepted').val(data.d.txtOfferAccepted);
                            $('#txtYearofPassing').val(data.d.txtYearofPassing);
                            $('#txtPlant').val(data.d.txtPlant);
                             $('#img1').hide();
                        }
                        else {
                            alert('No Existing Record');
                            $('#img1').hide();
                        }

                    },
                    error: function (response) {
                        alert(response.responseText);
                        $('#img1').hide();
                    },
                    failure: function (response) {
                        alert(response.responseText);
                        $('#img1').hide();
                    }
                });
            }

            function ResetInputNull() {
                $('#txtSeriesCode').val('');
                $('#txtEmployeeName').val('');
                $('#txtQualification').val('');
                $('#txtExperience').val('');
                $('#txtDesignation').val('');
                $('#txtDepartment').val('');
                $('#txtProbationPd').val('');
                $('#txtDateofjoining').val('');
                $('#txtOfferAccepted').val('');
                $('#txtPlant').val('');
                $('#txtYearofPassing').val('');
            }

            function ResetInputNullAll() {
                $('#txtSeriesCode').val('');
                $('#txtEmployeeName').val('');
                $('#txtQualification').val('');
                $('#txtExperience').val('');
                $('#txtDesignation').val('');
                $('#txtDepartment').val('');
                $('#txtProbationPd').val('');
                $('#txtDateofjoining').val('');
                $('#txtOfferAccepted').val('');
                $('#txtPlant').val('');
                $('#txtYearofPassing').val('');
                $('#txtSearchEmployecode').val('');
            }


        });
    </script>
    <table style="width: 100%">
        <tr>
            <td class="tableheader" colspan="6">
                PayScale Mapping :
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Employee Search
            </td>
            <td class="NormalText">
                <input type="text" name="txtSearchEmployecode" id="txtSearchEmployecode" class="textbox" />
                <label id="hfCustomerId">
                </label>
            </td>
            <td class="labelcells">
                <img src="/fusionapps/OPS/Image/loadingNew.gif" alt="Sample Image" id="img1" />
            </td>
            <td class="labelcells">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                SeriesCode
            </td>
            <td class="NormalText">
                <input id="txtSeriesCode" name="txtSeriesCode" class="textbox" style="width: 85px;"
                    type="text" />
            </td>
            <td class="labelcells">
                EmployeeName
            </td>
            <td class="NormalText">
                <input id="txtEmployeeName" name="txtEmployeeName" class="textbox" style="width: 85px;"
                    type="text" />
            </td>
            <td class="labelcells">
                Qualification
            </td>
            <td class="NormalText">
                <input id="txtQualification" name="txtQualification" class="textbox" style="width: 85px;"
                    type="text" />
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Experience
            </td>
            <td class="NormalText">
                <input id="txtExperience" name="txtExperience" class="textbox" style="width: 85px;"
                    type="text" />
            </td>
            <td class="labelcells">
                Designation
            </td>
            <td class="NormalText">
                <input id="txtDesignation" name="txtDesignation" class="textbox" style="width: 85px;"
                    type="text" />
            </td>
            <td class="labelcells">
                Department
            </td>
            <td class="NormalText">
                <input id="txtDepartment" name="txtDepartment" class="textbox" style="width: 85px;"
                    type="text" />
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                ProbationPd
            </td>
            <td class="NormalText">
                <input id="txtProbationPd" name="txtProbationPd" class="textbox" style="width: 85px;"
                    type="text" />
            </td>
            <td class="labelcells">
                Dateofjoining
            </td>
            <td class="NormalText">
                <input id="txtDateofjoining" name="txtDateofjoining" class="textbox" style="width: 85px;"
                    type="text" />
            </td>
            <td class="labelcells">
                OfferAccepted
            </td>
            <td class="NormalText">
                <input id="txtOfferAccepted" name="txtOfferAccepted" class="textbox" style="width: 85px;"
                    type="text" />
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                YearOfPassing</td>
            <td class="NormalText">
                <input id="txtYearofPassing" name="txtYearofPassing" class="textbox" style="width: 85px;"
                    type="text" /></td>
            <td class="labelcells">
                Plant</td>
            <td class="NormalText">
            <input id="txtPlant" name="txtPlant" class="textbox" style="width: 85px;"
                    type="text" />
                </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" colspan="6">
                <img src="/fusionapps/OPS/Image/loadingNew.gif" alt="Sample Image" id="imgwait" />
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="6">
                <input type="button" value="Save" id="lnkSave" name="lnkSave" class="buttonc" />
                <input type="button" id="btnQueryString" value="Print"  class="buttonc" />
                <input type="button" id="btnprintctc" value="CtcPrint"  class="buttonc" />
                <input type="button" id="btnback" value="Back"  class="buttonc" />
            </td>
        </tr>
        
    </table>
</asp:Content>
