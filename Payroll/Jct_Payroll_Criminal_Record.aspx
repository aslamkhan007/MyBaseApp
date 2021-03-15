<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_Criminal_Record.aspx.cs" Inherits="Payroll_Jct_Payroll_Criminal_Record" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td class="tableheader">
                Criminal Record
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Employee Code:
            </td>
            <td class="NormalText">
            <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>--%>
                <asp:TextBox ID="txtEmpCode" runat="server" Style="text-transform: capitalize;" CssClass="textbox"
                    AutoPostBack="True" MaxLength="10" ontextchanged="txtEmpCode_TextChanged1" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmpCode"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                     <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
             <td class="labelcells">
             &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
            </td>
            <td class="labelcells">
                 &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
            </td>
            <td class="labelcells">
                  &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
            </td>
            <td class="labelcells">
              &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
            </td>
            <td class="labelcells">
                <asp:Label ID="SrCode" runat="server" Text="Sr No" Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="SrId" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        </table>

     <asp:Panel ID="Panel1" Width="100%" runat="server" BorderStyle="Solid">
    <table class="mytable">
            <tr>
                <td>
                    <asp:GridView ID="grdDetail" runat="server" Width="100%" 
                        AutoGenerateColumns="False" >
                        <AlternatingRowStyle CssClass="GridAI" />
                        <Columns>
                             <asp:BoundField DataField="SrNo" HeaderText="SrNo" SortExpression="SrNo" 
                                InsertVisible="False" ReadOnly="True" />
                            <asp:BoundField DataField="Questions" HeaderText="Questions" SortExpression="Questions" />
                              <asp:TemplateField HeaderText="Further Details">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAnswer" runat="server" CssClass="textbox" Width="150px" MaxLength="80"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
  <%--                  <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$misjctdev %>" 
                        SelectCommand="SELECT SrNo,Questions FROM jctdev4.dbo.Jct_Payroll_Criminal_Questions WHERE SrNo between '1'and '10'">
                    </asp:SqlDataSource>--%>
                </td>
            </tr>
              <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" Width="100%" 
                        AutoGenerateColumns="False">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <Columns>
                             <asp:BoundField DataField="SrNo" HeaderText="SrNo" SortExpression="SrNo" 
                                InsertVisible="False" ReadOnly="True" />
                            <asp:BoundField DataField="Questions" HeaderText="Questions" SortExpression="Questions" />
                              <asp:TemplateField HeaderText="Further Details">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAnswer"  Text='<%# Eval("Answer") %>'  runat="server" CssClass="textbox" Width="150px" MaxLength="80"></asp:TextBox>
                                    <%--<asp:TextBox ID="txtAnswer"   runat="server" CssClass="textbox" Width="150px" MaxLength="80"></asp:TextBox>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                </td>
            </tr>
    <tr>
            <td class="buttonbackbar">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                    ValidationGroup="A" onclick="lnksave_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                    ValidationGroup="A" onclick="lnkupdate_Click">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                    onclick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr></table> </asp:Panel>

</asp:Content>
