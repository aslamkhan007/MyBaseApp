<%@ Page Title="" Language="C#" MasterPageFile="~/Courier Tracking System/MasterPage.master"
    AutoEventWireup="true" CodeFile="Authorize_Courier_Requests10.aspx.cs" Inherits="Courier_Tracking_System_Authorize_Courier_Requests10" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        th
        {
            text-align:left;
        }
          body
         {
             font-family:Arial;
             font-size:10pt;
         }
         #divEditBox
         {
             display:none;
             position:absolute;
             left:30%;
             top:30%;
         }
         .highlightRow
         {
            background-color:Yellow;   
         }
         .select
         {
             background-color:#c0c0c0;
         }
    </style>
    <script type="text/javascript">
        function setRowBackColor(checkBox, className) {
            if (checkBox.checked)
                checkBox.parentNode.parentNode.className = 'HighlightedRow';
            else
                checkBox.parentNode.parentNode.className = 'RowStyle';
        }

    </script>
    <script src="../Scripts/jquery-1.2.6.js" type="text/javascript"></script>
      <script type="text/javascript" language="javascript">
          $(document).ready(function () {


              $('.anchor1').mouseover(function () {

                  $("#disp").show();
                  var pos = $(this).offset();
                  var width = $(this).width();

                  $("#disp").css({
                      left: (pos.left + width) + 'px',
                      top: pos.top - 5 + 'px'
                  });
                  var id1 = $(this).attr("id");




                  var ID = 'ReferenceID=' + id1;
                  $.ajax({
                      type: "GET",
                      url: "Authorize_Courier_TooTip.aspx",
                      data: ID,

                      success: function (data) {

                          $("#disp").show("slow");
                          $("#disp").html(data);

                      }
                  });
                  return false;


              });

              $('.anchor1').mouseout(function () {
                  $("#disp").hide();

              });
          });
     
     
     
     </script>
    

    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="6">
                <asp:Label ID="Label18" runat="server" Text="Authorize Courier Requests"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 146px">
                <asp:Label ID="Label25" runat="server" Text="From Date"></asp:Label>
            </td>
            <td class="NormalText" style="width: 137px">
                <asp:TextBox ID="txtFromDate" runat="server" Columns="11" MaxLength="11"></asp:TextBox>
               
             
               
               
                <asp:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" 
                    TargetControlID="txtFromDate">
                </asp:CalendarExtender>
               
             
               
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtFromDate" ErrorMessage="*"></asp:RequiredFieldValidator>
               
             
               
            </td>
            <td class="NormalText" style="width: 81px">
                <asp:Label ID="Label26" runat="server" Text="To Date"></asp:Label>
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtToDate" runat="server" Columns="11" MaxLength="11"></asp:TextBox>
             
                <asp:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" 
                    TargetControlID="txtToDate">
                </asp:CalendarExtender>
               
             
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtToDate" ErrorMessage="*"></asp:RequiredFieldValidator>
               
             
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 146px">
                <asp:Label ID="Label19" runat="server" Text="Select Courier Type"></asp:Label>
            </td>
            <td class="NormalText" style="width: 137px">
                <asp:DropDownList ID="ddlCourierType" runat="server" AutoPostBack="True" 
                    OnSelectedIndexChanged="ddlCourierType_SelectedIndexChanged" 
                    style="text-align: center" DataSourceID="SqlDataSource1" 
                    DataTextField="CourierType" DataValueField="CourierType">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="Select 'All' as CourierType,'All' as CourierType
Union
Select [CourierType],[CourierType] from jct_courier_type_master where status='A'">
                </asp:SqlDataSource>
            </td>
            <td class="NormalText" style="width: 81px">
                <asp:Label ID="Label27" runat="server" Text="Department"></asp:Label>
            </td>
            <td class="NormalText" colspan="3">
                <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="combobox" 
                    DataSourceID="SqlDataSource2" DataTextField="DeptName" 
                    DataValueField="DeptCode">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="Select 'All' as DeptName,'All' as DeptCode
