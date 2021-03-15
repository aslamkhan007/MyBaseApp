<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_Payroll_JCT_HR_CTC_Insurance_Report.aspx.cs" Inherits="Payroll_Jct_Payroll_JCT_HR_CTC_Insurance_Report" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <script type="text/javascript">
      function SetContextKey() {
          $find('<%=txtEmployee_AutoCompleteExtender.ClientID%>').set_contextKey($get("<%=ddlplant.ClientID %>").value);
      }
    </script>
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
               Insurance For CTC Report :
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Plant
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" 
                    >
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                </td>
            <td class="NormalText">
                </td>
        </tr>
        <tr>
            
            <td class="labelcells">
                EmployeeCode</td>
            <td class="NormalText">                
                 <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" AutoPostBack="True" 
                    OnTextChanged="txtEmployee_TextChanged" Width="300px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" CompletionInterval="10"
                    CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                    ServiceMethod="GetEmployee_sh_Common" ServicePath="~/WebService.asmx" TargetControlID="txtEmployee"
                    UseContextKey="True">
                </cc1:AutoCompleteExtender>

            </td>

              <td class="labelcells">
                </td>
            <td class="NormalText">
                </td>
        </tr>
        <tr>
             <td class="labelcells">
                </td>
            <td class="NormalText">
                <asp:LinkButton ID="lnkexcel" runat="server"  CssClass="buttonXL"
                    Height="32px" OnClick="lnkexcel_Click" Width="32px"></asp:LinkButton>
                </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                    ValidationGroup="A">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                    OnClick="lnkreset_Click">Reset</asp:LinkButton>
                <asp:LinkButton ID="lnkreset0" runat="server" CssClass="buttonc" 
                    CausesValidation="False" onclick="lnkreset0_Click"
                    >Back</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="1000px" Visible = "false">
                            <asp:GridView ID="grdDetail" runat="server" EnableModelValidation="True" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PageStyle" />
                                <RowStyle CssClass="Griditem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>



