<%@ Page Title="" Language="C#" MasterPageFile="~/AssetMngmnt/MasterPage.master" AutoEventWireup="true" CodeFile="asset_fur_new_report.aspx.cs" Inherits="AssetMngmnt_asset_fur_new_report" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type = "text/javascript">
    function SetContextKey() {
        $find('<%=txtEmpCode_AutoCompleteExtender.ClientID%>').set_contextKey($get("<%=ddlloc.ClientID %>").value);
    }
</script>
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Summary Report</td>
        </tr>
        <tr>
            <td class="NormalText">
                Location</td>
            <td class="NormalText">
                                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <asp:DropDownList ID="ddlloc" runat="server" CssClass="combobox" AutoPostBack="True" 
                    onselectedindexchanged="ddlloc_SelectedIndexChanged">
                </asp:DropDownList>
                                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                Empcode</td>
            <td class="NormalText">
          <asp:TextBox ID="txtEmpCode" runat="server" CssClass="textbox" onkeyup = "SetContextKey()"></asp:TextBox>

                <cc1:AutoCompleteExtender ID="txtEmpCode_AutoCompleteExtender" runat="server" 
                 CompletionInterval="10" CompletionSetCount="5" MinimumPrefixLength="1" 
                            ServiceMethod="GetEmployeeDepartment_test" TargetControlID="txtEmpCode" 
                            CompletionListCssClass="AutoExtender" 
                            ServicePath="~/WebService.asmx" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList" UseContextKey="True">
                </cc1:AutoCompleteExtender>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtEmpCode" ErrorMessage="*" ValidationGroup="mandatory"></asp:RequiredFieldValidator>

                  <div id="divwidth" style="display:none;">   
                      <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>

               
                
                        </div>  

        </tr>
        <tr>
            <td class="NormalText">
                Sublocation</td>
            <td class="NormalText">
                                  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                <asp:DropDownList ID="ddlsublocation" runat="server" CssClass="combobox">
                </asp:DropDownList>
                                 </ContentTemplate>
                </asp:UpdatePanel>

            </td>

            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                <asp:LinkButton ID="excel" runat="server" CssClass="buttonXL" Height="32px" 
                    onclick="excel_Click" Width="32px"></asp:LinkButton>
            </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <progresstemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </progresstemplate>
                </asp:UpdateProgress>
            </td>
            <tr>
            <td class="buttonbackbar" colspan="4">
                                     <asp:UpdatePanel ID="Updbuttons" runat="server">
                    <ContentTemplate>

                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                    onclick="lnkfetch_Click">Fetch</asp:LinkButton>

                                     </ContentTemplate>
                </asp:UpdatePanel>
<%--                                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonc" 
                    onclick="lnkexcel_Click" Visible="False">Excel</asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
              <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="200px">
                <asp:GridView ID="grdDetail" runat="server" 
                    Width="100%">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <PagerStyle CssClass="PageStyle" />
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
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