Union
Select DeptName ,DeptCode from Deptmast where Company_Code='JCT00LTD' order by DeptName">
                </asp:SqlDataSource>
               
             
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 146px">
                <asp:Label ID="Label20" runat="server" Text="Select Type"></asp:Label>
            </td>
            <td class="NormalText" colspan="3">
                <asp:DropDownList ID="ddlSelectType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSelectType_SelectedIndexChanged">
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>Authorized</asp:ListItem>
                    <asp:ListItem>Cancelled</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 146px">
                &nbsp;</td>
            <td class="NormalText" colspan="3">
                 
                </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                    onclick="lnkFetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkAuthorize" runat="server" CssClass="buttonc" OnClick="lnkAuthorize_Click">Authorize</asp:LinkButton>
                <asp:LinkButton ID="lnkSearch" runat="server" CssClass="buttonc">Search</asp:LinkButton>
                <asp:LinkButton ID="lnkAddCost" runat="server" CssClass="buttonc" 
                    OnClick="lnkAddCost_Click" 
                    ToolTip="Add Cost to the Couriers whose cost has not been defined while authorization. It is mainly for the international Couriers.">Add Cost</asp:LinkButton>
                       <asp:LinkButton ID="lnkCancel" runat="server" CssClass="buttonc" 
                    onclick="lnkCancel_Click">Cancel</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText" colspan="2">
           
                <asp:Panel ID="Panel1" runat="server" CssClass="panelbg" ScrollBars="Both" 
                    Width="1000px">
                     <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle" EnableModelValidation="True"
                        AutoGenerateColumns="False" Width="100%" 
                        OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" 
                        onpageindexchanging="GridView1_PageIndexChanging" PageSize="500" 
                        onrowcreated="GridView1_RowCreated" onrowcommand="GridView1_RowCommand">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField runat="server" ID="hndRowBackColor" Value="" />
                                    <asp:CheckBox ID="chk" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ref. No">
                                <ItemTemplate>
                                    <a href="javascript:void(0);"  class="anchor1" style="display:none;" id='<%#Eval("Serial_No")%>'><%#Eval("Serial_No")%></a>
                                    <asp:Label ID="lblSerial"  runat="server" Visible="true" Text='<%#Eval("Serial_No")%>'></asp:Label>
                                         <asp:HoverMenuExtender ID="lblSerial_HoverMenuExtender" runat="server" PopupControlID="pnlToolTip"
                                        TargetControlID="lblSerial" PopupPosition="Right" 
                                        OffsetX="0"
                                              OffsetY="0"
                                         PopDelay="10">
                                    </asp:HoverMenuExtender>

                                    <div id="disp" class="large"
                                        style="position:absolute;  background-color: #FFF;    z-index: 20000; ">
                                    </div>
                                    <br />
                                    <asp:Panel ID="pnlToolTip" runat="server" CssClass="panelbg" BorderStyle="None" BorderColor="Black" BorderWidth="0"  style="display:none;" Width="50%"  >
                                        <table style="width: 100%;">
                                        <tr>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" Text="Serial_No"></asp:Label>
                                        </td>
                                        <td>
                                         <asp:Label ID="Label28" runat="server" Text='<%# Eval("Serial_No") %>'></asp:Label>
                                        </td>
                                        </tr>
                                            <tr>
                                                <td>
                                                     <asp:Label ID="Label14" runat="server" Text="Subject"></asp:Label>
                                                     </td>
                                                <td>
                                                    <asp:Label ID="Label41" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                     <asp:Label ID="Label15" runat="server" Text="Party Name"></asp:Label>
                                                     </td>
                                                <td>
                                                     <asp:Label ID="Label26" runat="server" Text='<%# Eval("Party_Name") %>'></asp:Label>
                                                     </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label16" runat="server" Text="Address"></asp:Label>
                                                    </td>
                                                <td>
                                                     <asp:Label ID="Label27" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                                     </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label17" runat="server" Text="Attached File"></asp:Label>
                                                    </td>
                                                <td>
                                                     <asp:LinkButton ID="lnkFile" CommandArgument='<%# Eval("Attached_File") %>' CommandName="Download" Text='<%# Eval("Attached_File") %>' runat="server">LinkButton</asp:LinkButton>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                     <asp:Label ID="Label23" runat="server" Text="Request By"></asp:Label>
                                                     </td>
                                                <td>
                                                    <asp:Label ID="Label43" runat="server" Text='<%# Eval("Request_By") %>'></asp:Label>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                     <asp:Label ID="Label24" runat="server" Text="Courier Service"></asp:Label></td>
                                                <td>
                                                     <asp:Label ID="Label44" runat="server" Text='<%# Eval("Courier_Service") %>'></asp:Label>
                                                     </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Courier Service">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlCourierService" runat="server" CssClass="combobox" 
                                        DataSourceID="DataSource2" DataTextField="Courier_Service" 
                                        DataValueField="Courier_Service">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="DataSource2" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                        SelectCommand="Select Courier_Service,Courier_Service from jct_Courier_Service_Master where status='A'">
                                    </asp:SqlDataSource>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delivery Type">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlDeliveryType" runat="server" CssClass="combobox" 
                                        DataSourceID="DataSource3" DataTextField="DeliveryType" 
                                        DataValueField="DeliveryType">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="DataSource3" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                        SelectCommand="Select 'All' as [DeliveryType] ,'All' as [DeliveryType] Union SELECT DeliveryType,DeliveryType FROM dbo.jct_courier_Delivery_Type where status='A'">
                                    </asp:SqlDataSource>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Doc. No.">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtUserRefNo" runat="server" Columns="15" CssClass="textbox" 
                                        MaxLength="20" Text='<%# Eval("User_RefNo") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Courier Slip No.">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSlipNo" runat="server" CssClass="textbox" 
                                        Text='<%# Eval("Slip_No") %>' Columns="15"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="txtSlipNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </ItemTemplate>
                                <ControlStyle CssClass="200px" />
                                <ItemStyle Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cost">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCost" runat="server" CssClass="textbox" 
                                        Text='<%# Eval("Cost") %>' Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Request By">
                                <ItemTemplate>
                                    <asp:Label ID="lblRequestedBy" runat="server" Text='<%# Eval("Request_By") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Party Code">
                                <ItemTemplate>
                                 <asp:Label ID="lblPartyCode" runat="server" Text='<%# Eval("PartyCode") %>'></asp:Label>
                                         
                                </ItemTemplate>
                                <ControlStyle Width="30px" />
                                <HeaderStyle Width="80px" />
                                <ItemStyle Width="40px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Courier Type">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlCourierType" runat="server" CssClass="combobox" 
                                        DataSourceID="DataSource1" DataTextField="CourierType" 
                                        DataValueField="CourierType" >
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="DataSource1" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="Select 'All' as CourierType,'All' as CourierType
Union
Select CourierType,CourierType from jct_courier_Type_master where status ='A' order by CourierType">
                                    </asp:SqlDataSource>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cost Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCostCenter" runat="server" Text='<%# Eval("Dept_Code") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle CssClass="FooterStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                </asp:Panel>
              
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 146px">
                &nbsp;
                <asp:HiddenField ID="hd1" runat="server" Visible="False" />
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 146px">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 146px">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlPopUp" Style="display: none;" runat="server" ScrollBars="Auto"
        Width="400px" Height="600px">
        <asp:Image ID="Image1" runat="server" Width="400px" Height="400px" ImageUrl="~/Image/Quotes_tournament/22.jpg" />
    </asp:Panel>

  <!-- <script type="text/javascript">
    // show edit box when edit link is clicked

    function ShowEditBox() {
        var pid = 'txtUserRefNo';
        var colIndex = 1;

        var $tr = $("#" + pid).parent().parent();

        $tr.find('td').each(function () {
            if (colIndex == 1) {
                $("#tAutoid").val($(this).text());
                var a = "#tAutoid";

            }
        })
        $("#divEditBox").slideDown("medium");
        $.ajax({
            type: "POST",
            url: "Authorize_Courier_Requests.aspx",
            // data: "#tAutoid",
            data: "a",
            success: function (msg) {
                $("#tAutoid").text(msg);
            }

        });
     // $("#editId").val(id);
  } 
          function HideEditBox() {
        $("#divEditBox").slideUp("medium");
    }
          //  else if (colIndex == 3) {
         //        $("#tPartyName").val($(this).text());
         //   }
          //  else if (colIndex == 4) {
           //     $("#tPartyAddress").val($(this).text());
            //}
           // else if (colIndex == 5) {
            //    $("#tFile").val($(this).text());
            //}
           // else if (colIndex == 5) {
             //   $("#tItem").val($(this).text());
            //}
            //else if (colIndex == 5) {
              //  $("#tCourier").val($(this).text());
            //}
            //else if (colIndex == 5) {
              //  $("#tDelivery").val($(this).text());
            //}
            //colIndex++;

  

    // Hide the edit/insert box
  

