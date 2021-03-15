<%@ Page Title="" Language="C#" MasterPageFile="~/AssetMngmnt/MasterPage.master" AutoEventWireup="true" CodeFile="AssetFurnitureLocMapping.aspx.cs" Inherits="AssetMngmnt_AssetFurnitureLocMapping" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type = "text/javascript">
    function SetContextKey() {
        $find('<%=txtEmployee_AutoCompleteExtender.ClientID%>').set_contextKey($get("<%=ddlloc.ClientID %>").value);
    }
</script>

<script type="text/javascript">
    function ConfirmationBox(username) {

        var result = confirm('Are you sure you want to Unmap ' + username + '?');
        if (result) {

            return true;
        }
        else {
            return false;
        }
    }
</script>

  <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Employee Location 
                (Mapping / Unmapping)</td>


        </tr>
        <tr>
            <td class="NormalText" style="width: 115px">
                Location</td>


            <td class="NormalText" style="width: 115px">
                <%--               <asp:LinkButton ID="lnkaddrow" runat="server" CssClass="buttonc">AddRow</asp:LinkButton>--%>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <telerik:RadComboBox ID="ddlloc" Runat="server" AutoPostBack="True" 
                    CssClass="combobox" EnableVirtualScrolling="true" ExpandDirection="Down" 
                    Height="85" Visible="true" 
                    onselectedindexchanged="ddlloc_SelectedIndexChanged">
                </telerik:RadComboBox>
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>


            <td class="NormalText" style="width: 115px">
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                <asp:Label ID="lblid" runat="server" Text="ID" Visible="False" ></asp:Label>
                                </ContentTemplate>
            </asp:UpdatePanel>
            </td>


            <td class="NormalText">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                <asp:Label ID="lblSrnoID" runat="server" Visible="False" ></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
            </td>




        </tr>
        <tr>
            <td class="NormalText" style="width: 115px">
                Sublocation</td>

            <td class="NormalText" style="width: 115px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <telerik:RadComboBox ID="ddlSubloc" Runat="server" AutoPostBack="True" 
                    CssClass="combobox" DataTextField="location" DataValueField="location" 
                    EnableVirtualScrolling="true" ExpandDirection="Down" Height="85" 
                        Visible="true" onselectedindexchanged="ddlSubloc_SelectedIndexChanged">
                </telerik:RadComboBox>

                <asp:RequiredFieldValidator ID="ReqvalSublocation" runat="server" 
                ControlToValidate="ddlSubloc" ErrorMessage="*" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>

            <td class="NormalText" style="width: 115px">
            </td>

            <td class="NormalText">




            </td>



        </tr>
        
        <tr>
            <td class="NormalText">
                Effective From</td>

            <td class="NormalText">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                <asp:TextBox ID="txtefffrom" runat="server" Columns="12" CssClass="textbox" 
                    MaxLength="12"  Width="70px"></asp:TextBox>               
             <cc1:CalendarExtender ID="CalendarExtender1"   Enabled="True" TargetControlID="txtefffrom" runat="server">
            </cc1:CalendarExtender>
             <cc1:MaskedEditExtender ID="MEE1" runat="server" Mask="99/99/9999" 
                    MaskType="Date" TargetControlID="txtefffrom">
                </cc1:MaskedEditExtender>

                                    </ContentTemplate>
                                     </asp:UpdatePanel>
                                                   <cc1:MaskedEditValidator ID="MEV1" runat="server" ControlExtender="MEE1" 
                    ControlToValidate="txtefffrom" Display="Dynamic" EmptyValueMessage="ENTER DATE!!" 
                    ErrorMessage="MEV1" InvalidValueMessage="INVALID DATE" 
                    TooltipMessage="MM/DD/YYYY" ValidationGroup="mandatory" 
                    IsValidEmpty="False"></cc1:MaskedEditValidator>
           
            </td>


            <td class="NormalText" style="width: 115px">
              <%--  Effective To--%></td>

            <td class="NormalText">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                        <%--<asp:TextBox ID="txtEffTo" runat="server" Columns="12" CssClass="textbox" 
                            MaxLength="12"  Width="70px"></asp:TextBox>--%>
