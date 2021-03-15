<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="CustomerBaleInspection.aspx.cs" Inherits="OPS_CustomerBaleInspection" %>

<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function SelectAll(id) {
            //get reference of GridView control
            var grid = document.getElementById("<%= GridView1.ClientID %>");
            //variable to contain the cell of the grid
            var cell;

            if (grid.rows.length > 0) {
                //loop starts from 1. rows[0] points to the header.
                for (i = 1; i < grid.rows.length; i++) {
                    //get the reference of first column
                    cell = grid.rows[i].cells[0];

                    //loop according to the number of childNodes in the cell
                    for (j = 0; j < cell.childNodes.length; j++) {
                        //if childNode type is CheckBox                 
                        if (cell.childNodes[j].type == "checkbox") {
                            //assign the status of the Select All checkbox to the cell 
                            //checkbox within the grid
                            cell.childNodes[j].checked = document.getElementById(id).checked;
                        }
                    }
                }
            }
        }

        function SelectAllChk(id) {
            //get reference of GridView control
            var grid = document.getElementById("<%= GridView4.ClientID %>");
            //variable to contain the cell of the grid
            var cell;

            if (grid.rows.length > 0) {
                //loop starts from 1. rows[0] points to the header.
                for (i = 1; i < grid.rows.length; i++) {
                    //get the reference of first column
                    cell = grid.rows[i].cells[0];

                    //loop according to the number of childNodes in the cell
                    for (j = 0; j < cell.childNodes.length; j++) {
                        //if childNode type is CheckBox                 
                        if (cell.childNodes[j].type == "checkbox") {
                            //assign the status of the Select All checkbox to the cell 
                            //checkbox within the grid
                            cell.childNodes[j].checked = document.getElementById(id).checked;
                        }
                    }
                }
            }
        }
    </script>
    <table>
        <tr>
            <td class="tableheader" colspan="4">
                Customer Bales Inspection
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:DropDownList ID="dropdownBales" runat="server" CssClass="labelcells" 
                            onselectedindexchanged="dropdownBales_SelectedIndexChanged">
                            <asp:ListItem Text="Bale Wise" Value="B" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Invoice Wise" Value="I"></asp:ListItem>
                            <asp:ListItem Text="Order Wise" Value="O"></asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="lblfrmBale" runat="server" Text="From "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBaleFrom" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblToBale" runat="server" Text="To  "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBaleTo" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
            </td>
            <td class="buttonbackbar">
                <asp:LinkButton ID="LnkfrstFetch" runat="server" CssClass="buttonc" OnClick="LnkfrstFetch_Click"
                    Width="70px">Fetch</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:Label ID="lblfrmInvoice" runat="server" Text="From Invoice" Visible="false"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtfrmInvoice" runat="server" CssClass="textbox" Width="200px" Visible="false"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblToInvoice" runat="server" Text="To Invoice " Visible="false"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txttoInvoice" runat="server" CssClass="textbox" Width="200px" Visible="false"></asp:TextBox>
            </td>
            <td>
                <asp:LinkButton ID="lnksecfetch" runat="server" CssClass="buttonc" OnClick="lnksecfetch_Click"
                    Visible="false" Width="70px">Fetch</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Bales Need to Send to Logistic From Folding"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="15">
                <asp:Panel ID="Panel1" runat="server" Height="200px" Width="100%">
                    <div id="AdjResultsDiv" style="height: 200px; overflow: scroll; width: auto; top: 0px;
                        left: 0px;">
                        <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="labelcells"
                                    Font-Bold="False" Width="100%" AllowPaging="false" Font-Size="Small" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="allchk" runat="server" Text="All" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Chk" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="bale_no" HeaderText="Bale No" />
                                        <asp:BoundField DataField="tot_meters" HeaderText="Total Meters" />
                                        <asp:BoundField DataField="Sort" HeaderText="Sort" />
                                        <asp:BoundField DataField="grade" HeaderText="Variant" />
                                        <asp:BoundField DataField="order_no" HeaderText="Order No" />
                                        <asp:BoundField DataField="customer" HeaderText="Customer" />
                                        <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" />
                                        <asp:BoundField DataField="InvoiceDate" HeaderText="Invoice Date" />
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                </asp:GridView>
                            </ContentTemplate>
                            
                        </asp:UpdatePanel>
                        
                    </div>
                </asp:Panel>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="3">
            </td>
            <td style="height: 26px">
                <asp:LinkButton ID="lnkFsendReq" runat="server" CssClass="buttonc" OnClick="lnkFsendReq_Click">Send Request</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblaccept" runat="server" Font-Size="Medium" Text="Bales Pending to Accept By Folding "></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="15">
                <asp:Panel ID="Panel2" runat="server" Height="200px" Width="100%">
                    <div id="Div1" style="height: 200px; overflow: scroll; width: auto; top: 0px; left: 0px;">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="labelcells"
                                    Font-Bold="False" Width="100%" DataKeyNames="FRequest" OnRowDataBound="OnRowDataBound"
                                    OnSelectedIndexChanged="GridView2_SelectedIndexChanged" Font-Size="Small">
                                    <Columns>
                                        <asp:ButtonField DataTextField="FRequest" HeaderText="Request ID" CommandName="Select" />
                                        <%-- <asp:BoundField DataField="FRequest" HeaderText="Request" />--%>
                                        <asp:BoundField DataField="OrderNo" HeaderText="Order No" SortExpression="UserInfo"
                                            ItemStyle-Width="200px" />
                                        <asp:BoundField DataField="Custcode" HeaderText="Customer" />
                                        <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" />
                                        <asp:BoundField DataField="InvoiceDate" HeaderText="Invoice Date" />
                                        <asp:BoundField DataField="sort" HeaderText="Sort No" />
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" /><SelectedRowStyle BackColor="LightGreen" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Size="Medium" Text="Pending Bales Detail"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="15">
                <asp:Panel ID="Panel3" runat="server" Height="200px" Width="100%">
                    <div id="Div2" style="height: 200px; overflow: scroll; width: auto; top: 0px; left: 0px;">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CssClass="labelcells"
                                    Font-Bold="False" Width="100%" AllowPaging="false" Font-Size="Small">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Accept/Reject">
                                         <HeaderTemplate>
                                                <asp:CheckBox ID="ddlChk" runat="server" Text="All" OnCheckedChanged="CheckedChanged" AutoPostBack="true" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:DropDownList ID="Chk" runat="server" CssClass="labelcells">
                                                    <asp:ListItem Text="Accept" Value="A" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Reject" Value="R"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FRequest" HeaderText="Request" />
                                        <asp:BoundField DataField="BaleNo" HeaderText="Bale No" />
                                        <asp:BoundField DataField="Meters" HeaderText="Quantity" />
                                        <asp:BoundField DataField="FRequestDate" HeaderText="Request Date" />
                                        <asp:BoundField DataField="Custcode" HeaderText="Customer" />
                                        <asp:BoundField DataField="OrderNo" HeaderText="Order No" />
                                        <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" />
                                        <asp:BoundField DataField="InvoiceDate" HeaderText="Invoice Date" />
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                   
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3">
            </td>
            <td>
                <asp:LinkButton ID="lnkAccept" runat="server" CssClass="buttonc" OnClick="lnkAccept_Click"
                    Width="64px">Accept</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblReturn" runat="server" Font-Size="Medium" Text="Bales Pending to Return"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="15">
                <asp:Panel ID="Panel4" runat="server" Height="200px" Width="100%">
                    <div id="Div3" style="height: 200px; overflow: scroll; width: auto; top: 0px; left: 0px;">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CssClass="labelcells"
                                    Font-Bold="False" Width="100%" AllowPaging="false" Font-Size="Small" OnRowDataBound="GridView4_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="allchk1" runat="server" Text="All" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkReturn" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FRequest" HeaderText="Request" />
                                        <asp:BoundField DataField="BaleNo" HeaderText="Bale No" />
                                        <asp:BoundField DataField="Meters" HeaderText="Quantity" />
                                        <asp:BoundField DataField="FRequestDate" HeaderText="Request Date" />
                                        <asp:BoundField DataField="Custcode" HeaderText="Customer" />
                                        <asp:BoundField DataField="OrderNo" HeaderText="Order No" />
                                        <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" />
                                        <asp:BoundField DataField="InvoiceDate" HeaderText="Invoice Date" />
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3">
            </td>
            <td style="height: 26px">
                <asp:LinkButton ID="LinkButton3" runat="server" CssClass="buttonc" OnClick="LinkButton3_Click"
                    Width="67px">Return</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
