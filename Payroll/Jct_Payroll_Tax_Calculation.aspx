<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_Payroll_Tax_Calculation.aspx.cs" Inherits="Payroll_Jct_Payroll_Tax_Calculation" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <%--  <script type="text/javascript">
        function SetContextKey() {
            $find('<%=txtEmployee_AutoCompleteExtender.ClientID%>').set_contextKey($get("<%=ddlLocation.ClientID %>").value);
        }
    </script>--%>

    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
              
                Tax Calculation</td>
        </tr>

         <tr>
            <td class="labelcells">
                Calculation Type
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlReporttype" runat="server" CssClass="combobox" 
                      AutoPostBack="True"
                    >
                    <asp:ListItem>Calculation</asp:ListItem>
                    <asp:ListItem>Freeze</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
              FIYear
            </td>
            <td class="NormalText">
             <asp:TextBox ID="txttodates" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1asdas" runat="server" ControlToValidate="txttodates"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>

         <tr>
            <td class="labelcells">
                Plant
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                <%--Location--%>
            </td>
            <td class="NormalText">
                <%--<asp:DropDownList ID="ddlLocation" runat="server" CssClass="combobox">
                </asp:DropDownList>--%>
            </td>
        </tr>


    <%--    <tr>
            <td class="labelcells">
                Plant</td>
            <td class="NormalText">
          <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" 
                    AutoPostBack="True" onselectedindexchanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ddlplant" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                Location
            </td>
            <td class="NormalText">
         <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="True" 
                    CssClass="combobox" 
                    onselectedindexchanged="ddlLocation_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="ddlLocation" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                      </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>--%>
        <tr>
            <td class="labelcells">
                YearMonth</td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="80px" 
                    MaxLength="6"></asp:TextBox>
                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
                    runat="server" Enabled="True" TargetControlID="txttodate" 
                    ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txttodate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
                   <td class="labelcells">
                       Search
                Employee
            </td>
            <td class="NormalText">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
<%--                <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" 
                    Width="100px" MaxLength="9"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                    CompletionListCssClass="autocomplete_ListItem1" Enabled="True" TargetControlID="txtEmployee"
                    ServiceMethod="GetEmployeeCode" ServicePath="~/WebService.asmx" MinimumPrefixLength="1">
                </cc1:AutoCompleteExtender>
--%>



  <%--<asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" AutoPostBack="True" onkeyup = "SetContextKey()"
                    OnTextChanged="txtEmployee_TextChanged" Width="300px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" CompletionInterval="10"
                    CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                    ServiceMethod="LocationWIse_Employee" ServicePath="~/WebService.asmx" TargetControlID="txtEmployee"
                    UseContextKey="True">
                </cc1:AutoCompleteExtender>

--%>

   <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnTextChanged="txtEmployee_TextChanged" Width="300px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" CompletionInterval="10"
                    CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                    ServiceMethod="GetEmployee_sh_Common" ServicePath="~/WebService.asmx" TargetControlID="txtEmployee">
                </cc1:AutoCompleteExtender>
              <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmployee"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>



                  </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
          <td class="labelcells">
               Installment</td>
              <td class="NormalText">
            
                <asp:TextBox ID="TxtInstallment" runat="server" CssClass="textbox" Width="30px" 
                      MaxLength="2" 
                      ToolTip="Enter Installment no. as per below instructions:Mar-1;Feb-2;Jan-3;Dec-4;Nov-5;Oct-6;Sept-7;Aug-8;Jul-9;Jun-10;May-11;Apr-12"></asp:TextBox>

            <cc1:FilteredTextBoxExtender ID="TxtInstallment_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="TxtInstallment" 
                    ValidChars="0123456789"></cc1:FilteredTextBoxExtender>

             <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1"
        runat="server" WatermarkCssClass="watermark" WatermarkText="12-1" targetcontrolid="TxtInstallment">
                            </cc1:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TxtInstallment" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>  
            <td class="labelcells"></td>
            <td class="NormalText">
                <asp:LinkButton ID="lnkexcel0" runat="server" CssClass="buttonXL" Height="32px" 
                    OnClick="lnkexcel_Click" Width="32px"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4" style="height: 27px">
            <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
            <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                        onclick="lnkfetch_Click" ValidationGroup="A">Fetch</asp:LinkButton>
                    <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                        onclick="lnkreset_Click">Reset</asp:LinkButton>
                    <asp:LinkButton ID="lnkFreeze0" runat="server" CssClass="buttonc" 
                        onclick="lnkFreeze_Click" Visible="False" >Freeze</asp:LinkButton>
              <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>

          
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

                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Both" 
                    Visible="False" Width="1000px">
                    <asp:GridView ID="grdDetail" runat="server" Width="100%">
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
    </table>
</asp:Content>


