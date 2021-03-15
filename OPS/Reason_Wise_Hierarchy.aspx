<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="Reason_Wise_Hierarchy.aspx.vb" Inherits="OPS_Reason_Wise_Hierarchy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                
                Sanction Note Reason Wise Employee Hierarchy</td>
        </tr>
        <tr>
            <td>
                
                Area</td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlarea" runat="server" CssClass="combobox" Width="200px" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                
                Reason</td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlReason" runat="server" AutoPostBack="True" 
                            CssClass="combobox" Width="200px">
                        </asp:DropDownList>
                        &nbsp;<asp:Label ID="Label1" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                
                Level</td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtLevel" runat="server" CssClass="textbox"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                
                EmpCode</td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEmpcode" runat="server" CssClass="textbox"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                
                Plant</td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPlant" runat="server" CssClass="combobox" 
                            AutoPostBack="True">
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
				<asp:ListItem>Garmenting</asp:ListItem>
                            <asp:ListItem>JCTHOMES</asp:ListItem>

                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
               <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="cmdSave" runat="server" BorderStyle="None" 
                            CssClass="buttonc">Save</asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server">LinkButton</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server">
                          <HeaderStyle CssClass="GridHeader" />
                                        <RowStyle CssClass="GridItem" />
                                        <AlternatingRowStyle CssClass="GridAI" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

