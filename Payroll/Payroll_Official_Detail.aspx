<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Payroll_Official_Detail.aspx.cs" Inherits="Payroll_Payroll_Official_Detail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="6">
                Employees Details:
            </td>
        </tr>
        <tr>
            <td colspan="6" align="center">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="ImageOfficial" runat="server" ImageUrl="~/Image/Official_Info_Red.png"
                            OnClick="ImageOfficial_Click" ValidationGroup="A" />
                        <asp:ImageButton ID="ImagePersonal" runat="server" ImageUrl="~/Image/Personal_Info.png"
                            OnClick="ImagePersonal_Click" ValidationGroup="A" />
                        <asp:ImageButton ID="ImageEarnings" runat="server" ImageUrl="~/Image/Earnings_Info.png"
                            OnClick="ImageEarnings_Click" ValidationGroup="A" />
                        <asp:ImageButton ID="ImageDeductions" runat="server" ImageUrl="~/Image/Deductions_Info.png"
                            OnClick="ImageDeductions_Click" ValidationGroup="A" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="6" style="text-decoration: underline">
                Personal Details:
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
                <asp:ImageButton ID="imgbtnportmaster" runat="server" ImageUrl="~/Image/document_add.PNG"
                    OnClick="imgbtnportmaster_Click" ToolTip="Change Location Or Plant" Height="19px"
                    Width="23px" />
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Active
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlstatus" runat="server" CssClass="combobox" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged">
                            <asp:ListItem>Y</asp:ListItem>
                            <asp:ListItem>N</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Plant
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updateplant" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Location
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updatelocation" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="combobox" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Employee Code
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updateemployecode" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEmployeecode" runat="server" CssClass="textbox" Width="78px"
                            ToolTip="Salary code can contain only Uppercase  Letters &amp; hyphen or minus sign(-). To Search any record give SalaryCode and then press Enter Key"
                            AutoCompleteType="Disabled" MaxLength="7"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmployeecode"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtNewEmployeeCode" runat="server" CssClass="textbox" Width="98px"
                            ToolTip="Enter new employee code" AutoCompleteType="Disabled" MaxLength="10"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="watermark"
                            WatermarkText="New Employee Code" TargetControlID="txtNewEmployeeCode">
                        </cc1:TextBoxWatermarkExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Savior Card No
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updatesaviorcardno" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSaviorcardno" runat="server" CssClass="textbox" MaxLength="10"
                            ToolTip="Card No. can contain only 10  characters." AutoCompleteType="Disabled"
                            Width="38px"></asp:TextBox>
                        <%--<cc1:FilteredTextBoxExtender ID="Flt1" runat="server" Enabled="True" FilterType="Numbers"
                            TargetControlID="txtSaviorcardno">
                        </cc1:FilteredTextBoxExtender>--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSaviorcardno"
                            Display="Dynamic" ErrorMessage="**CardNo Required!!" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Marital Status
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdateMartialStatus" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlMaritalStatus" runat="server" CssClass="combobox" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlMaritalStatus_SelectedIndexChanged">
                            <asp:ListItem>Married</asp:ListItem>
                            <asp:ListItem Selected="True">Single</asp:ListItem>
                            <asp:ListItem>Divorcee</asp:ListItem>
                            <asp:ListItem>Widow</asp:ListItem>
                            <asp:ListItem>Widower</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Blood Group
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlbloodgroup" runat="server" CssClass="combobox" Visible="True"
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Gender
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updategender" runat="server">
                    <ContentTemplate>
                        <asp:RadioButtonList ID="rdbgender" runat="server" RepeatDirection="Horizontal" ToolTip="Select M for Male gender and F for female gender"
                            AutoPostBack="True">
                            <asp:ListItem Selected="True">M</asp:ListItem>
                            <asp:ListItem>F</asp:ListItem>
                        </asp:RadioButtonList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Salutation
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdateSalutaion" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalutaion" runat="server" CssClass="combobox" AutoPostBack="True">
                            <asp:ListItem>Mr</asp:ListItem>
                            <asp:ListItem>Mrs</asp:ListItem>
                            <asp:ListItem>Ms</asp:ListItem>
                            <asp:ListItem>Dr</asp:ListItem>
                            <asp:ListItem>Capt</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                First Name
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updatefirstname" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtfirstname" runat="server" CssClass="textbox" Width="90px" 
                            MaxLength="20" AutoPostBack="True" ontextchanged="txtfirstname_TextChanged"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Middle Name
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updatmiddlename" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtMiddleName" runat="server" CssClass="textbox" Width="90px" MaxLength="20"
                            OnTextChanged="txtMiddleName_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Last Name
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updatelastname" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="textbox" Width="90px" MaxLength="20"
                            OnTextChanged="txtLastName_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
            <td class="NormalText">
                <asp:UpdatePanel ID="Updatefathername" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtfathername" runat="server" CssClass="textbox" MaxLength="100"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Shift
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlshift" runat="server" CssClass="combobox" AutoPostBack="True">
                            <asp:ListItem>Fixed</asp:ListItem>
                            <asp:ListItem>Rotation</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Salary Type
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalaryType" runat="server" CssClass="combobox" AutoPostBack="True">
                            <asp:ListItem>Bank</asp:ListItem>
                            <asp:ListItem>Cash</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Designation
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updatedesignation" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddldesignation" runat="server" CssClass="combobox" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Job Type
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updatejobtype" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddljobtype" runat="server" CssClass="combobox" AutoPostBack="True">
                            <asp:ListItem>Contract</asp:ListItem>
                            <asp:ListItem>Extension</asp:ListItem>
                            <asp:ListItem>Probabtion</asp:ListItem>
                            <asp:ListItem>Regular</asp:ListItem>
                            <asp:ListItem>Training</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Citizenship
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCitizenship" runat="server" CssClass="combobox" AutoPostBack="True">
                            <asp:ListItem>Indian</asp:ListItem>
                            <asp:ListItem>Others</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Area
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdateArea" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="combobox" AutoPostBack="True">
                            <asp:ListItem>Non Production</asp:ListItem>
                            <asp:ListItem>Production</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Religion
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updatedreligion" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlreligion" runat="server" CssClass="combobox" AutoPostBack="True">
                            <asp:ListItem>Hindu</asp:ListItem>
                            <asp:ListItem>Muslim</asp:ListItem>
                            <asp:ListItem>Sikh</asp:ListItem>
                            <asp:ListItem>Christian</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Date of Birth
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updatedateofbirth" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtdateofbirth" runat="server" CssClass="textbox" Width="78px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtdateofbirth_CalendarExtender" runat="server" TargetControlID="txtdateofbirth"
                            Animated="False" PopupPosition="TopRight">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MEE1" runat="server" MaskType="Date" Mask="99/99/9999"
                            TargetControlID="txtdateofbirth">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditValidator ID="MEV1" runat="server" ControlExtender="MEE1" ControlToValidate="txtdateofbirth"
                            Display="Dynamic" EmptyValueMessage="ENTER DATE!!" ErrorMessage="MEV1" InvalidValueMessage="INVALID DATE"
                            TooltipMessage="MM/DD/YYYY" IsValidEmpty="False" ValidationGroup="A"></cc1:MaskedEditValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Date of Joining
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updatejoiningdate" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtjoiningdate" runat="server" CssClass="textbox" Width="78px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtjoiningdate_CalendarExtender" runat="server" TargetControlID="txtjoiningdate"
                            Animated="False" PopupPosition="TopRight">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MEE2" runat="server" MaskType="Date" Mask="99/99/9999"
                            TargetControlID="txtjoiningdate">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditValidator ID="MEV2" runat="server" ControlExtender="MEE2" ControlToValidate="txtjoiningdate"
                            Display="Dynamic" ErrorMessage="MEV2" InvalidValueMessage="INVALID DATE" TooltipMessage="MM/DD/YYYY"
                            IsValidEmpty="False" EmptyValueMessage="ENTER DATE!!" ValidationGroup="A"></cc1:MaskedEditValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Date of Confirmation
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updateconfirmationdate" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtconfirmationdate" runat="server" CssClass="textbox" Width="78px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtconfirmationdate_CalendarExtender" runat="server" TargetControlID="txtconfirmationdate"
                            Animated="False" PopupPosition="TopRight">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MEE3" runat="server" MaskType="Date" Mask="99/99/9999"
                            TargetControlID="txtconfirmationdate">
                        </cc1:MaskedEditExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Date of Anniversary
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtAnniversaryDate" runat="server" CssClass="textbox" Width="78px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtAnniversaryDate"
                            Animated="False" PopupPosition="TopRight">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" MaskType="Date" Mask="99/99/9999"
                            TargetControlID="TxtAnniversaryDate">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MEE4"
                            ControlToValidate="TxtAnniversaryDate" Display="Dynamic" ErrorMessage="MEV4"
                            InvalidValueMessage="INVALID DATE" TooltipMessage="MM/DD/YYYY" ValidationGroup="A"></cc1:MaskedEditValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Date of Leaving
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updateleavingdate" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtleavingdate" runat="server" CssClass="textbox" Width="78px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtleavingdate_CalendarExtender" runat="server" TargetControlID="txtleavingdate"
                            Animated="False" PopupPosition="TopRight">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MEE4" runat="server" MaskType="Date" Mask="99/99/9999"
                            TargetControlID="txtleavingdate">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditValidator ID="MEV4" runat="server" ControlExtender="MEE4" ControlToValidate="txtleavingdate"
                            Display="Dynamic" ErrorMessage="MEV4" InvalidValueMessage="INVALID DATE" TooltipMessage="MM/DD/YYYY"
                            ValidationGroup="A"></cc1:MaskedEditValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Reason For Leaving
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updateleavingreason" runat="server">
                    <ContentTemplate>

                    <asp:DropDownList ID="ddlleavingreason" runat="server" CssClass="combobox" Visible="True"
                            AutoPostBack="True">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Absent</asp:ListItem>
                        <asp:ListItem>Died</asp:ListItem>
                        <asp:ListItem>Resigned</asp:ListItem>
                        <asp:ListItem>Retired</asp:ListItem>
                        <asp:ListItem>Others</asp:ListItem>
                        </asp:DropDownList>

                        <%--<asp:TextBox ID="txtleavingreason" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="labelcells_s" colspan="3">
                &nbsp;
            </td>
            <td class="labelcells_s" colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="6" style="text-decoration: underline">
                Official Details:
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Department
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updatedepartment" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddldepartment" runat="server" CssClass="combobox" AutoPostBack="True"
                            OnSelectedIndexChanged="ddldepartment_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Sub Department
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updatesubdepartment" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlsubdepartment" runat="server" CssClass="combobox" Height="16px"
                            Width="135px" OnSelectedIndexChanged="ddlsubdepartment_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Cost Center
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtCostCenter" runat="server" CssClass="textbox" MaxLength="8"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderqwe1" runat="server" FilterType="Numbers" TargetControlID="txtCostCenter">
                        </cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3qwe" runat="server" ControlToValidate="txtCostCenter"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Overtime Applicable
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlpaidovertime" runat="server" CssClass="combobox" AutoPostBack="true">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Compensatory Applicable
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlcompensatory" runat="server" CssClass="combobox" AutoPostBack="true">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Bonus Applicable
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlbonus" runat="server" CssClass="combobox" 
                            AutoPostBack="true" onselectedindexchanged="ddlbonus_SelectedIndexChanged">                            
                            <asp:ListItem>No</asp:ListItem>
                            <asp:ListItem>Yes</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Bank Loan Acct Number</td>
            <td class="NormalText">
            <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtBankLoanAccNo" runat="server" CssClass="textbox" 
                            Width="100px" MaxLength="15"></asp:TextBox>                        
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td class="labelcells">
                Extension No
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtextension" runat="server" CssClass="textbox" MaxLength="4" 
                            Width="78px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">

            <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblBonusCategory" runat="server" Text="Bonus Category" Visible="False"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            
                </td>
            <td class="NormalText">
               
                <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlbonusCategory" runat="server" AutoPostBack="true" 
                            CssClass="combobox" Visible="False">
                            <asp:ListItem>Unskilled</asp:ListItem>
                            <asp:ListItem>SemiSkilled</asp:ListItem>
                            <asp:ListItem>Skilled</asp:ListItem>
                            <asp:ListItem>HighlySkilled</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
               
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                House Type
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updatehousetype" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlhousetype" runat="server" CssClass="combobox" AppendDataBoundItems="True"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlhousetype_SelectedIndexChanged"
                            Height="17px" Width="100px">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                <asp:UpdatePanel ID="UpdatelblShared" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblShared" runat="server" Text="Shared" Visible="False"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatehouseShared" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlhouseShared" runat="server" CssClass="combobox" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlhouseShared_SelectedIndexChanged">
                            <asp:ListItem>No</asp:ListItem>
                            <asp:ListItem>Yes</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                <asp:UpdatePanel ID="Updatelblhouseno" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblhouseno" runat="server" Text="House No" Visible="False"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdateHouseNo" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtHouseNo" runat="server" CssClass="textbox" Width="78px" OnTextChanged="txtHouseNo_TextChanged"
                            AutoPostBack="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtHouseNo"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                MobileNumber</td>
            <td class="NormalText">
                        <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="Textmob" runat="server" CssClass="textbox" 
                            Width="100px" MaxLength="10"></asp:TextBox>                        
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td class="labelcells">
            <asp:Label ID="Label53" runat="server" Text="Emai Id"></asp:Label>
                </td>
            <td class="NormalText">

            <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtEmailID" runat="server" CssClass="textbox" Width="150px" MaxLength="30"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ControlToValidate="TxtEmailID" ErrorMessage="Invalid URL" ValidationGroup="A"></asp:RegularExpressionValidator>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" WatermarkCssClass="watermark"
                            WatermarkText="local-part@domain" TargetControlID="TxtEmailID">
                        </cc1:TextBoxWatermarkExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>

                </td>
            <td class="labelcells">
                HRDept</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="Updatedepartment0" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlHr" runat="server"
                            CssClass="combobox" >
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells_s" colspan="3" style="height: 17px">
            </td>
            <td class="labelcells_s" colspan="3" style="height: 17px">
            </td>
        </tr>
        <tr>
            <td colspan="6" style="text-decoration: underline" class="labelcells">
                Membership Details:
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Member Pf
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlpf" runat="server" CssClass="combobox" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlpf_SelectedIndexChanged">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                PF No
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePfNo" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtPfNo" runat="server" CssClass="textbox" Width="78px" MaxLength="10"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="Flt2" runat="server" FilterType="Numbers" TargetControlID="txtPfNo">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                FPF No
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtfpfno" runat="server" CssClass="textbox" Width="78px" MaxLength="10"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Member ESI
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlESI" runat="server" CssClass="combobox" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlESI_SelectedIndexChanged">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                ESI No
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdateESINo" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEsiNo" runat="server" AutoPostBack="True" CssClass="textbox"
                            Width="78px" MaxLength="15"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Member Club
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlclub" runat="server" CssClass="combobox" AutoPostBack="True">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Senior Citizen
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSeniorCitizen" runat="server" CssClass="combobox" AutoPostBack="True">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Society No
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSocietyNo" runat="server" AutoPostBack="True" CssClass="textbox"
                            Width="78px" MaxLength="10"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                UAN No
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdateUANNo" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtUANNo" runat="server" CssClass="textbox" Width="78px" MaxLength="15"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
               
                MemberSuperAnuation</td>
            <td class="NormalText">
                
                <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlmemberSuperannuationcat" runat="server"  
                            CssClass="combobox">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            </td>
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
                Pan Card No
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtpancardno" runat="server" CssClass="textbox" Width="78px" MaxLength="10"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Aadhaar No
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtAddharNo" runat="server" CssClass="textbox" Width="78px" MaxLength="12"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Employee File No
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtEmpFileNo" runat="server" CssClass="textbox" Width="78px" MaxLength="20"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Gratuity No</td>
            <td class="NormalText">
                
                <asp:UpdatePanel ID="UpdateGratuityyno" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtGratuityyno" runat="server" CssClass="textbox" Width="78px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="fltGratuityyno" runat="server" Enabled="True" 
                            FilterType="Numbers" TargetControlID="txtGratuityyno">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="6">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" OnClick="lnkadd_Click"
                            ValidationGroup="A">Save</asp:LinkButton>
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
