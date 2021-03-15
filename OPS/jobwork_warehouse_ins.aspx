<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="jobwork_warehouse_ins.aspx.cs" Inherits="OPS_jobwork_warehouse_ins" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="2">
                JobWork Warehouse Inspection</td>
        </tr>
        <tr>
            <td>
                RequestID</td>
            <td>
                <asp:TextBox ID="txtchalanno" runat="server" CssClass="textbox" 
                    ontextchanged="txtchalanno_TextChanged" AutoPostBack="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
         



                   <td  colspan="2" >
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Both" 
                    Visible="False" Width="900px">
                   <asp:GridView ID="grdDetail" runat="server"
                    Width="100%" EnableModelValidation="True" 
                                                       >
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />

                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                        <asp:TemplateField HeaderText="Shortfall">
                            <ItemTemplate>
                                <asp:TextBox ID="txtshrtfall" runat="server" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks">
                            <ItemTemplate>
                                <asp:TextBox ID="txtremarks" runat="server" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
           
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2">
                <asp:LinkButton ID="lnksaVE" runat="server" CssClass="buttonc" 
                    onclick="lnksaVE_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                    onclick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

