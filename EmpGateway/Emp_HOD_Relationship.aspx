<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="Emp_HOD_Relationship.aspx.vb" Inherits="Emp_HOD_Relationship" Title="Employee <-> HOD Relationship"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%" border="0" cellpadding="0" cellspacing="2" id="TABLE1">
        <tr>
            <td colspan="2" class="tableheader">
                &nbsp;<asp:Label ID="Label5" runat="server" Text="Employee - HOD Relationship" Width="275px"
                    BorderColor="Transparent"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 348px; text-align: left;">
                Select Department(s)
            </td>
            <td>
                <asp:Panel ID="Panel2" runat="server" Height="85px" Width="290px" ScrollBars="Both"
                    BorderColor="Gray" BorderWidth="1px">
                    <asp:CheckBoxList ID="cblDeptList" runat="server" Font-Bold="False" Font-Names="Tahoma"
                        Font-Size="8pt" Height="1px" Width="270px" RepeatColumns="1" CellPadding="0"
                        CellSpacing="0" ForeColor="#404040" AutoPostBack="True">
                    </asp:CheckBoxList>
                </asp:Panel>
                <asp:Button ID="cmdSelectAllDept" runat="server" Text="Select All" Font-Bold="True"
                    Font-Names="Tahoma" Font-Size="8pt" CssClass="ButtonBack" BackColor="Black" />
                <asp:Button ID="cmdDeselectDept" runat="server" Text="Deselect All" Font-Bold="True"
                    Font-Names="Tahoma" Font-Size="8pt" CssClass="ButtonBack" BackColor="Black" />
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 348px">
                Select Head*
            </td>
            <td style="width: 509px; text-align: left; height: 6px;">
                <asp:DropDownList ID="ddlHOD" runat="server" Font-Bold="False" Font-Names="Tahoma"
                    Font-Size="8pt" Width="290px" AutoPostBack="True" ForeColor="#404040">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells_s" style="width: 348px">
                Employee List*
            </td>
            <td style="background-position: right top; height: 161px; text-align: left; background-image: url('../Image/Plain_Footer.png');
                background-repeat: no-repeat;">
                <asp:Panel ID="Panel1" runat="server" Height="270px" ScrollBars="Auto" Width="82%"
                    BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px">
                    <asp:CheckBoxList ID="cblEmpList" runat="server" Font-Bold="False" Font-Names="Tahoma"
                        Font-Size="8pt" Height="15px" Width="470px" RepeatColumns="1" CellPadding="0"
                        CellSpacing="0" ForeColor="#404040">
                    </asp:CheckBoxList>
                    <asp:CheckBoxList ID="cblMappedEmpList" runat="server" AutoPostBack="True" CellPadding="0"
                        CellSpacing="0" Font-Bold="False" Font-Names="Tahoma" Font-Size="8pt" ForeColor="Red"
                        Height="15px" RepeatColumns="1" Width="470px">
                    </asp:CheckBoxList>
                </asp:Panel>
                <asp:Label ID="Label1" runat="server" Font-Names="Tahoma" Font-Size="8pt" ForeColor="Red"
                    Text="Note: Employees in Red are Mapped against selected Head. UNMAP an Employee by removing check sign against it"
                    Width="589px"></asp:Label><br />
                <asp:Button ID="cmdSelectAllEmp" runat="server" Text="Select All" Font-Bold="True"
                    Font-Names="Tahoma" Font-Size="8pt" CssClass="ButtonBack" BackColor="Black" />
                <asp:Button ID="cmdDeselectEmp" runat="server" Text="Deselect All" Font-Bold="True"
                    Font-Names="Tahoma" Font-Size="8pt" CssClass="ButtonBack" BackColor="Black" />
                <asp:Button ID="Button1" runat="server" 
                    Text="Click to Add Details" CssClass="buttonlg" Width="120px" BackColor="Black" />
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; height: 20px; text-align: left; width: 348px;" valign="top" 
                class="labelcells_s">
                Select Employee to View Detail
            </td>
            <td 
                style="background-position: right top; width: 509px; height: 20px; text-align: left;
                background-image: url('../Image/Plain_Footer.png'); background-repeat: no-repeat;">
                <asp:Panel ID="Panel7" runat="server" Height="100px" Width="98%" ScrollBars="Both"
                    BorderColor="Gray" BorderWidth="1px">
                    <asp:RadioButtonList ID="rdoMappedEmp" runat="server" AutoPostBack="True" CellPadding="0"
                        CellSpacing="0" Font-Bold="False" Font-Names="Tahoma" Font-Size="8pt" Width="477px"
                        ForeColor="#404040">
                    </asp:RadioButtonList>
                </asp:Panel>
                <asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Size="8pt" ForeColor="Red"
                    Text="Note: Select an Employee to view its details below"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="vertical-align: top; width: 348px; text-align: right" valign="top"
                rowspan="3" class="labelcells">
            </td>
            <td style="width: 509px; height: 8px; text-align: left" valign="top">
                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Font-Bold="True"
                    Font-Names="Tahoma" Font-Size="8pt" ForeColor="DimGray" Text="Show All Employees" />
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 8px; text-align: right" valign="top" colspan="2">
                Days &nbsp;Auth
            </td>
        </tr>
        <tr><td class="labelcells" style="width: 509px; height: 8px; text-align: right" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" valign="top" style="height: 161px; text-align: left; vertical-align: top; width: 348px;"
                class="labelcells_s">
                Select Others Concerned for &nbsp;Leave Approval*
            </td>
            <td style="text-align: left; height: 161px; background-color: white; border-top-style: none;
                border-right-style: none; border-left-style: none; border-bottom-style: none;">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 113%; height: 11px;">
                    <tr><td rowspan="3" style="background-position: center top; background-image: url('../Image/Plain_footer.PNG');
                            width: 42%; background-repeat: no-repeat" valign="top">
                            <asp:Panel ID="Panel3" runat="server" Height="250px" Width="98%" ScrollBars="Both"
                                BorderColor="Gray" BorderWidth="1px" Enabled="False">
                                <asp:RadioButtonList ID="cblEmailAddress" runat="server" CellPadding="0" CellSpacing="0"
                                    Font-Names="Tahoma" Font-Size="8pt" Width="255px" ForeColor="DimGray">
                                </asp:RadioButtonList>
                            </asp:Panel>
                        </td>
                        <td rowspan="1" style="background-position: right top; width: 200px; height: 55px;
                            background-image: url(../Image/plain_footer.PNG); background-repeat: no-repeat;"
                            valign="top">
                            <asp:Panel ID="Panel6" runat="server" Height="25px" Width="300px" BorderColor="Silver"
                                Enabled="False">
                                <table style="width: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="height: 1px;" valign="top">
                                            <asp:Button ID="cmdTo" runat="server" CssClass="ButtonBack" Enabled="False" 
                                                Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Text="To..." 
                                                Width="39px" BackColor="Black" />
                                        </td>
                                        <td style="width: 280px; height: 1px">
                                            <asp:CheckBoxList ID="cblTo" runat="server" Font-Bold="False" Font-Names="Tahoma"
                                                Font-Size="8pt" Height="1px" Width="100%" RepeatColumns="1" CellPadding="0" CellSpacing="0"
                                                ForeColor="#404040">
                                            </asp:CheckBoxList>
                                        </td>
                                        <td style="height: 1px" valign="top">
                                            <asp:TextBox ID="txtToDays" runat="server" Width="13px" Font-Bold="True" Font-Names="Tahoma"
                                                Font-Size="8pt"></asp:TextBox>
                                        </td>
                                        <td style="height: 1px" valign="top">
                                            <asp:CheckBox ID="chkTo" runat="server" Text=" " Checked="True" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="Panel5" runat="server" Height="25px" Width="300px" BorderColor="Silver"
                                Enabled="False">
                                <table style="width: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="height: 1px;" valign="top">
                                            <asp:Button ID="cmdCC" runat="server" CssClass="ButtonBack" Enabled="False" 
                                                Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Text="CC..." 
                                                Width="39px" BackColor="Black" />
                                        </td>
                                        <td style="width: 290px; height: 1px" valign="middle">
                                            <asp:CheckBoxList ID="cblCC" runat="server" Font-Bold="False" Font-Names="Tahoma"
                                                Font-Size="8pt" Height="1px" Width="100%" RepeatColumns="1" CellPadding="0" CellSpacing="0"
                                                ForeColor="#404040">
                                            </asp:CheckBoxList>
                                        </td>
                                        <td style="height: 1px" valign="top">
                                            <asp:TextBox ID="txtBCCDays" runat="server" Width="13px" Font-Bold="True" Font-Names="Tahoma"
                                                Font-Size="8pt"></asp:TextBox>
                                        </td>
                                        <td style="height: 1px" valign="top">
                                            <asp:CheckBox ID="chkBCC" runat="server" Text=" " Checked="True" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="Panel8" runat="server" Height="25px" Width="304px" BorderColor="Silver"
                                Enabled="False">
                                <table style="width: 99%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="height: 1px;" valign="top">
                                            <asp:Button ID="cmdBCC1" runat="server" CssClass="ButtonBack" Enabled="False" 
                                                Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Text="BCC1..." 
                                                Width="39px" BackColor="Black" />
                                        </td>
                                        <td style="width: 295px; height: 1px" valign="middle">
                                            <asp:CheckBoxList ID="cblBCC1" runat="server" Font-Bold="False" Font-Names="Tahoma"
                                                Font-Size="8pt" Height="1px" Width="100%" RepeatColumns="1" CellPadding="0" CellSpacing="0"
                                                ForeColor="#404040">
                                            </asp:CheckBoxList>
                                        </td>
                                        <td style="height: 1px" valign="top">
                                            <asp:TextBox ID="txtBCC1Days" runat="server" Width="13px" Font-Bold="True" Font-Names="Tahoma"
                                                Font-Size="8pt"></asp:TextBox>
                                        </td>
                                        <td style="height: 1px" valign="top">
                                            <asp:CheckBox ID="chkBCC1" runat="server" Text=" " Checked="True" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="Panel9" runat="server" Height="25px" Width="300px" BorderColor="Gray"
                                Enabled="False">
                                <table style="width: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="height: 1px;" valign="top">
                                            <asp:Button ID="cmdBCC2" runat="server" CssClass="ButtonBack" Enabled="False" 
                                                Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Text="BCC2..." 
                                                Width="39px" BackColor="Black" />
                                        </td>
                                        <td style="width: 294px; height: 1px" valign="middle">
                                            <asp:CheckBoxList ID="cblBCC2" runat="server" Font-Bold="False" Font-Names="Tahoma"
                                                Font-Size="8pt" Height="1px" Width="100%" RepeatColumns="1" CellPadding="0" CellSpacing="0"
                                                ForeColor="#404040">
                                            </asp:CheckBoxList>
                                        </td>
                                        <td style="height: 1px" valign="top">
                                            <asp:TextBox ID="txtBCC2Days" runat="server" Width="13px" Font-Bold="True" Font-Names="Tahoma"
                                                Font-Size="8pt"></asp:TextBox>
                                        </td>
                                        <td style="height: 1px" valign="top">
                                            <asp:CheckBox ID="chkBCC2" runat="server" Text=" " Checked="True" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="Panel10" runat="server" Height="25px" Width="300px" BorderColor="Gray"
                                Enabled="False">
                                <table style="width: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="height: 1px;" valign="top">
                                            <asp:Button ID="cmdBCC3" runat="server" CssClass="ButtonBack" Enabled="False" 
                                                Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Height="28px" 
                                                Text="BCC3..." Width="39px" BackColor="Black" />
                                        </td>
                                        <td style="width: 304px; height: 1px" valign="middle">
                                            <asp:CheckBoxList ID="cblBCC3" runat="server" Font-Bold="False" Font-Names="Tahoma"
                                                Font-Size="8pt" Height="1px" Width="100%" RepeatColumns="1" CellPadding="0" CellSpacing="0"
                                                ForeColor="#404040">
                                            </asp:CheckBoxList>
                                        </td>
                                        <td style="height: 1px" valign="top">
                                            <asp:TextBox ID="txtBCC3Days" runat="server" Width="13px" Font-Bold="True" Font-Names="Tahoma"
                                                Font-Size="8pt"></asp:TextBox>
                                        </td>
                                        <td style="height: 1px" valign="top">
                                            <asp:CheckBox ID="chkBCC3" runat="server" Text=" " Checked="True" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="Panel11" runat="server" Height="25px" Width="300px" BorderColor="Gray"
                                Enabled="False">
                                <table style="width: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="height: 1px;" valign="top">
                                            <asp:Button ID="cmdBCC4" runat="server" CssClass="ButtonBack" Enabled="False" 
                                                Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Text="BCC4..." 
                                                Width="39px" BackColor="Black" />
                                        </td>
                                        <td style="width: 287px; height: 1px" valign="middle">
                                            <asp:CheckBoxList ID="cblBCC4" runat="server" Font-Bold="False" Font-Names="Tahoma"
                                                Font-Size="8pt" Height="1px" Width="100%" RepeatColumns="1" CellPadding="0" CellSpacing="0"
                                                ForeColor="#404040">
                                            </asp:CheckBoxList>
                                        </td>
                                        <td style="height: 1px" valign="top">
                                            <asp:TextBox ID="txtBCC4Days" runat="server" Width="13px" Font-Bold="True" Font-Names="Tahoma"
                                                Font-Size="8pt"></asp:TextBox>
                                        </td>
                                        <td style="height: 1px" valign="top">
                                            <asp:CheckBox ID="chkBCC4" runat="server" Text=" " Checked="True" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="Panel12" runat="server" Height="25px" Width="300px" BorderColor="Gray"
                                Enabled="False">
                                <table style="width: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="height: 1px;" valign="top">
                                            <asp:Button ID="cmdBCC5" runat="server" CssClass="ButtonBack" Enabled="False" 
                                                Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Text="BCC5..." 
                                                Width="39px" BackColor="Black" />
                                        </td>
                                        <td style="width: 289px; height: 1px" valign="middle">
                                            <asp:CheckBoxList ID="cblBCC5" runat="server" Font-Bold="False" Font-Names="Tahoma"
                                                Font-Size="8pt" Height="1px" Width="100%" RepeatColumns="1" CellPadding="0" CellSpacing="0"
                                                ForeColor="#404040">
                                            </asp:CheckBoxList>
                                        </td>
                                        <td style="height: 1px" valign="top">
                                            <asp:TextBox ID="txtBCC5Days" runat="server" Width="13px" Font-Bold="True" Font-Names="Tahoma"
                                                Font-Size="8pt"></asp:TextBox>
                                        </td>
                                        <td style="height: 1px" valign="top">
                                            <asp:CheckBox ID="chkBCC5" runat="server" Text=" " Checked="True" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="Panel4" runat="server" Width="300px" BorderColor="Silver" Enabled="False">
                                <table style="width: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="height: 1px;" valign="top">
                                            <asp:Button ID="cmdBCC" runat="server" CssClass="ButtonBack" Enabled="False" 
                                                Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Text="BCC..." 
                                                Width="39px" BackColor="Black" />
                                        </td>
                                        <td style="width: 297px; height: 1px" valign="middle">
                                            <asp:CheckBoxList ID="cblBCC" runat="server" Font-Bold="False" Font-Names="Tahoma"
                                                Font-Size="8pt" Height="1px" Width="100%" RepeatColumns="1" CellPadding="0" CellSpacing="0"
                                                ForeColor="#404040">
                                            </asp:CheckBoxList>
                                        </td>
                                        <td style="height: 1px" valign="top">
                                            <asp:TextBox ID="txtCCDays" runat="server" Width="13px" Font-Bold="True" Font-Names="Tahoma"
                                                Font-Size="8pt"></asp:TextBox>
                                        </td>
                                        <td style="height: 1px" valign="top">
                                            <asp:CheckBox ID="chkCC" runat="server" Text=" " Checked="True" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                             <asp:Panel ID="Panel13" runat="server" Width="300px" BorderColor="Silver" Enabled="False">
                                <table style="width: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="height: 1px;" valign="top">
                                         
                                            <asp:Button ID="cmdRemove" runat="server" CssClass="ButtonBack" Enabled="False" 
                                                Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Text="&lt;&lt;" 
                                                Width="39px" BackColor="Black" />
                                         
                                        </td>
                                        <td style="width: 297px; height: 1px" valign="middle">
                                            
                                        </td>
                                        <td style="height: 1px" valign="top">
                                         
                                        </td>
                                        <td style="height: 1px" valign="top">
                                         
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top" align="right" style="width: 348px;">
            </td>
            <td style="width: 509px; text-align: left;" bgcolor="whitesmoke">
                <asp:Button ID="cmdSave" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Save Relation" CssClass="ButtonBack" Width="84px" BackColor="Black" />
            </td>
        </tr>
    </table>
    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
        ForeColor="Red"></asp:Label>
</asp:Content>
