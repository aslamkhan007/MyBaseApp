<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_HR_MasterDetailEntry.aspx.cs" Inherits="Payroll_Jct_Payroll_HR_MasterDetailEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


<script type ="text/javascript">

</script>       
          
       
  
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="6">
                Master Detail:
            </td>
        </tr>
        <tr>
            <td colspan="6" align="center">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="ImageOfficial" runat="server" ImageUrl="~/Image/Official_Info_Red.png" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdateImage4" runat="server">
                    <ContentTemplate>
                        <asp:Image ID="Image4" runat="server" AlternateText="Image Not Found" Height="125px"
                            Width="110px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                <br />
                Employee Code
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSearchEmployecode" runat="server" AutoCompleteType="Disabled"
                            CssClass="textbox" MaxLength="7" ToolTip="Salary code can contain only Uppercase  Letters &amp; hyphen or minus sign(-). To Search any record give SalaryCode and then press Enter Key"
                            Width="78px" OnTextChanged="txtSearchEmployecode_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--<asp:UpdatePanel ID="Updatesearch" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="cmdSearch" runat="server" CssClass="searchbluesmall" Height="16px"
                            Width="16px" OnClick="cmdSearch_Click" ValidationGroup="B"></asp:LinkButton>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSearchEmployecode"
                            Display="Dynamic" ErrorMessage="**EmployeeCode Required" ValidationGroup="B"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
            <td class="labelcells">
                &nbsp;
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
                &nbsp;
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
                Employee&#39;s Name
            </td>
            <td class="labelcells">
                <asp:UpdatePanel ID="Updatemplyoename" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbemployeename" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblFather" runat="server" Visible="true">Father/Husband&#39;s Name</asp:Label>
            </td>
            <td class="labelcells">
                <asp:UpdatePanel ID="Updatefathername" runat="server">
                    <ContentTemplate>
                        <%--<asp:TextBox ID="txtfathername" runat="server" CssClass="textbox" MaxLength="100"></asp:TextBox>--%>
                        <asp:Label ID="txtfathername" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
                Savior Card No
            </td>
            <td class="labelcells">
                <asp:UpdatePanel ID="Updatesaviorcardno" runat="server">
                    <ContentTemplate>
                        <%--  <asp:TextBox ID="txtSaviorcardno" runat="server" AutoCompleteType="Disabled" 
                            CssClass="textbox" MaxLength="10" 
                            ToolTip="Card No. can contain only 10  characters." Width="38px"></asp:TextBox>                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtSaviorcardno" Display="Dynamic" 
                            ErrorMessage="**CardNo Required!!" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                        <asp:Label ID="txtSaviorcardno" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Department
            </td>
            <td class="labelcells">
                <asp:UpdatePanel ID="UpdatePanel3s" runat="server">
                    <ContentTemplate>
                        <%--<asp:DropDownList ID="ddldepartment" runat="server" CssClass="combobox" AutoPostBack="True"
                            OnSelectedIndexChanged="ddldepartment_SelectedIndexChanged">
                        </asp:DropDownList>--%>
                        <asp:Label ID="ddldepartment" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Designation
            </td>
            <td class="labelcells">
                <asp:UpdatePanel ID="Updatedesignation" runat="server">
                    <ContentTemplate>
                        <%--<asp:DropDownList ID="ddldesignation" runat="server" CssClass="combobox" >
                        </asp:DropDownList>--%>
                        <asp:Label ID="ddldesignation" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells_s" colspan="3" style="height: 17px">
            </td>
            <td class="labelcells_s" colspan="3" style="height: 17px">
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
                &nbsp;
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
                HRDept
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updatedepartment0" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlHr" runat="server" CssClass="combobox">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                MemberSuperAnuation
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlmemberSuperannuationcat" runat="server" CssClass="combobox">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Employee File No
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtEmpFileNo" runat="server" CssClass="textbox" MaxLength="20" Width="78px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Superannuation No(Current)
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtAnnuationCurrent" runat="server" CssClass="textbox" Width="78px"
                            MaxLength="15"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Superannuation No(Previous)
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtAnnuationPrevious" runat="server" CssClass="textbox" Width="78px"
                            MaxLength="15"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                MobileNumber
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="Textmob" runat="server" CssClass="textbox" MaxLength="10" Width="100px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    
        <%-- <tr>
            <td class="labelcells">
                Super Member Id
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdateSuperMemberid" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSuperMemberid" runat="server" CssClass="textbox" Width="78px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="Fltsupermemberid" runat="server" Enabled="True"
                            FilterType="Numbers" TargetControlID="txtSuperMemberid">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Super Policy No
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdateSuperPolicyNo" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSuperPolicyNo" runat="server" CssClass="textbox" Width="78px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="Flt3" runat="server" FilterType="Numbers" TargetControlID="txtSuperPolicyNo">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>--%>
        
       
        <tr>
            <td class="labelcells">
                Type
            </td>
            <td class="labelcells">
             <%--   <input type="radio" name="radioName" checked value="Regular" />
                Regular
                <input type="radio" name="radioName" value="Contract" />
                Contract--%>

                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal" AutoPostBack="True" 
                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem Selected ="True">Regular</asp:ListItem>
                    <asp:ListItem>Contract</asp:ListItem>                    
                </asp:RadioButtonList>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>

        <tr>
            <td class="labelcells">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                <asp:Label ID="lblNoticePeriod" runat="server">Notice Period</asp:Label>
                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel4sds" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlnotice" runat="server" CssClass="combobox">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>0 Days</asp:ListItem>
                            <asp:ListItem>1 Month</asp:ListItem>
                            <asp:ListItem>3 Month</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
             <asp:UpdatePanel ID="UpdatePanelasds4" runat="server">
                    <ContentTemplate>
                <asp:Label ID="lblProbationPeriod" runat="server">Probation Period</asp:Label>
                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel5asd" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlProbatioPd" runat="server" CssClass="combobox">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>0 Days</asp:ListItem>
                            <asp:ListItem>1 Month</asp:ListItem>
                            <asp:ListItem>3 Month</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                <asp:UpdatePanel ID="UpdatasdasePanel4" runat="server">
                    <ContentTemplate>
                <asp:Label ID="lblConfirmationdate" runat="server">Confirmation Date</asp:Label>
                  </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updateconfirmationdate" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtconfirmationdate" runat="server" CssClass="textbox" Width="78px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtconfirmationdate_CalendarExtender" runat="server" TargetControlID="txtconfirmationdate"
                            Animated="False" PopupPosition="TopRight">
                        </cc1:CalendarExtender>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatoasdasdr1" runat="server" ControlToValidate="txtconfirmationdate"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>


            <tr>
            <td class="labelcells">
                <asp:Label ID="lblContractorCompletionDt" runat="server">Contractor Completion Date:</asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updatejoiningdate" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtConfirmationcompletetionDate" runat="server" CssClass="textbox"
                            Width="78px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtjoiningdate_CalendarExtender" runat="server" TargetControlID="txtConfirmationcompletetionDate"
                            Animated="False" PopupPosition="TopRight">
                        </cc1:CalendarExtender>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorasd1" runat="server" ControlToValidate="txtConfirmationcompletetionDate"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
            <td class="labelcells">
                <%--Contractor Completion Value--%>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updatedateofbirth" runat="server">
                    <ContentTemplate>
                        <%--<asp:TextBox ID="txtConfirmationValues" runat="server" CssClass="textbox" MaxLength="8"
                            ToolTip="0-9 Values only"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderqwe1" runat="server" FilterType="Numbers"
                            TargetControlID="txtConfirmationValues">
                        </cc1:FilteredTextBoxExtender>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>

        <tr>
            <td class="buttonbackbar" colspan="6">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" OnClick="lnkadd_Click"
                            ValidationGroup="A">Update</asp:LinkButton>
                        <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                            OnClick="lnkreset_Click">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
            <td class="labelcells">
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
