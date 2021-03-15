<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="UnusedQuotations.aspx.vb" Inherits="OPS_UnusedQuotations" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script type="text/javascript" src="pop.js"></script>
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label1" runat="server" Text="Un-Used Quotations"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Sale Person
            </td>
            <td colspan="1">
                <asp:DropDownList ID="ddlSalesPerson" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td>
                Customer
            </td>
            <td>
                <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" CssClass="textbox"
                    Width="200px" ToolTip="Please give Customer Code or Select Customer from the List "></asp:TextBox>
                <div id="divwidth" style="display: none;">
                    <cc1:autocompleteextender id="txtCustomer_AutoCompleteExtender" runat="server" completioninterval="10"
                        completionsetcount="20" minimumprefixlength="1" servicemethod="OPS_Customer"
                        completionlistcssclass="AutoExtender" servicepath="~/WebService.asmx" completionlistelementid="divwidth"
                        completionlisthighlighteditemcssclass="AutoExtenderHighlight" completionlistitemcssclass="AutoExtenderList"
                        targetcontrolid="txtCustomer">
                    </cc1:autocompleteextender>
                </div>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Plant
            </td>
            <td>
                <asp:DropDownList ID="ddlPlant" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>BLENDED</asp:ListItem>
                    <asp:ListItem>COTTON</asp:ListItem>
                    <asp:ListItem>POLYESTER</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                QuotationNo
            </td>
            <td>
                <asp:TextBox ID="txtQuotationNo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 250px">
                <%-- <asp:TextBox ID="txtEff_To" runat="server" CssClass="textbox" MaxLength="15" TabIndex="29"
                    ValidationGroup="ValidGrpSaveDetail" Width="65px"></asp:TextBox>
                <cc1:maskededitvalidator id="MEV7" runat="server" controlextender="MEE7" controltovalidate="txtEff_To"
                    validationgroup="ValidGrpSaveDetail" display="Dynamic" invalidvaluemessage="Invalid"
                    isvalidempty="False" emptyvaluemessage="*" tooltipmessage="MM/DD/YYYY" width="114px">
                </cc1:maskededitvalidator>
                <cc1:calendarextender id="CalEffTo" runat="server" animated="False" format="MM/dd/yyyy"
                    targetcontrolid="txtEff_To">
                </cc1:calendarextender>
                <cc1:maskededitextender id="MEE7" runat="server" mask="99/99/9999" masktype="Date"
                    targetcontrolid="txtEff_To">
                </cc1:maskededitextender>--%>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:LinkButton ID="CmdFetch" runat="server" CssClass="buttonc">Fetch</asp:LinkButton>
                <asp:LinkButton ID="CmdXl" runat="server" CssClass="buttonXL" Width="64px"></asp:LinkButton>
                </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="10">
                    <ProgressTemplate>
                        <asp:Image ID="ImageProg" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td colspan="3">
            <asp:Panel ID="Panel2" runat="server" Height="400px" Width="100%" ScrollBars="None">
                    <div id="AdjResultsDiv11" class="container" style="width: 100%; height: 398px;">
                        <asp:UpdatePanel ID="UpdatePanel17" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GrdRecords" runat="server" Width="100%" 
                                    EnableModelValidation="True" AutoGenerateSelectButton="True" >
                                    <HeaderStyle CssClass="GridHeader" />
                                    <RowStyle CssClass="GridItem" />
                                    <SelectedRowStyle CssClass="GridRowGreen" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="CmdFetch" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </asp:Panel>
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
