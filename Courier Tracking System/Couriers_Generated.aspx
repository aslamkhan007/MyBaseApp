<%@ Page Title="" Language="C#" MasterPageFile="~/Courier Tracking System/MasterPage.master" AutoEventWireup="true" CodeFile="Couriers_Generated.aspx.cs" Inherits="Courier_Tracking_System_Couriers_Generated" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label18" runat="server" Text="Couriers Generated  Report"></asp:Label>

            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 150px">
                <asp:Label ID="Label19" runat="server" Text="Date From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 153px">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtDateFrom" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 120px">
                <asp:Label ID="Label20" runat="server" Text="Date From"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtDateTo">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtDateTo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 150px">
                <asp:Label ID="Label21" runat="server" Text="Select Department"></asp:Label>
            </td>
            <td class="NormalText" style="width: 153px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlDept" runat="server" CssClass="combobox" 
                            AutoPostBack="True" onselectedindexchanged="ddlDept_SelectedIndexChanged">
                        </asp:DropDownList>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 120px">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Image/loadingNew.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 150px">
                <asp:Label ID="Label22" runat="server" Text="Courier Service"></asp:Label>
            </td>
            <td class="NormalText" style="width: 153px">
                <asp:DropDownList ID="ddlCourierService" runat="server" CssClass="combobox" 
                    onselectedindexchanged="ddlCourierService_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 120px">
                
            </td>
            <td class="NormalText">
                
            </td>
        </tr>
  
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                       
                        <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                            onclick="lnkfetch_Click" ValidationGroup="A">Fetch</asp:LinkButton>
                       
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" onclick="lnkReset_Click" 
                          >Reset</asp:LinkButton>
                        
                        
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
  <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" 
                            onclick="lnkExcel_Click" ValidationGroup="A">To Excel</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                    AssociatedUpdatePanelID="UpdatePanel2" DisplayAfter="10">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/loading.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>

<%--  <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <asp:Panel ID="Panel2" runat="server" Height="500px" ScrollBars="Vertical" 
            Visible="False" Width="100%">
          <asp:GridView ID="grdList" runat="server" onrowdatabound="grdList_RowDataBound" 
              ShowFooter="True" Width="100%">
              <AlternatingRowStyle CssClass="GridAI" />
              <HeaderStyle CssClass="GridHeader" />
              <RowStyle CssClass="GridItem" />
          </asp:GridView>
    </asp:Panel>
    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkList" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
--%>

        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
    <ContentTemplate>
<%--      <asp:Panel ID="Panel3" runat="server" Height="500px" ScrollBars="Vertical" 
             Width="60%">--%>
          <asp:GridView ID="GridView2" runat="server"  
              ShowFooter="True" Width="100%" PageSize="50" EmptyDataText="No Record Found!!" 
             >
              <AlternatingRowStyle CssClass="GridAI" />
              <HeaderStyle CssClass="GridHeader" />
              <RowStyle CssClass="GridItem" />
          </asp:GridView>
 <%--   </asp:Panel>--%>
    </ContentTemplate>
<%--        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkfetch" EventName="Click" />
        </Triggers>--%>
    </asp:UpdatePanel>
</asp:Content>

