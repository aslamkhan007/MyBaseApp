<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerProspectDetail.aspx.cs" Inherits="OPS_CustomerProspectDetail" %>
<%@ Register Src="~/FlashMessage.ascx" TagName="flashmessage"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label23" runat="server" Text="Customer/Prospect Detail"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 105px; height: 17px">
                <asp:Label ID="Label16" runat="server" Text="Customer Name"></asp:Label>
            </td>
            <td class="NormalText" style="height: 17px; width: 214px">
                <asp:TextBox ID="txtName" runat="server" CssClass="textbox" MaxLength="100" 
                    Width="200px"></asp:TextBox>
            </td>
            <td class="NormalText" style="height: 17px; width: 111px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="height: 17px">
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 105px">
                <asp:Label ID="Label17" runat="server" Text="Address"></asp:Label>
            </td>
            <td class="NormalText" style="width: 214px">
                <asp:TextBox ID="txtAddress" runat="server" CssClass="textbox" Height="50px" 
                    MaxLength="200" TextMode="MultiLine" Width="200px"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 111px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtAddress" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 105px">
                <asp:Label ID="Label18" runat="server" Text="City"></asp:Label>
            </td>
            <td class="NormalText" style="width: 214px">
                <asp:TextBox ID="txtCity" runat="server" CssClass="textbox" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtCity" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 111px">
                <asp:Label ID="Label24" runat="server" Text="State"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtState" runat="server" CssClass="textbox" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="txtState" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 105px">
                <asp:Label ID="Label19" runat="server" Text="Country"></asp:Label>
            </td>
            <td class="NormalText" style="width: 214px">
                <asp:TextBox ID="txtCountry" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtCountry" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 111px">
                <asp:Label ID="Label25" runat="server" Text="Concerned Person"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtConcPerson" runat="server" CssClass="textbox" 
                    MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtConcPerson" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 105px">
                <asp:Label ID="Label20" runat="server" Text="Contact No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 214px">
                <asp:TextBox ID="txtContactNo" runat="server" CssClass="textbox" MaxLength="15"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtContactNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 111px">
                <asp:Label ID="Label26" runat="server" Text="Email ID"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtEmailID" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="txtEmailID" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 105px">
                <asp:Label ID="Label21" runat="server" Text="Sale Person"></asp:Label>
            </td>
            <td class="NormalText" style="width: 214px">
                <asp:TextBox ID="txtSalePerson" runat="server" CssClass="textbox" 
                    MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtState" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 111px">
                <asp:Label ID="Label27" runat="server" Text="Product Category"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtProductCategory" runat="server" CssClass="textbox" 
                    MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                    ControlToValidate="txtProductCategory" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkCreate" runat="server" CssClass="buttonc" 
                    onclick="lnkCreate_Click" ValidationGroup="A">Create</asp:LinkButton>
                <asp:LinkButton ID="lnkQuote" runat="server" CssClass="buttonc">New Quote</asp:LinkButton>
               
              
            </td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText" style="height: 13px;">
              <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                <ContentTemplate>
                  <uc1:flashmessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                            FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" Visible="true">
                        </uc1:flashmessage>
                </ContentTemplate>
                </asp:UpdatePanel>
                </td>
        </tr>
        </table>
</asp:Content>

