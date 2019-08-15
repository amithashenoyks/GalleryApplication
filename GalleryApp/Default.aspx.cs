using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GalleryApp.App_Code.BLL;
namespace GalleryApp
{
    public partial class Default : System.Web.UI.Page
    {
        UsersClass usrCl = new UsersClass();

        protected void Page_PreInit(object sender, EventArgs e)
        {
          
          
        }


        protected void Page_Init(object sender, EventArgs e)
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {


                GetUserList();
                userDropDownList.Items.Insert(0, "Select");



            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = true;
            if (imgFileUpload.HasFile)
            {
                string path = Server.MapPath("Images//" + imgFileUpload.FileName);
                imgFileUpload.SaveAs(path);
                int userId = Convert.ToInt32(userDropDownList.SelectedValue);
                int k = usrCl.SaveImagePath(imgFileUpload.FileName, userId, DateTime.Now.ToShortDateString());
                if (k != 0)
                {
                    lblMsg.Text = "image uploaded !";
                    lblMsg.ForeColor = System.Drawing.Color.WhiteSmoke;
                }

            }
            else
            {
                lblMsg.Text = "Please select the file.";
            }
        }

        public void GetUserList()
        {
            userDropDownList.DataSource = usrCl.GetUsers();
            userDropDownList.DataTextField = "UName";
            userDropDownList.DataValueField = "Userid";
            userDropDownList.DataBind();
        }

        protected void btnGallery_Click(object sender, EventArgs e)
        {
            if (userDropDownList.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select the user.";
            }
            else
            {
                int id = Convert.ToInt32(userDropDownList.SelectedValue);
                Response.Redirect("Gallery.aspx?id=" + id + "", false);
                //  Response.Redirect("Gallerypage.aspx?id=" + id + "", false);
            }
        }


        [System.Web.Services.WebMethod]
        public static string GetCurrentTime()
        {
            return "Hello " + Environment.NewLine + "The Current Time is: "
                + DateTime.Now.ToString();
        }
    }
}