<%@ Page Title="" Language="C#" MasterPageFile="~/AssetMngmnt/MasterPage_blank.master" AutoEventWireup="true" CodeFile="Asset_accept.aspx.cs" Inherits="AssetMngmnt_Asset_accept" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="6">
                Accept/Reject PC configration</td>
        </tr>
        <tr>
            <td class="NormalText">
                Computer Type
            </td>
            <td class="NormalText">
                <asp:Label ID="lblcomptype" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="NormalText">
                Accepted Date</td>
            <td class="NormalText">
                <asp:Label ID="lblCurrentDate" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="NormalText">
                Issued To</td>
            <td class="NormalText">
                <asp:Label ID="lblissuedto" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Department</td>
            <td class="NormalText">
                <asp:Label ID="lbldept" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="NormalText">
                Model No</td>
            <td class="NormalText">
                <asp:Label ID="lblmodelno" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="NormalText">
                JctSrNo</td>
            <td class="NormalText">
                <asp:Label ID="lblsrno" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Computer Name</td>
            <td class="NormalText">
                <asp:Label ID="lblitemname" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" colspan="6">
                <asp:DataList ID="DataList2" runat="server" DataKeyField="asset_id" 
                    onitemdatabound="DataList2_ItemDataBound1">


               <ItemTemplate>
                        <table>
                         <tr>
                         <td>
                         
                         <asp:Label ID="Labelhead" runat="server"   Text='<%# Eval("item_name") %>' 
                                 Font-Bold="True" Font-Names="Calibri" Font-Size="Large" 
                                 ForeColor="Black" ></asp:Label>
                        </td>
                       </tr>
                        <tr>
                        <td>
 
                            <asp:Panel ID="Panel1" runat="server" Width="900px">
                                <asp:GridView ID="GridView1" runat="server"  Width="100%"   BorderColor="Black" 
                                    onrowdatabound="GridView1_RowDataBound" >
                           <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="GridItem" />
                                </asp:GridView>
                            </asp:Panel>
                            </td>

                            </tr>
                            </table>
                        </ItemTemplate>
                </asp:DataList>
     
            </td>
        </tr>
        <tr >
        <td class="NormalText" colspan="6">
             <asp:Label ID="Labelhead" runat="server"   Text='Printer/Scanner' 
                                 Font-Bold="True" Font-Names="Calibri" Font-Size="Large" 
                                 ForeColor="Black" ></asp:Label>
                                 </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="6">
               <asp:Panel ID="Panel1" runat="server" Width="900px">
                                <asp:GridView ID="grdDetailprinter" runat="server"  Width="100%"   BorderColor="Black" 
                                    onrowdatabound="GridView1_RowDataBound" >
                           <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="GridItem" />
                                </asp:GridView>
                            </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Remarks (In Case If Rejected)</td>
            <td class="NormalText" colspan="5">
                <asp:TextBox ID="txtremarks" runat="server" CssClass="textbox" Height="35px" MaxLength="400"
                    TextMode="MultiLine" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtremarks" ErrorMessage="Provide a reason to reject" 
                    ValidationGroup="A">Provide a reason to reject</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="6">
                <asp:LinkButton ID="lnkaccept" runat="server" CssClass="buttonc" 
                    onclick="lnkaccept_Click">Accept</asp:LinkButton>
                <asp:LinkButton ID="lnkreject" runat="server" CssClass="buttonc" 
                    onclick="lnkreject_Click" ValidationGroup="A">Reject</asp:LinkButton>
                <cc1:ConfirmButtonExtender ID="lnkreject_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Are You Sure?" Enabled="True" TargetControlID="lnkreject">
                </cc1:ConfirmButtonExtender>
                <asp:LinkButton ID="lnkback" runat="server" CssClass="buttonc" 
                    onclick="LinkButton1_Click">Refresh</asp:LinkButton>
                <asp:LinkButton ID="nextbtn" runat="server" CssClass="buttonc" 
                    onclick="nextbtn_Click" Visible="False">Next</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

