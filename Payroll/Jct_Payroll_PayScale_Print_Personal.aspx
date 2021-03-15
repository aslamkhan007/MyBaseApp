<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Jct_Payroll_PayScale_Print_Personal.aspx.cs" Inherits="Payroll_Jct_Payroll_PayScale_Print_Personal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="jquery-1.11.3.js" type="text/javascript"></script>
    <script src="jquery-ui.1.11.3.js" type="text/javascript"></script>
    <link href="jquery-ui.1.11.3.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #HoldForm
        {
            margin: 0;
            padding: 1em 0;
            border: 1px Solid black;
        }
        body
        {
            font-family: arial, sans-serif;
            font-size: 12px;
        }
        
        regenerateTable
        {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 50%;
            color: red;
        }
        
        table
        {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }
        
        tr td
        {
            border-bottom: 1px solid black;
        }
        td, th
        {
            border: 1px solid #dddddd;
            text-align: left;
            padding: 3px;
        }
        
        
        div#as
        {
            text-align: center;
            padding: 0px;
            margin: 0px;
        }
        
        
        div#a
        {
            text-align: center;
            padding: 0px;
            margin: 0px;
        }
        
        div#b
        {
            text-align: center;
            padding: 0px;
            margin: 5px;
        }
        
        #RightSide
        {
            float: right;
            margin-right: 20px;
        }
        
        
        #RightSide div
        {
            padding: 5px;
        }
        
        #LeftSide
        {
            float: left;
            margin-left: 20px;
        }
        
        
        #LeftSide div
        {
            padding: 5px;
        }
        
        .box1
        {
            display: block;
            padding: 10px;
            margin-bottom: 79px;
            text-align: justify;
        }
        
        
        .box2
        {
            display: block;
            padding: 10px;
            margin-bottom: 5px;
            text-align: justify;
        }
        
        
        #Allowances
        {
            margin-bottom: 28px;
            margin-left: 20px;
             margin-right: 20px;
             
        }
   
   
        #Allowances tr th
        {
            width: 33.9%;
             
        }
        
        #comcontribute
        {
            margin-bottom: 8px;
            margin-left: 20px;
             margin-right: 20px;
        }
        
        #comcontribute tr th
        {
            width: 33.9%;
             
        }
        
        
        #candidate
        {
            margin-top: 30px;
            margin-left: 10%;
        }
        
        
        #botoommarginset
        {
            margin-top: 0px;
        }
        
        #plus div
        {
            padding: 3px;
            margin-left: 20px;
             margin-right: 20px;
      
        }
        
        #plus1 
        {           
            margin-bottom : 20px;      
        }
        
        
        .botoommarginset40px
        {
            margin-top: 300px;
        }
        
        
        .botoommarginsetnon
        {
            margin-top: 0px;
        }   
                              
        
    </style>
