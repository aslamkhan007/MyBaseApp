<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="PlanOrders.aspx.cs" Inherits="OPS_PlanOrders" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<link href="js/reveal.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://code.jquery.com/jquery-1.6.min.js"></script>

<script src="js/jquery-1.4.3.min.js" type="text/javascript"></script>

    
    <style type="text/css">
        .web_dialog_overlay
        {
            position: fixed;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            height: 100%;
            width: 100%;
            margin: 0;
            padding: 0;
            background: #000000;
            opacity: .15;
            filter: alpha(opacity=15);
            -moz-opacity: .15;
            z-index: 101;
            display: none;
        }
        .web_dialog
        {
            display: none;
            position: fixed;
            width: 380px;
            height: 500px;
            top: 50%;
            left: 50%;
            margin-left: -190px;
            margin-top: -100px;
            background-color: #ffffff;
            border: 2px solid #336699;
            padding: 0px;
            z-index: 102;
            font-family: Verdana;
            font-size: 10pt;
        }
        .web_dialog_title
        {
            border-bottom: solid 2px #336699;
            background-color: #336699;
            padding: 4px;
            color: White;
            font-weight:bold;
        }
        .web_dialog_title a
        {
            color: White;
            text-decoration: none;
        }
        .align_right
        {
            text-align: right;
        }
    </style>

	<style type="text/css">
			body { font-family: "HelveticaNeue","Helvetica-Neue", "Helvetica", "Arial", sans-serif; }
			.big-link { display:block; }
		    .style3
            {
                font-family : Tahoma;
                font-size : 8pt;
                font-weight : bold;
                text-align : left;
                color : Black;
                display : block;
                margin-left: 0px;
                width: 78px;
            }
		</style>

         <script type="text/javascript">
             function CloseAndRebind(args) {
                 GetRadWindow().Close();
                 GetRadWindow().BrowserWindow.refreshGrid(args);
             }

             function GetRadWindow() {
                 var oWindow = null;
                 if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                 else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

                 return oWindow;
             }

             function CancelEdit() {
                 GetRadWindow().Close();
             }
        </script>

    <script language="javascript" type="text/javascript">
     function expandcollapse(obj, row) {
         var div = document.getElementById(obj);
         var img = document.getElementById('img' + obj);

         if (div.style.display == "none") {
             div.style.display = "block";
             if (row == 'alt') {
                 img.src = "../Image/minus.png";
             }
             else {
                 img.src = "../Image/minus.png";
             }
             img.alt = "Close";
         }
         else {
             div.style.display = "none";
             if (row == 'alt') {
                 img.src = "../Image/plus.png";
             }
             else {
                 img.src = "../Image/plus.png";
             }
             img.alt = "Expand to show Order Details";
         }
     } 
    </script>
  	
     <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
     
        <script type="text/javascript">

            function OrderSummary() {

                var order = document.getElementById('<%=txtOrderNo.ClientID %>').value;

                var sort = document.getElementById('<%=txtSortNo.ClientID %>').value;
 
                var btn = $find("<%= lnkHelp.ClientID %>");
 
                window.radopen("PlanWiseOrderSummary.aspx?OrderNo=" + order + "&SortNo=" + sort , "UserListDialog");
                return false;

            }
        </script>
    </telerik:RadCodeBlock>
  
     <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
     
        <script type="text/javascript">

            function PopUp() {

                var o = document.getElementById('<%=txtOrderNo.ClientID %>').value;

                var p = document.getElementById('<%=ddlPlanID.ClientID %>').value;
                

                var btn = $find("<%= Button1.ClientID %>");

                
                window.radopen("OrderStatusPopUp.aspx?OrderNo=" + o + "&PlanID=" + p, "UserListDialog");
                return false;
            }
          
            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
                }
            }
             
        </script>
    </telerik:RadCodeBlock>

      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdPopUp" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdPopUp">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdPopUp" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel"></telerik:RadAjaxLoadingPanel>
  
    <table style="width: 100%">
        <tr >
            <td colspan="6" class="tableheader">
                <asp:Label ID="Label21" runat="server" Text="Final Plan "></asp:Label>
            </td>
        </tr>
        <tr class="NormalText">
            <td class="NormalText" style="width: 105px">
                <asp:Label ID="Label18" runat="server" Text="Plant"></asp:Label>
            </td>
            <td class="NormalText" style="width: 119px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPlant" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlPlant_SelectedIndexChanged">
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="style3">
                &nbsp;</td>
            <td class="NormalText" colspan="2">
               
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr class="NormalText">
            <td class="NormalText" style="width: 105px">
                <asp:Label ID="Label16" runat="server" Text="Select Plan"></asp:Label>
            </td>
            <td class="NormalText" style="width: 119px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <asp:DropDownList ID="ddlPlanID" runat="server" CssClass="combobox" 
                        AutoPostBack="True" onselectedindexchanged="ddlPlanID_SelectedIndexChanged">
                </asp:DropDownList>
                </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlPlant" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="style3">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlPlanID" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" colspan="2">
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Calculate PPL</asp:LinkButton>
                </td>
            <cc1:ConfirmButtonExtender ID="cnfbtn" ConfirmText="Are you sure you want to calculate PPL ?" runat="server" TargetControlID="LinkButton1"></cc1:ConfirmButtonExtender> 
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 105px">
                <asp:Label ID="Label19" runat="server" Text="Order No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 119px">
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox"></asp:TextBox>
              
            </td>
            <td class="style3">
                &nbsp;</td>
            <td class="NormalText" style="width: 85px">
                <asp:Label ID="Label20" runat="server" Text="Sort No"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtSortNo" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:LinkButton ID="lnkHelp" runat="server" onclick="lnkHelp_Click" OnClientClick="return OrderSummary()">Plan Histroy</asp:LinkButton>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="6">
                
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click">fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                            onclick="lnkReset_Click">Reset</asp:LinkButton>
                     <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc"  CausesValidation="false"
                            onclick="lnkExcel_Click">Excel</asp:LinkButton>
  
                  <asp:LinkButton ID="LinkButton2" runat="server" 
                    onclientclick="window.history.go(-1);return false;">&lt;&lt; Back</asp:LinkButton>

                 
            </td>
        </tr>
          <tr>
            <td class="NormalText" colspan="6">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    
 <div>
        <asp:GridView ID="grdParent" runat="server" Width="100%" 
            AutoGenerateColumns="False" 
            EnableModelValidation="True" OnRowDataBound="grdParent_RowDataBound" 
            AllowPaging="True" onpageindexchanging="grdParent_PageIndexChanging" 
            PageSize="30">
            <AlternatingRowStyle CssClass="GridAI" />
            <HeaderStyle CssClass="GridHeader" />
            <PagerStyle CssClass="PagerStyle" />
            <RowStyle CssClass="GridItem" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="javascript:expandcollapse('div<%# Eval("OrderNo") %>--<%# Eval("SortNo") %>>','one');">
                            <img id="imgdiv<%# Eval("OrderNo") %>--<%# Eval("SortNo") %>>" alt="Click to show/hide  for OrderNo <%# Eval("OrderNo") %>"
                                width="9px" border="0" src="../Image/minus.png" />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="ID" SortExpression="ID">
                    <ItemTemplate>
                        <asp:Label ID="lblID" Text='<%# Eval("ID") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OrderNo" SortExpression="OrderNo">
                    <ItemTemplate>
                        <asp:Label ID="lblOrderNo" Text='<%# Eval("OrderNo") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SortNo" SortExpression="SortNo">
                    <ItemTemplate>
                        <asp:Label ID="lblSortNo" Text='<%# Eval("SortNo")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="WeavingSort" SortExpression="WeavingSort">
                    <ItemTemplate>
                     <asp:TextBox ID="txtWeavingSort" CssClass="textbox" MaxLength="15" Columns="10" Text='<%# Eval("WeavingSort") %>'
                                                        runat="server" AutoPostBack="True" 
                            ontextchanged="txtWeavingSort_TextChanged"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OrderQty" SortExpression="OrderQty">
                    <ItemTemplate>
                        <asp:Label ID="lblOrderQty" Text='<%# Eval("OrderQty")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Plan Qty">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtPlanQty" runat="server" Columns="6" MaxLength="8" CssClass="textbox" 
                                               Text='<%# Eval("PlanQty") %>' AutoPostBack="True" 
                                              ></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                 
                   <asp:TemplateField HeaderText="DeliveryDt">
                                       <ItemTemplate>
                                           <asp:Label ID="lblDeliveryDt" runat="server" Text='<%# Eval("DeliveryDt") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
               
               

                <asp:TemplateField HeaderText="Expected DeliveryDt">
                                       <ItemTemplate>
                                           <asp:TextBox ID="lblReqdt1" runat="server" Columns="12" MaxLength="12" CssClass="textbox" 
                                               Text='<%# Eval("ExpectedDeliveryDt") %>' AutoPostBack="True" 
                                               ontextchanged="lblReqdt1_TextChanged" ></asp:TextBox>
                                           <cc1:CalendarExtender ID="lblReqdt1_CalendarExtender" runat="server" 
                                               Format="dd/MM/yyyy" TargetControlID="lblReqdt1">
                                               </cc1:CalendarExtender>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Greigh ReqDt">
                                       <ItemTemplate>
                                         <asp:TextBox ID="lblGreyReqdt" runat="server" Columns="12" MaxLength="12" CssClass="textbox" 
                                               Text='<%# Eval("GreighReqDt") %>' AutoPostBack="True" 
                                               ></asp:TextBox>
                                           <cc1:CalendarExtender ID="lblGreyReqdt_CalendarExtender" runat="server" 
                                               Format="dd/MM/yyyy" TargetControlID="lblGreyReqdt">
                                           </cc1:CalendarExtender>
                                       </ItemTemplate>
                                         
                                   </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Greigh Req" SortExpression="GreighReq">
                    <ItemTemplate>
                     <asp:TextBox ID="txtGreighReq" CssClass="textbox" Enabled="false" MaxLength="15" Columns="10" Text='<%# Eval("GreighReq") %>'
                                                        runat="server"></asp:TextBox>
                       
                    </ItemTemplate>
                </asp:TemplateField>
                 
                <asp:TemplateField HeaderText="Greigh Adj" SortExpression="GreighAdj">
                    <ItemTemplate>
                    <asp:TextBox ID="txtGreighAdj" CssClass="textbox" Enabled="false" MaxLength="15" Columns="10" Text='<%# Eval("GreighAdj") %>'
                                                        runat="server" AutoPostBack="True" 
                            ontextchanged="txtGreighAdj_TextChanged" ></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Greigh Rem" SortExpression="GreighRem">
                    <ItemTemplate>
                    <asp:TextBox ID="txtGreighRem" CssClass="textbox" MaxLength="15" Enabled="false" Columns="10" Text='<%# Eval("GreighRem") %>'
                                                        runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Sizing Req" SortExpression="SizingRequired">
                    <ItemTemplate>
                      <asp:TextBox ID="txtSizing" CssClass="textbox" MaxLength="15" Columns="10" Text='<%# Eval("SizingReq") %>'
                                                        runat="server"  AutoPostBack="true"
                            ontextchanged="txtSizing_TextChanged"></asp:TextBox>
                        
                    </ItemTemplate>
                </asp:TemplateField>
                   
                   
                <asp:TemplateField HeaderText="Sizing Done" SortExpression="SizingDone">
                    <ItemTemplate>

                         <asp:Label ID="lblSizingDone" runat="server" Text='<%# Eval("SizingDone") %>' ></asp:Label>

                    </ItemTemplate>
                </asp:TemplateField>
                   <asp:TemplateField HeaderText="Sizing Rem" SortExpression="SizingRem">
                    <ItemTemplate>
                        <asp:Label ID="lblSizingRem" runat="server" Text='<%# Eval("SizingRem") %>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>              

                    <asp:TemplateField HeaderText="Shed">
                                       <ItemTemplate>
                                           <asp:DropDownList ID="ddlShed" CssClass="combobox" runat="server"  
                                               AutoPostBack="True" 
                                               onselectedindexchanged="ddlShed_SelectedIndexChanged" 
                                               SelectedValue='<%# Eval("Shed") %>'  >
                                                   <asp:ListItem Value="">Select</asp:ListItem>
                                                   <asp:ListItem Value="CON">Conventional</asp:ListItem>
                                                   <asp:ListItem Value="RP190">Rapier</asp:ListItem>
                                                   <asp:ListItem Value="AR190">Airjet</asp:ListItem>
                                                   <asp:ListItem Value="WP102">Waterjet Plain</asp:ListItem>
                                                   <asp:ListItem Value="WD12">Waterjet Dobby</asp:ListItem>
                                                   <asp:ListItem Value="WC38">Waterjet Cam</asp:ListItem>
                                                   <asp:ListItem Value="SA130">Sulzer A130</asp:ListItem>
                                                   <asp:ListItem Value="SA153">Sulzer A153</asp:ListItem>
                                                   <asp:ListItem Value="SB153">Sulzer B</asp:ListItem>
                                                   <asp:ListItem Value="SC130">Sulzer C130</asp:ListItem>
                                                   <asp:ListItem Value="SC153">Sulzer C153</asp:ListItem>
                                                   <asp:ListItem Value="SD153">Sulzer D</asp:ListItem>
                                                   <asp:ListItem Value="SE153">Sulzer E</asp:ListItem>
                                                 
                                           </asp:DropDownList>

                                       </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RPM">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtRPM" runat="server" Columns="4" MaxLength="5" 
                                               CssClass="textbox" Text='<%# Eval("RPM") %>' 
                                                AutoPostBack="True" ontextchanged="txtRPM_TextChanged"></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Efficiency">
                                       <ItemTemplate>
                                                   <asp:TextBox ID="txtEfficiency" Columns="3" MaxLength="3" runat="server" 
                                                       Text='<%# Eval("Efficiency") %>' 
                                                       AutoPostBack="True" ontextchanged="txtEfficiency_TextChanged"></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Loom">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtLoomAllot" runat="server" Columns="3" MaxLength="4"  AutoPostBack="true"
                                               CssClass="textbox" Text='<%# Eval("Looms") %>' ontextchanged="txtLoomAllot_TextChanged" 
                                              > </asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Wvg Days">
                                       <ItemTemplate>
                                           <asp:Label ID="lblWvgCompletionDt" runat="server" 
                                               Text='<%# Eval("WvgDays") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Save/Delete">
                                       <ItemTemplate>
                                           <asp:LinkButton ID="lnkSaveRow"  runat="server" onclick="lnkSaveRow_Click" >Save</asp:LinkButton>
                                           &nbsp;<asp:LinkButton ID="lnkDelete" runat="server" OnClick="lnkDelete_Click">Delete</asp:LinkButton>
                                           <cc1:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server" ConfirmText="Are you sure ?" TargetControlID="lnkDelete">
                                           </cc1:ConfirmButtonExtender>
                                       </ItemTemplate>
                                   </asp:TemplateField>


 <asp:TemplateField>
                    <ItemTemplate>
                        <tr>
                            <td colspan="100%">
                                <div  id="div<%# Eval("OrderNo") %>--<%# Eval("SortNo") %>>"  position: relative; left: 15px; 
                                    overflow: auto; width: 97%">
                                    <asp:GridView ID="GridView2" AllowPaging="True" AllowSorting="True" BackColor="White"
                                        Width="100%" Font-Size="X-Small" AutoGenerateColumns="False" Font-Names="Verdana"
                                        runat="server" DataKeyNames="OrderNo" ShowFooter="True"  PageSize="25"
                                        BorderStyle="Double" OnRowCreated="GridView2_RowCreated"
                                        BorderColor="#0083C1" EmptyDataText="No Record Present" OnPageIndexChanging="GridView2_PageIndexChanging"
                                        OnRowUpdating="GridView2_RowUpdating" OnRowCommand="GridView2_RowCommand" OnRowEditing="GridView2_RowEditing"
                                        OnRowUpdated="GridView2_RowUpdated" OnRowCancelingEdit="GridView2_CancelingEdit"
                                        OnRowDataBound="GridView2_RowDataBound" OnRowDeleting="GridView2_RowDeleting"
                                        OnRowDeleted="GridView2_RowDeleted" OnSorting="GridView2_Sorting" 
                                        EnableModelValidation="True">
                                        <RowStyle BackColor="Gainsboro" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <HeaderStyle BackColor="#0083C1" ForeColor="White" />
                                        <FooterStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Image ID="imgStatus" ImageUrl='<%# Eval("ImageUrl") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:HyperLinkField DataNavigateUrlFields="OrderNo,LineItem,ID,PlanID" 
                                                DataNavigateUrlFormatString="~/OPS/Plan_Individual_Item.aspx?OrderNo={0}&LineItem={1}&ID={2}&PlanID={3}" 
                                                NavigateUrl="~/OPS/Plan_Individual_Item.aspx" Target="_blank" Text="Plan" />
                                            <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete" CommandName="Delete" runat="server">Delete</asp:LinkButton>
                                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="lnkDelete" ConfirmText="Are your Sure ?">
                                                    </cc1:ConfirmButtonExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:TemplateField HeaderText="ID" SortExpression="ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" Text='<%# Eval("ID") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblID" Text='<%# Eval("ID") %>' runat="server"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="OrderNo" SortExpression="OrderNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderNo" Text='<%# Eval("OrderNo") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblOrderNo" Text='<%# Eval("OrderNo") %>' runat="server"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sort No" SortExpression="SortNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSortNo" Text='<%# Eval("SortNo") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblSortNo" Text='<%# Eval("SortNo") %>' runat="server"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                          
                                            <asp:TemplateField HeaderText="Line Item" SortExpression="Lineitem">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLineItem" Text='<%# Eval("Lineitem") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblLineItem" Text='<%# Eval("Lineitem") %>' runat="server"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Shade" SortExpression="Shade">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblShade" Text='<%# Eval("Shade") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblShade" Text='<%# Eval("Shade") %>' runat="server"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Order Qty" SortExpression="OrderQty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderQty" Text='<%# Eval("OrderQty") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblOrderQty" Text='<%# Eval("OrderQty") %>' runat="server"></asp:Label>
                                                <asp:ImageButton ID="imgRefresh" runat="server"  ImageUrl="~/Image/refresh-icon.gif" CommandName="Refresh" CausesValidation="False" />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Plan Qty" SortExpression="PlanQty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPlanQty" Text='<%# Eval("PlanQty") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                 <asp:TextBox ID="txtPlanQty" CssClass="textbox" MaxLength="15" Columns="10"  
                                                        Text='<%# Eval("PlanQty") %>' runat="server" 
                                                        ontextchanged="txtPlanQty_TextChanged"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DeliveryDt" SortExpression="DeliveryDt">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDeliveryDt" Text='<%# Eval("DeliveryDt") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtDeliveryDt" CssClass="textbox" MaxLength="15" Columns="10"  Text='<%# Eval("DeliveryDt") %>'
                                                        runat="server"></asp:TextBox>
                                              <cc1:CalendarExtender ID="txtDeliveryDt_CalendarExtender" runat="server" 
                                               Format="dd/MM/yyyy" TargetControlID="txtDeliveryDt">
                                           </cc1:CalendarExtender>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CaseType" SortExpression="CaseType">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCaseType" Text='<%# Eval("CaseType") %>' runat="server"></asp:Label>
                                                     <asp:Label ID="lblPeach" Text='<%# Eval("Peach") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlCaseType" CssClass="combobox" runat="server" AutoPostBack="True" 
                                                        DataSourceID="SqlDataSource1" DataTextField="CaseType" 
                                                        DataValueField="CaseType" 
                                                        onselectedindexchanged="ddlCaseType_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                                                        SelectCommand="Select '--Select--' as [CaseType] Union SELECT Distinct  [CaseType] FROM production..[JCT_Process_Greigh_Request_Variation] where status='A' and GetDate() between Eff_from and Eff_To">
                                                    </asp:SqlDataSource>

                                                    <asp:CheckBox runat="server" ID="chkPeach" AutoPostBack="true" Text="Peach" OnCheckedChanged="chkPeach_CheckedChanged" /> 

                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Greigh Req" SortExpression="GreighReq">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGreighReq" Text='<%# Eval("GreighReq") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtGreighReq" CssClass="textbox" MaxLength="15" Columns="10"  Text='<%# Eval("GreighReq") %>'
                                                        runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Greigh Adj" SortExpression="GreighAdj">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGreighAdj" Text='<%# Eval("greigh_adj") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtGreighAdj" CssClass="textbox" AutoPostBack="true" MaxLength="15" OnTextChanged="greighAdj_TextChanged"   Columns="10"  Text='<%# Eval("greigh_adj") %>'
                                                        runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sizing" SortExpression="Sizing">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSizing" Text='<%# Eval("Sizing") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtSizing" CssClass="textbox" MaxLength="15" Columns="10"  Text='<%# Eval("Sizing") %>'
                                                        runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Split" SortExpression="Split">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSplit" Text='<%# Eval("Split") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                   <asp:Label ID="lblSplit" Text='<%# Eval("Split") %>' runat="server"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="IPlan" SortExpression="IPlan">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIPlan" Text='<%# Eval("IndividualPlan") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                   <asp:Label ID="lblIPlan" Text='<%# Eval("IndividualPlan") %>' runat="server"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                         
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="grdParent" EventName="RowEditing" />
            <asp:AsyncPostBackTrigger ControlID="grdParent" EventName="RowUpdating" />
            <asp:AsyncPostBackTrigger ControlID="grdParent" EventName="RowUpdated" />
            <asp:AsyncPostBackTrigger ControlID="grdParent" EventName="RowCommand" />
            <asp:AsyncPostBackTrigger ControlID="grdParent" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>

     <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="UserListDialog" runat="server" Title="Order Already Planned..!!" Height="300px"
                Width="500px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                Modal="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>

    <asp:Button ID="btnPopUp" runat="server" onclick="btnPopUp_Click" Width="0px" />
    <asp:Button ID="Button1" runat="server" Visible="false" onclick="Button1_Click"  Text="Click" />
   
   


    <asp:Panel ID="pnlDetail2" runat="server" Width="1000px" Height="300px" 
        ScrollBars="Both">

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                 
               
          



                            <asp:GridView ID="grdDetail" runat="server" Width="100%" 
                               >
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                                  </ContentTemplate>
                               
                    <Triggers>
                     <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                    </Triggers>
                              </asp:UpdatePanel>     
                      </asp:Panel>

         
       <asp:PlaceHolder ID="holder" runat="server">
            </asp:PlaceHolder>
    
</asp:Content>

