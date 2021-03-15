<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Default11.aspx.vb" Inherits="Default11" title="Authroize/UnAuthorize Leave" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<table>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
            <td bgcolor="whitesmoke" colspan="2">
                &nbsp;</td>
            <td background="Image/Gradient.PNG" bgcolor="whitesmoke" style="width: 50px; background-image: url(Image/Gradient2.PNG);">
                <asp:TextBox ID="TextBox13" runat="server" BackColor="Transparent" BorderStyle="None"
                    Font-Bold="True"   ForeColor="DimGray" Width="68px">Leave Type</asp:TextBox></td>
            <td bgcolor="whitesmoke" style="width: 107px">
                &nbsp;</td>
        </tr>
        <tr>
            <td background="Image/Gradient.PNG" style="width: 138px; background-image: url(Image/Gradient2.PNG); background-repeat: no-repeat;">
                <asp:TextBox ID="TextBox15" runat="server" BackColor="Transparent" BorderStyle="None"
                    Font-Bold="True"   ForeColor="#5B5B5B" Width="100%">Name of Employee</asp:TextBox></td>
            <td bgcolor="whitesmoke" colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td background="Image/Gradient.PNG" style="width: 138px; background-image: url(Image/Gradient2.PNG); background-repeat: no-repeat;">
                <asp:TextBox ID="TextBox19" runat="server" BackColor="Transparent" BorderStyle="None"
                    Font-Bold="True"   ForeColor="#5B5B5B" Width="100%">Designation</asp:TextBox></td>
            <td bgcolor="whitesmoke" colspan="2">
                &nbsp;</td>
            <td background="Image/Gradient.PNG" bgcolor="whitesmoke" style="width: 50px; background-image: url(Image/Gradient2.PNG);">
                <asp:TextBox ID="TextBox23" runat="server" BackColor="Transparent" BorderStyle="None"
                    Font-Bold="True"   ForeColor="DimGray" Width="33px">Shift</asp:TextBox></td>
            <td bgcolor="whitesmoke" style="width: 107px">
                &nbsp;</td>
        </tr>
        <tr>
            <td background="Image/Gradient.PNG" style="width: 138px; height: 12px; background-image: url(Image/Gradient2.PNG); background-repeat: no-repeat;">
                <asp:TextBox ID="TextBox25" runat="server" BackColor="Transparent" BorderStyle="None"
                    Font-Bold="True"   ForeColor="#5B5B5B" Width="100%">Department</asp:TextBox></td>
            <td bgcolor="whitesmoke" colspan="2" style="height: 12px">
                &nbsp;</td>
            <td background="Image/Gradient.PNG" bgcolor="whitesmoke" style="width: 50px; background-image: url(Image/Gradient2.PNG);">
                <asp:TextBox ID="TextBox28" runat="server" BackColor="Transparent" BorderStyle="None"
                    Font-Bold="True"   ForeColor="DimGray" Width="90px">Number of Days</asp:TextBox></td>
            <td bgcolor="whitesmoke" style="width: 107px; height: 12px">
                &nbsp;</td>
        </tr>
        <tr>
            <td background="Image/Gradient.PNG" style="width: 138px; background-image: url(Image/Gradient2.PNG); background-repeat: no-repeat;">
                <asp:TextBox ID="TextBox30" runat="server" BackColor="Transparent" BorderStyle="None"
                    Font-Bold="True"   ForeColor="#5B5B5B" Width="113%">Leave From (DD/MM/YYYY)</asp:TextBox></td>
            <td bgcolor="whitesmoke" colspan="2" style="height: 1px">
                &nbsp;</td>
            <td background="Image/Gradient.PNG" bgcolor="whitesmoke" style="width: 50px; background-image: url(Image/Gradient2.PNG);">
                <asp:TextBox ID="TextBox31" runat="server" BackColor="Transparent" BorderStyle="None"
                    Font-Bold="True"   ForeColor="DimGray" Width="141px">Leave To (DD/MM/YYYY)</asp:TextBox></td>
            <td bgcolor="whitesmoke" style="width: 107px; height: 1px">
                &nbsp;</td>
        </tr>
        <tr>
            <td background="Image/Gradient.PNG" style="width: 138px; background-image: url(Image/Gradient2.PNG); background-repeat: no-repeat;">
                <asp:TextBox ID="TextBox32" runat="server" BackColor="Transparent" BorderStyle="None"
                    Font-Bold="True"   ForeColor="#5B5B5B" Width="100%">Time From</asp:TextBox></td>
            <td bgcolor="whitesmoke" style="width: 200px; height: 4px">
                &nbsp;</td>
            <td bgcolor="whitesmoke" style="width: 5px; height: 4px">
            </td>
            <td background="Image/Gradient.PNG" bgcolor="whitesmoke" style="width: 50px; background-image: url(Image/Gradient2.PNG);">
                <asp:TextBox ID="TextBox33" runat="server" BackColor="Transparent" BorderStyle="None"
                    Font-Bold="True"   ForeColor="DimGray" Width="99px">Time To</asp:TextBox></td>
            <td bgcolor="whitesmoke" style="width: 107px; height: 4px">
                &nbsp;</td>
        </tr>
        <tr>
            <td background="Image/Gradient.PNG" style="width: 138px; height: 19px; background-image: url(Image/Gradient2.PNG); background-repeat: no-repeat;">
                <asp:TextBox ID="TextBox34" runat="server" BackColor="Transparent" BorderStyle="None"
                    Font-Bold="True"   ForeColor="#5B5B5B" Width="100%">Compensatory Leave</asp:TextBox></td>
            <td bgcolor="whitesmoke" colspan="4" style="height: 19px">
                &nbsp;</td>
        </tr>
        <tr>
            <td background="Image/Gradient.PNG" style="width: 138px; height: 17px; background-image: url(Image/Gradient2.PNG); background-repeat: no-repeat;">
                <asp:TextBox ID="TextBox8" runat="server" BackColor="Transparent" BorderStyle="None"
                    Font-Bold="True"   ForeColor="#5B5B5B" Width="113%">Compensatory Date Against
