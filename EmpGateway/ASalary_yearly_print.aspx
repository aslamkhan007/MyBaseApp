<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Salary_yearly_print.aspx.cs" Inherits="OPS_Salary_yearly_print" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <script type = "text/javascript">
      function PrintPanel() {
          var panel = document.getElementById("<%=pnlContents.ClientID %>");
          var printWindow = window.open('', '', 'height=400,width=800');
          printWindow.document.write('<html><head><title>DIV Contents</title>');
          printWindow.document.write('</head><body >');
          printWindow.document.write(panel.innerHTML);
          printWindow.document.write('</body></html>');
          printWindow.document.close();
          setTimeout(function () {
              printWindow.print();
          }, 500);
          return false;
      }
    </script>
     <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 78px" class="NormalText">
                Select Year</td>
            <td>
                <asp:DropDownList ID="ddlyearfrom" runat="server" CssClass="combobox" 
                    AutoPostBack="True" onselectedindexchanged="ddlyearfrom_SelectedIndexChanged">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>2008-2009</asp:ListItem>
                    <asp:ListItem>2009-2010</asp:ListItem>
                    <asp:ListItem>2011-2012</asp:ListItem>
                    <asp:ListItem>2012-2013</asp:ListItem>
                    <asp:ListItem>2013-2014</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <%--      "if(!PrintPanel()()){return false;}--%>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc" 
                    onclick="LinkButton1_Click">Fetch</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
       
                <asp:Panel ID="pnlContents" runat="server" Visible="False">
                    Financial Year:&nbsp;
                    <asp:Label ID="lbyear" runat="server" Text="Label"></asp:Label>
                 <br />
                   <asp:GridView ID="Gridbasicdetail" runat="server" 
                      Width="100%" onselectedindexchanged="Gridbasicdetail_SelectedIndexChanged">
                          <AlternatingRowStyle CssClass="GridAI" />
                          <HeaderStyle CssClass="HeaderStyle" />
                          <PagerStyle CssClass="PageStyle" />
                          <RowStyle CssClass="GirdItem" />
                      </asp:GridView>
                           <br />
                      <asp:GridView ID="grdDetail" runat="server" Width="100%">
                          <AlternatingRowStyle CssClass="GridAI" />
                          <HeaderStyle CssClass="HeaderStyle" />
                          <PagerStyle CssClass="PageStyle" />
                          <RowStyle CssClass="GirdItem" />
                    </asp:GridView>
                </asp:Panel>

                  </td>
                  </tr>

                <tr>
                  <td class="buttonbackbar" colspan="4">
                    <asp:Linkbutton ID="lnkprint"  runat="server" Text="Print" 
                    OnClientClick = "if(!PrintPanel()){return false;}" xmlns:asp="#unknown" CssClass="buttonc" 
                          onclick="lnkprint_Click" Visible="False" />
                      <cc1:ConfirmButtonExtender ID="lnkprint_ConfirmButtonExtender" runat="server" 
                          ConfirmText="Are you sure?" Enabled="True" TargetControlID="lnkprint">
                      </cc1:ConfirmButtonExtender>
                  </td>
                    <%--   OnClientClick = "return PrintPanel();" CssClass="buttonc" --%>
               <%--   OnClientClick = "return PrintPanel();" CssClass="buttonc" --%>
          </tr>
       
 
    
        </table>
      


 
</asp:Content>

