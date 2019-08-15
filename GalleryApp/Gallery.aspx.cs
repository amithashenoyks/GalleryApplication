using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GalleryApp.App_Code.BLL;
using System.IO;
using System.Drawing.Imaging;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;

namespace GalleryApp
{
    public partial class Gallery : System.Web.UI.Page
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

            List<DataTable> result = usrCl.RetriveImages(id).AsEnumerable()
           .GroupBy(row => row.Field<string>("MName"))
           .Select(g => g.CopyToDataTable())
           .ToList();


            //dlistImages.DataSource = usrCl.RetriveImages(id);
            //dlistImages.DataBind();

            lblName.Text = result[0].Rows[0]["UName"].ToString();
            int listcount = 1;
            for (int i = 0; i < result.Count; i++)
            {

                HtmlGenericControl li = new HtmlGenericControl("li");
                HtmlGenericControl div = new HtmlGenericControl("div");
                HtmlGenericControl label = new HtmlGenericControl("label");
                label.InnerText = result[i].Rows[0]["MName"].ToString();
                ul1.Controls.Add(li);
                li.Controls.Add(label);
                li.Controls.Add(div);
                DataList dlist = ConstructDataList(listcount);
                listcount = listcount + 1;
                div.Controls.Add(dlist);
                dlist.ItemDataBound += new DataListItemEventHandler(dlistImages_ItemDataBound);
                dlist.DataSource = result[i];
                dlist.DataBind();
                // phArticles.Controls.Add(dlArt);

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
            DataList dl = (DataList)sender;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                System.Web.UI.WebControls.Image img = e.Item.FindControl("imgThumbnail") as System.Web.UI.WebControls.Image;
                string path = Server.MapPath("Images//" + img.AlternateText);

                img.ImageUrl = GenerateThumbnail(path);
                img.Attributes.Add("onclick", "javascript:WindowPopUp('" + img.AlternateText + "','" + dl.ID + "')");
            }
        }
        public DataList ConstructDataList(int lcount)
        {
            DataList customDataList = new DataList();
            customDataList.ID = "dlist" + lcount.ToString(); ;
            customDataList.RepeatDirection = RepeatDirection.Horizontal;
              customDataList.RepeatColumns = 4;
         //   customDataList.RepeatColumns = 1;
            customDataList.CellSpacing = 10;
            customDataList.ItemTemplate = new CustomDataListTemplate(ListItemType.Item);
            //  customDataList.AlternatingItemTemplate = new CustomDataListTemplate(ListItemType.AlternatingItem);
            return customDataList;
        }



    }
}