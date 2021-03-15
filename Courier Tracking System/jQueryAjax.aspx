<%@ Page Title="" Language="C#" MasterPageFile="~/Courier Tracking System/MasterPage.master" AutoEventWireup="true" CodeFile="jQueryAjax.aspx.cs" Inherits="Courier_Tracking_System_jQueryAjax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>jQuery Ajax - ajax demo</h3>

    <p>Click on The button and wait for result.</p>
    
    <input type="button" id="bntAjax" value="Load Data using jQuery Ajax" />
    
    <p>&nbsp;</p>
    
    Result: <div id="divResult"></div>
    
    <p>&nbsp;</p>

    <script language="javascript" type="text/javascript">

        $("#bntAjax").click(function () {
            $.ajax({
                type: "POST",
                url: "jQueryAjaxData.aspx",
                data: "a=2&b=5",
                success: function (msg) {
                    $("#divResult").text(msg);
                }
            });
        });
        
    </script>
    <!-- START - Navigations Links -->
    <hr />

</asp:Content>

