<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="JCT_Payroll_Tax_Master_Update.aspx.cs" Inherits="Payroll_JCT_Payroll_Tax_Master_Update" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   <script type="text/javascript">
       function SetContextKey() {
           $find('<%=txtEmployee_AutoCompleteExtender.ClientID%>').set_contextKey($get("<%=ddlLocation.ClientID %>").value);
       }
    </script>

    <table class="mytable">

        

        <tr>
            <td class="tableheader" colspan="4">
                Tax Salary Details
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
                    <asp:ListItem Selected="True">Tax Salary Details</asp:ListItem>
                    <asp:ListItem>Comparision</asp:ListItem>
                    <asp:ListItem>HRA Affidavit</asp:ListItem>
                                       
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
                FIYear
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttodate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
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
                Plant
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" AutoPostBack="True" CssClass="combobox"
                    OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlplant"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                Location
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="True" CssClass="combobox">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlLocation"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Search Emplyoee Name
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" AutoPostBack="True"
                    onkeyup="SetContextKey()" OnTextChanged="txtEmployee_TextChanged" Width="300px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" CompletionInterval="10"
                    CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                    ServiceMethod="LocationWIse_Employee" ServicePath="~/WebService.asmx" TargetControlID="txtEmployee">
                </cc1:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmployee"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" Width="32px"
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
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc" 
                    OnClick="LinkButton1_Click">Report</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel4" Width="900px" runat="server" BorderStyle="Solid" Visible="False"
        ScrollBars="Both" Height="100px">
        <table class="mytable">
            <tr>
                <td>
                    <asp:GridView ID="grdDetail" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                        OnRowDataBound="grdDetail_RowDataBound">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <Columns>
                            <asp:BoundField DataField="Empcode" HeaderText="EmployeeCode" SortExpression="Empcode" />

                            <asp:BoundField DataField="Empname" HeaderText="Empname" SortExpression="Empname" />
               
                
                            <asp:TemplateField HeaderText="Panno">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPanno" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Panno") %>'>></asp:TextBox>                                   
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:BoundField DataField="Housetype" HeaderText="Housetype" SortExpression="Housetype" />

                                  


                            <asp:TemplateField HeaderText="Sal_04">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSal_04" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Sal04") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="fl11" runat="server" Enabled="True" TargetControlID="txtSal_04"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Sal05">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSal05" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Sal05") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt2" runat="server" Enabled="True" TargetControlID="txtSal05"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sal06">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSal06" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Sal06") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt3" runat="server" Enabled="True" TargetControlID="txtSal06"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sal07">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSal07" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Sal07") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt4" runat="server" Enabled="True" TargetControlID="txtSal07"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sal08">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSal08" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Sal08") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt5" runat="server" Enabled="True" TargetControlID="txtSal08"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sal09">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSal09" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Sal09") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt6" runat="server" Enabled="True" TargetControlID="txtSal09"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sal10">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSal10" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Sal10") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt7" runat="server" Enabled="True" TargetControlID="txtSal10"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sal11">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSal11" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Sal11") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt8" runat="server" Enabled="True" TargetControlID="txtSal11"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sal12">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSal12" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Sal12") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt9" runat="server" Enabled="True" TargetControlID="txtSal12"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sal13">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSal13" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Sal13") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt10" runat="server" Enabled="True" TargetControlID="txtSal13"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sal14">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSal14" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Sal14") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt11" runat="server" Enabled="True" TargetControlID="txtSal14"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sal_15">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSal_15" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Sal_15") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt12" runat="server" Enabled="True" TargetControlID="txtSal_15"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hra04">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHra04" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Hra04") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt13" runat="server" Enabled="True" TargetControlID="txtHra04"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hra05">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHra05" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Hra05") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt14" runat="server" Enabled="True" TargetControlID="txtHra05"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hra06">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHra06" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Hra06") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt15" runat="server" Enabled="True" TargetControlID="txtHra06"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hra07">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHra07" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Hra07") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt16" runat="server" Enabled="True" TargetControlID="txtHra07"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hra08">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHra08" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Hra08") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt17" runat="server" Enabled="True" TargetControlID="txtHra08"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hra09">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHra09" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Hra09") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt18" runat="server" Enabled="True" TargetControlID="txtHra09"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hra10">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHra10" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Hra10") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt19" runat="server" Enabled="True" TargetControlID="txtHra10"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hra11">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHra11" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Hra11") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt20" runat="server" Enabled="True" TargetControlID="txtHra11"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hra12">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHra12" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Hra12") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt21" runat="server" Enabled="True" TargetControlID="txtHra12"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hra13">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHra13" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Hra13") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt22" runat="server" Enabled="True" TargetControlID="txtHra13"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hra14">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHra14" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Hra14") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt23" runat="server" Enabled="True" TargetControlID="txtHra14"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hra15">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHra15" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Hra15") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt24" runat="server" Enabled="True" TargetControlID="txtHra15"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fa04">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFa04" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Fa04") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt25" runat="server" Enabled="True" TargetControlID="txtFa04"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fa05">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFa05" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Fa05") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt26" runat="server" Enabled="True" TargetControlID="txtFa05"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fa06">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFa06" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Fa06") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt27" runat="server" Enabled="True" TargetControlID="txtFa06"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fa07">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFa07" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Fa07") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt28" runat="server" Enabled="True" TargetControlID="txtFa07"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fa08">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFa08" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Fa08") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt29" runat="server" Enabled="True" TargetControlID="txtFa08"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fa09">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFa09" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Fa09") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt30" runat="server" Enabled="True" TargetControlID="txtFa09"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fa10">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFa10" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Fa10") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt31" runat="server" Enabled="True" TargetControlID="txtFa10"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fa11">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFa11" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Fa11") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt32" runat="server" Enabled="True" TargetControlID="txtFa11"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fa12">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFa12" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Fa12") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt33" runat="server" Enabled="True" TargetControlID="txtFa12"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fa13">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFa13" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Fa13") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt34" runat="server" Enabled="True" TargetControlID="txtFa13"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fa14">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFa14" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Fa14") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt35" runat="server" Enabled="True" TargetControlID="txtFa14"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fa15">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFa15" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Fa15") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt36" runat="server" Enabled="True" TargetControlID="txtFa15"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Uni04">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtUni04" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Uni04") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt37" runat="server" Enabled="True" TargetControlID="txtUni04"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Uni05">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtUni05" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Uni05") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt38" runat="server" Enabled="True" TargetControlID="txtUni05"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Uni06">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtUni06" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Uni06") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt39" runat="server" Enabled="True" TargetControlID="txtUni06"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Uni07">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtUni07" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Uni07") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt40" runat="server" Enabled="True" TargetControlID="txtUni07"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Uni08">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtUni08" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Uni08") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt41" runat="server" Enabled="True" TargetControlID="txtUni08"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Uni09">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtUni09" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Uni09") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt42" runat="server" Enabled="True" TargetControlID="txtUni09"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Uni10">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtUni10" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Uni10") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt43" runat="server" Enabled="True" TargetControlID="txtUni10"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Uni11">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtUni11" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Uni11") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt44" runat="server" Enabled="True" TargetControlID="txtUni11"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Uni12">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtUni12" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Uni12") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt45" runat="server" Enabled="True" TargetControlID="txtUni12"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Uni13">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtUni13" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Uni13") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt46" runat="server" Enabled="True" TargetControlID="txtUni13"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Uni14">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtUni14" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Uni14") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt47" runat="server" Enabled="True" TargetControlID="txtUni14"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Uni15">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtUni15" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Uni15") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt48" runat="server" Enabled="True" TargetControlID="txtUni15"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pf04">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPf04" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Pf04") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt49" runat="server" Enabled="True" TargetControlID="txtPf04"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pf05">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPf05" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Pf05") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt50" runat="server" Enabled="True" TargetControlID="txtPf05"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pf06">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPf06" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Pf06") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt51" runat="server" Enabled="True" TargetControlID="txtPf06"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pf07">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPf07" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Pf07") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt52" runat="server" Enabled="True" TargetControlID="txtPf07"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pf08">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPf08" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Pf08") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt53" runat="server" Enabled="True" TargetControlID="txtPf08"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pf09">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPf09" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Pf09") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt54" runat="server" Enabled="True" TargetControlID="txtPf09"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pf10">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPf10" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Pf10") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt55" runat="server" Enabled="True" TargetControlID="txtPf10"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pf11">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPf11" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Pf11") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt56" runat="server" Enabled="True" TargetControlID="txtPf11"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pf12">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPf12" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Pf12") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt57" runat="server" Enabled="True" TargetControlID="txtPf12"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pf13">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPf13" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Pf13") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt58" runat="server" Enabled="True" TargetControlID="txtPf13"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pf14">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPf14" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Pf14") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt59" runat="server" Enabled="True" TargetControlID="txtPf14"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pf15">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPf15" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Pf15") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt60" runat="server" Enabled="True" TargetControlID="txtPf15"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="It04">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtIt04" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("It04") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt61" runat="server" Enabled="True" TargetControlID="txtIt04"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="It05">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtIt05" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("It05") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt62" runat="server" Enabled="True" TargetControlID="txtIt05"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="It06">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtIt06" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("It06") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt63" runat="server" Enabled="True" TargetControlID="txtIt06"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="It07">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtIt07" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("It07") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt64" runat="server" Enabled="True" TargetControlID="txtIt07"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="It08">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtIt08" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("It08") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt65" runat="server" Enabled="True" TargetControlID="txtIt08"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="It09">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtIt09" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("It09") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt66" runat="server" Enabled="True" TargetControlID="txtIt09"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="It10">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtIt10" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("It10") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt67" runat="server" Enabled="True" TargetControlID="txtIt10"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="It11">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtIt11" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("It11") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt68" runat="server" Enabled="True" TargetControlID="txtIt11"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="It12">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtIt12" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("It12") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt69" runat="server" Enabled="True" TargetControlID="txtIt12"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="It13">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtIt13" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("It13") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt70" runat="server" Enabled="True" TargetControlID="txtIt13"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="It14">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtIt14" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("It14") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt71" runat="server" Enabled="True" TargetControlID="txtIt14"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="It15">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtIt15" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("It15") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt72" runat="server" Enabled="True" TargetControlID="txtIt15"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Prf04">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrf04" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Prf04") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt7214" runat="server" Enabled="True" TargetControlID="txtPrf04"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Prf05">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrf05" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Prf05") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt7213" runat="server" Enabled="True" TargetControlID="txtPrf05"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Prf06">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrf06" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Prf06") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt7212" runat="server" Enabled="True" TargetControlID="txtPrf06"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Prf07">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrf07" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Prf07") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt7211" runat="server" Enabled="True" TargetControlID="txtPrf07"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Prf08">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrf08" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Prf08") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt7210" runat="server" Enabled="True" TargetControlID="txtPrf08"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Prf09">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrf09" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Prf09") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="fltPrf09" runat="server" Enabled="True" TargetControlID="txtPrf09"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Prf10">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrf10" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Prf10") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt726" runat="server" Enabled="True" TargetControlID="txtPrf10"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Prf11">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrf11" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Prf11") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt725" runat="server" Enabled="True" TargetControlID="txtPrf11"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Prf12">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrf12" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Prf12") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt724" runat="server" Enabled="True" TargetControlID="txtPrf12"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Prf13">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrf13" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Prf13") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt723" runat="server" Enabled="True" TargetControlID="txtPrf13"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Prf14">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrf14" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Prf14") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt722" runat="server" Enabled="True" TargetControlID="txtPrf14"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Prf15">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrf15" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("Prf15") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt721" runat="server" Enabled="True" TargetControlID="txtPrf15"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>










                                     <asp:TemplateField HeaderText="TaxConveyanceAmt">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtTaxConveyanceAmt" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("TaxConveyanceAmt") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt77" runat="server" Enabled="True" TargetControlID="txtTaxConveyanceAmt"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>

                                     <asp:TemplateField HeaderText="YrTaxableConveyance">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtYrTaxableConveyance" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("YrTaxableConveyance") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt76" runat="server" Enabled="True" TargetControlID="txtYrTaxableConveyance"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>


                                     <asp:TemplateField HeaderText="WaterRate">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtWaterRate" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("WaterRate") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt75" runat="server" Enabled="True" TargetControlID="txtWaterRate"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>


                                     <asp:TemplateField HeaderText="PerkAccomdation">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPerkAccomdation" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("PerkAccomdation") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt74" runat="server" Enabled="True" TargetControlID="txtPerkAccomdation"
                                        ValidChars="0123456789.-">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>

                                <asp:TemplateField HeaderText="PerkFurniture">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPerkFurniture" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("PerkFurniture") %>'>></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="flt73" runat="server" Enabled="True" TargetControlID="txtPerkFurniture"
                                        ValidChars="0123456789.-">
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
