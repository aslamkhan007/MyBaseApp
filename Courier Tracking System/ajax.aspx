<%@ Page Title="jQuery Ajax - ajax demo" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="ajax.aspx.cs" Inherits="Ajax_ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <p>
        <a href="Default.aspx" title="Back to Manipulations">Back to Ajax</a> | <a
            href="../" title="Back to jQuery Demo Home">Back to jQuery Demo Home</a>
    </p>
    <!-- END - Navigations Links -->
</asp:Content>
