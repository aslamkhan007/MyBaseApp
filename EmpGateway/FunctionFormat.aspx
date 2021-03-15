<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="FunctionFormat.aspx.vb" Inherits="FunctionFormat" title="Function Form Format" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table 100%" width="100%">
        <tr>
            <td align="center" colspan="2" class="tableheader">
                <asp:Label ID="lblHeading" runat="server" ForeColor="Black" Text="-----------" Font-Bold="True" Font-Names="Tahoma" Font-Size="11pt"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" class="labelcells">
                <asp:Label ID="lblDesg" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" class="labelcells">
                <asp:Label ID="lblLoc" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" class="labelcells">
                <asp:Label ID="lblCity" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" class="labelcells">
                <asp:Label ID="lblText1" runat="server" Font-Names="Tahoma" Font-Size="8pt">I, along with my following family members :-</asp:Label></td>
        </tr>
        <tr>
            <td class="panelcells" width="95%">
                <asp:GridView ID="GrdFamily" runat="server" AutoGenerateColumns="False" 
                    Width="593px">
                    <Columns>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:TextBox ID="txtName" runat="server" Text='<%# eval("Name") %>'
                                    Width="157px" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Realtionship">
                            <ItemTemplate>
                                <asp:TextBox ID="txtRelationship" runat="server"
                                    Text='<%# eval("Relationship") %>' Width="115px" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Age">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAge" runat="server" Text='<%# eval("Age") %>'
                                    Width="57px" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Meal">
                            <ItemTemplate>
                                <asp:DropDownList ID="DrpMeal" runat="server" CssClass="DropDownItem" Width="84px">
                                    <asp:ListItem>Veg</asp:ListItem>
                                    <asp:ListItem>NonVeg</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                    </Columns>
                    <HeaderStyle CssClass="GridHeader" />
                    <AlternatingRowStyle CssClass="GridAI" />
                </asp:GridView>
                </td>
            <td class="labelcells">
                <asp:LinkButton ID="LnkAddRow" runat="server" CssClass="ButtonBack" BorderStyle="None">Add Row</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="labelcells">
                <asp:Label ID="lblText2" runat="server" Font-Names="Tahoma" Font-Size="8pt">Would be attending the </asp:Label>
                <asp:Label ID="lblOccasion" runat="server" Font-Names="Tahoma" Font-Size="8pt" Font-Bold="True"></asp:Label>
                <asp:Label ID="lblText4" runat="server" Font-Names="Tahoma" Font-Size="8pt"> on </asp:Label>
                <asp:Label ID="lblDate" runat="server" Font-Names="Tahoma" Font-Size="8pt" Font-Bold="True"></asp:Label>
                <asp:Label ID="lblText3" runat="server" Font-Names="Tahoma" Font-Size="8pt">, to be held in the </asp:Label>
                <asp:Label ID="lblVenue" runat="server" Font-Names="Tahoma" Font-Size="8pt" Font-Bold="True"></asp:Label>
                <asp:Label ID="lblText5" runat="server" Font-Names="Tahoma" Font-Size="8pt">at</asp:Label>
                <asp:Label ID="lblTime" runat="server" Font-Names="Tahoma" Font-Size="8pt" Font-Bold="True"></asp:Label>.</td>
        </tr>
        <tr>
            <td colspan="2" class="labelcells">
                <asp:Label ID="lblText6" runat="server" Font-Names="Tahoma" Font-Size="8pt">My requirement of coupons, on payment is as under:-</asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" class="panelcells">
                <asp:GridView ID="GrdReq" runat="server" AutoGenerateColumns="False" 
                    Width="100%">
                    <Columns>
                        <asp:BoundField DataField="ItemName" HeaderText="Name" />
                        <asp:BoundField DataField="RateUOM" HeaderText="Rate(Rs.)" />
                        <asp:TemplateField HeaderText="Requirement">
                            <ItemTemplate>
                                &nbsp;
                                <asp:TextBox ID="txtQty" runat="server" CssClass="textbox" Font-Names="Tahoma" Font-Size="8pt"
                                    Width="57px" ToolTip="Only Numeric Valus Accepted. ** In case of Half use .5" ValidationGroup="qty"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtQty" Type="Double"></asp:CompareValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="UOM" HeaderText="Unit Of Measurement" />
                    </Columns>
                    <HeaderStyle CssClass="GridHeader" />
                    <AlternatingRowStyle CssClass="GridAI" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="labelcells">
                <asp:Label ID="lblText7" runat="server" Font-Names="Tahoma" Font-Size="8pt">I further hereby agree that the cost of Requirements specified  by me may be recovered from my salary for the month of </asp:Label>
                <asp:Label ID="lblSalMonth" runat="server" Font-Names="Tahoma" Font-Size="8pt"></asp:Label>.</td>
        </tr>
        <tr>
            <td colspan="2" class="labelcells">
                <asp:Label ID="lblNote" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"></asp:Label></td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2">
                <asp:LinkButton ID="LnkSubmit" runat="server" CssClass="ButtonBack" 
                    BorderStyle="None">Submit</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
            <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="True" Message="test" 
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" />
            </td>
        </tr>
        </table>
</asp:Content>

