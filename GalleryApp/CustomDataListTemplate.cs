using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace GalleryApp
{
    public class CustomDataListTemplate : ITemplate
    {

        ListItemType _templatetype;
        //private string _uname;
        //private string _mname;
        //private string _imgpath;
        //public string UName
        //{
        //    get { return _uname; }
        //    set { _uname = value; }
        //}
        //public string MName
        //{
        //    get { return _mname; }
        //    set { _mname = value; }
        //}
        //public string ImgPath
        //{
        //    get { return _imgpath; }
        //    set { _imgpath = value; }
        //}

        public CustomDataListTemplate(ListItemType type)
        {
            _templatetype = type;
        }



        public void InstantiateIn(System.Web.UI.Control container)
        {

            PlaceHolder ph = new PlaceHolder();
            Label lblName = new Label();
            lblName.ID = "lblName";
            Image imgThumbnail = new Image();
            imgThumbnail.ID = "imgThumbnail";
            switch (_templatetype)
            {

                case ListItemType.Item:
                  //  ph.Controls.Add(lblName);
                    ph.Controls.Add(imgThumbnail);
                    ph.DataBinding += new EventHandler(DataBinding);
                    break;
                case ListItemType.AlternatingItem:
                 //   ph.Controls.Add(lblName);
                    ph.Controls.Add(imgThumbnail);
                    ph.DataBinding += new EventHandler(DataBinding);
                    break;
            }


            container.Controls.Add(ph);
        }

        private void DataBinding(object sender, System.EventArgs e)
        {
            PlaceHolder ph;
            ph = (PlaceHolder)sender;
            DataListItem container = (DataListItem)ph.NamingContainer;

        //    String UName = (String)DataBinder.Eval(container.DataItem, "UName");
            String MName = (String)DataBinder.Eval(container.DataItem, "MName");
            String ImgPath = (String)DataBinder.Eval(container.DataItem, "ImgPath");
          //  ((Label)ph.FindControl("lblName")).Text = UName;
            ((Image)ph.FindControl("imgThumbnail")).AlternateText = ImgPath;

        }
    }
}