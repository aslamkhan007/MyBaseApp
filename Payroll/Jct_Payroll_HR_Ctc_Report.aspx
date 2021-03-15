<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_Payroll_HR_Ctc_Report.aspx.cs" Inherits="Jct_Payroll_HR_Ctc_Report" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<script type="text/javascript">
    function SetContextKey() {
        $find('<%=txtEmployee_AutoCompleteExtender.ClientID%>').set_contextKey($get("<%=ddlplant.ClientID %>").value);
    }
    </script>

    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
             HR Report:
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Plant
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" 
                    OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
             Report Type
            </td>
            <td class="NormalText">
               
               <asp:DropDownList ID="DropDownList1" runat="server" CssClass="combobox"  
                    AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged"
                    >
                   <asp:ListItem>EmployeeList</asp:ListItem>
                   <asp:ListItem>VariablePay</asp:ListItem>
                   <asp:ListItem>Retirement</asp:ListItem>
                   <asp:ListItem>CostCenter</asp:ListItem>
                   <asp:ListItem>HouseWise</asp:ListItem>
                   <asp:ListItem>JobType</asp:ListItem>
                   <asp:ListItem>WorkingArear</asp:ListItem>
				   <asp:ListItem>SuperAnnuation</asp:ListItem>
				   <asp:ListItem>Insurance</asp:ListItem>
                   <asp:ListItem>Ctc</asp:ListItem>
                </asp:DropDownList>

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
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" Width="32px"
                    OnClick="lnkexcel_Click"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkFetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="tableheader" colspan="4">
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" EmptyDataText="No Record Found" EnableModelValidation="True">
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



