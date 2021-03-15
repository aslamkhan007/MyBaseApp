<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage_Default.master" AutoEventWireup="false" CodeFile="Default_Panel.aspx.vb" Inherits="OPS_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DataList ID="DataList1" runat="server" Width="100%" 
        DataSourceID="SqlDataSource2" RepeatLayout="Flow">
    <ItemTemplate>
        <div class="tableback" 
            style="padding: 10px; font-family: 'trebuchet MS'; vertical-align: top;">
            <asp:Label ID="Label16" runat="server" Text='<%# Eval("linkcategory") %>'></asp:Label>
            
            <hr style="height: 2px; line-height: 2px;" />
            <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource1" 
                RepeatDirection="Horizontal">
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" style="width: 100px">
                        <tr>
                            <td>
                                <div style="margin: auto; width: 64px">
                                    <asp:ImageButton ID="ImageButton1" runat="server" 
                                        AlternateText='<%# Eval("LinkName") %>' ImageUrl='<%# Eval("LinkImagePath") %>' 
                                        PostBackUrl='<%# Eval("NavigateURL") %>' Width="64px" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="NormalText" style="text-align: center">
                                <asp:LinkButton ID="lnkLink" runat="server" 
                                    PostBackUrl='<%# Eval("NavigateURL") %>' Text='<%# Eval("LinkName") %>'></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
            SelectCommand="select * from jct_ops_quick_links where status = 'A' and LinkCategory = @LinkCategory">
            <SelectParameters>
                <asp:ControlParameter ControlID="Label16" DefaultValue="" Name="LinkCategory" 
                    PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    </ItemTemplate>
</asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
        SelectCommand="select distinct linkcategory,categoryorder from jct_ops_quick_links where status = 'A' order by categoryorder">
    </asp:SqlDataSource>
</asp:Content>

