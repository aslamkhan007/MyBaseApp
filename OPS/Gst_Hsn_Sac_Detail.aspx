<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="Gst_Hsn_Sac_Detail.aspx.cs" Inherits="OPS_Gst_Hsn_Sac_Detail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<script type="text/javascript">
        function SetContextKey()
        { var x = document.GetelementbyId("txtstate"); $find('txtcity_AutoCompleteExtender').set_contextKey(x.value); return; }
    </script>--%>
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                GST Item Detail :
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Item
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtItem" runat="server" CssClass="textbox" Width="150px" AutoPostBack="True"
                    OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                <div id="divwidth" style="display: none;">
                    <cc1:AutoCompleteExtender ID="txtSupplierName_AutoCompleteExtender" runat="server"
                        TargetControlID="txtItem" CompletionInterval="1" FirstRowSelected="True"
                        MinimumPrefixLength="1" ServiceMethod="StockItemList" ServicePath="~/WebService.asmx"
                        CompletionListElementID="divwidth" CompletionListCssClass="AutoExtender" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                        CompletionListItemCssClass="AutoExtenderList">
                    </cc1:AutoCompleteExtender>
                </div>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Stock Description
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtStockDesc" runat="server" CssClass="textbox" Width="250px" 
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 18px">
                Varient Description
            </td>
            <td class="NormalText" style="height: 18px">
                <asp:TextBox ID="txtVarientDesc" runat="server" CssClass="textbox" ReadOnly="True"
                    Width="250px" ></asp:TextBox>
            </td>
            <td class="labelcells" style="height: 18px">
            </td>
            <td class="labelcells" style="height: 18px">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                GST Class
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlGstClass" runat="server" CssClass="combobox" AppendDataBoundItems="True">
                    <asp:ListItem Selected="True">GST</asp:ListItem>
                    <asp:ListItem>EXEMPTED</asp:ListItem>
                    <asp:ListItem>NONE</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                HSN/SAC No
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtHsnSacNo" runat="server" CssClass="textbox" Width="150px"></asp:TextBox>
            </td>
            <td class="labelcells">
                HSN/SAC&nbsp; 
                Desc</td>
            <td class="NormalText">
                <asp:TextBox ID="txtlocdesc0" runat="server" CssClass="textbox" Height="30px" Width="250px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Reverse Charges
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlReverseCharge" runat="server" CssClass="combobox" 
                    AppendDataBoundItems="True">
                    <asp:ListItem Selected="True">N</asp:ListItem>
                    <asp:ListItem>Y</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" OnClick="lnkadd_Click"
                    ValidationGroup="A">Apply</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                                                                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                 <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" Visible="False"
                    Width="1000px">

                    <%--<asp:GridView ID="grdDetail" runat="server" 
                     Width="100%">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="GirdItem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>--%>

                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
