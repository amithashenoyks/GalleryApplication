using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GalleryApp.App_Code.BLL;
using System.IO;
using System.Drawing.Imaging;



namespace GalleryApp
{
    public partial class Gallerypage : System.Web.UI.Page
    {
        UsersClass usrCl = new UsersClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            if (!Page.IsPostBack)
            {

                LoadImages(id);
            }
        }

        public void LoadImages(int id)
        {

            //   gridviewGallery.DataSource = usrCl.RetriveImages(id);
            //   gridviewGallery.DataBind();
            dlistImages.DataSource = usrCl.RetriveImages(id);
            dlistImages.DataBind();
        }


        protected void gridviewGallery_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.Image img = e.Row.FindControl("imgThumbnail") as System.Web.UI.WebControls.Image;
                string path = Server.MapPath("Images//" + img.AlternateText);

                img.ImageUrl = GenerateThumbnail(path);
            }
        }
        private string GenerateThumbnail(string path)
        {

            System.Drawing.Image image = System.Drawing.Image.FromFile(path);
            using (System.Drawing.Image thumbnail = image.GetThumbnailImage(75, 75, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    thumbnail.Save(memoryStream, ImageFormat.Png);
                    Byte[] bytes = new Byte[memoryStream.Length];
                    memoryStream.Position = 0;
                    memoryStream.Read(bytes, 0, (int)bytes.Length);
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    return "data:image/png;base64," + base64String;

                }
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        protected void dlistImages_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                System.Web.UI.WebControls.Image img = e.Item.FindControl("imgThumbnail") as System.Web.UI.WebControls.Image;
                string path = Server.MapPath("Images//" + img.AlternateText);

                img.ImageUrl = GenerateThumbnail(path);
            }
        }
    }
}