<%--        <cc1:CalendarExtender ID="CalendarExtender2"   Enabled="True" TargetControlID="txtEffTo" runat="server">
            </cc1:CalendarExtender>
                            <cc1:MaskedEditExtender ID="MEE2" runat="server" Mask="99/99/9999" 
                    MaskType="Date" TargetControlID="txtEffTo">
                </cc1:MaskedEditExtender>--%>

                                    </ContentTemplate>
            </asp:UpdatePanel>
                                            <%--<cc1:MaskedEditValidator ID="MEV2" runat="server" ControlExtender="MEE2" 
                    ControlToValidate="txtEffTo" Display="Dynamic" EmptyValueMessage="ENTER DATE!!" 
                    ErrorMessage="MEV2" InvalidValueMessage="INVALID DATE" 
                    TooltipMessage="MM/DD/YYYY" ValidationGroup="mandatory" IsValidEmpty="False"></cc1:MaskedEditValidator>--%>
            </td>            
        </tr>
        
        <tr>
            <td class="NormalText" style="width: 115px">
                <asp:Label ID="lblLocation" runat="server" Text="EmployeeName" ></asp:Label>
            </td>

            <td class="NormalText" style="width: 115px">

                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                <asp:TextBox ID="txtEmpCode" runat="server" CausesValidation="True" 
                    CssClass="textbox" onkeyup="SetContextKey()" 
                    ValidationGroup="mandatory" ></asp:TextBox>


                                                         <asp:RequiredFieldValidator ID="ReqtxtEmpCode" runat="server" 
                ControlToValidate="txtEmpCode" ErrorMessage="*" ValidationGroup="mandatory"></asp:RequiredFieldValidator>


                    <div id="divwidth" style="display:none;">
                       <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" 
                          CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                          CompletionListElementID="divwidth" 
                          CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                          CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" 
                          MinimumPrefixLength="1" ServiceMethod="GetEmployeeDepartment_test_aslam" 
                          ServicePath="~/WebService.asmx" TargetControlID="txtEmpCode" 
                          UseContextKey="True">
                      </cc1:AutoCompleteExtender>


                </div>
                                                      </ContentTemplate>
            </asp:UpdatePanel>

            </td>

            <td class="NormalText" style="width: 115px">
                &nbsp;</td>

            <td class="NormalText">
               </td>
        </tr>
        
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <progresstemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </progresstemplate>
                </asp:UpdateProgress>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="6">
                <asp:UpdatePanel ID="Updbuttons" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkApply" runat="server" CssClass="buttonc" 
                             ValidationGroup="mandatory" onclick="lnkApply_Click">Map</asp:LinkButton>
                        

                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" onclick="lnkReset_Click" 
                            >Reset</asp:LinkButton>
                       <asp:LinkButton ID="lnkDel" runat="server" CssClass="buttonc" 
                            onclick="lnkDel_Click" ValidationGroup="mandatory" Visible="False">Delete</asp:LinkButton>
<%--                        <asp:LinkButton ID="lnkViewAll" runat="server" CssClass="buttonc" 
                            OnClick="lnkViewAll_Click">View All</asp:LinkButton>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td  class="NormalText" colspan="4">
                            <asp:UpdatePanel ID="UpdateRecordgrid" runat="server">
                    <ContentTemplate>
<%--                <asp:GridView ID="Gridview1" runat="server" EnableModelValidation="True" 
                    Width="100%">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle CssClass="HeaderStyle" />
                    <RowStyle CssClass="gridRow" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>--%>

                                <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" 
                    Width="900px">
                    <asp:GridView ID="GridView1" runat="server" 
              
                 Width="100%" onselectedindexchanged="GridView1_SelectedIndexChanged"  OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False">
                                      <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <Columns>
                            <asp:TemplateField HeaderText="UnMap">
                            <ItemTemplate>
                            <asp:ImageButton ID="ImgDelRows" runat="server" CausesValidation="False" 
                            ImageUrl="~/OPS/Image/iPhone_Delete_icon.png" onclick="ImgDelRows_Click" />
                            </ItemTemplate>
                            </asp:TemplateField>
                                <asp:BoundField DataField="SrNo" HeaderText="Srno" />
                                <asp:BoundField DataField="Location" HeaderText="Location" />
                                <asp:BoundField DataField="Sublocation" HeaderText="Sublocation" />
                                <asp:BoundField DataField="Usercode" HeaderText="Usercode" />
                                <asp:BoundField DataField="EmployeeName" HeaderText="EmployeeName" />
                                <asp:BoundField DataField="Effective From" HeaderText="Effective From" />   
                                <asp:TemplateField HeaderText="Effective To" >                             
                            <ItemTemplate >
                   <asp:TextBox ID="txtunmapdate" runat="server" Columns="12" CssClass="textbox"  Text='<%# Eval("Effective To") %>'
                    MaxLength="12"  Width="70px" ToolTip="MM/DD/YYYY "></asp:TextBox>

                <%--

                                                    <cc1:CalendarExtender ID="txtunmapdate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtunmapdate">
                </cc1:CalendarExtender>

                <cc1:MaskedEditExtender ID="MEEUnmap" runat="server" Mask="99/99/9999" 
                    MaskType="Date" TargetControlID="txtunmapdate">
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MEVUnmap" runat="server" ControlExtender="MEEUnmap" 
                    ControlToValidate="txtunmapdate" Display="Dynamic" EmptyValueMessage="ENTER DATE!!" 
                    ErrorMessage="MEV1" InvalidValueMessage="INVALID DATE" 
                    TooltipMessage="MM/DD/YYYY" ValidationGroup="mandatory"></cc1:MaskedEditValidator>--%>
                        </ItemTemplate>
                         </asp:TemplateField>                          
                        </Columns>
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GirdItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
                                          
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td  class="NormalText">
                           </td>
            <td  class="NormalText">
                            </td>
        </tr>
    </table>
</asp:Content>

