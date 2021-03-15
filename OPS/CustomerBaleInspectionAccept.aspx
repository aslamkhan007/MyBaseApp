<%@ Page Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="CustomerBaleInspectionAccept.aspx.cs" Inherits="OPS_CustomerBaleInspectionAccept" %>

<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function SelectAll(id) {
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

        function SelectAllChk(id) {
            //get reference of GridView control
            var grid = document.getElementById("<%= GridView3.ClientID %>");
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
                Customer Bales Inspection Acceptance
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblReqID" runat="server" Text="Request ID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtReqID" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
            </td>
            <td class="buttonbackbar">
                <asp:LinkButton ID="LnkFetch" runat="server" CssClass="buttonc" OnClick="LnkFetch_Click"
                    Width="64px">Fetch</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Pending Bales to Accept/Reject"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblPendingBales" runat="server" Visible="false" Text="No Data Found"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:Panel ID="Panel2" runat="server" Height="200px" Width="100%">
                    <div id="Div1" style="height: 200px; overflow: scroll; width: auto; top: 0px; left: 0px;">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="labelcells"
                                    Font-Bold="False" Width="100%" DataKeyNames="FRequest" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                    Font-Size="Small">
                                    <Columns>
                                        <asp:ButtonField DataTextField="FRequest" HeaderText="ID" CommandName="Select" />
                                        <asp:BoundField DataField="OrderNo" HeaderText="Order No" />
                                        <asp:BoundField DataField="Custcode" HeaderText="Cust No" />
                                        <asp:BoundField DataField="Sort" HeaderText="Sort No" />
                                        <asp:BoundField DataField="Variant" HeaderText="Variant" />
                                        <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" />
                                        <asp:BoundField DataField="InvoiceDate" HeaderText="InvoiceDate" />
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <SelectedRowStyle BackColor="LightGreen" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </asp:Panel>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Font-Size="Medium" Text="Bales Detail"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblBaleDetail" runat="server" Visible="false" Text="Bales Detail"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:Panel ID="Panel1" runat="server" Height="200px" Width="100%">
                    <div id="Div2" style="height: 200px; overflow: scroll; width: auto; top: 0px; left: 0px;">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="labelcells"
                                    Font-Bold="False" Width="100%" Font-Size="Small" HeaderStyle-CssClass="FixedHeader">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Accept/Reject">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="ddlChk" runat="server" Text="All" OnCheckedChanged="CheckedChanged"
                                                    AutoPostBack="true" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:DropDownList ID="Chk" runat="server" CssClass="labelcells">
                                                    <asp:ListItem Text="Accept" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="Reject" Value="R"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="BaleNo" HeaderText="Bale No" />
                                        <asp:BoundField DataField="FRequest" HeaderText="ID" />
                                        <asp:BoundField DataField="Meters" HeaderText="Meters" />
                                        <asp:BoundField DataField="OrderNo" HeaderText="Order No" />
                                        <asp:BoundField DataField="CustCode" HeaderText="Cust No" />
                                        <asp:BoundField DataField="Sort" HeaderText="Sort No" />
                                        <asp:BoundField DataField="Variant" HeaderText="Variant" />
                                        <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" />
                                        <asp:BoundField DataField="InvoiceDate" HeaderText="InvoiceDate" />
                                        <asp:TemplateField HeaderText="Remarks">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="labelcells">
                                                    
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <SelectedRowStyle BackColor="Green" />
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
            <td>
                <asp:LinkButton ID="lnkSave" runat="server" OnClick="lnkSave_Click" CssClass="buttonc"
                    Width="76px">Apply</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Size="Medium" Text="Pending Bales to Send to Folding Deptt."></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="15">
                <asp:Panel ID="Panel4" runat="server" Height="200px" Width="100%">
                    <div id="Div3" style="height: 200px; overflow: scroll; width: auto; top: 0px; left: 0px;">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CssClass="labelcells"
                                    Font-Bold="False" Width="100%" Font-Size="Small" OnRowDataBound="GridView4_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="allchk" runat="server" Text="All" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Chk" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FRequest" HeaderText="ID" />
                                        <asp:BoundField DataField="BaleNo" HeaderText="Bale No" />
                                        <asp:BoundField DataField="Meters" HeaderText="Meters" />
                                        <asp:BoundField DataField="FRequestDate" HeaderText="Request Date" />
                                        <asp:BoundField DataField="Custcode" HeaderText="Customer" />
                                        <asp:BoundField DataField="OrderNo" HeaderText="Order No" />
                                        <asp:BoundField DataField="Sort" HeaderText="Sort No" />
                                        <asp:BoundField DataField="Variant" HeaderText="Variant" />
                                        <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" />
                                        <asp:BoundField DataField="InvoiceDate" HeaderText="InvoiceDate" />
                                          <asp:TemplateField HeaderText="Remarks">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtSendRemarks" runat="server" CssClass="labelcells">
                                                    
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
            <td style="height: 26px">
                <asp:LinkButton ID="LinkButton3" runat="server" CssClass="buttonc" OnClick="LinkButton3_Click"
                    Width="78px">Send</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Font-Size="Medium" Text="Pending Bales to Accept."></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="15">
                <asp:Panel ID="Panel3" runat="server" Height="200px" Width="100%">
                    <div id="Div4" style="height: 200px; overflow: scroll; width: auto; top: 0px; left: 0px;">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CssClass="labelcells"
                                    Font-Bold="False" Width="100%" AllowPaging="true" Font-Size="Small" OnRowDataBound="GridView3_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="allchk1" runat="server" Text="All" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkReturn" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FRequest" HeaderText="ID" />
                                        <asp:BoundField DataField="BaleNo" HeaderText="Bale No" />
                                        <asp:BoundField DataField="Meters" HeaderText="Meters" />
                                        <asp:BoundField DataField="FRequestDate" HeaderText="Request Date" />
                                        <asp:BoundField DataField="Custcode" HeaderText="Customer" />
                                        <asp:BoundField DataField="OrderNo" HeaderText="Order No" />
                                        <asp:BoundField DataField="Sort" HeaderText="Sort No" />
                                        <asp:BoundField DataField="Variant" HeaderText="Variant" />
                                        <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" />
                                        <asp:BoundField DataField="InvoiceDate" HeaderText="InvoiceDate" />
                                         <asp:TemplateField HeaderText="Remarks">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtReturnRemarks" runat="server" CssClass="labelcells">
                                                    
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc" OnClick="LinkButton1_Click">R-Acceptance</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
