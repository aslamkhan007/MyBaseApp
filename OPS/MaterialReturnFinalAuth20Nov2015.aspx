<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="MaterialReturnFinalAuth.aspx.cs" Inherits="OPS_MaterialReturnFinalAuth" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../Scripts/jquery.min.js"></script>
    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../Image/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "../Image/plus.png");
            $(this).closest("tr").next().remove();
        });
    </script>
    <script type="text/javascript">
        var counter = 0;
        function AddFileUpload() {
            var div = document.createElement('DIV');
            div.innerHTML = '<input id="file' + counter + '" name = "file' + counter + '" type="file" /><input id="Button' + counter + '" type="button" value="Remove" onclick = "RemoveFileUpload(this)" />';
            document.getElementById("FileUploadContainer").appendChild(div);
            counter++;
        }
        function RemoveFileUpload(div) {
            document.getElementById("FileUploadContainer").removeChild(div.parentNode);
        }
    </script>
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="2">
                <asp:Label ID="Label17" runat="server" Text="Material Return  Authorization By Logistics"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 132px">
                <asp:Label ID="Label16" runat="server" Text="Requests Pending"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:Label ID="lblrequests" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" OnClick="lnkFetch_Click">Fetch</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:GridView ID="grdDetail" runat="server" EmptyDataText="No data available" EnableModelValidation="True"
                                OnSelectedIndexChanged="grdDetail_SelectedIndexChanged" Width="100%" OnRowDataBound="grdDetail_RowDataBound">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl" runat="server" Visible="false" Text="**" ForeColor="Red"></asp:Label>
                                            <img id="imageSanctionNoteID-<%# Eval("RequestID") %>" alt="Click to show/hide Description"
                                                border="0" src="../Image/plus.png" />
                                            <div id="SanctionNoteID-<%# Eval("RequestID") %>" style="display: none; position: relative;
                                                left: 25px;">
                                                <asp:GridView ID="nestedGridView_MultipleID" runat="server" Width="100%" AutoGenerateColumns="False">
                                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                                    <HeaderStyle CssClass="GridHeader" />
                                                    <RowStyle CssClass="GridItem" />
                                                    <AlternatingRowStyle CssClass="GridAI" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Invoice" HeaderText="Invoice" />
                                                        <asp:BoundField DataField="Sort" HeaderText="Sort" />
                                                        <asp:BoundField DataField="Customer" HeaderText="Customer" />
                                                        <asp:BoundField DataField="SalesPerson" HeaderText="SalesPerson" />
                                                        <asp:BoundField DataField="InvoiceQty" HeaderText="InvoiceQty" />
                                                        <asp:BoundField DataField="ReturnQty" HeaderText="ReturnQty" />
                                                        <asp:BoundField DataField="Reason" HeaderText="Reason" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                                SelectCommand="JCT_OPS_MATERIAL_REQUEST_FINAL_AUTHORIZATION_DETAILS"></asp:SqlDataSource>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnlEdit" runat="server" CssClass="panelbg" Visible="False">
                            <table style="width: 100%;">
                                <tr>
                                    <td class="NormalText" colspan="4">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" colspan="4">
                                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" colspan="4">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="RequestID9" runat="server">Mr no.</asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 130px">
                                        <asp:TextBox ID="txtMrNo" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td class="NormalText" style="width: 112px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMrNo"
                                            Display="Dynamic" ErrorMessage="**Required Field" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="NormalText">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="RequestID" runat="server">RequestID</asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 130px">
                                        <asp:Label ID="lblRequestID" runat="server"></asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 112px">
                                        <asp:Label ID="lblC" runat="server">Customer</asp:Label>
                                    </td>
                                    <td class="NormalText">
                                        <asp:Label ID="lblCustomer" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="RequestID0" runat="server">Invoice No</asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 130px">
                                        <asp:Label ID="lblInvoiceNo" runat="server" Visible="False"></asp:Label>
                                        <asp:DropDownList ID="ddlInvoiceNo" runat="server" AutoPostBack="True" CssClass="combobox"
                                            OnSelectedIndexChanged="ddlInvoiceNo_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="NormalText" style="width: 112px">
                                        <asp:Label ID="RequestID1" runat="server">Item No</asp:Label>
                                    </td>
                                    <td class="NormalText">
                                        <asp:Label ID="lblItemNo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="RequestID2" runat="server">Invoice Qty</asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 130px">
                                        <asp:Label ID="lblInvoiceQty" runat="server"></asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 112px">
                                        <asp:Label ID="RequestID3" runat="server">Return Qty</asp:Label>
                                    </td>
                                    <td class="NormalText">
                                        <asp:TextBox ID="txtReturnQty" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="RequestID4" runat="server">No of Bales</asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 130px">
                                        <asp:TextBox ID="txtBales" runat="server" Columns="5" CssClass="textbox" MaxLength="10"></asp:TextBox>
                                        <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/Image/save_icon.gif" OnClick="imgSave_Click"
                                            ToolTip="Click To Save No. of Bales..!!" />
                                    </td>
                                    <td class="NormalText" style="width: 112px">
                                        <asp:Label ID="RequestID5" runat="server">Freight Paid By</asp:Label>
                                    </td>
                                    <td class="NormalText">
                                        <asp:DropDownList ID="ddlFreight" runat="server" CssClass="combobox">
                                            <asp:ListItem>By Customer</asp:ListItem>
                                            <asp:ListItem>By Mill</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label ID="lblFreightBy" runat="server" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="RequestID6" runat="server">Gr No</asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 130px">
                                        <asp:TextBox ID="txtGrNo" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td class="NormalText" style="width: 112px">
                                        <asp:Label ID="RequestID7" runat="server">GR Date</asp:Label>
                                    </td>
                                    <td class="NormalText">
                                        <asp:TextBox ID="txtGrDate" runat="server" CssClass="textbox"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtGrDate_CalendarExtender0" runat="server" TargetControlID="txtGrDate">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="RequestID8" runat="server">Freight Value (Amount)</asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 130px">
                                        <asp:TextBox ID="txtAmount" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td class="NormalText" style="width: 112px">
                                        <asp:Label ID="RequestID10" runat="server">Transport</asp:Label>
                                    </td>
                                    <td class="NormalText">
                                        <asp:TextBox ID="txtTransport" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="Label1" runat="server">Enclosures</asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 130px">
                                        <asp:Label ID="lbLEnclosures" runat="server"></asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 112px">
                                        &nbsp;
                                    </td>
                                    <td class="NormalText">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="Label19" runat="server" Text="Physical Docs Received"></asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 130px">
                                        <asp:DropDownList ID="ddlPhysicalDocsRecvd" runat="server" CssClass="combobox" >
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                            ControlToValidate="ddlPhysicalDocsRecvd" Display="Dynamic" ErrorMessage="*" 
                                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="NormalText" style="width: 112px">
                                        &nbsp;
                                    </td>
                                    <td class="NormalText">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        upload
                                    </td>
                                    <td class="NormalText" colspan="3">
                                        <span style="font-family: Arial">Click to add files</span>&nbsp;&nbsp;
                                        <input id="Button2" onclick="AddFileUpload()" type="button" value="add" />
                                        <div id="FileUploadContainer">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="Label18" runat="server">Remarks</asp:Label>
                                    </td>
                                    <td class="NormalText" colspan="2">
                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Height="20px" TextMode="MultiLine"
                                            Width="230px"></asp:TextBox>
                                    </td>
                                    <td class="NormalText">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRemarks"
                                            Display="Dynamic" ErrorMessage="**Required Field" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="buttonbackbar" colspan="4">
                                        <asp:LinkButton ID="lnkAuthorize" runat="server" CssClass="buttonc" OnClick="lnkAuthorize_Click">Authorize</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:FileUpload ID="FileUpload1" runat="server" Height="0px" Width="0px" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdDetail" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
