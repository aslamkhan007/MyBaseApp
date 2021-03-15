<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="Excess_material_Issued.aspx.vb" Inherits="Excess_material_Issued" Debug ="true" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>--%>

    <table style="width: 100%">
        <tr>
            <td align="left" class="tableheader" colspan="4" style="font-size: small">
                <strong>Excess Material Issue</strong></td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label1" runat="server" Text="From Date " CssClass="labelcells"></asp:Label>
            </td>
            <td align="left">
                                   
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:TextBox ID="txtfromdate" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                                        
                    <cc1:FilteredTextBoxExtender ID="txtfromdate_FilteredTextBoxExtender" 
                        runat="server" TargetControlID="txtfromdate" FilterInterval="10" 
                        InvalidChars="a-z" ValidChars="1,2,3,4,5,6,7,8,9,0,/">
                    </cc1:FilteredTextBoxExtender>
                    <cc1:CalendarExtender ID="txtfromdate_CalendarExtender" runat="server" 
                        TargetControlID="txtfromdate">
                    </cc1:CalendarExtender>
                                        
                </ContentTemplate>  
                 </asp:UpdatePanel> 
            </td>
            <td align="left">
                <asp:Label ID="Label2" runat="server" Text="To Date " CssClass="labelcells"></asp:Label>
            </td>
            <td align="left">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <asp:TextBox ID="todate" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
             
                    <cc1:FilteredTextBoxExtender ID="todate_FilteredTextBoxExtender" runat="server" 
                        FilterInterval="10" InvalidChars="a-z" TargetControlID="todate" 
                        ValidChars="1,2,3,4,5,6,7,8,9,0,/">
                    </cc1:FilteredTextBoxExtender>
                    <cc1:CalendarExtender ID="todate_CalendarExtender" runat="server" 
                        TargetControlID="todate">
                    </cc1:CalendarExtender>
             
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label3" runat="server" Text="Stock Type " CssClass="labelcells"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlstocktype" runat="server" Width="60px" 
                    CssClass="combobox">
                    <asp:ListItem>ALL</asp:ListItem>
                    <asp:ListItem>BB</asp:ListItem>
                    <asp:ListItem>CF</asp:ListItem>
                    <asp:ListItem>CH</asp:ListItem>
                    <asp:ListItem>CM</asp:ListItem>
                    <asp:ListItem>DY</asp:ListItem>
                    <asp:ListItem>EG</asp:ListItem>
                    <asp:ListItem>HM</asp:ListItem>
                    <asp:ListItem>MM</asp:ListItem>
                    <asp:ListItem>OL</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                    <asp:ListItem>SS</asp:ListItem>
                    <asp:ListItem>SZ</asp:ListItem>
                    <asp:ListItem>WS</asp:ListItem>
                    <asp:ListItem>GM</asp:ListItem>
                    <asp:ListItem>EM</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:LinkButton ID="btnfetch" runat="server" CssClass="buttonc">Fetch</asp:LinkButton>
                <asp:LinkButton ID="btnclose" runat="server" CssClass="buttonc">Close</asp:LinkButton>
                <asp:LinkButton ID="btnexcel" runat="server" CssClass="buttonc">XL</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                   <img alt="" src="../Image/loading.gif" 
    style="width: 70px; height: 10px" />
                </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4">
                <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found " 
                    Width="100%" EnableModelValidation="True">
                    <Columns>
                        <asp:CommandField HeaderText="Select " ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="GridItem" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4">
                <asp:GridView ID="GridView2" runat="server" EmptyDataText="No Record Found" 
                    Width="100%">
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="GridItem" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

