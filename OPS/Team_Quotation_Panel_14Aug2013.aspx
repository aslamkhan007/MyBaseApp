<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" MaintainScrollPositionOnPostback ="true" AutoEventWireup="false" CodeFile="Team_Quotation_Panel.aspx.vb" Inherits="OPS_Quotation_Panel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Quotation Panel</td>
        </tr>
        <tr>
            <td style="font-size: 10pt; text-align: center;" colspan="4">
                <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="~/OPS/Image/STab_My_Quotations.png" 
                    PostBackUrl="~/OPS/Quotation_Panel.aspx" />
                <asp:ImageButton ID="ImageButton2" runat="server" 
                    ImageUrl="~/OPS/Image/Tab_Team_Quotations.png" Enabled="False" />
            </td>
        </tr>
        <tr>
            <td style="font-size: 10pt">
                Open Quotations</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <div id="AdjResultsDiv" 
                    style="height: 200px; overflow: auto; width:950px; top: 0px; left: 0px;">
                <asp:GridView ID="grdOpenQuotes" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
                    EnableModelValidation="True" EmptyDataText="No Open Quotation is found.">
                    <AlternatingRowStyle CssClass="GridAI" Wrap="False" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False" Visible="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="cmdAuthorise" runat="server" CausesValidation="False" 
                                    onclientclick="javascript:return confirm('Are you sure want to authorise?');" 
                                    Text="Authorise" CommandArgument='<%# Eval("Quotation No") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField DataTextField="Quotation No" HeaderText="Quotation No" 
                            NavigateUrl="~/OPS/Quotation_Main.aspx" 
                            DataNavigateUrlFields="Quotation No" 
                            DataNavigateUrlFormatString="Quotation_Main.aspx?quot={0}" />
                        <asp:TemplateField HeaderText="Validity" SortExpression="Validity">
                            <ItemTemplate>
                                <asp:Image ID="imgValidity" runat="server" 
                                    ImageUrl='<%# Eval("Validity_Img") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Validity") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="P/L" SortExpression="P/L">
                            <ItemTemplate>
                                <asp:Image ID="imgPL" runat="server" ImageUrl='<%# Eval("PL_Img") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("[P/L]") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Customer" HeaderText="Customer" 
                            SortExpression="Customer" >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Sale Person" HeaderText="Sale Person" 
                            SortExpression="Sale Person">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Item Type" HeaderText="Item Type" 
                            SortExpression="Item Type" >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Sort/Enq" HeaderText="Sort/Enq" 
                            SortExpression="Item Code" >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Dated" HeaderText="Dated" ReadOnly="True" 
                            SortExpression="Dated" >
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Shades" HeaderText="Shades" ReadOnly="True" 
                            SortExpression="Shades" >
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Total Quantity" HeaderText="Total Quantity" 
                            ReadOnly="True" SortExpression="Total Quantity" >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UOM" HeaderText="UOM" SortExpression="UOM" >
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DnV Cost AWtd." HeaderText="DnV Cost" 
                            ReadOnly="True" SortExpression="DnV Cost AWtd." >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Sale Price" HeaderText="Sale Price" 
                            SortExpression="Sale Price" >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Margin %" HeaderText="Margin %" 
                            SortExpression="Margin %" >
                        <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Pref Margin %" HeaderText="Pref Margin %" 
                            ReadOnly="True" SortExpression="Pref Margin %" >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Net Margin %" HeaderText="Net Margin %" 
                            SortExpression="Net Margin %" >
                        <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Pay Time" HeaderText="Pay Time" 
                            SortExpression="Pay Time" >
                        <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="GridHeader" Wrap="False" />
                    <RowStyle CssClass="GridItem" Wrap="False" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="jct_ops_get_team_quotations" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="User_Code" SessionField="EmpCode" Type="String" />
                        <asp:Parameter Name="status" Type="String" DefaultValue="QuotOpen" />
                    </SelectParameters>
                </asp:SqlDataSource>
                   
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="height: 17px" class="errormsg">
                 
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
               </ContentTemplate>
                </asp:UpdatePanel>
                </td>
        </tr>
        </table>
    <table style="width:100%;" class="tableback">
        <tr>
            <td style="font-size: 10pt">
                Quotations Pending Authorisation</td>
        </tr>
        <tr>
            <td>
                <div id="AdjResultsDiv1" 
                    style="height: 200px; overflow: auto; width:950px; top: 0px; left: -1px;">
                <asp:GridView ID="grdUnauthorisedQuotes" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="SqlDataSource2" 
                    EnableModelValidation="True" EmptyDataText="No Relevant Quotation is found.">
                    <AlternatingRowStyle CssClass="GridAI" Wrap="False" />
                    <Columns>
                        
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtAuthorise" runat="server" 
                                    ImageUrl="~/OPS/Image/Authorise.png" AlternateText="Authorise" 
                                    CommandArgument='<%# Eval("Quotation No") %>' CommandName="Authorise" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtReject" runat="server" 
                                    ImageUrl="~/OPS/Image/Reject.png" AlternateText="Reject Quotation" 
                                    CommandArgument='<%# Eval("Quotation No") %>' CommandName="Reject" 
                                    Height="17px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField ShowHeader="False" Visible="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="cmdAuthorise0" runat="server" CausesValidation="False" 
                                    onclientclick="javascript:return confirm('Are you sure want to authorise?');" 
                                    Text="Authorise" CommandArgument='<%# Eval("Quotation No") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField DataTextField="Quotation No" HeaderText="Quotation No" 
                            NavigateUrl="~/OPS/Quotation_Main.aspx" 
                            DataNavigateUrlFields="Quotation No" 
                            DataNavigateUrlFormatString="Quotation_Main.aspx?quot={0}" />
                        <asp:TemplateField HeaderText="Validity" SortExpression="Validity">
                            <ItemTemplate>
                                <asp:Image ID="imgValidity0" runat="server" 
                                    ImageUrl='<%# Eval("Validity_Img") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Validity") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="P/L" SortExpression="P/L">
                            <ItemTemplate>
                                <asp:Image ID="imgPL0" runat="server" ImageUrl='<%# Eval("PL_Img") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("[P/L]") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Customer" HeaderText="Customer" 
                            SortExpression="Customer" >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Sale Person" HeaderText="Sale Person" 
                            SortExpression="Sale Person">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Item Type" HeaderText="Item Type" 
                            SortExpression="Item Type" >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Sort/Enq" HeaderText="Sort/Enq" 
                            SortExpression="Item Code" >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Dated" HeaderText="Dated" ReadOnly="True" 
                            SortExpression="Dated" >
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Shades" HeaderText="Shades" ReadOnly="True" 
                            SortExpression="Shades" >
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Total Quantity" HeaderText="Total Quantity" 
                            ReadOnly="True" SortExpression="Total Quantity" >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UOM" HeaderText="UOM" SortExpression="UOM" >
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DnV Cost AWtd." HeaderText="DnV Cost" 
                            ReadOnly="True" SortExpression="DnV Cost AWtd." >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Sale Price" HeaderText="Sale Price" 
                            SortExpression="Sale Price" >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Margin %" HeaderText="Margin %" 
                            SortExpression="Margin %" >
                        <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Pref Margin %" HeaderText="Pref Margin %" 
                            ReadOnly="True" SortExpression="Pref Margin %" >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Net Margin %" HeaderText="Net Margin %" 
                            SortExpression="Net Margin %" >
                        <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Pay Time" HeaderText="Pay Time" 
                            SortExpression="Pay Time" >
                        <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="GridHeader" Wrap="False" />
                    <RowStyle CssClass="GridItem" Wrap="False" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="jct_ops_get_team_quotations" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="User_Code" SessionField="EmpCode" Type="String" 
                            DefaultValue="" />
                        <asp:Parameter Name="status" Type="String" DefaultValue="QuotAuthLM" />
                    </SelectParameters>
                </asp:SqlDataSource>
                </div>
            </td>
        </tr>
        </table>
    <table style="width:100%;" class="tableback">        
        <tr>
            <td style="font-size: 10pt">
                Authorised Quotations</td>
        </tr>
        <tr>
            <td>
                <div id="AdjResultsDiv2"                    
                    style=" height: 200px; overflow: auto; width:950px;">
                <asp:GridView ID="grdAuthorisedQuotes" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="SqlDataSource3" 
                    EnableModelValidation="True" EmptyDataText="No Relevant Quotation is found.">
                    <AlternatingRowStyle CssClass="GridAI" Wrap="False" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False" Visible="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="cmdAuthorise1" runat="server" CausesValidation="False" 
                                    onclientclick="javascript:return confirm('Are you sure want to authorise?');" 
                                    Text="Authorise" CommandArgument='<%# Eval("Quotation No") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField DataTextField="Quotation No" HeaderText="Quotation No" 
                            NavigateUrl="~/OPS/Quotation_Main.aspx" 
                            DataNavigateUrlFields="Quotation No" 
                            DataNavigateUrlFormatString="Quotation_Main.aspx?quot={0}" />
                        <asp:TemplateField HeaderText="Validity" SortExpression="Validity">
                            <ItemTemplate>
                                <asp:Image ID="imgValidity1" runat="server" 
                                    ImageUrl='<%# Eval("Validity_Img") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Validity") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="P/L" SortExpression="P/L">
                            <ItemTemplate>
                                <asp:Image ID="imgPL1" runat="server" ImageUrl='<%# Eval("PL_Img") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("[P/L]") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Customer" HeaderText="Customer" 
                            SortExpression="Customer" >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Sale Person" HeaderText="Sale Person" 
                            SortExpression="Sale Person">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Item Type" HeaderText="Item Type" 
                            SortExpression="Item Type" >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Sort/Enq" HeaderText="Sort/Enq" 
                            SortExpression="Sort/Enq" >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Dated" HeaderText="Dated" ReadOnly="True" 
                            SortExpression="Dated" >
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Shades" HeaderText="Shades" ReadOnly="True" 
                            SortExpression="Shades" >
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Total Quantity" HeaderText="Total Quantity" 
                            ReadOnly="True" SortExpression="Total Quantity" >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UOM" HeaderText="UOM" SortExpression="UOM" >
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DnV Cost AWtd." HeaderText="DnV Cost" 
                            ReadOnly="True" SortExpression="DnV Cost AWtd." >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Sale Price" HeaderText="Sale Price" 
                            SortExpression="Sale Price" >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Margin %" HeaderText="Margin %" 
                            SortExpression="Margin %" >
                        <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Pref Margin %" HeaderText="Pref Margin %" 
                            ReadOnly="True" SortExpression="Pref Margin %" >
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Net Margin %" HeaderText="Net Margin %" 
                            SortExpression="Net Margin %" >
                        <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Pay Time" HeaderText="Pay Time" 
                            SortExpression="Pay Time" >
                        <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="GridHeader" Wrap="False" />
                    <RowStyle CssClass="GridItem" Wrap="False" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="jct_ops_get_team_quotations" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="User_Code" SessionField="EmpCode" Type="String" 
                            DefaultValue="" />
                        <asp:Parameter Name="status" Type="String" DefaultValue="QuotAuth" />
                    </SelectParameters>
                </asp:SqlDataSource>
                </div>
            </td>
        </tr>
        </table>
</asp:Content>

