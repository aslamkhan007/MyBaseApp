<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="fabric_vendor_approval.aspx.cs" Inherits="OPS_fabric_vendor_approval" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader">
                Outsourced Fabric Vendor Approvals</td>
            <td class="tableheader">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
         <tr>
            <td class="NormalText" colspan="2">
                <asp:Panel ID="Panel1" runat="server" Height="150px" ScrollBars="Both" 
                    Width="800px">
                    <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                    onselectedindexchanged="grdDetail_SelectedIndexChanged" 
    Width="100%">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbcomp" runat="server" CssClass="NormalText" 
                    Text="Comparision List"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbvendlst" runat="server" CssClass="NormalText" 
                    Text="Vendor List"></asp:Label>
            </td>
        </tr>
                <tr>
      

            <td class="NormalText" style="width: 50%">
                <asp:Panel ID="Panel2" runat="server" Height="250px" ScrollBars="Both" 
                    Width="400px">
                    <asp:GridView ID="grdDetail2" runat="server" EnableModelValidation="True" 
                    ShowFooter="True" Width="100%">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PageStyle" />
                        <PagerTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server">Link</asp:LinkButton>
                        </PagerTemplate>
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
                    </td>
            <td class="NormalText" style="width: 50%; vertical-align: top;">
       
                               
    <asp:CheckBoxList ID="chklist" runat="server" 
                    onselectedindexchanged="chklist_SelectedIndexChanged" >
    </asp:CheckBoxList>
           
                <br />
                <table style="width:100%;">
                    <tr>
                        <td style="width: 85px">
                            Remarks</td>
                        <td>
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Height="50px" 
                                TextMode="MultiLine" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
           
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2">
                <asp:LinkButton ID="lnkapprove" runat="server" CssClass="buttonc" 
                    onclick="lnkapprove_Click">Approve</asp:LinkButton>
                <cc1:ConfirmButtonExtender ID="lnkapprove_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Are you sure ?" TargetControlID="lnkapprove">
                </cc1:ConfirmButtonExtender>
                <asp:LinkButton ID="lnkreject" runat="server" CssClass="buttonc" 
                    onclick="lnkreject_Click">Reject</asp:LinkButton>
                <cc1:ConfirmButtonExtender ID="lnkreject_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Are you sure ?" TargetControlID="lnkreject">
                </cc1:ConfirmButtonExtender>
            </td>
        </tr>
    </table>
</asp:Content>

