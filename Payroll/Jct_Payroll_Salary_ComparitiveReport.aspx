<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_Payroll_Salary_ComparitiveReport.aspx.cs" Inherits="Payroll_Jct_Payroll_Salary_ComparitiveReport" %>


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
                 Salary Comparitive Report
            </td>
        </tr>

               <tr>
            <td class="NormalText">
               YearMonth
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                <%--       <cc1:CalendarExtender ID="txttodate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txttodate">
                </cc1:CalendarExtender>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttodate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                
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
         
                <asp:DropDownList ID="ddllocation" runat="server" CssClass="combobox">
                </asp:DropDownList>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddllocation"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
   
        <tr>
          
            <td class="NormalText">
                Department</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldepartment" runat="server" AutoPostBack="True" 
                    CssClass="combobox" >
                </asp:DropDownList>
            </td>

              <td class="NormalText">
                            
                <asp:Label ID="lblName" runat="server" CssClass="NormalText" 
                    Text="Search Emplyoee Name" ></asp:Label>

            </td>
            <td class="NormalText">
        <%--        <asp:TextBox ID="txtEmployee" runat="server" AutoPostBack="True" 
                    CssClass="textbox" onkeyup="SetContextKey()" 
                    OnTextChanged="txtEmployee_TextChanged" Width="300px"  ></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" 
                    CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                    CompletionListElementID="divwidth" 
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" 
                    MinimumPrefixLength="3" ServiceMethod="GetEmployee_sh_Common_Employeecodewise" 
                    ServicePath="~/WebService.asmx" TargetControlID="txtEmployee" 
                    UseContextKey="True">
                </cc1:AutoCompleteExtender>--%>
                <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnTextChanged="txtEmployee_TextChanged" Width="300px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                    CompletionListCssClass="autocomplete_ListItem1" Enabled="True" TargetControlID="txtEmployee"
                    ServiceMethod="GetEmployee_sh_Common_Employeecodewise" ServicePath="~/WebService.asmx"
                    MinimumPrefixLength="1">
                </cc1:AutoCompleteExtender>
            </td>

        </tr>
   
        <tr>
          
            <td class="NormalText">
                Parameter</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldepartment0" runat="server" AutoPostBack="True" 
                    CssClass="combobox" >
                    <asp:ListItem Selected="True">Grossdiff</asp:ListItem>
                    <asp:ListItem>Netdiff</asp:ListItem>
                </asp:DropDownList>
            </td>

              <td class="NormalText">
                            
                  &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>

        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" OnClick="lnkexcel_Click"
                    Width="32px"></asp:LinkButton>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4" style="height: 27px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                            OnClick="lnkfetch_Click" ValidationGroup="A">Fetch</asp:LinkButton>
                        <%--<asp:LinkButton ID="lnkfreeeze" runat="server" CssClass="buttonc" 
                        onclick="lnkfreeeze_Click" ValidationGroup="A">Freeze</asp:LinkButton>--%>
                        <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>


                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" Width="100%" EmptyDataText="No Record Found" EnableModelValidation="True">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <%--                     <asp:TemplateField HeaderText="SelectAll">
                                      <HeaderTemplate>
                                          <asp:CheckBox ID="chkall" runat="server" AutoPostBack="True" 
                                              oncheckedchanged="chkall_CheckedChanged" Text="SelectAll" />
                                      </HeaderTemplate>
                                      <ItemTemplate>
                                          <asp:CheckBox ID="chk" runat="server" AutoPostBack="True" />
                                      </ItemTemplate>
                                  </asp:TemplateField>--%>
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