</head>
<body>
    <form id="MyFormControl">

    <div id="HoldForm">
        <div class="box1">

       

            <div id="a">
             <div id="Div1">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/OPS/Image/JCTLogoCR.png" Width="45px"
                        Height="45px" />
                </div>
                <u><b>JCT LIMITED  <label id="lblPlant"></label></b></u>
            </div>
            <div id="b">
                <b>CTC SHEET</b>
            </div>
            <div id="LeftSide">
                <div>
                    <label>
                        NAME:</label>
                    <label id="lblNameo">
                    </label>
                </div>
                <div>
                    <label>
                        QUALIFICATION :</label>
                    <label id="lblqualio">
                    </label>
                </div>
                <div>
                    <label>
                        EXPERIENCE :</label>
                    <label id="lblexpo">
                    </label>
                </div>
                <div>
                    <label>
                        DESIGNATION:</label>
                    <label id="lbldesgo">
                    </label>
                </div>
            </div>
            <div id="RightSide">
                <div>
                </div>
                <div>
                    <label>
                        YEAR OF PASSING :</label>
                    <label id="lblYearPasso">
                    </label>
                </div>
                <div>
                </div>
                <div>
                    <label>
                        DEPARTMENT :</label>
                    <label id="lbldepto">
                    </label>
                </div>
            </div>
        </div>
        <div class="box2">
            <div id="as">
                BREAK-UP OF MONTHLY/ANNUAL CTC
            </div>
        </div>
        <div id="Allowances">
            <table id="Allowances1">
                <tr>
                    <th>
                        NAME
                    </th>
                    <th>
                        PER MONTH
                    </th>
                    <th>
                        PER ANNUM
                    </th>
                </tr>
            </table>
        </div>
        <div style = "margin-left: 20px;">
            <u>COMPANY CONTRIBUTION / VALUE </u>
        </div>
        <div id="comcontribute">
            <table id="comcontribute1">
                <tr>
                    <th>
                        NAME
                    </th>
                    <th>
                        PER MONTH
                    </th>
                    <th>
                        PER ANNUM
                    </th>
                </tr>
            </table>
        </div>

        <div id="plus1">
        <div id="plus">
            
            <div>
                <label>
                    PROBATION PERIOD</label>
                :
                <label id="lblprobo">
                </label>
            </div>
            <div>
                <label>
                    DATE OF JOINING</label>
                :
                <label id="lblDojo">
                </label>
            </div>            
        </div>
        </div>

        <div id = "botoommargindiv" class = "botoommarginset">
            <div id="d1" style="float: left; margin-left: 20px; margin-right: 130px;">
                Candidate</div>
				
				<%--<div id="d1s" style=" float: left; margin-left: 20px; margin-right: 90px;" >
                HOD</div>--%>
				
            <div id="d2" style="float: left; margin-left: 05px; margin-right: 20px;">
                Sr.G.M(IT.HR & ADMIN)</div>
            <div id="d3" style="float: left;  margin-right: 10px;">
                Unit Head</div>
            <div id="d4" style="float: right; margin-right: 20px;">
                BuisnessHead</div>
        </div>
    </div>
    <div style="margin-top: 26px;">
        Note:- If a candidate stays in Company Accomodation,then he shall be eligible for
        the colony allowance, as per company policy and HRA shall not be paid.
    </div>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {

            var name = GetParameterValues('name');
            var code = GetParameterValues('code');

            function GetParameterValues(param) {

                var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
                for (var i = 0; i < url.length; i++) {
                    var urlparam = url[i].split('=');
                    if (urlparam[0] == param) {
                        //                        return urlparam[1].replace('%20', ' ');                        
                        return urlparam[1].replace(/%20/gi, ' ');
                    }
                }
            }

            ResetOtherDetails();
            SaveValues();

            function SaveValues() {
                $.ajax({
                    url: "Jct_Payroll_PayScale_Print.aspx/Fetch",
                    //                    data: "{ 'code': '" + code + "'}",
                    data: "{ 'code': '" + code + "' ,'name': '" + name + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {

                        if (data.d.OtherDetails.EmployeeName != null) {
                            $('#lblNameo').text(data.d.OtherDetails.EmployeeName);
                            $('#lblqualio').text(data.d.OtherDetails.Qualification);
                            $('#lblexpo').text(data.d.OtherDetails.Experience);
                            $('#lbldesgo').text(data.d.OtherDetails.Designation);
                            $('#lblYearPasso').text(data.d.OtherDetails.Department);
                            $('#lbldepto').text(data.d.OtherDetails.Department);
                            $('#lblprobo').text(data.d.OtherDetails.ProbationPd);
                            $('#lblDojo').text(data.d.OtherDetails.Dateofjoining);
                            //$('#lbloffacco').text(data.d.OtherDetails.OfferAccepted);
                            $('#lblYearPasso').text(data.d.OtherDetails.YearOFPassing);
                            $('#lblPlant').text(data.d.OtherDetails.Plant);
                        }
                        else {
                            alert('No Record Found Against Employee');
                            //                            $('#MyFormControl').hide();
                            return;
                        }

                        var firstgridrec = 1;
                        for (var i = 0; i < data.d.TableEarning.length; i++) {
                            firstgridrec = i + 1;
                            $("#Allowances1").append("<tr><td>" + data.d.TableEarning[i].Allowance + "</td><td>" + data.d.TableEarning[i].Amount + "</td><td>" + data.d.TableEarning[i].PerAnnum + "</td></tr>");
                        }
                        var Secondgridrec = 1;
                        for (var i = 0; i < data.d.TableContribution.length; i++) {
                            Secondgridrec = i + 1;

                            $("#comcontribute1").append("<tr><td>" + data.d.TableContribution[i].Allowance + "</td><td>" + data.d.TableContribution[i].Amount + "</td><td>" + data.d.TableContribution[i].PerAnnum + "</td></tr>");
                        }

                        if (Number(firstgridrec) + Number(Secondgridrec) <= 5) {
                            //                            $('#Allowances1 tbody td').addClass('ct-active');
                            $('#botoommargindiv').addClass('botoommarginset40px');
                        }

                        if (Number(firstgridrec) + Number(Secondgridrec) > 20) {
                            $('#botoommargindiv').addClass('botoommarginsetnon');
                        }

                    },
                    error: function (response) {

                        var errmsg = jQuery.parseJSON(response.responseText);
                        alert(errmsg.Message);
                    },
                    failure: function (response) {

                        ResetOtherDetails();
                        alert(response.responseText);
                    }
                });
            }

            function ResetOtherDetails() {
                $('#lblNameo').text('');
                $('#lblqualio').text('');
                $('#lblexpo').text('');
                $('#lbldesgo').text('');
                $('#lblYearPasso').text('');
                $('#lbldepto').text('');
                $('#lblprobo').text('');
                $('#lblDojo').text('');
                //$('#lbloffacco').text('');
                $('#lblYearPasso').text('');
                $('#lblPlant').text('');

            }

        });
    </script>
</body>
</html>