</asp:TextBox></td>
            <td id="Td1" bgcolor="whitesmoke" colspan="4" style="height: 17px">
                &nbsp;</td>
        </tr>
        <tr>
            <td background="Image/Gradient.PNG" style="width: 138px; background-image: url(Image/Gradient2.PNG); background-repeat: no-repeat; height: 12px;">
                <asp:TextBox ID="TextBox36" runat="server" BackColor="Transparent" BorderStyle="None"
                    Font-Bold="True"   ForeColor="#5B5B5B" Height="18px"
                    Width="100%">Purpose of Leave</asp:TextBox></td>
            <td bgcolor="whitesmoke" colspan="4" style="height: 12px">
                &nbsp;</td>
        </tr>
        <tr>
            <td background="Image/Gradient.PNG" style="width: 138px; background-image: url(Image/Gradient2.PNG); background-repeat: no-repeat; height: 6px;">
                <asp:TextBox ID="TextBox38" runat="server" BackColor="Transparent" BorderStyle="None"
                    Font-Bold="True"   ForeColor="#5B5B5B" Height="18px"
                    Width="100%">Address while on Leave</asp:TextBox></td>
            <td bgcolor="whitesmoke" colspan="4" style="height: 6px">
                &nbsp;</td>
        </tr>
        <tr>
            <td background="Image/Gradient.PNG" style="width: 138px; background-image: url(Image/Gradient2.PNG); background-repeat: no-repeat;">
                <asp:TextBox ID="TextBox40" runat="server" BackColor="Transparent" BorderStyle="None"
                    Font-Bold="True"   ForeColor="#5B5B5B" Height="18px"
                    Width="100%">Phone while on Leave</asp:TextBox></td>
            <td bgcolor="whitesmoke" colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td background="Image/Gradient.PNG" style="width: 138px; background-image: url(Image/Gradient2.PNG); background-repeat: no-repeat;">
                <asp:TextBox ID="TextBox42" runat="server" BackColor="Transparent" BorderStyle="None"
                    Font-Bold="True"   ForeColor="#5B5B5B" Height="18px"
                    Width="100%">Remarks*</asp:TextBox></td>
            <td bgcolor="whitesmoke" colspan="4" valign="top">
                &nbsp;
                </td>
        </tr>
        </table>--%>
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label5" runat="server" Text="Leave Application (OD/SL/PL/CL/Travel Leave/Comp Leave)" Width="427px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label16" runat="server" Text="Nature of Leave" Width="120px"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="ddlleave" runat="server" CssClass="textbox" ReadOnly="True"></asp:TextBox></td>
            <td class="labelcells">
                <asp:Label ID="Label28" runat="server" Text="Leave Type" Width="80px"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="dlleavetype" runat="server" CssClass="textbox" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label17" runat="server" Text="Name of Employee"></asp:Label>
            </td>
            <td class="textcells" colspan="3">
                <asp:TextBox ID="txtname" runat="server" CssClass="textbox" ReadOnly="True" 
                    Width="502px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label18" runat="server" Text="Designation"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="TextBox6" runat="server" CssClass="textbox" ReadOnly="True"></asp:TextBox></td>
            <td class="labelcells">
                <asp:Label ID="Label29" runat="server" Text="Shift"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="ddlshift" runat="server" Font-Names="Tahoma" Font-Size="8pt" 
                    Width="95%" ReadOnly="True" CssClass="textbox"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label19" runat="server" Text="Department"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtdept" runat="server" CssClass="textbox" ReadOnly="True" 
                    Width="199px"></asp:TextBox></td>
            <td class="labelcells">
                <asp:Label ID="Label30" runat="server" Text="Number of Days"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtdays" runat="server" Font-Names="Tahoma" Font-Size="8pt" 
                    Width="50px" ReadOnly="True" CssClass="textbox"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelcells" >
                <asp:Label ID="Label20" runat="server" Text="Leave From (DD/MM/YYYY)"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtleavefrom" runat="server"  
                    ReadOnly="True" CssClass="textbox"></asp:TextBox></td>
            <td class="labelcells" style="height: 30px">
                <asp:Label ID="Label31" runat="server" Text="Leave To (DD/MM/YYYY)"></asp:Label>
            </td>
            <td style="height: 30px">
                <asp:TextBox ID="txtleaveto" runat="server" Font-Names="Tahoma" Font-Size="8pt" 
                    Width="95%" ReadOnly="True" CssClass="textbox"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label21" runat="server" Text="Time From"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txttimefrom" runat="server"  
                    ReadOnly="True" CssClass="textbox"></asp:TextBox></td>
            <td class="labelcells">
                <asp:Label ID="Label32" runat="server" Text="Time To"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txttimeto" runat="server"   
                    Width="95%" ReadOnly="True" CssClass="textbox"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label22" runat="server" Text="Compensatory Leave"></asp:Label>
            </td>
            <td class="textcells" colspan="3">
                <asp:TextBox ID="txtcompleave" runat="server" Enabled="False" Font-Names="Tahoma"
                    Font-Size="8pt" Width="420px" ReadOnly="True" CssClass="textbox"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label33" runat="server" Text="Compensatory Against Dt." 
                    Width="150px"></asp:Label>
            </td>
            <td class="textcells" colspan="3">
                <asp:TextBox ID="TxtCoDtAgian" runat="server" Font-Names="Tahoma" Font-Size="8pt" ReadOnly="True" Width="89px" CssClass="textbox"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label23" runat="server" Text="Purpose of Leave"></asp:Label>
            </td>
            <td class="textcells" colspan="3">
                <asp:TextBox ID="txtpurleave" runat="server"   Width="420px" ReadOnly="True" CssClass="textbox"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label24" runat="server" Text="Address while on leave"></asp:Label>
            </td>
            <td class="textcells" colspan="3">
                <asp:TextBox ID="txtaddleave" runat="server"   Width="420px" ReadOnly="True" CssClass="textbox"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label25" runat="server" Text="Phone while on Leave"></asp:Label>
            </td>
            <td class="textcells" colspan="3">
                <asp:TextBox ID="txtphoneleave" runat="server"   Width="420px" ReadOnly="True" CssClass="textbox"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label27" runat="server" Text="Remarks*"></asp:Label>
            </td>
            <td class="textcells" colspan="3">
                <asp:TextBox ID="txtremarks" runat="server"   Height="19px"
                    Width="420px" TextMode="MultiLine" CssClass="textbox"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="textcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4" valign="top">
                <asp:Button ID="cmdauthorize" runat="server" Text="Authorize" CssClass="ButtonBack" BackColor="black" />
                <asp:Button ID="cmdcancle" runat="server" Text="UnAuthorize/Cancel" CssClass="buttonlg" BackColor="black" Width="120px" /></td>
        </tr>
        </table>
    </asp:Content>

