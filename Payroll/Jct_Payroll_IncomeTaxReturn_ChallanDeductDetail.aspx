<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_IncomeTaxReturn_ChallanDeductDetail.aspx.cs" Inherits="Payroll_Jct_Payroll_IncomeTaxReturn_ChallanDeductDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

        $(document).ready(function () {
            $('#<%= txtRecordNo.ClientID %>').bind("focusout", function (e) {
                var a = $('#<%= txtRecordNo.ClientID %>').val();
                e = parseInt(a);
                var arrlist = [1, 2, 3];
                var flag = "";
              
                for (var i = 0; i < arrlist.length; i++) {

                    var d = arrlist[i];

                    if (parseInt(d) === e) {
                        flag = 'True';
                        break;
                    }
                    else {

                        flag = 'false';
                    }
                }              
                if (flag == 'false') {
                    $('#<%= txtRecordNo.ClientID %>').val('') ;
                    $(".error").css("display", "inline");
                }
                if (flag == 'True') {
                    $(".error").css("display", "none");
                }
            });
        });


    </script>
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Challan Deductee Details:
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="LblReportType" runat="server" Text="Type"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlReporttypes" runat="server" CssClass="combobox" OnSelectedIndexChanged="ddlReporttypes_SelectedIndexChanged"
                    AutoPostBack="True">
                    <asp:ListItem>FileBatch</asp:ListItem>
                    <asp:ListItem Selected="True">ChallanDed</asp:ListItem>
                    <asp:ListItem>Annexture</asp:ListItem>
                    <asp:ListItem>TaxReturn</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                YearMonth
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtMonth" runat="server" Style="text-transform: capitalize;" CssClass="textbox"
                    AutoPostBack="True" MaxLength="6" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMonth"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True"
                    TargetControlID="txtMonth" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" WatermarkCssClass="watermark"
                    WatermarkText="201909" TargetControlID="txtMonth">
                </cc1:TextBoxWatermarkExtender>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlplant"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                RecordNo
            </td>
            <td class="NormalText">
      
                <asp:TextBox ID="txtRecordNo" runat="server" Style="text-transform: capitalize;"
                    CssClass="textbox" MaxLength="1" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRecordNo"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" Enabled="True"
                    TargetControlID="txtRecordNo" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="watermark"
                    WatermarkText="type 1,2,3" TargetControlID="txtRecordNo">
                </cc1:TextBoxWatermarkExtender>
               
            </td>
            <td class="labelcells" colspan ="2">
                
            </td>

        </tr>
        <tr>
            <td colspan="4" align="left" class="labelcells">
                <span class="error" style="color: Red; display: none">* Value Should Be In (1,2,3)</span>
            </td>
        </tr>
        
        
        
        
        
        <tr>
            <td class="labelcells">
                ChallanSrNo
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtChallanSrNo" runat="server" Style="text-transform: capitalize;"
                    CssClass="textbox" MaxLength="5" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtChallanSrNo"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                    TargetControlID="txtChallanSrNo" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
               
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                BranchCode
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtBranchCode" runat="server" Style="text-transform: capitalize;"
                    CssClass="textbox" MaxLength="7" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBranchCode"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" WatermarkCssClass="watermark"
                    WatermarkText="0-9 digit" TargetControlID="txtBranchCode">
                </cc1:TextBoxWatermarkExtender>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                ChallanDate
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtChallanDate" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtefffrm_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtChallanDate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtChallanDate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                LateFee
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtLateFee" runat="server" Style="text-transform: capitalize;" CssClass="textbox"
                    MaxLength="17" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLateFee"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" Enabled="True"
                    TargetControlID="txtLateFee" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
               
            </td>
            <td class="labelcells">
                &nbsp;
                <asp:LinkButton ID="lnkexcel0" runat="server" CssClass="buttonXL" Height="32px" OnClick="lnkexcel_Click"
                    Width="32px"></asp:LinkButton>
            </td>
            <td class="NormalText">
            </td>
        </tr>
     <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkfetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" Visible="False"
                    Width="1000px">
                    <asp:GridView ID="grdDetail" runat="server" Width="100%" EmptyDataText="No Record Found">
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
