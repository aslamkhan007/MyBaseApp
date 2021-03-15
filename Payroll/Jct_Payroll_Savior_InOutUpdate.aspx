<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_Savior_InOutUpdate.aspx.cs" Inherits="Payroll_Jct_Payroll_Savior_InOutUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="2">
                Punch Updation:
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Date
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtefffrm" runat="server" CssClass="textbox" AutoPostBack="True"></asp:TextBox>
                <cc1:CalendarExtender ID="txtefffrm_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtefffrm">
                </cc1:CalendarExtender>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
              CardNo
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEmployeeCode" runat="server" CssClass="textbox" AutoPostBack="True"
                            OnTextChanged="txtEmployeeCode_TextChanged" Width="250px"></asp:TextBox>
                       <%-- <cc1:AutoCompleteExtender ID="txtEmployeeCode_AutoCompleteExtender" runat="server"
                            DelimiterCharacters="" CompletionListCssClass="autocomplete_ListItem1" Enabled="True"
                            TargetControlID="txtEmployeeCode" ServiceMethod="GetEmployee_sh_Common" ServicePath="~/WebService.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1">
                        </cc1:AutoCompleteExtender>--%>
                        <asp:RequiredFieldValidator ID="ReqEmployeecode" runat="server" ControlToValidate="txtEmployeeCode"
                            Display="Dynamic" ErrorMessage="**EmployeeName Required!!" ForeColor="#CC0000"
                            ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <%-- <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" EmptyDataText="No Record Found" EnableModelValidation="True"
                                Width="100%" OnSelectedIndexChanged="grdDetail_SelectedIndexChanged">
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
        </tr>--%><%-- <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" EmptyDataText="No Record Found" EnableModelValidation="True"
                                Width="100%" OnSelectedIndexChanged="grdDetail_SelectedIndexChanged">
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
        </tr>--%><%-- <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" EmptyDataText="No Record Found" EnableModelValidation="True"
                                Width="100%" OnSelectedIndexChanged="grdDetail_SelectedIndexChanged">
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
        </tr>--%><%-- <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" EmptyDataText="No Record Found" EnableModelValidation="True"
                                Width="100%" OnSelectedIndexChanged="grdDetail_SelectedIndexChanged">
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
        </tr>--%>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
      
       
        <tr>
            <td class="buttonbackbar" style="height: 16px" colspan="2">
                Pls Note: Time Format Shoud be like&nbsp; 10:51 and Hours Worked in Minutes like 
                7 * 60 = 420 minutes</td>
        </tr>

          <tr>
            <td class="labelcells">
                <asp:Label ID="Label4" runat="server" Text="Status"></asp:Label>
              </td>
            <td class="labelcells">
       <%--       <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                <asp:Label ID="Label5" runat="server" ></asp:Label>
                </ContentTemplate>
                </asp:UpdatePanel>--%>


                 <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="Label5" runat="server" CssClass="textbox" Width="60px" 
                            MaxLength="5"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Label5"
                            Display="Dynamic" ErrorMessage="**Required!!" ForeColor="#CC0000" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>


                       </td>
        </tr>

          <tr>
            <td class="labelcells">
                <asp:Label ID="Label2" runat="server" Text="Shift"></asp:Label>
            </td>
            <td class="labelcells">
              
                       <%-- <asp:Label ID="sshit" runat="server"></asp:Label>--%>
                         <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="sshit" runat="server" CssClass="textbox" Width="60px" 
                            MaxLength="5"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="sshit"
                            Display="Dynamic" ErrorMessage="**Required!!" ForeColor="#CC0000" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
                    
            </td>
        </tr>

        <tr>
            <td class="labelcells">
                <asp:Label ID="Label3" runat="server" Text="Shift Attended"></asp:Label>
            </td>
            <td class="labelcells">
                
                        <%--<asp:Label ID="lblshift" runat="server"></asp:Label>--%>
<asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="lblshift" runat="server" CssClass="textbox" Width="60px" 
                            MaxLength="5"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="lblshift"
                            Display="Dynamic" ErrorMessage="**Required!!" ForeColor="#CC0000" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
                   
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 16px">
                IN
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtIn1" runat="server" CssClass="textbox" Width="60px" 
                            MaxLength="5"></asp:TextBox>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Lunch Out    
                </td>
                <td class="NormalText">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtOut1" runat="server" CssClass="textbox" Width="60px"   MaxLength="5" ></asp:TextBox>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Lunch In</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePaneltxtSanctionAmount" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtIn2" runat="server" CssClass="textbox" Width="60px"  MaxLength="5"></asp:TextBox>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                OUT</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtOut2" runat="server" CssClass="textbox" Width="60px"  MaxLength="5" AutoPostBack="True"></asp:TextBox>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Hours Worked
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtHours" runat="server" CssClass="textbox" Width="60px"   MaxLength="3" AutoPostBack="True"
                          ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqInsAmount" runat="server" ControlToValidate="txtHours"
                            Display="Dynamic" ErrorMessage="**Required!!" ForeColor="#CC0000" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                            ValidationGroup="A">Update</asp:LinkButton>
                        <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                        <asp:LinkButton ID="lnkreset0" runat="server" CssClass="buttonc" onclick="lnkreset0_Click" 
                            >PunchTransfer</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <%-- <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" EmptyDataText="No Record Found" EnableModelValidation="True"
                                Width="100%" OnSelectedIndexChanged="grdDetail_SelectedIndexChanged">
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
        </tr>--%>
    </table>
</asp:Content>
