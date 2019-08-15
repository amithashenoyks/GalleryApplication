using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GalleryApp
{
    public partial class GalleryImages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
             
                gridImages.DataSource = GetImages();
                gridImages.DataBind();
            }
        }
        public List<ListItem> GetImages()
        {
            string[] ImagePaths = Directory.GetFiles(Server.MapPath("~/Images/"));
            List<ListItem> Imgs = new List<ListItem>();
            foreach (string imgPath in ImagePaths)
            {
                string ImgName = Path.GetFileName(imgPath);
                Imgs.Add(new ListItem("~/Images/" + ImgName));
            }
            return Imgs;
        }

        protected void gridImages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridImages.PageIndex = e.NewPageIndex;
            gridImages.DataSource = GetImages();
            gridImages.DataBind();
        }
    }
}