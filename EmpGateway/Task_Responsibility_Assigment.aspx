<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Task_Responsibility_Assigment.aspx.vb" Inherits="Default4" Title="Task Reponsibility Assignment" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="2" class="tableheader">
                <asp:Label ID="Label5" runat="server" Text="Task Responsibility Assignment" Width="295px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Area
            </td>
            <td class="textcells">
                <asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="True" Width="550px" CssClass="combobox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Sub Area*
            </td>
            <td class="textcells">
                <asp:DropDownList ID="ddlSubArea" runat="server" AutoPostBack="True" Width="550px"
                    CssClass="combobox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Select Responsible Person(s)*
            </td>
            <td >
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 256px">
                    <tr>
                        <td rowspan="6" width="45%">
                            <asp:Panel ID="Panel4" runat="server" Height="250px" CssClass="panelcells" ScrollBars="Both"
                                Width="98%">
                                <asp:CheckBoxList ID="cblEmpResp" runat="server" CellPadding="0" CellSpacing="0"
                                    Height="1px" RepeatColumns="1" Width="95%">
                                </asp:CheckBoxList>
                            </asp:Panel>
                        </td>
                        <td rowspan="6">
                            <asp:Button ID="cmdTo" runat="server" Text="To..." Height="25px" CssClass="ButtonBack"
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Width="50px" BackColor="Black" />
                            <br />
                            <asp:Button ID="cmdRemove" runat="server" Text="<<" Width="50px" Height="25px" CssClass="ButtonBack"
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" BackColor="Black" />
                            <br />
                            <asp:Button ID="cmdCC" runat="server" Text="CC..." Width="50px" Height="25px" CssClass="ButtonBack"
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" BackColor="Black" />
                        </td>
                        <td rowspan="1" style="width: 45%; background-image: url(Image/SmallPanelGradient.PNG);
                            background-repeat: repeat-x;" valign="top">
                            <asp:Panel ID="Panel5" CssClass="panelcells" runat="server" Height="125px" ScrollBars="Both"
                                Width="98%">
                                <asp:CheckBoxList ID="cblTo" runat="server" CellPadding="0" CellSpacing="0" Height="1px"
                                    RepeatColumns="1" Width="230px">
                                </asp:CheckBoxList>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="5">
                            <asp:Panel ID="Panel6" runat="server" Height="125px" ScrollBars="Both" 
                                Width="98%" CssClass="panelcells">
                                <asp:CheckBoxList ID="cblCC" runat="server" CellPadding="0" CellSpacing="0" Height="1px"
                                    RepeatColumns="1" Width="230px">
                                </asp:CheckBoxList>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="Button1" runat="server" Text="Select All" CssClass="ButtonBack" BackColor="Black" />
                <asp:Button ID="cmdDeselectEmp" runat="server" Text="Deselect All" CssClass="ButtonBack" BackColor="Black" />
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2">
                <asp:Button ID="cmdSave" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Save" CssClass="ButtonBack" BackColor="Black" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
        ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    </asp:Content>
