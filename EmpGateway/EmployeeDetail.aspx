<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="EmployeeDetail.aspx.vb" Inherits="EmployeeDetail" title="Employee Detail" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td  colspan="4" align="center" class="tableheader">
                <asp:Label ID="Label5" runat="server" BorderColor="Transparent" Font-Bold="True"
                    Font-Names="Trebuchet MS" Font-Size="10pt" Text="Employee Details"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 15%;
                height: 17px" class="labelcells">
                &nbsp;</td>
            <td colspan="3" style="height: 17px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 15%;
                height: 17px" class="labelcells_s">
                <asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Company Code" Width="112px"></asp:Label></td>
            <td colspan="3" style="height: 17px;">
                <asp:DropDownList ID="ddlccode" runat="server" Font-Size="9pt" Height="20px" Width="84px">
                    <asp:ListItem>JCT00LTD</asp:ListItem>
                    <asp:ListItem>JCT01LTD</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="labelcells_s">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Card Number" Width="112px"></asp:Label></td>
            <td colspan="2">
                <asp:TextBox ID="txtcard" runat="server" Width="78px" MaxLength="4"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RF1" runat="server" ControlToValidate="txtcard" ErrorMessage="*">*</asp:RequiredFieldValidator>&nbsp;
                <asp:LinkButton ID="btnfetch" runat="server" CssClass="buttonc" Text="Fetch" 
                    CausesValidation="False" /></td>
            <td align="right" colspan="1">
                <asp:LinkButton ID="lnkaddimg" runat="server" CausesValidation="False" Font-Bold="True"
                    Font-Names="Verdana" Font-Size="8pt" ForeColor="Red"
                    Width="226px">Click Here to Add/Replace Image</asp:LinkButton></td>
        </tr>
        <tr>
            <td 
                class="labelcells_s">
                <asp:Label ID="lblact" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Active" Width="112px"></asp:Label></td>
            <td  colspan="1" class="textcells"><asp:RadioButtonList ID="RLact" runat="server" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" Height="20px" RepeatDirection="Horizontal" Width="90px" 
                    style="letter-spacing: 10px" RepeatLayout="Flow" AutoPostBack="True">
                <asp:ListItem Selected="True">Y</asp:ListItem>
                <asp:ListItem>N</asp:ListItem>
            </asp:RadioButtonList></td>
            <td  colspan="1" class="labelcells_s">
                <asp:Label ID="lblleave" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Date Of Leaving" Width="112px"></asp:Label></td>
            <td  colspan="1" class="textcells">
                <ew:CalendarPopup ID="dateDOL" runat="server" BackColor="WhiteSmoke" Culture="English (United Kingdom)"
                    Font-Names="Tahoma" Font-Size="8pt" Text="..." UpperBoundDate="12/31/9990 23:59:00"
                    VisibleDate="" Width="75px">
                    <ClearDateStyle BackColor="#E0E0E0" />
                    <DayHeaderStyle BackColor="OrangeRed" />
                    <MonthYearSelectedItemStyle BackColor="Silver" />
                    <TodayDayStyle BackColor="#FFC0C0" />
                    <MonthHeaderStyle BackColor="Gray" />
                    <GoToTodayStyle BackColor="#E0E0E0" />
                </ew:CalendarPopup>
            </td>
        </tr>
        <tr>
            <td class="labelcells_s">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Employee Code" Width="112px"></asp:Label></td>
            <td colspan="3" class="textcells">
                <asp:TextBox ID="txtempcode" runat="server" Width="81px" MaxLength="14"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RF2" runat="server" ControlToValidate="txtempcode" ErrorMessage="*">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="labelcells_s">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Salutation" Width="112px"></asp:Label></td>
            <td colspan="1" valign="top" class="textcells"><asp:RadioButtonList ID="RLSal" runat="server" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" Height="1px" RepeatDirection="Horizontal" Width="140px" style="line-height: 5pt; letter-spacing: normal" RepeatLayout="Flow">
                    <asp:ListItem Selected="True" Value="mr">Mr</asp:ListItem>
                    <asp:ListItem Value="mrs">Mrs</asp:ListItem>
                    <asp:ListItem Value="miss">Miss</asp:ListItem>
                </asp:RadioButtonList><span style="font-size: 1pt"></span></td>
            <td colspan="1" class="labelcells_s">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Gender" Width="112px"></asp:Label></td>
            <td colspan="1" valign="top" class="textcells"><asp:RadioButtonList ID="RLgen" runat="server" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" Height="20px" RepeatDirection="Horizontal" Width="82px" style="letter-spacing: 10px" RepeatLayout="Flow">
                    <asp:ListItem Selected="True">M</asp:ListItem>
                    <asp:ListItem>F</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td class="labelcells_s">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Employee Name" Width="112px"></asp:Label></td>
            <td colspan="1">
                <asp:TextBox ID="txtempname" runat="server" Width="221px" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtempname" ErrorMessage="*"
                    Width="1px">*</asp:RequiredFieldValidator></td>
            <td colspan="1" class="labelcells_s">
                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Date Of Birth" Width="112px"></asp:Label></td>
            <td colspan="1" class="textcells">
                <ew:CalendarPopup ID="dateDOB" runat="server" BackColor="WhiteSmoke" Culture="English (United Kingdom)"
                    Font-Names="Tahoma" Font-Size="8pt" Text="..." UpperBoundDate="12/31/9990 23:59:00"
                    Width="77px">
                    <ClearDateStyle BackColor="#E0E0E0" />
                    <DayHeaderStyle BackColor="OrangeRed" />
                    <MonthYearSelectedItemStyle BackColor="Silver" />
                    <TodayDayStyle BackColor="#FFC0C0" />
                    <MonthHeaderStyle BackColor="Gray" />
                    <GoToTodayStyle BackColor="#E0E0E0" />
                </ew:CalendarPopup>
               </td>
        </tr>
        <tr>
            <td class="labelcells_s">
                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Father's Name" Width="112px"></asp:Label></td>
            <td colspan="1">
                <asp:TextBox ID="txtfather" runat="server" Width="221px" MaxLength="150"></asp:TextBox></td>
            <td colspan="1" class="labelcells_s">
                <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Senior Citizen" Width="112px"></asp:Label></td>
            <td colspan="1" class="textcells"><asp:RadioButtonList ID="RLcit" runat="server" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" Height="20px" RepeatDirection="Horizontal" Width="86px" style="letter-spacing: 10px" RepeatLayout="Flow">
                    <asp:ListItem Selected="True">Y</asp:ListItem>
                    <asp:ListItem>N</asp:ListItem>
                </asp:RadioButtonList>&nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells_s">
                <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Department Code" Width="112px"></asp:Label></td>
            <td colspan="3" class="textcells">
                <asp:DropDownList ID="ddldeptcode" runat="server" Font-Size="9pt" Height="20px" Width="97px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="labelcells_s">
                <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Designation Code" Width="112px"></asp:Label></td>
            <td colspan="1" class="textcells">
                <asp:TextBox ID="txtdescode" runat="server" Width="81px" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtdescode" ErrorMessage="*"
                    Width="1px">*</asp:RequiredFieldValidator></td>
            <td colspan="1" class="labelcells_s">
                <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Designation" Width="112px"></asp:Label></td>
            <td colspan="1">
                <asp:TextBox ID="txtdes" runat="server" Width="221px" MaxLength="25"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtdes" ErrorMessage="*"
                    Width="1px">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="labelcells_s">
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Address 1" Width="112px"></asp:Label></td>
            <td colspan="3" class="ls">
                <asp:TextBox ID="txtadd1" runat="server" Width="356px" MaxLength="250"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelcells_s">
                <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Address 2" Width="112px"></asp:Label></td>
            <td colspan="3" class="textcells">
                <asp:TextBox ID="txtadd2" runat="server" Width="356px" MaxLength="250"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelcells_s">
                <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Category" Width="112px"></asp:Label></td>
            <td colspan="3" class="textcells">
                <asp:DropDownList ID="ddlcat" runat="server" Font-Size="9pt" Height="20px" Width="55px">
                    <asp:ListItem>001</asp:ListItem>
                    <asp:ListItem>002</asp:ListItem>
                    <asp:ListItem>JM1</asp:ListItem>
                    <asp:ListItem>JM2</asp:ListItem>
                    <asp:ListItem>MM1</asp:ListItem>
                    <asp:ListItem>MM2</asp:ListItem>
                    <asp:ListItem>MM3</asp:ListItem>
                    <asp:ListItem>SM1</asp:ListItem>
                    <asp:ListItem>SM2</asp:ListItem>
                    <asp:ListItem>SM3</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="labelcells_s">
                <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Member ID" Width="112px"></asp:Label></td>
            <td colspan="1">
                <asp:TextBox ID="txtmembID" runat="server" Width="122px" MaxLength="8">0</asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtmembID"
                    Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ValidationExpression="^\d+$"
                    ValidationGroup="a">Invalid Data</asp:RegularExpressionValidator></td>
            <td colspan="1" class="labelcells_s">
                <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Policy ID" Width="112px"></asp:Label></td>
            <td colspan="1">
                <asp:TextBox ID="txtPolID" runat="server" Width="122px" MaxLength="8">0</asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPolID"
                    Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ValidationExpression="^\d+$"
                    ValidationGroup="a">Invalid Data</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td class="labelcells_s">
                <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Salary Type" Width="112px"></asp:Label></td>
            <td colspan="3"><asp:RadioButtonList ID="RLsalary" runat="server" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" Height="20px" RepeatDirection="Horizontal" Width="181px" RepeatLayout="Flow">
                <asp:ListItem Selected="True" Value="B">Bank</asp:ListItem>
                <asp:ListItem Value="C">Cheque</asp:ListItem>
                <asp:ListItem Value="O">Other</asp:ListItem>
            </asp:RadioButtonList><asp:TextBox ID="txtsal" runat="server" Width="27px" MaxLength="2"></asp:TextBox><asp:CustomValidator
                ID="CVsal" runat="server" ControlToValidate="txtsal" ErrorMessage="*" ValidateEmptyText="True"></asp:CustomValidator></td>
        </tr>
        <tr>
            <td class="labelcells_s">
                <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Bank Code" Width="112px"></asp:Label></td>
            <td colspan="1">
                <asp:TextBox ID="txtbankcode" runat="server" Width="81px" MaxLength="3"></asp:TextBox><asp:CustomValidator
                    ID="CVbankcode" runat="server" ControlToValidate="txtbankcode" ErrorMessage="*"
                    ValidateEmptyText="True"></asp:CustomValidator></td>
            <td colspan="1" class="labelcells_s">
                <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Bank Number" Width="112px"></asp:Label></td>
            <td colspan="1">
                <asp:TextBox ID="txtbankno" runat="server" Width="81px" MaxLength="6"></asp:TextBox><asp:CustomValidator
                    ID="CVbankno" runat="server" ControlToValidate="txtbankno" ErrorMessage="*" ValidateEmptyText="True"></asp:CustomValidator></td>
        </tr>
        <tr>
            <td class="labelcells_s">
                <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="PF Number" Width="112px"></asp:Label></td>
            <td colspan="1">
                <asp:TextBox ID="txtPFno" runat="server" Width="81px" MaxLength="6"></asp:TextBox></td>
            <td colspan="1" class="labelcells_s">
                <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="FPF Number" Width="112px"></asp:Label></td>
            <td colspan="1">
                <asp:TextBox ID="txtFPFno" runat="server" Width="81px" MaxLength="6"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelcells_s">
                <asp:Label ID="Label23" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="ESI Number" Width="112px"></asp:Label></td>
            <td colspan="3">
                <asp:TextBox ID="txtESIno" runat="server" Width="81px" MaxLength="7"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelcells_s">
                <asp:Label ID="Label29" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Date Of Joining" Width="112px"></asp:Label></td>
            <td colspan="3">
                <ew:CalendarPopup ID="dateDOJ" runat="server" BackColor="WhiteSmoke" Culture="English (United Kingdom)"
                    Font-Names="Tahoma" Font-Size="8pt" Text="..." UpperBoundDate="12/31/9990 23:59:00"
                    Width="73px">
                    <ClearDateStyle BackColor="#E0E0E0" />
                    <DayHeaderStyle BackColor="OrangeRed" />
                    <MonthYearSelectedItemStyle BackColor="Silver" />
                    <TodayDayStyle BackColor="#FFC0C0" />
                    <MonthHeaderStyle BackColor="Gray" />
                    <GoToTodayStyle BackColor="#E0E0E0" />
                </ew:CalendarPopup>
                </td>
        </tr>
        <tr>
            <td class="labelcells_s">
                <asp:Label ID="Label24" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="House Type" Width="112px"></asp:Label></td>
            <td colspan="3">
                <asp:TextBox ID="txtHtype" runat="server" Width="80px" MaxLength="30"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelcells_s">
                <asp:Label ID="Label27" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="House Number" Width="112px"></asp:Label></td>
            <td colspan="1">
                <asp:TextBox ID="txtHno" runat="server" Width="105px" MaxLength="40"></asp:TextBox><asp:CustomValidator
                    ID="CVhno" runat="server" ControlToValidate="txtHno" ErrorMessage="*" ValidateEmptyText="True"></asp:CustomValidator></td>
            <td colspan="1" class="labelcells_s">
                <asp:Label ID="Label28" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="House Description" Width="112px"></asp:Label></td>
            <td colspan="1" style="width: 35%;
                height: 16px; background-color: whitesmoke;">
                <asp:TextBox ID="txtHdesc" runat="server" Width="221px" MaxLength="30"></asp:TextBox><asp:CustomValidator
                    ID="CVhdesc" runat="server" ControlToValidate="txtHdesc" ErrorMessage="*" Width="1px" ValidateEmptyText="True"></asp:CustomValidator></td>
        </tr>
        <tr>
            <td class="labelcells_s">
                <asp:Label ID="Label25" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Contact Number" Width="112px"></asp:Label></td>
            <td colspan="3">
                <asp:TextBox ID="txtcontno" runat="server" Width="105px" MaxLength="40"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator4"
                        runat="server" ControlToValidate="txtcontno" ValidationExpression="^\d+$" ValidationGroup="a" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt">Invalid Data</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td align="center" colspan="4" 
                style="height: 16px; background-color: whitesmoke;" class="buttoncbar">
                <asp:LinkButton ID="btnIns" runat="server" CssClass="buttonc" Text="Insert" />
                &nbsp; &nbsp;<asp:LinkButton ID="btnUpd" runat="server" CssClass="buttonc" Text="Update" />
                &nbsp; &nbsp;<asp:LinkButton ID="btnClear" runat="server" CssClass="buttonc" Text="Reset" CausesValidation="False" /></td>
        </tr>
    </table>
</asp:Content>

