<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GalleryApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Home</title>
    <link href="GalleryStyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        //onload = function () {
        //    debugger;
        //    var browser = navigator.appName

        //    alert("browser is" + browser)
        //}

        function ShowCurrentTime() {
            PageMethods.GetCurrentTime(OnSuccess);
        }

        function OnSuccess(response, userContext, methodName) {
            debugger;
            alert(response);
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>

        <div>

            <div>
                <asp:DropDownList ID="userDropDownList" runat="server" Width="200px" Style="margin-left: 100px; margin-top: 50px;" AutoPostBack="true">
                    <asp:ListItem>Select User</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <p>New changes to git repo</p>
                <asp:Button ID="btnGallery" runat="server" Text="Go To Gallery" Style="margin-left: 100px; margin-top: 50px;" OnClick="btnGallery_Click" />
                <input id="btnGetTime" type="button" value="Show Current Time" onclick="ShowCurrentTime()" />
            </div>

            <div>
                <center>
                   <%-- Style="border-color:black;border-style: solid;background-color:CadetBlue; border-width: 1px; height: 350px;  width: 500px;"--%>
            <asp:Panel ID="pnlUpload" runat="server" CssClass="uploadpanel" >
                <div style="width: 500px; margin-top: 150px;">
                    <asp:FileUpload ID="imgFileUpload" runat="server" />
                </div>
                <div style="width: 500px; margin-top: 10px">
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                </div>
                <div style="width: 500px; margin-top: 10px">
                  <asp:Label ID="lblMsg" runat="server" Visible="false" CssClass="lblUploadMsg"> </asp:Label>
                </div>
                </asp:Panel>
              </center>
            </div>
        </div>

    </form>
</body>
</html>
