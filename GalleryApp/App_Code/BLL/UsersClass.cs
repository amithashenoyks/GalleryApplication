using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GalleryApp.App_Code.BLL
{

    public class UsersClass
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["galleryAppConnectionstring"].ToString();

        public DataTable GetUsers()
        {
            SqlConnection con = new SqlConnection(connectionstring);

            SqlCommand comm = new SqlCommand("Select * from Users", con);
            con.Open();
            comm.CommandType = CommandType.Text;
            SqlDataReader reader = comm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            con.Close();
            return dt;
        }

        public int SaveImagePath(string ImgPath, int UserId, string date)
        {
            SqlConnection con = new SqlConnection(connectionstring);

            SqlCommand com = new SqlCommand("usr_saveimagepath", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@imgPath", ImgPath);
            com.Parameters.AddWithValue("@userId", UserId);
            com.Parameters.AddWithValue("@datetime", date);
            con.Open();

            int k = com.ExecuteNonQuery();
            con.Close();
            return k;

        }

        public DataTable RetriveImages(int userId)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();


            SqlCommand com = new SqlCommand("Select I.ImgKey,I.ImgPath,I.userID,datename(month, I.iDatetime) + ','+ datename(year, I.iDatetime) As MName,U.UName from ImagePath I inner Join Users U ON I.userID = U.Userid where U.Userid in (Select  UserID from Users where Userid =  " + @userId + ") order by year(I.iDatetime), month(I.iDatetime) desc", con);
            com.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            dt.Load(reader);
            con.Close();
            return dt;
        }
    }
}