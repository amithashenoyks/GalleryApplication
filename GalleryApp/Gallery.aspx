<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="GalleryApp.Gallery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="GalleryStyle.css" rel="stylesheet" type="text/css" />
    <title></title>
    <script src="Jscript/jquery-3.2.1.js"></script>
    <script type="text/javascript">

        //$(document).ready(function () {
        //    //debugger;
        //    $("table[id*='dlist']").click(function () {
        //    });
        //});

        //function WindowPopUp(img,dlist) {
        //    debugger;
        //    HideBackground(dlistID,img);
        //    alert("on pop up image name: "+img);
        //}

        function WindowPopUp(imgAlt, dlist) {
            debugger;
            var img = new Image();
            
            var bcgDiv = document.getElementById("divBackground");
            var imgDiv = document.getElementById("divImage");
            var imgFull = document.getElementById("imgFull");
            var imgLoader = document.getElementById("imgLoader");

            var imgs = document.getElementById(dlist).getElementsByTagName("img")
            imgLoader.style.display = "block";

            img.onload = function () {
                imgFull.src = img.src;
                imgFull.style.display = "block";
                imgLoader.style.display = "none";
                document.body.style.overflowY = 'hidden';
            };
            img.src = "Images//" + imgAlt;
            var width = document.body.clientWidth;
            //if (document.body.clientHeight >= document.body.scrollHeight) {
            //    bcgDiv.style.height = document.body.clientHeight + "px";
            //}
            //else {
            //    bcgDiv.style.height = document.body.scrollHeight + "px";
            //}
            imgDiv.style.left = (width - 650) / 2 + "px";
            imgDiv.style.top = "20px";
            bcgDiv.style.width = "100%";

            bcgDiv.style.display = "block";
            imgDiv.style.display = "block";
            return false;

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <section class="intro">
            <div class="container">
                <h1>
                    <asp:Label ID="lblName" runat="server"></asp:Label></h1>
            </div>
        </section>
        <section class="timeline">
            <ul id="ul1" runat="server">
                <%--<li>
                    <div>
                        <asp:DataList ID="dlistImages" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                            OnItemDataBound="dlistImages_ItemDataBound">

                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("UName") %>' Visible="false"></asp:Label>
                                <asp:HyperLink runat="server" onclick="OpenPopUpWindow(this);"
                                    Target="_blank">
                                    <asp:Image ID="imgThumbnail" AlternateText='<%# Eval("ImgPath") %>' runat="server" />
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </li>--%>
            </ul>
        </section>
        <div id="divBackground" class="modal"></div>
        <div id="divImage">
         <table style="height: 100%; width: 100%">
                <tr>
                    <td valign="middle" align="center" colspan="3" style="height: 500px;">
                        <img id="imgLoader" runat="server" alt=""
                            src="images/loader.gif" />
                        <img id="imgFull" alt="" src=""
                            style="display: none; height: 500px; width: 600px" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
