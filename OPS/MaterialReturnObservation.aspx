<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="MaterialReturnObservation.aspx.cs" Inherits="OPS_MaterialReturnObservation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        var counter = 0;
        function AddFileUpload() {
            var div = document.createElement('DIV');
            div.innerHTML = '<input id="file' + counter + '" name = "file' + counter +
                            '" type="file" />' +
                            '<input id="Button' + counter + '" type="button" ' +
                            'value="Remove" onclick = "RemoveFileUpload(this)" />';

            document.getElementById("FileUploadContainer").appendChild(div);
            counter++;
        }

        function RemoveFileUpload(div) {
            document.getElementById("FileUploadContainer").removeChild(div.parentNode);
        }

    </script>

    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Folding Observation
            </td>
        </tr>
        <tr>
            <td colspan="1">
                Observation Type
            </td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdObservationType" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlObservationType" runat="server" AutoPostBack="True" CssClass="combobox"
                            OnSelectedIndexChanged="ddlObservationType_SelectedIndexChanged">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Normal Return</asp:ListItem>
                            <asp:ListItem>Excess Return</asp:ListItem>
                            <asp:ListItem>Short Return</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="1">
                Request ID
            </td>
            <td>
                <asp:TextBox ID="txtRequest" runat="server" Text="">
                </asp:TextBox>
                <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" OnClick="lnkFetch_Click">Fetch</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <%--  <asp:Label ID="lblMr" runat="server" Text="Material Return Type"></asp:Label>--%>
                        <asp:TextBox ID="txtID" runat="server" CssClass="textbox"></asp:TextBox>
                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Reterive</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" EnableModelValidation="True"
                            AllowPaging="true" PageSize="15" Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                            OnPageIndexChanging="GridView1_PageIndexChanging">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl" runat="server" Visible="false" Text="**" ForeColor="Red"></asp:Label>
                                        <%--  <img id="imageSanctionNoteID-<%# Eval("SanctionNoteID") %>" alt="Click to show/hide Description" border="0" src="../Image/plus.png" />  
                                            <div id="SanctionNoteID-<%# Eval("SanctionNoteID") %>" style="display:none;position:relative;left:25px;">
                                             <asp:GridView ID="nestedGridView" runat="server" Width="100%" 
                    AutoGenerateColumns="False"  >
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <HeaderStyle CssClass="GridHeader" />
                    <RowStyle CssClass="GridItem" />
                        <AlternatingRowStyle CssClass="GridAI" />
                                  <Columns>
                            <asp:BoundField DataField="Description" HeaderText="Description"/>
                          
                    </Columns>
                </asp:GridView>--%>
                                        <hr />
                                        <asp:GridView ID="nestedGridView_MultipleID" runat="server" Width="100%" AutoGenerateColumns="False">
                                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                                            <HeaderStyle CssClass="GridHeader" />
                                            <RowStyle CssClass="GridItem" />
                                            <AlternatingRowStyle CssClass="GridAI" />
                                            <Columns>
                                                <%--  <asp:BoundField DataField="Invoice" HeaderText="Invoice"/>--%>
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
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                            <RowStyle CssClass="GridItem" />
                            <SelectedRowStyle CssClass="GridRowGreen" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlObservationType" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="LinkButton1" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="LinkButton3" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="Grdinvoices" runat="server" EnableModelValidation="True" ShowHeaderWhenEmpty="true"
                            ShowHeader="true" Width="100%" AutoGenerateColumns="False" OnSelectedIndexChanged="Grdinvoices_SelectedIndexChanged">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:ButtonField DataTextField="Invoice_No" HeaderText="Select" CommandName="Select" />
                                <asp:BoundField HeaderText="Invoice No" DataField="Invoice_No" />
                                <asp:BoundField HeaderText="Order No" DataField="OrderNo" />
                                <asp:BoundField HeaderText="Sort" DataField="SortNo" />
                                <asp:BoundField HeaderText="Invoice Qty" DataField="InvoiceQty" />
                                <asp:BoundField HeaderText="Return Qty" DataField="ReturnQty" />
                                <asp:BoundField HeaderText="Meters" DataField="Meters" />
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                            <SelectedRowStyle CssClass="GridRowGreen" />
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
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdObservation" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView2" runat="server" EnableModelValidation="True" ShowHeaderWhenEmpty="true"
                            ShowHeader="true" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand"
                            OnRowDataBound="GridView2_RowDataBound" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgDelRows" runat="server" CausesValidation="True" ImageUrl="~/Image/Icons/close.png"
                                            CommandName="deleterow" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- Added 3 Dec 2015--%>
                                <asp:BoundField HeaderText="Invoice No" DataField="Invoice_No" />
                                <asp:BoundField HeaderText="Invoice Qty" DataField="InvoiceQty" />
                                <asp:BoundField HeaderText="Order No" DataField="OrderNo" />
                                <%-- <asp:TemplateField HeaderText="Order Line">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlOrderLines" runat="server" CssClass="combobox">
                                        </asp:DropDownList>
                                      
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:BoundField HeaderText="Sort" DataField="SortNo" />
                                <%-- Added 3 Dec 2015--%>
                                <asp:TemplateField HeaderText="Shade">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtShade" runat="server" CssClass="textbox" CausesValidation="true"
                                            Text='<%# Eval("Shade") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredShade" runat="server" ErrorMessage="*" ControlToValidate="txtShade"
                                            ValidationGroup="mandatory"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Packing Type">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlPackingType" runat="server" CssClass="combobox" AutoPostBack="True">
                                            <asp:ListItem>Company</asp:ListItem>
                                            <asp:ListItem>Customer</asp:ListItem>
                                            <asp:ListItem>Mix</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label ID="lblShowText" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Meters">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMeters" runat="server" CssClass="textbox" ValidationGroup="mandatory"
                                            CausesValidation="true" Text='<%# Eval("Meters") %>'></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtMeters"
                                            ValidChars="0123456789" FilterType="Numbers">
                                        </cc1:FilteredTextBoxExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                            ControlToValidate="txtMeters" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlType" runat="server" CssClass="combobox">
                                            <asp:ListItem>FR</asp:ListItem>
                                            <asp:ListItem>ST</asp:ListItem>
                                            <asp:ListItem>SM</asp:ListItem>
                                            <asp:ListItem>SW</asp:ListItem>
                                            <asp:ListItem>SF</asp:ListItem>
                                            <asp:ListItem>FN</asp:ListItem>
                                            <asp:ListItem>RG</asp:ListItem>
                                            <asp:ListItem>CH</asp:ListItem>
                                            <asp:ListItem>SP</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Observation">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtObservation" runat="server" CssClass="textbox" Text='<%# Eval("Observation") %>'
                                            CausesValidation="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredObservation" runat="server" ErrorMessage="*"
                                            ControlToValidate="txtObservation" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Reason">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlReason" runat="server" CssClass="combobox" DataSourceID="SqlDataSourceReason"
                                            DataTextField="Reason" DataValueField="Reason">
                                            <%-- <asp:ListItem>Crease</asp:ListItem>
                                        <asp:ListItem>Strain</asp:ListItem>
                                        <asp:ListItem>Burn</asp:ListItem>--%>
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourceReason" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                                            SelectCommand="SELECT DISTINCT Reason,Description FROM	Jct_Ops_Folding_Observation_Reason WHERE STATUS = 'A' ORDER BY Description ">
                                        </asp:SqlDataSource>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                            <SelectedRowStyle CssClass="GridRowGreen" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkaddrow" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
            </td>
            <td>
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
            <td colspan="4">
            </td>
        </tr>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc" CausesValidation="True"
                            OnClick="LinkButton1_Click" ValidationGroup="mandatory">Apply</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="buttonc" OnClick="LinkButton2_Click">Reset</asp:LinkButton>
                        <asp:LinkButton ID="lnkaddrow" runat="server" CssClass="buttonc" CausesValidation="True"
                            OnClick="lnkaddrow_Click" ValidationGroup="mandatory">AddRow</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView3" runat="server" AutoGenerateSelectButton="True" EnableModelValidation="True"
                    AllowPaging="true" PageSize="10" Width="100%" Caption="Pending Requests:" CaptionAlign="Left">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lbl0" runat="server" Visible="false" Text="**" ForeColor="Red"></asp:Label>
                                <hr />
                                <asp:GridView ID="nestedGridView_MultipleID0" runat="server" Width="100%" AutoGenerateColumns="False">
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
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
        </tr>
        <tr>
            <td colspan="4">
        </tr>
        <tr>
            <td>
                <%--                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>--%>
                <asp:DataList ID="DataList2" runat="server" RepeatColumns="6" RepeatDirection="Horizontal"
                    OnItemCommand="DataList2_ItemCommand">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <div style="margin: auto; width: 64px">
                                        <asp:ImageButton ID="ImageButton1" runat="server" AlternateText='<%# Eval("RefDocActFileName") %>'
                                            ImageUrl='<%# Eval("LogoImgPath") %>' Visible="False" Width="64px" />
                                        <asp:Image ID="Image2" runat="server" AlternateText='<%# Eval("RefDocActFileName") %>'
                                            ImageUrl='<%# Eval("LogoImgPath") %>' Width="64px" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="NormalText" style="text-align: center">
                                    <asp:LinkButton ID="HyperLink1" runat="server" CommandArgument='<%# Eval("RefDocActFileName") %>'
                                        CommandName="Download" NavigateUrl='<%# Eval("RefDocFilePath") %>' Text='<%# Eval("RefDocActFileName") %>'></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <%--                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="imgUpload" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>--%>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <div id="FileUploadContainer">
                </div>
                &nbsp;<img alt="Add File" src="../Image/Icons/Action/document_add.png" onclick="AddFileUpload()"
                    width="48" />
                    <asp:ImageButton AlternateText="Upload File(s)" ID="imgUpload" runat="server"
                        OnClick="btnUpload_Click" ImageUrl="~/OPS/Image/Upload.png" Width="48px" />
            </td>
        </tr>
    </table>
</asp:Content>
