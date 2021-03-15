<%@ Page Title="" Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="UpLoadFile.aspx.vb" Inherits="UploadFile" %>
   <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
   

    Sub Page_Load(ByVal Sender As Object, ByVal e As EventArgs)

        Dim MyPath, MyName As String
        ' Display the names in C:\ that represent directories.

        MyPath = "E:\ServerFolder"                      ' Set the path.
        MyName = Dir(MyPath, vbDirectory)   ' Retrieve the first entry.

        If MyName = "" Then          ' The folder is not there & to be created
            MkDir("E:\ServerFolder\")       'Folder created
            LblError2.Text = "A Folder (E:\ServerFolder) is created at the Page_Load"
        End If
  
    End Sub

    Sub Upload_Click(ByVal Sender As Object, ByVal e As EventArgs)

        ' Display properties of the uploaded file

        LblFileName.Text = MyFile.PostedFile.FileName
        LblFileContent.Text = MyFile.PostedFile.ContentType
        LblFileSize.Text = MyFile.PostedFile.ContentLength.ToString
        UploadDetails.Visible = True

        ' Let us recover only the file name from its fully qualified path at client 

        Dim strFileName As String
        strFileName = MyFile.PostedFile.FileName
        Dim c As String = System.IO.Path.GetFileName(strFileName) ' only the attched file name not its path

        ' Let us Save uploaded file to server at E:\ServerFolder\


        Try
               

            MyFile.PostedFile.SaveAs("E:\ServerFolder\" + c)
            LblError1.Text = "Your File Uploaded Sucessfully at server as : E:\ServerFolder\" & c
  
        Catch Exp As Exception
            LblError1.Text = "An Error occured. Please check the attached  file"
            UploadDetails.Visible = False
            LblError2.Visible = False
        End Try
           
    End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <style type="text/css">
        #divFileUpload input
        {
            border-color: Olive;
            border-style: solid;
            border-width: 1px;
        }
        .style4
        {
            width: 44px;
        }
        .style5
        {
        }
        .style6
        {
        }
        .style7
        {
            width: 617px;
        }
    </style>

     
   
</head>
<body>
    
    <div id="divFileUpload">
        <br />
&nbsp;<table style="width:100%;">
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style7">
                    <asp:Label ID="Label19" runat="server" CssClass="labelcells" 
                        Text="Choose File TO Upload"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style7">
        <input id="MyFile" type="File" runat="Server" size="40" onclick="return MyFile_onclick()"></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style7">
        <input id="Submit1" type="Submit" value="Upload" OnServerclick="Upload_Click" runat="Server"></td>
                <td>
                    &nbsp;</td>
            </tr>
            <div id="UploadDetails" visible="False" runat="Server">
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style5" colspan="2">
                    <asp:Label ID="Label16" runat="server" CssClass="labelcells" Text="File Name"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="LblFileName" runat="server" CssClass="labelcells"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style5" colspan="2">
                    <asp:Label ID="Label17" runat="server" CssClass="labelcells" 
                        Text="File Content"></asp:Label>
                &nbsp;
                    <asp:Label ID="LblFileContent" runat="server" CssClass="labelcells"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style6" colspan="2">
                    <asp:Label ID="Label18" runat="server" CssClass="labelcells" Text="File Size"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="LblFileSize" runat="server" CssClass="labelcells"></asp:Label>
                </td>
            </tr>
            </div>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style7">
                    <asp:Label ID="LblError1" runat="server" CssClass="labelcells" 
                        ForeColor="Red"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style7">
                    <asp:Label ID="LblError2" runat="server" CssClass="labelcells" 
                        ForeColor="Red"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>
        <br>
        &nbsp;</div>
    
 
</body>
</html>
</asp:Content>