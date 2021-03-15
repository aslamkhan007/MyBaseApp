<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="Sizing_Orderwise_Jobwise_report.aspx.cs" Inherits="OPS_Sizing_Orderwise_Jobwise_report" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td colspan="4" class="tableheader" >
                SIZING RECIPE MATERIAL MAPPING REPORT:</td>
        </tr>      
        <tr>
            <td class="labelcells">    
                <asp:Label ID="lblFromDate" runat="server" Text="FROM DATE"></asp:Label>
            </td>
            <td class="NormalText">        
                <asp:TextBox ID="txtFromDate" runat="server" CssClass="textbox" 
                    ToolTip="Select Date"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtFromDate_FilteredTextBoxExtender" 
                    runat="server" TargetControlID="txtFromDate" ValidChars="0123456789/" >
                </cc1:FilteredTextBoxExtender>
                <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" 
                    TargetControlID="txtFromDate">
                </cc1:CalendarExtender>          
            </td>
            <td class="labelcells">
                <asp:Label ID="lblToDate" runat="server" Text="TO DATE"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtToDate" runat="server" style="margin-left: 0px" 
                    CssClass="textbox" ToolTip="Select Date"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtToDate_FilteredTextBoxExtender0" 
                    runat="server" TargetControlID="txtToDate" ValidChars="0123456789/">
                </cc1:FilteredTextBoxExtender>
                <cc1:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" 
                    TargetControlID="txtToDate">
                </cc1:CalendarExtender>        
                </td>
        </tr>
        <tr>
            <td class="labelcells">    
                    <asp:Label ID="lblSortNo" runat="server" Text="SORT NO"></asp:Label>
                </td>
            <td class="NormalText">        
                    <asp:TextBox ID="txtSortNo" runat="server" CssClass="textbox"></asp:TextBox>

                    <cc1:AutoCompleteExtender ID="txtSortNo_AutoCompleteExtender" runat="server" 
                        ServiceMethod="distinctsort" ServicePath="~/WebService.asmx" 
                        TargetControlID="txtSortNo">
                    </cc1:AutoCompleteExtender>          
                   <cc1:FilteredTextBoxExtender ID="txtSortNo_FilteredTextBoxExtender" 
                        runat="server" TargetControlID="txtSortNo" ValidChars="0123456789">
                    </cc1:FilteredTextBoxExtender>
                </td>
            <td class="labelcells">
                    <asp:Label ID="lblOrderNo" runat="server" Text="ORDER NO "></asp:Label>
                </td>
            <td class="NormalText">
                    <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox"></asp:TextBox>
                   <cc1:AutoCompleteExtender ID="txtOrderNo_AutoCompleteExtender" runat="server" 
                        ServiceMethod="distinctorders" ServicePath="~/WebService.asmx" 
                        TargetControlID="txtOrderNo">
                    </cc1:AutoCompleteExtender>
                </td>
        </tr>
        <tr>
            <td colspan="4" class="buttonbackbar">                  
                    <asp:LinkButton ID="lnkBtnFetch" runat="server" onclick="lnkBtnFetch_Click" 
                        CssClass="buttonc">Fetch</asp:LinkButton>
                </td>
        </tr>
        <tr>
            <td colspan="4">    
                <asp:GridView ID="grdjobwisereport" runat="server" Caption="JOBWISE REPORT" 
                        CaptionAlign="Left" Height="144px" Width="101%" 
                        EmptyDataText="No Record Found!!!" CellSpacing="-1">
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                </td>
        </tr>
        <tr>
            <td colspan="4">    
                    <asp:GridView ID="grdorderwisereport" runat="server" Caption="ORDERWISE REPORT" 
                        CaptionAlign="Left" Width="101%" Height="155px" 
                        EmptyDataText="No Record Found!!!">
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PagerStyle" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
           </td>
        </tr>
    </table>
</asp:Content>

