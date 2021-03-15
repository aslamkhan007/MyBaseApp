<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="medicalinsurance.aspx.vb" Inherits="medicalinsurance" title="Medical Insurance" %>

<%@ Register Assembly="eWorld.UI.Compatibility, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
  Namespace="eWorld.UI.Compatibility" TagPrefix="cc1" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
  Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
  <table style="width: 100%">
    <tr>
    <td colspan="4" class="tableheader">
      <asp:Label ID="Label1" runat="server" Text="Medical Insurance" Width="155px"></asp:Label></td>
    </tr>
    <tr>
    <td class="labelcells">
      <asp:Label ID="Lblname" runat="server" Text="Name" Width="46px" TabIndex="200"  ></asp:Label></td>
    <td class="textcells">
      <asp:TextBox ID="Txtempname" runat="server"  
        CssClass="textbox"></asp:TextBox></td>
    <td class="labelcells">
    </td>
    <td 
      class="textcells">
    </td>
    </tr>
    <tr>
    <td class="labelcells">
      <asp:Label ID="lblspouse"  runat="server" Text="Spouse Name" Width="88px" TabIndex="300"  ></asp:Label></td>
    <td class="textcells">
      <asp:TextBox ID="Txtspousename" runat="server" TabIndex="3" 
       CssClass="textbox"></asp:TextBox></td>
    <td class="labelcells">
      <asp:Label ID="Lblspdob" runat="server" Text="Spouse DOB" Width="82px" TabIndex="400"  ></asp:Label></td>
    <td 
      class="textcells">
      <cc1:CalendarPopup ID="txtspdob" runat="server" Width="59px" Text="..." 
        CssClass="textbox">
      </cc1:CalendarPopup>
    </td>
    </tr>
    <tr>
    <td class="labelcells">
      <asp:Label ID="lblspflag" runat="server" Text="Flag" Width="46px" TabIndex="500"></asp:Label></td>
    <td class="textcells">
      <asp:DropDownList ID="ddlspflag" runat="server" TabIndex="12"  Width="44px" CssClass="combobox">
        <asp:ListItem>Y</asp:ListItem>
        <asp:ListItem>N</asp:ListItem>
      </asp:DropDownList></td>
    <td class="labelcells">
    </td>
    <td class="textcells">
    </td>
    </tr>
    <tr>
    <td class="labelcells">
      <asp:Label ID="Label2" runat="server"  
        Text="Father Name"></asp:Label></td>
    <td  class="textcells">
      <asp:TextBox ID="Txtfather" runat="server"  
        CssClass="textbox"></asp:TextBox></td>
    <td class="labelcells">
      <asp:Label ID="Lblfatherdob" runat="server"  
       Text="Father DOB"></asp:Label></td>
    <td class="textcells">
      <cc1:CalendarPopup ID="txtfatherdob" runat="server" Text="..." Width="56px" 
        CssClass="textbox">
      </cc1:CalendarPopup>
    </td>
    </tr>
    <tr>
    <td class="labelcells">
      <asp:Label ID="lblfatherflag" runat="server" Text="Flag" Width="43px"></asp:Label></td>
    <td class="textcells">
      <asp:DropDownList ID="ddlfatherflag" runat="server" Width="44px" CssClass="combobox"  >
        <asp:ListItem>Y</asp:ListItem>
        <asp:ListItem>N</asp:ListItem>
      </asp:DropDownList></td>
    <td  class="labelcells">
    </td>
    <td class="textcells">
    </td>
    </tr>
    <tr>
    <td class="labelcells">
      <asp:Label ID="lblmother" runat="server" Text="Mother Name" Width="122px"></asp:Label></td>
    <td  class="textcells">
      <asp:TextBox ID="txtmother" runat="server" CssClass="textbox"></asp:TextBox></td>
    <td  class="labelcells">
      <asp:Label ID="lblmotherdob" runat="server"  
       Text="Mother DOB"></asp:Label></td>
    <td class="textcells">
      <cc1:CalendarPopup ID="txtmotherdob" runat="server" Text="..." Width="58px" 
        CssClass="textbox">
      </cc1:CalendarPopup>
    </td>
    </tr>
    <tr>
    <td  class="labelcells">
      <asp:Label ID="lblmotherflag" runat="server"  
       Text="Flag"></asp:Label></td>
    <td  class="textcells">
      <asp:DropDownList ID="ddlmotherflag" runat="server" Width="44px" CssClass="combobox"  >
        <asp:ListItem>Y</asp:ListItem>
        <asp:ListItem>N</asp:ListItem>
      </asp:DropDownList></td>
    <td  class="labelcells">
    </td>
    <td class="textcells">
    </td>
    </tr>
    <tr>
    <td  
      class="labelcells">
      <asp:Label ID="Lblchild" runat="server" Text="Children" Width="46px" TabIndex="550"  ></asp:Label></td>
    <td align="left" class="labelcells">
      </td>
    <td align="left" class="labelcells">
    </td>
    <td align="left" 
      class="labelcells">
      </td>
    </tr>
    <tr>
    <td class="panelcells" colspan="4">
      <asp:GridView ID="Grdchild" runat="server" AutoGenerateColumns="False" 
        TabIndex="15" Width="100%" GridLines="None"    CssClass="GridViewStyle">
        <Columns>
        <asp:TemplateField HeaderText="Salutation">
          <ItemTemplate>
            <asp:DropDownList ID="ddlsal" runat="server" 
            SelectedValue='<%# eval("salutation") %>' TabIndex="18" Font-Bold="False" 
            Width="48px" CssClass="combobox">
            <asp:ListItem Selected="True">MR</asp:ListItem>
            </asp:DropDownList>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Name">
          <ItemTemplate>
            <asp:TextBox ID="Textname" runat="server" Text='<%# eval("name") %>' 
            Width="104px" TabIndex="21" Height="15px"></asp:TextBox>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DOB">
          <ItemTemplate>
            <asp:TextBox ID="Textdob" runat="server" Text='<%# eval("dob") %>' Width="73px" 
            TabIndex="24" CssClass="combobox"></asp:TextBox>
            &nbsp;
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Age">
          <ItemTemplate>
            <asp:TextBox ID="Textage" runat="server" Text='<%# eval("age") %>' Width="50px" 
            TabIndex="27" CssClass="textbox"></asp:TextBox>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Flag">
          <ItemTemplate>
            <asp:DropDownList ID="ddlflag" runat="server" 
            SelectedValue='<%# eval("flag") %>' TabIndex="30" CssClass="combobox">
            <asp:ListItem Selected="True">Y</asp:ListItem>
            <asp:ListItem>N</asp:ListItem>
            </asp:DropDownList>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Exist">
          <ItemTemplate>
            <asp:TextBox ID="Textexist" runat="server" Width="36px" Text='<%# eval("exist") %>' TabIndex="33"  ></asp:TextBox>
          </ItemTemplate>
        </asp:TemplateField>
        </Columns>
                                  <RowStyle CssClass="RowStyle" />           
    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    <SelectedRowStyle CssClass="SelectedRowStyle" />

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />
      </asp:GridView>
    </td>
    </tr>
    <tr>
    <td class="buttonbackbar" colspan="4">
    <asp:Button ID="Button1" runat="server" CssClass="ButtonBack"
        Text="Back" BackColor="Black" PostBackUrl="Form.aspx" />
      <asp:Button ID="btnsub" runat="server" CssClass="ButtonBack"
        Text="Submit" BackColor="Black" />
      <asp:Button ID="btnadd" runat="server" CssClass="ButtonBack"
        BackColor="Black" Text="Add More" />
      <br />
      
    </td>
    </tr>
  </table>
</asp:Content>

