<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="ODS_Stock_For_Sale_Report.aspx.vb" Inherits="OPS_ODS_Stock_For_Sale_Report" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;" >
        <tr>
            <td class="tableheader" colspan="5">
                Ready Stock for ODS
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Lbl_Search_SaleOrder" runat="server" Text="Sale Order"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSearchSaleOrder" runat="server" CssClass="textbox" ValidationGroup="SearchGroup"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Lbl_Shade" runat="server" Text="Shade"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSearchShade" runat="server" CssClass="textbox" ValidationGroup="SearchGroup"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td rowspan="4">
               <asp:LinkButton ID="CmdXl" runat="server" CssClass="buttonXL" Width="64px"></asp:LinkButton></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblValue1" runat="server">Sort</asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSearchSort" runat="server" CssClass="textbox" ValidationGroup="SearchGroup"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="lblValue2" runat="server">Variant</asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSearchVariant" runat="server" CssClass="textbox" ValidationGroup="SearchGroup"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqdVariant" runat="server" ControlToValidate="txtSearchVariant"
                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="SearchGroup"
                            Enabled="False"></asp:RequiredFieldValidator>
                        <asp:LinkButton ID="CmdSearchData" runat="server" CssClass="searchbluesmall" Height="17px"
                            Width="16px" ValidationGroup="SearchGroup"></asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                Plant
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPlant" runat="server" CssClass="combobox">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Status
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                </asp:UpdatePanel>
                <asp:DropDownList ID="ddlAuthStatus" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Authorize</asp:ListItem>
                    <asp:ListItem>Cancel</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                RequestID
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtREquestID" runat="server" CssClass="textbox" ValidationGroup="SearchGroup"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="ImageProg" runat="server" ImageUrl="~/Image/Progress02.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
              
            </td>
        </tr>
    </table>
      <table style="width: 100%;">
                    <tr>
                        <td class="buttonbackbar" colspan="3">
                            <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                                <ContentTemplate>
                                    <telerik:RadButton ID="cmdFetch" runat="server" Text="Fetch">
                                    </telerik:RadButton>
                                    &nbsp;
                                    <telerik:RadButton ID="cmdFetch0" runat="server" Text="Clear">
                                    </telerik:RadButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdRequestDetail" runat="server" AutoGenerateColumns="true" EnableModelValidation="True"
                                        ShowFooter="False" Width="100%">
                                        <SelectedRowStyle CssClass="GridRowGreen" />
                                        <HeaderStyle CssClass="GridHeader" />
                                        <RowStyle CssClass="GridItem" />
                                        <%-- <RowStyle CssClass="GridItem" />--%>
                                        <%--  <AlternatingRowStyle CssClass="GridAI" />--%>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
</asp:Content>
