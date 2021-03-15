<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeFile="DownloadFile.aspx.cs" Inherits="DownloadFile" %>
<style type="text/css">
.tableheader
{
    background-position: 0px -10px; 
    background-image: url('../Image/Frame/Frame_Vertical_Back.png');
    font-family : Trebuchet MS;
    font-size:10pt;
    vertical-align:text-bottom;
    height: 37px;
    text-align: left;
}
.tableback
{
    background-position: 0px -41px; 
    background-image: url('../Image/Frame/Frame_Vertical_Back.png');
    background-repeat:repeat-x ;
    text-align: left;
}
</style>
<form id="form1" runat="server">
<div class="tableheader"><b><h3> A Tribute to Late Sh. Lala Karam Chand Thapar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Close</asp:LinkButton>
    </b></h3></div>
<div class="tableback" style="text-align:center">
<div>
    <%--<asp:literal id="ltrlMediaPlayer" runat="server" ></asp:literal>--%>
    
    <asp:literal id="ltrlMediaPlayer" runat="server"></asp:literal>
</div>
<div class="tableback" style="text-align:center">copyright@ JCT Limited Phagwara.<b>Complied by IT Department</b></div>
    </div>

 </form>


 