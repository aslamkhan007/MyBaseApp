﻿<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="Yarn_approvals.aspx.cs" Inherits="OPS_Yarn_approvals" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="2">
                Yarn Approvals&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkpo_allocate" runat="server" 
                    PostBackUrl="~/OPS/po_gen_yarn.aspx">PO Allocation</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" colspan="2">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="1000px">
                    <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                    onselectedindexchanged="grdDetail_SelectedIndexChanged" 
    Width="100%" DataKeyNames="Plant">
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
            <td class="NormalText" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
      

            <td class="NormalText" style="width: 50%">
                <asp:Label ID="lbcomp" runat="server" Text="Comparision List" Visible="False"></asp:Label>
            </td>
            <td class="NormalText" style="width: 50%; vertical-align: top;">         
                <asp:Label ID="lbvendlst" runat="server" Text="Vendor List" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
      

            <td class="NormalText" style="width: 50%">
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
&nbsp;</td>
            <td class="NormalText" style="width: 50%; vertical-align: top;">
       
                               
    <asp:CheckBoxList ID="chklist" runat="server" >
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
                    <tr>
                        <td style="width: 85px">
                            &nbsp;</td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtRemarks" ErrorMessage="** Remarks Required" 
                                ValidationGroup="A"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2">
                <asp:LinkButton ID="lnkApproved" runat="server" CssClass="buttonc" 
                    onclick="lnkApproved_Click" ValidationGroup="A">Accept</asp:LinkButton>
                <cc1:ConfirmButtonExtender ID="lnkApproved_ConfirmButtonExtender" 
                    runat="server" ConfirmText="Are you sure, you want to Accept ?" 
                    TargetControlID="lnkApproved">
                </cc1:ConfirmButtonExtender>
                <asp:LinkButton ID="lnkreject" runat="server" CssClass="buttonc" 
                    onclick="lnkreject_Click" ValidationGroup="A">Reject</asp:LinkButton>
                <cc1:ConfirmButtonExtender ID="lnkreject_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Are you sure, you want to reject ?" TargetControlID="lnkreject">
                </cc1:ConfirmButtonExtender>
            </td>
            </tr>
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

