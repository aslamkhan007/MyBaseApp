<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_PayScaleEntry.aspx.cs" Inherits="Payroll_Jct_Payroll_PayScaleEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .abc
        {
        }
        
        .ctc
        {
        }
        
        .hilighted { color:  Green;  font-weight :bold }
        
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
        
        
        div
        {
            margin-bottom: 5px;
            padding: 4px 12px;
        }
        
        .danger
        {
            background-color: #ffdddd;
            border-left: 6px solid #f44336;
            font-size: 8pt;
            font-family: cursive;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            HideControls();
            $('#img').hide();
            $('#img0').hide();
            $('#imgwait').hide();
            $('#<%=lnkUpdate.ClientID%>').hide();
            $('#<%=lnkadd.ClientID%>').show();
            calculatesum();
            $('#txtTotal1').addClass("hilighted");

            $('#txtCTC').addClass("hilighted");

            $("#<%=lblVariablePay.ClientID%>").show();
            $("#<%=txtvariableearning.ClientID%>").show();


            sTABILITYHideShow();
            HideCat();

            function HideCat() {
                $('#ddlcat').hide();
                $('#lblCategory').hide();

                $('#ddlUni').hide();
                $('#lblUniversity').hide();

                $('#lblRMaxCtc').hide();
                $('#lblMaxCtc').hide();
            }



            var employee = {};
            employee.txtSearchEmployecode = $('#<%=txtSearchEmployecode.ClientID%>').val();
            employee.txtbasic = $('#<%=txtbasic.ClientID%>').val();
            employee.txtHra = $('#<%=txtHra.ClientID%>').val();
            employee.txtColonyAllowance = $('#<%=txtColonyAllowance.ClientID%>').val();
            employee.txtSpecialAllowance = $('#<%=txtSpecialAllowance.ClientID%>').val();
            employee.txtPersonelAllowance = $('#<%=txtPersonelAllowance.ClientID%>').val();
            employee.txtStablity = $('#<%=txtStablity.ClientID%>').val();
            employee.txtJoiningAllowance = $('#<%=txtJoiningAllowance.ClientID%>').val();
            employee.txtTelePhoneAllowance = $('#<%=txtTelePhoneAllowance.ClientID%>').val();
            employee.txtScooterAllowance = $('#<%=txtScooterAllowance.ClientID%>').val();
            employee.txtCarAllowance = $('#<%=txtCarAllowance.ClientID%>').val();
            employee.txtAdditionalAllowance = $('#<%=txtAdditionalAllowance.ClientID%>').val();
            employee.txtUniformAllowance = $('#<%=txtUniformAllowance.ClientID%>').val();
            employee.txtDriverAllowance = $('#<%=txtDriverAllowance.ClientID%>').val();
            employee.txtEntertainmentAllowance = $('#<%=txtEntertainmentAllowance.ClientID%>').val();
            //            employee.txtTotal1 = $('#txtTotal1').val();

            $('#lnkFetch').click(function () {
                $("#lnkFetch").attr("disabled", true);
                GetFetchValues();
            });

            function GetFetchValues() {
                $('#img0').show();
                $.ajax({
                    type: "POST",
                    url: "Jct_Payroll_PayScaleEntry.aspx/def",
                    //                    data: '{txtSearchEmployecode: "' + $("#<%=txtSearchEmployecode.ClientID%>")[0].value + '" ,txtbasic: "' + $("#<%=txtbasic.ClientID%>")[0].value + '",txtHra: "' + $("#<%=txtHra.ClientID%>")[0].value + '" ,txtColonyAllowance: "' + $("#<%=txtColonyAllowance.ClientID%>")[0].value + '",txtSpecialAllowance: "' + $("#<%=txtSpecialAllowance.ClientID%>")[0].value + '" ,txtPersonelAllowance: "' + $("#<%=txtPersonelAllowance.ClientID%>")[0].value + '",txtStablity: "' + $("#<%=txtStablity.ClientID%>")[0].value + '" ,txtJoiningAllowance: "' + $("#<%=txtJoiningAllowance.ClientID%>")[0].value + '",txtTelePhoneAllowance: "' + $("#<%=txtTelePhoneAllowance.ClientID%>")[0].value + '" ,txtScooterAllowance: "' + $("#<%=txtScooterAllowance.ClientID%>")[0].value + '",txtCarAllowance: "' + $("#<%=txtCarAllowance.ClientID%>")[0].value + '" ,txtAdditionalAllowance: "' + $("#<%=txtAdditionalAllowance.ClientID%>")[0].value + '",txtUniformAllowance: "' + $("#<%=txtUniformAllowance.ClientID%>")[0].value + '" ,txtDriverAllowance: "' + $("#<%=txtDriverAllowance.ClientID%>")[0].value + '",txtEntertainmentAllowance: "' + $("#<%=txtEntertainmentAllowance.ClientID%>")[0].value + '" ,txtTotal1: "' + $("#txtTotal1").val() + '" ,ddlHraValue: "' + $("#<%=ddlHraValue.ClientID%>")[0].value + '"}',
                    data: '{txtSearchEmployecode: "' + $("#<%=txtSearchEmployecode.ClientID%>")[0].value + '" ,txtbasic: "' + $("#<%=txtbasic.ClientID%>")[0].value + '",txtHra: "' + $("#<%=txtHra.ClientID%>")[0].value + '" ,txtColonyAllowance: "' + $("#<%=txtColonyAllowance.ClientID%>")[0].value + '",txtSpecialAllowance: "' + $("#<%=txtSpecialAllowance.ClientID%>")[0].value + '" ,txtPersonelAllowance: "' + $("#<%=txtPersonelAllowance.ClientID%>")[0].value + '",txtStablity: "' + $("#<%=txtStablity.ClientID%>")[0].value + '" ,txtJoiningAllowance: "' + $("#<%=txtJoiningAllowance.ClientID%>")[0].value + '",txtTelePhoneAllowance: "' + $("#<%=txtTelePhoneAllowance.ClientID%>")[0].value + '" ,txtScooterAllowance: "' + $("#<%=txtScooterAllowance.ClientID%>")[0].value + '",txtCarAllowance: "' + $("#<%=txtCarAllowance.ClientID%>")[0].value + '" ,txtAdditionalAllowance: "' + $("#<%=txtAdditionalAllowance.ClientID%>")[0].value + '",txtUniformAllowance: "' + $("#<%=txtUniformAllowance.ClientID%>")[0].value + '" ,txtDriverAllowance: "' + $("#<%=txtDriverAllowance.ClientID%>")[0].value + '",txtEntertainmentAllowance: "' + $("#<%=txtEntertainmentAllowance.ClientID%>")[0].value + '" ,txtTotal1: "' + $("#txtTotal1").val() + '" ,ddlHraValue: "' + $("#<%=ddlHraValue.ClientID%>")[0].value + '" ,txtltaallw: "' + $("#<%=txtltaallw.ClientID%>")[0].value + '" ,txtFurAllw: "' + $("#<%=txtFurAllw.ClientID%>")[0].value + '" ,ddldesignation: "' + $("#<%=ddldesignation.ClientID%>")[0].value + '" ,txtCarInsurance: "' + $("#<%=txtCarInsurance.ClientID%>")[0].value + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess1,
                    error: function (response) {
                        //                        var r =  JSON.parse(response.responseText);    
                        $('#img0').hide();
                        $("#lnkFetch").attr("disabled", false);
                        alert(response.responseText);
                    }
                });
            }


            function OnSuccess1(response) {
                $('#img0').hide();
                $("#lnkFetch").attr("disabled", false);
                if (response.d.txtSearchEmployecode == null) {
                    alert('No PerksValue Found Against This AutoID...');
                    return;
                }
                $('#txtPF').val(response.d.txtPF);
                $('#txtESI').val(response.d.txtESI);
                $('#txtGratuity').val(response.d.txtGratuity);
                $('#txtLTA').val(response.d.txtLTA);
                $('#txtBONUS').val(response.d.txtBONUS);
                $('#txtSuperAnnuation').val(response.d.txtSuperAnnuation);
                $('#txtEarnedLeave').val(response.d.txtEarnedLeave);
                //                $('#txtEDLI').val(response.d.txtEDLI);
                $('#<%=txtEDLI.ClientID%>').val(response.d.txtEDLI);

                $('#<%=txtGroupMedicalInsurance.ClientID%>').val(response.d.txtGroupMedicalInsurance);
                $('#<%=txtGroupPerAcceridted.ClientID%>').val(response.d.txtGroupPerAcceridted);
                $('#<%=txtGroupPerPlus.ClientID%>').val(response.d.txtGroupPerPlus);
                $('#txtCTC').val(response.d.txtCTC);
                $('#txtctcam').val(response.d.txtctcam);
                $('#<%=txtvariableearning.ClientID%>').val(response.d.txtvariableearning);
            }

            $("#<%=ddldesignation.ClientID%>").change(function () {
                ShowCurrentTime();
                ResetValues();

                if ($("#<%=ddldesignation.ClientID%>").val() == "DSG-108") {
                    $('#ddlcat').show();
                    $('#lblCategory').show();
                }
                else {
                    $('#ddlcat').hide();
                    $('#lblCategory').hide();

                    $('#ddlUni').hide();
                    $('#lblUniversity').hide();

                    $('#lblRMaxCtc').hide();
                    $('#lblMaxCtc').hide();

                    $('#ddlcat').val(0);

                }
                var RatecardIDs = ['DSG-102', 'DSG-105', 'DSG-101', 'DSG-106', 'DSG-111', 'DSG-112'];

                var looprecord;
                for (looprecord = 0; looprecord < RatecardIDs.length; ++looprecord) {
                    if ($("#<%=ddldesignation.ClientID%>").val() == RatecardIDs[looprecord]) {
                        $("#<%=txtvariableearning.ClientID%>").hide();
                        $("#<%=lblVariablePay.ClientID%>").hide();
                        return;
                    }
                    else {
                        $("#<%=lblVariablePay.ClientID%>").show();
                        $("#<%=txtvariableearning.ClientID%>").show();
                    }

                }
            });

            $('#<%=ddlHraValue.ClientID%>').change(function () {
                if ($('#<%=ddlHraValue.ClientID%>').val().length != 0) {
                    if ($("#<%=txtbasic.ClientID%>").val().length != 0) {
                        var pervalue = Math.round(($("#<%=txtbasic.ClientID%>").val() * $('#<%=ddlHraValue.ClientID%>').val()) / 100);
                        $('#<%=txtHra.ClientID%>').val(pervalue);
                        calculatesum();
                    }
                    else {
                        alert('Basic Cannot Be Empty');
                    }
                }
                else {
                    $('#<%=txtHra.ClientID%>').val('');
                    calculatesum();
                }
            });


            $('.textbox.abc').keyup(function () {
                calculatesum();
                clearControllsAllTouched();
            });

            function calculatesum() {
                var sum = 0;
                $('.textbox.abc').each(function () {
                    if ($(this).val().length != 0) {
                        sum += Number($(this).val());
                    }
                });
                $('#txtTotal1').val(Math.round(sum));
            }




            function ResetValues() {
                $('.textbox.abc').each(function () {
                    if ($(this).val().length != 0) {
                        $(this).val('');
                    }
                });
                calculatesum();
            }


            $('#<%=txtbasic.ClientID%>').blur(function () {
                $('#<%=txtHra.ClientID%>').val('');
                $('#<%=ddlHraValue.ClientID%>').val('');
                calculatesum();
            });


            function ShowCurrentTime() {
                $("#img").show();
                $.ajax({
                    type: "POST",
                    url: "Jct_Payroll_PayScaleEntry.aspx/GetCurrentTime",
                    data: '{name: "' + $("#<%=ddldesignation.ClientID%>")[0].value + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            }

            function OnSuccess(response) {
                $("#img").hide();

                if (response.d == '1') {
                    HideControls();
                    $("#<%=txtScooterAllowance.ClientID%>").show();
                    $("#<%=lblScooterAllowance.ClientID%>").show();
                }
                else if (response.d == '2') {
                    HideControls();
                    $("#<%=txtCarAllowance.ClientID%>").show();
                    $("#<%=lblCarAllowance.ClientID%>").show();

                }

                else if (response.d == '3') {

                    HideControls();
                    $("#<%=txtAdditionalAllowance.ClientID%>").show();
                    $("#<%=lblAdditionalAllowance.ClientID%>").show();

                    $("#<%=txtCarAllowance.ClientID%>").show();
                    $("#<%=lblCarAllowance.ClientID%>").show();

                    $("#<%=txtUniformAllowance.ClientID%>").show();
                    $("#<%=lblUniformAllowance.ClientID%>").show();

                }

                else if (response.d == '4') {
                    HideControls();
                    $("#<%=txtAdditionalAllowance.ClientID%>").show();
                    $("#<%=lblAdditionalAllowance.ClientID%>").show();

                    $("#<%=txtCarAllowance.ClientID%>").show();
                    $("#<%=lblCarAllowance.ClientID%>").show();

                    $("#<%=txtUniformAllowance.ClientID%>").show();
                    $("#<%=lblUniformAllowance.ClientID%>").show();

                }


                else if (response.d == '5') {
                    HideControls();
                    $("#<%=txtAdditionalAllowance.ClientID%>").show();
                    $("#<%=lblAdditionalAllowance.ClientID%>").show();

                    $("#<%=txtCarAllowance.ClientID%>").show();
                    $("#<%=lblCarAllowance.ClientID%>").show();

                    $("#<%=txtUniformAllowance.ClientID%>").show();
                    $("#<%=lblUniformAllowance.ClientID%>").show();


                    $("#<%=txtDriverAllowance.ClientID%>").show();
                    $("#<%=lblDriverAllowance.ClientID%>").show();


                    $("#<%=txtEntertainmentAllowance.ClientID%>").show();
                    $("#<%=lblEntertainmentAllowance.ClientID%>").show();

                }

                else if (response.d == '6') {
                    HideControls();
                }

            }

            function HideControls() {
                $("#<%=txtScooterAllowance.ClientID%>").hide();
                $("#<%=lblScooterAllowance.ClientID%>").hide();
                $("#<%=txtCarAllowance.ClientID%>").hide();
                $("#<%=lblCarAllowance.ClientID%>").hide();
                $("#<%=txtAdditionalAllowance.ClientID%>").hide();
                $("#<%=lblAdditionalAllowance.ClientID%>").hide();
                $("#<%=txtUniformAllowance.ClientID%>").hide();
                $("#<%=lblUniformAllowance.ClientID%>").hide();
                $("#<%=txtScooterAllowance.ClientID%>").hide();
                $("#<%=lblScooterAllowance.ClientID%>").hide();
                $("#<%=txtDriverAllowance.ClientID%>").hide();
                $("#<%=lblDriverAllowance.ClientID%>").hide();
                $("#<%=txtEntertainmentAllowance.ClientID%>").hide();
                $("#<%=lblEntertainmentAllowance.ClientID%>").hide();

            }

            $("#<%=txtSearchEmployecode0.ClientID%>").blur(function () {

                
                if ($("#<%=txtSearchEmployecode0.ClientID%>").val().length > 6) {
                    
                    sTABILITYHideShow();
                    clearControllsAll();
                    SearchAutoID();                        
                }
                else {
                    alert('InValid AutoID. Please Check AutoID');
                    $("#<%=txtSearchEmployecode0.ClientID%>").val('');
                }
            });


            function SearchAutoID() {
                $('#imgwait').show();
                $.ajax({
                    type: "POST",
                    url: "Jct_Payroll_PayScaleEntry.aspx/search",
                    data: '{code: "' + $("#<%=txtSearchEmployecode0.ClientID%>")[0].value + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess2,
                    error: function (response) {
                        $('#imgwait').hide();
                        $('#<%=lblAutoID.ClientID%>').show();
                        $('#<%=txtSearchEmployecode.ClientID%>').show();
                        $('#<%=lnkUpdate.ClientID%>').hide();
                        $('#<%=lnkadd.ClientID%>').show();
                        alert(response.responseText);
                    }
                });
            }

            function OnSuccess2(response) {
                $('#imgwait').hide();
                if (response.d.txtSearchEmployecode == null) {
                    $('#<%=lblAutoID.ClientID%>').show();
                    $('#<%=txtSearchEmployecode.ClientID%>').show();
                    $('#<%=lnkUpdate.ClientID%>').hide();
                    $('#<%=lnkadd.ClientID%>').show();
                    alert('No Record Found Against This AutoID...');
                    $("#<%=txtSearchEmployecode0.ClientID%>").val('');
                    return;
                }
                else {
                    $('#<%=lnkadd.ClientID%>').hide();
                    $('#<%=lnkUpdate.ClientID%>').show();
                    $('#<%=lblAutoID.ClientID%>').hide();
                    $('#<%=txtSearchEmployecode.ClientID%>').hide();
                    $('#<%=txtbasic.ClientID%>').val(response.d.txtbasic);
                    $('#<%=txtHra.ClientID%>').val(response.d.txtHra);
                    $('#<%=txtColonyAllowance.ClientID%>').val(response.d.txtColonyAllowance);
                    $('#<%=txtSpecialAllowance.ClientID%>').val(response.d.txtSpecialAllowance);
                    $('#<%=txtPersonelAllowance.ClientID%>').val(response.d.txtPersonelAllowance);
                    $('#<%=txtStablity.ClientID%>').val(response.d.txtStablity);
                    $('#<%=txtJoiningAllowance.ClientID%>').val(response.d.txtJoiningAllowance);
                    $('#<%=txtTelePhoneAllowance.ClientID%>').val(response.d.txtTelePhoneAllowance);
                    $('#<%=txtScooterAllowance.ClientID%>').val(response.d.txtScooterAllowance);
                    $('#<%=txtCarAllowance.ClientID%>').val(response.d.txtCarAllowance);
                    $('#<%=txtAdditionalAllowance.ClientID%>').val(response.d.txtAdditionalAllowance);
                    $('#<%=txtUniformAllowance.ClientID%>').val(response.d.txtUniformAllowance);
                    $('#<%=txtDriverAllowance.ClientID%>').val(response.d.txtDriverAllowance);
                    $('#<%=txtEntertainmentAllowance.ClientID%>').val(response.d.txtEntertainmentAllowance);
                    $('#txtTotal1').val(response.d.txtTotal1);
                    $('#txtPF').val(response.d.txtPF);
                    $('#txtESI').val(response.d.txtESI);
                    $('#txtGratuity').val(response.d.txtGratuity);
                    $('#txtLTA').val(response.d.txtLTA);
                    $('#txtBONUS').val(response.d.txtBONUS);
                    $('#txtSuperAnnuation').val(response.d.txtSuperAnnuation);
                    $('#txtEarnedLeave').val(response.d.txtEarnedLeave);

                    //$('#txtEDLI').val(response.d.txtEDLI);
                    $('#<%=txtEDLI.ClientID%>').val(response.d.txtEDLI);

                    $('#<%=txtGroupMedicalInsurance.ClientID%>').val(response.d.txtGroupMedicalInsurance);
                    $('#<%=txtGroupPerAcceridted.ClientID%>').val(response.d.txtGroupPerAcceridted);

                    $('#<%=txtGroupPerPlus.ClientID%>').val(response.d.txtGroupPerPlus);

                    $('#txtCTC').val(response.d.txtCTC);
                    $('#<%=ddlHraValue.ClientID%>').val(response.d.ddlHraValue);

                    $('#<%=ddldesignation.ClientID%>').val(response.d.ddldesignation);


                    $('#<%=txtvariableearning.ClientID%>').val(response.d.txtvariableearning);
                    $('#txtctcam').val(response.d.txtctcam);

                    $('#<%=txtFurAllw.ClientID%>').val(response.d.txtFurAllw);
                    $('#<%=txtltaallw.ClientID%>').val(response.d.txtltaallw);

                    $('#<%=txtCarInsurance.ClientID%>').val(response.d.txtCarInsurance);

                    ShowCurrentTime();
                }
            }


            function clearControllsAll() {
                $('#<%=txtbasic.ClientID%>').val('');
                $('#<%=txtHra.ClientID%>').val('');
                $('#<%=txtColonyAllowance.ClientID%>').val('');
                $('#<%=txtSpecialAllowance.ClientID%>').val('');
                $('#<%=txtPersonelAllowance.ClientID%>').val('');
                $('#<%=txtStablity.ClientID%>').val('');
                $('#<%=txtJoiningAllowance.ClientID%>').val('');
                $('#<%=txtTelePhoneAllowance.ClientID%>').val('');
                $('#<%=txtScooterAllowance.ClientID%>').val('');
                $('#<%=txtCarAllowance.ClientID%>').val('');
                $('#<%=txtAdditionalAllowance.ClientID%>').val('');
                $('#<%=txtUniformAllowance.ClientID%>').val('');
                $('#<%=txtDriverAllowance.ClientID%>').val('');
                $('#<%=txtEntertainmentAllowance.ClientID%>').val('');
                $('#txtTotal1').val('');
                $('#txtPF').val('');
                $('#txtESI').val('');
                $('#txtGratuity').val('');
                $('#txtLTA').val('');
                $('#txtBONUS').val('');
                $('#txtSuperAnnuation').val('');
                $('#txtEarnedLeave').val('');
                //$('#txtEDLI').val('');

                $('#<%=txtEDLI.ClientID%>').val('');

                $('#<%=txtGroupMedicalInsurance.ClientID%>').val('');
                $('#<%=txtGroupPerAcceridted.ClientID%>').val('');
                $('#<%=txtGroupPerPlus.ClientID%>').val('');
                $('#txtCTC').val('');
                $('#<%=ddlHraValue.ClientID%>').val('');
                $('#txtctcam').val('');

                $('#<%=txtFurAllw.ClientID%>').val('');
                $('#<%=txtltaallw.ClientID%>').val('');

                $('#<%=txtCarInsurance.ClientID%>').val('');

                //                $('#txtCTC').val('');
            }


            function clearControllsAllTouched() {
                $('#txtPF').val('');
                $('#txtESI').val('');
                $('#txtGratuity').val('');
                $('#txtLTA').val('');
                $('#txtBONUS').val('');
                $('#txtSuperAnnuation').val('');
                $('#txtEarnedLeave').val('');
                //$('#txtEDLI').val('');

                $('#<%=txtEDLI.ClientID%>').val('');
                $('#<%=txtGroupMedicalInsurance.ClientID%>').val('');
                $('#<%=txtGroupPerAcceridted.ClientID%>').val('');
                $('#<%=txtGroupPerPlus.ClientID%>').val('');
                $('#txtCTC').val('');
                $('#txtctcam').val('');
                $('#<%=txtvariableearning.ClientID%>').val('');
            }

            //Category DropDownWorking(Start) 
            $("#ddlcat").change(function () {

                $('#img').show();
                $('#ddlUni').find('option').remove().end().append('<option value="0">--Select University--</option>');

                SearchUni();
                $('#lblRMaxCtc').text('');
                $('#lblRMaxCtc').hide();
                $('#lblMaxCtc').hide();
            });

            function SearchUni() {
                $.ajax({
                    type: "POST",
                    url: "Jct_Payroll_PayScaleEntry.aspx/GetCountriesName",
                    data: '{code: "' + $("#ddlcat").val() + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessUni,
                    error: function (response) {
                        $('#img').hide();
                        $('#lblRMaxCtc').text('');
                        alert(response.responseText);
                    }
                });
            }

            function OnSuccessUni(response) {
                $('#img').hide();

                if (response.d != null) {
                    $('#ddlUni').show();
                    $('#lblUniversity').show();
                    $.each(response.d, function (data, value) {
                        $("#ddlUni").append($("<option></option>").val(value.CountryId).html(value.CountryName));
                    })
                }
                else {
                    $('#lblRMaxCtc').text('');
                    $('#lblRMaxCtc').hide();
                    $('#lblMaxCtc').hide();
                    alert('No University Found For This Category');
                }

            }
            //Category DropDownWorking(End)



            //University DropDownWorking(Start) 
            $("#ddlUni").change(function () {
                $('#img').show();
                SearchCtc()
            });

            function SearchCtc() {
                $.ajax({
                    type: "POST",
                    url: "Jct_Payroll_PayScaleEntry.aspx/GetMaxCtc",
                    data: '{code: "' + $("#ddlcat").val() + '" , Uni: "' + $("#ddlUni").val() + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessCtc,
                    error: function (response) {
                        $('#img').hide();
                        alert(response.responseText);
                    }
                });
            }

            function OnSuccessCtc(response) {
                $('#img').hide();
                if (response.d != 0) {
                    $('#lblMaxCtc').show();
                    $('#lblRMaxCtc').show();

                    $('#lblRMaxCtc').text(response.d);
                }
                else {
                    alert('No Ctc Found For This University Against This Category');
                    $('#lblRMaxCtc').text('');
                    $('#lblMaxCtc').hide();
                    $('#lblRMaxCtc').hide();

                }
            }


            $('.textbox.ctc').keyup(function () {
                calculatectc();
            });

            function calculatectc() {
                var sumctc = 0;
                $('.textbox.ctc').each(function () {
                    if ($(this).val().length != 0) {
                        sumctc += Number($(this).val());
                    }
                });
                if ($('#txtTotal1').val().length != 0) {

                    var totear = Number($('#txtTotal1').val());
                    var calctc = Math.round(Number((totear) + Number(sumctc)));

                    $('#txtCTC').val(calctc);
                    var storepre = $('#txtCTC').val();

                    var ctcam = Math.round(storepre * 12);
                    $('#txtctcam').val(ctcam);

                }
            }


            $('input[name=radioName]').click(function () {
                sTABILITYHideShow();
            });


            function sTABILITYHideShow() {
                if ($('input[name=radioName]:checked').val() == "Fresher") {
                    $('#<%=lblStabilityAllw.ClientID%>').show();
                    $('#<%=txtStablity.ClientID%>').show();
                }
                else {
                    $('#<%=lblStabilityAllw.ClientID%>').hide();
                    $('#<%=txtStablity.ClientID%>').hide();
                }

            }

            $("#btnnext").bind("click", function () {
                var url = "Jct_Payroll_PayScaleMapping.aspx";
                window.location.href = url;
            });
    

        })

      

    </script>
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="6">
                Pay Scale:
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Search
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtSearchEmployecode0" Width="85px" runat="server" CssClass="textbox"
                    MaxLength="10" ToolTip="Search AutoID like EMP-101"></asp:TextBox>
            </td>
            <td class="labelcells">
                <img src="/fusionapps/OPS/Image/loadingNew.gif" alt="Sample Image" id="imgwait" />
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            <input type="button" id="btnnext" value="Next"  class="buttonc" />

                  
            
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="6">
                For Multiple Attempts
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="6">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Type
            </td>
            <td class="labelcells" colspan="5">
                <input type="radio" name="radioName" checked value="Fresher" />
                Fresher            
                <input type="radio" name="radioName" value="Experience" />
                Experience
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblAutoID" runat="server">AutoID</asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtSearchEmployecode" runat="server" AutoCompleteType="Disabled"
                    Width="85px" CssClass="textbox" MaxLength="10" ToolTip="AutoID Generated For Tracking like EMP-101"
                    OnTextChanged="txtSearchEmployecode_TextChanged" Enabled="false"></asp:TextBox>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Designation
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldesignation" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                <img src="/fusionapps/OPS/Image/loadingNew.gif" alt="Sample Image" id="img" />
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <label id="lblCategory">
                    Category</label>
            </td>
            <td class="NormalText">
                <select id="ddlcat" class="combobox">
                    <option value="0">--Select Category--</option>
                    <option value="1">MBA/GRADE-A</option>
                    <option value="2">MBA/GRADE-B</option>
                    <option value="3">DIPLOMA</option>
                    <option value="4">GRADUATE</option>
                </select>
            </td>
            <td class="labelcells">
                <label id="lblUniversity">
                    University</label>
            </td>
            <td class="NormalText">
                <select id="ddlUni" class="combobox">
                    <option value="0">--Select University--</option>
                </select>
            </td>
            <td class="labelcells">
                <label id="lblMaxCtc">
                    MaxCTC</label>
            </td>
            <td class="labelcells">
                <%--<asp:Label ID="lblRMaxCtc" runat="server"></asp:Label>--%>
                <label id="lblRMaxCtc">
                </label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Basic
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtbasic" runat="server" CssClass="textbox abc" Width="85px" MaxLength="10"
                    Text="1000"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1basic" runat="server" FilterType="Custom"
                    TargetControlID="txtbasic" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3qwebasic" runat="server" ControlToValidate="txtbasic"
                    Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                Hra%
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlHraValue" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="30">30</asp:ListItem>
                    <asp:ListItem Value="40">40</asp:ListItem>
                    <asp:ListItem Value="50">50</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                HRA
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtHra" runat="server" CssClass="textbox abc" Width="85px" MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderhra1" runat="server" FilterType="Custom"
                    TargetControlID="txtHra" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorhra1" runat="server" ControlToValidate="txtHra"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                ColonyAllw
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtColonyAllowance" Width="85px" runat="server" CssClass="textbox abc"
                    MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtendercolony1" runat="server" FilterType="Custom"
                    TargetControlID="txtColonyAllowance" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorcoony1" runat="server" ControlToValidate="txtColonyAllowance"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
            <td class="labelcells">
                SpecialAllw
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtSpecialAllowance" runat="server" Width="85px" CssClass="textbox abc"
                    MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderspecial1" runat="server"
                    FilterType="Custom" TargetControlID="txtSpecialAllowance" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorspecial1" runat="server" ControlToValidate="txtSpecialAllowance"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
            <td class="labelcells">
                PersonelAllw
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtPersonelAllowance" runat="server" CssClass="textbox abc" Width="85px"
                    MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderperonso2" runat="server"
                    FilterType="Custom" TargetControlID="txtPersonelAllowance" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorpersonaol2" runat="server" ControlToValidate="txtPersonelAllowance"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblStabilityAllw" runat="server">StabilityAllw</asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtStablity" Width="85px" runat="server" CssClass="textbox abc"
                    MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderstabilty1" runat="server"
                    FilterType="Custom" TargetControlID="txtStablity" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorstablilty1" runat="server" ControlToValidate="txtStablity"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
            <td class="labelcells">
                JoiningAllw
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtJoiningAllowance" runat="server" Width="85px" CssClass="textbox abc"
                    MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderjoing2" runat="server" FilterType="Custom"
                    TargetControlID="txtJoiningAllowance" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorjoing2" runat="server" ControlToValidate="txtJoiningAllowance"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
            <td class="labelcells">
                TelePhoneAllw
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtTelePhoneAllowance" runat="server" CssClass="textbox abc" Width="85px"
                    MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtendertele3" runat="server" FilterType="Custom"
                    TargetControlID="txtTelePhoneAllowance" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidatortele3" runat="server" ControlToValidate="txtTelePhoneAllowance"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblScooterAllowance" runat="server">ScooterAllw</asp:Label>
            </td>
            <td class="NormalText">
                <%-- <asp:DropDownList ID="ddlScooterAllowance" runat="server" CssClass="combobox" AutoPostBack="True">
                        </asp:DropDownList>--%>
                <asp:TextBox ID="txtScooterAllowance" runat="server" Width="85px" CssClass="textbox abc"
                    MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderscooter1" runat="server"
                    FilterType="Custom" TargetControlID="txtScooterAllowance" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblCarAllowance" runat="server">CarAllw</asp:Label>
            </td>
            <td class="NormalText">
                <%--<asp:DropDownList ID="ddlCarAllowance" runat="server" CssClass="combobox" AutoPostBack="True">
                        </asp:DropDownList>--%>
                <asp:TextBox ID="txtCarAllowance" runat="server" CssClass="textbox abc" Width="85px"
                    MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1sas" runat="server" FilterType="Custom"
                    TargetControlID="txtCarAllowance" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblAdditionalAllowance" runat="server">AdditionalAllw</asp:Label>
            </td>
            <td class="NormalText">
                <%--<asp:DropDownList ID="ddlAdditionalAllowance" runat="server" CssClass="combobox" AutoPostBack="True">
                        </asp:DropDownList>--%>
                <asp:TextBox ID="txtAdditionalAllowance" runat="server" CssClass="textbox abc" Width="85px"
                    MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtendeasdasdr1" runat="server" FilterType="Custom"
                    TargetControlID="txtAdditionalAllowance" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblUniformAllowance" runat="server">UniformAllw</asp:Label>
            </td>
            <td class="NormalText">
                <%-- <asp:DropDownList ID="ddlUniformAllowance" runat="server" CssClass="combobox" AutoPostBack="True">
                        </asp:DropDownList>--%>
                <asp:TextBox ID="txtUniformAllowance" Width="85px" runat="server" CssClass="textbox abc"
                    MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTeasxtBoxExteassdnder1" runat="server" FilterType="Custom"
                    TargetControlID="txtUniformAllowance" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblDriverAllowance" runat="server">DriverAllw</asp:Label>
            </td>
            <td class="NormalText">
                <%-- <asp:DropDownList ID="ddlDriverAllowance" runat="server" CssClass="combobox" AutoPostBack="True">
                        </asp:DropDownList>--%>
                <asp:TextBox ID="txtDriverAllowance" runat="server" Width="85px" CssClass="textbox abc"
                    MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExteasdasdsdnder1" runat="server"
                    FilterType="Custom" TargetControlID="txtDriverAllowance" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblEntertainmentAllowance" runat="server">EntertainmentAllw</asp:Label>
            </td>
            <td class="NormalText">
                <%--<asp:DropDownList ID="ddlEntertainmentAllowance" runat="server" CssClass="combobox" AutoPostBack="True">
                        </asp:DropDownList>--%>
                <asp:TextBox ID="txtEntertainmentAllowance" runat="server" Width="85px" CssClass="textbox abc"
                    MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenasdasddeasdasdr1" runat="server"
                    FilterType="Custom" TargetControlID="txtEntertainmentAllowance" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblltaallw" runat="server">LtaAllw</asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtltaallw" Width="85px" runat="server" CssClass="textbox abc" MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderltaallw1" runat="server"
                    FilterType="Custom" TargetControlID="txtltaallw" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblFurAllw" runat="server">FurAllw</asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtFurAllw" Width="85px" runat="server" CssClass="textbox abc" MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxEasdasdxtender1" runat="server" FilterType="Custom"
                    TargetControlID="txtFurAllw" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="labelcells">                
                <asp:Label ID="lblCarInsurance" runat="server">CarInsurance</asp:Label>
            </td>
            <td class="NormalText">
          <asp:TextBox ID="txtCarInsurance" Width="85px" runat="server" CssClass="textbox abc" MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExteasdasdasdnder1" runat="server" FilterType="Custom"
                    TargetControlID="txtCarInsurance" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                MonthlyEarnings
            </td>
            <td class="NormalText">
                <input id="txtTotal1" name="txtTotal1" class="textbox" readonly="readonly" style="width: 85px;
                    background-color: green" type="text" />
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <img src="/fusionapps/OPS/Image/loadingNew.gif" alt="Sample Image" id="img0" />
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="6">
                <%--<asp:UpdatePanel ID="UpdatePanel31" runat="server">
                    <ContentTemplate>--%>
                <%--    <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                             CausesValidation="False" >Fetch</asp:LinkButton> --%>
                <button class="buttonc" type="button" id="lnkFetch" name="lnkFetch">
                    Fetch</button>
                <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
        <tr>
            <td class="labelcells_s" colspan="3" style="height: 17px">
            </td>
            <td class="labelcells_s" colspan="3" style="height: 17px">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                PF
            </td>
            <td class="NormalText">
                <input id="txtPF" name="txtPF" class="textbox ctc" readonly="readonly" style="width: 85px;" type="text" />
                <%--<asp:TextBox ID="txtPF" runat="server" CssClass="textbox" MaxLength="10" Width = "85px" 
                            ></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1pf" runat="server" FilterType="Custom"
                            TargetControlID="txtPF" ValidChars="0.123456789">
                        </cc1:FilteredTextBoxExtender>--%>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorpf1" runat="server" ControlToValidate="txtPF"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
            <td class="labelcells">
                ESI
            </td>
            <td class="NormalText">
                <input id="txtESI" name="txtESI" class="textbox ctc" readonly="readonly" style="width: 85px;" type="text" />
                <%--<asp:TextBox ID="txtESI" runat="server" CssClass="textbox" Width = "85px"   MaxLength="10"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderesi1" runat="server" FilterType="Custom"
                            TargetControlID="txtESI" ValidChars="0.123456789">
                        </cc1:FilteredTextBoxExtender>--%>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatoresi1" runat="server" ControlToValidate="txtESI"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
            <td class="labelcells">
                Gratuity
            </td>
            <td class="NormalText">
                <input id="txtGratuity" name="txtGratuity" class="textbox ctc" readonly="readonly" style="width: 85px;"
                    type="text" />
                <%--<asp:TextBox ID="txtGratuity" runat="server" CssClass="textbox"  Width = "85px"   MaxLength="10"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtendeGratuityr2" runat="server" FilterType="Custom"
                            TargetControlID="txtGratuity" ValidChars="0.123456789">
                        </cc1:FilteredTextBoxExtender>--%>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorGratuity2" runat="server" ControlToValidate="txtGratuity"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                LTA
            </td>
            <td class="NormalText">
                <input id="txtLTA" name="txtLTA" class="textbox ctc" readonly="readonly" style="width: 85px;" type="text" />
                <%--<asp:TextBox ID="txtLTA" runat="server" CssClass="textbox"  Width = "85px"   MaxLength="10"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderLTA1" runat="server" FilterType="Custom"
                            TargetControlID="txtLTA" ValidChars="0.123456789">
                        </cc1:FilteredTextBoxExtender>--%>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorLTA1" runat="server" ControlToValidate="txtLTA"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
            <td class="labelcells">
                Bonus
            </td>
            <td class="NormalText">
                <input id="txtBONUS" name="txtBONUS" class="textbox ctc" readonly="readonly" style="width: 85px;" type="text" />
                <%--<asp:TextBox ID="txtBONUS" runat="server" CssClass="textbox"  Width = "85px"  MaxLength="10"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderBONUS2" runat="server" FilterType="Custom"
                            TargetControlID="txtBONUS" ValidChars="0.123456789">
                        </cc1:FilteredTextBoxExtender>--%>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorBONUS2" runat="server" ControlToValidate="txtBONUS"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
            <td class="labelcells">
                SuperAnnuation
            </td>
            <td class="NormalText">
                <input id="txtSuperAnnuation" name="txtSuperAnnuation" readonly="readonly" class="textbox ctc" style="width: 85px;"
                    type="text" />
                <%--<asp:TextBox ID="txtSuperAnnuation" runat="server" CssClass="textbox" Width = "85px"   MaxLength="10"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderSuperAnnuation3" runat="server" FilterType="Custom"
                            TargetControlID="txtSuperAnnuation" ValidChars="0.123456789">
                        </cc1:FilteredTextBoxExtender>--%>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorSuperAnnuation3" runat="server" ControlToValidate="txtSuperAnnuation"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                EarnedLeave
            </td>
            <td class="NormalText">
                <input id="txtEarnedLeave" name="txtEarnedLeave"  readonly="readonly" class="textbox ctc" style="width: 85px;"
                    type="text" />
                <%--<asp:TextBox ID="txtEarnedLeave" runat="server" CssClass="textbox"  Width = "85px"   MaxLength="10"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtendeEarnedLeaver1" runat="server" FilterType="Custom"
                            TargetControlID="txtEarnedLeave" ValidChars="0.123456789">
                        </cc1:FilteredTextBoxExtender>--%>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatoEarnedLeaver1" runat="server" ControlToValidate="txtEarnedLeave"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
            <td class="labelcells">
                EDLI
            </td>
            <td class="NormalText">
                <%--<input id="txtEDLI" name="txtEDLI"  readonly="readonly"  class="textbox ctc" style="width: 85px;" type="text" />--%>

                <asp:TextBox ID="txtEDLI" runat="server" CssClass="textbox ctc" Width="85px"
                    MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtendewerqweq21131" runat="server"
                    FilterType="Custom" TargetControlID="txtEDLI" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>


                <%--<asp:TextBox ID="txtEDLI" runat="server" CssClass="textbox"  Width = "85px"   MaxLength="10"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtendeEDLIr2" runat="server" FilterType="Custom"
                            TargetControlID="txtEDLI" ValidChars="0.123456789">
                        </cc1:FilteredTextBoxExtender>--%>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatoEDLIr2" runat="server" ControlToValidate="txtEDLI"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
            <td class="labelcells">
                GroupMedicalInsurance
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtGroupMedicalInsurance" runat="server" CssClass="textbox ctc"  
                    Width="85px" MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderGroupMedicalInsurance3" runat="server"
                    FilterType="Custom" TargetControlID="txtGroupMedicalInsurance" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorGroupMedicalInsurance3" runat="server" ControlToValidate="txtGroupMedicalInsurance"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                GroupPerAccident
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtGroupPerAcceridted" runat="server" CssClass="textbox ctc" Width="85px"
                    MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtendeGroupPerAcceridtedr1" runat="server"
                    FilterType="Custom" TargetControlID="txtGroupPerAcceridted" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorGroupPerAcceridted1" runat="server" ControlToValidate="txtGroupPerAcceridted"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
            <td class="labelcells">
                GroupTermPolicy
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtGroupPerPlus" runat="server" CssClass="textbox ctc" Width="85px"
                    MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderGroupPerPlus2" runat="server"
                    FilterType="Custom" TargetControlID="txtGroupPerPlus" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorGroupPerPlus2" runat="server" ControlToValidate="txtGroupPerPlus"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblVariablePay" runat="server">VariablePay</asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtvariableearning" runat="server" CssClass="textbox ctc" Width="85px"
                    MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtendeasdasr2" runat="server" FilterType="Custom"
                    TargetControlID="txtvariableearning" ValidChars="0.123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                CTCPM
            </td>
            <td class="NormalText">
                <input id="txtCTC" name="txtCTC" class="textbox" style="width: 85px;" type="text" />
                <%--<asp:TextBox ID="txtCTC" runat="server" CssClass="textbox" Width = "85px" Enabled="False"  MaxLength="10"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderCTC1" runat="server" FilterType="Custom"
                            TargetControlID="txtCTC" ValidChars="0.123456789">--%>
                <%--</cc1:FilteredTextBoxExtender>--%>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorCTC1" runat="server" ControlToValidate="txtCTC"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
            <td class="labelcells">
                CTCAM
            </td>
            <td class="NormalText">
                <input id="txtctcam" name="txtctcam" class="textbox" style="width: 85px;" type="text" />
                <%--<asp:TextBox ID="txtctcam" runat="server" CssClass="textbox" Width = "85px"  Enabled="False"  MaxLength="10"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                            TargetControlID="txtctcam" ValidChars="0.123456789">
                        </cc1:FilteredTextBoxExtender>--%>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorCTC1" runat="server" ControlToValidate="txtCTC"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="6">
                <%--  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>--%>
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" Text="Save" OnClick="lnkadd_Click"
                    ValidationGroup="B"></asp:LinkButton>
                <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="buttonc" Text="Update" ValidationGroup="B"
                    OnClick="lnkUpdate_Click"></asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                    OnClick="lnkreset_Click">Reset</asp:LinkButton>
                    <asp:LinkButton ID="lblVarpay" runat="server" CssClass="buttonc" 
                    Text="VariablePay" onclick="lblVarpay_Click" 
                    ></asp:LinkButton>

                    <asp:LinkButton ID="lnkctcenty" runat="server" CssClass="buttonc" 
                    Text="CTCEntry" onclick="lnkctcenty_Click" 
                    ></asp:LinkButton>

                    
                     
                <%--    </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
    </table>
    <div class="danger">
        <p>
            <strong>NOTE 1.</strong> FOR PHAGWARA VARIABLE PAY IS APPLICABLE (A).DEPT MANAGER
            AND MANAGER IN (MARKTING) (B) AGM AND ABOVE(ALL DEPARTMENTS)
        </p>
        <p>
            <strong>2.</strong> FOR HOSHIARPUR VARIABLE PAY IS APPLICABLE TO MANAGER AND ABOVE.
        </p>
    </div>
</asp:Content>
