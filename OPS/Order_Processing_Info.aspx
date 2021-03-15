<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="Order_Processing_Info.aspx.vb" Inherits="OPS_Order_Processing_Info" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Order processing Info</td>
        </tr>
        <tr>
            <td class="labelcells">
                Month Year</td>
            <td style="width: 8px">
                <asp:DropDownList ID="ddlOrderScheduling" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Sale Person</td>
            <td>
                <asp:DropDownList ID="ddlSalesPerson" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Customer</td>
            <td style="width: 8px">
                
                        <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" 
                            CssClass="textbox"  Width="200px" ToolTip="Please give Customer Code or Select Customer from the List " ></asp:TextBox>
  
                    <div id="divwidth" style="display:none;">   
                        <cc1:AutoCompleteExtender ID="txtCustomer_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1" 
                            ServiceMethod="OPS_Customer"   CompletionListCssClass="AutoExtender" 
                            ServicePath="~/WebService.asmx" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList"
                            TargetControlID="txtCustomer">
                        </cc1:AutoCompleteExtender>
                        </div>
            </td>
            <td>
                Plant</td>
            <td>
                <asp:DropDownList ID="ddlPlant" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>BLENDED</asp:ListItem>
                    <asp:ListItem>COTTON</asp:ListItem>
                    <asp:ListItem>POLYESTER</asp:ListItem>
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc">Fetch</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="400px" ScrollBars="Both" 
                    Width="95%">
                    <%--<asp:GridView ID="GridView1" runat="server" Width="100%" 
                    AutoGenerateColumns="False" EnableModelValidation="True">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkSelect" runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" />
                            <asp:BoundField DataField="SalePerson" HeaderText="SalePerson" />
                            <asp:BoundField DataField="OrderNo" HeaderText="OrderNo" />
                            <asp:BoundField DataField="Item" HeaderText="Item" />
                            <asp:BoundField DataField="LineNo" HeaderText="LineNo" />
                            <asp:BoundField DataField="Blend" HeaderText="Blend" />
                            <asp:BoundField DataField="OrderQty" HeaderText="OrderQty" />
                            <asp:BoundField DataField="OrderReqDate" HeaderText="OrderReqDate" />
                            <asp:BoundField DataField="PlannedQty" HeaderText="WeavedQty" />
                            <asp:BoundField DataField="IssuedMeters" HeaderText="IssuedMeters" />
                            <asp:TemplateField HeaderText="DyeingQty">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDyeingMtrs" runat="server" CssClass="textbox" MaxLength="5" 
                                    Width="50px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtDyeingMtrs_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" FilterType="Numbers" 
                                    TargetControlID="txtDyeingMtrs">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ReqDyeingDate">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtReqDyeingDate" runat="server" CssClass="textbox" 
                                    Width="60px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtReqDyeingDate_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtReqDyeingDate">
                                    </cc1:CalendarExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FinishedQty">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFinishMtrs" runat="server" CssClass="textbox" MaxLength="5" 
                                    Width="50px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtFinishMtrs_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" FilterType="Numbers" 
                                    TargetControlID="txtFinishMtrs">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ReqFinishedDate">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtReqFinishDate" runat="server" CssClass="textbox" 
                                    Width="60px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtReqFinishDate_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtReqFinishDate">
                                    </cc1:CalendarExtender>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>--%>







                    <asp:GridView ID="GridView1" runat="server" Width="100%" 
                    AutoGenerateColumns="True" EnableModelValidation="True">
                        <AlternatingRowStyle CssClass="GridAI" />     
                        <HeaderStyle CssClass="GridHeader" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>



        </table>
     <table style="width:100%;">



        <tr>
        <td colspan="2" class="LeftMenuItemHover" >
            Add On Details</td>
        </tr>



        <tr>
        <td class="HoverMenu" style="width:125px" >
            <asp:LinkButton ID="LinkButton2" runat="server" >O.P.I</asp:LinkButton>
           
        </td>
        <td class="HoverMenu" style="width:125px">
            <asp:LinkButton ID="LinkButton7" runat="server">Old Recipe Used</asp:LinkButton>
        </td>
        </tr>
        <tr>
        <td class="HoverMenu" style="width:125px" >
            <asp:LinkButton ID="LinkButton3" runat="server">Lab Dip Recipe</asp:LinkButton>
           
        </td>
        <td class="HoverMenu" style="width:150px" >
            <asp:LinkButton ID="LinkButton8" runat="server">Hold Detail</asp:LinkButton>
        </td>
        </tr>
        <tr>
        <td class="HoverMenu"  style="width:150px">
            <asp:LinkButton ID="LinkButton4" runat="server">Fabric Construction</asp:LinkButton>           
        </td>
        <td class="HoverMenu" style="width:150px" >
            <asp:LinkButton ID="LinkButton9" runat="server">Complaints By Customer</asp:LinkButton>
        </td>
        </tr>

        <tr>
        <td class="HoverMenu"  style="width:150px">
            <asp:LinkButton ID="LinkButton5" runat="server">QC Detail</asp:LinkButton>
        </td>
        <td class="HoverMenu"  style="width:150px">
            <asp:LinkButton ID="LinkButton6" runat="server">Grading/Detail</asp:LinkButton>
        
        </td>
        </tr>
        <tr>
        <td class="HoverMenu"  style="width:150px">
            <asp:LinkButton ID="cmdCustSpecs" runat="server">Cust. Quality Specification</asp:LinkButton>
        </td>
        <td class="HoverMenu"  style="width:150px">
            &nbsp;</td>
        </tr>
        <tr>
        <td class="HeaderStyle" >
            &nbsp;</td>
        <td class="HeaderStyle" >
            &nbsp;</td>
        </tr>



        <tr>
        <td class="labelcells_s" >
            &nbsp;</td>
        <td class="textcells_s" >
            &nbsp;</td>
        </tr>

        </table>
</asp:Content>

