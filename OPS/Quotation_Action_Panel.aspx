<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="Quotation_Action_Panel.aspx.vb" Inherits="OPS_Quotation_Action_Panel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Quotation Action Panel</td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td>
                <div id="AdjResultsDiv1" style="height: 200px; overflow: scroll; width: 1050px; top: 0px;
                    left: 0px;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                                SelectCommand="jct_ops_get_team_quotations" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:SessionParameter DefaultValue="" Name="User_Code" SessionField="EmpCode" Type="String" />
                                    <asp:Parameter DefaultValue="QuotOpen" Name="status" Type="String" />
                                    <asp:Parameter DefaultValue="MktAuth" Name="Sch_Auth_Status" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:GridView ID="grdUnauthorisedQuotes" runat="server" AutoGenerateColumns="False"
                                DataSourceID="SqlDataSource2" EmptyDataText="No Relevant Quotation is found."
                                EnableModelValidation="True" DataKeyNames="Quotation No">
                                <AlternatingRowStyle CssClass="GridAI" Wrap="False" />
                                <Columns>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ibtAuthorise" runat="server" AlternateText="Authorise" CommandArgument='<%# Eval("Quotation No") %>'
                                                CommandName="Authorise" ImageUrl="~/OPS/Image/Authorise.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ibtReject" runat="server" AlternateText="Reject Quotation" CommandArgument='<%# Eval("Quotation No") %>'
                                                CommandName="Reject" Height="17px" ImageUrl="~/OPS/Image/Reject.png" ValidationGroup="a" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False" Visible="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="cmdAuthorise0" runat="server" CausesValidation="False" CommandArgument='<%# Eval("Quotation No") %>'
                                                OnClientClick="javascript:return confirm('Are you sure want to authorise?');"
                                                Text="Authorise"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks" Visible="False">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRemarks" runat="server" Columns="30" CssClass="textbox" ValidationGroup="a"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:HyperLinkField DataNavigateUrlFields="Quotation No" DataNavigateUrlFormatString="Quotation_Main.aspx?quot={0}"
                                        DataTextField="Quotation No" HeaderText="Quotation No" NavigateUrl="~/OPS/Quotation_Main.aspx"
                                        Target="_blank" />
                                    <asp:TemplateField HeaderText="Validity" SortExpression="Validity" Visible="False">
                                        <ItemTemplate>
                                            <asp:Image ID="imgValidity0" runat="server" ImageUrl='<%# Eval("Validity_Img") %>' />
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
                                    <asp:BoundField DataField="Customer" HeaderText="Customer" SortExpression="Customer">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sale Person" HeaderText="Sale Person" SortExpression="Sale Person">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Item Type" HeaderText="Item Type" SortExpression="Item Type">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sort/Enq" HeaderText="Sort/Enq" SortExpression="Item Code">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Dated" HeaderText="Dated" ReadOnly="True" SortExpression="Dated">
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Shades" HeaderText="Shades" ReadOnly="True" SortExpression="Shades">
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total Quantity" HeaderText="Total Quantity" ReadOnly="True"
                                        SortExpression="Total Quantity">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UOM" HeaderText="UOM" SortExpression="UOM">
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DnV Cost AWtd." HeaderText="DnV Cost" ReadOnly="True"
                                        SortExpression="DnV Cost AWtd.">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sale Price" HeaderText="Sale Price" SortExpression="Sale Price">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Margin %" HeaderText="Margin %" SortExpression="Margin %">
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Pref Margin %" HeaderText="Pref Margin %" ReadOnly="True"
                                        SortExpression="Pref Margin %">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Net Margin %" HeaderText="Net Margin %" SortExpression="Net Margin %">
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Pay Time" HeaderText="Pay Time" SortExpression="Pay Time">
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" Wrap="False" />
                                <RowStyle CssClass="GridItem" Wrap="False" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="labelcells">
                Remarks
            </td>
            <td style="vertical-align: top">
                <asp:DropDownList ID="ddlRejectionReason" runat="server" CssClass="combobox" ValidationGroup="Reject"
                    Visible="False">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Low Margin</asp:ListItem>
                    <asp:ListItem>Shade Length</asp:ListItem>
                    <asp:ListItem>Dispatch Date</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtRejectionRemarks" runat="server" Columns="100" CssClass="textbox"
                    TextMode="MultiLine" ValidationGroup="Reject"></asp:TextBox>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:LinkButton ID="cmdDevApprove" runat="server" CssClass="buttonc" ValidationGroup="Reject">Approve Devp</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="cmdReject" runat="server" CssClass="buttonc" ValidationGroup="Reject">Reject Quot</asp:LinkButton>
                
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Current Dispatch Detail for Quotation #
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:Label ID="lblQuotationNo" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdDispatchDetail" runat="server" AutoGenerateColumns="False" EmptyDataText="No Dispatch Schedule for this Quotation is found."
                            EnableModelValidation="True" Width="100%" DataSourceID="SqlDataSource3">
                            <AlternatingRowStyle CssClass="GridAI" Wrap="False" />
                            <Columns>
                            <%-- <asp:BoundField  DataField="Target_Date" HeaderText="Greige Date(M-D-Y)" DataFormatString="{0:MM/dd/yyyy}" />
                             <asp:BoundField DataField="Remarks" HeaderText="Remarks" />--%>
                              
                                <asp:BoundField DataField="Shade" HeaderText="Shade" SortExpression="Pay Time">
                                    <HeaderStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                <asp:BoundField DataField="UOM" HeaderText="UOM" />
                                <asp:BoundField DataField="Dispatch_Date" HeaderText="Quoted Dispatch Date" />
                                <asp:BoundField DataField="Remark" HeaderText="Remark" />
                                <asp:TemplateField HeaderText="Advised Dispatch Date MDY">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtAdvisedDate" runat="server" CssClass="textbox" Text='<%# Eval("Advised_Date") %>'
                                            ValidationGroup="a"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtAdvisedDate_CalendarExtender" runat="server" TargetControlID="txtAdvisedDate">
                                        </cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAdvisedDate"
                                            ErrorMessage="Please Specify Advised Dispatch Date"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField  DataField="Target_Date" HeaderText="Greige Date(M-D-Y)" DataFormatString="{0:MM/dd/yyyy}" />
                             <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                               <asp:BoundField DataField="Line_no" HeaderText="Line No" />
                             <asp:BoundField DataField="GreighQty" HeaderText="GreighQty" />
                                <asp:TemplateField HeaderText="Remark">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Text='<%# Eval("Remark") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Country" HeaderText="Country" />
                                <asp:BoundField DataField="City" HeaderText="City" />
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" Wrap="False" />
                            <RowStyle CssClass="GridItem" Wrap="False" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                            SelectCommand="jct_ops_get_quote_dispatch_sch_manish" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="grdUnauthorisedQuotes" Name="Quotation_No" PropertyName="SelectedValue"
                                    Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>


           <tr> <td></td></tr>
        <tr>
          <td>

           <%-- <asp:UpdatePanel ID="UpdatePanel400" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridAuth" runat="server" AutoGenerateColumns="False" EmptyDataText="This Quotation Number Final Planning Date is not Authorized."
                            EnableModelValidation="True" Width="100%" DataSourceID="SqlDataSource4">
                            <AlternatingRowStyle CssClass="GridAI" Wrap="False" />
                       
                            <Columns>
                                <asp:BoundField DataField="UserName" HeaderText="UserName" 
                                    SortExpression="UserName" />
                                <asp:BoundField DataField="QuotationNO" HeaderText="QuotationNO" 
                                    SortExpression="QuotationNO" />
                                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                                <asp:BoundField DataField="Target Date" HeaderText="Target Date" 
                                    SortExpression="Target Date" />
                                <asp:BoundField DataField="Remarks" HeaderText="Remarks" 
                                    SortExpression="Remarks" />
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" Wrap="False" />
                            <RowStyle CssClass="GridItem" Wrap="False" />

                            </asp:GridView>
                              <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                            SelectCommand="jct_ops_Quotation_Internal_planningAuth" SelectCommandType="StoredProcedure">
                                
                                  <SelectParameters>
                                      <asp:ControlParameter ControlID="lblQuotationNo" 
                                          Name="Quotation_No" PropertyName="Text" Type="String" />
                                  </SelectParameters>
                                
                        </asp:SqlDataSource>
                            </ContentTemplate>

                   </asp:UpdatePanel>--%>
          
          </td>
        
        </tr>

        


        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblMessage" runat="server" CssClass="errormsg"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmdAdvise" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="cmdApprove" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="cmdApprove" runat="server" CssClass="buttonc" CausesValidation="False">Approve Quot</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="cmdAdvise" runat="server" CssClass="buttonc" ValidationGroup="a">Advise Date</asp:LinkButton>&nbsp;</td>
        </tr>
        <tr><td></td></tr>

        <tr>
        <td>
            <div id="Div1" style="height: 200px; overflow: scroll; width: 1050px; top: 0px;
                    left: 0px;">
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" RenderMode="Inline">
               <ContentTemplate>
               
                                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="Quotation_No" 
                        EmptyDataText="No Relevant Quotation is found." EnableModelValidation="True" Width="1050px" 
                                         AllowPaging="True">
                        <AlternatingRowStyle CssClass="GridAI" Wrap="False" />
                        <Columns>
                       <%--  <asp:HyperLinkField DataNavigateUrlFields="Quotation_No" 
                                DataNavigateUrlFormatString="Quotation_Main.aspx?quot={0}" 
                                DataTextField="Quotation_No" HeaderText="Quotation No" NavigateUrl="#" />--%>

                                 <asp:HyperLinkField DataNavigateUrlFields="Quotation_No" DataNavigateUrlFormatString="Quotation_Main.aspx?quot={0}"
                                        DataTextField="Quotation_No" HeaderText="Quotation No" NavigateUrl="~/OPS/Quotation_Main.aspx"
                                        Target="_blank" />

                                 <asp:BoundField DataField="Greige Date" HeaderText="Greige Date(M-D-Y)" DataFormatString="{0:MM/dd/yyyy}"
                                SortExpression="Greige Date">
                                <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" /></asp:BoundField>


                                   <asp:BoundField DataField="Greige Remarks" HeaderText="Greige Remarks" 
                                SortExpression="Greige Remarks">    <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" /></asp:BoundField>
                            <asp:BoundField DataField="Greige Created By" HeaderText="Greige Created By" 
                                SortExpression="Greige Created By">    <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" /></asp:BoundField>
                               <asp:BoundField DataField="Created Date" HeaderText="Created Date" 
                                SortExpression="Created Date">    <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" /></asp:BoundField>
                              <%--  <asp:BoundField DataField="Finish Date" HeaderText="Finish Date(M-D-Y)" DataFormatString="{0:MM/dd/yyyy}"
                                SortExpression="Finish Date">    <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" /></asp:BoundField>
                                 <asp:BoundField DataField="Finish Remarks" HeaderText="Finish Remarks" 
                                SortExpression="Finish Remarks">    <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" /></asp:BoundField>--%>

                        </Columns>
                         <HeaderStyle CssClass="GridHeader" Wrap="False" />
                        <RowStyle CssClass="GridItem" Wrap="False" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                        </asp:GridView>



               </ContentTemplate>
               </asp:UpdatePanel>
               </div>
        </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Attached Documents:</td>
            <td>
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        </table>
    <table style="width: 100%;">
        <tr>
            <td>
            
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        
                        <asp:DataList ID="dlsRefDocs" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="6" RepeatDirection="Horizontal" Width="100%">
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" style="width: 64px">
                                    <tr>
                                        <td>
                                            <div style="margin: auto; width: 64px">
                                                <asp:ImageButton ID="ImageButton1" runat="server" AlternateText='<%# Eval("RefDocActFileName") %>' ImageUrl='<%# Eval("LogoImgPath") %>' Width="64px" Visible="False" />
                                                <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("LogoImgPath") %>' AlternateText='<%# Eval("RefDocActFileName") %>' Width="64px" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="NormalText" style="text-align: center">
                                            <%--<asp:LinkButton ID="lnkLink" runat="server" PostBackUrl='<%# Eval("RefDocFilePath") %>' Text='<%# Eval("RefDocActFileName") %>'></asp:LinkButton>--%>
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Eval("RefDocActFileName") %>' NavigateUrl='<%# Eval("RefDocFilePath") %>'></asp:HyperLink>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="jct_ops_get_ref_docs" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblQuotationNo" Name="DocNo" PropertyName="Text" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