</script> -->

 <!-- <div id="divEditBox">
        <table cellpadding="4" width="600" cellspacing="0" border="0" style="background-color:#efefef;border:1px solid #c0c0c0;">
            <tr style="background-color:#b0b0b0;" valign="top">
                <td style="width: 91%" colspan="3">&nbsp;<label id="lblPopTitle">View Detail</label></td>
                <td align="right" style="width: 9%;padding-right:10px;">
                    <a id="closeLink"  href="javascript:void(0)" onclick="HideEditBox()" title="Close">Close</a>
                </td>
            </tr>
             <tr>
                <td>AutoID: </td><td><div id="tAutoid"></div> </td>  
                </tr>
            <tr>
                <td>Subject: </td><td><div id="tSubject"></div> </td>  
                </tr>
                <tr>
                         
                <td>Party Name: </td><td><div id="tPartyName"></div></td>  
                   </tr>   
                     <tr>             
                <td>Party Address: </td><td><div id="tPartyAddress"></div></td></tr> 
                  <tr>  
                <td>Attached File: </td><td><div id="tFile"></div></td>  </tr>  
                 <tr>  
                <td>Item : </td><td><div id="tItem"></div> </td>  </tr>  
                 <tr>  
                <td>Courier Service: </td><td><div id="tCourier"></div> </td>  </tr>  
                 <tr>  
                <td>Delivery Type: </td><td><div id="tDelivery"></div> </td> 
            </tr>
            <tr><td colspan="4" align="center">&nbsp;
        
            </td></tr>
        </table>
    </div> -->


    
</asp:Content>
