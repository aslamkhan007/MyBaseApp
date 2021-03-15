<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_Payroll_TaxHra_Exemption.aspx.cs" Inherits="Payroll_Jct_Payroll_TaxHra_Exemption" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--    <script type="text/javascript">
        function SetContextKey() {
            $find('<%=AutoCompleteExtender1.ClientID%>').set_contextKey($get("<%=ddlLocation.ClientID %>").value);
        }
    </script>--%>
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                HRA Affidavit:
            </td>
        </tr>

         <tr>
            <td class="labelcells">
              Type
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldedtype" runat="server" CssClass="combobox"
                    OnSelectedIndexChanged="ddldedtype_SelectedIndexChanged" AppendDataBoundItems="True"
                    DataTextField="Deduction_Short_Description" 
                    DataValueField="Deduction_code" AutoPostBack="True">                   
                    <asp:ListItem >Tax Salary Details</asp:ListItem>
                    <asp:ListItem >Comparision</asp:ListItem>
                          <asp:ListItem Selected="True">HRA Affidavit</asp:ListItem>
                                       
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
            <td class="labelcells">
                FI Year
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="80px" 
                    ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttodate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
           
                <%--Plant--%></td>
            <td class="NormalText">
                
                <%--<asp:DropDownList ID="ddlplant" runat="server" AutoPostBack="True" 
                    CssClass="combobox" OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
                --%>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
               
                <asp:Label ID="lblSearchEmployeeName" runat="server">SearchEmployee</asp:Label>
            </td>
            <td class="NormalText">
               
                <asp:TextBox ID="txtEmployee" runat="server" AutoPostBack="True" 
                    CssClass="textbox" OnTextChanged="txtEmployee_TextChanged" Width="300px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" 
                    CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                    CompletionListElementID="divwidth" 
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" 
                    MinimumPrefixLength="3" ServiceMethod="GetEmployee_sh_Common" 
                    ServicePath="~/WebService.asmx" TargetControlID="txtEmployee">
                </cc1:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtEmployee" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
              
                &nbsp;</td>
            <td class="NormalText">
              
                
              
            </td>
        </tr>
        <tr>

           <td class="labelcells">
                <asp:Label ID="employeename" runat="server" Text="Employee Name" ></asp:Label>
            </td>
            <td class="labelcells">
                &nbsp;<asp:Label ID="lblEmployeeName" runat="server" ></asp:Label>
            </td>

            <td class="labelcells">
               
                <asp:Label ID="employeename0" runat="server" Text="Department" ></asp:Label>
               
            </td>
            <td class="labelcells">
                <%--<asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" AutoPostBack="True"
                    onkeyup="SetContextKey()" OnTextChanged="txtEmployee_TextChanged" Width="300px"
                    Visible="False"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10"
                    CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                    ServiceMethod="LocationWIse_Employee" ServicePath="~/WebService.asmx" TargetControlID="txtEmployee"
                    UseContextKey="True">
                </cc1:AutoCompleteExtender>--%>

                  


                <asp:Label ID="lbldept" runat="server" ></asp:Label>

                  


            </td>
         
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblamount" runat="server" >Value</asp:Label>
            </td>
            <td class="NormalText">
                <%--<telerik:RadNumericTextBox ID="txtBasic" runat="server" CausesValidation="True" Culture="en-US"
                    DataType="System.Int32" DbValueFactor="1" EmptyMessage="Maximum Value 15000"
                    inputtype="Number" LabelWidth="32px" MaxLength="10" MinValue="1" ValidationGroup="mandatory"
                    Width="30" MaxValue="15000">
                    <NumberFormat DecimalDigits="0" />
                </telerik:RadNumericTextBox>--%>
                <asp:TextBox ID="txtBasic" runat="server" CssClass="textbox" Width="50px" MaxLength="1"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtunitrate_FilteredTextBoxExtender" runat="server"
                    Enabled="True" TargetControlID="txtBasic" ValidChars="1234567890">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBasic"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>


            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" OnClick="lnkexcel_Click"
                    Width="32px"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                    ValidationGroup="A">Apply</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                    OnClick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="1000px">
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

