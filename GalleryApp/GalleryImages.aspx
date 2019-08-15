<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GalleryImages.aspx.cs" Inherits="GalleryApp.GalleryImages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.2.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:GridView ID="gridImages" runat="server" AutoGenerateColumns="false" ShowHeader="false" PageSize="1" AllowPaging="true" OnPageIndexChanging="gridImages_PageIndexChanging">
                <Columns>
                    <asp:ImageField DataImageUrlField="Value" />
                </Columns>
                <PagerSettings Mode="NextPrevious" NextPageText="Next" PreviousPageText="Prev" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
