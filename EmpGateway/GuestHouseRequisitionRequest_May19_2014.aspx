<%@ Page Title="" Language="C#" MasterPageFile="~/EmpGateway/MasterPage.master" AutoEventWireup="true" CodeFile="GuestHouseRequisitionRequest.aspx.cs" Inherits="EmpGateway_GuestHouseRequisitionRequest" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="2">
                <asp:Label ID="Label6" runat="server" Text="Guest House Requisition"
                    Width="155px"></asp:Label>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 162px">
    <span >
                    <asp:Label ID="Label21" runat="server"  Text="Name of Guest" Width="84px"></asp:Label>
       </span></td>
            <td class="NormalText">
                <asp:TextBox ID="txtGuestName" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGuestName" Display="Dynamic" ErrorMessage="** Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 162px">
    <span >
                    <asp:Label ID="Label22" runat="server" Text="Address Of Guest"></asp:Label>
       </span></td>
            <td class="NormalText">
                <asp:TextBox ID="txtGuestAddress" runat="server" CssClass="textbox" Height="50px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtGuestAddress" Display="Dynamic" ErrorMessage="** Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 162px">
    <span >
                    <asp:Label ID="Label2" runat="server"  Text="No. Of Persons :" Width="87px" 
                        Height="16px"></asp:Label>
       </span></td>
            <td class="NormalText">
                <asp:TextBox ID="txtNoOfPerson" runat="server" CssClass="textbox" Width="20px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtNoOfPerson_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="txtNoOfPerson">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNoOfPerson" ErrorMessage="** Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 162px">
    <span >
                    <asp:Label ID="lbl8" runat="server"  Text="Whether to be charged" 
                        Height="16px"></asp:Label>
       </span></td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlCharges" runat="server" CssClass="combobox">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 162px; height: 16px">
    <span >
                    <asp:Label ID="Label23" runat="server"  Text="Whether stay is required :" 
                        Height="16px"></asp:Label>
       </span></td>
            <td class="NormalText">
                 <asp:UpdatePanel runat="server" id="UpdStayRequired" >
                     <ContentTemplate>
                <asp:RadioButtonList ID="rblStayRequired" runat="server" AutoPostBack="True" CssClass="combobox" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblStayRequired_SelectedIndexChanged">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rblStayRequired" Display="Dynamic" ErrorMessage="** Required"></asp:RequiredFieldValidator>
            </ContentTemplate>
                     </asp:UpdatePanel>
            </td>
        </tr>
    </table>

  <asp:UpdatePanel runat="server" id="UpdStayYes" UpdateMode="Conditional" >
        <ContentTemplate>
  <p runat="server" class="panelbg" id="pnlStayYes" visible="False">
        <table style="width: 100%;">
            <tr>
                <td class="NormalText" style="width: 162px">&nbsp;</td>
                <td class="NormalText" style="width: 161px">
                    <span>
                        <asp:Label ID="Label24" runat="server" Text="Duration of Stay"
                            Height="16px"></asp:Label>
                    </span></td>
                <td class="NormalText" style="width: 24px">
                    <span style="text-align: right">
                        <asp:Label ID="Label25" runat="server" Text="From"
                            Height="16px"></asp:Label>
                    </span></td>
                <td class="NormalText">
                    <asp:TextBox ID="txtFrom" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtFrom_CalendarExtender" runat="server" TargetControlID="txtFrom">
                    </cc1:CalendarExtender>
                </td>
                <td class="NormalText" style="width: 28px">
                    <span style="text-align: right">
                        <asp:Label ID="Label26" runat="server" Text="To"
                            Height="16px"></asp:Label>
                    </span></td>
                <td class="NormalText">
                    <asp:TextBox ID="txtTo" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtTo_CalendarExtender" runat="server" TargetControlID="txtTo">
                    </cc1:CalendarExtender>
                </td>
                <td class="NormalText">&nbsp;</td>
            </tr>
            <tr>
                <td class="NormalText" style="width: 162px">&nbsp;</td>
                <td class="NormalText" style="width: 161px">
                    <span>
                        <asp:Label ID="Label27" runat="server" Text="Where to accomodate"
                            Height="16px"></asp:Label>
                    </span></td>
                <td class="NormalText" colspan="4">
                    <asp:DropDownList ID="ddlAccomodate" runat="server" CssClass="combobox">
                        <asp:ListItem>Main Guest House</asp:ListItem>
                        <asp:ListItem>B-1</asp:ListItem>
                        <asp:ListItem>A-2</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="NormalText">&nbsp;</td>
            </tr>
            <tr>
                <td class="NormalText" style="width: 162px">&nbsp;</td>
                <td class="NormalText" style="width: 161px">
                    <span>
                        <asp:Label ID="Label28" runat="server" Text="Whether drinks to served"
                            Height="16px"></asp:Label>
                    </span></td>
                <td class="NormalText" colspan="4">
                    <asp:DropDownList ID="ddlDrinksServed" runat="server" CssClass="combobox">
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="NormalText">&nbsp;</td>
            </tr>
            <tr>
                <td class="NormalText" style="width: 162px">&nbsp;</td>
                <td class="NormalText" style="width: 161px">
                    <span>
                        <asp:Label ID="Label29" runat="server" Text="Kind of foods to be served"
                            Height="16px"></asp:Label>
                    </span></td>
                <td class="NormalText" colspan="4">
                    <asp:DropDownList ID="ddlFood" runat="server" CssClass="combobox">
                        <asp:ListItem>Vegetarian</asp:ListItem>
                        <asp:ListItem>Non-Vegetarian</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="NormalText">&nbsp;</td>
            </tr>
            <tr>
                <td class="NormalText" style="width: 162px">&nbsp;</td>
                <td class="NormalText" style="width: 161px">&nbsp;</td>
                <td class="NormalText" style="width: 24px">&nbsp;</td>
                <td class="NormalText">&nbsp;</td>
                <td class="NormalText" style="width: 28px">&nbsp;</td>
                <td class="NormalText">&nbsp;</td>
                <td class="NormalText">&nbsp;</td>
            </tr>
            <tr>
                <td class="NormalText" style="width: 162px">&nbsp;</td>
                <td class="NormalText" style="width: 161px">&nbsp;</td>
                <td class="NormalText" style="width: 24px">&nbsp;</td>
                <td class="NormalText">&nbsp;</td>
                <td class="NormalText" style="width: 28px">&nbsp;</td>
                <td class="NormalText">&nbsp;</td>
                <td class="NormalText">&nbsp;</td>
            </tr>
        </table>
    </p>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="rblStayRequired" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
  
     <asp:UpdatePanel runat="server" id="UpdStayNo" UpdateMode="Conditional" >
        <ContentTemplate>
     <p runat="server" class="panelbg" id="pnlStayNo" visible="False">
        <table style="width:100%;">
               <tr>
            <td class="NormalText" style="width: 162px">&nbsp;</td>
            <td class="NormalText" style="width: 161px">
                <span>
                <asp:Label ID="Lbl9" runat="server" Height="16px" Text="Date of Stay"></asp:Label>
                </span></td>
            <td class="NormalText" colspan="5">
                <asp:TextBox ID="txtDateofStay" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateofStay_CalendarExtender" runat="server" TargetControlID="txtDateofStay">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 162px"></td>
            <td class="NormalText" style="width: 161px">
    <span >
                    <asp:Label ID="Lbl1" runat="server"  Text="Meals to be served" 
                        Height="16px"></asp:Label>
       </span></td>
            <td class="NormalText" colspan="5">
                <asp:CheckBoxList ID="chkMealsServed" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Breakfast</asp:ListItem>
                    <asp:ListItem>Lunch</asp:ListItem>
                    <asp:ListItem>Tea/Snacks</asp:ListItem>
                    <asp:ListItem>Dinner</asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 162px">&nbsp;</td>
            <td class="NormalText" style="width: 161px">
    <span >
                    <asp:Label ID="lbl5" runat="server"  Text="Whether drinks to be served" 
                        Height="16px"></asp:Label>
       </span></td>
            <td class="NormalText" colspan="4">
                <asp:DropDownList ID="ddlDrinksServed1" runat="server" CssClass="combobox">
                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                    <asp:ListItem Value="N">No</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">&nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 162px">&nbsp;</td>
            <td class="NormalText" style="width: 161px">
    <span >
                    <asp:Label ID="lbl6" runat="server"  Text="Name of the Person accompained" ></asp:Label>
       </span></td>
            <td class="NormalText" colspan="4">
                <asp:TextBox ID="txtPersonAccompained" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
            </td>
            <td class="NormalText">&nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 162px">&nbsp;</td>
            <td class="NormalText" style="width: 161px">&nbsp;</td>
            <td class="NormalText" style="width: 24px">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
            <td class="NormalText" style="width: 28px">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 162px">&nbsp;</td>
            <td class="NormalText" style="width: 161px">&nbsp;</td>
            <td class="NormalText" style="width: 24px">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
            <td class="NormalText" style="width: 28px">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
        </tr>
    </table>
    </p>
   </ContentTemplate>
         <Triggers>
             <asp:AsyncPostBackTrigger ControlID="rblStayRequired" EventName="SelectedIndexChanged" />
         </Triggers>
         </asp:UpdatePanel>
    <table style="width: 100%;">
        <tr>
            <td class="buttonbackbar" colspan="2">
                <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" OnClick="lnkSave_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 165px">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 165px">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
        </tr>
        </table>

</asp:Content>

