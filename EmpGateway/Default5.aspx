<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Default5.aspx.vb" Inherits="Default5" Title="JCTians" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
               
                            <table style="width: 100%; height: 96px">
                                <tr>
                                    <td class="tableheader" colspan="3">
                            <asp:Label ID="Label27" runat="server" Text="JCTians "></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelcells">
                                        <asp:Label ID="lbldeptname" runat="server" Text="Department Name"></asp:Label>
                                    </td>
                                    <td class="textcells">
                                        <asp:DropDownList ID="DDLDeptname" runat="server" AutoPostBack="True" 
                                            Width="245px" CssClass="combobox">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                                            SelectCommand="SELECT [DEPTCODE],[DeptName] FROM [DEPTMAST] ORDER BY [DEPTNAME]">
                                        </asp:SqlDataSource>
                                        <%-- DataSourceID="SqlSavior1--%><%-- <asp:DropDownList ID="DDLDeptname" runat="server" AutoPostBack="True" Width="245px" Font-Names="Tahoma" Font-Size="8pt" >
                </asp:DropDownList>--%>
                                    </td>
                                    <td class="textcells" rowspan="10">
                                     <asp:Image ID="PictureBox1" runat="server" BorderStyle="None" Height="200px" ImageAlign="Middle"
                                Width="171px" ImageUrl="../EmployeePortal/EmpImages/2.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelcells">
                                        <asp:Label ID="lblempname" runat="server" Text="Employee Name" Height="13px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtempname" runat="server" CssClass="textbox" ReadOnly="true" Width="240px"></asp:TextBox >
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelcells">
                                        <asp:Label ID="lbldesg" runat="server" Text="Designation" Height="10px"></asp:Label>
                                    </td>
                                    <td class="textcells">
                                        <asp:TextBox ID="txtdesg" runat="server" Width="240px" CssClass="textbox" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelcells">
                                        <asp:Label ID="lbldob" runat="server" Text="Date of Birth" Height="13px" ></asp:Label>
                                    </td>
                                    <td class="labelcells">
                                        <asp:TextBox ID="txtdob" runat="server" Width="60px" CssClass="textbox" ReadOnly="true"></asp:TextBox>
                                        <asp:Label ID="Label1" runat="server" BorderStyle="None" Font-Size="8pt" Height="11px"
                                            Text="DD/MM/YYYY" Width="76px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelcells">
                                        <asp:Label ID="lbldoj" runat="server" Text="Date of Joining" Height="13px" ></asp:Label>
                                    </td>
                                    <td class="textcells">
                                        <asp:TextBox ID="txtdoj" runat="server" Width="60px" CssClass="textbox" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelcells">
                                        <asp:Label ID="lblintoffno" runat="server" Font-Size="8pt" Text="Int Off No" Width="80px"
                                            Height="13px"></asp:Label>
                                    </td>
                                    <td  class="textcells">
                                        <ew:NumericBox ID="txtintoff" runat="server" Font-Size="8pt" MaxLength="4" Width="36px"
                                            ReadOnly="True" CssClass="textbox"></ew:NumericBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelcells">
                                        <asp:Label ID="lblextoffno" runat="server" Font-Size="8pt" Text="Int. Res. No." Height="13px"></asp:Label>
                                    </td>
                                    <td  class="textcells">
                                        <ew:NumericBox ID="txtextoff" runat="server" MaxLength="4" Width="36px" ReadOnly="True"
                                            CssClass="textbox"></ew:NumericBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelcells">
                                        <asp:Label ID="lblepbxoff" runat="server" Text="EPBX Off" Height="13px"></asp:Label>
                                    </td>
                                    <td  class="textcells">
                                        <ew:NumericBox ID="txtepbxoff" runat="server" MaxLength="4" Width="36px" ReadOnly="True"
                                            CssClass="textbox"></ew:NumericBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelcells">
                                        <asp:Label ID="lblepbxresd" runat="server" Text="EPBX Res." Height="13px"></asp:Label>
                                    </td>
                                    <td class="textcells">
                                        <ew:NumericBox ID="txtepbxres" runat="server" CssClass="textbox" MaxLength="4" Width="36px"
                                            ReadOnly="True"></ew:NumericBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labelcells">
                                        <asp:Label ID="Label2" runat="server" Text="Email Id" Height="13px"></asp:Label>
                                    </td>
                                    <td class="textcells">
                                        <asp:TextBox ID="txtemailid" runat="server" MaxLength="30" ToolTip="You Can Change Personal Contact"
                                            Width="206px" ReadOnly="true" CssClass="textbox"></asp:TextBox>
                                        <asp:Label ID="Label3" runat="server" Text="@jctltd.com" Width="76px" BorderStyle="None"
                                            CssClass="labelcells" Font-Bold="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="buttonbackbar" colspan="3">
                                        <asp:Button ID="CmdMoveFirst" runat="server" Text="First" Enabled="False"
                                            CssClass="ButtonBack" BackColor="Black" />
                                        <asp:Button ID="Cmdmovepre" runat="server" Text="Previous" Enabled="False" CssClass="ButtonBack" BackColor="Black" />
                                        <asp:Button ID="CmdMoveNext" runat="server" Text="Next" Enabled="False" CssClass="ButtonBack" BackColor="Black" />
                                        <asp:Button ID="cmdmovelast" runat="server" Text="Last" Enabled="False" CssClass="ButtonBack" BackColor="Black" />
                                        <asp:Button ID="Button1" runat="server" Text="Save" CssClass="ButtonBack" BackColor="Black" />
                                    </td>
                                </tr>
                            </table>
                            <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="Please Edit Your Contact Info. & Then Press Save. You Can Edit Your Info. Only"
                                Width="442px" CssClass="labelcells" Font-Bold="True"></asp:Label>
                        
         
</asp:Content>
