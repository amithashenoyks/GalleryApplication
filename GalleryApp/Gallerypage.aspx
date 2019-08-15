<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gallerypage.aspx.cs" Inherits="GalleryApp.Gallerypage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">

        function OpenPopUpWindow(lnk) {
            var imgName = lnk.parentNode.parentNode.cells[2].getElementsByTagName("img")[0].alt;
            window.open("GalleryImages.aspx?ImgName=" + imgName);
            // window.showModalDialog("GalleryImages.aspx?ImgName=" + 'flower-2510249__480.jpg', "dialogWidth:800px; dialogHeight:500px; dialogLeft:252px; dialogTop:120px; center:yes");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
      <%--  style="height: 100%; width: 100%; background-color: yellow--%>
        <div style="height: 500px; width: 750px; background-color:burlywood"">
            <br />
            <asp:GridView ID="gridviewGallery" runat="server" AutoGenerateColumns="false"
                Font-Names="Arial" OnRowDataBound="gridviewGallery_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="userID" HeaderText="ID" />
                    <asp:BoundField DataField="iDateTime" HeaderText="Date" />
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" onclick="OpenPopUpWindow(this);"
                                Target="_blank">
                                <asp:Image ID="imgThumbnail" AlternateText='<%# Eval("ImgPath") %>' runat="server" />
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:DataList ID="dlistImages" runat="server" RepeatDirection="Horizontal"  RepeatColumns="4" 
                 OnItemDataBound="dlistImages_ItemDataBound" >
                
                <ItemTemplate>
                     <asp:HyperLink runat="server" onclick="OpenPopUpWindow(this);"
                                Target="_blank">
                                <asp:Image ID="imgThumbnail" AlternateText='<%# Eval("ImgPath") %>' runat="server" />
                          </asp:HyperLink> 
                </ItemTemplate>
            </asp:DataList>

        </div>
    </form>
</body>
</html>
