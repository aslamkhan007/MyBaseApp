<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Assetstate.aspx.cs" Inherits="AssetMngmnt_Assetstate" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="2">
                Asset State Master</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 115px">
                Asset State</td>
            <td class="NormalText">
                                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                <asp:TextBox ID="txtstate" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtstate" Display="Dynamic" ErrorMessage="**Required Field" ValidationGroup="A"></asp:RequiredFieldValidator>
                

                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 115px">
                Asset Description</td>
            <td class="NormalText">
            

                                         <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                <asp:TextBox ID="txtassetdesc" runat="server" CssClass="textbox" Height="50px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtassetdesc" Display="Dynamic" ErrorMessage="**Required Field" ValidationGroup="A"></asp:RequiredFieldValidator>
                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="2">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <progresstemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </progresstemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2">
                            <asp:UpdatePanel ID="Updbuttons" runat="server">
                    <ContentTemplate>
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                    onclick="lnksave_Click" ValidationGroup="A">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="buttonc" 
                    onclick="lnkUpdate_Click" ValidationGroup="A">Update</asp:LinkButton>

                            <cc1:ConfirmButtonExtender
                                ID="ConfirmButtonExtender1" runat="server" TargetControlID="lnkDelete" ConfirmText="Are u sure To Delete ?" >
                            </cc1:ConfirmButtonExtender>

                <asp:LinkButton ID="lnkDelete" runat="server" CssClass="buttonc" 
                    onclick="lnkDelete_Click" ValidationGroup="A">Delete</asp:LinkButton>
                <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" OnClick="lnkReset_Click">Reset</asp:LinkButton>
                                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table class="mytable">
        <tr>
            <td class="NormalText">
                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <asp:GridView ID="grdStateDetail" runat="server" EnableModelValidation="True" OnSelectedIndexChanged="grdStateDetail_SelectedIndexChanged" Width="100%">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle CssClass="HeaderStyle" />
                    <RowStyle CssClass="gridRow" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
                                             </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

