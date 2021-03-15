<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="jct_hr_recrument_new.aspx.cs" Inherits="Payroll_jct_hr_recrument_new" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 

    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Title</td>
        </tr>
        <tr>
            <td class="labelcells">
                Name
            </td>
            <td class="labelcells" >
                <asp:TextBox ID="txtname" runat="server" CssClass="textbox" Width="140px" 
                    MaxLength="30" ontextchanged="txtname_TextChanged"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtname" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                Address</td>
            <td>
                <asp:TextBox ID="txtaddress" runat="server" CssClass="textbox" Width="140px" 
                    MaxLength="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtaddress" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 18px">
                Qualification</td>
            <td style="height: 18px">
                <asp:TextBox ID="txtqualification" runat="server" CssClass="textbox" 
                    Width="140px" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtqualification" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td style="height: 18px">
                <asp:Label ID="Label18" runat="server" CssClass="labelcells" 
                    Text="Organisation"></asp:Label>
            </td>
            <td style="height: 18px">
                <asp:TextBox ID="txtorganisation" runat="server" CssClass="textbox" 
                    Width="140px" MaxLength="30"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label19" runat="server" CssClass="labelcells" Text="Experience"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlexperience" runat="server" AutoPostBack="True" 
                    CssClass="combobox" Height="30px" Width="51px">
                    <asp:ListItem>0</asp:ListItem>
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
                    <asp:ListItem>32</asp:ListItem>
                    <asp:ListItem>33</asp:ListItem>
                    <asp:ListItem>34</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>36</asp:ListItem>
                    <asp:ListItem>37</asp:ListItem>
                    <asp:ListItem>38</asp:ListItem>
                    <asp:ListItem>39</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="ddlexperience" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label20" runat="server" Text="ContactNo" CssClass="labelcells"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtcontactno" runat="server" CssClass="textbox" Width="140px" 
                    MaxLength="15"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtcontactno" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="height: 18px">
                <asp:Label ID="Label21" runat="server" CssClass="labelcells" Text="Referance"></asp:Label>
            </td>
            <td style="height: 18px">
                <asp:TextBox ID="txtreferance" runat="server" CssClass="textbox" Width="140px" 
                    MaxLength="30"></asp:TextBox>
            </td>
            <td style="height: 18px">
                <asp:Label ID="Label22" runat="server" CssClass="labelcells" Text="MailID"></asp:Label>
            </td>
            <td style="height: 18px">
                <asp:TextBox ID="txtmail" runat="server" CssClass="textbox" Width="140px" 
                    MaxLength="30"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label23" runat="server" CssClass="labelcells" 
                    Text="InterviewDate"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtdate" runat="server" CssClass="textbox" Width="140px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" 
                    TargetControlID="txtdate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                    ControlToValidate="txtdate" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label24" runat="server" CssClass="labelcells" Text="Department"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="dddepartment" runat="server" AutoPostBack="True" 
                    CssClass="combobox" Height="30px" Width="138px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="dddepartment" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label25" runat="server" CssClass="labelcells" Text="Designation"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddldesg" runat="server" AutoPostBack="True" 
                    CssClass="combobox" Height="30px" Width="159px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                    ControlToValidate="ddldesg" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label26" runat="server" CssClass="labelcells" Text="Status "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtstatus" runat="server" CssClass="textbox" Width="140px" 
                    MaxLength="25"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                    ControlToValidate="txtstatus" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" 
                    onclick="lnkadd_Click1">Add</asp:LinkButton>
                <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                    onclick="lnkupdate_Click1">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkdelete" runat="server" CssClass="buttonc" onclick="lnkdelete_Click1" 
                    >Delete</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" 
                    Visible="False" Width="1000px">
                    <asp:GridView ID="GridDetail" runat="server" Width="100%" 
                        AutoGenerateSelectButton="True" 
                        onselectedindexchanged="grdDetail_SelectedInd">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        </table>
</asp:Content>

