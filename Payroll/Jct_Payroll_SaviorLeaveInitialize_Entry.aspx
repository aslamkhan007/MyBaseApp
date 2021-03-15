<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_Payroll_SaviorLeaveInitialize_Entry.aspx.cs" Inherits="Payroll_Jct_Payroll_SaviorLeaveInitialize_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<script type="text/javascript">
    function SetContextKey() {
        $find('<%=txtEmployee_AutoCompleteExtender.ClientID%>').set_contextKey($get("<%=ddllocation.ClientID %>").value);
    }
    </script>
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
             Leave Balance Initialization
            </td>
        </tr>
          <tr>
            <td class="NormalText">
                Plant
            </td>
            <td class="NormalText">
    
                <asp:DropDownList ID="ddlplant" runat="server" AutoPostBack="True" CssClass="combobox"
                    OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                Location
            </td>
            <td class="NormalText">


                <asp:DropDownList ID="ddllocation" runat="server"  CssClass="combobox">
                </asp:DropDownList>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddllocation"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
      

          <tr>
            <td class="NormalText">
                            
                <asp:Label ID="lblName" runat="server" CssClass="NormalText" 
                    Text="Search Emplyoee Name" ></asp:Label>

            </td>
            <td class="NormalText">

                <asp:TextBox ID="txtEmployee" runat="server" AutoPostBack="True" 
                    CssClass="textbox" onkeyup="SetContextKey()" 
                    OnTextChanged="txtEmployee_TextChanged" Width="300px"  ></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" 
                    CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                    CompletionListElementID="divwidth" 
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" 
                    MinimumPrefixLength="3" ServiceMethod="LocationWIse_Employee" 
                    ServicePath="~/WebService.asmx" TargetControlID="txtEmployee" 
                    UseContextKey="True">
                </cc1:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmployee"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
      

          <tr>
            <td class="NormalText">
               
               <asp:Label ID="Label150" runat="server" CssClass="NormalText"  Visible ="false"
                    Text="EmployeeName" ></asp:Label>
                            
               </td>
            <td class="NormalText">

                <asp:Label ID="headerEmployeeName" runat="server" CssClass="NormalText"  Visible ="false"
                  ></asp:Label>
                </td>


           <td class="NormalText">
               
               <asp:Label ID="Label151" runat="server" CssClass="NormalText"  Visible ="false"
                    Text="EmployeeCode" ></asp:Label>
                            
               </td>
            <td class="NormalText">

                <asp:Label ID="Headeremployeecode" runat="server" CssClass="NormalText"  Visible ="false"
                  ></asp:Label>
                </td>

            
        </tr>
      


         <tr>
            <td class="NormalText">
               
               <asp:Label ID="Label152" runat="server" CssClass="NormalText"  Visible = "false"
                    Text="LeaveYear" ></asp:Label>
                            
               </td>
            <td class="NormalText">

                <asp:Label ID="headerleaveyr" runat="server" CssClass="NormalText" 
                  ></asp:Label>
                </td>


           <td class="NormalText">
               
               <asp:Label ID="Label153" runat="server" CssClass="NormalText"  Visible = "false"
                    Text="CardNo" ></asp:Label>
                            
               </td>
            <td class="NormalText">

                <asp:Label ID="headercardno" runat="server" CssClass="NormalText" 
                  ></asp:Label>
                </td>

            
        </tr>

 
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" Width="32px" Visible = "false"
                    OnClick="lnkexcel_Click"></asp:LinkButton>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" OnClick="lnkadd_Click"
                    ValidationGroup="A">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                <%--<asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc" 
                    onclick="LinkButton1_Click" >Report</asp:LinkButton>--%>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel4" Width="900px" runat="server" BorderStyle="Solid" Visible="False"
        ScrollBars="Both" Height="70px">
        <table class="mytable">
            <tr>
                <td>
                    <asp:GridView ID="grdDetail" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" 
                        OnRowDataBound="grdDetail_RowDataBound">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <Columns>
                            <asp:BoundField DataField="cardno" HeaderText="CardNo" SortExpression="cardno" />
                            <asp:TemplateField HeaderText="L01_ADD">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAccnum" runat="server" CssClass="textbox" MaxLength="8" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="Flt" runat="server" Enabled="True" TargetControlID="txtAccnum"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="L02_ADD">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHandicapEmployee" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FHandicapEmployee" runat="server" Enabled="True"
                                        TargetControlID="txtHandicapEmployee" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="L03_ADD">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHandicapDependent" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FHandicapDependent" runat="server" Enabled="True"
                                        TargetControlID="txtHandicapDependent" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="L04_ADD">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPublicProvidentFund" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FPublicProvidentFund" runat="server" Enabled="True"
                                        TargetControlID="txtPublicProvidentFund" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="L05_ADD">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtLifeInsuranceCorporation" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FLifeInsuranceCorporation" runat="server" Enabled="True"
                                        TargetControlID="txtLifeInsuranceCorporation" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="L06_ADD">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNationalSavingCertificate8" runat="server" CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FNationalSavingCertificate8" runat="server" Enabled="True"
                                        TargetControlID="txtNationalSavingCertificate8" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="L01">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHouseingLoanPayment" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FHouseingLoanPayment" runat="server" Enabled="True"
                                        TargetControlID="txtHouseingLoanPayment" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="L02">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtINFRA" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FINFRA" runat="server" Enabled="True" TargetControlID="txtINFRA"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="L03">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtUNITLN" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="UNITLN" runat="server" Enabled="True" TargetControlID="txtUNITLN"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="L04">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMedical_Insurance" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FMedical_Insurance" runat="server" Enabled="True"
                                        TargetControlID="txtMedical_Insurance" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="L05">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSENIOR" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FSENIOR" runat="server" Enabled="True" TargetControlID="txtSENIOR"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="L06">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNPS" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FNPS" runat="server" Enabled="True" TargetControlID="txtNPS"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                                                            
                        </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="buttonbackbar" colspan="4">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <table class="mytable">
            <tr>
                <td class="buttonbackbar" colspan="4">
                    <asp:LinkButton ID="lnkapply" runat="server" CssClass="buttonc" ValidationGroup="A"
                        OnClick="lnkapply_Click">Save</asp:LinkButton>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

