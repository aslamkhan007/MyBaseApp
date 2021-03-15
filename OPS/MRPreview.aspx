<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="MRPreview.aspx.cs" Inherits="OPS_MRPreview" %>

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
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Material Request Preview "></asp:Label>
            </td>
        </tr>
        <tr id="Tr1" runat="server" visible="false">
            <td class="NormalText" style="width: 98px">
                <asp:Label ID="Label17" runat="server" Text="Request From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 135px">
                <asp:TextBox ID="txtRequestFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtRequestFrom_CalendarExtender" runat="server" TargetControlID="txtRequestFrom">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRequestFrom"
                    Display="Dynamic" ErrorMessage="**" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 73px">
                <asp:Label ID="Label18" runat="server" Text="Request To"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtRequestTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtRequestTo_CalendarExtender" runat="server" TargetControlID="txtRequestTo">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRequestTo"
                    Display="Dynamic" ErrorMessage="**" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 98px">
                <asp:Label ID="Label19" runat="server" Text="Request ID"></asp:Label>
            </td>
            <td class="NormalText" style="width: 135px">
                <asp:TextBox ID="txtID" runat="server" Columns="10" CssClass="textbox" MaxLength="10"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 73px">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" CausesValidation="false"
                            OnClick="lnkFetch_Click" ValidationGroup="A">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
                        <asp:LinkButton ID="lnkPreview" runat="server" CssClass="buttonc" CausesValidation="false"
                            ValidationGroup="A" onclick="lnkPreview_Click">Preview</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:GridView ID="grdMaterialRequest" runat="server" AutoGenerateSelectButton="True"
                                EnableModelValidation="True" Width="100%" OnRowDataBound="grdMaterialRequest_RowDataBound"
                                OnSelectedIndexChanged="grdMaterialRequest_SelectedIndexChanged" DataKeyNames="RequestID">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
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
                                                        <%--  <asp:BoundField DataField="Reason" HeaderText="Reason"/>--%>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="Label1" runat="server" Text="Authorization "></asp:Label>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server" Visible="true">
                            <asp:GridView ID="grdHistory" runat="server" EnableModelValidation="True" AllowPaging="true"
                                PageSize="15" Width="100%" >
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                <RowStyle CssClass="GridItem" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
         <tr>
            <td class="NormalText">
                <asp:Label ID="Label3" runat="server" Text="PPC And Logistic Authorization"></asp:Label>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel4" runat="server" Visible="true">
                            <asp:GridView ID="grdPPCandLogAuth" runat="server" EnableModelValidation="True"
                                AllowPaging="true" PageSize="15" Width="100%" EmptyDataText="No Record Found">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                <RowStyle CssClass="GridItem" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="Label2" runat="server" Text="Folding Observation"></asp:Label>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel3" runat="server" Visible="true">
                            <asp:GridView ID="grdFoldingObservation" runat="server" EnableModelValidation="True"
                                AllowPaging="true" PageSize="15" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                <RowStyle CssClass="GridItem" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="Label4" runat="server" Text="Sale Order Detail"></asp:Label>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel5" runat="server" Visible="true">
                            <asp:GridView ID="grdOrderDetail" runat="server" EnableModelValidation="True"
                                AllowPaging="true" PageSize="15" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                <RowStyle CssClass="GridItem" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>

    </table>
</asp:Content>
