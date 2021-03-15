<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="PackingUpdateStatusReport.aspx.vb" Inherits="PackingUpdateStatusReport" title="Packing Update Status Report" MaintainScrollPositionOnPostback="true" %>  


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript" type="text/javascript">
        // <!CDATA[

        function TABLE1_onclick() {

        }

        // ]]>
</script>

    <table style="width:100%">
        <tr>
            <td class="tableheader" colspan="5">
                Packing Reason Reports</td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td class="labelcells" style="width: 176px">
                Report Type</td>
            <td class="NormalText" >
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="txtSalePerson" runat="server" CssClass="combobox" AutoPostBack="true">
                           
                                   
                                    <asp:ListItem>Status VS SalePerson</asp:ListItem>
                                    <asp:ListItem>SalePerson VS Status</asp:ListItem>
                                    <asp:ListItem>CustomerName VS SalePerson</asp:ListItem>
                                    <asp:ListItem>Status VS Date</asp:ListItem>
                                       
                                </asp:DropDownList>
                                &nbsp;<asp:Label ID="lblName" runat="server"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblTime" runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </td>
            <td class="labelcells">
                &nbsp;</td>
            <td style="height: 16px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 11px; text-align: center;" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:Button ID="BtnGet" runat="server" BackColor="Black" 
                              CssClass="ButtonBack" Text="View" ValidationGroup="A" />
                        <asp:Button ID="BtnRefresh" runat="server" BackColor="Black" 
                            CausesValidation="False" CssClass="ButtonBack" Text="Refresh" />
                        <asp:Button ID="BtnExcel" runat="server" BackColor="Black" 
                            CausesValidation="False" CssClass="ButtonBack" Text="Excel" />
                        <asp:Button ID="BtnExcel1" runat="server" BackColor="Black" 
                            CausesValidation="False" CssClass="ButtonBack" Text="Excel Part II" />
                        <asp:Button ID="BtnExcel3" runat="server" BackColor="Black" 
                            CausesValidation="False" CssClass="ButtonBack" Text="Excel Part III" />
                    </ContentTemplate>
                    <Triggers>
                    <asp:PostBackTrigger ControlID="BtnExcel" />
                     <asp:PostBackTrigger ControlID="BtnExcel1" />
                     <asp:PostBackTrigger ControlID="BtnExcel3" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            
        </tr>
        </table>
    <table style="width: 100%" class="tableback">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <img alt="" src="../CostingSystemTest/Image/loading.gif" 
    style="width: 70px; height: 10px" />
                        &nbsp;
                        <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="Please Wait..."></asp:Label>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td>
                
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" >
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" 
                            CssClass="GridViewStyle" GridLines="None" 
                            PageSize="150000" width="100%" EnableSortingAndPagingCallbacks="True" 
                            AllowSorting="True">
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                            
                            <RowStyle CssClass="RowStyle" />
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <PagerStyle CssClass="PagerStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <EditRowStyle CssClass="EditRowStyle" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                        </asp:GridView>
                    </ContentTemplate>
                 
                   
                </asp:UpdatePanel>
               
            </td>
        </tr>
        <tr>
            <td>
                
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="True" 
                                    CssClass="GridViewStyle" EnableSortingAndPagingCallbacks="True" 
                                    GridLines="None" PageSize="150000" width="100%" AllowSorting="True">
                                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                                    <RowStyle CssClass="RowStyle" />
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <PagerStyle CssClass="PagerStyle" />
                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <EditRowStyle CssClass="EditRowStyle" />
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
               
            </td>
        </tr>
        <tr>
            <td>
                
                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="True" 
                                    CssClass="GridViewStyle" EnableSortingAndPagingCallbacks="True" 
                                    GridLines="None" PageSize="150000" width="100%">
                                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                                    <RowStyle CssClass="RowStyle" />
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <PagerStyle CssClass="PagerStyle" />
                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <EditRowStyle CssClass="EditRowStyle" />
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
               
            </td>
        </tr>
    </table>
</asp:Content>