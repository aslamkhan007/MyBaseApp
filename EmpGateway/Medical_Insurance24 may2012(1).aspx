﻿<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Medical_Insurance.aspx.cs" Inherits="EmpGateway_Medical_Insurance" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



<link href="../StyleSheets/style.css" rel="stylesheet" type="text/css" />
<link href="../StyleSheets/Chromestyle.css" rel="stylesheet" type="text/css" />
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label20" runat="server" Text="Employee Insurance Details"></asp:Label>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                </td>
        
        </tr>
        <tr>
            <td class="NormalText" style="width: 119px">
                <asp:Label ID="Label16" runat="server" Text="Name"></asp:Label>
            </td>
            <td class="NormalText" style="width: 185px">
                <asp:Label ID="lblName" runat="server"></asp:Label>
            </td>
            <td class="NormalText" style="width: 164px">
                <asp:Label ID="lable2" runat="server" Text="Salary Code"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:Label ID="lblEmpCode" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 119px">
                <asp:Label ID="Label17" runat="server" Text="Card No."></asp:Label>
            </td>
            <td class="NormalText" style="width: 185px">
                <asp:Label ID="lblCardNo" runat="server"></asp:Label>
            </td>
            <td class="NormalText" style="width: 164px">
                <asp:Label ID="label4" runat="server">Department</asp:Label>
            </td>
            <td class="NormalText">
                <asp:Label ID="lblDepartment" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 119px">
                <asp:Label ID="label18" runat="server">Designation</asp:Label>
            </td>
            <td class="NormalText" style="width: 185px">
                <asp:Label ID="lblDesignation" runat="server"></asp:Label>
            </td>
            <td class="NormalText" style="width: 164px">
                <asp:Label ID="label5" runat="server">Date of Joining</asp:Label>
            </td>
            <td class="NormalText">
                <asp:Label ID="lblDoj" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 119px">
                <asp:Label ID="label19" runat="server">DOB</asp:Label>
            </td>
            <td class="NormalText" style="width: 185px">
                <asp:Label ID="lblDob" runat="server"></asp:Label>
            </td>
            <td class="NormalText" style="width: 164px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <asp:Label ID="label21" runat="server">Enter Your Family Details Below :</asp:Label>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" colspan="2">
                <asp:Panel ID="pnlGrid" runat="server" CssClass="panelbg" ScrollBars="Both" 
                    Width="800px">
                    <asp:GridView ID="GridView1" runat="server"  CssClass="GridViewStyle_Newgrid" 
                        AutoGenerateColumns="False" Width="100%" 
                         AllowPaging="True" 
                       PageSize="20" EnableModelValidation="True" ShowFooter="True" 
                        onrowcommand="GridView1_RowCommand"
                       >
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" 
                                        CommandArgument='<%# Eval("Relation") %>' CommandName="Remove"  ToolTip="Click here to Delete record."
                                        ImageUrl="~/Image/Icons/Cross.gif" />
                                    <cc1:ConfirmButtonExtender ID="ImageButton1_ConfirmButtonExtender" 
                                        runat="server" 
                                        ConfirmText="Are you sure, you want to delete this record ?" 
                                        TargetControlID="ImageButton1">
                                    </cc1:ConfirmButtonExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Relation">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlRelation" runat="server" CssClass="combobox" 
                                        SelectedValue='<%# Eval("Relation") %>'>
                                         <asp:ListItem Selected="True">--Select--</asp:ListItem>
                                        <asp:ListItem>Spouse</asp:ListItem>
                                        <asp:ListItem>Father</asp:ListItem>
                                        <asp:ListItem>Mother</asp:ListItem>
                                        <asp:ListItem>Daughter</asp:ListItem>
                                        <asp:ListItem>Son</asp:ListItem>
                                        <asp:ListItem>Self</asp:ListItem>
                                        <asp:ListItem>Other</asp:ListItem>
                                         <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="textbox" 
                                        Text='<%# Eval("Name") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txtName" ErrorMessage="Field Required." 
                                        ValidationGroup="A"></asp:RequiredFieldValidator>
                                </ItemTemplate>
                                <ItemStyle Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DOB">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDob" runat="server" CssClass="textbox" 
                                        Text='<%# Eval("Dob") %>'></asp:TextBox>
                                
                                    <cc1:TextBoxWatermarkExtender ID="txtDob_TextBoxWatermarkExtender" 
                                        runat="server" TargetControlID="txtDob" WatermarkCssClass="watermark" 
                                        WatermarkText="dd/mm/yyyy">
                                    </cc1:TextBoxWatermarkExtender>
                                
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Age">
                                <ItemTemplate>
                                    <asp:Label ID="lblAge" runat="server" Text='<%# Eval("Age") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                         
                        </Columns>
                        <FooterStyle CssClass="FooterStyle_Newgrid" />
                  
                        <HeaderStyle CssClass="HeaderStyle_Newgrid" />
                        <PagerStyle CssClass="PagerStyle_Newgrid" />
                        <PagerTemplate>
                            <asp:Button ID="Button1" runat="server" Text="Add New Row" />
                        </PagerTemplate>
                        <RowStyle CssClass="RowStyle_Newgrid" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="2">
                <asp:Label ID="lblmsg" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2">
                <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" 
                    onclick="lnkSave_Click" ValidationGroup="A">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkSubmit" runat="server" CssClass="buttonc" 
                    onclick="lnkSubmit_Click" ValidationGroup="A">Submit</asp:LinkButton>
                <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
                <asp:LinkButton ID="lnkAddRow" runat="server" CssClass="buttonc" 
                    onclick="lnkAddRow_Click">Add Row</asp:LinkButton>
                <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" 
                    onclick="lnkExcel_Click" Visible="False">To Excel</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

