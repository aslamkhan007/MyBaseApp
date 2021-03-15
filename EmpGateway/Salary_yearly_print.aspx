<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Salary_yearly_print.aspx.cs" Inherits="OPS_Salary_yearly_print" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">

        function PrintPanel() {
           var panel = document.getElementById("<%=pnlContents.ClientID %>");

           var printWindow = window.open("", "_blank", "toolbar=no, scrollbars=yes, resizable=yes, top=500, left=50");
           printWindow.document.write('<html><head><link rel="stylesheet" type="text/css" href="../stylesheets/stylesheet.css" /><link rel="stylesheet" type="text/css" href="../stylesheets/FormatingSheet.css" /> <link rel="stylesheet" type="text/css" href="../stylesheets/empgatewaystylesheet.css" />   <title>DIV Contents</title>');
           printWindow.document.write('</head><body class="NormalText" style="font-size : 8pt;">');
           printWindow.document.write(panel.innerHTML);
           printWindow.document.write('</body></html>');
           printWindow.document.close();
           setTimeout(function () {
               printWindow.print();
           }, 500);
           return false;

       }
       function myFunction() {
           window.open("", "_blank", "toolbar=yes, scrollbars=yes, resizable=yes, top=500, left=500, width=400, height=400");
       }
  

    function AccessClipboardData() {
        try {
            window.clipboardData.setData('text', "No print data");
        } catch (err) {
            // txt = "There was an error on this page.\n\n";
            // txt += "Error description: " + err.description + "\n\n";
            // txt += "Click OK to continue.\n\n";
            //  alert(txt);
        }

    }


    setInterval("AccessClipboardData()", 300);
    var ClipBoardText = "";

    if (window.clipboardData) {
        ClipBoardText = window.clipboardData.getData('text');
        if (ClipBoardText == "") {
            alert('Sorry you have to allow the page to access clipboard');
            // hide the div which contains your data
            document.all("divmaster").style.display = "none"
        } else {

            document.onkeydown = function(ev) {
                var a;
                ev = window.event;
                if (typeof ev == "undefined") {
                    alert("PLEASE DON'T USE KEYBORD");
                }
                a = ev.keyCode;
                alert("PLEASE DON'T USE KEYBORD");
                return false;
            }
            document.onkeyup = function(ev) {
                var charCode;
                if (typeof ev == "undefined") {
                    ev = window.event;
                    alert("PLEASE DON'T USE KEYBORD");
                } else {
                    alert("PLEASE DON'T USE KEYBORD");
                }
                return false;
            }
        }
    }
       
</script>
 
    
    <table class="NormalText">
        <tr>
            <td class="tableheader" colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 78px" class="NormalText">Select Year</td>
            <td>
                <asp:DropDownList ID="ddlyearfrom" runat="server" CssClass="combobox"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlyearfrom_SelectedIndexChanged">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>2008-2009</asp:ListItem>
                    <asp:ListItem>2009-2010</asp:ListItem>
                    <asp:ListItem>2010-2011</asp:ListItem>
                    <asp:ListItem>2011-2012</asp:ListItem>
                    <asp:ListItem>2012-2013</asp:ListItem>
                    <asp:ListItem>2013-2014</asp:ListItem>
		    <asp:ListItem>2014-2015</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <%--      "if(!PrintPanel()()){return false;}--%>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc"
                    OnClick="LinkButton1_Click">Fetch</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="3">

                <asp:Panel ID="pnlContents" runat="server" Visible="False">
                    <div style="font-size : 8pt;">
                        Financial Year:&nbsp;
                    <asp:Label ID="lbyear" runat="server" Text="Label"></asp:Label>
                        <br />
                        <asp:GridView ID="Gridbasicdetail" runat="server"
                            Width="100%" OnSelectedIndexChanged="Gridbasicdetail_SelectedIndexChanged">
                            <AlternatingRowStyle CssClass="NormalText" />
                            <HeaderStyle CssClass="NormalText" />
                            <PagerStyle CssClass="NormalText" />
                            <RowStyle CssClass="NormalText" />
                        </asp:GridView>
                        <br />
                        <asp:GridView ID="grdDetail" runat="server" Width="100%">
                            <AlternatingRowStyle CssClass="NormalText" />
                            <HeaderStyle CssClass="NormalText" />
                            <PagerStyle CssClass="NormalText" />
                            <RowStyle CssClass="NormalText" />
                        </asp:GridView>
                    </div>
                </asp:Panel>

            </td>
        </tr>

        <tr>
            <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:linkbutton id="lnkprint" runat="server" text="Print"
                        onclientclick="if(!PrintPanel()){return false;}" xmlns:asp="#unknown" cssclass="buttonc"
                        onclick="lnkprint_Click" visible="False" />
                <cc1:ConfirmButtonExtender ID="lnkprint_ConfirmButtonExtender" runat="server"
                    ConfirmText="Are you sure?" Enabled="True" TargetControlID="lnkprint">
                </cc1:ConfirmButtonExtender>
            </td>
            <%--   OnClientClick = "return PrintPanel();" CssClass="buttonc" --%>
            <%--   OnClientClick = "return PrintPanel();" CssClass="buttonc" --%>
        </tr>



    </table>


</asp:Content>


