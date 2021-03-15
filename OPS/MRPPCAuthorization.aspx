<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OPS/MasterPage.master"
    CodeFile="MRPPCAuthorization.aspx.cs" Inherits="OPS_MRPPCAuthorization" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        var counter = 0;
        function AddFileUpload() {
            var div = document.createElement('DIV');
            div.innerHTML = '<input id="file' + counter + '" name = "file' + counter + '" type="file"  /><input id="Button' + counter + '" type="button" value="Remove" onclick = "RemoveFileUpload(this)" />';
            document.getElementById("FileUploadContainer").appendChild(div);

            counter++;
        }
        function RemoveFileUpload(div) {
            document.getElementById("FileUploadContainer").removeChild(div.parentNode);
        }
    </script>
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
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="2">
                <asp:Label ID="Label17" runat="server" Text="Material Return  Authorization By PPC"></asp:Label>
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
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" Visible="false" OnClick="lnkFetch_Click">Fetch</asp:LinkButton>
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
                            <asp:GridView ID="grdDetail" runat="server" DataKeyNames="RequestID" EmptyDataText="No data available"
                                EnableModelValidation="True" OnSelectedIndexChanged="grdDetail_SelectedIndexChanged"
                                Width="100%" OnRowDataBound="grdDetail_RowDataBound" AllowPaging="True" OnPageIndexChanging="grdDetail_PageIndexChanging"
                                PageSize="5">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl" runat="server" Visible="false" Text="" ForeColor="Red"></asp:Label>
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
                                                        <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" />
                                                        <asp:BoundField DataField="InvoiceDate" HeaderText="Invoice Date" />
                                                        <asp:BoundField DataField="SortNo" HeaderText="Sort" />
                                                        <asp:BoundField DataField="Customer" HeaderText="Customer" />
                                                        <asp:BoundField DataField="SalePerson" HeaderText="SalesPerson" />
                                                        <asp:BoundField DataField="InvoiceQty" HeaderText="InvoiceQty" />
                                                        <asp:BoundField DataField="SalePrice" HeaderText="SalePrice" />
                                                        <asp:BoundField DataField="ReturnQty" HeaderText="ReturnQty" />
                                                        <asp:BoundField DataField="Reason" HeaderText="Reason" />
                                                        <asp:BoundField DataField="ActionToBeTaken" HeaderText="ActionToBeTaken" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                <RowStyle CssClass="GridItem" />
<SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                            <%--     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                                SelectCommand="JCT_OPS_MATERIAL_REQUEST_FINAL_AUTHORIZATION_DETAILS"></asp:SqlDataSource>--%>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkAuthorize" EventName="Click" />
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
                                <%-- <tr>
                                    <td class="NormalText" colspan="4">
                                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" colspan="4">
                                        &nbsp;
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="RequestID9" runat="server">Mr no.</asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 130px">
                                        <asp:TextBox ID="txtMrNo" runat="server" Enabled="false" CssClass="textbox"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMrNo"
                                            Display="Dynamic" ErrorMessage="Required **" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="NormalText">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="Label1" runat="server">Category</asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 130px">
                                        <asp:TextBox ID="txtcategory" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcategory"
                                            Display="Dynamic" ErrorMessage="Required **" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="NormalText">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="Label18" runat="server">Action</asp:Label>
                                    </td>
                                    <td class="NormalText" colspan="2">
                                        <asp:DropDownList ID="ddlAction" runat="server" CssClass="combobox">
                                            <asp:ListItem Text="Select" Value="Select" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Authorize" Value="A"></asp:ListItem>
                                            <asp:ListItem Text="Cancel" Value="C"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlAction"
                                            Display="Dynamic" ErrorMessage="Required **" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="NormalText">
                                    </td>
                                </tr>
								
								 <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="Label5" runat="server">Remarks</asp:Label>
                                    </td>
                                    <td width="400px" align="left" valign="top">
                                        <asp:TextBox ID="txtBckOffRmrks" runat="server" CssClass="textbox" Height="100px" MaxLength="500"
                                            TextMode="MultiLine" Width="90%"></asp:TextBox>
                                       <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtBckOffRmrks"
                                        Display="Dynamic" ErrorMessage="Required **" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                                    </td>
                                </tr>
								
                                <tr>
                                    <td class="buttonbackbar" colspan="4">
                                        <asp:LinkButton ID="lnkAuthorize" runat="server" CssClass="buttonc" BorderStyle="None"
                                            OnClick="lnkAuthorize_Click">Auth/Cancel</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        &nbsp;
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
    <table style="width: 100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server">
                            <asp:GridView ID="grdPending" runat="server" Visible="true" DataKeyNames="RequestID"
                                EmptyDataText="No data available" EnableModelValidation="True" Width="100%" AllowPaging="True"
                                PageSize="5" OnPageIndexChanging="grdPending_PageIndexChanging" OnSelectedIndexChanged="grdPending_SelectedIndexChanged">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div id="SanctionNoteID-<%# Eval("RequestID") %>" style="display: none; position: relative;
                                                left: 25px;">
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                <RowStyle CssClass="GridItem" />
<SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkAuthorize" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkSend" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnllogsend" runat="server" CssClass="panelbg">
                            <table style="width: 100%;">
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="Label2" runat="server">Mr no.</asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 130px">
                                        <asp:TextBox ID="txtMRNumber" runat="server" Enabled="false" CssClass="textbox"></asp:TextBox>
                                        <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMRNumber"
                                            Display="Dynamic" ErrorMessage="Required **" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                                    </td>
                                    <td class="NormalText">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="Label3" runat="server">Order Number</asp:Label>
                                    </td>
                                    <td class="NormalText" style="width: 130px">
                                        <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox"></asp:TextBox>
                                        <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtOrderNo"
                                            Display="Dynamic" ErrorMessage="Required **" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                                    </td>
                                    <td class="NormalText">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="NormalText" style="width: 158px">
                                        <asp:Label ID="Label4" runat="server">Remarks</asp:Label>
                                    </td>
                                    <td width="400px" align="left" valign="top">
                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Height="100px" MaxLength="500"
                                            TextMode="MultiLine" Width="90%"></asp:TextBox>
                                        <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRemarks"
                                        Display="Dynamic" ErrorMessage="Required **" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="buttonbackbar" colspan="4">
                                        <asp:LinkButton ID="lnkSend" runat="server" CssClass="buttonc" BorderStyle="None"
                                            OnClick="lnkSend_Click">Send</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdPending" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
