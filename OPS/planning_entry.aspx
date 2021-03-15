<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="planning_entry.aspx.vb" Inherits="planning_entry" title="Untitled Page" %>
<%@ Register Src="../FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server"></script>


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    
    <table style="width: 100%;">
        <tr>
            <td colspan="4" class ="tableheader" >
                Final Plan
            </td>
        </tr>
        
        <tr>
            <td >
                <asp:Label ID="label19" runat="server" CssClass="labelcells" Text="Action"></asp:Label>
            </td>
            <td class="textcells" style="width: 75px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlaction" runat="server" 
    CssClass="combobox" AutoPostBack="True">
                            <asp:ListItem>Generate Plan</asp:ListItem>
                            <asp:ListItem Value="Plan Modify ">Plan Modify</asp:ListItem>
                            <asp:ListItem>UnFreeze Plan</asp:ListItem>
                            <asp:ListItem>Freeze Plan </asp:ListItem>
                            <asp:ListItem>New Sort</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="style17">
                &nbsp;</td>
            <td class="style18" style="width: 368px">
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="labelcells" 
                    NavigateUrl="~/ProductionPlanning/final_plan_help.pdf">Help</asp:HyperLink>
            </td>
        </tr>
        
        <tr>
            <td class="style15" style="height: 22px">
                <asp:Label ID="Label21" runat="server" CssClass="labelcells" 
                    Text="Plant"></asp:Label>
            </td>
            <td class="style16" style="width: 75px; height: 22px;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddllocation" runat="server" AutoPostBack="True" 
                    CssClass="combobox" 
                    onselectedindexchanged="ddllocation_SelectedIndexChanged">
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="style17" style="height: 22px">
                <asp:Label ID="label1" runat="server" CssClass="labelcells" Text="YearMonth"></asp:Label>
            </td>
            <td class="style18" style="width: 368px; height: 22px;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlyrmth" runat="server" AutoPostBack="True" 
                    CssClass="combobox">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        
        <tr>
            <td class="style12">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="Label24" runat="server" CssClass="labelcells" 
                    Text="Revision No"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="style13" style="width: 75px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlrevno1" runat="server" AutoPostBack="True" 
                            CssClass="combobox">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="style14">
                <asp:Label ID="Label23" runat="server" CssClass="labelcells" 
                    Text="Revision Comments"></asp:Label>
            </td>
            <td style="width: 368px">

                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlremarks" runat="server" AutoPostBack="True" 
                                    CssClass="combobox">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>

            </td>
        </tr>
        
        <tr>
            <td class="style12" style="height: 20px">
                <asp:Label ID="Label20" runat="server" CssClass="labelcells" Text="  Days"></asp:Label>
            </td>
            <td class="style13" style="width: 75px; height: 20px;">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddldays" runat="server" AutoPostBack="True">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                            <asp:ListItem>24</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                            <asp:ListItem>26</asp:ListItem>
                            <asp:ListItem>27</asp:ListItem>
                            <asp:ListItem>28</asp:ListItem>
                            <asp:ListItem>29</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>31</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="style14" style="height: 20px">
                <asp:Label ID="Label22" runat="server" CssClass="labelcells" Text="Cot/Syn"></asp:Label>
            </td>
            <td style="width: 368px; height: 20px;">
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlclthtype" runat="server" 
                    CssClass="combobox">
                                </asp:DropDownList><uc1:FlashMessage id="FMsg" runat="server" EnableTheming="true" EnableViewState="true" FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" Visible="true"></uc1:FlashMessage>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
        </tr>
        
        <tr class="buttonbackbar">
            <td colspan="4" >
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="cmdFetch" runat="server" CssClass="buttonc" 
                    onclick="cmdFetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="cmdUpdate" runat="server" CssClass="buttonc" 
                            onclick="cmdUpdate_Click">Save</asp:LinkButton>
                        <asp:LinkButton ID="cmdrevision" runat="server" CssClass="buttonc">Revision 
                        No</asp:LinkButton>
                        
                        <asp:LinkButton ID="cmdclose" runat="server" CssClass="buttonc" 
                            onclick="cmdclose_Click">Close</asp:LinkButton>
                        <asp:LinkButton ID="cmdfreeze" runat="server" CssClass="buttonc" 
                            onclick="cmdfreeze_Click">Freeze</asp:LinkButton>
                        <asp:LinkButton ID="cmdunfreeze" runat="server" CssClass="buttonc" 
                            onclick="cmdunfreeze_Click">Unfreeze</asp:LinkButton>
                        <asp:LinkButton ID="cmdnewsort" runat="server" CssClass="buttonc" 
                            onclick="cmdnewsort_Click">NewSort</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
           
        </tr>
                
    </table>
    <table style="width: 100%;">
        <tr>
            <td>
          <!--   <div  id = "AdjResultsDiv" 
                        style=" width: 100%; height:300px; left: -1px; top: 0px;"> 
                         </div> -->
               <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
            
                            <asp:GridView ID="grdGrid" runat="server" 
                                AutoGenerateColumns="False" CellPadding="0" EnableTheming="True" 
                                OnSelectedIndexChanged="grdGrid_SelectedIndexChanged" 
                                  PageSize="15" Width="100%" AllowPaging="True" 
                                onrowdatabound="grdgrid_RowDataBound" CssClass="GridView" Visible="False" >
                                <Columns>
                                   <asp:TemplateField HeaderText="Update">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="Update" runat="server" AutoPostBack="True" 
                                                 Text="" oncheckedchanged="Update_CheckedChanged2" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Update" runat="server" 
                                                oncheckedchanged="Update_CheckedChanged" CssClass="combobox" />
                                            <br />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="sort_no" HeaderText="Sort_no" ReadOnly="True" />
                                    <asp:TemplateField HeaderText="Shed">
                                        <ItemTemplate>
                                            <asp:TextBox ID="shed" runat="server" CssClass="textbox" Columns="8"
                                                Text='<%# eval("shed") %>' ontextchanged="shed_TextChanged"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" 
                                                TargetControlID="shed" ValidChars="A,R,S,W,C">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Efficiency">
                                        <ItemTemplate>
                                            <asp:TextBox ID="eff" runat="server" CssClass="textbox"  Columns="8"
                                                Text='<%# eval("eff") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RPM">
                                        <ItemTemplate>
                                            <asp:TextBox ID="rpm" runat="server" CssClass="textbox" Columns="8"
                                                Text='<%# eval("rpm") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="qty" HeaderText="Quantity" />
                                    <asp:TemplateField HeaderText="Planned Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="planned_qty" runat="server" CssClass="textbox" Columns="8"
                                                Text='<%# eval ("planned_qty") %>' ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="previous_qty" 
                                        HeaderText="Prev.Pending Qty" />
                                    <asp:TemplateField HeaderText="Sizing Length">
                                        <ItemTemplate>
                                            <asp:TextBox ID="sizing" runat="server" CssClass="textbox"  Columns="8"
                                                Text='<%# eval ("sizing") %>' ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="looms_required" HeaderText="Looms / Day" />
                                    <asp:TemplateField HeaderText="Working Looms">
                                        <ItemTemplate>
                                            <asp:TextBox ID="workinglooms" runat="server" CssClass="textbox" Columns="8"
                                                Text='<%# eval ("workinglooms") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle CssClass="EditRowStyle" />
                                <EmptyDataTemplate>
                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="No Data Present. " 
                                        Width="160px"></asp:Label>
                                </EmptyDataTemplate>
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="RowStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                                <HeaderStyle CssClass="gridheader" />
                            </asp:GridView>
                            </ContentTemplate>
                </asp:UpdatePanel>
               
                        </td>
           
        </tr>
        
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NomalText">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                 <asp:Panel ID="Panel1" CssClass="panelbg" runat="server" ScrollBars="Auto" 
                        Width="100%">
                    <asp:GridView ID="GridView1" runat="server" CssClass="GridView" Width="100%" 
                    AutoGenerateColumns="False" EnableModelValidation="True" AllowPaging="True">
                    <HeaderStyle CssClass="gridheader" />
                        <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="RowStyle" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <Columns>
                                   <asp:TemplateField HeaderText="Update">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="Update" runat="server" AutoPostBack="True" 
                                                 Text="" oncheckedchanged="Update_CheckedChanged2" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Update" runat="server" 
                                                oncheckedchanged="Update_CheckedChanged" CssClass="combobox" />
                                            <br />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Order No">
                                       <ItemTemplate>
                                           <asp:Label ID="Label25" runat="server" Text='<%# Eval("OrderNo") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Line Item">
                                       <ItemTemplate>
                                           <asp:Label ID="Label26" runat="server" Text='<%# Eval("LineItem") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Sort">
                                       <ItemTemplate>
                                           <asp:Label ID="Label27" runat="server" Text='<%# Eval("Sort") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Req. Date">
                                       <ItemTemplate>
                                           <asp:Label ID="Label28" runat="server" Text='<%# Eval("ReqDt") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Order Qty.">
                                       <ItemTemplate>
                                           <asp:Label ID="Label29" runat="server" Text='<%# Eval("OrderQty") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Plan Qty.">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtPlanQty" runat="server" Columns="10" CssClass="textbox" 
                                               Text='<%# Eval("PlanQty") %>'></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Sizing Length">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtSizingLength" runat="server" Columns="10" 
                                               CssClass="textbox" Text='<%# Eval("SizingLength") %>'></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Shed">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtShed" runat="server" Columns="6" CssClass="textbox"></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="RPM">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtRPM" runat="server" Columns="6" CssClass="textbox"></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Efficiency">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtEfficiency" runat="server" Columns="10" CssClass="textbox"></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Loom Allotment">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtLoomAllot" runat="server" Columns="10" CssClass="textbox"></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Wvg. Completion Dt.">
                                       <ItemTemplate>
                                           <asp:Label ID="lblWvgCompletionDt" runat="server" 
                                               Text='<%# Eval("WvgCompletionDt") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </asp:Panel>
                </ContentTemplate>
                </asp:UpdatePanel>
               
                
            </td>
        </tr>
        <tr>
            <td class="NomalText">
                &nbsp;</td>
        </tr>
        </table>
</asp:Content>


