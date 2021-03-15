<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="Guest_Book.aspx.vb" Inherits="Guest_Book" Title="Guest Book" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[

      
// ]]>
    </script>

    <table style="width: 100%;">
        <tr>
            <td colspan="2" class="tableheader">
                Add Comments</asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 129px">
                Department
            </td>
            <td style="width: 906px">
                <asp:DropDownList ID="DrpArea" runat="server" Width="249px" AutoPostBack="True" Font-Names="Tahoma"
                    Font-Size="8pt" Height="20px" CssClass="combobox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 129px">
                Subject
            </td>
            <td style="width: 906px">
                <asp:TextBox ID="txtsub" runat="server" TextMode="MultiLine" Width="519px" Font-Names="Tahoma"
                    Font-Size="8pt" Height="25px" CssClass="textbox"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 129px">
                Addressed To
            </td>
            <td style="width: 906px">
            </td>
        </tr>
        <tr>
            <td style="height: 90px;" colspan="2">
                <table width="100%" align="left" class="labelcells">
                    <tr>
                        <td valign="top" width="43%" class="textcells">
                            <asp:Panel ID="Panel1" runat="server" Height="100px" ScrollBars="Vertical" 
                                Width="98%" style="text-align: left" BorderStyle="Solid" BorderWidth="1px" Font-Names="Tahoma" Font-Size="8pt">
                                <asp:CheckBoxList ID="ChkFrom" runat="server" CellPadding="0" CellSpacing="0" Font-Bold="False"
                                    ForeColor="DimGray" Width="220px" Font-Names="Tahoma" Font-Size="8pt">
                                </asp:CheckBoxList>
                            </asp:Panel>
                        </td>
                        <td style="text-align: center; height: 42px; width: 123px">
                            <asp:Button ID="cmdTo" runat="server" CssClass="ButtonBack" BackColor="ControlDarkDark"  Font-Names="Tahoma"
                                Text="To" />
                            <br />
                            <asp:Button ID="cmdDel" runat="server" BackColor="ControlDarkDark" CssClass="ButtonBack"
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" ForeColor="White" Height="22px"
                                Text="<<" />
                        </td>
                        <td valign="top" class="textcells">
                            <asp:Panel ID="Panel2" runat="server" Height="100px" ScrollBars="Vertical" 
                                Width="98%" style="text-align: left" BorderStyle="Solid" BorderWidth="1px">
                                <asp:CheckBoxList ID="ChkTo" runat="server" CellPadding="0" CellSpacing="0" Font-Bold="False"
                                    Font-Names="Tahoma" Font-Size="8pt" ForeColor="DimGray" Width="280px">
                                </asp:CheckBoxList>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 129px">
                Point Of Problem/Suggestions
            </td>
            <td style="width: 906px;" class="textcells">
                <asp:TextBox ID="txtprob" runat="server" Height="20px" Width="277px" Font-Names="Tahoma"
                    Font-Size="8pt"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 129px">
                Remarks
            </td>
            <td style="width: 906px;" class="textcells">
                <asp:TextBox ID="txtremarks" runat="server" Height="112px" Width="571px" Font-Names="Tahoma"
                    Font-Size="8pt" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 129px; height: 20px">
            </td>
            <td style="height: 20px; width: 906px;">
                &nbsp;<asp:Button ID="Button1" runat="server" BackColor="ControlDarkDark"
                    Text="Apply" CssClass="ButtonBack" />
                <asp:Button ID="Button2" runat="server" BackColor="ControlDarkDark"
                    Text="Clear" CssClass="ButtonBack" />
            </td>
        </tr>
    </table>
</asp:Content>
