<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="classimate.aspx.cs" Inherits="OPS_classimate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="uc1" TagName="FMsg" Src="~/FlashMessage.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%; height: 219px;">
        <tr>
            <td colspan="4" class="tableheader">
               
                <asp:Label ID="lblFabricParticular" runat="server" Text="FABRICS PARTICULARS"></asp:Label>
             
            </td>
        </tr>
        <tr>
            <td  class="NormalText" style="width: 119px">
                <asp:Label ID="Label1" runat="server" Text="SEARCH SORT/ITEM"></asp:Label>
            </td>
            <td class="NormalText" style="width: 211px">
                <asp:TextBox ID="txtSearchItem" runat="server" CssClass="textbox" 
                    Width="237px" ToolTip="Type in minimum of 3 characters to search an Item" 
                    ontextchanged="txtSearchItem_TextChanged" AutoPostBack="True"></asp:TextBox>

               
                <cc1:AutoCompleteExtender ID="txtSearchItem_AutoCompleteExtender" 
                    runat="server" ServiceMethod="OPS_Fabric_Items" ServicePath="~/WebService.asmx" 
                    TargetControlID="txtSearchItem" CompletionInterval="100" 
                    MinimumPrefixLength="1">
                </cc1:AutoCompleteExtender>

               
            </td>
            <td  class="NormalText" style="width: 85px">
             
                <asp:Label ID="lblPPi" runat="server" Text="PPI"></asp:Label>
             
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtPPI" runat="server" CssClass="textbox" ToolTip="PPI"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td  class="NormalText" style="width: 119px">
                <asp:Label ID="lblblend" runat="server" Text="BLEND "></asp:Label>
            </td>
            <td  class="NormalText" style="width: 211px">
                <asp:TextBox ID="txtBlend" runat="server" CssClass="textbox" Width="203px" 
                    ToolTip="BLEND "></asp:TextBox>
            </td>
            <td  class="NormalText" style="width: 85px">
                <asp:Label ID="lblWeight" runat="server" Text="WEIGHT(GSM)"></asp:Label>
            </td>
            <td  class="NormalText">
                <asp:TextBox ID="txtWeight" runat="server" CssClass="textbox" ToolTip="WEIGHT "></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  class="NormalText" style="width: 119px">
                <asp:Label ID="lblEpi" runat="server" Text="EPI"></asp:Label>
            </td>
            <td class="NormalText" style="width: 211px">
                <asp:TextBox ID="txtEPI" runat="server" CssClass="textbox" ToolTip="PPI"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 85px">
                <asp:Label ID="lblWeave" runat="server" Text="WEAVE"></asp:Label>
            </td>
            <td  class="NormalText">
                <asp:TextBox ID="txtWeave" runat="server" CssClass="textbox" ToolTip="WEAVE"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 119px">
                <asp:Label ID="lblWidth" runat="server" Text="WIDTH"></asp:Label>
            </td>
            <td  class="NormalText" style="width: 211px">
                <asp:TextBox ID="txtWidth" runat="server" CssClass="textbox" ToolTip="WIDTH"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 85px">
                &nbsp;</td>
            <td class="NormalText">
                <br />
            </td>
        </tr>
        <tr>
            <td  class="NormalText" colspan="2">
            
                  
                <uc1:FMsg  ID="lblErrMachineNo" runat="server" />
             
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
             
            </td>
            <td class="NormalText" colspan="2">
                <asp:Label ID="lblidnew" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  colspan="4">
                <asp:GridView ID="grdDetails" runat="server" 
                    EmptyDataText="NO RECORDS FOUND !!!!" Width="100%">
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="GridItem" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="NormalText">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:test1 %>" 
                    SelectCommand="jct_ops_get_count_detail_1" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtSearchItem" Name="sort" PropertyName="Text" 
                            Type="Decimal" />
                        <asp:ControlParameter ControlID="txtSearchItem" Name="enq" PropertyName="Text" 
                            Type="Decimal" />
                    </SelectParameters>
                </asp:SqlDataSource>
            
            </td>
        </tr>
        <tr>
            <td colspan="4" class="NormalText">
                <asp:GridView ID="grdFileUploadDetails" runat="server" 
                    EmptyDataText="NO FILE ATTACHED AGAINST THIS ITEM CODE" Width="100%" 
                    AutoGenerateColumns="False" EnableModelValidation="True" 
                    onrowcommand="grdFileUploadDetails_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="ItemCode">
                            <ItemTemplate>
                                <asp:Label ID="Label16" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DocType">
                            <ItemTemplate>
                                <asp:Label ID="Label17" runat="server" Text='<%# Eval("DocType") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DocNo.">
                            <ItemTemplate>
                                <asp:Label ID="Label18" runat="server" Text='<%# Eval("DocNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks">
                            <ItemTemplate>
                                <asp:Label ID="Label19" runat="server" Text='<%# Eval("Remark") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="File Name">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" 
                                    CommandArgument='<%# Eval("UploadFile") %>' CommandName="Download" 
                                    Text='<%# Eval("UploadFile") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="GridItem" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="NormalText">
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:test1 %>" 
                    SelectCommand="jct_ops_get_fabric_param_fileUpload_View" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtSearchItem" Name="ItemCode" 
                            PropertyName="Text" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="NormalText">
                <asp:GridView ID="grdDetails2" runat="server" Width="100%" 
                    EmptyDataText="NO  RECORD FOUND  !!!!!!!!">
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="GridItem" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="NormalText">
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:test1 %>" 
                    SelectCommand="jct_ops_fab_detail" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtSearchItem" Name="Item_Code" 
                            PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
              
            </td>
        </tr>
        
    </table>
</asp:Content>

